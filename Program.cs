
Scanner scanner = new();


Checkout checkout = null;

//Just random generated prices
Utils.generatePriceMap();

CheckoutType t = UI.chooseType();

switch (t)
{
    case CheckoutType.CHEAP:
        checkout = new () {
            scan = scanner.Scan,
            print = UI.printReceiptCheap
        };
        break;
    case CheckoutType.EXP:
        checkout = new () {
            scan = scanner.Scan,
            print = UI.printReceiptExp
        };
        break;

    default:
        checkout = null;
        break;
}

if (checkout == null) {
    throw new Exception();
}

//Loop
bool scanning = true;
while (scanning) {

    checkout.addProduct();

    UI.printTotalCost(checkout.totalPrice);

    scanning = UI.scanChoices();

    if (!scanning) {
        checkout.printReceipt();
    }
}