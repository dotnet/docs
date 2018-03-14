using System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Classic_WebData_SqlError.StateCS
{
	class Program
	{
		static void Main()
		{
			//DisplaySqlErrors();
		}

		// <Snippet1>
		public void DisplaySqlErrors(SqlException exception)
		{
			for (int i = 0; i < exception.Errors.Count; i++)
			{
				Console.WriteLine("Index #" + i + "\n" +
					"Source: " + exception.Errors[i].Source + "\n" +
					"Number: " + exception.Errors[i].Number.ToString() + "\n" +
					"State: " + exception.Errors[i].State.ToString() + "\n" +
					"Class: " + exception.Errors[i].Class.ToString() + "\n" +
					"Server: " + exception.Errors[i].Server + "\n" +
					"Message: " + exception.Errors[i].Message + "\n" +
					"Procedure: " + exception.Errors[i].Procedure + "\n" +
					"LineNumber: " + exception.Errors[i].LineNumber.ToString());
			}
			Console.ReadLine();
		}
		// </Snippet1>
	}
}
