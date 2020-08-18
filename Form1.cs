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
    public partial class Form1 : Form
    {
        // string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security=True"; //C:\Users\asus\Desktop\Flex00\Flex00\

        string link = DBHelper.connectionString;
        bool isSuccess = false;
        bool isLoad = true;
        // 228; 239; 255 - выбранный bg

        public Form1()
        {
            InitializeComponent();
            connect();
        }

        private async void connect()
        {
            using (SqlConnection connection = new SqlConnection(link))
            {
                try
                {
                    await connection.OpenAsync();
                    showSuccess();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    showError();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(link))
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        // Закругленные углы bg
        private void bgHelp_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgHelp, 20, e);
        private void bgAuth_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgAuth, 20, e);

        // Все, что связано с анимацией
        public void showSuccess()
        {
            pbLoad.Image = Properties.Resources.success;
            isLoad = false;
            isSuccess = true;
        }
        public void showError()
        {
            pbLoad.Image = Properties.Resources.error;
            isLoad = false;
            isSuccess = false;
        }

        // открытие других форм
        private void btnAuth_Click(object sender, EventArgs e)
        {
            Form formAuth = new FormAuth();
            formAuth.Show();
            Hide();
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Form formHelp = new FormHelp();
            formHelp.Show();
            Hide();
        }
    }
}
