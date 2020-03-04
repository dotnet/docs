using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace Classic_WebData_OdbcErrorCS
{
	class Program
	{
		static void Main()
		{
			//DisplayOdbcErrorCollection();
		}

		// <Snippet1>
		public void DisplayOdbcErrorCollection(OdbcException exception)
		{
			for (int i = 0; i < exception.Errors.Count; i++)
			{
				Console.WriteLine("Index #" + i + "\n" +
					"Message: " + exception.Errors[i].Message + "\n" +
					"Native: " + exception.Errors[i].NativeError.ToString() + "\n" +
					"Source: " + exception.Errors[i].Source + "\n" +
					"SQL: " + exception.Errors[i].SQLState + "\n");
			}
			Console.ReadLine();
		}
		// </Snippet1>
	}
}
