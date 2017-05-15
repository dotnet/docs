using System;
using System.IO;

namespace FromFileTime
{
	class Class1
	{
		static void Main(string[] args)
		{			
			System.Console.WriteLine("Enter a file's path");
			string filePath = System.Console.ReadLine();
			System.IO.FileInfo fInfo;
			try {
				fInfo = new System.IO.FileInfo(filePath);
			}
			catch {
				System.Console.WriteLine("Error opening {0}", filePath);
				return;
			}
			long fileTime = System.Convert.ToInt64(fInfo.CreationTime.ToFileTime());
			Class1 theApp = new Class1();
			System.TimeSpan fileAge = theApp.FileAge(fileTime);
			System.Console.WriteLine("{0}", fileAge);
		}

		// This function takes a file's creation time as an unsigned long,
		// and returns its age.
		//<Snippet1>
		public System.TimeSpan FileAge(long fileCreationTime) {

			System.DateTime now = System.DateTime.Now;
			try {
				System.DateTime fCreationTime = 
					System.DateTime.FromFileTime(fileCreationTime);
				System.TimeSpan fileAge = now.Subtract(fCreationTime);
				return fileAge;				
			} 
			catch (ArgumentOutOfRangeException) {
				// fileCreationTime is not valid, so re-throw the exception.
				throw;
			}
		}
		//</Snippet1>
	}
}
