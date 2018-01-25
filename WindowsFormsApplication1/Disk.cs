using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    internal class Disk:Media
    {
        public int Size { get; set; }

        public int NumDisks { get; set; }

        public string TypeDisk { get; set; }

        public Disk()
        {
        }

        public Disk(string type, string id, string descr, double price, int qty, string rDate, int size, int numDisks, string typeDisk)
          : base(type, id, descr, price, qty, rDate)
        {
            this.Size = size;
            this.NumDisks = numDisks;
            this.TypeDisk = typeDisk;
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + (object)this.Size + sep + (object)this.NumDisks + sep + this.TypeDisk;
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
