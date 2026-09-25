using System;

class Program
{
    static void Main(string[] args)
    {
        Address address = new Address("12 maple ln", "McGucket", "Town Town", "USA");
        Customer customer = new Customer("Jannet Merkley", address);

        Order order = new Order(customer);

        order.AddProduct("String Cheese", "13B19F", 23.23f, 78);
        order.AddProduct("Ham Sandwich", "16A17B", 0.13f, 8);
        order.AddProduct("Pickle", "21C03E", 13.97f, 1);
        

        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"$ {order.TotalPrice()}");
        Console.WriteLine();
        order.DisplayPackageLabel();
        
    }
}