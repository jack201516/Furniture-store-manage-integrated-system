namespace ITP4915M__sales_part__
{
    partial class Form15
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
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.dtpDispatchDate = new System.Windows.Forms.DateTimePicker();
            this.btnBack = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.ForeColor = System.Drawing.Color.Black;
            this.lblDeliveryDate.Location = new System.Drawing.Point(24, 98);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(99, 13);
            this.lblDeliveryDate.TabIndex = 15;
            this.lblDeliveryDate.Text = "Delivery Date & time:";
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(26, 143);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.Size = new System.Drawing.Size(745, 250);
            this.dgvOrderItems.TabIndex = 19;
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.BackColor = System.Drawing.Color.Red;
            this.btnCancelOrder.ForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.Location = new System.Drawing.Point(631, 420);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(110, 30);
            this.btnCancelOrder.TabIndex = 20;
            this.btnCancelOrder.Text = "Cancel Item";
            this.btnCancelOrder.UseVisualStyleBackColor = false;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelItem_Click);
            // 
            // dtpDispatchDate
            // 
            this.dtpDispatchDate.Location = new System.Drawing.Point(131, 90);
            this.dtpDispatchDate.Name = "dtpDispatchDate";
            this.dtpDispatchDate.Size = new System.Drawing.Size(150, 20);
            this.dtpDispatchDate.TabIndex = 21;
            this.dtpDispatchDate.Value = new System.DateTime(2026, 4, 20, 0, 0, 0, 0);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(26, 420);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "SAVE";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 30);
            this.button1.TabIndex = 23;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dtpDispatchDate);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.lblDeliveryDate);
            this.Name = "Form15";
            this.Text = "Form15";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.DateTimePicker dtpDispatchDate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button button1;
    }
}