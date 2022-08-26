using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoice
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> rideDict = null;
        public RideRepository()
        {
            this.rideDict = new Dictionary<string, List<Ride>>();
        }

        public void AddRides(string userId, Ride[] rides)
        {
            bool check = rideDict.ContainsKey(userId);
            try
            {
                if (!check)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    rideDict.Add(userId, list);
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }
        public Ride[] GetRide(string userId)
        {
            try
            {
                return this.rideDict[userId].ToArray();
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "User iad is Invalid");
            }
        }
    }
}
