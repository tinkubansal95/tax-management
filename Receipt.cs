using System.Collections.Generic;
using System.Text;

namespace CouncilWise
{
    internal class Receipt
    {
        public ICollection<ReceiptItem> Items { get; set; }
        public decimal Total { get; set; }
        public decimal TaxTotal { get; set; }
        public override string ToString()
        {
            string itemDetails = "";
            foreach (ReceiptItem item in Items)
            {
                itemDetails = itemDetails + item.Name + @"
		    Quantity: " + item.Quantity+ @"		UnitPrice inc. Tax: " +	item.UnitPrice+@"    Total inc. Tax: "+ item.Total+@"
            ";
            }
                return @"Receipt:
	    Items:
	    "+itemDetails+@"
	   
    Total:	"+Total+@"
    GST:	"+TaxTotal+@"
    ";
        }
    }
}
