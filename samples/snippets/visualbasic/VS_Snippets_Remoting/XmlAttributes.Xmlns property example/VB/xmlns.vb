'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
 
Public Class Student
   <XmlAttributeAttribute()> _
   Public Name As String

   <XmlNamespaceDeclarationsAttribute()> _   
   Public myNamespaces As XmlSerializerNamespaces
End Class 'Student
 

Public Class Run
   
   Public Shared Sub Main()
      Dim test As New Run()
      test.SerializeStudent("Student_v.xml")
      test.DeserializeStudent("Student_v.xml")
   End Sub 
   
   
   Public Sub SerializeStudent(filename As String)
      Dim atts As New XmlAttributes()
      ' Set to true to preserve namespaces, or false to ignore them.
      atts.Xmlns = True
      
      Dim xover As New XmlAttributeOverrides()
      ' Add the XmlAttributes and specify the name of 
      ' the element containing namespaces.
      xover.Add(GetType(Student), "myNamespaces", atts)
      ' Create the XmlSerializer using the 
      ' XmlAttributeOverrides object.
      Dim xser As New XmlSerializer(GetType(Student), xover)
      
      Dim myStudent As New Student()
      Dim ns As New XmlSerializerNamespaces()
      ns.Add("myns1", "http://www.cpandl.com")
      ns.Add("myns2", "http://www.cohowinery.com")
      myStudent.myNamespaces = ns
      myStudent.Name = "Student1"
      
      Dim fs As New FileStream(filename, FileMode.Create)
      
      xser.Serialize(fs, myStudent)
      fs.Close()
   End Sub 
       
   Private Sub DeserializeStudent(filename As String)
      Dim atts As New XmlAttributes()
      ' Set to true to preserve namespaces, or false to ignore them.
      atts.Xmlns = True
      
      Dim xover As New XmlAttributeOverrides()
      ' Add the XmlAttributes and specify the name 
      ' of the element containing namespaces.
      xover.Add(GetType(Student), "myNamespaces", atts)
      
      ' Create the XmlSerializer using the 
      ' XmlAttributeOverrides object.
      Dim xser As New XmlSerializer(GetType(Student), xover)
      
      Dim fs As New FileStream(filename, FileMode.Open)
      
      Dim myStudent As Student
      myStudent = CType(xser.Deserialize(fs), Student)
      fs.Close()
      
      ' Use the ToArray method to get an array 
      ' of XmlQualifiedName objects.
      Dim qNames As XmlQualifiedName() = _
           myStudent.myNamespaces.ToArray()
      Dim i As Integer
      For i = 0 To qNames.Length - 1
         Console.WriteLine("{0}:{1}", _
              qNames(i).Name, qNames(i).Namespace)
      Next i
   End Sub 
End Class 
'</snippet1>