using System.Diagnostics;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StandardQueryOperators;
public class QuantifierExamples
{
    private static readonly IEnumerable<Student> students = Sources.Students;

    public static void RunAllSnippets()
    {
        Console.WriteLine("All:");
        AllExample();
        Console.WriteLine("Any:");
        AnyExample();
        Console.WriteLine("Contains:");
        ContainsExample();
    }

    private static void AllExample()
    {
        // <AllQuantifier>
        IEnumerable<string> names = from student in students
                                    where student.Scores.All(score => score > 70)
                                    select $"{student.FirstName} {student.LastName}: {string.Join(", ", student.Scores.Select(s => s.ToString()))}";

        foreach (string name in names)
        {
            Console.WriteLine($"{name}");
        }

        // This code produces the following output:
        //
        // Cesar Garcia: 71, 86, 77, 97
        // Nancy Engström: 75, 73, 78, 83
        // Ifunanya Ugomma: 84, 82, 96, 80
        // </AllQuantifier>
    }

    private static void AnyExample()
    {
        // <AnyQuantifier>
        IEnumerable<string> names = from student in students
                                    where student.Scores.Any(score => score > 95)
                                    select $"{student.FirstName} {student.LastName}: {student.Scores.Max()}";

        foreach (string name in names)
        {
            Console.WriteLine($"{name}");
        }

        // This code produces the following output:
        //
        // Svetlana Omelchenko: 97
        // Cesar Garcia: 97
        // Debra Garcia: 96
        // Ifeanacho Jamuike: 98
        // Ifunanya Ugomma: 96
        // Michelle Caruana: 97
        // Nwanneka Ifeoma: 98
        // Martina Mattsson: 96
        // Anastasiya Sazonova: 96
        // Jesper Jakobsson: 98
        // Max Lindgren: 96
        // </AnyQuantifier>
    }

    private static void ContainsExample()
    {
        // <ContainsQuantifier>
        IEnumerable<string> names = from student in students
                                    where student.Scores.Contains(95)
                                    select $"{student.FirstName} {student.LastName}: {string.Join(", ", student.Scores.Select(s => s.ToString()))}";

        foreach (string name in names)
        {
            Console.WriteLine($"{name}");
        }

        // This code produces the following output:
        //
        // Claire O'Donnell: 56, 78, 95, 95
        // Donald Urquhart: 92, 90, 95, 57
        // </ContainsQuantifier>
    }
}
