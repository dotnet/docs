Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.ComponentModel


' This is the class that will be serialized. 
Public Class Pet
    ' The default value for the Animal field is "Dog". 
    <DefaultValueAttribute("Dog")> Public Animal As String 
End Class


Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("OverrideDefaultValue.xml")
        test.DeserializeObject("OverrideDefaultValue.xml")
    End Sub 'Main
    
    
    ' Return an XmlSerializer used for overriding. 
    Public Function CreateOverrider() As XmlSerializer
        ' Create the XmlAttributeOverrides and XmlAttributes objects. 
        Dim xOver As New XmlAttributeOverrides()
        Dim xAttrs As New XmlAttributes()
        
        ' Add an override for the default value of the GroupName. 
        Dim defaultName As Object = "Cat"
        xAttrs.XmlDefaultValue = defaultName
        
        ' Add all the XmlAttributes to the XmlAttributeOverrides object. 
        xOver.Add(GetType(Pet), "Animal", xAttrs)
        
        ' Create the XmlSerializer and return it.
        Return New XmlSerializer(GetType(Pet), xOver)
    End Function
    
    
    Public Sub SerializeObject(ByVal filename As String)
       ' Create an instance of the XmlSerializer class.
       Dim mySerializer As XmlSerializer = CreateOverrider()
        
       ' Writing the file requires a TextWriter.
       Dim writer As New StreamWriter(filename)
        
       ' Create an instance of the class that will be serialized. 
       Dim myPet As New Pet()
        
       ' Set the Animal property. If you set it to the default value,
       ' which is "Cat" (the value assigned to the XmlDefaultValue
       ' of the XmlAttributes object), no value will be serialized.
       ' If you change the value to any other value (including "Dog"),
       ' the value will be serialized.

      ' The default value "Cat" will be assigned (nothing serialized).
      myPet.Animal = ""
      ' Uncommenting the next line also results in the default 
      ' value because Cat is the default value (not serialized).
      '  myPet.Animal = "Cat"; 
      
      ' Uncomment the next line to see the value serialized:
      ' myPet.Animal = "fish";
      ' This will also be serialized because Dog is not the 
      ' default anymore.
      '  myPet.Animal = "Dog";
       ' Serialize the class, and close the TextWriter.
        mySerializer.Serialize(writer, myPet)
        writer.Close()
    End Sub
    
    
    Public Sub DeserializeObject(ByVal filename As String)
        Dim mySerializer As XmlSerializer = CreateOverrider()
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim myPet As Pet = CType(mySerializer.Deserialize(fs), Pet)
        Console.WriteLine(myPet.Animal)
    End Sub
End Class

' </Snippet1>

