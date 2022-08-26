using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoice
{
    public class InvoiceSummery
    {
        public int totalNumberOfRides;
        public double totalFare;
        public double AvgFare;

        public InvoiceSummery(int totalNumberOfRides, double totalFare)
        {
            this.totalNumberOfRides = totalNumberOfRides;
            this.totalFare = totalFare;
            this.AvgFare = this.totalFare/this.totalNumberOfRides;
        }
        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            if(!(obj is InvoiceSummery))
            {
                return false;
            }
            InvoiceSummery invoiceSummery = (InvoiceSummery)obj;
            return this.totalNumberOfRides == invoiceSummery.totalNumberOfRides && this.totalFare == invoiceSummery.totalFare && this.AvgFare == invoiceSummery.AvgFare;
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return this.totalNumberOfRides.GetHashCode() ^ this.totalFare.GetHashCode()^ this.AvgFare.GetHashCode();
        }

    }
}
