using System;
using DependencyLibrary;

namespace Library
{
	public static class NewLibrary
	{
		public static string Hello => "Hello, .NET Core!";
		
		public static string GenerateImportantMessage(string name) =>
			$"{NewDependencyLibrary.ImportantMessage}, {name}!";
	}
}