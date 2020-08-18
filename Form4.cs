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

namespace Flex00
{
    public partial class Form4 : Form
    {
        Form form2 = Application.OpenForms[2];
        string link = DBHelper.connectionString;

        // Создание формы
        public Form4()
        {
            InitializeComponent();
            LoadData();
            LoadData2();
            comboBox1.SelectedItem = "admin";
            comboBox2.SelectedItem = "admin";
        }

        // Загрузка данных
        public async void LoadData()
        {
            string query = "SELECT * FROM Services";
            using (SqlConnection connection = new SqlConnection(link))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                List<string[]> data = new List<string[]>();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    data.Add(new string[4]);
                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = reader[3].ToString();
                }
                reader.Close();
                dataGridView1.Rows.Clear();
                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
            }
        }
        public async void LoadData2()
        {
            string query = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(link))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                dataGridView2.Rows.Clear();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    dataGridView2.Rows.Add(
                        reader[0],
                        reader[1],
                        reader[2],
                        reader[3],
                        reader[4],
                        reader[5]
                        );
                }
                reader.Close();
            }
        }

        // Проверка лимита
        private void checkBox1_CheckedChanged(object sender, EventArgs e) => textBox3.Enabled = checkBox1.Checked ? true : false;
        private void checkBox2_CheckedChanged(object sender, EventArgs e) => textBox4.Enabled = checkBox2.Checked ? true : false;

        // Главные методы
        private async void btnAddSub_Click(object sender, EventArgs e)
        {
            if (DBHelper.isFormat(textBox1.Text.Trim()) &&
                int.TryParse(textBox2.Text.Trim(), out int price) &&
                textBox1.Text.Trim().Length > 0 &&
                textBox2.Text.Trim().Length > 0 &&
                byte.TryParse(textBox5.Text.Trim(), out byte month))
            {
                Service service = new Service
                {
                    Name = textBox1.Text.Trim(),
                    Price = price,
                    Month = month
                };
                if (checkBox1.Checked)
                {
                    if (int.TryParse(textBox3.Text.Trim(), out int limit))
                        service.Limit = limit.ToString();
                    else
                        MessageBox.Show("Лимит должен быть цифрой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    service.Limit = "-";

                var task = DBHelper.InsertServices(service);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                checkBox1.Checked = false;
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
                    s +
                    DBHelper.getOr() +
                    DBHelper.getIsDigitError("Месяц должен"), 
                    DBHelper.getCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnUpdSub_Click(object sender, EventArgs e)
        {
            string oldName  = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string oldPrice = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string oldLimit = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string oldMonth = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (DBHelper.isFormat(textBox8.Text.Trim()) &&
                int.TryParse(textBox7.Text.Trim(), out int price) &&
                textBox8.Text.Trim().Length > 0 &&
                textBox7.Text.Trim().Length > 0 &&
                byte.TryParse(textBox10.Text.Trim(), out byte month))
            {
                Service service = new Service
                {
                    Name = textBox8.Text.Trim(),
                    Price = price,
                    Month = month
                };
                Service oldService = new Service
                {
                    Name = oldName,
                    Limit = oldLimit
                };
                if (checkBox2.Checked)
                {
                    if (int.TryParse(textBox4.Text.Trim(), out int limit))
                        service.Limit = limit.ToString();
                    else
                        MessageBox.Show("Лимит должен быть цифрой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    service.Limit = "-";

                var task = DBHelper.UpdateService(service, oldService, oldPrice, oldMonth);
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
                    s +
                    DBHelper.getOr() +
                    DBHelper.getIsDigitError("Месяц должен"),
                    DBHelper.getCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (DBHelper.isFormat(tbAddLogin.Text.Trim()) &&
                DBHelper.isFormat(tbAddPass.Text.Trim()) &&
                DBHelper.isFormat(tbAddSname.Text.Trim()) &&
                DBHelper.isFormat(tbAddName.Text.Trim()) &&
                tbAddLogin.Text.Trim().Length > 0 &&
                tbAddSname.Text.Trim().Length > 0 &&
                tbAddName.Text.Trim().Length > 0 &&
                tbAddPass.Text.Trim().Length > 0)
            {
                sql = string.Format("INSERT INTO Users (Surname, Name, Login, Password, Type) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', '{4}')", tbAddSname.Text.Trim(), tbAddName.Text.Trim(), tbAddLogin.Text.Trim(), tbAddPass.Text.Trim(), comboBox1.Text);

                var task = DBHelper.ExecuteCommand(sql);
                tbAddLogin.Text = "";
                tbAddPass.Text = "";
                tbAddSname.Text = "";
                tbAddName.Text = "";
                await task;
                LoadData2();
            }
            else
                MessageBox.Show(DBHelper.getIsFormatError(), DBHelper.getCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private async void btnUpdUser_Click(object sender, EventArgs e)
        {
            string id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            string sql = "";
            if (DBHelper.isFormat(tbUpdLogin.Text.Trim()) &&
                DBHelper.isFormat(tbUpdPass.Text.Trim()) &&
                DBHelper.isFormat(tbUpdSname.Text.Trim()) &&
                DBHelper.isFormat(tbUpdName.Text.Trim()) &&
                tbUpdLogin.Text.Trim().Length > 0 &&
                tbUpdSname.Text.Trim().Length > 0 &&
                tbUpdName.Text.Trim().Length > 0 &&
                tbUpdPass.Text.Trim().Length > 0)
            {
                sql = string.Format("UPDATE Users SET Surname = N'{0}', Name = N'{1}', Login = N'{2}', Password = N'{3}', Type = '{4}' WHERE Id = {5}", tbUpdSname.Text.Trim(), tbUpdName.Text.Trim(), tbUpdLogin.Text.Trim(), tbUpdPass.Text.Trim(), comboBox2.Text, id);

                var task = DBHelper.ExecuteCommand(sql);
                await task;
                LoadData2();
                updateTextBox2();
            }
            else
                MessageBox.Show("Нельзя добавлять ', /, ; и -- \nИли данные должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Выход из формы
        private void Form4_FormClosing(object sender, FormClosingEventArgs e) => exit();
        private void button7_Click(object sender, EventArgs e) { Close(); }
        public void exit()
        {
            form2.Show();
            using (SqlConnection connection = new SqlConnection(link))
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        // Функции
        public void updateTextBox()
        {
            if (dataGridView1.CurrentRow != null &&
                dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "-")
                    checkBox2.Checked = false;
                else
                {
                    checkBox2.Checked = true;
                    textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                }
            }
        }
        public void updateTextBox2()
        {
            if (dataGridView2.CurrentRow != null &&
                dataGridView2.CurrentRow.Cells[0].Value != null)
            {
                tbUpdLogin.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                tbUpdSname.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                tbUpdName.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                tbUpdPass.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                comboBox2.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                updateTextBox();
            }
        }
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 1)
            {
                updateTextBox2();
            }
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e) => updateTextBox();
        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e) => updateTextBox2();

        // Удаление (архив?)
        private void button5_Click(object sender, EventArgs e)
        {
            string name  = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string price = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string limit = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string month = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string text = "Вы действительно хотите удалить '" + name + "' с ценой " + price + " и с лимитом = " + limit + "?";
            string caption = "Удаление записи";

            DialogResult result = MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
                delete(name, price, limit, month);
        }
        public async void delete(string name, string price, string limit, string month)
        {
            string sql = string.Format("DELETE FROM Services WHERE Name = N'{0}' AND Price = {1} AND Limit = N'{2}' AND Month = {3}", name, price, limit, month);

            var task = DBHelper.ExecuteCommand(sql);
            await task;
            LoadData();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string login = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            string id    = dataGridView2.CurrentRow.Cells[0].Value.ToString();

            string text = "Вы действительно хотите удалить '" + login + "' ?";
            string caption = "Удаление записи";

            DialogResult result = MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
                delete2(id);
        }
        public async void delete2(string id)
        {
            string sql = string.Format("DELETE FROM Users WHERE Id = {0}", id);
            var task = DBHelper.ExecuteCommand(sql);
            await task;
            LoadData2();
        }

        // 
        private void bgM1_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM1, 20, e);
        private void bgM2_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM2, 20, e);
    }
}
