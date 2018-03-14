using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

public class Example
{
   public static void Main()
   {
      // <Snippet5>
      XmlSerializer xmlSer = new XmlSerializer(typeof(T));
      DataContractSerializer dataSer = new DataContractSerializer(typeof(T));
      DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(T));
      // </Snippet5>
      
      // <Snippet6>
      Type t = typeof(DataSet);
      XmlSerializer ser = new XmlSerializer(t);
      // </Snippet6>
   }

   public void UsesReflection()
   {
      // <Snippet7>
      XmlSerializer xSerializer = new XmlSerializer(typeof(Teacher), 
                                  new Type[] { typeof(Student), 
                                               typeof(Course), 
                                               typeof(Location) });
      // </Snippet7>
   }
}


public class T
{}

public class DataSet
{}

public class Teacher
{}

public class Student
{}

public class Course
{}

public class Location
{}

