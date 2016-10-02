// <UsingStaticMath>
using static System.Math;
// </UsingStaticMath>
// <UsingStatic>
using static System.String;
// </UsingStatic>
using System;
using System.Collections.Generic;
// <usingStaticLinq>
using static System.Linq.Enumerable;
// </usingStaticLinq>

namespace NewStyle
{
    public class Student
    {
        // <ReadOnlyAutoPropertyConstructor>
        public Student(string firstName, string lastName)
        {
            // <UsingStaticString>
            if (IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(message: "Cannot be blank", paramName: nameof(lastName));
            // </UsingStaticString>
            FirstName = firstName;
            LastName = lastName;
        }
        // </ReadOnlyAutoPropertyConstructor>

        // <ReadOnlyAutoProperty>
        public string FirstName { get; }
        public string LastName { get;  }
        // </ReadOnlyAutoProperty>

        // <Initialization>
        public ICollection<double> Grades { get; } = new List<double>();
        // </Initialization>
        // <ReadWriteInitialization>
        public Standing YearInSchool { get; set;} = Standing.Freshman;
        // </ReadWriteInitialization>

        // <FullNameExpressionMember>
        public string FullName => $"{FirstName} {LastName}";
        // </FullNameExpressionMember>

        // <ToStringExpressionMember>
        public override string ToString() => $"{LastName}, {FirstName}";
        // </ToStringExpressionMember>

        // <stringInterpolationExpression>
        public string GetFormattedGradePoint() =>
            $"Name: {LastName}, {FirstName}. G.P.A: {Grades.Average()}";
        // </stringInterpolationExpression>

        // <stringInterpolationFormat>
        public string GetGradePointPercentage() =>
            $"Name: {LastName}, {FirstName}. G.P.A: {Grades.Average():F2}";
        // </stringInterpolationFormat>

        // <stringInterpolationConditional>            
        public string GetGradePointPercentages() =>
            $"Name: {LastName}, {FirstName}. G.P.A: {(Grades.Any() ? Grades.Average() : double.NaN):F2}";
        // </stringInterpolationConditional>
        
        // <UsingStaticLinkMethod>
        public bool MakesDeansList()
        {
            return Grades.All(g => g > 3.5) && Grades.Any();
            // Code below generates CS0103: 
            // The name 'All' does not exist in the current context.
            //return All(Grades, g => g > 3.5) && Grades.Any();
        }
        // </UsingStaticLinkMethod>

        // <stringInterpolationLinq>
        public string GetAllGrades() =>
            $@"All Grades: {Grades.OrderByDescending(g => g)
            .Select(s => s.ToString("F2")).Aggregate((partial, element) => $"{partial}, {element}")}";
        // </stringInterpolationLinq>
    }
}
