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
}