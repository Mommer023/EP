using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Conversions
{
    public static class Validator
    {
        public static string Title { get; set; } = "Entry Error";

        public static bool IsPresent(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                NotifyUser(textBox, $"{textBox.Tag} is a required field.");
                return false;
            }
            return true;
        }

        public static bool IsSelected(ListBox listBox)
        {
            if (listBox.SelectedItems.Count == 0)
            {
                NotifyUser(listBox, $"{listBox.Tag} must have at least one item selected.");
                return false;
            }
            return true;
        }

        public static bool IsDecimal(TextBox textBox)
        {
            if (Decimal.TryParse(textBox.Text, out decimal number))
            {
                return true;
            }
            else
            {
                NotifyUser(textBox, $"{textBox.Tag} must be a decimal value.");
                return false;
            }
        }

        public static bool IsInt32(TextBox textBox)
        {
            if (Int32.TryParse(textBox.Text, out int number))
            {
                return true;
            }
            else
            {
                NotifyUser(textBox, $"{textBox.Tag} must be an integer.");
                return false;
            }
        }

        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                NotifyUser(textBox, $"{textBox.Tag} must be between {min} and {max}");
                return false;
            }
            return true;
        }

        public static void NotifyUser(TextBox textBox, string message)
        {
            MessageBox.Show(message, Title);
            textBox.Focus();
        }

        public static void NotifyUser(ListBox listBox, string message)
        {
            MessageBox.Show(message, Title);
            listBox.Focus();
        }
    }
}
