using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    internal class Pants:Apparel
    {
        public double Waist { get; set; }
        public double Length { get; set; }

        public Pants()
        {
        }

        public Pants(string type, string id, string descr, double price, int qty, string material, string color, string manufacturer, int waist, int length)
      : base(type, id, descr, price, qty, material, color, manufacturer)
        {
            this.Waist = waist;
            this.Length = length;
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + (object)this.Waist + sep + (object)this.Length;
        }

        public override string ToString()
        {
            return this.getDisplayText("\r\n");
        }

        public override string ToCSV()
        {
            return this.getDisplayText(",");
        }

    }//end pants
}//end form
