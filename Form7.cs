using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Flex00
{
    public partial class Form7 : Form
    {
        string link = DBHelper.connectionString;
        Form form2 = Application.OpenForms[2];

        // Создание формы
        public Form7()
        {
            InitializeComponent();
            LoadData();
            LoadData2();
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            if (Data.Type == "user")
            {
                tabControl1.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;
            }
            else
            {
                tabControl1.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
            }
        }

        // Закрытие формы
        private void button4_Click(object sender, EventArgs e)
        {
            form2.Show();
            using (SqlConnection connection = new SqlConnection(link))
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            Close();
        }
        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            form2.Show();
            using (SqlConnection connection = new SqlConnection(link))
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        // Заполнение данных
        public async void LoadData()
        {
            string query = "SELECT * FROM OneVisitServices";
            using (SqlConnection connection = new SqlConnection(link))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                dataGridView1.Rows.Clear();
                while (await reader.ReadAsync())
                {
                    dataGridView1.Rows.Add(
                            reader[0],
                            reader[1]
                            );
                }
                reader.Close();
            }
        }
        public async void LoadData2(string query = "SELECT * FROM OneVisits")
        {
            int amount = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(link))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    dgw2.Rows.Clear();
                    while (await reader.ReadAsync())
                    {
                        dgw2.Rows.Add(
                                reader[0],
                                reader[1],
                                reader[2],
                                reader[3],
                                reader[4]
                                );
                        amount += (int)reader[2];
                    }
                    reader.Close();
                }
                label5.Text = "Всего записей: ";
                label5.Text += Convert.ToString(dgw2.RowCount);
                label5.Text += "\nСумма: " + amount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Все функции
        public void updateTextBox()
        {
            if (dataGridView1.CurrentRow != null &&
                dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                tbNameUpd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tbPriceUpd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
        }
        public async void delete(string name, string price)
        {
            string sql = string.Format("DELETE FROM OneVisitServices WHERE Name = N'{0}' AND Price = {1} ", name, price);
            var task = DBHelper.ExecuteCommand(sql);
            await task;
            LoadData();
        }
        public async void delete2(string id, string time)
        {
            string sql = string.Format("DELETE FROM OneVisits WHERE Id = '{0}'", id);
            string sqlEvent = string.Format("INSERT INTO Events (Event, Type, Time, Who) VALUES (N'{0}', 'delete', '{1}', '{2}')", "Удалено разовое посещение [" + time + "]", DateTime.Now.ToString("s"), Data.Login);
            var task = DBHelper.ExecuteCommand(sql, sqlEvent);
            await task;
            LoadData2();
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e) => updateTextBox();

        // Добавить, изменить и удалить услугу
        private async void button1_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (DBHelper.isFormat(tbNameAdd.Text.Trim()) &&
                int.TryParse(tbPriceAdd.Text.Trim(), out int price) &&
                tbNameAdd.Text.Trim().Length > 0 &&
                tbPriceAdd.Text.Trim().Length > 0)
            {
                sql = string.Format("INSERT INTO OneVisitServices VALUES (N'{0}', {1})", tbNameAdd.Text.Trim(), price);
                var task = DBHelper.ExecuteCommand(sql);
                tbNameAdd.Text = "";
                tbPriceAdd.Text = "";
                await task;
                LoadData();
            }
            else
            {
                string s = "Название и цены не должны быть пустые ";
                MessageBox.Show(DBHelper.getIsFormatError() +
                    DBHelper.getOr() +
                    DBHelper.getIsDigitError("Цена должна") +
                    DBHelper.getOr() +
                    s, DBHelper.getCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            string oldName = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string oldPrice = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string sql = "";
            if (DBHelper.isFormat(tbNameUpd.Text.Trim()) &&
                int.TryParse(tbPriceUpd.Text.Trim(), out int price) &&
                tbNameUpd.Text.Trim().Length > 0 &&
                tbPriceUpd.Text.Trim().Length > 0)
            {
                sql = string.Format("UPDATE OneVisitServices SET Name = N'{0}', Price = {1} WHERE (Name = N'{2}') AND (Price = {3})", tbNameUpd.Text.Trim(), price, oldName, oldPrice);
                var task = DBHelper.ExecuteCommand(sql);
                await task;
                LoadData();
                updateTextBox();
            }
            else
            {
                string s = "Название и цены не должны быть пустые ";
                MessageBox.Show(DBHelper.getIsFormatError() +
                    DBHelper.getOr() +
                    DBHelper.getIsDigitError("Цена должна") +
                    DBHelper.getOr() +
                    s, DBHelper.getCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string price = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            string text = "Вы действительно хотите удалить '" + name + "' с ценой " + price + "?";
            string caption = "Удаление записи";

            DialogResult result = MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
                delete(name, price);
        }

        // Продажа услуги
        private async void button6_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string price = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string payment = cbCash.Checked ? "Наличные" : "Не наличные";

            string sql = string.Format("INSERT INTO OneVisits (Name, Price, Time, TypePayment) VALUES (N'{0}', {1}, '{2}', N'{3}')", name, price, DateTime.Now.ToString("s"), payment);
            string sqlEvent = string.Format("INSERT INTO Events (Event, Type, Time, Who) VALUES (N'{0}', 'onevisit', '{1}', '{2}')", "Разовое посещение [" + name + "]", DateTime.Now.ToString("s"), Data.Login);
            var task = DBHelper.ExecuteCommand(sql, sqlEvent);
            await task;
            LoadData2();

            string text = "Услуга успешно продано";
            string caption = "Успешно выполнено";
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgw2.CurrentCell = dgw2[0, dgw2.RowCount - 1];
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string id = dgw2.CurrentRow.Cells[0].Value.ToString();
            string time = dgw2.CurrentRow.Cells[3].Value.ToString();

            string text = "Вы действительно хотите удалить '" + time + "' ?";
            string caption = "Удаление записи";

            DialogResult result = MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
                delete2(id, time);
        }

        // Дополнительные кнопки
        private void button8_Click(object sender, EventArgs e) => dtp1.Value = DateTime.Today;
        private void button7_Click(object sender, EventArgs e) => dtp1.Value = DateTime.Today.AddDays(-1);
        private void button10_Click(object sender, EventArgs e) => LoadData2();

        // Запрос
        private void button9_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM OneVisits WHERE ";
            if (tabControl2.SelectedIndex == 0)
            {
                sql += "Time > '" + dtp1.Value.Date.ToString("yyyy-MM-dd") + "T00:00:00' AND Time < '" + dtp1.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "T00:00:00' ";
            }
            if (tabControl2.SelectedIndex == 1)
                sql += "Time >= '" + dtp2.Value.Date.ToString("yyyy-MM-dd") + "T00:00:00' AND Time <= '" + dtp3.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "T00:00:00' ";
            LoadData2(sql);
        }

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
        private void tbPriceUpd_TextChanged(object sender, EventArgs e)
        {
            if (tbPriceUpd.Text.Trim() == "")
            {
                lbError2.Text = "";
                return;
            }
            lbError2.Text = !int.TryParse(tbPriceUpd.Text.Trim(), out int price) ? DBHelper.getIsDigitError("Цена должна") : "";
        }

        // Закругленные углы - panel
        private void bgM1_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM1, 20, e);
        private void bgM2_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM2, 20, e);
        private void bgM3_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM3, 20, e);
        private void bgM4_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM4, 20, e);
        private void bgM5_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM5, 20, e);

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
            DBHelper.ReleaseExcel(ex);
        }
    }
}
