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
        string json = @"{""Name"":""Banana"",""ExpiryDate"":""2019-07-26T00:00:00""}";
        Product p = JsonSerializer.Deserialize<Product>(json);
        Console.WriteLine(p.Name);
        Console.WriteLine(p.ExpiryDate);
    }
}

// The example displays output similar to the following:
// Banana
// 7/26/2019 12:00:00 AM
