namespace TestTask.DepthQuotesSystem.Messages
{
    public record Quote
    {
        public string Symbol { get; set; }

        public decimal Price { get; set; }

        public decimal Quantaty { get; set; }
    }
}