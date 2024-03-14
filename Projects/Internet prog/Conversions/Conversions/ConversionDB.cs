using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Conversions
{
    public static class ConversionDB
    {
        private const string dir = @"C:\C#\Files\";
        private const string path = dir + "Conversions.txt";
        private const string defaultPath = dir + "ConversionsDefault.txt";

        public static List<Conversion> GetConversions()
        {
            // if the directory doesn't exist, create it
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            // create the object for the input stream for a text file
            StreamReader textIn =
                new StreamReader(
                new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

            // create the conversions list
            List<Conversion> conversions = new List<Conversion>();

            // read the data from the file and store it in the list
            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                Conversion conversion = new Conversion(row);
                conversions.Add(conversion);
            }

            // close the input stream for the text file
            textIn.Close();

            return conversions;
        }

        public static List<Conversion> GetDefaultConversions()
        {
            // if the directory doesn't exist, create it
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            // create the object for the input stream for a text file
            StreamReader textIn =
                new StreamReader(
                new FileStream(defaultPath, FileMode.OpenOrCreate, FileAccess.Read));

            // create the conversions list
            List<Conversion> conversions = new List<Conversion>();

            // read the data from the file and store it in the ArrayList
            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                Conversion conversion = new Conversion(row);
                conversions.Add(conversion);
            }

            // close the input stream for the text file
            textIn.Close();

            return conversions;
        }

        public static void SaveConversions(List<Conversion> conversions)
        {
            // create the output stream for a text file that exists
            StreamWriter textOut =
                new StreamWriter(
                new FileStream(path, FileMode.Create, FileAccess.Write));

            // write each item
            foreach (Conversion conversion in conversions)
                textOut.WriteLine(conversion.FullText);
                //textOut.WriteLine(conversion.From + "|" +
                //                  conversion.To + "|" +
                //                  conversion.Multiplier.ToString());

            // close the output stream for the text file
            textOut.Close();
        }
    }
}
