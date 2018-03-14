' <Snippet1>
' Beginning of HighSchool.dll
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic
Imports HighSchool

Namespace HighSchool
    
    Public Class Student
        Public Name As String
        Public ID As Integer
    End Class 'Student
    
    
    Public Class MyClass1
        Public Students() As Student
    End Class 'MyClass1
End Namespace 'HighSchool

Namespace College
    Public Class Graduate
        Inherits HighSchool.Student
        
        Public Sub New()
        End Sub 'New ' Add a new field named University.
        Public University As String
    End Class 'Graduate
    
    
    
    Public Class Run
        
        Public Shared Sub Main()
            Dim test As New Run()
            test.WriteOverriddenAttributes("College.xml")
            test.ReadOverriddenAttributes("College.xml")
        End Sub 'Main
        
        
        Private Sub WriteOverriddenAttributes(filename As String)
            ' Writing the file requires a TextWriter.
            Dim myStreamWriter As New StreamWriter(filename)
            ' Create an XMLAttributeOverrides class.
            Dim attrOverrides As New XmlAttributeOverrides()
            ' Create the XmlAttributes class.
            Dim attrs As New XmlAttributes()
            
            ' Override the Student class. "Alumni" is the name
            ' of the overriding element in the XML output. 
            Dim attr As New XmlElementAttribute("Alumni", GetType(Graduate))
            
            ' Add the XmlElementAttribute to the collection of
            ' elements in the XmlAttributes object. 
            attrs.XmlElements.Add(attr)
            
            ' Add the XmlAttributes to the XmlAttributeOverrides. 
            ' "Students" is the name being overridden. 
            attrOverrides.Add(GetType(HighSchool.MyClass1), "Students", attrs)
            
            ' Create the XmlSerializer. 
            Dim mySerializer As New XmlSerializer(GetType(HighSchool.MyClass1), attrOverrides)
            
            Dim oMyClass As New MyClass1()
            
            Dim g1 As New Graduate()
            g1.Name = "Jackie"
            g1.ID = 1
            g1.University = "Alma Mater"
            
            Dim g2 As New Graduate()
            g2.Name = "Megan"
            g2.ID = 2
            g2.University = "CM"
            
            Dim myArray As Student() =  {g1, g2}
            oMyClass.Students = myArray
            
            mySerializer.Serialize(myStreamWriter, oMyClass)
            myStreamWriter.Close()
        End Sub 'WriteOverriddenAttributes
        
        
        Private Sub ReadOverriddenAttributes(filename As String)
            ' The majority of the code here is the same as that in the
            ' WriteOverriddenAttributes method. Because the XML being read
            ' doesn't conform to the schema defined by the DLL, the
            ' XMLAttributesOverrides must be used to create an
            ' XmlSerializer instance to read the XML document.
            
            Dim attrOverrides As New XmlAttributeOverrides()
            Dim attrs As New XmlAttributes()
            Dim attr As New XmlElementAttribute("Alumni", GetType(Graduate))
            attrs.XmlElements.Add(attr)
            attrOverrides.Add(GetType(HighSchool.MyClass1), "Students", attrs)
            
            Dim readSerializer As New XmlSerializer(GetType(HighSchool.MyClass1), attrOverrides)
            
            ' To read the file, a FileStream object is required. 
            Dim fs As New FileStream(filename, FileMode.Open)
            
            Dim oMyClass As MyClass1
            
            oMyClass = CType(readSerializer.Deserialize(fs), MyClass1)
            
            ' Here is the difference between reading and writing an
            ' XML document: You must declare an object of the derived
            ' type (Graduate) and cast the Student instance to it.
            Dim g As Graduate
            
            Dim grad As Graduate
            For Each grad In  oMyClass.Students
                g = CType(grad, Graduate)
                Console.Write((g.Name & ControlChars.Tab))
                Console.Write((g.ID.ToString & ControlChars.Tab))
                Console.Write((g.University & ControlChars.Cr))
            Next grad
        End Sub 'ReadOverriddenAttributes
    End Class 'Run
End Namespace 'College
' </Snippet1>
