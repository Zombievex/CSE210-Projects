using System;
using System.Data;

public class Address
{
    // gets list of variables
    private string _street;
    private string _city;
    private string _state;
    private string _country;



    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsUSA()
    {
        if (_country == "USA")
        {
            return true;
        }else
        {
            return false;
        }
    }
   
   public string GetDisplayAddress()
    {   
        string text = $"{_street} {_city}, {_state}, {_country}";
        return text;
    }
}