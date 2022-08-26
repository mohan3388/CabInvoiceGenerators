using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoice
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private readonly int MIN_FARE;
        private readonly int FARE_PER_KM;
        private readonly int FARE_PER_MIN;

        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            try
            {
                if(rideType.Equals(RideType.NORMAL))
                {
                    this.MIN_FARE = 5;
                    this.FARE_PER_KM = 10;
                    this.FARE_PER_MIN = 1;
                }
                //else if(rideType.Equals(RideType.PREMIUM)){
                //    this.MIN_FARE = 20;
                //    this.FARE_PER_KM = 15;
                //    this.FARE_PER_MIN = 2;
                //}
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride");
            }
        }
        public double CalculateFare(int distance, int time)
        {
            double Fair = 0.0d;
            try
            {
                Fair=FARE_PER_KM*distance+time*FARE_PER_MIN;
            }
            catch(CabInvoiceException)
            {
                if(rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Rice");
                }
                if(distance==0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                }
                if(time<0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(Fair,MIN_FARE);
        }
    }
}
