using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    internal class ProductList: List <Product>
    {
        public void Add(string[] recs)
        {
            if (recs[0] == "Book")
                this.Add((Product)new Book(recs[0], recs[1], recs[2], double.Parse(recs[3]), int.Parse(recs[4]), recs[5], int.Parse(recs[6]), recs[7], recs[8]));
            else if (recs[0] == "DressShirt")
                this.Add((Product)new DressShirt(recs[0], recs[1], recs[2], double.Parse(recs[3]), int.Parse(recs[4]), recs[5], recs[6], recs[7], (double)int.Parse(recs[8]), int.Parse(recs[9])));
            else if (recs[0] == "Movie")
                this.Add((Product)new Movie(recs[0], recs[1], recs[2], double.Parse(recs[3]), int.Parse(recs[4]), recs[5], int.Parse(recs[6]), int.Parse(recs[7]), recs[8], recs[9], recs[10], recs[11]));
            else if (recs[0] == "Music")
                this.Add((Product)new Music(recs[0], recs[1], recs[2], double.Parse(recs[3]), int.Parse(recs[4]), recs[5], int.Parse(recs[6]), int.Parse(recs[7]), recs[8], recs[9], recs[10], recs[11], recs[12]));
            else if (recs[0] == "Pants")
                this.Add((Product)new Pants(recs[0], recs[1], recs[2], double.Parse(recs[3]), int.Parse(recs[4]), recs[5], recs[6], recs[7], int.Parse(recs[8]), int.Parse(recs[9])));
            else if (recs[0] == "Software")
                this.Add((Product)new Software(recs[0], recs[1], recs[2], double.Parse(recs[3]), int.Parse(recs[4]), recs[5], int.Parse(recs[6]), int.Parse(recs[7]), recs[8], recs[9]));
            else if (recs[0] == "TShirt")
            {
                this.Add((Product)new TShirt(recs[0], recs[1], recs[2], double.Parse(recs[3]), int.Parse(recs[4]), recs[5], recs[6], recs[7], recs[8]));
            }
            else
            {
                int num = (int)MessageBox.Show("Unknown type");
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (Product product in (List<Product>)this)
                str = str + product.ToString() + "\r\n\r\n";
            return str;
        }

        public string ToCSV()
        {
            string str = "";
            foreach (Product product in (List<Product>)this)
                str = str + product.ToCSV() + "\r\n";
            return str;
        }

        public int readFromFile(string fileName)
        {
            int num = 0;
            StreamReader streamReader = new StreamReader(fileName);
            string str;
            while ((str = streamReader.ReadLine()) != null)
            {
                this.Add(str.Split(','));
                ++num;
            }
            streamReader.Close();
            return num;
        }

        public int writeToFile(string fileName)
        {
            int num = 0;
            StreamWriter streamWriter = new StreamWriter(fileName);
            foreach (Product product in (List<Product>)this)
            {
                streamWriter.WriteLine(product.ToCSV());
                ++num;
            }
            streamWriter.Close();
            return num;
        }

        public int writeToBinary(string fileName)
        {
            int num = 0;
            BinaryWriter binaryWriter = new BinaryWriter((Stream)new FileStream(fileName, FileMode.Create, FileAccess.Write));
            foreach (Product product in (List<Product>)this)
            {
                binaryWriter.Write(product.ToCSV());
                ++num;
            }
            binaryWriter.Close();
            return num;
        }

        public int readFromBinary(string fileName)
        {
            int num = 0;
            BinaryReader binaryReader = new BinaryReader((Stream)new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read));
            while (binaryReader.PeekChar() != -1)
            {
                this.Add(binaryReader.ReadString().Split(','));
                ++num;
            }
            binaryReader.Close();
            return num;
        }
    }
}
