using System;
using System.Numerics;

public class Product
{
    // gets list of variables
    private string _name;
    private string _id;
    private float _price;
    private int _quantity;

    public Product(string name, string id, float price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }
   

   public float Price()
    {
        float total = _price * _quantity;
        return total;
    }

    public string GetDisplayProduct()
    {
        string text = $"{_name}: {_id}, {_price}x{_quantity}";
        return text;
    }
}