namespace ITP4915M__sales_part__
{
    partial class ProductDetailForm
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
            this.lblPriceLabel = new System.Windows.Forms.Label();
            this.lblQuantityLabel = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblCustomMadeLabel = new System.Windows.Forms.Label();
            this.txtCustomRequire = new System.Windows.Forms.TextBox();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pnlTopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.pnlTopMenu.Size = new System.Drawing.Size(500, 55);
            this.pnlTopMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(410, 9);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(70, 37);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnMail
            // 
            this.btnMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMail.ForeColor = System.Drawing.Color.White;
            this.btnMail.Location = new System.Drawing.Point(320, 9);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(80, 37);
            this.btnMail.TabIndex = 3;
            this.btnMail.Text = "Complaint";
            this.btnMail.UseVisualStyleBackColor = true;
            // 
            // btnOrderList
            // 
            this.btnOrderList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderList.ForeColor = System.Drawing.Color.White;
            this.btnOrderList.Location = new System.Drawing.Point(220, 9);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(90, 37);
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
            this.btnNewOrder.Size = new System.Drawing.Size(90, 37);
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
            // lblPriceLabel
            // 
            this.lblPriceLabel.AutoSize = true;
            this.lblPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPriceLabel.ForeColor = System.Drawing.Color.Black;
            this.lblPriceLabel.Location = new System.Drawing.Point(50, 120);
            this.lblPriceLabel.Name = "lblPriceLabel";
            this.lblPriceLabel.Size = new System.Drawing.Size(47, 20);
            this.lblPriceLabel.TabIndex = 2;
            this.lblPriceLabel.Text = "price:";
            // 
            // lblQuantityLabel
            // 
            this.lblQuantityLabel.AutoSize = true;
            this.lblQuantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblQuantityLabel.ForeColor = System.Drawing.Color.Black;
            this.lblQuantityLabel.Location = new System.Drawing.Point(50, 157);
            this.lblQuantityLabel.Name = "lblQuantityLabel";
            this.lblQuantityLabel.Size = new System.Drawing.Size(72, 20);
            this.lblQuantityLabel.TabIndex = 4;
            this.lblQuantityLabel.Text = "Quantity:";
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numQuantity.Location = new System.Drawing.Point(130, 155);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(80, 26);
            this.numQuantity.TabIndex = 5;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCustomMadeLabel
            // 
            this.lblCustomMadeLabel.AutoSize = true;
            this.lblCustomMadeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCustomMadeLabel.ForeColor = System.Drawing.Color.Black;
            this.lblCustomMadeLabel.Location = new System.Drawing.Point(50, 194);
            this.lblCustomMadeLabel.Name = "lblCustomMadeLabel";
            this.lblCustomMadeLabel.Size = new System.Drawing.Size(47, 20);
            this.lblCustomMadeLabel.TabIndex = 6;
            this.lblCustomMadeLabel.Text = "Note:";
            // 
            // txtCustomRequire
            // 
            this.txtCustomRequire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCustomRequire.Location = new System.Drawing.Point(54, 222);
            this.txtCustomRequire.Multiline = true;
            this.txtCustomRequire.Name = "txtCustomRequire";
            this.txtCustomRequire.Size = new System.Drawing.Size(390, 74);
            this.txtCustomRequire.TabIndex = 7;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.Black;
            this.lblTotalLabel.Location = new System.Drawing.Point(258, 332);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(107, 24);
            this.lblTotalLabel.TabIndex = 8;
            this.lblTotalLabel.Text = "total price:";
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.Green;
            this.btnAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(328, 360);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(150, 37);
            this.btnAddToCart.TabIndex = 10;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(295, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 116);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 122);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(54, 83);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(156, 22);
            this.textBox2.TabIndex = 13;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(378, 337);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 14;
            // 
            // ProductDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 426);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.lblTotalLabel);
            this.Controls.Add(this.txtCustomRequire);
            this.Controls.Add(this.lblCustomMadeLabel);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantityLabel);
            this.Controls.Add(this.lblPriceLabel);
            this.Controls.Add(this.pnlTopMenu);
            this.Name = "ProductDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Details";
            this.Load += new System.EventHandler(this.ProductDetailForm_Load);
            this.pnlTopMenu.ResumeLayout(false);
            this.pnlTopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Label lblPLFC;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Button btnMail;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblPriceLabel;
        private System.Windows.Forms.Label lblQuantityLabel;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblCustomMadeLabel;
        private System.Windows.Forms.TextBox txtCustomRequire;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}