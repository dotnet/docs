// Modern F# query expression example using in-memory data
open System
open System.Linq

// Simple data structures
type Customer = {
    CustomerID: int
    CompanyName: string
    ContactName: string
}

// Sample data
let customers = [
    { CustomerID = 1; CompanyName = "Alfreds Futterkiste"; ContactName = "Maria Anders" }
    { CustomerID = 2; CompanyName = "Ana Trujillo Emparedados y helados"; ContactName = "Ana Trujillo" }
    { CustomerID = 3; CompanyName = "Antonio Moreno Taquería"; ContactName = "Antonio Moreno" }
]

let db = customers.AsQueryable()

// A query expression
let query1 =
    query {
        for customer in db do
            select customer
    }

// Print results
query1
|> Seq.iter (fun customer -> printfn "Company: %s Contact: %s" customer.CompanyName customer.ContactName)