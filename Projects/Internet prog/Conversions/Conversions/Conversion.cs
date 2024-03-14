using System;
using System.Collections.Generic;
using System.Text;

namespace Conversions
{
    public class Conversion
    {
        public Conversion() { }
        public Conversion(string row)
        {
            var columns = row.Split("|");
            if (columns.Length == 3)
            {
                From = columns[0];
                To = columns[1];
                Multiplier = Convert.ToDecimal(columns[2]);
            }
        }

        //Add your property code here

        public string From {get; set;}
        public string To {get; set;}
        public decimal Multiplier {get; set;}

        public string FullText => From + "|" + To + "|" + Multiplier.ToString();

        public string DisplayConversion(decimal value) {
            decimal result = value * Multiplier;
            return $"{value} {From} = {result:n2} {To}";
        }

        public override string ToString() => From + " to " + To.ToLower();
    }
}
