using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace Classic_WebData_OdbcError.ToStringCS
{
	class Program
	{
		static void Main()
		{
			//DisplayOdbcErrors();
		}

		// <Snippet1>
		public void DisplayOdbcErrors(OdbcException exception)
		{
			for (int i = 0; i < exception.Errors.Count; i++)
			{
				Console.WriteLine("Index #" + i + "\n" +
					"Error: " + exception.Errors[i].ToString() + "\n");
			}
			Console.ReadLine();
		}
		// </Snippet1>
	}
}
