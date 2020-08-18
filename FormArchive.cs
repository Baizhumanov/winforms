using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flex00
{
    public partial class FormArchive : Form
    {
        string link = DBHelper.connectionString;
        Form form2 = Application.OpenForms[2];

        public FormArchive()
        {
            InitializeComponent();
            LoadData("SELECT * FROM [AR Clients]");
            Data.Archive = "[AR Clients]";
        }

        public async void LoadData(string sql)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(link))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Load(reader);
                    dgw.DataSource = dt;
                    reader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
            switch (sql)
            {
                case "SELECT * FROM [AR Clients]":
                    dgw.Columns[9].Visible = false;
                    dgw.Columns[0].Width = 50;
                    dgw.Columns[1].Width = 70;
                    dgw.Columns[2].Width = 90;
                    dgw.Columns[3].Width = 80;
                    dgw.Columns[4].Width = 80;
                    dgw.Columns[5].Width = 80;
                    dgw.Columns[6].Width = 100;
                    dgw.Columns[7].Width = 100;
                    dgw.Columns[8].Width = 100;
                    dgw.Columns[0].HeaderText = "ID";
                    dgw.Columns[1].HeaderText = "Старый ID";
                    dgw.Columns[2].HeaderText = "Фамилия";
                    dgw.Columns[3].HeaderText = "Имя";
                    dgw.Columns[4].HeaderText = "Отчество";
                    dgw.Columns[5].HeaderText = "Телефон";
                    dgw.Columns[6].HeaderText = "Дополнительное";
                    dgw.Columns[7].HeaderText = "Дата добавления";
                    dgw.Columns[8].HeaderText = "Дата изменения";
                    break;
                case "SELECT * FROM [AR Products]":
                    dgw.Columns[0].Width = 50;
                    dgw.Columns[1].Width = 70;
                    dgw.Columns[2].Width = 90;
                    dgw.Columns[3].Width = 80;
                    dgw.Columns[4].Width = 80;
                    dgw.Columns[0].HeaderText = "ID";
                    dgw.Columns[1].HeaderText = "Старый ID";
                    dgw.Columns[2].HeaderText = "Название";
                    dgw.Columns[3].HeaderText = "Кол-во";
                    dgw.Columns[4].HeaderText = "Цена";
                    break;
                case "SELECT * FROM [AR Sells]":
                    dgw.Columns[0].Width = 50;
                    dgw.Columns[1].Width = 70;
                    dgw.Columns[2].Width = 90;
                    dgw.Columns[3].Width = 80;
                    dgw.Columns[4].Width = 80;
                    dgw.Columns[5].Width = 100;
                    dgw.Columns[6].Width = 80;
                    dgw.Columns[7].Width = 90;
                    dgw.Columns[0].HeaderText = "ID";
                    dgw.Columns[1].HeaderText = "Старый ID";
                    dgw.Columns[2].HeaderText = "Название";
                    dgw.Columns[3].HeaderText = "Кол-во";
                    dgw.Columns[4].HeaderText = "Цена";
                    dgw.Columns[5].HeaderText = "Дата покупки";
                    dgw.Columns[6].HeaderText = "Сумма";
                    dgw.Columns[7].HeaderText = "Тип оплаты";
                    break;
                case "SELECT * FROM [AR Sold Subs]":
                    dgw.Columns[0].Width = 50;
                    dgw.Columns[1].Width = 70;
                    dgw.Columns[2].Width = 70;
                    dgw.Columns[3].Width = 90;
                    dgw.Columns[4].Width = 80;
                    dgw.Columns[5].Width = 70;
                    dgw.Columns[6].Width = 120;
                    dgw.Columns[7].Width = 100;
                    dgw.Columns[8].Width = 100;
                    dgw.Columns[9].Width = 70;
                    dgw.Columns[10].Width = 90;
                    dgw.Columns[11].Width = 90;
                    dgw.Columns[12].Width = 80;
                    dgw.Columns[13].Width = 90;
                    dgw.Columns[14].Width = 70;
                    dgw.Columns[15].Width = 120;

                    dgw.Columns[0].HeaderText = "ID";
                    dgw.Columns[1].HeaderText = "Старый ID";
                    dgw.Columns[2].HeaderText = "Id клиента";
                    dgw.Columns[3].HeaderText = "Фамилия";
                    dgw.Columns[4].HeaderText = "Имя";
                    dgw.Columns[5].HeaderText = "Номер абонемента";
                    dgw.Columns[6].HeaderText = "Тип абонемента";
                    dgw.Columns[7].HeaderText = "Дата начала";
                    dgw.Columns[8].HeaderText = "Дата окончания";
                    dgw.Columns[9].HeaderText = "Осталось";
                    dgw.Columns[10].HeaderText = "Дата оплаты";
                    dgw.Columns[11].HeaderText = "С тренером?";
                    dgw.Columns[12].HeaderText = "Скидка";
                    dgw.Columns[13].HeaderText = "Тип оплаты";
                    dgw.Columns[14].HeaderText = "Сумма";
                    dgw.Columns[15].HeaderText = "Дополнительное";
                    break;
            }
        }

        // Запросы 
        private void btnClients_Click(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM [AR Clients]");
            paintButton();
            btnClients.BackColor = Color.FromArgb(82, 110, 250);
            btnClients.ForeColor = Color.White;
            Data.Archive = "[AR Clients]";
        }
        private void btnProducts_Click(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM [AR Products]");
            paintButton();
            btnProducts.BackColor = Color.FromArgb(82, 110, 250);
            btnProducts.ForeColor = Color.White;
            Data.Archive = "[AR Products]";
        }
        private void btnSells_Click(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM [AR Sells]");
            paintButton();
            btnSells.BackColor = Color.FromArgb(82, 110, 250);
            btnSells.ForeColor = Color.White;
            Data.Archive = "[AR Sells]";
        }
        private void btnSold_Click(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM [AR Sold Subs]");
            paintButton();
            btnSold.BackColor = Color.FromArgb(82, 110, 250);
            btnSold.ForeColor = Color.White;
            Data.Archive = "[AR Sold Subs]";
        }
        public void paintButton()
        {
            btnClients.BackColor = Color.FromArgb(228, 239, 255);
            btnProducts.BackColor = Color.FromArgb(228, 239, 255);
            btnSells.BackColor = Color.FromArgb(228, 239, 255);
            btnSold.BackColor = Color.FromArgb(228, 239, 255);

            btnClients.ForeColor = Color.FromArgb(41, 60, 74);
            btnProducts.ForeColor = Color.FromArgb(41, 60, 74);
            btnSells.ForeColor = Color.FromArgb(41, 60, 74);
            btnSold.ForeColor = Color.FromArgb(41, 60, 74);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            form2.Show();
            Close();
        }
        private void FormArchive_FormClosing(object sender, FormClosingEventArgs e) => form2.Show();

        private async void btnReturn_Click(object sender, EventArgs e)
        {
            string id = dgw.CurrentRow.Cells[0].Value.ToString();
            string oldId = dgw.CurrentRow.Cells[1].Value.ToString();

            var task = Task.Factory.StartNew(() => { }); // для event без await
            var needTask = Task.Factory.StartNew(() => { }); // нужен await

            string text = "";
            string sql = "";

            switch (Data.Archive)
            {
                case "[AR Sold Subs]":
                    needTask = DBHelper.UnZipSoldSub(id);
                    text = string.Format("Абонемент {0} вынесен из архива", id); // перепроверить текст
                    sql = "SELECT * FROM " + Data.Archive;
                    break;
                case "[AR Clients]":
                    needTask = DBHelper.UnZipClient(id, oldId);
                    text = string.Format("Клиент {0} вынесен из архива", id); // перепроверить текст
                    sql = "SELECT * FROM " + Data.Archive;
                    break;
                case "[AR Products]":
                    needTask = DBHelper.UnZipProduct(id);
                    text = string.Format("Продукт {0} вынесен из архива", id); // перепроверить текст
                    sql = "SELECT * FROM " + Data.Archive;
                    break;
                case "[AR Sells]":
                    needTask = DBHelper.UnZipSell(id);
                    text = string.Format("Транзакция {0} вынесена из архива", id); // перепроверить текст
                    sql = "SELECT * FROM " + Data.Archive;
                    break;
            }
            task = DBHelper.InsertEvent(text, "unzip", DateTime.Now.ToString("s"), Data.Login);
            await needTask;
            LoadData(sql);
        }

        // Закругленные углы bg
        private void bgData_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgData, 20, e);
        private void bgControl_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgControl, 20, e);
    }
}
