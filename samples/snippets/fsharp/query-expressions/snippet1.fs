// F# query expression example using Entity Framework Core
open System
open System.Linq
open Microsoft.EntityFrameworkCore

// Entity type
[<CLIMutable>]
type Customer = {
    CustomerID: int
    CompanyName: string
    ContactName: string
}

// Database context
type NorthwindContext() =
    inherit DbContext()
    
    [<DefaultValue>]
    val mutable private customers: DbSet<Customer>
    member this.Customers with get() = this.customers and set v = this.customers <- v
    
    override _.OnConfiguring(optionsBuilder: DbContextOptionsBuilder) =
        optionsBuilder.UseInMemoryDatabase("NorthwindDatabase") |> ignore

// Create and seed database
let db = 
    let context = new NorthwindContext()
    context.Customers.AddRange([|
        { CustomerID = 1; CompanyName = "Alfreds Futterkiste"; ContactName = "Maria Anders" }
        { CustomerID = 2; CompanyName = "Ana Trujillo Emparedados y helados"; ContactName = "Ana Trujillo" }
        { CustomerID = 3; CompanyName = "Antonio Moreno Taquería"; ContactName = "Antonio Moreno" }
    |]) |> ignore
    context.SaveChanges() |> ignore
    context

// A query expression
let query1 =
    query {
        for customer in db.Customers do
            select customer
    }

// Print results
query1
|> Seq.iter (fun customer -> printfn "Company: %s Contact: %s" customer.CompanyName customer.ContactName)