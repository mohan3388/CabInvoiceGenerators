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
    }
}