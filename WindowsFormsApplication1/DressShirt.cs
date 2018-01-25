using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    internal class DressShirt : Apparel
    {
        public double Neck { get; set; }
        public double Sleeve { get; set; }

        public DressShirt()
        {
        }

        public DressShirt(string type, string id, string descr, double price, int qty, string material, string color, string manufacturer, double neck, double sleeve)
            :base(type, id, descr, price, qty, material, color, manufacturer)
        {
            this.Neck = neck;
            this.Sleeve = sleeve;
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + (object)this.Neck + (object)this.Sleeve;
        }

        public override string ToString()
        {
            return base.getDisplayText("\r\n");
        }

        public override string ToCSV()
        {
            return this.getDisplayText(",");
        }
    }//end DressShirt class
}//end nameSpace
