using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    internal class TShirt:Apparel
    {
        public string Size { get; set; }

        public TShirt()
        {
        }

        public TShirt(string type, string id, string descr, double price, int qty, string material, string color, string manufacturer, string size)
            :base(type, id, descr, price, qty, material, color, manufacturer)
        {
            this.Size = size;
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + (object) this.Size;
        }

        public override string ToString()
        {
            return base.getDisplayText("\r\n");
        }

        public override string ToCSV()
        {
            return this.getDisplayText(",");
        }
    }//end TShirt class
}//end nameSpace
