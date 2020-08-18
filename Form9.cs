using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Flex00
{
    public partial class Form9 : Form
    {
        Form form2 = Application.OpenForms[2];
        string link = DBHelper.connectionString;

        // Первая загрузка - язык и роль
        public Form9()
        {
            InitializeComponent();
            LoadData();
            LoadData2();
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            if (Data.Type == "user")
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button6.Enabled = false;
                button13.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button6.Enabled = true;
                button13.Enabled = true;
            }
        }

        // Вывод данных (Если поменяю БД, то переписать)
        public async void LoadData(string sql = "SELECT * FROM Products")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(link))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    dataGridView1.Rows.Clear();
                    while (await reader.ReadAsync())
                    {
                        dataGridView1.Rows.Add(
                            reader[0],
                            reader[1],
                            reader[2],
                            reader[3]
                            );
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            labelInfo.Text = "Всего записей: ";
            labelInfo.Text += Convert.ToString(dataGridView1.RowCount);
        }
        public async void LoadData2(string sql = "SELECT * FROM Sells")
        {
            int amount = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(link))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    dgw2.Rows.Clear();
                    while (await reader.ReadAsync())
                    {
                        dgw2.Rows.Add(
                            reader[0],
                            reader[1],
                            reader[2],
                            reader[3],
                            reader[4],
                            reader[5],
                            reader[6]
                            );
                        amount += (int)reader[5];
                    }
                    reader.Close();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            labelInfo2.Text = "Всего записей: ";
            labelInfo2.Text += Convert.ToString(dgw2.RowCount);
            labelInfo2.Text += "\nСумма: " + amount;
        }

        // Добавить продукт, Изменить продукт и продвать продукт
        private async void button2_Click(object sender, EventArgs e)
        {
            if (DBHelper.isFormat(tbNameAdd.Text.Trim()) &&
                int.TryParse(tbPriceAdd.Text.Trim(), out int price) &&
                tbNameAdd.Text.Trim().Length > 0 &&
                tbPriceAdd.Text.Trim().Length > 0 &&
                tbCountAdd.Text.Trim().Length > 0 &&
                int.TryParse(tbCountAdd.Text.Trim(), out int count))
            {
                Product product = new Product
                {
                    Name = tbNameAdd.Text.Trim(),
                    Price = price,
                    Count = count
                };
                Task task = DBHelper.InsertProduct(product);
                tbNameAdd.Text = "";
                tbPriceAdd.Text = "";
                tbCountAdd.Text = "";
                await task;
                LoadData();
            }
            else
            {
                string s = "все данные не должны быть пустые";
                MessageBox.Show(DBHelper.getIsFormatError() +
                    DBHelper.getOr() +
                    s +
                    DBHelper.getOr() +
                    DBHelper.getIsDigitError("Цена и кол-во должны"), DBHelper.getCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            if (DBHelper.isString(tbNameUpd.Text.Trim()) &&
                int.TryParse(tbPriceUpd.Text.Trim(), out int price) &&
                tbNameUpd.Text.Trim().Length > 0 &&
                tbPriceUpd.Text.Trim().Length > 0 &&
                tbCountUpd.Text.Trim().Length > 0 &&
                int.TryParse(tbCountUpd.Text.Trim(), out int count))
            {
                Product product = new Product
                {
                    Name = tbNameUpd.Text.Trim(),
                    Price = price,
                    Count = count
                };
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                Task task = DBHelper.UpdateProduct(product, id);
                await task;
                LoadData();
            }
            else
            {
                string s = "все данные не должны быть пустые";
                MessageBox.Show(DBHelper.getIsFormatError() +
                    DBHelper.getOr() +
                    s +
                    DBHelper.getOr() +
                    DBHelper.getIsDigitError("Цена и кол-во должны"), DBHelper.getCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (DBHelper.isFormat(tbCountSell.Text.Trim()) &&
                DBHelper.isFormat(tbPriceSell.Text.Trim()) &&
                int.TryParse(tbPriceSell.Text.Trim(), out int price) &&
                tbCountSell.Text.Trim().Length > 0 &&
                tbPriceSell.Text.Trim().Length > 0 &&
                int.TryParse(tbCountSell.Text.Trim(), out int count))
            {
                if (Convert.ToInt16(dataGridView1.CurrentRow.Cells[2].Value) > Convert.ToInt16(tbCountSell.Text.Trim()))
                {
                    Sell sell = new Sell
                    {
                        Name = dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                        Count = count,
                        Price = price,
                        Date = DateTime.Now.ToString("s"),
                        Amount = price * count,
                        TypePayment = checkBox1.Checked ? "Наличные" : "Не наличные"
                    };

                    Task task = DBHelper.InsertSell(sell);
                    
                    string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    int oldCount = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);

                    Task task2 = DBHelper.DecrementProduct((oldCount - count), id); // тут был ToString() 
                    
                    string text = "Продан продукт " + sell.Name + " за цену " + sell.Price + ". Кол-во = " + count + ". Сумма = " + sell.Amount;
                    Task task3 = DBHelper.InsertEvent(text, "sell", DateTime.Now.ToString("s"), Data.Login);

                    await task;  LoadData2();
                    dgw2.CurrentCell = dgw2[0, dgw2.RowCount - 1];
                    await task2; LoadData();
                    MessageBox.Show("Товар успешно продан", "Успешно выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string s = "Недостаточное количество продуктов для продажи";
                    MessageBox.Show(s, DBHelper.getCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string s = "все данные не должны быть пустые";
                MessageBox.Show(DBHelper.getIsFormatError() +
                    DBHelper.getOr() +
                    s +
                    DBHelper.getOr() +
                    DBHelper.getIsDigitError("Цена и кол-во должны"), DBHelper.getCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Автоматом вставлять данные в tb
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e) => updateTextBox();
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e) => updateTextBox();
        public void updateTextBox()
        {
            if (dataGridView1.CurrentRow != null &&
                dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                label4.Text += dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tbNameUpd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tbPriceUpd.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tbCountUpd.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tbPriceSell.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
        }
        
        // Просто функции (Переписать на нормальную версию без MB)
        public void decide()
        {
            if (tbCountSell.Text.Trim().Length > 0)
            {
                if (short.TryParse(tbCountSell.Text.Trim(), out short count) &&
                    int.TryParse(tbPriceSell.Text.Trim(), out int price) )
                {
                    try
                    {
                        label14.Text += (price * count).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Поиск (Если поменяю БД, то переписать)
        private void button5_Click(object sender, EventArgs e)
        {
            string query = string.Format("SELECT * FROM Sells WHERE Name Like '%{0}%'", textBox10.Text.Trim());
            LoadData2(query);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Sells WHERE ";
            if (tabControl1.SelectedIndex == 0)
            {
                sql += "Date > '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "T00:00:00' AND Date < '" + dateTimePicker1.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "T00:00:00' ";
            }
            if (tabControl1.SelectedIndex == 1)
                sql += "Date >= '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "T00:00:00' AND Date <= '" + dateTimePicker3.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "T00:00:00' ";
            LoadData2(sql);
        }

        // Кнопки дат
        private void button8_Click(object sender, EventArgs e) => dateTimePicker1.Value = DateTime.Today;
        private void button7_Click(object sender, EventArgs e) => dateTimePicker1.Value = DateTime.Today.AddDays(-1);

        // Архивы
        private async void button6_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            string text1 = "Вы действительно хотите отправить в архив " + name + "?";
            string caption = "Перенос в Архив";

            DialogResult result = MessageBox.Show(
                text1,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                var task = Task.Factory.StartNew(() => { }); // для event без await
                var needTask = Task.Factory.StartNew(() => { }); // нужен await
                needTask = DBHelper.DeleteProduct(id);

                string text = string.Format("Продукт {0} перенесен в архив", name);
                task = DBHelper.InsertEvent(text, "delete", DateTime.Now.ToString("s"), Data.Login);

                await needTask;
                LoadData();
            }
        }
        private async void button13_Click(object sender, EventArgs e)
        {
            string id = dgw2.CurrentRow.Cells[0].Value.ToString();

            string text1 = "Вы действительно хотите перенести в архив транзакцию '" + id + "'?";
            string caption = "Перенос в Архив";

            DialogResult result = MessageBox.Show(
                text1,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                var task = Task.Factory.StartNew(() => { }); // для event без await
                var needTask = Task.Factory.StartNew(() => { }); // нужен await
                needTask = DBHelper.DeleteSell(id);

                string text = string.Format("Транзакция №{0} перенесена в архив", id);
                task = DBHelper.InsertEvent(text, "delete", DateTime.Now.ToString("s"), Data.Login);

                await needTask;
                LoadData2();
            }
        }

        // Выход из страницы
        private void button10_Click(object sender, EventArgs e)
        {
            form2.Show();
            using (SqlConnection connection = new SqlConnection(link))
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            Close();
        }
        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            form2.Show();
            using (SqlConnection connection = new SqlConnection(link))
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        // Обновить
        private void button11_Click(object sender, EventArgs e) => LoadData();
        private void button12_Click(object sender, EventArgs e) => LoadData2();
        
        // Закругленные углы - panel
        private void bgM2_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM2, 20, e);
        private void bgM3_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM3, 20, e);
        private void bgM4_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM4, 20, e);

        // Проверка данных
        private void tbPriceAdd_TextChanged(object sender, EventArgs e)
        {
            if (tbPriceAdd.Text.Trim() == "")
            {
                lbError1.Text = "";
                return;
            }
            lbError1.Text = !int.TryParse(tbPriceAdd.Text.Trim(), out int price) ? DBHelper.getIsDigitError("Цена должна") : "";
        }
        private void tbCountAdd_TextChanged(object sender, EventArgs e)
        {
            if (tbCountAdd.Text.Trim() == "")
            {
                lbError1.Text = "";
                return;
            }
            lbError1.Text = !int.TryParse(tbCountAdd.Text.Trim(), out int price) ? DBHelper.getIsDigitError("Кол-во должно") : "";
        }
        private void tbPriceUpd_TextChanged(object sender, EventArgs e)
        {
            if (tbPriceUpd.Text.Trim() == "")
            {
                lbError2.Text = "";
                return;
            }
            lbError2.Text = !int.TryParse(tbPriceUpd.Text.Trim(), out int price) ? DBHelper.getIsDigitError("Цена должна") : "";
        }
        private void tbCountUpd_TextChanged(object sender, EventArgs e)
        {
            if (tbCountUpd.Text.Trim() == "")
            {
                lbError2.Text = "";
                return;
            }
            lbError2.Text = !int.TryParse(tbCountUpd.Text.Trim(), out int price) ? DBHelper.getIsDigitError("Кол-во должно") : "";
        }
        private void tbCountSell_TextChanged(object sender, EventArgs e)
        {
            if (tbCountSell.Text.Trim() == "")
            {
                lbError3.Text = "";
                return;
            }
            lbError3.Text = !int.TryParse(tbCountSell.Text.Trim(), out int price) ? DBHelper.getIsDigitError("Кол-во должно") : "";
            decide();
        }
        private void tbPriceSell_TextChanged(object sender, EventArgs e)
        {
            if (tbPriceSell.Text.Trim() == "")
            {
                lbError3.Text = "";
                return;
            }
            lbError3.Text = !int.TryParse(tbPriceSell.Text.Trim(), out int price) ? DBHelper.getIsDigitError("Цена должна") : "";
            decide();
        }

        // Excel
        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application ex = new Excel.Application();

            ex.SheetsInNewWorkbook = 2;
            Excel.Workbook workbook = ex.Workbooks.Add(Type.Missing);
            ex.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);

            for (int i = 0; i < dgw2.ColumnCount; i++)
            {
                sheet.Cells[1, i + 1] = dgw2.Columns[i].HeaderText;
            }

            for (int i = 0; i < dgw2.RowCount; i++)
            {
                for (int j = 0; j < dgw2.ColumnCount; j++)
                {
                    sheet.Cells[i + 2, j + 1] = dgw2.Rows[i].Cells[j].Value.ToString();
                }
            }

            ex.Visible = true;
            DBHelper.ReleaseExcel(ex as object);
        }
    }
}
