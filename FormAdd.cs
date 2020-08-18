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
using System.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace Flex00
{
    public partial class FormAdd : Form
    {
        // выбранный bgcolor     Color.FromArgb(82, 110, 250)
        // не выбранный bgcolor  Color.FromArgb(228, 239, 255)
        // выбранный color       Color.FromArgb(255, 255, 255)
        // не выбранный color    Color.FromArgb(41, 60, 74)
        private string link = DBHelper.connectionString;
        Form form2 = Application.OpenForms[2];

        public FormAdd()
        {
            InitializeComponent();
            Data.Price = ""; // сбиваю, чтобы при каждом открытии цена не суммировалась
            if (Data.Action == "update")
            {
                tbSurname.Text = Data.Surname;
                tbName.Text = Data.Name;
                cbOldClient.Checked = true;
                cbNewClient.Enabled = false;
                cbOldClient.Enabled = false;
                dgw.Enabled = false;
                btnAddUser.Enabled = false;
                tbSubNumber.Text = Data.SubscriptionNumber;
                dtStart.Value = Convert.ToDateTime(Data.StartDate);
                dtBuy.Value = Convert.ToDateTime(Data.PaymentDate);
                cbTrainer.Checked = Data.WithTrainer == "Да" ? true : false;
                cbLimit.Checked = Data.Limit == "" ? false : true;
                cbDisc.Checked = Data.Discount == "" ? false : true;
                tbSum.Text = Data.Amount;
                tbAdditional.Text = Data.Additional;
                tbPercent.Text = cbDisc.Checked ? Data.Discount.TrimEnd('%') : "";
                tbCount.Text = cbLimit.Checked ? Data.Limit : "";
                if (Data.TypePayment != "Наличные") toggleCash();
                Data.Action = ""; // Сбиваем чтобы норм форма выходила
            } else Data.SubscriptionType = ""; // сбиваю, чтобы при каждом открытии не выбиралось
            
            LoadData();
            showService();
            showDiscounts();
            changeDate(Convert.ToByte(Data.Month));
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            
        }

        public async void LoadData(string query = "SELECT Id, Surname, Name FROM Clients")
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
                            reader[0], // Id
                            reader[1], // Surname
                            reader[2]  // Name
                            );
                    }
                    reader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // Text Changed functions
        private void tbSurname_TextChanged(object sender, EventArgs e)
        {
            if (cbNewClient.Checked) filter(tbSurname.Text.Trim(), 1);
            lbError1.Text = !isString(tbSurname.Text.Trim()) ? DBHelper.getSurnameError() : "";
        }
        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (cbNewClient.Checked) filter(tbName.Text.Trim(), 2);
            lbError1.Text = !isString(tbName.Text.Trim()) ? DBHelper.getNameError() : "";
        }
        private void tbSubNumber_TextChanged(object sender, EventArgs e)
        {
            if (tbSubNumber.Text.Trim() == "")
            {
                lbError.Text = "";
                return;
            }
            lbError.Text = !int.TryParse(tbSubNumber.Text.Trim(), out int number) ? DBHelper.getIsDigitError("Номер должен") : "";
        }
        private void tbSum_TextChanged(object sender, EventArgs e)
        {
            if (tbSum.Text.Trim() == "")
            {
                lbError.Text = "";
                return;
            }
            lbError.Text = !int.TryParse(tbSum.Text.Trim(), out int sum) ? DBHelper.getIsDigitError("Сумма должна") : "";
        }

        // Все функции
        public void filter(string filter, int colIndex)
        {
            if (filter == "")
            {
                for (int i = 0; i < dgw.Rows.Count; i++)
                {
                    dgw.Rows[i].Visible = true;
                }
                return;
            }
            for (int i = 0; i < dgw.Rows.Count; i++)
            {
                dgw.Rows[i].Visible = dgw[colIndex, i].Value.ToString().Trim().IndexOf(filter) != -1; // 2 != -1 => true
            }
        }
        public void fullFilter(string surname, string name)
        {
            for (int i = 0; i < dgw.Rows.Count; i++)
            {
                dgw.Rows[i].Visible = dgw[1, i].Value.ToString().Trim() != surname;
                dgw.Rows[i].Visible = dgw[2, i].Value.ToString().Trim() != name;
            }
        }
        public bool isFormat(string s)
        {
            if (s.IndexOf("'") == -1 &&
                s.IndexOf("\"") == -1 &&
                s.IndexOf(";") == -1 &&
                s.IndexOf("--") == -1)
                return true;
            else
                return false;
        }
        public bool isString(string s)
        {
            string newString = s;
            if (s.Contains('-')) newString = s.Replace("-", "");
            return newString.ToCharArray().All(char.IsLetter) ? true : false;
        }
        public void changeDate(byte k = 1)
        {
            DateTime firstDate = dtStart.Value;
            DateTime secondDate = firstDate.AddMonths(k).AddDays(-1);
            dtStart.Value = firstDate;
            dtEnd.Value = secondDate;
        }
        public int getVisibleRows()
        {
            int k = 0;
            for (int i = 0; i < dgw.Rows.Count; i++)
            {
                if (dgw.Rows[i].Visible) i++;
            }
            return k;
        }
        public string getEventMore(string surname, string name, SoldSub soldsub)
        {
            string eventMore = "Изменен абонемент пользователя " + surname + " " + name + " [";
            if (Data.SubscriptionNumber != soldsub.SubscriptionNumber.ToString())
                eventMore += "номер абонемента с `" + Data.SubscriptionNumber + "` на `" + soldsub.SubscriptionNumber.ToString() + "`, ";
            if (Data.SubscriptionType != soldsub.SubscriptionType)
                eventMore += "тип абонемента с `" + Data.SubscriptionType + "` на `" + soldsub.SubscriptionType + "`, ";
            if (Data.StartDate != soldsub.StartDate)
                eventMore += "дата началы с `" + Data.StartDate + "` на `" + soldsub.StartDate + "`, ";
            if (Data.EndDate != soldsub.EndDate)
                eventMore += "дата окончания с `" + Data.EndDate + "` на `" + soldsub.EndDate + "`, ";
            if (Data.Limit != soldsub.Visit)
                eventMore += "кол-во визитов с `" + Data.Limit + "` на `" + soldsub.Visit + "`, ";
            if (Data.PaymentDate != soldsub.PaymentDate)
                eventMore += "дата оплаты с `" + Data.PaymentDate + "` на `" + soldsub.PaymentDate + "`, ";
            string withTrainerString = soldsub.WithTrainer ? "Да" : "Нет";
            if (Data.WithTrainer != withTrainerString)
                eventMore += withTrainerString != "Да" ? "с `с тренером` на `без тренера`, " : "с `без тренером` на `с тренера`, ";
            if (Data.Discount != soldsub.Discount)
                eventMore += "скидка с `" + Data.Discount + "` на `" + soldsub.Discount + "`,";
            string withCashString = soldsub.TypePayment ? "Наличные" : "Не наличные";
            if (Data.TypePayment != withCashString)
                eventMore += withCashString == "Наличные" ? "с `Не наличные` на `Наличные`, " : "с `Наличные` на `Не наличные`, ";
            if (Data.Amount != soldsub.Amount)
                eventMore += "сумма с `" + Data.Amount + "` на `" + soldsub.Amount + "`, ";
            if (Data.Additional != soldsub.Additional)
                eventMore += "дополнительное с `" + Data.Additional + "` на `" + soldsub.Additional + "`, ";
            eventMore += "]";
            return eventMore;
        }

        // Переключатели клиентов
        private void cbNewClient_CheckedChanged(object sender, EventArgs e)
        {
            cbOldClient.Checked = cbNewClient.Checked ? false : true;
            if (cbNewClient.Checked)
            {
                tbSurname.Text = "";
                tbName.Text = "";
                tbSurname.Enabled = true;
                tbName.Enabled = true;
            }
        }
        private void cbOldClient_CheckedChanged(object sender, EventArgs e)
        {
            cbNewClient.Checked = cbOldClient.Checked ? false : true;
            if (cbOldClient.Checked)
            {
                tbSurname.Enabled = false;
                tbName.Enabled = false;
            }
        }

        // Все, что связано с выбором существующего клиента
        private void dgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => chooseUser();
        private void btnAddUser_Click(object sender, EventArgs e) => chooseUser();
        public void chooseUser()
        {
            cbOldClient.Checked = true;
            tbName.Text = dgw.CurrentRow.Cells["NameColumn"].Value.ToString();
            tbSurname.Text = dgw.CurrentRow.Cells["SurnameColumn"].Value.ToString();
            Data.IdOfClient = dgw.CurrentRow.Cells["IdColumn"].Value.ToString();
        }

        // Все, что связано с выводом кнопок
        public void showService()
        {
            short left = 10;
            short top = 10;
            for (short i = 0; i < Data.Service.Count; i++)
            {
                string name = Data.Service[i].Substring(1, Data.Service[i].IndexOf("]") - 1);
                string price = Data.Service[i].Substring(Data.Service[i].IndexOf("{") + 1, Data.Service[i].IndexOf("}") - Data.Service[i].IndexOf("{") - 1);
                string limit = Data.Service[i].Substring(Data.Service[i].Length - 2) == "no" ? "no" : "yes";
                string month = Data.Service[i].Substring(Data.Service[i].IndexOf("(") + 1, Data.Service[i].IndexOf(")") - Data.Service[i].IndexOf("(") - 1);
                Button newButton = new Button
                {
                    Name = "btn" + i.ToString() + "(" + month + ")" + limit,
                    Text = name + " [" + price + "]",
                    Left = left,
                    Top = top,
                    TabIndex = i + 5,
                    TabStop = true
                };
                newButton.Click += ButtonOnClick;
                // newButton.Enter += ButtonEnter;
                // newButton.Leave += ButtonLeave;
                newButton.Width = 220;
                newButton.Height = 50;
                newButton.FlatStyle = FlatStyle.Flat;
                newButton.FlatAppearance.BorderSize = 0;
                newButton.BackColor = name == Data.SubscriptionType ? Color.FromArgb(82, 110, 250) : Color.FromArgb(228, 239, 255);
                newButton.ForeColor = name == Data.SubscriptionType ? Color.FromArgb(255, 255, 255) : Color.FromArgb(41, 60, 74);
                Data.Month = name == Data.SubscriptionType ? month.ToString() : "1".ToString();
                // newButton.Font = new Font("Segoi UI", 10, FontStyle.Regular);

                bgSubType.Controls.Add(newButton);
                top += Convert.ToInt16(newButton.Height + 10);
            }
        }
        public void ButtonOnClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button != null)
            {
                byte startIndex = Convert.ToByte(button.Text.IndexOf("[") + 1);
                string price = button.Text.Substring(startIndex, button.Text.IndexOf("]") - startIndex);
                string name = button.Text.Substring(0, button.Text.IndexOf("[")).Trim();
                string month = button.Name.Substring(button.Name.IndexOf("(") + 1, button.Name.IndexOf(")") - button.Name.IndexOf("(") - 1);
                if (button.Name.Substring(button.Name.Length - 2) == "no")
                {
                    cbLimit.Checked = false;
                    tbCount.Text = "";
                }
                else
                {
                    cbLimit.Checked = true;
                    tbCount.Text = "12";
                }

                paintButton(bgSubType);
                button.BackColor = Color.FromArgb(82, 110, 250); // выбранный bgcolor
                button.ForeColor = Color.FromArgb(255, 255, 255); // выбранный color
                changeDate(Convert.ToByte(month));

                Data.SubscriptionType = name;
                Data.Month = month;
                Data.Price = price;

                decide();
            }
        }
        public void showDiscounts()
        {
            short left = 10;
            short top = 10;
            for (short i = 0; i < Data.Discounts.Count; i++)
            {
                string name = Data.Discounts[i].Substring(1, Data.Discounts[i].IndexOf("]") - 1);
                string value = Data.Discounts[i].Substring(Data.Discounts[i].IndexOf("{") + 1, Data.Discounts[i].IndexOf("}") - Data.Discounts[i].IndexOf("{") - 1);
                Button newButton = new Button
                {
                    Name = "btnDisc" + i.ToString(),
                    Text = name + " [" + value + "]",
                    Left = left,
                    Top = top,
                    TabIndex = i + 5,
                    TabStop = true
                };
                newButton.Click += DiscOnClick;
                // newButton.Enter += ButtonEnter;
                // newButton.Leave += ButtonLeave;
                newButton.Width = 160;
                newButton.Height = 40;
                newButton.FlatStyle = FlatStyle.Flat;
                newButton.FlatAppearance.BorderSize = 0;
                newButton.BackColor = Color.FromArgb(228, 239, 255);
                newButton.ForeColor = Color.FromArgb(41, 60, 74);
                // newButton.Font = new Font("Segoi UI", 10, FontStyle.Regular);

                bgDiscounts.Controls.Add(newButton);
                top += Convert.ToInt16(newButton.Height + 10);
            }
        }
        public void DiscOnClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button != null)
            {
                byte startIndex = Convert.ToByte(button.Text.IndexOf("[") + 1);
                string value = button.Text.Substring(startIndex, button.Text.IndexOf("]") - startIndex);
                string name = button.Text.Substring(0, button.Text.IndexOf("["));

                cbDisc.Checked = true;
                tbPercent.Text = value;

                if (button.BackColor == Color.FromArgb(82, 110, 250)) // если кнопка была активной
                {
                    paintButton(bgDiscounts);
                }
                else
                {
                    paintButton(bgDiscounts);
                    button.BackColor = Color.FromArgb(82, 110, 250); // выбранный bgcolor
                    button.ForeColor = Color.FromArgb(255, 255, 255); // выбранный color
                }
            }
        }
        public void paintButton(Panel bg)
        {
            foreach (Control control in bg.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    control.BackColor = Color.FromArgb(228, 239, 255); // не выбранный bgcolor
                    control.ForeColor = Color.FromArgb(41, 60, 74); // не выбранный color
                }
            }
        }

        // Самый главный метод
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (isFormat(tbSurname.Text.Trim()) &&
                isFormat(tbName.Text.Trim()) &&
                isFormat(tbSubNumber.Text.Trim()) &&
                isFormat(tbCount.Text.Trim()) &&
                isFormat(tbAdditional.Text.Trim()) &&
                isFormat(tbPercent.Text.Trim()) &&
                isFormat(tbSum.Text.Trim()))
            {
                string errorMessage = "";

                string surname = tbSurname.Text.Trim();
                string name = tbName.Text.Trim();
                string number = tbSubNumber.Text.Trim();
                string sum = tbSum.Text.Trim();
                string additional = tbAdditional.Text.Trim();
                string limit = tbCount.Text.Trim();
                string discount = cbDisc.Checked ? tbPercent.Text.Trim() : "";
                bool withTrainer = cbTrainer.Checked ? true : false;
                string withTrainerString = cbTrainer.Checked ? "Да" : "Нет";
                bool withCash = btnCash.BackColor == Color.FromArgb(82, 110, 250) ? true : false;  // нал : карта
                string withCashString = btnCash.BackColor == Color.FromArgb(82, 110, 250) ? "Наличные" : "Не наличные";

                // -------------------------- Start Check -------------------------------

                bool flag1 = true;
                bool flag2 = true;
                bool flag3 = true;
                bool flag4 = true;
                bool flag5 = true;
                bool flag6 = true;
                bool flag7 = true;
                bool flag8 = true;
                bool flag9 = true;

                if (surname.Length < 2 || name.Length < 2) { errorMessage += "Фамилия и имя должны быть больше 1 символа\n"; flag1 = false; }
                if (!isString(surname) || !isString(name)) { errorMessage += "Фамилия и имя должны состоять только из букв\n"; flag2 = false; }
                if (number.Length > 6) { errorMessage += "Номер абонемента не должен привышать 6 символов\n"; flag3 = false; }
                if (!int.TryParse(number, out int numberInt)) { errorMessage += "Номер абонемента должен состоять только из цифр\n"; flag4 = false; }
                if (!int.TryParse(sum, out int sumInt)) { errorMessage += "Сумма должна состоять только из цифр\n"; flag5 = false; }

                if (cbLimit.Checked)
                {
                    if (byte.TryParse(limit, out byte limitByte))
                        limit = limitByte.ToString();
                    else { errorMessage += "Визит должен состоять только из цифр\n"; flag6 = false; }
                }
                else limit = "";

                if (cbDisc.Checked)
                {
                    if (!short.TryParse(discount, out short discountShort)) { errorMessage += "Скидка должна состоять только из цифр\n"; flag7 = false; }
                    else
                        discount += "%";
                }

                if (btnAdd.Text == "Изменить")
                {
                    if (Data.SubscriptionNumber == number)
                        flag8 = true; // не понял зачем это надо
                }
                else if (Data.SubNumbers.Contains(number)) { errorMessage += "Такой номер абонемента уже есть\n"; flag8 = false; }

                if (dtStart.Value > dtEnd.Value) { errorMessage += "Дата окончания не может быть меньше дата начала\n"; flag9 = false; }
                // -------------------------- End Check -------------------------------


                // ---------------- Проверка на одного и того же клиента --------------
                fullFilter(surname, name);
                if (getVisibleRows() > 0)
                {
                    DialogResult result = MessageBox.Show(
                                    "В базе данных уже есть клиент с таким именем и фамилией. Вы уверены что хотите добавить нового?",
                                    "В базе уже есть такой клиент",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Stop,
                                    MessageBoxDefaultButton.Button2,
                                    MessageBoxOptions.DefaultDesktopOnly);
                    if (result != DialogResult.Yes) { return; }
                }


                //  --------------------- Добавление и изменение ----------------------
                if (flag1 && flag2 && flag3 && flag4 && flag5 && flag6 && flag7 && flag8 && flag9)
                {
                    var task = Task.Factory.StartNew(() => { }); // то, что добавляет в Events - не нужен await
                    var needTask = Task.Factory.StartNew(() => { }); // то, что добавляет в SS или CL - нужен await
                    Data.SqlEventDate = DateTime.Now.ToString("s");
                    Data.DoIt = true;
                    SoldSub soldSub = new SoldSub
                    {
                        SubscriptionNumber = numberInt,
                        SubscriptionType = Data.SubscriptionType,
                        StartDate = dtStart.Value.ToString("yyyy-MM-dd"),
                        EndDate = dtEnd.Value.ToString("yyyy-MM-dd"),
                        Visit = limit,
                        PaymentDate = dtBuy.Value.ToString("yyyy-MM-dd"),
                        WithTrainer = withTrainer,
                        Discount = discount,
                        TypePayment = withCash,
                        Amount = sum,
                        Additional = additional
                    };

                    if (btnAdd.Text == "Добавить")
                    {
                        Client client = new Client
                        {
                            Surname = surname,
                            Name = name,
                            DateAdd = DateTime.Today.ToString("yyyy-MM-dd"),
                            DateUpdate = DateTime.Today.ToString("yyyy-MM-dd")
                        };

                        if (cbNewClient.Checked)
                        {
                            needTask = DBHelper.InsertClientAndSoldSub(client, soldSub);

                            Data.SqlEvent = "Добавлен клиент " + surname + " " + name;
                            Data.SqlEventType = "insert";
                            task = DBHelper.InsertEvent(Data.SqlEvent, Data.SqlEventType, Data.SqlEventDate, Data.Login);
                        }
                        else
                        {
                            needTask = DBHelper.InsertSoldSub(soldSub, Data.IdOfClient, surname, name);
                        }

                        Data.SqlEvent = "Продан абонемент " + surname + " " + name;
                        Data.SqlEventType = "insert";
                        task = DBHelper.InsertEvent(Data.SqlEvent, Data.SqlEventType, Data.SqlEventDate, Data.Login);
                    }
                    if (btnAdd.Text == "Изменить")
                    {
                        needTask = DBHelper.UpdateSoldSub(soldSub, Data.Id);

                        Data.SqlEvent = getEventMore(surname, name, soldSub);
                        Data.SqlEventType = "update";
                        task = DBHelper.InsertEvent(Data.SqlEvent, Data.SqlEventType, Data.SqlEventDate, Data.Login);
                    }
                    await needTask;
                    form2.Show();
                    Close();
                }
                else
                    MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show(DBHelper.getIsFormatError(), DBHelper.getCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Методы с закрытием окна
        private void btnBack_Click(object sender, EventArgs e) => Close();
        private void FormAdd_FormClosing(object sender, FormClosingEventArgs e) => form2.Show();

        // Все, что связано с расчетом скидки
        private void cbDisc_CheckedChanged(object sender, EventArgs e)
        {
            tbPercent.Enabled = cbDisc.Checked ? true : false;
            decide();
        }
        public void decide()
        {
            if (Data.Price.Length > 0)
            {
                int.TryParse(Data.Price, out int price);
                if (cbDisc.Checked)
                {
                    if (tbPercent.Text.Trim() == "")
                    {
                        tbSum.Text = price.ToString();
                        return;
                    }
                    if (int.TryParse(tbPercent.Text.Trim(), out int percent))
                    {
                        int sum = price * (100 - percent) / 100;
                        tbSum.Text = sum.ToString();
                    }
                }
                else
                {
                    tbSum.Text = price.ToString();
                }
            }
        }
        private void tbPercent_TextChanged(object sender, EventArgs e)
        {
            if (tbPercent.Text.Trim() == "")
            {
                lbError.Text = "";
                return;
            }
            lbError.Text = !int.TryParse(tbPercent.Text.Trim(), out int percent)
                ? DBHelper.getIsDigitError("Процент скилки должен")
                : percent > 100 ? "Процент скидки должен быть до 100%" : "";
            decide();
        }
        private void btnDecide_Click(object sender, EventArgs e) => decide();

        // Закругленные углы bg
        private void bgM1_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM1, 20, e);
        private void bgM2_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM2, 20, e);
        private void bgM3_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM3, 20, e);
        private void bgM4_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM4, 20, e);
        private void bgM5_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgM5, 20, e);
        private void bgMainData_Paint(object sender, PaintEventArgs e) => DBHelper.SetRoundedShape(bgMainData, 20, e);

        // Дата
        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            changeDate(Convert.ToByte(Data.Month));
            lbError.Text = dtStart.Value.ToShortDateString() != DateTime.Today.ToShortDateString() ? "Не сегодняшний день, вы уверены?" : "";
        }

        // Переключатели наличных
        private void btnCard_Click(object sender, EventArgs e) => toggleCash();
        private void btnCash_Click(object sender, EventArgs e) => toggleCash();
        public void toggleCash()
        {
            btnCash.BackColor = btnCash.BackColor == Color.FromArgb(82, 110, 250) ? Color.FromArgb(228, 239, 255) : Color.FromArgb(82, 110, 250);
            btnCard.BackColor = btnCard.BackColor == Color.FromArgb(82, 110, 250) ? Color.FromArgb(228, 239, 255) : Color.FromArgb(82, 110, 250);
            btnCash.ForeColor = btnCash.ForeColor == Color.White ? Color.FromArgb(41, 60, 74) : Color.White;
            btnCard.ForeColor = btnCard.ForeColor == Color.White ? Color.FromArgb(41, 60, 74) : Color.White;
        }

        private void btnReset_Click(object sender, EventArgs e) => cbNewClient.Checked = true;
    }
}
