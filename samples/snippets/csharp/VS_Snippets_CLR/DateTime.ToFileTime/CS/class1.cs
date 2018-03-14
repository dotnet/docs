using System;

namespace ToFileTime
{
	class Class1
	{
		//<Snippet1>
		static void Main(string[] args)
		{
			System.Console.WriteLine("Enter the file path:");
			string filePath = System.Console.ReadLine();

			if (System.IO.File.Exists(filePath)) {
				System.DateTime fileCreationDateTime = 
					System.IO.File.GetCreationTime(filePath);

				long fileCreationFileTime = fileCreationDateTime.ToFileTime();

				System.Console.WriteLine("{0} in file time is {1}.",
										 fileCreationDateTime,
										 fileCreationFileTime);
			} 
			else {
				System.Console.WriteLine("{0} is an invalid file", filePath);
			}
		}
		//</Snippet1>
	}
}
