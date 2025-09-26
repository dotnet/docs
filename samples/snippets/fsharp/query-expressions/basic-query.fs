module QueryExpressions.BasicQuery

// Basic query expression example using in-memory data
open System
open System.Linq

// Define simple data types to represent our sample database
type Student = {
    StudentID: int
    Name: string
    Age: int option
}

type Course = {
    CourseID: int
    CourseName: string
}

type CourseSelection = {
    ID: int
    StudentID: int
    CourseID: int
}

// Sample data
let students = [
    { StudentID = 1; Name = "Abercrombie, Kim"; Age = Some 10 }
    { StudentID = 2; Name = "Abolrous, Hazen"; Age = Some 14 }
    { StudentID = 3; Name = "Hance, Jim"; Age = Some 12 }
    { StudentID = 4; Name = "Adams, Terry"; Age = Some 12 }
    { StudentID = 5; Name = "Hansen, Claus"; Age = Some 11 }
    { StudentID = 6; Name = "Penor, Lori"; Age = Some 13 }
    { StudentID = 7; Name = "Perham, Tom"; Age = Some 12 }
    { StudentID = 8; Name = "Peng, Yun-Feng"; Age = None }
]

let courses = [
    { CourseID = 1; CourseName = "Algebra I" }
    { CourseID = 2; CourseName = "Trigonometry" }
    { CourseID = 3; CourseName = "Algebra II" }
    { CourseID = 4; CourseName = "History" }
    { CourseID = 5; CourseName = "English" }
    { CourseID = 6; CourseName = "French" }
    { CourseID = 7; CourseName = "Chinese" }
]

let courseSelections = [
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
]

// Convert to queryable collections for LINQ operations
let studentsQueryable = students.AsQueryable()
let coursesQueryable = courses.AsQueryable()
let courseSelectionsQueryable = courseSelections.AsQueryable()

// A query expression example
let query1 =
    query {
        for student in studentsQueryable do
            select student
    }

// Print results
query1
|> Seq.iter (fun student -> printfn "Student: %s" student.Name)