using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Entertainment:Disk
    {
        private TimeSpan runTime;
        
        public string RunTime
        {
            get
            {
                return this.runTime.Hours.ToString() + ":" + this.runTime.Minutes.ToString() + ":" + this.runTime.Seconds.ToString();
            }
            set
            {
                string[] strArray = value.Split(':');
                this.runTime = new TimeSpan(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]));
            }
        }  

        public Entertainment()
        { }

        public Entertainment(string type, string id, string descr, double price, int qty, string rDate, int size, int numDisks, string typeDisk, string rTime)
      : base(type, id, descr, price, qty, rDate, size, numDisks, typeDisk)
        {
            this.RunTime = rTime;
        }

        public override string getDisplayText(string sep)
        {
            return base.getDisplayText(sep) + sep + (object)this.runTime.Hours + ":" + (object)this.runTime.Minutes + ":" + (object)this.runTime.Seconds;
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
