namespace ITP4915M__sales_part__
{
    partial class OrderDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTopMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMail = new System.Windows.Forms.Button();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.lblPLFC = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.pnlTopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopMenu
            // 
            this.pnlTopMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.pnlTopMenu.Controls.Add(this.btnLogout);
            this.pnlTopMenu.Controls.Add(this.btnMail);
            this.pnlTopMenu.Controls.Add(this.btnOrderList);
            this.pnlTopMenu.Controls.Add(this.btnNewOrder);
            this.pnlTopMenu.Controls.Add(this.lblPLFC);
            this.pnlTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlTopMenu.Name = "pnlTopMenu";
            this.pnlTopMenu.Size = new System.Drawing.Size(700, 60);
            this.pnlTopMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(540, 10);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 40);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnMail
            // 
            this.btnMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMail.ForeColor = System.Drawing.Color.White;
            this.btnMail.Location = new System.Drawing.Point(400, 10);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(120, 40);
            this.btnMail.TabIndex = 3;
            this.btnMail.Text = "Complaint";
            this.btnMail.UseVisualStyleBackColor = true;
            // 
            // btnOrderList
            // 
            this.btnOrderList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderList.ForeColor = System.Drawing.Color.White;
            this.btnOrderList.Location = new System.Drawing.Point(260, 10);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(120, 40);
            this.btnOrderList.TabIndex = 2;
            this.btnOrderList.Text = "Order List";
            this.btnOrderList.UseVisualStyleBackColor = true;
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewOrder.ForeColor = System.Drawing.Color.White;
            this.btnNewOrder.Location = new System.Drawing.Point(120, 10);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(120, 40);
            this.btnNewOrder.TabIndex = 1;
            this.btnNewOrder.Text = "New order";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            // 
            // lblPLFC
            // 
            this.lblPLFC.AutoSize = true;
            this.lblPLFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblPLFC.ForeColor = System.Drawing.Color.White;
            this.lblPLFC.Location = new System.Drawing.Point(20, 15);
            this.lblPLFC.Name = "lblPLFC";
            this.lblPLFC.Size = new System.Drawing.Size(78, 29);
            this.lblPLFC.TabIndex = 0;
            this.lblPLFC.Text = "PLFC";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrderNumber.ForeColor = System.Drawing.Color.Black;
            this.lblOrderNumber.Location = new System.Drawing.Point(20, 80);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(80, 20);
            this.lblOrderNumber.TabIndex = 1;
            this.lblOrderNumber.Text = "orderID: ";
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.ForeColor = System.Drawing.Color.Black;
            this.lblDeliveryDate.Location = new System.Drawing.Point(20, 120);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(99, 13);
            this.lblDeliveryDate.TabIndex = 2;
            this.lblDeliveryDate.Text = "Delivery Date & time:";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerID.Location = new System.Drawing.Point(20, 155);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(68, 13);
            this.lblCustomerID.TabIndex = 5;
            this.lblCustomerID.Text = "Customer ID:";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.ForeColor = System.Drawing.Color.Black;
            this.lblOrderDate.Location = new System.Drawing.Point(220, 155);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(62, 13);
            this.lblOrderDate.TabIndex = 7;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.ForeColor = System.Drawing.Color.Black;
            this.lblAddress.Location = new System.Drawing.Point(20, 185);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Address:";
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(25, 220);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.Size = new System.Drawing.Size(648, 150);
            this.dgvOrderItems.TabIndex = 11;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(23, 390);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 30);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.OrderDetailForm_Load);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.BackColor = System.Drawing.Color.Red;
            this.btnCancelOrder.ForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.Location = new System.Drawing.Point(560, 390);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(110, 30);
            this.btnCancelOrder.TabIndex = 14;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.UseVisualStyleBackColor = false;
            this.btnCancelOrder.Click += new System.EventHandler(this.OrderDetailForm_Load);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(23, 440);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 17;
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Location = new System.Drawing.Point(120, 113);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(150, 20);
            this.dtpDeliveryDate.TabIndex = 22;
            this.dtpDeliveryDate.Value = new System.DateTime(2026, 4, 20, 0, 0, 0, 0);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(94, 152);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerID.TabIndex = 23;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(285, 152);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(100, 20);
            this.txtOrderDate.TabIndex = 25;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(71, 182);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(365, 20);
            this.txtAddress.TabIndex = 26;
            // 
            // OrderDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 490);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.dtpDeliveryDate);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.lblDeliveryDate);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.pnlTopMenu);
            this.Name = "OrderDetailForm";
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.OrderDetailForm_Load);
            this.pnlTopMenu.ResumeLayout(false);
            this.pnlTopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Label lblPLFC;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Button btnMail;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.TextBox txtAddress;
    }
}