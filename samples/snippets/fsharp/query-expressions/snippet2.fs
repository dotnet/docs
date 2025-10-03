// Database setup example for query expressions using Entity Framework Core
open System
open System.Linq
open Microsoft.EntityFrameworkCore

// Define entity types that map to database tables
[<CLIMutable>]
type Student = {
    StudentID: int
    Name: string
    Age: Nullable<int>
}

[<CLIMutable>]
type Course = {
    CourseID: int
    CourseName: string
}

[<CLIMutable>]
type CourseSelection = {
    ID: int
    StudentID: int
    CourseID: int
}

// Define the database context using Entity Framework Core
type SchoolContext() =
    inherit DbContext()
    
    [<DefaultValue>]
    val mutable private student: DbSet<Student>
    member this.Student with get() = this.student and set v = this.student <- v
    
    [<DefaultValue>]
    val mutable private course: DbSet<Course>
    member this.Course with get() = this.course and set v = this.course <- v
    
    [<DefaultValue>]
    val mutable private courseSelection: DbSet<CourseSelection>
    member this.CourseSelection with get() = this.courseSelection and set v = this.courseSelection <- v
    
    override _.OnConfiguring(optionsBuilder: DbContextOptionsBuilder) =
        optionsBuilder.UseInMemoryDatabase("SchoolDatabase") |> ignore

// Create and seed the database
let createAndSeedDatabase() =
    let context = new SchoolContext()
    
    // Seed data
    context.Student.AddRange([|
        { StudentID = 1; Name = "Abercrombie, Kim"; Age = Nullable(10) }
        { StudentID = 2; Name = "Abolrous, Hazen"; Age = Nullable(14) }
        { StudentID = 3; Name = "Hance, Jim"; Age = Nullable(12) }
        { StudentID = 4; Name = "Adams, Terry"; Age = Nullable(12) }
        { StudentID = 5; Name = "Hansen, Claus"; Age = Nullable(11) }
        { StudentID = 6; Name = "Penor, Lori"; Age = Nullable(13) }
        { StudentID = 7; Name = "Perham, Tom"; Age = Nullable(12) }
        { StudentID = 8; Name = "Peng, Yun-Feng"; Age = Nullable() }
    |]) |> ignore
    
    context.Course.AddRange([|
        { CourseID = 1; CourseName = "Algebra I" }
        { CourseID = 2; CourseName = "Trigonometry" }
        { CourseID = 3; CourseName = "Algebra II" }
        { CourseID = 4; CourseName = "History" }
        { CourseID = 5; CourseName = "English" }
        { CourseID = 6; CourseName = "French" }
        { CourseID = 7; CourseName = "Chinese" }
    |]) |> ignore
    
    context.CourseSelection.AddRange([|
        { ID = 1; StudentID = 1; CourseID = 2 }
        { ID = 2; StudentID = 1; CourseID = 3 }
        { ID = 3; StudentID = 1; CourseID = 5 }
        { ID = 4; StudentID = 2; CourseID = 2 }
        { ID = 5; StudentID = 2; CourseID = 5 }
        { ID = 6; StudentID = 2; CourseID = 6 }
        { ID = 7; StudentID = 2; CourseID = 3 }
        { ID = 8; StudentID = 3; CourseID = 2 }
        { ID = 9; StudentID = 3; CourseID = 1 }
        { ID = 10; StudentID = 4; CourseID = 2 }
        { ID = 11; StudentID = 4; CourseID = 5 }
        { ID = 12; StudentID = 4; CourseID = 2 }
        { ID = 13; StudentID = 5; CourseID = 3 }
        { ID = 14; StudentID = 5; CourseID = 2 }
        { ID = 15; StudentID = 7; CourseID = 3 }
    |]) |> ignore
    
    context.SaveChanges() |> ignore
    context

// Create the database context
let db = createAndSeedDatabase()

// Needed for some query operator examples:
let data = [ 1; 5; 7; 11; 18; 21]