namespace Linq.GetStarted;

// <basics_datasource>
record City(string Name, long Population);
record Country(string Name, double Area, long Population, List<City> Cities);
record Product(string Name, string Category);
// </basics_datasource>

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ID { get; set; }
    public GradeLevel? Year { get; set; }
    public List<int> ExamScores { get; set; }

    public Student(string FirstName, string LastName, int ID, GradeLevel Year, List<int> ExamScores)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.ID = ID;
        this.Year = Year;
        this.ExamScores = ExamScores;
    }

    public Student(string FirstName, string LastName, int StudentID, List<int>? ExamScores = null)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        ID = StudentID;
        this.ExamScores = ExamScores ?? [];
    }

    public static List<Student> students =
    [
        new(
            FirstName: "Terry", LastName: "Adams", ID: 120,
            Year: GradeLevel.SecondYear,
            ExamScores: [99, 82, 81, 79]
        ),
        new(
            "Fadi", "Fakhouri", 116,
            GradeLevel.ThirdYear,
            [99, 86, 90, 94]
        ),
        new(
            "Hanying", "Feng", 117,
            GradeLevel.FirstYear,
            [93, 92, 80, 87]
        ),
        new(
            "Cesar", "Garcia", 114,
            GradeLevel.FourthYear,
            [97, 89, 85, 82]
        ),
        new(
            "Debra", "Garcia", 115,
            GradeLevel.ThirdYear,
            [35, 72, 91, 70]
        ),
        new(
            "Hugo", "Garcia", 118,
            GradeLevel.SecondYear,
            [92, 90, 83, 78]
        ),
        new(
            "Sven", "Mortensen", 113,
            GradeLevel.FirstYear,
            [88, 94, 65, 91]
        ),
        new(
            "Claire", "O'Donnell", 112,
            GradeLevel.FourthYear,
            [75, 84, 91, 39]
        ),
        new(
            "Svetlana", "Omelchenko", 111,
            GradeLevel.SecondYear,
            [97, 92, 81, 60]
        ),
        new(
            "Lance", "Tucker", 119,
            GradeLevel.ThirdYear,
            [68, 79, 88, 92]
        ),
        new(
            "Michael", "Tucker", 122,
            GradeLevel.FirstYear,
            [94, 92, 91, 91]
        ),
        new(
            "Eugene", "Zabokritski", 121,
            GradeLevel.FourthYear,
            [96, 85, 91, 60]
        )
    ];
}

enum GradeLevel
{
    FirstYear = 1,
    SecondYear,
    ThirdYear,
    FourthYear
};

