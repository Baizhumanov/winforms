namespace Flex00
{
    partial class FormArchive
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
            this.bgData = new System.Windows.Forms.Panel();
            this.lbTitle1 = new System.Windows.Forms.Label();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.bgControl = new System.Windows.Forms.Panel();
            this.btnSold = new System.Windows.Forms.Button();
            this.btnSells = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.bgData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.bgControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgData
            // 
            this.bgData.BackColor = System.Drawing.Color.White;
            this.bgData.Controls.Add(this.lbTitle1);
            this.bgData.Controls.Add(this.dgw);
            this.bgData.Location = new System.Drawing.Point(19, 19);
            this.bgData.Margin = new System.Windows.Forms.Padding(10);
            this.bgData.Name = "bgData";
            this.bgData.Size = new System.Drawing.Size(450, 412);
            this.bgData.TabIndex = 0;
            this.bgData.Paint += new System.Windows.Forms.PaintEventHandler(this.bgData_Paint);
            // 
            // lbTitle1
            // 
            this.lbTitle1.AutoSize = true;
            this.lbTitle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.lbTitle1.Location = new System.Drawing.Point(10, 20);
            this.lbTitle1.Name = "lbTitle1";
            this.lbTitle1.Size = new System.Drawing.Size(58, 21);
            this.lbTitle1.TabIndex = 1;
            this.lbTitle1.Text = "Архив";
            // 
            // dgw
            // 
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Location = new System.Drawing.Point(10, 51);
            this.dgw.Margin = new System.Windows.Forms.Padding(10);
            this.dgw.Name = "dgw";
            this.dgw.Size = new System.Drawing.Size(430, 351);
            this.dgw.TabIndex = 0;
            // 
            // bgControl
            // 
            this.bgControl.BackColor = System.Drawing.Color.White;
            this.bgControl.Controls.Add(this.btnSold);
            this.bgControl.Controls.Add(this.btnSells);
            this.bgControl.Controls.Add(this.btnProducts);
            this.bgControl.Controls.Add(this.btnClients);
            this.bgControl.Controls.Add(this.btnReturn);
            this.bgControl.Location = new System.Drawing.Point(489, 19);
            this.bgControl.Margin = new System.Windows.Forms.Padding(10);
            this.bgControl.Name = "bgControl";
            this.bgControl.Size = new System.Drawing.Size(200, 412);
            this.bgControl.TabIndex = 1;
            this.bgControl.Paint += new System.Windows.Forms.PaintEventHandler(this.bgControl_Paint);
            // 
            // btnSold
            // 
            this.btnSold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btnSold.FlatAppearance.BorderSize = 0;
            this.btnSold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSold.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnSold.Location = new System.Drawing.Point(10, 164);
            this.btnSold.Margin = new System.Windows.Forms.Padding(10);
            this.btnSold.Name = "btnSold";
            this.btnSold.Size = new System.Drawing.Size(180, 40);
            this.btnSold.TabIndex = 4;
            this.btnSold.Text = "Абонементы";
            this.btnSold.UseVisualStyleBackColor = false;
            this.btnSold.Click += new System.EventHandler(this.btnSold_Click);
            // 
            // btnSells
            // 
            this.btnSells.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btnSells.FlatAppearance.BorderSize = 0;
            this.btnSells.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSells.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSells.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnSells.Location = new System.Drawing.Point(10, 113);
            this.btnSells.Margin = new System.Windows.Forms.Padding(10);
            this.btnSells.Name = "btnSells";
            this.btnSells.Size = new System.Drawing.Size(180, 40);
            this.btnSells.TabIndex = 3;
            this.btnSells.Text = "Продажи";
            this.btnSells.UseVisualStyleBackColor = false;
            this.btnSells.Click += new System.EventHandler(this.btnSells_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnProducts.Location = new System.Drawing.Point(10, 62);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(10);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(180, 40);
            this.btnProducts.TabIndex = 2;
            this.btnProducts.Text = "Продукты";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Location = new System.Drawing.Point(10, 10);
            this.btnClients.Margin = new System.Windows.Forms.Padding(10);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(180, 40);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Клиенты";
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(10, 354);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(10);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(180, 48);
            this.btnReturn.TabIndex = 0;
            this.btnReturn.Text = "Восстановить";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnBack.FlatAppearance.BorderSize = 2;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(250)))));
            this.btnBack.Location = new System.Drawing.Point(19, 444);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 40);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(727, 496);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.bgControl);
            this.Controls.Add(this.bgData);
            this.Name = "FormArchive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Архив";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormArchive_FormClosing);
            this.bgData.ResumeLayout(false);
            this.bgData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.bgControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bgData;
        private System.Windows.Forms.Panel bgControl;
        private System.Windows.Forms.Label lbTitle1;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.Button btnSold;
        private System.Windows.Forms.Button btnSells;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnBack;
    }
}