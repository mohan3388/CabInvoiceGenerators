namespace CabInvoice
{
    class Program
    {
        public static void Main(string[] args)
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            //double Result = invoiceGenerator.CalculateFare(15, 5);
            //Console.WriteLine(Result);

            Ride[] rides = { new Ride(2, 3), new Ride(4, 7), new Ride(6, 2) };
            double result = invoiceGenerator.CalculateMultipleFare(rides);
            Console.WriteLine(result);
        }
    }
}