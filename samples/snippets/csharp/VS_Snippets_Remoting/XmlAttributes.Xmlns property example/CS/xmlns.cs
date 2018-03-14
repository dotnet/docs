//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization; 

public class Student
{
    [XmlAttributeAttribute]
    public string Name;

    [XmlNamespaceDeclarationsAttribute]
    public XmlSerializerNamespaces myNamespaces;

}
    
public class Run
{
    public static void Main()
    {
        Run test = new Run();
        test.SerializeStudent("Student.xml");
        test.DeserializeStudent("Student.xml");
    }

    public void SerializeStudent(string filename)
    {
        XmlAttributes atts = new XmlAttributes();
        // Set to true to preserve namespaces, 
	// or false to ignore them.
        atts.Xmlns=true;

        XmlAttributeOverrides xover = new XmlAttributeOverrides();
        // Add the XmlAttributes and specify the name of the element 
	// containing namespaces.
        xover.Add(typeof(Student),"myNamespaces", atts);
        // Create the XmlSerializer using the 
		// XmlAttributeOverrides object.
        XmlSerializer xser = new XmlSerializer(typeof (Student),xover);

        Student myStudent = new Student();
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("myns1", "http://www.cpandl.com");
        ns.Add("myns2", "http://www.cohowinery.com");
        myStudent.myNamespaces= ns;
        myStudent.Name= "Student1";

        FileStream fs = new FileStream(filename,FileMode.Create);

        xser.Serialize(fs,myStudent);
        fs.Close();

    }

    private void DeserializeStudent(string filename)
    {
        XmlAttributes atts = new XmlAttributes();
        // Set to true to preserve namespaces, or false to ignore them.
        atts.Xmlns=true;

        XmlAttributeOverrides xover = new XmlAttributeOverrides();
        // Add the XmlAttributes and specify the name of the 
        // element containing namespaces.
        xover.Add(typeof(Student),"myNamespaces", atts);

        // Create the XmlSerializer using the 
        // XmlAttributeOverrides object.
        XmlSerializer xser = 
        new XmlSerializer(typeof (Student),xover);

        FileStream fs = new FileStream(filename,FileMode.Open);

        Student myStudent;
        myStudent= (Student) xser.Deserialize(fs);
        fs.Close();

        // Use the ToArray method to get an array of 
        // XmlQualifiedName objects.
        XmlQualifiedName[] qNames= myStudent.myNamespaces.ToArray();
        for(int i = 0; i < qNames.Length;i++)
        {
            Console.WriteLine("{0}:{1}", 
	    qNames[i].Name,qNames[i].Namespace);
        }
    }
}
//</snippet1>