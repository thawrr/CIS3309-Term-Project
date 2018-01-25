using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class ProductsFrm : Form
    {
        //my objects
        private ProductList pl = new ProductList();
        private int idx = -1;
        private IContainer Components = (IContainer)null;
        private Product p;

        public ProductsFrm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ProductsFrm_Load(object sender, EventArgs e)
        {
            this.drawSet(false, false, false, false, false, false, false, false);
            this.previous.Enabled = false;
            this.next.Enabled = false;
            this.write.Enabled = false;
            this.writeBin.Enabled = false;
        }

        public void drawSet(bool b1, bool b2, bool b3, bool b4, bool b5, bool b6, bool b7, bool b8)
        {
            this.label6.Visible = b1;
            this.var1.Visible = b1;

            this.label7.Visible = b2;
            this.var2.Visible = b2;

            this.label8.Visible = b3;
            this.var3.Visible = b3;

            this.label9.Visible = b4;
            this.var4.Visible = b4;

            this.label10.Visible = b5;
            this.var5.Visible = b5;

            this.label11.Visible = b6;
            this.var6.Visible = b6;

            this.label12.Visible = b7;
            this.var7.Visible = b7;

            this.label13.Visible = b8;
            this.var8.Visible = b8;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void write_Click(object sender, EventArgs e)
        {
            this.pl.writeToFile("Output.csv");
        }

        private void read_Click(object sender, EventArgs e)
        {
            this.pl.Clear();
            this.pl.readFromFile("Products.csv");
            this.idx = 0;
            this.drawProduct();
            this.previous.Enabled = false;
            this.next.Enabled = true;
            this.write.Enabled = true;
            this.writeBin.Enabled = true;
        }

        private void previous_Click(object sender, EventArgs e)
        {
            if (this.idx == 1)
            {
                this.idx = this.idx - 1;
                this.p = this.pl.ElementAt<Product>(this.idx);
                this.drawProduct();
                this.previous.Enabled = false;
            }
            else
            {
                this.idx = this.idx - 1;
                this.p = this.pl.ElementAt<Product>(this.idx);
                this.drawProduct();
                this.next.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.idx == this.pl.Count - 2)
            {
                this.idx = this.idx + 1;
                this.p = this.pl.ElementAt<Product>(this.idx);
                this.drawProduct();
                this.next.Enabled = false;
            }
            else
            {
                if (this.idx >= this.pl.Count - 2)
                    return;
                this.idx = this.idx + 1;
                this.p = this.pl.ElementAt<Product>(this.idx);
                this.drawProduct();
                this.previous.Enabled = true;
            }
        }

        private void readBin_Click(object sender, EventArgs e)
        {
            this.pl.Clear();
            this.pl.readFromBinary("Products.bin");
            this.idx = 0;
            this.drawProduct();
            this.previous.Enabled = false;
            this.next.Enabled = true;
            this.write.Enabled = true;
            this.writeBin.Enabled = true;
        }

     

        private void writeBin_Click(object sender, EventArgs e)
        {
            this.pl.writeToFile("Output.csv");
        }

        public void drawProduct()
        {
            if (this.idx < 0 || this.idx >= this.pl.Count)
                return;
            this.p = this.pl.ElementAt<Product>(this.idx);
            this.type.Text = this.p.Type;
            this.id.Text = this.p.ID;
            this.describ.Text = this.p.Desc;
            this.price.Text = this.p.Price.ToString("C");
            this.quant.Text = this.p.Qty.ToString();
            if (this.p.Type == "Book")
                this.drawBook();
            else if (this.p.Type == "Software")
                this.drawSoftware();
            else if (this.p.Type == "Music")
                this.drawMusic();
            else if (this.p.Type == "Movie")
                this.drawMovie();
            else if (this.p.Type == "Pants")
                this.drawPants();
            else if (this.p.Type == "TShirt")
                this.drawTShirt();
            else if (this.p.Type == "DressShirt")
            {
                this.drawDressShirt();
            }
            else
            {
                int num = (int)MessageBox.Show("Not found.");
            }
        }

        public void drawMedia()
        {
            Media p = (Media)this.p;
            this.label6.Text = "Release Date";
            this.var1.Text = p.ReleaseDate;
        }

        public void drawApparel()
        {
            Apparel p = (Apparel)this.p;
            this.label6.Text = "Color";
            this.var1.Text = p.Color;
            this.label7.Text = "Manufacturer";
            this.var2.Text = p.Manufacture;
            this.label8.Text = "Material";
            this.var3.Text = p.Material;
        }

        public void drawDisk()
        {
            Disk p = (Disk)this.p;
            this.drawMedia();
            this.label7.Text = "Number of Disks";
            this.var2.Text = p.NumDisks.ToString();
            this.label8.Text = "Data Size";
            this.var3.Text = p.Size.ToString();
            this.label9.Text = "Type Disk";
            this.var4.Text = p.TypeDisk;
        }

        public void drawEntertainment()
        {
            Entertainment p = (Entertainment)this.p;
            this.drawDisk();
            this.label10.Text = "Runtime";
            this.var5.Text = p.RunTime;
        }

        public void drawBook()
        {
            Book p = (Book)this.p;
            this.drawSet(true, true, true, true, false, false, false, false);
            this.drawMedia();
            this.label7.Text = "Author";
            this.var2.Text = p.Author;
            this.label8.Text = "Pages";
            this.var3.Text = p.NumPages.ToString();
            this.label9.Text = "Publisher";
            this.var4.Text = p.Publisher;
        }

        public void drawSoftware()
        {
            Software p = (Software)this.p;
            this.drawSet(true, true, true, true, true, false, false, false);
            this.drawDisk();
            this.label10.Text = "Type Software";
            this.var5.Text = p.TypeSoft;
        }

        public void drawMusic()
        {
            Music p = (Music)this.p;
            this.drawSet(true, true, true, true, true, true, true, true);
            this.drawEntertainment();
            this.label11.Text = "Artist";
            this.var6.Text = p.Artist;
            this.label12.Text = "Label";
            this.var7.Text = p.Label;
            this.label13.Text = "Genre";
            this.var8.Text = p.Genre;
        }

        public void drawMovie()
        {
            Movie p = (Movie)this.p;
            this.drawSet(true, true, true, true, true, true, true, false);
            this.drawEntertainment();
            this.label11.Text = "Director";
            this.var6.Text = p.Director;
            this.label12.Text = "Producer";
            this.var7.Text = p.Producer;
        }

        public void drawPants()
        {
            Pants p = (Pants)this.p;
            this.drawSet(true, true, true, true, true, false, false, false);
            this.drawApparel();
            this.label9.Text = "Waist";
            this.var4.Text = p.Waist.ToString();
            this.label10.Text = "Inseam";
            this.var5.Text = p.Length.ToString();
        }

        public void drawDressShirt()
        {
            DressShirt p = (DressShirt)this.p;
            this.drawSet(true, true, true, true, true, false, false, false);
            this.drawApparel();
            this.label9.Text = "Neck";
            this.var4.Text = p.Neck.ToString();
            this.label10.Text = "Sleeve";
            this.var5.Text = p.Sleeve.ToString();
        }

        public void drawTShirt()
        {
            TShirt p = (TShirt)this.p;
            this.drawSet(true, true, true, true, false, false, false, false);
            this.drawApparel();
            this.label9.Text = "Size";
            this.var4.Text = p.Size.ToString();
        }

    }//end form class
}//end nameSpace
