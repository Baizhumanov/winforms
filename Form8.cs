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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Flex00
{
    public partial class Form8 : Form
    {
        Form form2 = Application.OpenForms[2];
        DataTable allSoldSub = new DataTable();
        Image image;

        string link = DBHelper.connectionString;

        // Создание формы
        public Form8()
        {
            InitializeComponent();
            LoadData2();
            LoadData();
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            button5.Enabled = Data.Type == "user" ? false : true;
            button8.Enabled = Data.Type == "user" ? false : true;
        }

        // Заполнение данных
        public async void LoadData(string sql = "SELECT * FROM Clients")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(link))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    dgw1.Rows.Clear();
                    while (await reader.ReadAsync())
                    {
                        dgw1.Rows.Add(
                            reader[0],
                            reader[1],
                            reader[2],
                            reader[3],
                            reader[4],
                            reader[5],
                            ((DateTime)reader[6]).ToShortDateString(),
                            ((DateTime)reader[7]).ToShortDateString()
                            );
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            labelInfo.Text ="Всего записей: ";
            labelInfo.Text += Convert.ToString(dgw1.RowCount);
        }
        public async void LoadData2(string sql = "SELECT Id, [Id of Client], [Subscription number], [Payment Date] FROM [Sold Subscriptions]")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(link))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    allSoldSub.Load(reader);
                    allSoldSub.Columns[1].ColumnName = "IdOfClient";
                    dataGridView2.DataSource = allSoldSub;
                    dataGridView2.Columns[1].Visible = false;
                    dataGridView2.Columns[0].Width = 50;
                    dataGridView2.Columns[2].HeaderText = "Номер абонемента";
                    dataGridView2.Columns[3].HeaderText = "Дата покупки";
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Функции
        public void updateTextBox()
        {
            if (dgw1.CurrentRow != null &&
                dgw1.CurrentRow.Cells[0].Value != null)
            {
                tbSurnameUpd.Text = dgw1.CurrentRow.Cells[1].Value.ToString();
                tbNameUpd.Text = dgw1.CurrentRow.Cells[2].Value.ToString();
                textBox10.Text = dgw1.CurrentRow.Cells[3].Value.ToString();
                textBox11.Text = dgw1.CurrentRow.Cells[4].Value.ToString();
                textBox12.Text = dgw1.CurrentRow.Cells[5].Value.ToString();

                lbPatronymic.Text += dgw1.CurrentRow.Cells[3].Value.ToString();
                lbPhone.Text += dgw1.CurrentRow.Cells[4].Value.ToString();
                lbAdd.Text += dgw1.CurrentRow.Cells[6].Value.ToString();
                lbUpd.Text += dgw1.CurrentRow.Cells[7].Value.ToString();
                lbAdditional.Text += dgw1.CurrentRow.Cells[5].Value.ToString();
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                updateTextBox();
            }
        }

        // Добавление клиента
        private async void button2_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (DBHelper.isFormat(tbSurnameAdd.Text.Trim()) &&
                DBHelper.isFormat(tbNameAdd.Text.Trim()) &&
                DBHelper.isFormat(textBox5.Text.Trim()) &&
                DBHelper.isFormat(textBox6.Text.Trim()) &&
                DBHelper.isFormat(textBox7.Text.Trim()) &&
                tbSurnameAdd.Text.Trim().Length > 0 &&
                tbNameAdd.Text.Trim().Length > 0)
            {
                sql = string.Format("INSERT INTO Clients (Surname, Name, Patronymic, Phone, Additional, [Date Add], [Date Update]) VALUES " +
                    "(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', '{6}')",
                    tbSurnameAdd.Text.Trim(),
                    tbNameAdd.Text.Trim(),
                    textBox5.Text.Trim(),
                    textBox6.Text.Trim(),
                    textBox7.Text.Trim(),
                    DateTime.Today.ToString("yyyy-MM-dd"),
                    DateTime.Today.ToString("yyyy-MM-dd"));
                string sql2 = string.Format("INSERT INTO Events (Event, Type, Time, Who) VALUES (N'Добавлен клиент {0}', 'insert', '{1}', '{2}')", tbSurnameAdd.Text.Trim() + " " + tbNameAdd.Text.Trim(), DateTime.Now.ToString("s"), Data.Login);
                var task = DBHelper.ExecuteCommand(sql, sql2);
                tbSurnameAdd.Text = "";
                tbNameAdd.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                await task;
                LoadData();
            }
            else
            {
                string s = "Фамилия и имя не должны быть пустые ";
                MessageBox.Show(DBHelper.getIsFormatError() +
                    DBHelper.getOr() + 
                    s, DBHelper.getCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Выбор клиента
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            button9.Visible = false;
            updateTextBox();
            if (dgw1.CurrentRow != null)
            {
                if (dataGridView2.DataSource as DataTable != null)
                    (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = string.Format("IdOfClient = '{0}'", dgw1.CurrentRow.Cells[0].Value.ToString());

                string id = dgw1.CurrentRow.Cells[0].Value.ToString(); // 72

                string path = Environment.CurrentDirectory + @"\images\" + id + ".jpg";
                try
                {
                    if (File.Exists(path))
                    {
                        image = Image.FromFile(path);
                        if (image != null)
                        {
                            pictureBox1.Image = image;
                            button7.Text = "Изменить фото";
                        }
                    }
                    else
                    {
                        pictureBox1.Image = null;
                        button7.Text = "Добавить фото";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                }
            }
        }
        // Изменение клиента
        private async void button3_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (DBHelper.isFormat(tbSurnameUpd.Text.Trim()) &&
                DBHelper.isFormat(tbNameUpd.Text.Trim()) &&
                DBHelper.isFormat(textBox10.Text.Trim()) &&
                DBHelper.isFormat(textBox11.Text.Trim()) &&
                DBHelper.isFormat(textBox12.Text.Trim()) &&
                tbSurnameUpd.Text.Trim().Length > 0 &&
                tbNameUpd.Text.Trim().Length > 0)
            {
                string id = dgw1.CurrentRow.Cells[0].Value.ToString();
                sql = string.Format("UPDATE Clients SET Surname = N'{0}', Name = N'{1}', Patronymic = N'{2}', " +
                    "Phone = N'{3}', Additional = N'{4}', [Date Update] = '{5}' WHERE Id = '{6}'",
                    tbSurnameUpd.Text.Trim(),
                    tbNameUpd.Text.Trim(),
                    textBox10.Text.Trim(),
                    textBox11.Text.Trim(),
                    textBox12.Text.Trim(),
                    DateTime.Today.ToString("yyyy-MM-dd"),
                    id);
                string sql2 = string.Format("INSERT INTO Events (Event, Type, Time, Who) VALUES (N'Изменен клиент {0}', 'insert', '{1}', '{2}')", tbSurnameUpd.Text.Trim() + " " + tbNameUpd.Text.Trim(), DateTime.Now.ToString("s"), Data.Login);
                var task = DBHelper.ExecuteCommand(sql, sql2);
                sql = string.Format("UPDATE [Sold Subscriptions] SET Surname = N'{0}', Name = N'{1}' WHERE [Id of Client] = '{2}'", tbSurnameUpd.Text.Trim(), tbNameUpd.Text.Trim(), id);
                task = DBHelper.ExecuteCommand(sql);
                await task;
                LoadData();
            }
            else
                MessageBox.Show("Фамилия и имя не может включать при себе ', /, ; и -- \nИли Фамилия и имя не должны быть пустые", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Архив
        private async void button5_Click(object sender, EventArgs e)
        {
            string id = dgw1.CurrentRow.Cells[0].Value.ToString();
            string surname = dgw1.CurrentRow.Cells[1].Value.ToString();
            string name = dgw1.CurrentRow.Cells[2].Value.ToString();

            string text = "Вы действительно хотите отправить в архив " + surname + " " + name + "?";
            string caption = "Перенос записи в архив";

            DialogResult result = MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                var task = Task.Factory.StartNew(() => { }); // для event без await
                var needTask = Task.Factory.StartNew(() => { }); // нужен await
                needTask = DBHelper.DeleteClient(id);

                string text2 = string.Format("Клиент {0} перенесен в архив", surname + " " + name);
                task = DBHelper.InsertEvent(text2, "delete", DateTime.Now.ToString("s"), Data.Login);

                await needTask;
                LoadData();
            }
        }

        // Запросы
        private void button6_Click(object sender, EventArgs e) => LoadData();
        private void button1_Click(object sender, EventArgs e)
        {
            if (DBHelper.isFormat(textBox1.Text.Trim()) &&
                DBHelper.isFormat(textBox2.Text.Trim()))
            {
                string query = "SELECT * FROM Clients WHERE (Surname LIKE N'%" + textBox1.Text.Trim() + "%')";
                query += textBox2.Text.Trim().Length > 0 ? string.Format(" AND Name Like N'%{0}%'", textBox2.Text.Trim()) : "";
                LoadData(query);
            }
            else
                MessageBox.Show(DBHelper.getIsFormatError(), DBHelper.getCaptionIsFormat(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Закрытие формы
        private void button4_Click(object sender, EventArgs e) { Close(); }
        private void Form8_FormClosing(object sender, FormClosingEventArgs e) => exit();
        public void exit()
        {
            form2.Show();
            using (SqlConnection connection = new SqlConnection(link))
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        // Открытие фотки
        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Файлы изображений|*.bmp;*.png;*.jpg|Все файлы|*.*";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                image = Image.FromFile(openFileDialog1.FileName);
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Ошибка чтении картинки");
                return;
            }

            pictureBox1.Image = image;
            button9.Visible = true;
        }
        // Сохранение фотки
        private async void button9_Click(object sender, EventArgs e)
        {
            string id = dgw1.CurrentRow.Cells[0].Value.ToString(); // 72

            string newName = id + ".jpg"; // 72.jpg

            string sql = string.Format("UPDATE Clients SET Image = '{0}' WHERE Id = {1}", newName, id);
            var task = DBHelper.ExecuteCommand(sql);

            string output = Environment.CurrentDirectory + @"\images\" + newName;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (File.Exists(output))
            {
                File.Delete(output);
            }

            File.Copy(openFileDialog1.FileName, output, true);

            string text = "Операция выполнена успешно";
            string caption = "Успешно выполнено";

            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            button9.Visible = false;
            await task;
            dgw1.CurrentCell = dgw1[0, 0];
        }
        // Удаление фотки
        private void button8_Click(object sender, EventArgs e)
        {
            string id = dgw1.CurrentRow.Cells[0].Value.ToString();
            string text = "Вы действительно хотите фото?";
            string caption = "Удаление фото";

            DialogResult result = MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                deleteImage(id);
            }
        }
        public async void deleteImage(string id)
        {
            string sql = string.Format("UPDATE Clients SET Image = '' WHERE Id = {0}", id);
            var task = DBHelper.ExecuteCommand(sql);

            string path = Environment.CurrentDirectory + @"\images\" + id + ".jpg";

            try
            {
                image.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            await task;
            LoadData();
        }

        // Закругленные углы bg
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

            for (int i = 0; i < dgw1.ColumnCount; i++)
            {
                sheet.Cells[1, i + 1] = dgw1.Columns[i].HeaderText;
            }

            for (int i = 0; i < dgw1.RowCount; i++)
            {
                for (int j = 0; j < dgw1.ColumnCount; j++)
                {
                    sheet.Cells[i + 2, j + 1] = dgw1.Rows[i].Cells[j].Value.ToString();
                }
            }

            ex.Visible = true;
            DBHelper.ReleaseExcel(ex);
        }

        private void tbSurnameAdd_TextChanged(object sender, EventArgs e)
        {
            if (!DBHelper.isString(tbSurnameAdd.Text.Trim()))
                lbError1.Text = DBHelper.getSurnameError();
            else
                lbError1.Text = "";
        }
        private void tbNameAdd_TextChanged(object sender, EventArgs e)
        {
            if (!DBHelper.isString(tbNameAdd.Text.Trim()))
                lbError1.Text = DBHelper.getNameError();
            else
                lbError1.Text = "";
        }
        private void tbSurnameUpd_TextChanged(object sender, EventArgs e)
        {
            if (!DBHelper.isString(tbSurnameUpd.Text.Trim()))
                lbError2.Text = DBHelper.getSurnameError();
            else
                lbError2.Text = "";
        }
        private void tbNameUpd_TextChanged(object sender, EventArgs e)
        {
            if (!DBHelper.isString(tbNameUpd.Text.Trim()))
                lbError2.Text = DBHelper.getNameError();
            else
                lbError2.Text = "";
        }
    } 
}
