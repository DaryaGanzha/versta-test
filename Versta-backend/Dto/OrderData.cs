namespace Versta
{
    public class OrderData
    {
        public int? Number { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddress { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddress { get; set; }
        public double CargoWeight { get; set; }
        public string CargoShippingDate { get; set; }
    }
}
