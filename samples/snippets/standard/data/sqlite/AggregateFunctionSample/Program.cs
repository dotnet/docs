using System;
using Microsoft.Data.Sqlite;

namespace AggregateFunctionSample
{
    class Program
    {
        static void Main()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var createCommand = connection.CreateCommand();
            createCommand.CommandText =
            @"
                CREATE TABLE student (
                    gpa REAL
                );

                INSERT INTO student
                VALUES (4.0),
                       (3.0),
                       (3.0),
                       (2.0),
                       (2.0),
                       (2.0),
                       (2.0),
                       (1.0),
                       (1.0),
                       (0.0);
            ";
            createCommand.ExecuteNonQuery();

            #region snippet_CreateAggregate
            connection.CreateAggregate(
                "stdev",

                // A tuple to maintain context between rows
                (Count: 0, Sum: 0.0, SumOfSquares: 0.0),

                // This is called for each row
                ((int Count, double Sum, double SumOfSquares) context, double value) =>
                {
                    context.Count++;
                    context.Sum += value;
                    context.SumOfSquares += value * value;

                    return context;
                },

                // This is called to get the final result
                context =>
                {
                    var variance = context.SumOfSquares - context.Sum * context.Sum / context.Count;

                    return Math.Sqrt(variance / context.Count);
                });

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT stdev(gpa)
                FROM student
            ";
            var stdDev = command.ExecuteScalar();
            #endregion

            Console.WriteLine($"Standard deviation: {stdDev}");
        }
    }
}
