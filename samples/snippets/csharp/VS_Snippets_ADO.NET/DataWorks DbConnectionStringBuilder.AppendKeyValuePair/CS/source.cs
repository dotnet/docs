using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace ConBuilderAppendKeyCS
{
    class Program
    {
        static void Main()
        {
        }
        // <Snippet1>
        public string AddPooling(string connectionString)
        {
            StringBuilder builder = new StringBuilder(connectionString);
            DbConnectionStringBuilder.AppendKeyValuePair(builder, "Pooling", "true");
            return builder.ToString();
        }
        // </Snippet1>
    }
}
