using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace builtin_types
{
    public static class RecordType
    {
        public static void Examples()
        {
            instantiatepositional.Example.Main();
            positionalwithmanualproperty.Example.Main();
            shallowimmutability.Example.Main();
            equality.Example.Main();
            withexpressions.Example.Main();
            recordinheritancetostringdefault.Example.Main();
            recordinheritancepositional.Example.Main();
            recordinheritanceequality.Example.Main();
            recordinheritancewithexpression.Example.Main();
            recordinheritancetostring.Example.Main();
            recordinheritanceprintmembers.Example.Main();
            recordinheritancedeconstructor.Example.Main();

            var p = new Point();
            (double x, double y, double z) = p;

        }
        // <PositionalRecord>
        public record Person(string FirstName, string LastName);
        // </PositionalRecord>

        // <PositionalRecordStruct>
        public readonly record struct Point(double X, double Y, double Z);
        // </PositionalRecordStruct>
    }

    public static class ImmutableRecordType
    {
        // <ImmutableRecord>
        public record Person
        {
            public string FirstName { get; init; } = default!;
            public string LastName { get; init; } = default!;
        };
        // </ImmutableRecord>

        // <ImmutableRecordStruct>
        public record struct Point
        {
            public double X {  get; init; }
            public double Y {  get; init; }
            public double Z {  get; init; }
        }
        // </ImmutableRecordStruct>
    }

    public static class MutableRecordType
    {
        // <MutableRecord>
        public record Person
        {
            public string FirstName { get; set; } = default!;
            public string LastName { get; set; } = default!;
        };
        // </MutableRecord>

        // <MutablePositionalRecordStruct>
        public record struct DataMeasurement(DateTime TakenAt, double Measurement);
        // </MutablePositionalRecordStruct>


        // <MutableRecordStruct>
        public record struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
        }
        // </MutableRecordStruct>
    }

    public static class MixedSyntax
    {
        // <MixedSyntax>
        public record Person(string FirstName, string LastName)
        {
            public string[] PhoneNumbers { get; init; } = Array.Empty<string>();
        };
        // </MixedSyntax>
    }

    public static class PositionalAttributes
    {
        // <PositionalAttributes>
        /// <summary>
        /// Person record type
        /// </summary>
        /// <param name="FirstName">First Name</param>
        /// <param name="LastName">Last Name</param>
        /// <remarks>
        /// The person type is a positional record containing the
        /// properties for the first and last name. Those properties
        /// map to the JSON elements "firstName" and "lastName" when
        /// serialized or deserialized.
        /// </remarks>
        public record Person([property: JsonPropertyName("firstName")]string FirstName, 
            [property: JsonPropertyName("lastName")]string LastName);
        // </PositionalAttributes>

    }

    namespace instantiatepositional
    {
        public static class Example
        {
            // <InstantiatePositional>
            public record Person(string FirstName, string LastName);

            public static void Main()
            {
                Person person = new("Nancy", "Davolio");
                Console.WriteLine(person);
                // output: Person { FirstName = Nancy, LastName = Davolio }
            }
            // </InstantiatePositional>
        }
    }

    namespace positionalwithmanualproperty
    {
        public static class Example
        {
            // <PositionalWithManualProperty>
            public record Person(string FirstName, string LastName, string Id)
            {
                internal string Id { get; init; } = Id;
            }

            public static void Main()
            {
                Person person = new("Nancy", "Davolio", "12345");
                Console.WriteLine(person.FirstName); //output: Nancy

            }
            // </PositionalWithManualProperty>
        }
    }

    namespace shallowimmutability
    {
        public static class Example
        {
            // <ShallowImmutability>
            public record Person(string FirstName, string LastName, string[] PhoneNumbers);

            public static void Main()
            {
                Person person = new("Nancy", "Davolio", new string[1] { "555-1234" });
                Console.WriteLine(person.PhoneNumbers[0]); // output: 555-1234

                person.PhoneNumbers[0] = "555-6789";
                Console.WriteLine(person.PhoneNumbers[0]); // output: 555-6789
            }
            // </ShallowImmutability>
        }
    }
    namespace equality
    {
        public static class Example
        {
            // <Equality>
            public record Person(string FirstName, string LastName, string[] PhoneNumbers);

            public static void Main()
            {
                var phoneNumbers = new string[2];
                Person person1 = new("Nancy", "Davolio", phoneNumbers);
                Person person2 = new("Nancy", "Davolio", phoneNumbers);
                Console.WriteLine(person1 == person2); // output: True

                person1.PhoneNumbers[0] = "555-1234";
                Console.WriteLine(person1 == person2); // output: True

                Console.WriteLine(ReferenceEquals(person1, person2)); // output: False
            }
            // </Equality>
        }
    }

    namespace withexpressions
    {
        public static class Example
        {
            // <WithExpressions>
            public record Person(string FirstName, string LastName)
            {
                public string[] PhoneNumbers { get; init; }
            }

            public static void Main()
            {
                Person person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[1] };
                Console.WriteLine(person1);
                // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }

                Person person2 = person1 with { FirstName = "John" };
                Console.WriteLine(person2);
                // output: Person { FirstName = John, LastName = Davolio, PhoneNumbers = System.String[] }
                Console.WriteLine(person1 == person2); // output: False

                person2 = person1 with { PhoneNumbers = new string[1] };
                Console.WriteLine(person2);
                // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }
                Console.WriteLine(person1 == person2); // output: False

                person2 = person1 with { };
                Console.WriteLine(person1 == person2); // output: True
            }
            // </WithExpressions>
        }
    }

    namespace recordinheritancepositional
    {
        public static class Example
        {
            // <PositionalInheritance>
            public abstract record Person(string FirstName, string LastName);
            public record Teacher(string FirstName, string LastName, int Grade)
                : Person(FirstName, LastName);
            public static void Main()
            {
                Person teacher = new Teacher("Nancy", "Davolio", 3);
                Console.WriteLine(teacher);
                // output: Teacher { FirstName = Nancy, LastName = Davolio, Grade = 3 }
            }
            // </PositionalInheritance>
        }
    }

    namespace recordinheritanceequality
    {
        public static class Example
        {
            // <InheritanceEquality>
            public abstract record Person(string FirstName, string LastName);
            public record Teacher(string FirstName, string LastName, int Grade)
                : Person(FirstName, LastName);
            public record Student(string FirstName, string LastName, int Grade)
                : Person(FirstName, LastName);
            public static void Main()
            {
                Person teacher = new Teacher("Nancy", "Davolio", 3);
                Person student = new Student("Nancy", "Davolio", 3);
                Console.WriteLine(teacher == student); // output: False

                Student student2 = new Student("Nancy", "Davolio", 3);
                Console.WriteLine(student2 == student); // output: True
            }
            // </InheritanceEquality>
        }
    }

    namespace recordinheritancetostringdefault
    {
        public static class Example
        {
            public abstract record Person(string FirstName, string LastName, string[] PhoneNumbers);
            public record Teacher(string FirstName, string LastName, string[] PhoneNumbers, int Grade)
                : Person(FirstName, LastName, PhoneNumbers)
            {
                // <ToStringOverrideDefault>
                public override string ToString()
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("Teacher"); // type name
                    stringBuilder.Append(" { ");
                    if (PrintMembers(stringBuilder))
                    {
                        stringBuilder.Append(" ");
                    }
                    stringBuilder.Append("}");
                    return stringBuilder.ToString();
                }
                // </ToStringOverrideDefault>
            };

            public static void Main()
            {
                Person teacher = new Teacher("Nancy", "Davolio", new string[2] { "555-1234", "555-6789" }, 3);
                Console.WriteLine(teacher);
            }
        }
    }

    namespace recordinheritanceprintmembers
    {
        public static class Example
        {
            // <PrintMembersImplementation>
            public abstract record Person(string FirstName, string LastName, string[] PhoneNumbers)
            {
                protected virtual bool PrintMembers(StringBuilder stringBuilder)
                {
                    stringBuilder.Append($"FirstName = {FirstName}, LastName = {LastName}, ");
                    stringBuilder.Append($"PhoneNumber1 = {PhoneNumbers[0]}, PhoneNumber2 = {PhoneNumbers[1]}");
                    return true;
                }
            }

            public record Teacher(string FirstName, string LastName, string[] PhoneNumbers, int Grade)
                : Person(FirstName, LastName, PhoneNumbers)
            {
                protected override bool PrintMembers(StringBuilder stringBuilder)
                {
                    if (base.PrintMembers(stringBuilder))
                    {
                        stringBuilder.Append(", ");
                    };
                    stringBuilder.Append($"Grade = {Grade}");
                    return true;
                }
            };

            public static void Main()
            {
                Person teacher = new Teacher("Nancy", "Davolio", new string[2] { "555-1234", "555-6789" }, 3);
                Console.WriteLine(teacher);
                // output: Teacher { FirstName = Nancy, LastName = Davolio, PhoneNumber1 = 555-1234, PhoneNumber2 = 555-6789, Grade = 3 }
            }
            // </PrintMembersImplementation>
        }
    }

    namespace recordinheritancetostring
    {
        public static class Example
        {
            // <ToStringInheritance>
            public abstract record Person(string FirstName, string LastName);
            public record Teacher(string FirstName, string LastName, int Grade)
                : Person(FirstName, LastName);
            public record Student(string FirstName, string LastName, int Grade)
                : Person(FirstName, LastName);

            public static void Main()
            {
                Person teacher = new Teacher("Nancy", "Davolio", 3);
                Console.WriteLine(teacher);
                // output: Teacher { FirstName = Nancy, LastName = Davolio, Grade = 3 }
            }
            // </ToStringInheritance>
        }
    }

    namespace recordinheritancedeconstructor
    {
        public static class Example
        {
            // <DeconstructorInheritance>
            public abstract record Person(string FirstName, string LastName);
            public record Teacher(string FirstName, string LastName, int Grade)
                : Person(FirstName, LastName);
            public record Student(string FirstName, string LastName, int Grade)
                : Person(FirstName, LastName);

            public static void Main()
            {
                Person teacher = new Teacher("Nancy", "Davolio", 3);
                var (firstName, lastName) = teacher; // Doesn't deconstruct Grade
                Console.WriteLine($"{firstName}, {lastName}");// output: Nancy, Davolio

                var (fName, lName, grade) = (Teacher)teacher;
                Console.WriteLine($"{fName}, {lName}, {grade}");// output: Nancy, Davolio, 3
            }
            // </DeconstructorInheritance>
        }
    }

    namespace recordinheritancewithexpression
    {
        public static class Example
        {
            // <WithExpressionInheritance>
            public record Point(int X, int Y)
            {
                public int Zbase { get; set; }
            };
            public record NamedPoint(string Name, int X, int Y) : Point(X, Y)
            {
                public int Zderived { get; set; }
            };

            public static void Main()
            {
                Point p1 = new NamedPoint("A", 1, 2) { Zbase = 3, Zderived = 4 };

                Point p2 = p1 with { X = 5, Y = 6, Zbase = 7 }; // Can't set Name or Zderived
                Console.WriteLine(p2 is NamedPoint);  // output: True
                Console.WriteLine(p2);
                // output: NamedPoint { X = 5, Y = 6, Zbase = 7, Name = A, Zderived = 4 }

                Point p3 = (NamedPoint)p1 with { Name = "B", X = 5, Y = 6, Zbase = 7, Zderived = 8 };
                Console.WriteLine(p3);
                // output: NamedPoint { X = 5, Y = 6, Zbase = 7, Name = B, Zderived = 8 }
            }
            // </WithExpressionInheritance>
        }
    }
}
