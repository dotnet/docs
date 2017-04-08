' <Snippet1>
'Beginning of the HighSchool.dll 
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic
' Imports HighSchool

Namespace HighSchool

    Public Class Student
        Public Name As String
        Public ID As Integer
    End Class 'Student


    Public Class ClassRoom
        Public Students() As Student
    End Class 'ClassRoom
End Namespace 'HighSchool

Namespace College
    Public Class Graduate
        Inherits HighSchool.Student

        Public Sub New()
        End Sub 'New
        ' Add a new field named University.
        Public University As String
        ' Use extra types to use this field.
        Public Info() As Object
    End Class 'Graduate


    Public Class Address
        Public City As String
    End Class 'Address


    Public Class Phone
        Public Number As String
    End Class 'Phone


    Public Class Run

        Public Shared Sub Main()
            Dim test As New Run()
            test.WriteOverriddenAttributes("College.xml")
            test.ReadOverriddenAttributes("College.xml")
        End Sub 'Main


        Private Sub WriteOverriddenAttributes(ByVal filename As String)
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
            attrOverrides.Add(GetType(HighSchool.ClassRoom), "Students", attrs)

            ' Create array of extra types.
            Dim extraTypes(1) As Type
            extraTypes(0) = GetType(Address)
            extraTypes(1) = GetType(Phone)

            ' Create an XmlRootAttribute.
            Dim root As New XmlRootAttribute("Graduates")

            ' Create the XmlSerializer with the
            ' XmlAttributeOverrides object. 
            Dim mySerializer As New XmlSerializer(GetType(HighSchool.ClassRoom), _
                attrOverrides, extraTypes, root, "http://www.microsoft.com")

            Dim oMyClass As New HighSchool.ClassRoom()

            Dim g1 As New Graduate()
            g1.Name = "Jacki"
            g1.ID = 1
            g1.University = "Alma"

            Dim g2 As New Graduate()
            g2.Name = "Megan"
            g2.ID = 2
            g2.University = "CM"

            Dim myArray As HighSchool.Student() = {g1, g2}

            oMyClass.Students = myArray

            ' Create extra information.
            Dim a1 As New Address()
            a1.City = "Ionia"
            Dim a2 As New Address()
            a2.City = "Stamford"
            Dim p1 As New Phone()
            p1.Number = "555-0101"
            Dim p2 As New Phone()
            p2.Number = "555-0100"

            Dim o1() As Object = {a1, p1}
            Dim o2() As Object = {a2, p2}

            g1.Info = o1
            g2.Info = o2
            mySerializer.Serialize(myStreamWriter, oMyClass)
            myStreamWriter.Close()
        End Sub 'WriteOverriddenAttributes


        Private Sub ReadOverriddenAttributes(ByVal filename As String)
            ' The majority of the code here is the same as that in the
            ' WriteOverriddenAttributes method. Because the XML being read
            ' doesn't conform to the schema defined by the DLL, the
            ' XMLAttributesOverrides must be used to create an
            ' XmlSerializer instance to read the XML document.

            Dim attrOverrides As New XmlAttributeOverrides()
            Dim attrs As New XmlAttributes()
            Dim attr As New XmlElementAttribute("Alumni", GetType(Graduate))
            attrs.XmlElements.Add(attr)
            attrOverrides.Add(GetType(HighSchool.ClassRoom), "Students", attrs)

            Dim extraTypes(1) As Type
            extraTypes(0) = GetType(Address)
            extraTypes(1) = GetType(Phone)

            Dim root As New XmlRootAttribute("Graduates")

            Dim readSerializer As New XmlSerializer(GetType(HighSchool.ClassRoom), _
                attrOverrides, extraTypes, root, "http://www.microsoft.com")

            ' A FileStream object is required to read the file. 
            Dim fs As New FileStream(filename, FileMode.Open)

            Dim oMyClass As HighSchool.ClassRoom
            oMyClass = CType(readSerializer.Deserialize(fs), HighSchool.ClassRoom)

            ' Here is the difference between reading and writing an
            ' XML document: You must declare an object of the derived
            ' type (Graduate) and cast the Student instance to it.
            Dim g As Graduate
            Dim a As Address
            Dim p As Phone
            Dim grad As Graduate
            For Each grad In oMyClass.Students
                g = CType(grad, Graduate)
                Console.Write((g.Name & ControlChars.Tab))
                Console.Write((g.ID & ControlChars.Tab))
                Console.Write((g.University & ControlChars.Cr))
                a = CType(g.Info(0), Address)
                Console.WriteLine(a.City)
                p = CType(g.Info(1), Phone)
                Console.WriteLine(p.Number)
            Next grad
        End Sub 'ReadOverriddenAttributes
    End Class 'Run
End Namespace 'College
' </Snippet1>
