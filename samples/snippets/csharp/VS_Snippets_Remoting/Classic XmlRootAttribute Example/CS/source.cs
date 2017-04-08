// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

[XmlRoot(Namespace = "www.contoso.com", 
     ElementName = "MyGroupName", 
     DataType = "string", 
     IsNullable=true)]
public class Group
{
    private string groupNameValue;
    // Insert code for the Group class.
    public Group()
    {
    }
 
    public Group(string groupNameVal)
    {
        groupNameValue = groupNameVal;
    }
 
    public string GroupName
    {
        get{return groupNameValue;}
        set{groupNameValue = value;}
    }
}
public class Test
{
    static void Main()
    {
        Test t = new Test();
        t.SerializeGroup();
    }
 
    private void SerializeGroup()
    {
        // Create an instance of the Group class, and an
        // instance of the XmlSerializer to serialize it.
        Group myGroup = new Group("Redmond");
        XmlSerializer ser = new XmlSerializer(typeof(Group));
        // A FileStream is used to write the file.
        FileStream fs = new FileStream("group.xml",FileMode.Create);
        ser.Serialize(fs,myGroup);
        fs.Close();
        Console.WriteLine(myGroup.GroupName);
        Console.WriteLine("Done");
        Console.ReadLine();
    }
}
// </Snippet1>
 

