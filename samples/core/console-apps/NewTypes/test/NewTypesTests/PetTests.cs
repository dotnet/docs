using System;
using Xunit;
using Pets;

public class PetTests
{
	[Fact]
	public void DogTalkToOwnerTest()
	{
		string expected = "Woof!";
		string actual = new Dog().TalkToOwner();
		
		Assert.Equal(expected, actual);
	}
	
	[Fact]
	public void CatTalkToOwnerTest()
	{
		string expected = "Meow!";
		string actual = new Cat().TalkToOwner();
		
		Assert.Equal(expected, actual);
	}
}