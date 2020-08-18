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
using System.Threading;

namespace Flex00
{
    public partial class Form2 : Form
    {
        Form formAuth = Application.OpenForms[1];
        string link = DBHelper.connectionString;
        
        // Заполнение данных
        public void LoadData()
        {
            string sql = cbActive.Checked
                ? "SELECT * FROM [Sold Subscriptions] WHERE [End Date] > '" + DateTime.Today.ToString("yyyy-MM-dd") + "' ORDER BY [End Date]"
                : "SELECT * FROM [Sold Subscriptions] ORDER BY [End Date]";
            executeCommand(sql);
        }
        public async void executeCommand(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(link))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(query, connection);
                    List<string> data = new List<string>();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    dataGridView1.Rows.Clear();
                    while (await reader.ReadAsync())
                    {
                        string withTrainer = (bool)reader[10] ? "Да" : "Нет";
                        string withCash = (bool)reader[12] ? "Наличные" : "Не наличные";
                        dataGridView1.Rows.Add(
                            reader[0], // Id
                            reader[1], // Id of Client
                            reader[2], // Surname
                            reader[3], // Name
                            reader[4], // Sub num
                            reader[5], // Sub type
                            ((DateTime)reader[6]).ToShortDateString(), // start date
                            ((DateTime)reader[7]).ToShortDateString(), // end date
                            reader[8], // visit
                            ((DateTime)reader[9]).ToShortDateString(), // payment date
                            withTrainer,
                            reader[11], // With discount
                            withCash, //
                            reader[13], // Amount
                            reader[14] // Add
                            );
                        data.Add(reader[4].ToString());
                    }
                    Data.SubNumbers = data;
                    reader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
            label5.Text =  "Всего записей: ";
            label5.Text += Convert.ToString(dataGridView1.RowCount);
        }

        // Создание формы (разное состоянии)
        public Form2()
        {
            InitializeComponent();
            addService();
            DBHelper.addDiscounts();
            LoadData();
            setSubTypes();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (Data.Type == "user")
            {
                btnDelete.Enabled = false;
                управляющийToolStripMenuItem.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
                управляющийToolStripMenuItem.Enabled = true;
                button3.Enabled = true;
            }
        }
        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            if (!cbActive.Checked)
                cbActive.Checked = true;  // Автоматом вызывается LoadData()
            else
                LoadData();

            addService();
            DBHelper.addDiscounts();
            setSubTypes();
        }

        // Функции
        public void setSubTypes()
        {
            List<string> data = new List<string>();
            data.Add("");
            Data.SubTypes = data;
        }

        // Создание CheckBox для фильтрации
        public async void addService()
        {
            panel1.Controls.Clear();
            using (SqlConnection connection = new SqlConnection(link))
            {
                string query = "SELECT * FROM Services";
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                List<string> data = new List<string>();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                short left = 10;
                short top = 10;
                short i = 0;
                while (await reader.ReadAsync())
                {
                    string name  = reader.GetValue(0).ToString();
                    string price = reader.GetValue(1).ToString();
                    string limit = reader.GetValue(2).ToString() == "-" ? "no" : "yes";
                    string month = reader.GetValue(3).ToString();
                    data.Add("[" + name + "]{" + price + "}(" + month + ")" + limit);

                    CheckBox newCheckBox = new CheckBox
                    {
                        Name = "chBox" + i.ToString(),
                        Text = name,
                        Left = left,
                        Top = top,
                        AutoSize = true
                    };
                    newCheckBox.CheckedChanged += new EventHandler(CheckBoxOnChecked);
                    newCheckBox.Font = new Font("Segoi UI", 10, FontStyle.Regular);

                    panel1.Controls.Add(newCheckBox);
                    top += Convert.ToInt16(newCheckBox.Height + 10);
                    i++;
                }
                reader.Close();
                Data.Service = data;
            }
        }
        public void CheckBoxOnChecked(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            string name = checkBox.Text;
            if (checkBox != null)
            {
                if (checkBox.Checked)
                    Data.SubTypes.Add(name);
                else
                    Data.SubTypes.Remove(name);
            }
        }

        // Выход из страницы
        private void button1_Click(object sender, EventArgs e) { Close(); }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !exit() ? true : false;
        public bool exit()
        {
            string text = "Вы действительно хотите выйти? ";
            string caption = "Выйти из аккаунта";
            DialogResult result = MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                formAuth.Show();
                using (SqlConnection connection = new SqlConnection(link))
                {
                    if (connection != null && connection.State != ConnectionState.Closed)
                        connection.Close();
                }
                return true;
            } else
            {
                return false;
            }
        }

        // Открытие других страниц
        private void button2_Click(object sender, EventArgs e)
        {
            Form formAdd = new FormAdd();
            formAdd.Show();
            Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Data.Action = "update";
            Data.Id = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            Data.IdOfClient = dataGridView1.CurrentRow.Cells["IdOfClient"].Value.ToString();
            Data.Surname = dataGridView1.CurrentRow.Cells["Surname"].Value.ToString();
            Data.Name = dataGridView1.CurrentRow.Cells["NameDB"].Value.ToString();
            Data.SubscriptionNumber = dataGridView1.CurrentRow.Cells["SubscriptionNumber"].Value.ToString();
            Data.SubscriptionType = dataGridView1.CurrentRow.Cells["SubscriptionType"].Value.ToString().Trim();
            Data.StartDate = dataGridView1.CurrentRow.Cells["StartDate"].Value.ToString();
            Data.EndDate = dataGridView1.CurrentRow.Cells["EndDate"].Value.ToString();
            Data.Limit = dataGridView1.CurrentRow.Cells["Visit"].Value.ToString();
            Data.PaymentDate = dataGridView1.CurrentRow.Cells["PaymentDate"].Value.ToString();
            Data.WithTrainer = dataGridView1.CurrentRow.Cells["WithTrainer"].Value.ToString();
            Data.Discount = dataGridView1.CurrentRow.Cells["WithDiscount"].Value.ToString();
            Data.TypePayment = dataGridView1.CurrentRow.Cells["TypePayment"].Value.ToString();
            Data.Amount = dataGridView1.CurrentRow.Cells["Amount"].Value.ToString();
            Data.Additional = dataGridView1.CurrentRow.Cells["Additional"].Value.ToString();
            Form formAdd = new FormAdd();
            formAdd.Show();
            Hide();
        }
        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form8 = new Form8();
            form8.Show();
            Hide();
        }
        private void всяТаблицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form6 = new Form6();
            form6.Show();
            Hide();
        }
        private void журналСобытийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form5 = new Form5();
            form5.Show();
            Hide();
        }
        private void продажиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form9 = new Form9();
            form9.Show();
            Hide();
        }
        private void разовыеПосещенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form7 = new Form7();
            form7.Show();
            Hide();
        }
        private void управляющийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form4 = new Form4();
            form4.Show();
            Hide();
        }
        private void архивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formArcive = new FormArchive();
            formArcive.Show();
            Hide();
        }

        // Архив и пришел
        private async void button4_Click(object sender, EventArgs e)
        {
            string surname = dataGridView1.CurrentRow.Cells["Surname"].Value.ToString();
            string name    = dataGridView1.CurrentRow.Cells["NameDB"].Value.ToString();

            string text1 = "Вы действительно хотите отправить в архив " + surname + " " + name + "?";
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
                needTask = DBHelper.DeleteSoldSub(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

                string text = string.Format("Абонемент {0} перенесен в архив", surname + " " + name);
                task = DBHelper.InsertEvent(text, "delete", DateTime.Now.ToString("s"), Data.Login);

                await needTask;
                LoadData();
            }
        }
        private async void button11_Click(object sender, EventArgs e)
        {
            string limit = dataGridView1.CurrentRow.Cells["Visit"].Value.ToString();
            string id = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            string surname = dataGridView1.CurrentRow.Cells["Surname"].Value.ToString();
            string name = dataGridView1.CurrentRow.Cells["NameDB"].Value.ToString();
            if (limit != "")
            {
                if (limit != "0")
                {
                    byte limitByte = Convert.ToByte(limit);
                    limitByte--;

                    Task task = DBHelper.DecrementVisit(limitByte, id);

                    string text = string.Format("Пришел пользователь {0}", surname + " " + name);
                    Task task2 = DBHelper.InsertEvent(text, "come", DateTime.Now.ToString("s"), Data.Login);

                    await task;
                    LoadData();
                    string text1 = "Операция выполнена успешно";
                    string caption1 = "Успешно выполнено";
                    MessageBox.Show(text1, caption1, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string text2 ="Все доступные занятии закончены";
                    string caption2 ="Предупреждение";
                    MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string text3 ="Он безлимит";
                string caption3 = "Предупреждение";
                MessageBox.Show(text3, caption3, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Запросы (Если поменяется БД, то переписать их)
        private void button5_Click(object sender, EventArgs e)
        {
            if (DBHelper.isFormat(tbSurname.Text.Trim()) &&
                DBHelper.isFormat(tbName.Text.Trim()))
            {
                string query = "SELECT * FROM [Sold Subscriptions] WHERE (Surname LIKE N'%" + tbSurname.Text.Trim() + "%')";
                query += tbName.Text.Trim().Length > 0 ? string.Format(" AND (Name Like N'%{0}%')", tbName.Text.Trim()) : "";
                query += string.Format(" AND ([End Date] > '{0}') ORDER BY [End Date]", DateTime.Today.ToString("yyyy-MM-dd"));
                executeCommand(query);
            }
            else
                MessageBox.Show(DBHelper.ERROR_ISFORMAT, DBHelper.CAPTION_ISFORMAT, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void button8_Click(object sender, EventArgs e)
        {            
            if (int.TryParse(tbSubNumber.Text.Trim(), out int subscriptionNumber))
            {
                string query = string.Format("SELECT * FROM [Sold Subscriptions] WHERE [Subscription number] = {0} AND [End Date] > '{1}' ORDER BY [End Date]", tbSubNumber.Text.Trim(), DateTime.Today.ToString("yyyy-MM-dd"));
                executeCommand(query);
            }
            else if (tbSubNumber.Text.Trim() == "")
            {
                LoadData();
            }
            else
            {
                string caption = "Ескерту";
                string text = "Номер абонемента должен состоять только из цифр";
                MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            string sql = "";
            string types = "";
            if (Data.SubTypes.Count > 1)
            {
                for (int i = 0; i < Data.SubTypes.Count; i++)
                {
                    if (i + 1 == Data.SubTypes.Count)
                        types += string.Format("N'{0}'", Data.SubTypes[i]);
                    else
                        types += string.Format("N'{0}', ", Data.SubTypes[i]);
                }
                sql = string.Format("SELECT * FROM [Sold Subscriptions] WHERE ([Subscription Type] IN ({0})) AND ([End Date] > '{1}') ORDER BY [End Date]", types, DateTime.Today.ToString("yyyy-MM-dd"));
                if (!cbActive.Checked)
                    sql = string.Format("SELECT * FROM [Sold Subscriptions] WHERE [Subscription Type] IN ({0}) ORDER BY [End Date]", types);
            }
            else
            {
                sql = "SELECT * FROM [Sold Subscriptions] WHERE [End Date] > '" + DateTime.Today.ToString("yyyy-MM-dd") + "' ORDER BY [End Date]";
                if (!cbActive.Checked)
                    sql = "SELECT * FROM [Sold Subscriptions] ORDER BY [End Date]";
            }
            executeCommand(sql);
        }
        private void button12_Click(object sender, EventArgs e) => LoadData();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string sql = cbActive.Checked
                ? "SELECT * FROM [Sold Subscriptions] WHERE [End Date] > '" + DateTime.Today.ToString("yyyy-MM-dd") + "' ORDER BY [End Date]"
                : "SELECT * FROM [Sold Subscriptions] ORDER BY [End Date]";
            executeCommand(sql);
        }

        // Сброс
        private void button13_Click(object sender, EventArgs e)
        {
            tbSurname.Clear();
            tbName.Clear();
            tbSubNumber.Clear();
            foreach (Control control in panel1.Controls)
            {
                CheckBox checkBox;
                if (control.GetType() == typeof(CheckBox))
                {
                    checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }
            }
            cbActive.Checked = true;
        }

        // Закругленные углы bg
        private void bgM1_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM1, 20, e);
        private void bgM2_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM2, 20, e);
        private void bgM3_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM3, 20, e);
        
        // Проверка данных
        private void tbSurname_TextChanged(object sender, EventArgs e) => lbError.Text = !DBHelper.isString(tbSurname.Text.Trim()) ? DBHelper.getSurnameError() : "";
        private void tbName_TextChanged(object sender, EventArgs e) => lbError.Text = !DBHelper.isString(tbName.Text.Trim()) ? DBHelper.getNameError() : "";
        private void tbSubNumber_TextChanged(object sender, EventArgs e)
        {
            if (tbSubNumber.Text.Trim() == "") { lbError.Text = ""; return; }
            string text = "Номер тек саннан тұру қажет";
            lbError.Text = !DBHelper.isDigit(tbSubNumber.Text.Trim()) ? text : "";
        }
    }
}
