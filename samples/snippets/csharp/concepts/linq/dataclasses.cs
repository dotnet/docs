record City(long Population);
record Country(string Name, List<City> Cities, long Area, long Population);
record Product(string Name, string Category);

enum GradeLevel
{
    FirstYear = 1,
    SecondYear,
    ThirdYear,
    FourthYear
};

// <query-a-collection-of-objects_1>
record Student(string FirstName, string LastName, int ID, GradeLevel Year, List<int> ExamScores)
{
    public static List<Student> students = new()
    {
        new(
            FirstName: "Terry", LastName: "Adams",
            ID: 120,
            Year: GradeLevel.SecondYear,
            ExamScores: new() { 99, 82, 81, 79 }
        ),
        new(
            FirstName: "Fadi", LastName: "Fakhouri",
            ID: 116,
            Year: GradeLevel.ThirdYear,
            ExamScores: new() { 99, 86, 90, 94 }
        ),
        new(
            FirstName: "Hanying", LastName: "Feng",
            ID: 117,
            Year: GradeLevel.FirstYear,
            ExamScores: new() { 93, 92, 80, 87 }
        ),
        new(
            FirstName: "Cesar", LastName: "Garcia",
            ID: 114,
            Year: GradeLevel.FourthYear,
            ExamScores: new() { 97, 89, 85, 82 }
        ),
        new(
            FirstName: "Debra", LastName: "Garcia",
            ID: 115,
            Year: GradeLevel.ThirdYear,
            ExamScores: new() { 35, 72, 91, 70 }
        ),
        new(
            FirstName: "Hugo", LastName: "Garcia",
            ID: 118,
            Year: GradeLevel.SecondYear,
            ExamScores: new() { 92, 90, 83, 78 }
        ),
        new(
            FirstName: "Sven", LastName: "Mortensen",
            ID: 113,
            Year: GradeLevel.FirstYear,
            ExamScores: new() { 88, 94, 65, 91 }
        ),
        new(
            FirstName: "Claire", LastName: "O'Donnell",
            ID: 112,
            Year: GradeLevel.FourthYear,
            ExamScores: new() { 75, 84, 91, 39 }
        ),
        new(
            FirstName: "Svetlana", LastName: "Omelchenko",
            ID: 111,
            Year: GradeLevel.SecondYear,
            ExamScores: new() { 97, 92, 81, 60 }
        ),
        new(
            FirstName: "Lance", LastName: "Tucker",
            ID: 119,
            Year: GradeLevel.ThirdYear,
            ExamScores: new() { 68, 79, 88, 92 }
        ),
        new(
            FirstName: "Michael", LastName: "Tucker",
            ID: 122,
            Year: GradeLevel.FirstYear,
            ExamScores: new() { 94, 92, 91, 91 }
        ),
        new(
            FirstName: "Eugene", LastName: "Zabokritski",
            ID: 121,
            Year: GradeLevel.FourthYear,
            ExamScores: new() { 96, 85, 91, 60 }
        )
    };
}
// </query-a-collection-of-objects_1>
