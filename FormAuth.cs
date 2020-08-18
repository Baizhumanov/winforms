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
    public partial class FormAuth : Form
    {
        string link = DBHelper.connectionString;
        Form form1 = Application.OpenForms[0];
        public FormAuth()
        {
            InitializeComponent();
        }
    
        // Закругленные углы bg
        private void bgMain_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgMain, 20, e);

        // Проверка вводимости
        private void tbLogin_TextChanged(object sender, EventArgs e) => lbError.Text = DBHelper.isFormat(tbLogin.Text.Trim()) ? "" : "Нельзя вводить одинарные кавычки, точку с запятой, -- и слэш";
        private void tbPassword_TextChanged(object sender, EventArgs e) => lbError.Text = DBHelper.isFormat(tbPassword.Text.Trim()) ? "" : "Нельзя вводить одинарные кавычки, точку с запятой, -- и слэш";

        // Закрытие
        private void FormAuth_FormClosing(object sender, FormClosingEventArgs e) => form1.Show();
        private void button2_Click(object sender, EventArgs e) => Close();

        // Самый главный метод
        private async void btnAuth_Click(object sender, EventArgs e)
        {
            string login = tbLogin.Text.Trim();
            string passsword = tbPassword.Text.Trim();

            if (login.Length == 0 || passsword.Length == 0)
            {
                lbError.Text = "Введите данные";
                return;
            }
            btnAuth.Enabled = false;
            if (DBHelper.isFormat(login) && DBHelper.isFormat(passsword))
            {
                using (SqlConnection connection = new SqlConnection(link))
                {
                    SqlDataReader sqlReader = null;
                    try
                    {
                        await connection.OpenAsync();
                        SqlCommand command = new SqlCommand(string.Format("SELECT Login, Password, Type FROM Users WHERE Login = '{0}'", login), connection);

                        using (sqlReader = await command.ExecuteReaderAsync())
                        {
                            if (sqlReader.HasRows)
                            {
                                tbLogin.Text = "";
                                tbPassword.Text = "";
                                lbError.Text = "";
                                while (await sqlReader.ReadAsync())
                                {
                                    if (sqlReader.GetValue(1).ToString() == passsword)
                                    {
                                        Data.Type = sqlReader.GetValue(2).ToString();
                                        Data.Login = sqlReader.GetValue(0).ToString();
                                        Form form2 = new Form2();
                                        form2.Show();
                                        Hide();
                                    }
                                    else
                                        lbError.Text = "Неверный логин или пароль";
                                }
                            }
                            else
                                lbError.Text = "Неверный логин или пароль";
                        }

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
                lbError.Text = "Нельзя вводить одинарные кавычки, точку с запятой, -- и слэш";

            btnAuth.Enabled = true;
        }
    }
}
