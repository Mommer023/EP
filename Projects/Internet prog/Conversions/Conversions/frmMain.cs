using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conversions
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private List<Conversion> conversions;

        private void frmConversions_Load(object sender, EventArgs e)
        {
            LoadConversions();
        }

        private void LoadConversions(List<Conversion> list = null)
        {
            lstConversions.Items.Clear();

            if (list == null)
                conversions = ConversionDB.GetConversions();
            else
                conversions = list;

            foreach (var conversion in conversions)
                lstConversions.Items.Add(conversion);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                lstResults.Items.Clear();

                var value = Convert.ToDecimal(txtValueToConvert.Text);
                var selected = lstConversions.SelectedItems;

                foreach (var item in selected)
                {
                    Conversion conversion = (Conversion)item;
                    lstResults.Items.Add(conversion.DisplayConversion(value));
                }
            } 
        }

        private bool IsValidData()
        {
            return
                Validator.IsPresent(txtValueToConvert) &&
                Validator.IsDecimal(txtValueToConvert) &&
                Validator.IsSelected(lstConversions);
        }

        private void btnManageConversions_Click(object sender, EventArgs e)
        {
            var manageForm = new frmManageConversions();
            DialogResult result = manageForm.ShowDialog();

            if (result == DialogResult.OK)
                LoadConversions(manageForm.Conversions);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtValueToConvert.Text = "";
            lstConversions.SelectedIndex = -1;
            lstResults.Items.Clear();
            txtValueToConvert.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
