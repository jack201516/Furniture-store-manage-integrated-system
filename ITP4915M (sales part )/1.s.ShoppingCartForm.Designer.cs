namespace ITP4915M__sales_part__
{
    partial class ShoppingCartForm
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
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.grpCustomerInfo = new System.Windows.Forms.GroupBox();
            this.dtpDispatchDate = new System.Windows.Forms.DateTimePicker();
            this.lblDispatchDate = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblOrderDate2 = new System.Windows.Forms.Label();
            this.grpPayment = new System.Windows.Forms.GroupBox();
            this.rdbMasterCard = new System.Windows.Forms.RadioButton();
            this.rdbVisa = new System.Windows.Forms.RadioButton();
            this.rdbCash = new System.Windows.Forms.RadioButton();
            this.btnConfirmOrder = new System.Windows.Forms.Button();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.pnlTopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.grpCustomerInfo.SuspendLayout();
            this.grpPayment.SuspendLayout();
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
            this.pnlTopMenu.Size = new System.Drawing.Size(734, 55);
            this.pnlTopMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(540, 9);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 37);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnMail
            // 
            this.btnMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMail.ForeColor = System.Drawing.Color.White;
            this.btnMail.Location = new System.Drawing.Point(400, 9);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(120, 37);
            this.btnMail.TabIndex = 3;
            this.btnMail.Text = "Complaint";
            this.btnMail.UseVisualStyleBackColor = true;
            // 
            // btnOrderList
            // 
            this.btnOrderList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderList.ForeColor = System.Drawing.Color.White;
            this.btnOrderList.Location = new System.Drawing.Point(260, 9);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(120, 37);
            this.btnOrderList.TabIndex = 2;
            this.btnOrderList.Text = "Order List";
            this.btnOrderList.UseVisualStyleBackColor = true;
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewOrder.ForeColor = System.Drawing.Color.White;
            this.btnNewOrder.Location = new System.Drawing.Point(120, 9);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(120, 37);
            this.btnNewOrder.TabIndex = 1;
            this.btnNewOrder.Text = "New order";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            // 
            // lblPLFC
            // 
            this.lblPLFC.AutoSize = true;
            this.lblPLFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblPLFC.ForeColor = System.Drawing.Color.White;
            this.lblPLFC.Location = new System.Drawing.Point(20, 14);
            this.lblPLFC.Name = "lblPLFC";
            this.lblPLFC.Size = new System.Drawing.Size(78, 29);
            this.lblPLFC.TabIndex = 0;
            this.lblPLFC.Text = "PLFC";
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(12, 74);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.Size = new System.Drawing.Size(700, 138);
            this.dgvCart.TabIndex = 1;
            // 
            // grpCustomerInfo
            // 
            this.grpCustomerInfo.Controls.Add(this.dtpDispatchDate);
            this.grpCustomerInfo.Controls.Add(this.lblDispatchDate);
            this.grpCustomerInfo.Controls.Add(this.lblOrderDate);
            this.grpCustomerInfo.Controls.Add(this.txtAddress);
            this.grpCustomerInfo.Controls.Add(this.lblAddress);
            this.grpCustomerInfo.Controls.Add(this.txtEmail);
            this.grpCustomerInfo.Controls.Add(this.lblEmail);
            this.grpCustomerInfo.Controls.Add(this.txtContact);
            this.grpCustomerInfo.Controls.Add(this.lblContact);
            this.grpCustomerInfo.Controls.Add(this.txtCustomerID);
            this.grpCustomerInfo.Controls.Add(this.lblCustomerID);
            this.grpCustomerInfo.Controls.Add(this.lblOrderDate2);
            this.grpCustomerInfo.Location = new System.Drawing.Point(12, 258);
            this.grpCustomerInfo.Name = "grpCustomerInfo";
            this.grpCustomerInfo.Size = new System.Drawing.Size(450, 185);
            this.grpCustomerInfo.TabIndex = 3;
            this.grpCustomerInfo.TabStop = false;
            this.grpCustomerInfo.Text = "Customer Information";
            // 
            // dtpDispatchDate
            // 
            this.dtpDispatchDate.Location = new System.Drawing.Point(100, 159);
            this.dtpDispatchDate.Name = "dtpDispatchDate";
            this.dtpDispatchDate.Size = new System.Drawing.Size(150, 22);
            this.dtpDispatchDate.TabIndex = 11;
            this.dtpDispatchDate.Value = new System.DateTime(2026, 4, 20, 0, 0, 0, 0);
            // 
            // lblDispatchDate
            // 
            this.lblDispatchDate.AutoSize = true;
            this.lblDispatchDate.Location = new System.Drawing.Point(20, 162);
            this.lblDispatchDate.Name = "lblDispatchDate";
            this.lblDispatchDate.Size = new System.Drawing.Size(72, 12);
            this.lblDispatchDate.TabIndex = 10;
            this.lblDispatchDate.Text = "Dispatch Date:";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(20, 138);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(59, 12);
            this.lblOrderDate.TabIndex = 8;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(70, 108);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(350, 22);
            this.txtAddress.TabIndex = 7;
            this.txtAddress.Text = "Zhuoerju Phase 1, Building 2,101";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 111);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 12);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Address:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(60, 80);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(190, 22);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.Text = "CTKAP@gmail.com";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 83);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(29, 12);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Mail:";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(110, 53);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(140, 22);
            this.txtContact.TabIndex = 3;
            this.txtContact.Text = "25100122";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(20, 55);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(85, 12);
            this.lblContact.TabIndex = 2;
            this.lblContact.Text = "Contact Number:";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(100, 25);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(150, 22);
            this.txtCustomerID.TabIndex = 1;
            this.txtCustomerID.Text = "C000001";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(20, 28);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(68, 12);
            this.lblCustomerID.TabIndex = 0;
            this.lblCustomerID.Text = "Customer ID:";
            // 
            // lblOrderDate2
            // 
            this.lblOrderDate2.AutoSize = true;
            this.lblOrderDate2.Location = new System.Drawing.Point(100, 138);
            this.lblOrderDate2.Name = "lblOrderDate2";
            this.lblOrderDate2.Size = new System.Drawing.Size(59, 12);
            this.lblOrderDate2.TabIndex = 9;
            this.lblOrderDate2.Text = "2026/03/20";
            // 
            // grpPayment
            // 
            this.grpPayment.Controls.Add(this.rdbMasterCard);
            this.grpPayment.Controls.Add(this.rdbVisa);
            this.grpPayment.Controls.Add(this.rdbCash);
            this.grpPayment.Location = new System.Drawing.Point(480, 258);
            this.grpPayment.Name = "grpPayment";
            this.grpPayment.Size = new System.Drawing.Size(232, 92);
            this.grpPayment.TabIndex = 4;
            this.grpPayment.TabStop = false;
            this.grpPayment.Text = "Payment Methods";
            // 
            // rdbMasterCard
            // 
            this.rdbMasterCard.AutoSize = true;
            this.rdbMasterCard.Location = new System.Drawing.Point(20, 69);
            this.rdbMasterCard.Name = "rdbMasterCard";
            this.rdbMasterCard.Size = new System.Drawing.Size(77, 16);
            this.rdbMasterCard.TabIndex = 2;
            this.rdbMasterCard.Text = "MasterCard";
            // 
            // rdbVisa
            // 
            this.rdbVisa.AutoSize = true;
            this.rdbVisa.Location = new System.Drawing.Point(20, 46);
            this.rdbVisa.Name = "rdbVisa";
            this.rdbVisa.Size = new System.Drawing.Size(43, 16);
            this.rdbVisa.TabIndex = 1;
            this.rdbVisa.Text = "Visa";
            // 
            // rdbCash
            // 
            this.rdbCash.AutoSize = true;
            this.rdbCash.Checked = true;
            this.rdbCash.Location = new System.Drawing.Point(20, 23);
            this.rdbCash.Name = "rdbCash";
            this.rdbCash.Size = new System.Drawing.Size(46, 16);
            this.rdbCash.TabIndex = 0;
            this.rdbCash.TabStop = true;
            this.rdbCash.Text = "Cash";
            // 
            // btnConfirmOrder
            // 
            this.btnConfirmOrder.BackColor = System.Drawing.Color.Green;
            this.btnConfirmOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfirmOrder.ForeColor = System.Drawing.Color.White;
            this.btnConfirmOrder.Location = new System.Drawing.Point(480, 369);
            this.btnConfirmOrder.Name = "btnConfirmOrder";
            this.btnConfirmOrder.Size = new System.Drawing.Size(232, 37);
            this.btnConfirmOrder.TabIndex = 5;
            this.btnConfirmOrder.Text = "Confirm Order";
            this.btnConfirmOrder.UseVisualStyleBackColor = false;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPrice.Location = new System.Drawing.Point(12, 226);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(60, 24);
            this.lblTotalPrice.TabIndex = 2;
            this.lblTotalPrice.Text = "total: ";
            // 
            // ShoppingCartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 453);
            this.Controls.Add(this.btnConfirmOrder);
            this.Controls.Add(this.grpPayment);
            this.Controls.Add(this.grpCustomerInfo);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.pnlTopMenu);
            this.Name = "ShoppingCartForm";
            this.Text = "Shopping Cart";
            this.Load += new System.EventHandler(this.ShoppingCartForm_Load);
            this.pnlTopMenu.ResumeLayout(false);
            this.pnlTopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.grpCustomerInfo.ResumeLayout(false);
            this.grpCustomerInfo.PerformLayout();
            this.grpPayment.ResumeLayout(false);
            this.grpPayment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Label lblPLFC;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Button btnMail;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.GroupBox grpCustomerInfo;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblOrderDate2;
        private System.Windows.Forms.Label lblDispatchDate;
        private System.Windows.Forms.DateTimePicker dtpDispatchDate;
        private System.Windows.Forms.GroupBox grpPayment;
        private System.Windows.Forms.RadioButton rdbMasterCard;
        private System.Windows.Forms.RadioButton rdbVisa;
        private System.Windows.Forms.RadioButton rdbCash;
        private System.Windows.Forms.Button btnConfirmOrder;
        private System.Windows.Forms.Label lblTotalPrice;
    }
}