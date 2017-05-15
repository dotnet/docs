' <Snippet1>
Imports System
Imports System.Xml.Serialization
Imports System.IO


Public Class Group1
   ' The XmlTextAttribute with type set to String informs the 
   ' XmlSerializer that strings should be serialized as XML text.
   <XmlText(GetType(String)), _
   XmlElement(GetType(integer)), _  
   XmlElement(GetType(double))> _
   public All () As Object = _
   New Object (){321, "One", 2, 3.0, "Two" }
End Class


Public Class Group2
   <XmlText(GetType(GroupType))> _
   public Type As GroupType 
End Class

Public Enum GroupType
   Small
   Medium
   Large
End Enum

Public Class Group3
   <XmlText(GetType(DateTime))> _
   Public CreationTime As DateTime = DateTime.Now
End Class

Public Class Test
   Shared Sub Main()
      Dim t As Test = New Test()
      t.SerializeArray("XmlText1.xml")
      t.SerializeEnum("XmlText2.xml")
      t.SerializeDateTime("XmlText3.xml")
   End Sub

   Private Sub SerializeArray(filename As String)
      Dim ser As XmlSerializer = New XmlSerializer(GetType(Group1))
      Dim myGroup1 As Group1 = New Group1()

      Dim writer As TextWriter = New StreamWriter(filename)

      ser.Serialize(writer, myGroup1)
      writer.Close()
   End Sub

   Private Sub SerializeEnum(filename As String)
      Dim ser As XmlSerializer = New XmlSerializer(GetType(Group2))
      Dim myGroup As Group2 = New Group2()
      myGroup.Type = GroupType.Medium
      Dim writer As TextWriter = New StreamWriter(filename)

      ser.Serialize(writer, myGroup)
      writer.Close()
   End Sub

   Private Sub SerializeDateTime(filename As String)
      Dim ser As XmlSerializer = new XmlSerializer(GetType(Group3))
      Dim myGroup As Group3 = new Group3()
      Dim writer As TextWriter = new StreamWriter(filename)

      ser.Serialize(writer, myGroup)
      writer.Close()
   End Sub
End Class
' </Snippet1>

