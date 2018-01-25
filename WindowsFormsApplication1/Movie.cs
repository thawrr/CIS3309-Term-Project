using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    internal class Movie:Entertainment
    {
        public string Director { get; set; }

        public string Producer { get; set; }

        public Movie()
        {
        }

        public Movie(string type, string id, string descr, double price, int qty, string rDate, int size, int numDisks, string typeDisk, string rTime, string director, string producer)
          : base(type, id, descr, price, qty, rDate, size, numDisks, typeDisk, rTime)
        {
            this.Director = director;
            this.Producer = producer;
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + this.Director + sep + this.Producer;
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
