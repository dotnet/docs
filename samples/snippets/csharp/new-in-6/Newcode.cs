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

        // <FullNameExpressionMember>
        public string FullName => $"{FirstName} {LastName}";
        // </FullNameExpressionMember>

        // <ToStringExpressionMember>
        public override string ToString() => $"{LastName}, {FirstName}";
        // </ToStringExpressionMember>

        // <stringInterpolationFormat>
        public string GetGradePointPercentage() =>
            $"Name: {LastName}, {FirstName}. G.P.A: {Grades.Average():F2}";
        // </stringInterpolationFormat>
    }
}
