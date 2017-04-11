using System;
using System.Security;


public class SecurityElementTest
{
    private SecurityElement xmlRootElement;

    public SecurityElementTest()
    {
        xmlRootElement = new SecurityElement("thetag", " ");

        xmlRootElement.AddAttribute("a", "123");
        xmlRootElement.AddAttribute("b", "456");
        xmlRootElement.AddAttribute("c", "789");

        xmlRootElement.AddChild(new SecurityElement("first", "text1"));
        xmlRootElement.AddChild(new SecurityElement("second", "text2"));
    }

    // <Snippet1>
    string SearchForTextOfTag(string tag)
    {
        SecurityElement element = this.SearchForChildByTag(tag);
        return element.Text;
    }
    // </Snippet1>

    private SecurityElement SearchForChildByTag(string tag)
    {
        return xmlRootElement.SearchForChildByTag(tag);
    }

    public static void Main()
    {
        SecurityElementTest seTest = new SecurityElementTest();

        Console.WriteLine("Found the text for <second>: " + seTest.SearchForTextOfTag("second"));
    }
}