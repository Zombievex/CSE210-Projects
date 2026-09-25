using System;

public class Customer
{
    // gets list of variables
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }
   
    public bool IsUSA()
    {
        return _address.IsUSA();
    }

    public string GetAddress()
    {
        return _address.GetDisplayAddress();
    }
}