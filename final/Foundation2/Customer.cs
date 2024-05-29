using System;
using System.Collections.Generic;

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName() => name;
    public Address GetAddress() => address;

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }
}
