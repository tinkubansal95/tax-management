using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CouncilWise
{
    /*	
   
    Requirements:

    - Given a list of receipt items where TaxAmount is not populated, calculate the correct tax for each receipt item. If IncludesGST is true, the unit price contains tax already. (In this case you will need to divide by 11 to get the tax amount). 
        If includesGST is false, the unit price does not contain tax and you will need to calculate it (multiply by 0.1 for tax amount). 
    - Return a populated Receipt object which contains the receipt items including tax amounts with the correct totals.
        Note that all totals shown on the receipt should be tax inclusive, including the receipt item totals.
    - For bonus points, if the receipt item name is a palindrome, the receipt item unit price should be changed to free. 
        A palindrome is a string which reads the same way forwards and backwards
    - You may modify the Receipt ReceiptItem and Helper classes any way you like as well as add new classes, but you must call the ProcessReceiptItems() method and the Receipt.ToString() method in your test case and no other methods.
    - 
    - Add additional test cases to cover any edge cases you can think of

    Expected Output:

    Print a receipt to the console with the following format:

    Receipt:
	    Items:
	    <Name>
		    <Quantity>		<UnitPrice>		<Total inc. Tax>
	    <Name>			
		    <Quantity>		<UnitPrice>		<Total inc. Tax>
	    ... for all receipt items
    Total:	<Total inc. Tax>
    GST:	<TaxTotal>

    */
    class Program
    {
        static void Main(string[] args)
        {
            RunTestCases();
        }

        /// <summary>
        /// Run through some possible scenarios for processing receipt items
        /// </summary>
        static void RunTestCases()
        {
            var items = new List<ReceiptItem>();
            items.Add(new ReceiptItem { Name = "Bouncy Ball", Quantity = 4, UnitPrice = 1.15m, IncludesTax = true });
            items.Add(new ReceiptItem { Name = "Doll's House", Quantity = 1, UnitPrice = 213.99m, IncludesTax = true });
            items.Add(new ReceiptItem { Name = "In-store assist hrs", Quantity = 2, UnitPrice = 25.30m, IncludesTax = false });
            var receiptResult = ProcessReceiptItems(items);
            Console.WriteLine(receiptResult.ToString());
          

            items = new List<ReceiptItem>();
            items.Add(new ReceiptItem { Name = "freebie eibeerf", Quantity = 4, UnitPrice = 1.15m, IncludesTax = true });
            receiptResult = ProcessReceiptItems(items);
            Console.WriteLine(receiptResult.ToString());

            // TODO: Add more test cases here to capture any edge cases you can think of 
        }

        /// <summary>
        /// Process a list of receipt items to ensure correct tax is allocated
        /// </summary>
        /// <param name="items"></param>
        /// <returns>processed receipt</returns>
        static Receipt ProcessReceiptItems(ICollection<ReceiptItem> items)
        {
            Receipt receipt = new Receipt();
            receipt.Items = new Collection<ReceiptItem>();
            foreach ( ReceiptItem item in items)
            {
                // checks if the item's name is palindrome
                if(String.Equals(item.Name, Helper.Reverse(item.Name)))
                {
                    item.UnitPrice = 0m;
                    item.TaxAmount = 0m;
                    receipt.Items.Add(item);
                    continue;
                }
                if (item.IncludesTax)
                {
                    item.TaxAmount = Helper.CurrencyRound(item.UnitPrice / 11);     
                }
                else
                {
                    item.TaxAmount = Helper.CurrencyRound(item.UnitPrice * 0.1m);
                    // Update unit price of each item to include tax amount
                    item.UnitPrice += item.TaxAmount;
                    // Update IncludesTax to True because now tax in included in unit price
                    item.IncludesTax = true;
                }

                // Total of each item
                item.Total = item.UnitPrice * item.Quantity;

                // Add current item's total into total of receipt
                receipt.Total += item.Total;

                // Update total tax
                receipt.TaxTotal += item.TaxAmount * item.Quantity;
               
                // Add updated item to receipt
                receipt.Items.Add(item);
            }
            
            return receipt;
            // throw new NotImplementedException();
        }
    }
}
