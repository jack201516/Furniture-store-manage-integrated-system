namespace ITP4915M__sales_part__
{
    partial class MainMenuForm
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
            this.grpCategory = new System.Windows.Forms.GroupBox();
            this.btnOthers = new System.Windows.Forms.Button();
            this.btnBathroom = new System.Windows.Forms.Button();
            this.btnKitchen = new System.Windows.Forms.Button();
            this.btnBeds = new System.Windows.Forms.Button();
            this.btnSofas = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.btnChair = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnShoppingCart = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.pnlTopMenu.SuspendLayout();
            this.grpCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
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
            this.pnlTopMenu.Size = new System.Drawing.Size(984, 55);
            this.pnlTopMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(872, 9);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 37);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnMail
            // 
            this.btnMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMail.ForeColor = System.Drawing.Color.White;
            this.btnMail.Location = new System.Drawing.Point(494, 9);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(100, 37);
            this.btnMail.TabIndex = 3;
            this.btnMail.Text = "Complaint";
            this.btnMail.UseVisualStyleBackColor = true;
            // 
            // btnOrderList
            // 
            this.btnOrderList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderList.ForeColor = System.Drawing.Color.White;
            this.btnOrderList.Location = new System.Drawing.Point(330, 9);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(100, 37);
            this.btnOrderList.TabIndex = 2;
            this.btnOrderList.Text = "Order List";
            this.btnOrderList.UseVisualStyleBackColor = true;
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewOrder.ForeColor = System.Drawing.Color.White;
            this.btnNewOrder.Location = new System.Drawing.Point(173, 9);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(100, 37);
            this.btnNewOrder.TabIndex = 1;
            this.btnNewOrder.Text = "New order";
            this.btnNewOrder.UseVisualStyleBackColor = true;
          
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
            // grpCategory
            // 
            this.grpCategory.Controls.Add(this.btnOthers);
            this.grpCategory.Controls.Add(this.btnBathroom);
            this.grpCategory.Controls.Add(this.btnKitchen);
            this.grpCategory.Controls.Add(this.btnBeds);
            this.grpCategory.Controls.Add(this.btnSofas);
            this.grpCategory.Controls.Add(this.btnTable);
            this.grpCategory.Controls.Add(this.btnChair);
            this.grpCategory.Location = new System.Drawing.Point(12, 74);
            this.grpCategory.Name = "grpCategory";
            this.grpCategory.Size = new System.Drawing.Size(200, 323);
            this.grpCategory.TabIndex = 1;
            this.grpCategory.TabStop = false;
            this.grpCategory.Text = "Categories";
            // 
            // btnOthers
            // 
            this.btnOthers.Location = new System.Drawing.Point(20, 277);
            this.btnOthers.Name = "btnOthers";
            this.btnOthers.Size = new System.Drawing.Size(160, 32);
            this.btnOthers.TabIndex = 6;
            this.btnOthers.Text = "others";
            // 
            // btnBathroom
            // 
            this.btnBathroom.Location = new System.Drawing.Point(20, 235);
            this.btnBathroom.Name = "btnBathroom";
            this.btnBathroom.Size = new System.Drawing.Size(160, 32);
            this.btnBathroom.TabIndex = 5;
            this.btnBathroom.Text = "bathroom furniture";
            // 
            // btnKitchen
            // 
            this.btnKitchen.Location = new System.Drawing.Point(20, 194);
            this.btnKitchen.Name = "btnKitchen";
            this.btnKitchen.Size = new System.Drawing.Size(160, 32);
            this.btnKitchen.TabIndex = 4;
            this.btnKitchen.Text = "Kitchen furniture";
            // 
            // btnBeds
            // 
            this.btnBeds.Location = new System.Drawing.Point(20, 152);
            this.btnBeds.Name = "btnBeds";
            this.btnBeds.Size = new System.Drawing.Size(160, 32);
            this.btnBeds.TabIndex = 3;
            this.btnBeds.Text = "Beds";
            // 
            // btnSofas
            // 
            this.btnSofas.Location = new System.Drawing.Point(20, 111);
            this.btnSofas.Name = "btnSofas";
            this.btnSofas.Size = new System.Drawing.Size(160, 32);
            this.btnSofas.TabIndex = 2;
            this.btnSofas.Text = "Sofas";
            // 
            // btnTable
            // 
            this.btnTable.Location = new System.Drawing.Point(20, 69);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(160, 32);
            this.btnTable.TabIndex = 1;
            this.btnTable.Text = "Table";
            // 
            // btnChair
            // 
            this.btnChair.Location = new System.Drawing.Point(20, 28);
            this.btnChair.Name = "btnChair";
            this.btnChair.Size = new System.Drawing.Size(160, 32);
            this.btnChair.TabIndex = 0;
            this.btnChair.Text = "Chair";
            this.btnChair.UseVisualStyleBackColor = true;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(230, 74);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(742, 352);
            this.dgvProducts.TabIndex = 2;
            // 
            // btnShoppingCart
            // 
            this.btnShoppingCart.BackColor = System.Drawing.Color.Orange;
            this.btnShoppingCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnShoppingCart.Location = new System.Drawing.Point(12, 413);
            this.btnShoppingCart.Name = "btnShoppingCart";
            this.btnShoppingCart.Size = new System.Drawing.Size(200, 46);
            this.btnShoppingCart.TabIndex = 3;
            this.btnShoppingCart.Text = "Shopping cart";
            this.btnShoppingCart.UseVisualStyleBackColor = false;
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(837, 441);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(120, 28);
            this.btnViewDetail.TabIndex = 14;
            this.btnViewDetail.Text = "View Details";
            this.btnViewDetail.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 480);
            this.Controls.Add(this.btnViewDetail);
            this.Controls.Add(this.btnShoppingCart);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.grpCategory);
            this.Controls.Add(this.pnlTopMenu);
            this.Name = "MainMenuForm";
            this.Text = "Main Menu";
            this.pnlTopMenu.ResumeLayout(false);
            this.pnlTopMenu.PerformLayout();
            this.grpCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Label lblPLFC;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Button btnMail;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.GroupBox grpCategory;
        private System.Windows.Forms.Button btnChair;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Button btnSofas;
        private System.Windows.Forms.Button btnBeds;
        private System.Windows.Forms.Button btnKitchen;
        private System.Windows.Forms.Button btnBathroom;
        private System.Windows.Forms.Button btnOthers;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnShoppingCart;
        private System.Windows.Forms.Button btnViewDetail;
    }
}