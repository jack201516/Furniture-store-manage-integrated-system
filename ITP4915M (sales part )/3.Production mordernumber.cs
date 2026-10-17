using System;
using System.Windows.Forms;

namespace ITP4915M__sales_part__
{
    public partial class Form5 : Form
    {
        string currentUser;

        public Form5(string userId)
        {
            InitializeComponent();
            currentUser = userId;
        }


  

        private string GenerateRequestId()
        {
            return "R" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}