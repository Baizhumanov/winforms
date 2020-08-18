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
    public partial class Form5 : Form
    {
        Form form2 = Application.OpenForms[2];
        string link = DBHelper.connectionString;

        //
        public Form5()
        {
            InitializeComponent();
            LoadData();
        }
        private void Form5_Load(object sender, EventArgs e) => button2.Enabled = Data.Type == "user" ? false : true;

        // 
        public async void LoadData(string query = "SELECT * FROM Events ORDER BY Time DESC")
        {
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
                        dgw.Rows.Add(
                            reader[0],
                            reader[1],
                            reader[2],
                            reader[3],
                            reader[4]
                            );
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            label3.Text ="Всего записей:";
            label3.Text += Convert.ToString(dgw.RowCount);
        }

        // Выход из страницы
        private void button1_Click(object sender, EventArgs e) { Close(); }
        private void Form5_FormClosing(object sender, FormClosingEventArgs e) => exit();
        public void exit()
        {
            form2.Show();
            using (SqlConnection connection = new SqlConnection(link))
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        // Удаление
        private void button2_Click(object sender, EventArgs e)
        {
            string id = dgw.CurrentRow.Cells["Id"].Value.ToString();
            string text = "Вы действительно хотите удалить событие с Id = " + id + "?";
            string caption = "Удаление записи";

            DialogResult result = MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                delete(id);
            }
        }
        public async void delete(string id)
        {
            string sql = string.Format("DELETE FROM Events WHERE Id = {0}", id);
            var task = DBHelper.ExecuteCommand(sql);
            await task;
            LoadData();
        }

        // Сброс
        private void button7_Click(object sender, EventArgs e)
        {
            LoadData();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false; 
            checkBox4.Checked = false;
            button3.BackColor = Color.FromArgb(255, 210, 133);
            button4.BackColor = Color.FromArgb(255, 238, 210);
            tabControl1.Enabled = false;
        }

        // Показ данных
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgw.CurrentRow != null &&
                dgw.CurrentRow.Cells[2].Value != null)
            {
                label4.Text = dgw.CurrentRow.Cells["Event"].Value.ToString();
            }            
        }

        // Переключатели дат
        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(255, 210, 133);
            button4.BackColor = Color.FromArgb(255, 238, 210);
            tabControl1.Enabled = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(255, 210, 133);
            button3.BackColor = Color.FromArgb(255, 238, 210);
            tabControl1.Enabled = true;
        }

        // Кнопка запроса
        private void button8_Click(object sender, EventArgs e)
        {
            string types = "";
            string sql = "SELECT * FROM Events WHERE 1=1 ";

            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked || checkBox5.Checked)
            {
                if (checkBox1.Checked)
                    types += types.Length > 0 ? ", 'insert'" : "'insert'";
                if (checkBox2.Checked)
                    types += types.Length > 0 ? ", 'update'" : "'update'";
                if (checkBox3.Checked)
                    types += types.Length > 0 ? ", 'delete'" : "'delete'";
                if (checkBox4.Checked)
                    types += types.Length > 0 ? ", 'come'" : "'come'";
                if (checkBox5.Checked)
                    types += types.Length > 0 ? ", 'sell'" : "'sell'";
                sql += string.Format("AND Type IN ({0}) ", types);
            }

            if (button4.BackColor == Color.FromArgb(255, 210, 133))
            {
                sql += "AND ";
                if (tabControl1.SelectedIndex == 0)
                {
                    sql += "Time > '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "T00:00:00' AND Time < '" + dateTimePicker1.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "T00:00:00' ";
                }
                if (tabControl1.SelectedIndex == 1)
                    sql += "Time > '" + dateTimePicker2.Value.ToString("s") + "' AND Time < '" + dateTimePicker3.Value.ToString("s") + "' ";
            }
            sql += "ORDER BY Time DESC";
            LoadData(sql);
        }

        // Сегодня / Вчера
        private void button5_Click(object sender, EventArgs e) => dateTimePicker1.Value = DateTime.Today;
        private void button6_Click(object sender, EventArgs e) => dateTimePicker1.Value = DateTime.Today.AddDays(-1);

        // Закругленные углы bg
        private void bgM1_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM1, 20, e);
        private void bgM2_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM2, 20, e);
        private void bgM3_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM3, 20, e);
        private void bgM4_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM4, 20, e);

        // Excel
        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application ex = new Excel.Application();
            
            ex.SheetsInNewWorkbook = 2;
            Excel.Workbook workbook = ex.Workbooks.Add(Type.Missing);
            ex.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);

            for (int i = 0; i < dgw.ColumnCount; i++)
            {
                if (i != 2)
                {
                    sheet.Cells[1, i + 1] = dgw.Columns[i].HeaderText;
                }
                else continue;
            }

            for (int i = 0; i < dgw.RowCount; i++)
            {
                for (int j = 0; j < dgw.ColumnCount; j++)
                {
                    if (j != 2)
                    {
                        sheet.Cells[i + 2, j + 1] = dgw.Rows[i].Cells[j].Value.ToString();
                    }
                    else continue;
                }
            }

            ex.Visible = true;
            DBHelper.ReleaseExcel(ex);
        }
    }
}
