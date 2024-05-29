using System;
using System.Collections.Generic;

public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string GetName() => name;
    public string GetProductId() => productId;
    public decimal GetPrice() => price;
    public int GetQuantity() => quantity;

    public decimal GetTotalCost()
    {
        return price * quantity;
    }
}
