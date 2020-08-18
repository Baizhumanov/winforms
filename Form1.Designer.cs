namespace Flex00
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbLoad = new System.Windows.Forms.PictureBox();
            this.bgHelp = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bgAuth = new System.Windows.Forms.Panel();
            this.btnAuth = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).BeginInit();
            this.bgHelp.SuspendLayout();
            this.bgAuth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLoad
            // 
            this.pbLoad.Image = ((System.Drawing.Image)(resources.GetObject("pbLoad.Image")));
            this.pbLoad.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbLoad.InitialImage")));
            this.pbLoad.Location = new System.Drawing.Point(25, 375);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(32, 32);
            this.pbLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoad.TabIndex = 6;
            this.pbLoad.TabStop = false;
            // 
            // bgHelp
            // 
            this.bgHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bgHelp.BackColor = System.Drawing.Color.White;
            this.bgHelp.Controls.Add(this.btnHelp);
            this.bgHelp.Location = new System.Drawing.Point(500, 25);
            this.bgHelp.Margin = new System.Windows.Forms.Padding(3, 3, 25, 3);
            this.bgHelp.Name = "bgHelp";
            this.bgHelp.Size = new System.Drawing.Size(200, 50);
            this.bgHelp.TabIndex = 8;
            this.bgHelp.Paint += new System.Windows.Forms.PaintEventHandler(this.bgHelp_Paint);
            // 
            // btnHelp
            // 
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.ImageIndex = 1;
            this.btnHelp.ImageList = this.imageList1;
            this.btnHelp.Location = new System.Drawing.Point(5, 5);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(5);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Padding = new System.Windows.Forms.Padding(10, 0, 30, 0);
            this.btnHelp.Size = new System.Drawing.Size(190, 40);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.Text = "Инструкция";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "login.png");
            this.imageList1.Images.SetKeyName(1, "question.png");
            // 
            // bgAuth
            // 
            this.bgAuth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bgAuth.BackColor = System.Drawing.Color.White;
            this.bgAuth.Controls.Add(this.btnAuth);
            this.bgAuth.Location = new System.Drawing.Point(500, 357);
            this.bgAuth.Margin = new System.Windows.Forms.Padding(3, 3, 25, 25);
            this.bgAuth.Name = "bgAuth";
            this.bgAuth.Size = new System.Drawing.Size(200, 50);
            this.bgAuth.TabIndex = 9;
            this.bgAuth.Paint += new System.Windows.Forms.PaintEventHandler(this.bgAuth_Paint);
            // 
            // btnAuth
            // 
            this.btnAuth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAuth.FlatAppearance.BorderSize = 0;
            this.btnAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuth.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAuth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuth.ImageIndex = 0;
            this.btnAuth.ImageList = this.imageList1;
            this.btnAuth.Location = new System.Drawing.Point(5, 5);
            this.btnAuth.Margin = new System.Windows.Forms.Padding(5);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnAuth.Size = new System.Drawing.Size(190, 40);
            this.btnAuth.TabIndex = 0;
            this.btnAuth.Text = "Авторизация";
            this.btnAuth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAuth.UseVisualStyleBackColor = true;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatus.Location = new System.Drawing.Point(63, 384);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(224, 18);
            this.lbStatus.TabIndex = 10;
            this.lbStatus.Text = "Соединение с базой данных...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(253, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 249);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 441);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.bgAuth);
            this.Controls.Add(this.bgHelp);
            this.Controls.Add(this.pbLoad);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FLEX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).EndInit();
            this.bgHelp.ResumeLayout(false);
            this.bgAuth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbLoad;
        private System.Windows.Forms.Panel bgHelp;
        private System.Windows.Forms.Panel bgAuth;
        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

