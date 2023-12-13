using System.ComponentModel.Design;

public class UI {

    public static CheckoutType chooseType() {

        Console.WriteLine("\nChoose checkout type:\n" +
                           "(1) cheap\n" +
                           "(2) expensive");
        
        string input = Console.ReadLine();

        if (input.Equals("1")) {
            return CheckoutType.CHEAP;
        } else {
            return CheckoutType.EXP;
        }
    }
    public static bool scanChoices() {

        Console.WriteLine("\n(1) Scan new item\n(0) Proceed to checkout");

        string input = Console.ReadLine();

        if (input is "0"){
            return false;
        } else {
            return true;
        }
        
    }
    public static void succesfullScan(bool ok) {
        
        if (ok) {
            Console.WriteLine("\nSuccesfully scanned the item!\n");
        } else {
            Console.WriteLine("\nSomething unexpected happened");
        }
        
    }
    public static string codeInput() {

        Console.WriteLine("\nCode: \n");
        string code = Console.ReadLine();

        return code;

    }
    public static void receipt() {

    }


    public static void printTotalCost(float cost) {

        Console.WriteLine($"TOTAL COST: {cost}$$$");
    }


    public static void printReceiptCheap(Checkout checkout) {

        Console.WriteLine("RECEIPT........................... ");
        Console.WriteLine("ITEM.............................. PRICE");
        for (int i = 0; i < checkout.products.Count; i++)
        {

            Console.WriteLine($"({i}): {checkout.products[i].code}.......................{checkout.products[i].price}");
        }

        printTotalCost(checkout.totalPrice);

    }
    public static void printReceiptExp(Checkout checkout) {
        
        var sortedProducts = from product in checkout.products
            orderby 
                product ascending
            select product;
        
        //This line finds unique products and groups them together
        var productGroups = sortedProducts.Select(p => p.code).Distinct().GroupBy(p => p[0]);

        Console.WriteLine("RECEIPT........................: ");
        foreach (var group in productGroups)
        {   
            Console.WriteLine($"\nGroup: {group.Key}");
            Console.WriteLine(" ITEM:......................... NUM...PRICE");
            foreach (string code in group)
            {
                uint numOfP = 0;
                float price = 0;
                string codeToPrint = "";

                foreach (var p in sortedProducts)
                {
                    if (p.code.Equals(code)) {
                        numOfP++;
                        price += p.price;
                        bool ok = p.subP.code != null;
                        if (ok) {
                            
                            codeToPrint = $"{code}..({p.subP.amount} Of {p.subP.code}).................";
                        } else {
                            codeToPrint = $"{code}.............................";
                        }
                    }
                }

                
                Console.WriteLine($" {codeToPrint}{numOfP}.....{price}");
            }
        }
        printTotalCost(checkout.totalPrice); 
    }
}