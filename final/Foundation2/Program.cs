using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Wall St", "Rexburg", "ID", "USA");
        Address address2 = new Address("75 Lagos St", "Ikeja", "LG", "Nigeria");

        Customer customer1 = new Customer("Vicky Jegede", address1);
        Customer customer2 = new Customer("Daniel Jegede", address2);

        Product product1 = new Product("Bag", "BAG123", 1000m, 1);
        Product product2 = new Product("Shoe", "SHO456", 25m, 2);
        Product product3 = new Product("Belt", "BEL789", 50m, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}\n");
        }
    }
}
