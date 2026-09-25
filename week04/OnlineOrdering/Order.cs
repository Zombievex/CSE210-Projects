using System;
using System.Reflection.Emit;

public class Order
{
    // gets list of variables
    private Customer _customer;

    private List<Product> _products = new List<Product>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(string name, string id, float price, int quantity)
    {
        Product product = new Product(name, id, price, quantity);
        _products.Add(product);
    }

    public float TotalPrice()
    {
        float total = 0.0f;
        foreach (Product product in _products)
        {
            total += product.Price();
        }

        total += GetShipping();

        total = MathF.Round(total, 2);
        return total;
    }
    public float GetShipping()
    {
        if (_customer.IsUSA()){
            return 5.0f;
        }else
        {
            return 35.0f;
        }
    }

    public void DisplayPackageLabel()
    {
        foreach (Product product in _products)
        {
            Console.WriteLine(product.GetDisplayProduct());
        }
    }

    public string GetShippingLabel()
    {
        return _customer.GetAddress();
    }
}