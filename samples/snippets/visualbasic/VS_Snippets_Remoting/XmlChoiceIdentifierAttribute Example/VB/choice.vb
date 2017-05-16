'<Snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO

Public Class Choices
   ' The MyChoice field can be set to any one of 
   ' the types below. 
   <XmlChoiceIdentifier("EnumType"), _
   XmlElement("Word", GetType(String)), _
   XmlElement("Number", GetType(Integer)), _
   XmlElement("DecimalNumber", GetType(double))> _
   Public MyChoice As Object 

   ' Don't serialize this field. The EnumType field
   ' contains the enumeration value that corresponds
   ' to the MyChoice field value.
   <XmlIgnore> _
   Public EnumType As ItemChoiceType 

   'The ManyChoices field can contain an array
   ' of choices. Each choice must be matched to
   ' an array item in the ChoiceArray field.
   <XmlChoiceIdentifier("ChoiceArray"), _
   XmlElement("Item", GetType(string)), _
   XmlElement("Amount", GetType(Integer)), _
   XmlElement("Temp", GetType(double))> _
   Public ManyChoices() As Object

   ' TheChoiceArray field contains the enumeration
   ' values, one for each item in the ManyChoices array.
   <XmlIgnore> _
   Public ChoiceArray() As MoreChoices
End Class

<XmlType(IncludeInSchema:=false)> _
Public Enum ItemChoiceType
   None
   Word 
   Number
   DecimalNumber
End Enum

<XmlType(IncludeInSchema:=false)> _
Public Enum MoreChoices
   None
   Item
   Amount
   Temp
End Enum

Public Class Test
   Shared Sub Main()
      Dim t  As Test = New Test()
      t.SerializeObject("Choices.xml")
      t.DeserializeObject("Choices.xml")
   End Sub

   private Sub SerializeObject(filename As string)
      Dim mySerializer As XmlSerializer = _
      New XmlSerializer(GetType(Choices))
      Dim writer As TextWriter = New StreamWriter(filename)
      Dim myChoices As Choices = New Choices()

      ' Set the MyChoice field to a string. Set the
      ' EnumType to Word.
      myChoices.MyChoice= "Book"
      myChoices.EnumType = ItemChoiceType.Word

      ' Populate an object array with three items, one
      ' of each enumeration type. Set the array to the 
      ' ManyChoices field.
      Dim strChoices () As Object = New object(){"Food",  5, 98.6}
      myChoices.ManyChoices=strChoices

      ' For each item in the ManyChoices array, add an
      ' enumeration value.
      Dim itmChoices () As MoreChoices = New MoreChoices() _
      {MoreChoices.Item, _
      MoreChoices.Amount, _
      MoreChoices.Temp}
      myChoices.ChoiceArray=itmChoices
      
      mySerializer.Serialize(writer, myChoices)
      writer.Close()
   End Sub

   private Sub DeserializeObject(filename As string)
      Dim ser As XmlSerializer = New XmlSerializer(GetType(Choices))
      

      ' A FileStream is needed to read the XML document.
      Dim fs As FileStream = New FileStream(filename, FileMode.Open)
      
      Dim myChoices As Choices = CType(ser.Deserialize(fs), Choices)

      fs.Close()

      ' Disambiguate the MyChoice value Imports the enumeration.
      if myChoices.EnumType = ItemChoiceType.Word Then
      	   Console.WriteLine("Word: " & _
      	   myChoices.MyChoice.ToString())
      	
      else if myChoices.EnumType = ItemChoiceType.Number Then 
      	   Console.WriteLine("Number: " & _
      	   	myChoices.MyChoice.ToString())
      	
      else if myChoices.EnumType = ItemChoiceType.DecimalNumber Then
         Console.WriteLine("DecimalNumber: " & _
      	   	myChoices.MyChoice.ToString())
      	End If

      ' Disambiguate the ManyChoices values Imports the enumerations.
      Dim i As Integer
      for i = 0 to myChoices.ManyChoices.Length -1
      if myChoices.ChoiceArray(i) = MoreChoices.Item Then
      	Console.WriteLine("Item: " +  _
      	myChoices.ManyChoices(i).ToString())
      else if myChoices.ChoiceArray(i) = MoreChoices.Amount Then
      	Console.WriteLine("Amount: " + _
      	myChoices.ManyChoices(i).ToString())
      else if (myChoices.ChoiceArray(i) = MoreChoices.Temp)
      	Console.WriteLine("Temp: " + _
      	myChoices.ManyChoices(i).ToString())
      	End If
      	Next i
      
   End Sub
End Class
'</Snippet1>	
	
	

