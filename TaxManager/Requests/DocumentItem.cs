namespace TaxManager.Requests
{
    public class DocumentItem
    {
        public string ItemName { get; set; }

        internal int ItemCodeType { get; set; }

        public string ItemCode { get; set; }

        public decimal ItemQuantity { get; set; }

        public decimal ItemPrice { get; set; }

        public decimal ItemSum { get; set; }

        public decimal ItemVatPercent { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public decimal? ItemMarginSum { get; set; }

        /// <summary>
        /// Optional field
        /// </summary>
        public decimal? ItemMarginPrice { get; set; }

    }


}
