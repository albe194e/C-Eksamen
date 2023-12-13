This is my exam assignment for C# course

Intro:
    ```
    The program has the ability to scan different products based on a code e.g "5A",
    and then print out the reciept, either a very simple or more complicated.
    The product codes are genereated and prices are random.
    ```
Used functionality:
    - First of course OOP, but also value types (struct).
    - My checkout uses a delegate for an event from the scanner. So whenever i call the scan         function, it returns a product for the checkout to process.
    - Object initializers for my classes and struct.
    - LINQ syntax to sort and select specific products to print. used in UI class
    - I have an Utils which contains types and static methods which 

Program flow:

    First the user chooses weather to use the cheap or expensive version of the checkout.
    The checkout then gets instantieted and gets the delegate function from the scanner aswell as a delegate function from which type of receipt it should print.

    The product struct is a struct because i will never change the value of this, and therefore i dont need a class. The product struct can also contain a subProduct, which tells weather or not it is a collection of one of the other products.

    The program then loops over scanning and the user inputs which item it should scan. 
    The checkout adds the product to its list of scanned products and at the end it can print the reciept of the items.
