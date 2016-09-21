using static System.Math;
using static System.String;
using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace NewStyle
{
    public class Student
    {
        public Student(string firstName, string lastName)
        {
            if (IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(nameof(firstName), "Cannot be blank");
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get;  }
        public ICollection<double> Grades { get; } = new List<double>();
        public Standing YearInSchool { get; set;} = Standing.Freshman;
        public string FullName => $"{FirstName} {LastName}";

        public override string ToString() => $"{LastName}, {FirstName}";

        public string GetFormattedGradePoint() =>
            $"Name: {LastName}, {FirstName}. G.P.A: {Grades.Average()}";

        public string GetGradePointPercentage() =>
            $"Name: {LastName}, {FirstName}. G.P.A: {Grades.Average():F2}";
            
        public string GetGradePointPercentages() =>
            $"Name: {LastName}, {FirstName}. G.P.A: {(Grades.Any() ? Grades.Average() : double.NaN):F2}";

        public bool MakesDeansList()
        {
            return Grades.All(g => g > 3.5) && Grades.Any();
            // Generates CS0103: The name 'All' does not exist in the current context.
            //return All(Grades, g => g > 3.5) && Grades.Any();
        }

        public string GetAllGrades() =>
            $@"All Grades: {Grades.OrderByDescending(g => g)
            .Select(s => s.ToString("F2")).Aggregate((partial, element) => $"{partial}, {element}")}";
    }
}
