using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Conversions
{
    public partial class frmManageConversions : Form
    {
        public frmManageConversions()
        {
            InitializeComponent();
        }

        public List<Conversion> Conversions { get; set; }

        private void frmManageConversions_Load(object sender, EventArgs e)
        {
            LoadConversions();
        }

        private void LoadConversions()
        {
            lstConversions.Items.Clear();

            Conversions = ConversionDB.GetConversions();
            foreach (var conversion in Conversions)
                lstConversions.Items.Add(conversion.FullText);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index = lstConversions.SelectedIndex;
            lstConversions.Items.RemoveAt(index);
            Conversions.RemoveAt(index);

            ConversionDB.SaveConversions(Conversions);
            LoadConversions();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new frmAddConversion();
            DialogResult result = addForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                Conversions.Add(addForm.Conversion);

                ConversionDB.SaveConversions(Conversions);
                LoadConversions();
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            Conversions = ConversionDB.GetDefaultConversions();

            ConversionDB.SaveConversions(Conversions);
            LoadConversions();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
