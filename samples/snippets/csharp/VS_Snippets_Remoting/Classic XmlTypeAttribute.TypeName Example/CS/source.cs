using System;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public class Group {
   public Person[]Staff;
}

[XmlType(TypeName = "Employee",
         Namespace = "http://www.cpandl.com")]
public class Person {
   public string PersonName;
   public Job Position;
}

[XmlType(TypeName = "Occupation", 
         Namespace = "http://www.cohowinery.com")]
public class Job {
   public string JobName;
}

// </Snippet1>
