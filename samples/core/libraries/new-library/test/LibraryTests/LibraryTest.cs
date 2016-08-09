using Xunit;
using Library;
using System;

public class LibraryTest
{
	[Fact]
	public void HelloTest()
	{
		string expected = "Hello, .NET Core!";
		
		string actual = NewLibrary.Hello;
		
		Assert.Equal(expected, actual);
	}
	
	[Fact]
	public void ImportantMessageTest()
	{
		string expected = "Live long and prosper, Captain Kirk!";
		
		string actual = NewLibrary.GenerateImportantMessage("Captain Kirk");
		
		Assert.Equal(expected, actual);
	}
}