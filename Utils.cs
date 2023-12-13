public enum CheckoutType {
    CHEAP,
    EXP
}

public delegate Product ScanProduct();
public delegate void ReceiptPrint(Checkout products);

public class Utils {

    public static List<Product> priceMap = new();

    public static void generatePriceMap()
    {
        Random r = new();

        for (int number = 1; number <= 10; number++)
        {
            for (char letter = 'A'; letter <= 'E'; letter++)
            {
                string key = $"{number}{letter}";
                float basePrice = (float)r.NextDouble() * 100;

                Product p = new (){
                    code = key,
                    price = basePrice
                };
                priceMap.Add(p);

                char multipleLetter = (char) (letter + 6);
                string multipleKey = $"{number}{multipleLetter}";
                float discountFactor = 0.8f;
                int amount = r.Next(3,10);
                float multiplePrice = basePrice * (amount * discountFactor);
                
                Product multiP = new () {
                        code = multipleKey,
                        price = multiplePrice,
                        subP = {code = p.code, amount = amount}
                    };
                priceMap.Add(multiP);
            }
        }
        foreach (var item in priceMap)
        {
            Console.WriteLine(item);
        }
    }

    public static Product.subProduct isCollectionInMap(string key) {
        foreach (Product p in priceMap)
        {
            if (p.code.Equals(key)) {
                
                Console.WriteLine(p.subP.code);
                return p.subP;
            }
        }

        return new Product.subProduct() {code = null, amount = 0};
    }
    public static float getPrice(string key) {

        foreach (Product p in priceMap)
        {
            if (key.Equals(p.code)){
                return p.price;
            }
        }
        return 0;
    }  
}