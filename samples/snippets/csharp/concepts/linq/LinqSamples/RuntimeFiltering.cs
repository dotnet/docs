using static LinqSamples.Student;

namespace LinqSamples;

public static class RuntimeFiltering
{
    public static void RuntimeFiltering1()
    {
        // <runtime_filtering_1>
        int[] ids = [111, 114, 112];

        var queryNames =
            from student in students
            where ids.Contains(student.ID)
            select new
            {
                student.LastName,
                student.ID
            };

        foreach (var name in queryNames)
        {
            Console.WriteLine($"{name.LastName}: {name.ID}");
        }

        /* Output:
            Garcia: 114
            O'Donnell: 112
            Omelchenko: 111
         */

        // Change the ids.
        ids = [122, 117, 120, 115];

        // The query will now return different results
        foreach (var name in queryNames)
        {
            Console.WriteLine($"{name.LastName}: {name.ID}");
        }

        /* Output:
            Adams: 120
            Feng: 117
            Garcia: 115
            Tucker: 122
         */
        // </runtime_filtering_1>
    }

    public static void RuntimeFiltering2()
    {
        // <runtime_filtering_2>
        void FilterByYearType(bool oddYear)
        {
            IEnumerable<Student> studentQuery;
            if (oddYear)
            {
                studentQuery =
                    from student in students
                    where student.Year == GradeLevel.FirstYear || student.Year == GradeLevel.ThirdYear
                    select student;
            }
            else
            {
                studentQuery =
                    from student in students
                    where student.Year == GradeLevel.SecondYear || student.Year == GradeLevel.FourthYear
                    select student;
            }

            string descr = oddYear ? "odd" : "even";
            Console.WriteLine($"The following students are at an {descr} year level:");
            foreach (Student name in studentQuery)
            {
                Console.WriteLine($"{name.LastName}: {name.ID}");
            }
        }

        FilterByYearType(true);

        /* Output:
            The following students are at an odd year level:
            Fakhouri: 116
            Feng: 117
            Garcia: 115
            Mortensen: 113
            Tucker: 119
            Tucker: 122
         */

        FilterByYearType(false);

        /* Output:
            The following students are at an even year level:
            Adams: 120
            Garcia: 114
            Garcia: 118
            O'Donnell: 112
            Omelchenko: 111
            Zabokritski: 121
         */
        // </runtime_filtering_2>
    }
}
