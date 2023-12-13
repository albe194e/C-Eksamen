using System.Security.Permissions;

public struct Product : IComparable<Product>{

    public string code {get; set;}
    public float price {get; set;}

    public subProduct subP;

    public struct subProduct {
        public string code {get; set;} = "";
        public int amount {get; set;}

        public subProduct() {}
    }

    public Product() {
        
    }
    public Product(string code)
    {
        this.code = code;
        price = Utils.getPrice(code);
    }

    public bool isCollection() {
        if (subP.code == null){
            return false;
        } else {
            return true;
        }
    }

    public override string ToString() => $"({code}......{price}$$.....{isCollection()})";

    public int CompareTo(Product other)
    {
        return this.code.CompareTo(other.code);
    }
}

