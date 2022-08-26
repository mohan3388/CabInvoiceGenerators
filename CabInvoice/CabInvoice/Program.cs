namespace CabInvoice
{
    class Program
    {
        public static void Main(string[] args)
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double Result = invoiceGenerator.CalculateFare(15, 5);
            Console.WriteLine(Result);
        }
    }
}