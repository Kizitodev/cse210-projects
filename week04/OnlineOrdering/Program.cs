class Program
{
    static void Main(string[] args)
    {
        // Customer 1
        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "NY",
            "USA");

        Customer customer1 = new Customer(
            "John Smith",
            address1);

        // Products for Order 1
        Product product1 = new Product(
            "Laptop",
            "P001",
            800,
            1);

        Product product2 = new Product(
            "Wireless Mouse",
            "P002",
            25,
            2);

        Product product3 = new Product(
            "Keyboard",
            "P003",
            50,
            1);

        // Order 1
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        // Customer 2
        Address address2 = new Address(
            "15 Allen Avenue",
            "Lagos",
            "Lagos",
            "Nigeria");

        Customer customer2 = new Customer(
            "Chidera Ibekwe",
            address2);

        // Products for Order 2
        Product product4 = new Product(
            "Monitor",
            "P004",
            300,
            1);

        Product product5 = new Product(
            "USB Cable",
            "P005",
            10,
            3);

        // Order 2
        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);


        // Display Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}");
        Console.WriteLine();


        // Display Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
    }
}