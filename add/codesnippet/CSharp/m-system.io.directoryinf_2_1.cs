// Create a DirectoryInfo of the directory of the files to enumerate.
DirectoryInfo DirInfo = new DirectoryInfo(@"\\archives1\library\");

DateTime StartOf2009 = new DateTime(2009, 01, 01);

// LINQ query for all files created before 2009.
var files = from f in DirInfo.EnumerateFiles()
		   where f.CreationTimeUtc < StartOf2009
		   select f;

// Show results.
foreach (var f in files)
{
	Console.WriteLine("{0}", f.Name);
}