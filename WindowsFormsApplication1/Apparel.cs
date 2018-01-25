using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    internal class Apparel : Product
    {
        public String Material { get; set; }
        public String Color { get; set; }
        public String Manufacture { get; set; }

        public Apparel()
        { }

        public Apparel(string type, string id, string descr, double price, int quant, string material, string color, string manufacture)
        {
            this.Material = material;
            this.Color = color;
            this.Manufacture = manufacture;
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + this.Material + sep + this.Color + sep + this.Manufacture;
        }

        public override string ToString()
        {
            return this.getDisplayText("\r\n");
        }

        public override string ToCSV()
        {
            return this.getDisplayText(",");
        }

    }
}
