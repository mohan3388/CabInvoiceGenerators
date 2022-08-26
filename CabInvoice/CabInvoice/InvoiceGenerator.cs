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

        RideRepository repository = new RideRepository();

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
                else if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MIN_FARE = 20;
                    this.FARE_PER_KM = 15;
                    this.FARE_PER_MIN = 2;
                }
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
        public double CalculateMultipleFare(Ride[] rides)
        {
            double result = 0.0d;
            try
            {
                foreach(var data in rides)
                {
                    result += CalculateFare((int)data.distance, (int)data.time);

                }
            }
            catch(CabInvoiceException)
            {
                if(rides==null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides null");
                }
            }
            return result/rides.Length;
        }
        public InvoiceSummery CalculateMultipleRideSummery(Ride[] ride)
        {
            double result = 0.0d;
            try
            {
                foreach (var data in ride)
                {
                    result += CalculateFare((int)data.distance, (int)data.time);
                }
            }
            catch (CabInvoiceException)
            {
                if (ride == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
                }
            }
            return new InvoiceSummery(ride.Length, result);
        }
        public void MapUserId(string usreId, Ride[] rides)
        {
            this.repository.AddRides(usreId, rides);
        }
        public InvoiceSummery GetRideInvoiceSummary(string userId)
        {
            Ride[] result = this.repository.GetRide(userId);
            return CalculateMultipleRideSummery(result);
        }
    }
}
