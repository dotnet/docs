using serialization;
// <Snippet3>
using System.IO;
using System.Text.Json;
// </Snippet3>

// <Snippet4>
const string fileName = @"../../../SavedLoan.json";
// </Snippet4>

// <Snippet1>
Loan testLoan = new(10000.0, 7.5, 36, "Neil Black");
// </Snippet1>

// <Snippet5>
if (File.Exists(fileName))
{
    Console.WriteLine("Reading saved file");
    string jsonFromFile = File.ReadAllText(fileName);
    testLoan = JsonSerializer.Deserialize<Loan>(jsonFromFile);
    testLoan.TimeLastLoaded = DateTime.Now;
}
// </Snippet5>

// <Snippet2>
testLoan.PropertyChanged += (_, __) => Console.WriteLine($"New customer value: {testLoan.Customer}");

testLoan.Customer = "Henry Clay";
Console.WriteLine(testLoan.InterestRate);
testLoan.InterestRate = 7.1;
Console.WriteLine(testLoan.InterestRate);
// </Snippet2>

// <Snippet6>
// Serialize it.
string jsonString = JsonSerializer.Serialize(testLoan);
File.WriteAllText(fileName, jsonString);
// </Snippet6>
