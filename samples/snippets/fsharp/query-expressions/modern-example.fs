module QueryExpressions.ModernExample

// Modern F# query expression example using in-memory collections
// This provides a working alternative to deprecated type providers

open System
open System.Linq

// Simple data structures to demonstrate query capabilities
type Customer = {
    CustomerID: int
    CompanyName: string
    ContactName: string
}

// Sample data that replaces the external data source
let customers = [
    { CustomerID = 1; CompanyName = "Alfreds Futterkiste"; ContactName = "Maria Anders" }
    { CustomerID = 2; CompanyName = "Ana Trujillo Emparedados y helados"; ContactName = "Ana Trujillo" }
    { CustomerID = 3; CompanyName = "Antonio Moreno Taquería"; ContactName = "Antonio Moreno" }
    { CustomerID = 4; CompanyName = "Around the Horn"; ContactName = "Thomas Hardy" }
    { CustomerID = 5; CompanyName = "Berglunds snabbköp"; ContactName = "Christina Berglund" }
]

// Convert to queryable for LINQ operations
let db = customers.AsQueryable()

// A query expression that works with modern .NET
let query1 =
    query {
        for customer in db do
            select customer
    }

// Print results (this would be equivalent to the old example)
let printResults() =
    query1
    |> Seq.iter (fun customer -> printfn "Company: %s Contact: %s" customer.CompanyName customer.ContactName)