using CabInvoice;

namespace InvoiceGeneratorTest
{
    [TestClass]
    public class FareTest
    {
        [TestMethod]
        public void InputInInteger_ShouldReturn_TotalFair()

        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double result = invoiceGenerator.CalculateFare(15, 5);
            Assert.AreEqual(result, 155);
        }
        [TestMethod]
        public void InputInInteger_ShouldReturn_MultipleRides_TotalFair()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2, 3), new Ride(4, 7), new Ride(6, 2) };
            double result= invoiceGenerator.CalculateMultipleFare(rides);
            Assert.AreEqual(result, 68);
        }
        [TestMethod]
       
        public void InputInInteger_ShouldReturn_MultipleRides_TotalFair_InvoiceSummary()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides1 = { new Ride(15, 10), new Ride(35, 35), new Ride(25, 15) };
            InvoiceSummery result = invoiceGenerator.CalculateMultipleRideSummery(rides1);
            Assert.AreEqual(result.totalNumberOfRides, 3);
        }
        [TestMethod]
        public void InputInString_GivenUserId_ShouldReturn_MultipleRides_TotalFair_InvoiceSummary()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL);
            Ride[] ride = { new Ride(15, 10), new Ride(35, 35), new Ride(25, 15), new Ride(15, 15), new Ride(50, 60) };
            string userId = "2001abc";
            invoice.MapUserId(userId, ride);
            InvoiceSummery expectedInvoice = invoice.GetRideInvoiceSummary("2001abc");
            Assert.AreEqual(5, expectedInvoice.totalNumberOfRides);
        }
        [TestMethod]
        public void InputInInteger_ShouldReturn_MultipleRides_TotalFair_InvoiceSummary_ForPremiumRides()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] preRides = { new Ride(15, 10), new Ride(35, 35), new Ride(25, 15), new Ride(15, 15), new Ride(50, 60) };
            InvoiceSummery result = invoice.CalculateMultipleRideSummery(preRides);
            Assert.AreEqual(result.totalNumberOfRides, preRides.Length);
        }
    }
}