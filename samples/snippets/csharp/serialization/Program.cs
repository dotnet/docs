using serialization;
using System.Text.Json;

const string fileName = @"../../../SavedLoan.json";

Loan testLoan = new(10000.0, 7.5, 36, "Neil Black");

if (File.Exists(fileName))
{
    Console.WriteLine("Reading saved file");
    string jsonFromFile = File.ReadAllText(fileName);
    testLoan = JsonSerializer.Deserialize<Loan>(jsonFromFile);
    testLoan.TimeLastLoaded = DateTime.Now;
}

testLoan.PropertyChanged += (_, __) => Console.WriteLine($"New customer value: {testLoan.Customer}");

testLoan.Customer = "Henry Clay";
Console.WriteLine(testLoan.InterestRate);
testLoan.InterestRate = 7.1;
Console.WriteLine(testLoan.InterestRate);

// Serialize it.
string jsonString = JsonSerializer.Serialize(testLoan);
File.WriteAllText(fileName, jsonString);
