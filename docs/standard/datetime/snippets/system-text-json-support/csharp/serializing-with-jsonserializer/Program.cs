using System;
using System.Text.Json;

public class Example
{
    private class Product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

    public static void Main(string[] args)
    {
        Product p = new Product();
        p.Name = "Banana";
        p.ExpiryDate = new DateTime(2019, 7, 26);

        string json = JsonSerializer.Serialize(p);
        Console.WriteLine(json);
    }
}

// The example displays the following output:
// {"Name":"Banana","ExpiryDate":"2019-07-26T00:00:00"}
