namespace StandardQueryOperators;

//<QueryDataSource>
public enum GradeLevel
{
    FirstYear = 1,
    SecondYear,
    ThirdYear,
    FourthYear
};

public class Student
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required int ID { get; init; }

    public required GradeLevel Year { get; init; }
    public required List<int> Scores { get; init; }

    public required int DepartmentID { get; init; }
}

public class Teacher
{
    public required string First { get; init; }
    public required string Last { get; init; }
    public required int ID { get; init; }
    public required string City { get; init; }
}

public class Department
{
    public required string Name { get; init; }
    public int ID { get; init; }

    public required int TeacherID { get; init; }
}
// </QueryDataSource>

public static class Sources
{
    public static IEnumerable<Department> Departments =>
    [
        new() { Name = "English",     ID = 1, TeacherID = 901 },
        new() { Name = "Mathematics", ID = 2, TeacherID = 965 },
        new() { Name = "Engineering", ID = 3, TeacherID = 932 },
        new() { Name = "Economics",   ID = 4, TeacherID = 945 },
        new() { Name = "Physics",     ID = 5, TeacherID = 987 },
        new() { Name = "Chemistry",   ID = 6, TeacherID = 901 }
    ];

    // Create a data source by using a collection initializer.
    public static IEnumerable<Student> Students =>
    [
        new() { FirstName = "Svetlana",   LastName = "Omelchenko",  DepartmentID =  1, Year = GradeLevel.FirstYear,  ID = 111, Scores = [97, 90, 73, 54] },
        new() { FirstName = "Claire",     LastName = "O'Donnell",   DepartmentID = -1, Year = GradeLevel.FirstYear,  ID = 112, Scores = [56, 78, 95, 95] },
        new() { FirstName = "Sven",       LastName = "Mortensen",   DepartmentID =  3, Year = GradeLevel.SecondYear, ID = 113, Scores = [61, 52, 48, 72] },
        new() { FirstName = "Cesar",      LastName = "Garcia",      DepartmentID =  4, Year = GradeLevel.SecondYear, ID = 114, Scores = [71, 86, 77, 97] },
        new() { FirstName = "Debra",      LastName = "Garcia",      DepartmentID =  5, Year = GradeLevel.ThirdYear,  ID = 115, Scores = [66, 96, 70, 69] },
        new() { FirstName = "Fadi",       LastName = "Fakhouri",    DepartmentID =  6, Year = GradeLevel.ThirdYear,  ID = 116, Scores = [93, 72, 62, 65] },
        new() { FirstName = "Hanying",    LastName = "Feng",        DepartmentID =  1, Year = GradeLevel.FourthYear, ID = 117, Scores = [53, 81, 81, 50] },
        new() { FirstName = "Hugo",       LastName = "Garcia",      DepartmentID =  2, Year = GradeLevel.FourthYear, ID = 118, Scores = [68, 91, 60, 51] },
        new() { FirstName = "Lance",      LastName = "Tucker",      DepartmentID = -1, Year = GradeLevel.FirstYear,  ID = 119, Scores = [83, 42, 68, 63] },
        new() { FirstName = "Terry",      LastName = "Adams",       DepartmentID =  4, Year = GradeLevel.SecondYear, ID = 120, Scores = [63, 91, 71, 51] },
        new() { FirstName = "Eugene",     LastName = "Zabokritski", DepartmentID =  5, Year = GradeLevel.ThirdYear,  ID = 121, Scores = [56, 40, 73, 75] },
        new() { FirstName = "Michael",    LastName = "Tucker",      DepartmentID =  3, Year = GradeLevel.FourthYear, ID = 122, Scores = [85, 82, 81, 70] },
        new() { FirstName = "Mark",       LastName = "Johansson",   DepartmentID =  1, Year = GradeLevel.FirstYear,  ID = 123, Scores = [82, 94, 84, 65] },
        new() { FirstName = "Sarah",      LastName = "Andersson",   DepartmentID =  1, Year = GradeLevel.FirstYear,  ID = 124, Scores = [77, 83, 67, 90] },
        new() { FirstName = "Christiane", LastName = "Jensen",      DepartmentID =  1, Year = GradeLevel.FirstYear,  ID = 125, Scores = [88, 57, 65, 87] },
        new() { FirstName = "Evgeniya",   LastName = "Maslova",     DepartmentID =  2, Year = GradeLevel.SecondYear, ID = 126, Scores = [46, 84, 87, 66] },
        new() { FirstName = "Innocenty",  LastName = "Popov",       DepartmentID =  6, Year = GradeLevel.SecondYear, ID = 127, Scores = [92, 45, 88, 60] },
        new() { FirstName = "Anna",       LastName = "Hedlund",     DepartmentID =  2, Year = GradeLevel.SecondYear, ID = 128, Scores = [85, 54, 74, 75] },
        new() { FirstName = "Erik",       LastName = "Axelsson",    DepartmentID =  3, Year = GradeLevel.ThirdYear,  ID = 129, Scores = [51, 78, 54, 49] },
        new() { FirstName = "Anna",       LastName = "Yermolayeva", DepartmentID =  3, Year = GradeLevel.ThirdYear,  ID = 130, Scores = [46, 73, 93, 68] },
        new() { FirstName = "Cassie",     LastName = "Hicks",       DepartmentID =  3, Year = GradeLevel.ThirdYear,  ID = 131, Scores = [85, 60, 85, 56] },
        new() { FirstName = "Ifeanacho",  LastName = "Jamuike",     DepartmentID =  4, Year = GradeLevel.FourthYear, ID = 132, Scores = [54, 98, 56, 61] },
        new() { FirstName = "Carmen",     LastName = "Vella",       DepartmentID =  6, Year = GradeLevel.FourthYear, ID = 133, Scores = [63, 57, 69, 70] },
        new() { FirstName = "Noel",       LastName = "Svensson",    DepartmentID =  4, Year = GradeLevel.FourthYear, ID = 134, Scores = [85, 60, 80, 73] },
        new() { FirstName = "Sanna",      LastName = "Hansson",     DepartmentID =  5, Year = GradeLevel.FirstYear,  ID = 135, Scores = [46, 94, 93, 45] },
        new() { FirstName = "Sofiya",     LastName = "Seleznyova",  DepartmentID =  6, Year = GradeLevel.FirstYear,  ID = 136, Scores = [74, 45, 87, 55] },
        new() { FirstName = "Amy E.",     LastName = "Edwards",     DepartmentID =  5, Year = GradeLevel.FirstYear,  ID = 137, Scores = [87, 59, 55, 70] },
        new() { FirstName = "Nancy",      LastName = "Engström",    DepartmentID =  3, Year = GradeLevel.FirstYear,  ID = 138, Scores = [75, 73, 78, 83] },
        new() { FirstName = "Katerina",   LastName = "Kovaleva",    DepartmentID =  2, Year = GradeLevel.FirstYear,  ID = 139, Scores = [44, 50, 47, 41] },
        new() { FirstName = "Ifunanya",   LastName = "Ugomma",      DepartmentID =  4, Year = GradeLevel.FirstYear,  ID = 140, Scores = [84, 82, 96, 80] },
        new() { FirstName = "Don",        LastName = "Richardson",  DepartmentID =  5, Year = GradeLevel.FirstYear,  ID = 141, Scores = [47, 91, 73, 68] },
        new() { FirstName = "Josephine",  LastName = "Balzan",      DepartmentID =  6, Year = GradeLevel.SecondYear, ID = 142, Scores = [40, 47, 63, 42] },
        new() { FirstName = "Michelle",   LastName = "Caruana",     DepartmentID = -1, Year = GradeLevel.FirstYear,  ID = 143, Scores = [97, 92, 69, 77] },
        new() { FirstName = "Gaby",       LastName = "Frost",       DepartmentID =  2, Year = GradeLevel.FirstYear,  ID = 144, Scores = [70, 79, 47, 79] },
        new() { FirstName = "Erna",       LastName = "Nilsson",     DepartmentID =  3, Year = GradeLevel.FirstYear,  ID = 145, Scores = [56, 52, 51, 51] },
        new() { FirstName = "Naima",      LastName = "Larsson",     DepartmentID =  4, Year = GradeLevel.ThirdYear,  ID = 146, Scores = [65, 81, 44, 61] },
        new() { FirstName = "Donald",     LastName = "Urquhart",    DepartmentID =  1, Year = GradeLevel.FirstYear,  ID = 147, Scores = [92, 90, 95, 57] },
        new() { FirstName = "Nadezhda",   LastName = "Kolpakova",   DepartmentID =  1, Year = GradeLevel.FirstYear,  ID = 148, Scores = [94, 69, 52, 58] },
        new() { FirstName = "Ruth",       LastName = "Olsson",      DepartmentID =  2, Year = GradeLevel.FourthYear, ID = 149, Scores = [66, 49, 82, 74] },
        new() { FirstName = "Maria",      LastName = "Sammut",      DepartmentID =  2, Year = GradeLevel.FirstYear,  ID = 150, Scores = [43, 83, 94, 60] },
        new() { FirstName = "Veronika",   LastName = "Berg",        DepartmentID =  3, Year = GradeLevel.FirstYear,  ID = 151, Scores = [59, 76, 65, 92] },
        new() { FirstName = "Nicholas",   LastName = "Micallef",    DepartmentID =  3, Year = GradeLevel.FirstYear,  ID = 152, Scores = [44, 57, 52, 63] },
        new() { FirstName = "Izuchukwu",  LastName = "Adaobi",      DepartmentID =  4, Year = GradeLevel.SecondYear, ID = 153, Scores = [51, 40, 42, 54] },
        new() { FirstName = "Nwanneka",   LastName = "Ifeoma",      DepartmentID =  4, Year = GradeLevel.FirstYear,  ID = 154, Scores = [44, 70, 98, 56] },
        new() { FirstName = "John",       LastName = "Falzon",      DepartmentID =  5, Year = GradeLevel.FirstYear,  ID = 155, Scores = [77, 65, 83, 45] },
        new() { FirstName = "Martina",    LastName = "Mattsson",    DepartmentID =  5, Year = GradeLevel.ThirdYear,  ID = 156, Scores = [51, 49, 96, 72] },
        new() { FirstName = "Jeanette",   LastName = "Berggren",    DepartmentID =  4, Year = GradeLevel.FirstYear,  ID = 157, Scores = [41, 67, 46, 68] },
        new() { FirstName = "Anastasiya", LastName = "Sazonova",    DepartmentID =  2, Year = GradeLevel.FirstYear,  ID = 158, Scores = [53, 96, 76, 49] },
        new() { FirstName = "Bruce",      LastName = "Keever",      DepartmentID =  3, Year = GradeLevel.FirstYear,  ID = 159, Scores = [54, 81, 84, 81] },
        new() { FirstName = "Sami",       LastName = "Åkesson",     DepartmentID =  5, Year = GradeLevel.FourthYear, ID = 160, Scores = [45, 85, 79, 94] },
        new() { FirstName = "Jesper",     LastName = "Jakobsson",   DepartmentID =  1, Year = GradeLevel.FirstYear,  ID = 161, Scores = [59, 98, 47, 92] },
        new() { FirstName = "Max",        LastName = "Lindgren",    DepartmentID =  2, Year = GradeLevel.FirstYear,  ID = 162, Scores = [86, 88, 96, 63] },
        new() { FirstName = "Arina",      LastName = "Ivanova",     DepartmentID =  1, Year = GradeLevel.FirstYear,  ID = 163, Scores = [93, 63, 70, 80] }
    ];

    public static IEnumerable<Teacher> Teachers =>
    [
        new() { First = "Ann",       Last = "Beebe",     ID = 901, City = "Seattle" },
        new() { First = "Alex",      Last = "Robinson",  ID = 910, City = "Redmond" },
        new() { First = "Michiyo",   Last = "Sato",      ID = 921, City = "Tacoma"  },
        new() { First = "Aylin",     Last = "Lundgren",  ID = 932, City = "Seattle" },
        new() { First = "Gleb",      Last = "Seleznyov", ID = 943, City = "Redmond" },
        new() { First = "Alexandra", Last = "Voronova",  ID = 954, City = "Tacoma" },
        new() { First = "Kevin",     Last = "McDowell",  ID = 965, City = "Redmond" },
        new() { First = "Selma",     Last = "Nyberg",    ID = 976, City = "Seattle" },
        new() { First = "Selma",     Last = "Åstrom",    ID = 987, City = "Redmond" },
        new() { First = "Hillevi",   Last = "Bengtsson", ID = 998, City = "Tacoma" },
        new() { First = "Allan",     Last = "Sandberg",  ID = 912, City = "Seattle" },
        new() { First = "Dmitry",    Last = "Degtyarev", ID = 923, City = "Redmond" },
        new() { First = "Arinze",    Last = "Madu",      ID = 934, City = "Seattle" },
        new() { First = "Andrey",    Last = "Glazkov",   ID = 945, City = "Redmond" },
        new() { First = "Kettil",    Last = "Berggren",  ID = 956, City = "Tacoma" },
        new() { First = "Hanying",   Last = "Feng",      ID = 967, City = "Seattle" },
        new() { First = "Hugo",      Last = "Garcia",    ID = 978, City = "Redmond" },
        new() { First = "Michael",   Last = "Tucker",    ID = 989, City = "Tacoma" },
        new() { First = "Ifeanacho", Last = "Jamuike",   ID = 991, City = "Redmond" },
        new() { First = "Carmen",    Last = "Vella",     ID = 982, City = "Tacoma" },
        new() { First = "Noel",      Last = "Svensson",  ID = 973, City = "Seattle" }
   ];
}
