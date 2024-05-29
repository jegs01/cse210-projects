using System;
using System.Collections.Generic;

public class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {stateOrProvince}, {country}";
    }
}
