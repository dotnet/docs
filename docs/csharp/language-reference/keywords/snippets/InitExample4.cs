
// <SnippetClassDefinitions>
class PersonPrivateSet
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public PersonPrivateSet(string first, string last) => (FirstName, LastName) = (first, last);

    public void ChangeName(string first, string last) => (FirstName, LastName) = (first, last);
}

class PersonReadOnly
{
    public string FirstName { get; }
    public string LastName { get; }
    public PersonReadOnly(string first, string last) => (FirstName, LastName) = (first, last);
}

class PersonInit
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
}
// </SnippetClassDefinitions>

public class Usage
{
    public static void Examples()
    {
        // <SnippetUsage>
        PersonPrivateSet personPrivateSet = new("Bill", "Gates");
        PersonReadOnly personReadOnly = new("Bill", "Gates");
        PersonInit personInit = new() { FirstName = "Bill", LastName = "Gates" };
        // </SnippetUsage>
    }
}