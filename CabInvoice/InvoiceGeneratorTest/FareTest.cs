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
    }
}