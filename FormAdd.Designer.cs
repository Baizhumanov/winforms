namespace Flex00
{
    partial class FormAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bgMain = new System.Windows.Forms.Panel();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurnameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.bgMainData = new System.Windows.Forms.Panel();
            this.lbError1 = new System.Windows.Forms.Label();
            this.cbOldClient = new System.Windows.Forms.CheckBox();
            this.cbNewClient = new System.Windows.Forms.CheckBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.lbSurname = new System.Windows.Forms.Label();
            this.lbTitle1 = new System.Windows.Forms.Label();
            this.lbTitle2 = new System.Windows.Forms.Label();
            this.bgM1 = new System.Windows.Forms.Panel();
            this.bgSubType = new System.Windows.Forms.Panel();
            this.lbSubType = new System.Windows.Forms.Label();
            this.tbSubNumber = new System.Windows.Forms.TextBox();
            this.lbSubNumber = new System.Windows.Forms.Label();
            this.bgM2 = new System.Windows.Forms.Panel();
            this.dtBuy = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lbBuy = new System.Windows.Forms.Label();
            this.lbEnd = new System.Windows.Forms.Label();
            this.lbStart = new System.Windows.Forms.Label();
            this.bgM3 = new System.Windows.Forms.Panel();
            this.tbAdditional = new System.Windows.Forms.TextBox();
            this.lbAdditional = new System.Windows.Forms.Label();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.lbCount = new System.Windows.Forms.Label();
            this.cbLimit = new System.Windows.Forms.CheckBox();
            this.cbTrainer = new System.Windows.Forms.CheckBox();
            this.bgM4 = new System.Windows.Forms.Panel();
            this.bgDiscounts = new System.Windows.Forms.Panel();
            this.lbPercent = new System.Windows.Forms.Label();
            this.tbPercent = new System.Windows.Forms.TextBox();
            this.cbDisc = new System.Windows.Forms.CheckBox();
            this.bgM5 = new System.Windows.Forms.Panel();
            this.tbSum = new System.Windows.Forms.TextBox();
            this.lbSum = new System.Windows.Forms.Label();
            this.btnCard = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbError = new System.Windows.Forms.Label();
            this.bgMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.bgMainData.SuspendLayout();
            this.bgM1.SuspendLayout();
            this.bgM2.SuspendLayout();
            this.bgM3.SuspendLayout();
            this.bgM4.SuspendLayout();
            this.bgM5.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgMain
            // 
            this.bgMain.BackColor = System.Drawing.Color.White;
            this.bgMain.Controls.Add(this.dgw);
            this.bgMain.Controls.Add(this.btnReset);
            this.bgMain.Controls.Add(this.btnBack);
            this.bgMain.Controls.Add(this.btnAddUser);
            this.bgMain.Controls.Add(this.bgMainData);
            this.bgMain.Controls.Add(this.lbTitle1);
            this.bgMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.bgMain.Location = new System.Drawing.Point(0, 0);
            this.bgMain.Margin = new System.Windows.Forms.Padding(0);
            this.bgMain.Name = "bgMain";
            this.bgMain.Size = new System.Drawing.Size(460, 641);
            this.bgMain.TabIndex = 0;
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.SurnameColumn,
            this.NameColumn});
            this.dgw.GridColor = System.Drawing.Color.White;
            this.dgw.Location = new System.Drawing.Point(30, 240);
            this.dgw.Name = "dgw";
            this.dgw.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgw.RowHeadersWidth = 25;
            this.dgw.RowTemplate.Height = 25;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(400, 243);
            this.dgw.TabIndex = 6;
            this.dgw.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellDoubleClick);
            // 
            // idColumn
            // 
            this.idColumn.HeaderText = "id";
            this.idColumn.Name = "idColumn";
            this.idColumn.Width = 50;
            // 
            // SurnameColumn
            // 
            this.SurnameColumn.HeaderText = "Фамилия";
            this.SurnameColumn.Name = "SurnameColumn";
            this.SurnameColumn.Width = 150;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Имя";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.Width = 150;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(280, 569);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 40);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnBack.FlatAppearance.BorderSize = 2;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnBack.Location = new System.Drawing.Point(30, 569);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 40);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(30, 489);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(400, 40);
            this.btnAddUser.TabIndex = 3;
            this.btnAddUser.Text = "Выбрать существующего клиента";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // bgMainData
            // 
            this.bgMainData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.bgMainData.Controls.Add(this.lbError1);
            this.bgMainData.Controls.Add(this.cbOldClient);
            this.bgMainData.Controls.Add(this.cbNewClient);
            this.bgMainData.Controls.Add(this.lbName);
            this.bgMainData.Controls.Add(this.tbName);
            this.bgMainData.Controls.Add(this.tbSurname);
            this.bgMainData.Controls.Add(this.lbSurname);
            this.bgMainData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bgMainData.Location = new System.Drawing.Point(30, 70);
            this.bgMainData.Name = "bgMainData";
            this.bgMainData.Size = new System.Drawing.Size(400, 160);
            this.bgMainData.TabIndex = 1;
            this.bgMainData.Paint += new System.Windows.Forms.PaintEventHandler(this.bgMainData_Paint);
            // 
            // lbError1
            // 
            this.lbError1.AutoSize = true;
            this.lbError1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbError1.ForeColor = System.Drawing.Color.Red;
            this.lbError1.Location = new System.Drawing.Point(21, 134);
            this.lbError1.Name = "lbError1";
            this.lbError1.Size = new System.Drawing.Size(0, 17);
            this.lbError1.TabIndex = 6;
            // 
            // cbOldClient
            // 
            this.cbOldClient.AutoSize = true;
            this.cbOldClient.Location = new System.Drawing.Point(200, 80);
            this.cbOldClient.Name = "cbOldClient";
            this.cbOldClient.Size = new System.Drawing.Size(195, 25);
            this.cbOldClient.TabIndex = 5;
            this.cbOldClient.Text = "Существующий клиент";
            this.cbOldClient.UseVisualStyleBackColor = true;
            this.cbOldClient.CheckedChanged += new System.EventHandler(this.cbOldClient_CheckedChanged);
            // 
            // cbNewClient
            // 
            this.cbNewClient.AutoSize = true;
            this.cbNewClient.Checked = true;
            this.cbNewClient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNewClient.Location = new System.Drawing.Point(200, 40);
            this.cbNewClient.Name = "cbNewClient";
            this.cbNewClient.Size = new System.Drawing.Size(130, 25);
            this.cbNewClient.TabIndex = 4;
            this.cbNewClient.Text = "Новый клиент";
            this.cbNewClient.UseVisualStyleBackColor = true;
            this.cbNewClient.CheckedChanged += new System.EventHandler(this.cbNewClient_CheckedChanged);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbName.Location = new System.Drawing.Point(20, 75);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(45, 20);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Имя*";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(24, 98);
            this.tbName.MaxLength = 25;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(110, 29);
            this.tbName.TabIndex = 2;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(24, 33);
            this.tbSurname.MaxLength = 30;
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(130, 29);
            this.tbSurname.TabIndex = 1;
            this.tbSurname.TextChanged += new System.EventHandler(this.tbSurname_TextChanged);
            // 
            // lbSurname
            // 
            this.lbSurname.AutoSize = true;
            this.lbSurname.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSurname.Location = new System.Drawing.Point(20, 10);
            this.lbSurname.Name = "lbSurname";
            this.lbSurname.Size = new System.Drawing.Size(79, 20);
            this.lbSurname.TabIndex = 0;
            this.lbSurname.Text = "Фамилия*";
            // 
            // lbTitle1
            // 
            this.lbTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTitle1.Location = new System.Drawing.Point(0, 0);
            this.lbTitle1.Name = "lbTitle1";
            this.lbTitle1.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.lbTitle1.Size = new System.Drawing.Size(460, 50);
            this.lbTitle1.TabIndex = 0;
            this.lbTitle1.Text = "Продажа абонемента";
            this.lbTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbTitle2
            // 
            this.lbTitle2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTitle2.Location = new System.Drawing.Point(460, 0);
            this.lbTitle2.Name = "lbTitle2";
            this.lbTitle2.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.lbTitle2.Size = new System.Drawing.Size(734, 50);
            this.lbTitle2.TabIndex = 1;
            this.lbTitle2.Text = "Данные абонемента";
            this.lbTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bgM1
            // 
            this.bgM1.BackColor = System.Drawing.Color.White;
            this.bgM1.Controls.Add(this.bgSubType);
            this.bgM1.Controls.Add(this.lbSubType);
            this.bgM1.Controls.Add(this.tbSubNumber);
            this.bgM1.Controls.Add(this.lbSubNumber);
            this.bgM1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bgM1.Location = new System.Drawing.Point(480, 70);
            this.bgM1.Margin = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.bgM1.Name = "bgM1";
            this.bgM1.Size = new System.Drawing.Size(280, 470);
            this.bgM1.TabIndex = 2;
            this.bgM1.Paint += new System.Windows.Forms.PaintEventHandler(this.bgM1_Paint);
            // 
            // bgSubType
            // 
            this.bgSubType.AutoScroll = true;
            this.bgSubType.Location = new System.Drawing.Point(15, 86);
            this.bgSubType.Margin = new System.Windows.Forms.Padding(15);
            this.bgSubType.Name = "bgSubType";
            this.bgSubType.Size = new System.Drawing.Size(250, 369);
            this.bgSubType.TabIndex = 3;
            // 
            // lbSubType
            // 
            this.lbSubType.AutoSize = true;
            this.lbSubType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSubType.Location = new System.Drawing.Point(20, 50);
            this.lbSubType.Name = "lbSubType";
            this.lbSubType.Size = new System.Drawing.Size(156, 21);
            this.lbSubType.TabIndex = 2;
            this.lbSubType.Text = "Виды абонементов";
            // 
            // tbSubNumber
            // 
            this.tbSubNumber.Location = new System.Drawing.Point(125, 12);
            this.tbSubNumber.Name = "tbSubNumber";
            this.tbSubNumber.Size = new System.Drawing.Size(60, 25);
            this.tbSubNumber.TabIndex = 1;
            this.tbSubNumber.TextChanged += new System.EventHandler(this.tbSubNumber_TextChanged);
            // 
            // lbSubNumber
            // 
            this.lbSubNumber.AutoSize = true;
            this.lbSubNumber.Location = new System.Drawing.Point(20, 15);
            this.lbSubNumber.Name = "lbSubNumber";
            this.lbSubNumber.Size = new System.Drawing.Size(104, 17);
            this.lbSubNumber.TabIndex = 0;
            this.lbSubNumber.Text = "№ абонемента*";
            // 
            // bgM2
            // 
            this.bgM2.BackColor = System.Drawing.Color.White;
            this.bgM2.Controls.Add(this.dtBuy);
            this.bgM2.Controls.Add(this.dtEnd);
            this.bgM2.Controls.Add(this.dtStart);
            this.bgM2.Controls.Add(this.lbBuy);
            this.bgM2.Controls.Add(this.lbEnd);
            this.bgM2.Controls.Add(this.lbStart);
            this.bgM2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bgM2.Location = new System.Drawing.Point(770, 70);
            this.bgM2.Margin = new System.Windows.Forms.Padding(5);
            this.bgM2.Name = "bgM2";
            this.bgM2.Size = new System.Drawing.Size(200, 220);
            this.bgM2.TabIndex = 3;
            this.bgM2.Paint += new System.Windows.Forms.PaintEventHandler(this.bgM2_Paint);
            // 
            // dtBuy
            // 
            this.dtBuy.Location = new System.Drawing.Point(13, 160);
            this.dtBuy.Name = "dtBuy";
            this.dtBuy.Size = new System.Drawing.Size(175, 25);
            this.dtBuy.TabIndex = 5;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(13, 100);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(175, 25);
            this.dtEnd.TabIndex = 4;
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(13, 35);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(175, 25);
            this.dtStart.TabIndex = 3;
            this.dtStart.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // lbBuy
            // 
            this.lbBuy.AutoSize = true;
            this.lbBuy.Location = new System.Drawing.Point(10, 140);
            this.lbBuy.Name = "lbBuy";
            this.lbBuy.Size = new System.Drawing.Size(87, 17);
            this.lbBuy.TabIndex = 2;
            this.lbBuy.Text = "Дата покупки";
            // 
            // lbEnd
            // 
            this.lbEnd.AutoSize = true;
            this.lbEnd.Location = new System.Drawing.Point(10, 80);
            this.lbEnd.Name = "lbEnd";
            this.lbEnd.Size = new System.Drawing.Size(75, 17);
            this.lbEnd.TabIndex = 1;
            this.lbEnd.Text = "Дата конца";
            // 
            // lbStart
            // 
            this.lbStart.AutoSize = true;
            this.lbStart.Location = new System.Drawing.Point(10, 15);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(82, 17);
            this.lbStart.TabIndex = 0;
            this.lbStart.Text = "Дата начала";
            // 
            // bgM3
            // 
            this.bgM3.BackColor = System.Drawing.Color.White;
            this.bgM3.Controls.Add(this.tbAdditional);
            this.bgM3.Controls.Add(this.lbAdditional);
            this.bgM3.Controls.Add(this.tbCount);
            this.bgM3.Controls.Add(this.lbCount);
            this.bgM3.Controls.Add(this.cbLimit);
            this.bgM3.Controls.Add(this.cbTrainer);
            this.bgM3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bgM3.Location = new System.Drawing.Point(770, 300);
            this.bgM3.Margin = new System.Windows.Forms.Padding(5);
            this.bgM3.Name = "bgM3";
            this.bgM3.Size = new System.Drawing.Size(200, 170);
            this.bgM3.TabIndex = 4;
            this.bgM3.Paint += new System.Windows.Forms.PaintEventHandler(this.bgM3_Paint);
            // 
            // tbAdditional
            // 
            this.tbAdditional.Location = new System.Drawing.Point(13, 125);
            this.tbAdditional.Name = "tbAdditional";
            this.tbAdditional.Size = new System.Drawing.Size(173, 25);
            this.tbAdditional.TabIndex = 5;
            // 
            // lbAdditional
            // 
            this.lbAdditional.AutoSize = true;
            this.lbAdditional.Location = new System.Drawing.Point(10, 105);
            this.lbAdditional.Name = "lbAdditional";
            this.lbAdditional.Size = new System.Drawing.Size(109, 17);
            this.lbAdditional.TabIndex = 4;
            this.lbAdditional.Text = "Дополнительное";
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(123, 70);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(60, 25);
            this.tbCount.TabIndex = 3;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(120, 50);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(51, 17);
            this.lbCount.TabIndex = 2;
            this.lbCount.Text = "Кол-во";
            // 
            // cbLimit
            // 
            this.cbLimit.AutoSize = true;
            this.cbLimit.Location = new System.Drawing.Point(15, 60);
            this.cbLimit.Name = "cbLimit";
            this.cbLimit.Size = new System.Drawing.Size(89, 21);
            this.cbLimit.TabIndex = 1;
            this.cbLimit.Text = "с лимитом";
            this.cbLimit.UseVisualStyleBackColor = true;
            // 
            // cbTrainer
            // 
            this.cbTrainer.AutoSize = true;
            this.cbTrainer.Location = new System.Drawing.Point(15, 15);
            this.cbTrainer.Name = "cbTrainer";
            this.cbTrainer.Size = new System.Drawing.Size(96, 21);
            this.cbTrainer.TabIndex = 0;
            this.cbTrainer.Text = "с тренером";
            this.cbTrainer.UseVisualStyleBackColor = true;
            // 
            // bgM4
            // 
            this.bgM4.BackColor = System.Drawing.Color.White;
            this.bgM4.Controls.Add(this.bgDiscounts);
            this.bgM4.Controls.Add(this.lbPercent);
            this.bgM4.Controls.Add(this.tbPercent);
            this.bgM4.Controls.Add(this.cbDisc);
            this.bgM4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bgM4.Location = new System.Drawing.Point(980, 70);
            this.bgM4.Margin = new System.Windows.Forms.Padding(5);
            this.bgM4.Name = "bgM4";
            this.bgM4.Size = new System.Drawing.Size(200, 260);
            this.bgM4.TabIndex = 5;
            this.bgM4.Paint += new System.Windows.Forms.PaintEventHandler(this.bgM4_Paint);
            // 
            // bgDiscounts
            // 
            this.bgDiscounts.AutoScroll = true;
            this.bgDiscounts.Location = new System.Drawing.Point(10, 50);
            this.bgDiscounts.Margin = new System.Windows.Forms.Padding(10);
            this.bgDiscounts.Name = "bgDiscounts";
            this.bgDiscounts.Size = new System.Drawing.Size(180, 200);
            this.bgDiscounts.TabIndex = 3;
            // 
            // lbPercent
            // 
            this.lbPercent.AutoSize = true;
            this.lbPercent.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPercent.Location = new System.Drawing.Point(160, 17);
            this.lbPercent.Name = "lbPercent";
            this.lbPercent.Size = new System.Drawing.Size(19, 17);
            this.lbPercent.TabIndex = 2;
            this.lbPercent.Text = "%";
            // 
            // tbPercent
            // 
            this.tbPercent.Enabled = false;
            this.tbPercent.Location = new System.Drawing.Point(114, 12);
            this.tbPercent.Name = "tbPercent";
            this.tbPercent.Size = new System.Drawing.Size(40, 25);
            this.tbPercent.TabIndex = 1;
            this.tbPercent.TextChanged += new System.EventHandler(this.tbPercent_TextChanged);
            // 
            // cbDisc
            // 
            this.cbDisc.AutoSize = true;
            this.cbDisc.Location = new System.Drawing.Point(15, 15);
            this.cbDisc.Name = "cbDisc";
            this.cbDisc.Size = new System.Drawing.Size(92, 21);
            this.cbDisc.TabIndex = 0;
            this.cbDisc.Text = "со скидкой";
            this.cbDisc.UseVisualStyleBackColor = true;
            this.cbDisc.CheckedChanged += new System.EventHandler(this.cbDisc_CheckedChanged);
            // 
            // bgM5
            // 
            this.bgM5.BackColor = System.Drawing.Color.White;
            this.bgM5.Controls.Add(this.tbSum);
            this.bgM5.Controls.Add(this.lbSum);
            this.bgM5.Controls.Add(this.btnCard);
            this.bgM5.Controls.Add(this.btnCash);
            this.bgM5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bgM5.Location = new System.Drawing.Point(980, 340);
            this.bgM5.Margin = new System.Windows.Forms.Padding(5);
            this.bgM5.Name = "bgM5";
            this.bgM5.Size = new System.Drawing.Size(200, 130);
            this.bgM5.TabIndex = 6;
            this.bgM5.Paint += new System.Windows.Forms.PaintEventHandler(this.bgM5_Paint);
            // 
            // tbSum
            // 
            this.tbSum.Location = new System.Drawing.Point(18, 85);
            this.tbSum.Name = "tbSum";
            this.tbSum.Size = new System.Drawing.Size(80, 25);
            this.tbSum.TabIndex = 3;
            this.tbSum.TextChanged += new System.EventHandler(this.tbSum_TextChanged);
            // 
            // lbSum
            // 
            this.lbSum.AutoSize = true;
            this.lbSum.Location = new System.Drawing.Point(15, 65);
            this.lbSum.Name = "lbSum";
            this.lbSum.Size = new System.Drawing.Size(52, 17);
            this.lbSum.TabIndex = 2;
            this.lbSum.Text = "Сумма*";
            // 
            // btnCard
            // 
            this.btnCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btnCard.FlatAppearance.BorderSize = 0;
            this.btnCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCard.Location = new System.Drawing.Point(105, 15);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(80, 35);
            this.btnCard.TabIndex = 1;
            this.btnCard.Text = "Картой";
            this.btnCard.UseVisualStyleBackColor = false;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnCash.FlatAppearance.BorderSize = 0;
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.ForeColor = System.Drawing.Color.White;
            this.btnCash.Location = new System.Drawing.Point(15, 15);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(80, 35);
            this.btnCash.TabIndex = 0;
            this.btnCash.Text = "Наличные";
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(1030, 569);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 40);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(770, 489);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 13);
            this.lbError.TabIndex = 8;
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1194, 641);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.bgM5);
            this.Controls.Add(this.bgM4);
            this.Controls.Add(this.bgM3);
            this.Controls.Add(this.bgM2);
            this.Controls.Add(this.bgM1);
            this.Controls.Add(this.lbTitle2);
            this.Controls.Add(this.bgMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.MinimumSize = new System.Drawing.Size(1110, 677);
            this.Name = "FormAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Страница продажи абонемента";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdd_FormClosing);
            this.Load += new System.EventHandler(this.FormAdd_Load);
            this.bgMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.bgMainData.ResumeLayout(false);
            this.bgMainData.PerformLayout();
            this.bgM1.ResumeLayout(false);
            this.bgM1.PerformLayout();
            this.bgM2.ResumeLayout(false);
            this.bgM2.PerformLayout();
            this.bgM3.ResumeLayout(false);
            this.bgM3.PerformLayout();
            this.bgM4.ResumeLayout(false);
            this.bgM4.PerformLayout();
            this.bgM5.ResumeLayout(false);
            this.bgM5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bgMain;
        private System.Windows.Forms.Label lbTitle1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Panel bgMainData;
        private System.Windows.Forms.Label lbTitle2;
        private System.Windows.Forms.Panel bgM1;
        private System.Windows.Forms.TextBox tbSubNumber;
        private System.Windows.Forms.Label lbSubNumber;
        private System.Windows.Forms.Panel bgM2;
        private System.Windows.Forms.Panel bgM3;
        private System.Windows.Forms.Panel bgM4;
        private System.Windows.Forms.Panel bgM5;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Label lbSurname;
        private System.Windows.Forms.CheckBox cbOldClient;
        private System.Windows.Forms.CheckBox cbNewClient;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurnameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.Label lbSubType;
        private System.Windows.Forms.Panel bgSubType;
        private System.Windows.Forms.DateTimePicker dtBuy;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label lbBuy;
        private System.Windows.Forms.Label lbEnd;
        private System.Windows.Forms.Label lbStart;
        private System.Windows.Forms.TextBox tbAdditional;
        private System.Windows.Forms.Label lbAdditional;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.CheckBox cbLimit;
        private System.Windows.Forms.CheckBox cbTrainer;
        private System.Windows.Forms.Panel bgDiscounts;
        private System.Windows.Forms.Label lbPercent;
        private System.Windows.Forms.TextBox tbPercent;
        private System.Windows.Forms.CheckBox cbDisc;
        private System.Windows.Forms.TextBox tbSum;
        private System.Windows.Forms.Label lbSum;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Label lbError1;
    }
}