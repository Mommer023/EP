using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Conversions
{
    public partial class frmAddConversion : Form
    {
        public frmAddConversion()
        {
            InitializeComponent();
        }

        public Conversion Conversion { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Add your code here
        }

        private bool IsValidData()
        {
            //Delete the return statement below and add your code here.
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
