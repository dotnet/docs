using System;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Sqlite;

namespace ResultMetadataSample
{
    static class Program
    {
        static string GetDebugString(this DbDataReader reader)
        {
            // This extension method uses GetSchemaTable to create a debug string containing
            // metadata about the query results represented by a data reader.
            #region snippet_ResultMetadata
            var builder = new StringBuilder();
            var schemaTable = reader.GetSchemaTable();

            foreach (DataRow column in schemaTable.Rows)
            {
                if ((bool)column[SchemaTableColumn.IsExpression])
                {
                    builder.Append("(expression)");
                }
                else
                {
                    builder.Append(column[SchemaTableColumn.BaseTableName])
                           .Append(".")
                           .Append(column[SchemaTableColumn.BaseColumnName]);
                }

                builder.Append(" ");

                if ((bool)column[SchemaTableColumn.IsAliased])
                    builder.Append("AS ")
                           .Append(column[SchemaTableColumn.ColumnName])
                           .Append(" ");

                builder.Append(column["DataTypeName"])
                       .Append(" ");

                if (column[SchemaTableColumn.AllowDBNull] as bool? == false)
                    builder.Append("NOT NULL ");

                if (column[SchemaTableColumn.IsKey] as bool? == true)
                    builder.Append("PRIMARY KEY ");

                if (column[SchemaTableOptionalColumn.IsAutoIncrement] as bool? == true)
                    builder.Append("AUTOINCREMENT ");

                if (column[SchemaTableColumn.IsUnique] as bool? == true)
                    builder.Append("UNIQUE ");

                builder.AppendLine();
            }

            var debugString = builder.ToString();
            #endregion

            return debugString;
        }

        static void Main()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var createCommand = connection.CreateCommand();
            createCommand.CommandText =
            @"
                CREATE TABLE post (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    title TEXT NOT NULL UNIQUE,
                    body TEXT
                );
            ";
            createCommand.ExecuteNonQuery();

            var queryCommand = connection.CreateCommand();
            queryCommand.CommandText =
            @"
                SELECT id AS post_id,
                       title,
                       body,
                       random() AS random
                FROM post;
            ";

            using (var reader = queryCommand.ExecuteReader())
            {
                var debugString = reader.GetDebugString();
                Console.WriteLine(debugString);
            }
        }
    }
}
