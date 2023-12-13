public class Scanner {


    public Product Scan() {

        string code = UI.codeInput();
        
        return new Product() {code = code, price = Utils.getPrice(code), subP = Utils.isCollectionInMap(code)};
    }

}
