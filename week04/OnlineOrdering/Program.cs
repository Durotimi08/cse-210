using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "Ontario", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Maria Garcia", address2);

        // Create products
        Product laptop = new Product("Gaming Laptop", "LAP001", 1299.99, 1);
        Product mouse = new Product("Wireless Mouse", "MOU002", 29.99, 2);
        Product keyboard = new Product("Mechanical Keyboard", "KEY003", 89.99, 1);
        Product headphones = new Product("Noise-Canceling Headphones", "HEA004", 199.99, 1);
        Product monitor = new Product("4K Monitor", "MON005", 399.99, 1);
        Product webcam = new Product("HD Webcam", "WEB006", 79.99, 1);

        // Create Order 1 (USA customer)
        Order order1 = new Order(customer1);
        order1.AddProduct(laptop);
        order1.AddProduct(mouse);
        order1.AddProduct(keyboard);

        // Create Order 2 (International customer)
        Order order2 = new Order(customer2);
        order2.AddProduct(headphones);
        order2.AddProduct(monitor);
        order2.AddProduct(webcam);

        // Display Order 1 information
        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");
        Console.WriteLine();

        // Display Order 2 information
        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}