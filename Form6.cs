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
    public partial class Form6 : Form
    {
        Form form2 = Application.OpenForms[2];
        string link = DBHelper.connectionString;

        // Создание формы
        public Form6()
        {
            InitializeComponent();
            LoadData();
            showService();
            Data.SubTypes.Clear(); // Сброс выбранных абонементов
        }

        // Вывод данных
        public async void LoadData(string query = "SELECT * FROM [Sold Subscriptions]")
        {
            int amount = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(link))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    dgw.Rows.Clear();
                    while (await reader.ReadAsync())
                    {
                        string withTrainer = (bool)reader[10] ? "Да" : "Нет";
                        string withCash = (bool)reader[12] ? "Наличные" : "Не наличные";
                        dgw.Rows.Add(
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
                        amount += (int)reader[13];
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lbInfo.Text = "Всего записей: ";
            lbInfo.Text += Convert.ToString(dgw.RowCount);
            lbInfo.Text += "\nСумма: " + amount;
        }

        // Вывод абонементов
        public void showService()
        {
            short left = 10;
            short top = 10;
            for (short i = 0; i < Data.Service.Count; i++)
            {
                string name = Data.Service[i].Substring(1, Data.Service[i].IndexOf("]") - 1);
                CheckBox newCheckBox = new CheckBox
                {
                    Name = "chBox" + i.ToString(),
                    Text = name,
                    Left = left,
                    Top = top,
                    AutoSize = true
                };
                newCheckBox.CheckedChanged += new EventHandler(CheckBoxOnChecked);
                newCheckBox.Font = new Font("Segoi UI", 8, FontStyle.Regular);

                panel1.Controls.Add(newCheckBox);
                top += Convert.ToInt16(newCheckBox.Height + 10);
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

        // Выход
        private void button3_Click(object sender, EventArgs e) { Close(); }
        private void Form6_FormClosing(object sender, FormClosingEventArgs e) => exit();
        public void exit()
        {
            form2.Show();
            using (SqlConnection connection = new SqlConnection(link))
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        // Запросы
        private void button1_Click(object sender, EventArgs e)
        {
            if (DBHelper.isFormat(tbSurname.Text.Trim()) &&
                DBHelper.isFormat(tbName.Text.Trim()))
            {
                string query = "SELECT * FROM [Sold Subscriptions] WHERE Surname LIKE N'%" + tbSurname.Text.Trim() + "%'";
                query += tbName.Text.Trim().Length > 0 ? string.Format(" AND Name Like N'%{0}%'", tbName.Text.Trim()) : "";
                LoadData(query);
            }
            else
                MessageBox.Show(DBHelper.getIsFormatError(), DBHelper.getCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbSubNumber.Text.Trim(), out int subscriptionNumber))
            {
                string query = string.Format("SELECT * FROM [Sold Subscriptions] Where [Subscription number] = {0}", tbSubNumber.Text.Trim());
                LoadData(query);
            }
            else if (tbSubNumber.Text.Trim() == "")
            {
                LoadData("SELECT * FROM [Sold Subscriptions]");
            }
            else
            {
                MessageBox.Show(DBHelper.getIsDigitError("Номер должен"), DBHelper.getCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e) => LoadData(createQueary());
        private void button6_Click(object sender, EventArgs e)
        {
            LoadData();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
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
        }

        public string createQueary()
        {
            string sql = "SELECT * FROM [Sold Subscriptions] WHERE 1=1 ";
            bool hasQuery = false; // Есть ли хоть один фильтр?
            if (cbSubTypes.Checked && Data.SubTypes.Count > 1)
            {
                string types = "";
                for (int i = 0; i < Data.SubTypes.Count; i++)
                {
                    types += i + 1 == Data.SubTypes.Count ? string.Format("N'{0}'", Data.SubTypes[i]) : string.Format("N'{0}', ", Data.SubTypes[i]);
                }
                sql += string.Format("AND [Subscription Type] IN ({0}) ", types);
                hasQuery = true;
            }
            if (cbAdd.Checked)
            {
                if (checkBox1.Checked)
                {
                    sql += "AND ([With Trainer] = 'true') ";
                    hasQuery = true;
                }
                if (checkBox2.Checked)
                {
                    sql += "AND ([With Trainer] = 'false') ";
                    hasQuery = true;
                }
                if (checkBox3.Checked)
                {
                    sql += "AND (Visit != '') ";
                    hasQuery = true;
                }
                if (checkBox4.Checked)
                {
                    sql += "AND (Visit = '') ";
                    hasQuery = true;
                }
                if (checkBox5.Checked)
                {
                    sql += "AND ([With Discount] != '') ";
                    hasQuery = true;
                }
                if (checkBox6.Checked)
                {
                    sql += "AND ([With Discount] = '') ";
                    hasQuery = true;
                }
            }
            if (cbStartDate1.Checked)
            {
                sql += string.Format("AND [Start date] = '{0}' ", dtp1.Value.ToString("yyyy-MM-dd"));
                hasQuery = true;
            }
            if (cbStartDate2.Checked)
            {
                sql += string.Format("AND ([Start date] >= '{0}' AND [Start date] <= '{1}') ", dtp2.Value.ToString("yyyy-MM-dd"), dtp3.Value.ToString("yyyy-MM-dd"));
                hasQuery = true;
            }
            if (cbPayDate1.Checked)
            {
                sql += string.Format("AND [Payment date] = '{0}' ", dtp4.Value.ToString("yyyy-MM-dd"));
                hasQuery = true;
            }
            if (cbPayDate2.Checked)
            {
                sql += string.Format("AND ([Payment date] >= '{0}' AND [Payment date] <= '{1}') ", dtp5.Value.ToString("yyyy-MM-dd"), dtp6.Value.ToString("yyyy-MM-dd"));
                hasQuery = true;
            }
            if (cbActive.Checked)
            {
                sql += string.Format("AND ([Start date] <= '{0}' AND [End date] >= '{0}') ", DateTime.Today.ToString("yyyy-MM-dd"));
                hasQuery = true;
            }
            return hasQuery ? sql : "SELECT * FROM [Sold Subscriptions]";
        }

        // Закругленные углы bg
        private void bgM1_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM1, 20, e);
        private void bgM2_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM2, 20, e);
        private void bgM3_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM3, 20, e);
        private void bgM4_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM4, 20, e);
        private void bgM5_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM5, 20, e);

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => checkBox2.Checked = false;
        private void checkBox2_CheckedChanged(object sender, EventArgs e) => checkBox1.Checked = false;
        private void checkBox3_CheckedChanged(object sender, EventArgs e) => checkBox4.Checked = checkBox3.Checked ? false : true;
        private void checkBox4_CheckedChanged(object sender, EventArgs e) => checkBox3.Checked = checkBox4.Checked ? false : true;
        private void checkBox5_CheckedChanged(object sender, EventArgs e) => checkBox6.Checked = checkBox5.Checked ? false : true;
        private void checkBox6_CheckedChanged(object sender, EventArgs e) => checkBox5.Checked = checkBox6.Checked ? false : true;

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application ex = new Excel.Application();

            ex.SheetsInNewWorkbook = 1;
            Excel.Workbook workbook = ex.Workbooks.Add(Type.Missing);
            ex.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);

            for (int i = 0; i < dgw.ColumnCount; i++)
            {
                sheet.Cells[1, i + 1] = dgw.Columns[i].HeaderText;
            }

            for (int i = 0; i < dgw.RowCount; i++)
            {
                for (int j = 0; j < dgw.ColumnCount; j++)
                {
                    sheet.Cells[i + 2, j + 1] = dgw.Rows[i].Cells[j].Value.ToString();
                }
            }

            ex.Visible = true;
            DBHelper.ReleaseExcel(ex);
        }

        private void tbSurnane_TextChanged(object sender, EventArgs e)
        {
            if (!DBHelper.isString(tbSurname.Text.Trim()))
                lbError1.Text = DBHelper.getSurnameError();
            else
                lbError1.Text = "";
        }
        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (!DBHelper.isString(tbName.Text.Trim()))
                lbError1.Text = DBHelper.getNameError();
            else
                lbError1.Text = "";
        }
        private void tbSubNumber_TextChanged(object sender, EventArgs e)
        {
            if (tbSubNumber.Text.Trim() == "")
            {
                lbError1.Text = "";
                return;
            }
            if (!int.TryParse(tbSubNumber.Text.Trim(), out int number))
                lbError1.Text = DBHelper.getIsDigitError("Номер должен");
            else
                lbError1.Text = "";
        }
    }
}
