using System;
using System.Windows.Forms;

namespace ITP4915M__sales_part__
{
    public partial class OrderPlacedForm : Form
    {
        string orderId;
        string customerId;

        public OrderPlacedForm(string oid, string cid)
        {
            InitializeComponent();
            orderId = oid;
            customerId = cid;
        }

        private void OrderPlacedForm_Load(object sender, EventArgs e)
        {
            
            
            SetupButtons();
        }

        private void SetupButtons()
        {
            btnBack.Click += (s, ev) => NavigateToForm(new MainMenuForm(customerId, "sales"));
            btnNewOrder.Click += (s, ev) => NavigateToForm(new ShoppingCartForm(customerId));
            btnOrderList.Click += (s, ev) => NavigateToForm(new OrderListForm(customerId));
            btnMail.Click += (s, ev) => NavigateToForm(new MailForm(customerId));
            btnLogout.Click += (s, ev) => { this.Close(); Application.OpenForms[0]?.Show(); };
        }

        private void NavigateToForm(Form targetForm)
        {
            targetForm.Show();
            this.Hide();
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }
    
    }
}