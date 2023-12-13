public class Checkout {


    public List<Product> products;

    public float totalPrice;

    //Callback function
    public ScanProduct scan;
    public ReceiptPrint print;
    

    
    public Checkout() {
        products = new();
    }

    public void printReceipt() {
        print(this);
    }

    public void addProduct() {

        Product p = scan();

        if (p.price > 0) {
            products.Add(p);

            totalPrice += p.price;
        }
    }

    

    public void deleteProduct() {

        
    }

    public void clearProducts() {

        products.Clear();
        totalPrice = 0;
    }

}