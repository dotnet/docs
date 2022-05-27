using Xunit;
using static LinqSamples.Test.Shared;

namespace LinqSamples.Test;

public class GroupJoinsTest
{
    [Fact]
    public void GroupJoins1Test()
    {
        var sw = InitTest();

        GroupJoins.GroupJoin1();
        Assert.Equal(
@"Magnus:
  Daisy
Terry:
  Barley
  Boots
  Blue Moon
Charlotte:
  Whiskers
Arlene:
", sw.ToString());
    }

    [Fact]
    public void GroupJoinXmlTest()
    {
        var sw = InitTest();

        GroupJoins.GroupJoinXml();
        Assert.Equal(
@"<PetOwners>
  <Person FirstName=""Magnus"" LastName=""Hedlund"">
    <Pet>Daisy</Pet>
  </Person>
  <Person FirstName=""Terry"" LastName=""Adams"">
    <Pet>Barley</Pet>
    <Pet>Boots</Pet>
    <Pet>Blue Moon</Pet>
  </Person>
  <Person FirstName=""Charlotte"" LastName=""Weiss"">
    <Pet>Whiskers</Pet>
  </Person>
  <Person FirstName=""Arlene"" LastName=""Huff"" />
</PetOwners>
", sw.ToString());
    }
}
