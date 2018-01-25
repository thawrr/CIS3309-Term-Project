using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    internal class Media:Product
    {
        private DateTime releaseDate;

        public string ReleaseDate
        {
            get
            {
                return this.releaseDate.ToShortDateString();
            }
            set
            {
                this.releaseDate = DateTime.Parse(value);
            }
        }

        public Media()
        { }

        public Media(string type, string id, string descr, double price, int qty, string rDate)
     : base(type, id, descr, price, qty)
        {
            this.ReleaseDate = rDate;
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + this.ReleaseDate;
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
