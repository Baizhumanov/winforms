namespace Flex00
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdOfClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubscriptionNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubscriptionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WithTrainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WithDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypePayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Additional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lbSurname = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnCome = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tbSubNumber = new System.Windows.Forms.TextBox();
            this.lbSubNumber = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всяТаблицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналСобытийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.продажиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разовыеПосещенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управляющийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.архивToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgM1 = new System.Windows.Forms.Panel();
            this.lbError = new System.Windows.Forms.Label();
            this.bgM2 = new System.Windows.Forms.Panel();
            this.bgM3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.bgM1.SuspendLayout();
            this.bgM2.SuspendLayout();
            this.bgM3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnExit.FlatAppearance.BorderSize = 2;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageIndex = 1;
            this.btnExit.Location = new System.Drawing.Point(12, 507);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 42);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "034-refresh.png");
            this.imageList1.Images.SetKeyName(1, "079-home.png");
            this.imageList1.Images.SetKeyName(2, "098-delete-2.png");
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(10, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(280, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Продать абонемент";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdOfClient,
            this.Surname,
            this.NameDB,
            this.SubscriptionNumber,
            this.SubscriptionType,
            this.StartDate,
            this.EndDate,
            this.Visit,
            this.PaymentDate,
            this.WithTrainer,
            this.WithDiscount,
            this.TypePayment,
            this.Amount,
            this.Additional});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(834, 402);
            this.dataGridView1.TabIndex = 4;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 40;
            // 
            // IdOfClient
            // 
            this.IdOfClient.HeaderText = "Id клиента";
            this.IdOfClient.Name = "IdOfClient";
            this.IdOfClient.ReadOnly = true;
            this.IdOfClient.Visible = false;
            // 
            // Surname
            // 
            this.Surname.HeaderText = "Фамилия";
            this.Surname.Name = "Surname";
            this.Surname.ReadOnly = true;
            // 
            // NameDB
            // 
            this.NameDB.HeaderText = "Имя";
            this.NameDB.Name = "NameDB";
            this.NameDB.ReadOnly = true;
            // 
            // SubscriptionNumber
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SubscriptionNumber.DefaultCellStyle = dataGridViewCellStyle9;
            this.SubscriptionNumber.HeaderText = "Номер абонемента";
            this.SubscriptionNumber.Name = "SubscriptionNumber";
            this.SubscriptionNumber.ReadOnly = true;
            this.SubscriptionNumber.Width = 85;
            // 
            // SubscriptionType
            // 
            this.SubscriptionType.HeaderText = "Тип абонемента";
            this.SubscriptionType.Name = "SubscriptionType";
            this.SubscriptionType.ReadOnly = true;
            this.SubscriptionType.Width = 200;
            // 
            // StartDate
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StartDate.DefaultCellStyle = dataGridViewCellStyle10;
            this.StartDate.HeaderText = "Дата началы";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            // 
            // EndDate
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EndDate.DefaultCellStyle = dataGridViewCellStyle11;
            this.EndDate.HeaderText = "Дата окончания";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // Visit
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Visit.DefaultCellStyle = dataGridViewCellStyle12;
            this.Visit.HeaderText = "Осталось";
            this.Visit.Name = "Visit";
            this.Visit.ReadOnly = true;
            this.Visit.Width = 70;
            // 
            // PaymentDate
            // 
            this.PaymentDate.HeaderText = "Дата оплаты";
            this.PaymentDate.Name = "PaymentDate";
            this.PaymentDate.ReadOnly = true;
            this.PaymentDate.Visible = false;
            this.PaymentDate.Width = 80;
            // 
            // WithTrainer
            // 
            this.WithTrainer.HeaderText = "С тренером";
            this.WithTrainer.Name = "WithTrainer";
            this.WithTrainer.ReadOnly = true;
            this.WithTrainer.Visible = false;
            this.WithTrainer.Width = 80;
            // 
            // WithDiscount
            // 
            this.WithDiscount.HeaderText = "Скидка";
            this.WithDiscount.Name = "WithDiscount";
            this.WithDiscount.ReadOnly = true;
            this.WithDiscount.Visible = false;
            this.WithDiscount.Width = 50;
            // 
            // TypePayment
            // 
            this.TypePayment.HeaderText = "Вид оплаты";
            this.TypePayment.Name = "TypePayment";
            this.TypePayment.ReadOnly = true;
            this.TypePayment.Visible = false;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Сумма";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Visible = false;
            this.Amount.Width = 50;
            // 
            // Additional
            // 
            this.Additional.HeaderText = "Дополнительное";
            this.Additional.Name = "Additional";
            this.Additional.ReadOnly = true;
            this.Additional.Visible = false;
            this.Additional.Width = 200;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.button3.Location = new System.Drawing.Point(300, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 40);
            this.button3.TabIndex = 5;
            this.button3.Text = "Изменить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.ImageIndex = 2;
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(500, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 32);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.button4_Click);
            // 
            // lbSurname
            // 
            this.lbSurname.AutoSize = true;
            this.lbSurname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSurname.Location = new System.Drawing.Point(15, 15);
            this.lbSurname.Name = "lbSurname";
            this.lbSurname.Size = new System.Drawing.Size(99, 21);
            this.lbSurname.TabIndex = 7;
            this.lbSurname.Text = "По фамилии";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(246, 37);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 30);
            this.button5.TabIndex = 8;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tbSurname
            // 
            this.tbSurname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSurname.Location = new System.Drawing.Point(19, 39);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(100, 29);
            this.tbSurname.TabIndex = 9;
            this.tbSurname.TextChanged += new System.EventHandler(this.tbSurname_TextChanged);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbName.Location = new System.Drawing.Point(136, 15);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(80, 21);
            this.lbName.TabIndex = 10;
            this.lbName.Text = "По имени";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(140, 39);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 29);
            this.tbName.TabIndex = 11;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // btnCome
            // 
            this.btnCome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnCome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnCome.FlatAppearance.BorderSize = 2;
            this.btnCome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCome.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCome.ForeColor = System.Drawing.Color.White;
            this.btnCome.Location = new System.Drawing.Point(176, 100);
            this.btnCome.Name = "btnCome";
            this.btnCome.Size = new System.Drawing.Size(100, 32);
            this.btnCome.TabIndex = 15;
            this.btnCome.Text = "Пришел";
            this.btnCome.UseVisualStyleBackColor = false;
            this.btnCome.Click += new System.EventHandler(this.button11_Click);
            // 
            // button8
            // 
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(125, 102);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(30, 30);
            this.button8.TabIndex = 14;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tbSubNumber
            // 
            this.tbSubNumber.Location = new System.Drawing.Point(19, 104);
            this.tbSubNumber.Name = "tbSubNumber";
            this.tbSubNumber.Size = new System.Drawing.Size(100, 29);
            this.tbSubNumber.TabIndex = 13;
            this.tbSubNumber.TextChanged += new System.EventHandler(this.tbSubNumber_TextChanged);
            // 
            // lbSubNumber
            // 
            this.lbSubNumber.AutoSize = true;
            this.lbSubNumber.Location = new System.Drawing.Point(15, 80);
            this.lbSubNumber.Name = "lbSubNumber";
            this.lbSubNumber.Size = new System.Drawing.Size(88, 21);
            this.lbSubNumber.TabIndex = 12;
            this.lbSubNumber.Text = "По номеру";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(24, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 225);
            this.panel1.TabIndex = 17;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnFilter.FlatAppearance.BorderSize = 2;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(24, 276);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(100, 32);
            this.btnFilter.TabIndex = 18;
            this.btnFilter.Text = "Фильтр";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.button10_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdate.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.ImageIndex = 0;
            this.btnUpdate.ImageList = this.imageList1;
            this.btnUpdate.Location = new System.Drawing.Point(550, 15);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(32, 32);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button12_Click);
            // 
            // btnReset
            // 
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnReset.FlatAppearance.BorderSize = 2;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnReset.Location = new System.Drawing.Point(173, 276);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 32);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.button13_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 449);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "Всего записей: ";
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Checked = true;
            this.cbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbActive.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbActive.Location = new System.Drawing.Point(24, 247);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(99, 25);
            this.cbActive.TabIndex = 22;
            this.cbActive.Text = "Активные";
            this.cbActive.UseVisualStyleBackColor = true;
            this.cbActive.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентыToolStripMenuItem,
            this.всяТаблицаToolStripMenuItem,
            this.журналСобытийToolStripMenuItem,
            this.продажиToolStripMenuItem,
            this.разовыеПосещенияToolStripMenuItem,
            this.управляющийToolStripMenuItem,
            this.архивToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1159, 25);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // всяТаблицаToolStripMenuItem
            // 
            this.всяТаблицаToolStripMenuItem.Name = "всяТаблицаToolStripMenuItem";
            this.всяТаблицаToolStripMenuItem.Size = new System.Drawing.Size(96, 21);
            this.всяТаблицаToolStripMenuItem.Text = "Вся таблица";
            this.всяТаблицаToolStripMenuItem.Click += new System.EventHandler(this.всяТаблицаToolStripMenuItem_Click);
            // 
            // журналСобытийToolStripMenuItem
            // 
            this.журналСобытийToolStripMenuItem.Name = "журналСобытийToolStripMenuItem";
            this.журналСобытийToolStripMenuItem.Size = new System.Drawing.Size(127, 21);
            this.журналСобытийToolStripMenuItem.Text = "Журнал событий";
            this.журналСобытийToolStripMenuItem.Click += new System.EventHandler(this.журналСобытийToolStripMenuItem_Click);
            // 
            // продажиToolStripMenuItem
            // 
            this.продажиToolStripMenuItem.Name = "продажиToolStripMenuItem";
            this.продажиToolStripMenuItem.Size = new System.Drawing.Size(79, 21);
            this.продажиToolStripMenuItem.Text = "Продажи";
            this.продажиToolStripMenuItem.Click += new System.EventHandler(this.продажиToolStripMenuItem_Click);
            // 
            // разовыеПосещенияToolStripMenuItem
            // 
            this.разовыеПосещенияToolStripMenuItem.Name = "разовыеПосещенияToolStripMenuItem";
            this.разовыеПосещенияToolStripMenuItem.Size = new System.Drawing.Size(147, 21);
            this.разовыеПосещенияToolStripMenuItem.Text = "Разовые посещения";
            this.разовыеПосещенияToolStripMenuItem.Click += new System.EventHandler(this.разовыеПосещенияToolStripMenuItem_Click);
            // 
            // управляющийToolStripMenuItem
            // 
            this.управляющийToolStripMenuItem.Name = "управляющийToolStripMenuItem";
            this.управляющийToolStripMenuItem.Size = new System.Drawing.Size(110, 21);
            this.управляющийToolStripMenuItem.Text = "Управляющий";
            this.управляющийToolStripMenuItem.Click += new System.EventHandler(this.управляющийToolStripMenuItem_Click);
            // 
            // архивToolStripMenuItem
            // 
            this.архивToolStripMenuItem.Name = "архивToolStripMenuItem";
            this.архивToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.архивToolStripMenuItem.Text = "Архив";
            this.архивToolStripMenuItem.Click += new System.EventHandler(this.архивToolStripMenuItem_Click);
            // 
            // bgM1
            // 
            this.bgM1.BackColor = System.Drawing.Color.White;
            this.bgM1.Controls.Add(this.lbError);
            this.bgM1.Controls.Add(this.btnCome);
            this.bgM1.Controls.Add(this.button5);
            this.bgM1.Controls.Add(this.tbName);
            this.bgM1.Controls.Add(this.button8);
            this.bgM1.Controls.Add(this.lbName);
            this.bgM1.Controls.Add(this.tbSurname);
            this.bgM1.Controls.Add(this.tbSubNumber);
            this.bgM1.Controls.Add(this.lbSurname);
            this.bgM1.Controls.Add(this.lbSubNumber);
            this.bgM1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bgM1.Location = new System.Drawing.Point(853, 370);
            this.bgM1.Name = "bgM1";
            this.bgM1.Size = new System.Drawing.Size(295, 180);
            this.bgM1.TabIndex = 27;
            this.bgM1.Paint += new System.Windows.Forms.PaintEventHandler(this.bgM1_Paint);
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(20, 140);
            this.lbError.MaximumSize = new System.Drawing.Size(260, 0);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 17);
            this.lbError.TabIndex = 16;
            // 
            // bgM2
            // 
            this.bgM2.BackColor = System.Drawing.Color.White;
            this.bgM2.Controls.Add(this.panel1);
            this.bgM2.Controls.Add(this.cbActive);
            this.bgM2.Controls.Add(this.btnFilter);
            this.bgM2.Controls.Add(this.btnReset);
            this.bgM2.Location = new System.Drawing.Point(852, 41);
            this.bgM2.Name = "bgM2";
            this.bgM2.Size = new System.Drawing.Size(296, 323);
            this.bgM2.TabIndex = 28;
            this.bgM2.Paint += new System.Windows.Forms.PaintEventHandler(this.bgM2_Paint);
            // 
            // bgM3
            // 
            this.bgM3.BackColor = System.Drawing.Color.White;
            this.bgM3.Controls.Add(this.button2);
            this.bgM3.Controls.Add(this.button3);
            this.bgM3.Controls.Add(this.btnDelete);
            this.bgM3.Controls.Add(this.btnUpdate);
            this.bgM3.Location = new System.Drawing.Point(236, 456);
            this.bgM3.Name = "bgM3";
            this.bgM3.Size = new System.Drawing.Size(610, 60);
            this.bgM3.TabIndex = 29;
            this.bgM3.Paint += new System.Windows.Forms.PaintEventHandler(this.bgM3_Paint);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1159, 561);
            this.Controls.Add(this.bgM3);
            this.Controls.Add(this.bgM2);
            this.Controls.Add(this.bgM1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная страница";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.VisibleChanged += new System.EventHandler(this.Form2_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.bgM1.ResumeLayout(false);
            this.bgM1.PerformLayout();
            this.bgM2.ResumeLayout(false);
            this.bgM2.PerformLayout();
            this.bgM3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lbSurname;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox tbSubNumber;
        private System.Windows.Forms.Label lbSubNumber;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnCome;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всяТаблицаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналСобытийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem продажиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разовыеПосещенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управляющийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem архивToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel bgM1;
        private System.Windows.Forms.Panel bgM2;
        private System.Windows.Forms.Panel bgM3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOfClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubscriptionNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubscriptionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Visit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn WithTrainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn WithDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypePayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Additional;
        private System.Windows.Forms.Label lbError;
    }
}