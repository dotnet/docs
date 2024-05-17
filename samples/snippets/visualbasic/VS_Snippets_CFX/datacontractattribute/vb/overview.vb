Imports System.IO
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Security.Permissions

'<snippet1>
Namespace DataContractAttributeExample
    ' Set the Name and Namespace properties to new values.
    <DataContract(Name:="Customer", [Namespace]:="http://www.contoso.com")> _
    Class Person
        Implements IExtensibleDataObject
        ' To implement the IExtensibleDataObject interface, you must also
        ' implement the ExtensionData property.
        Private extensionDataObjectValue As ExtensionDataObject

        Public Property ExtensionData() As ExtensionDataObject _
          Implements IExtensibleDataObject.ExtensionData
            Get
                Return extensionDataObjectValue
            End Get
            Set
                extensionDataObjectValue = value
            End Set
        End Property

        <DataMember(Name:="CustName")> _
        Friend Name As String

        <DataMember(Name:="CustID")> _
        Friend ID As Integer


        Public Sub New(ByVal newName As String, ByVal newID As Integer)
            Name = newName
            ID = newID

        End Sub
    End Class


    Class Test

        Public Shared Sub Main()
            Try
                WriteObject("DataContractExample.xml")
                ReadObject("DataContractExample.xml")
                Console.WriteLine("Press Enter to end")
                Console.ReadLine()
            Catch se As SerializationException
                Console.WriteLine("The serialization operation failed. Reason: {0}", _
                   se.Message)
                Console.WriteLine(se.Data)
                Console.ReadLine()
            End Try

        End Sub


        Public Shared Sub WriteObject(ByVal path As String)
            ' Create a new instance of the Person class and 
            ' serialize it to an XML file.
            Dim p1 As New Person("Mary", 1)
            ' Create a new instance of a StreamWriter
            ' to read and write the data.
            Dim fs As New FileStream(path, FileMode.Create)
            Dim writer As XmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(fs)
            Dim ser As New DataContractSerializer(GetType(Person))
            ser.WriteObject(writer, p1)
            Console.WriteLine("Finished writing object.")
            writer.Close()
            fs.Close()

        End Sub

        Public Shared Sub ReadObject(ByVal path As String)
            ' Deserialize an instance of the Person class 
            ' from an XML file. First create an instance of the 
            ' XmlDictionaryReader.
            Dim fs As New FileStream(path, FileMode.OpenOrCreate)
            Dim reader As XmlDictionaryReader = XmlDictionaryReader. _
              CreateTextReader(fs, New XmlDictionaryReaderQuotas())

            ' Create the DataContractSerializer instance.
            Dim ser As New DataContractSerializer(GetType(Person))

            ' Deserialize the data and read it from the instance.
            Dim newPerson As Person = CType(ser.ReadObject(reader), Person)
            Console.WriteLine("Reading this object:")
            Console.WriteLine(String.Format("{0}, ID: {1}", newPerson.Name, newPerson.ID))
            fs.Close()

        End Sub
    End Class
End Namespace
'</snippet1>

Namespace NewDataStuff
    '<snippet2>
    <DataContract()> _
    Public Class Person
        ' This member is serialized.
        <DataMember()> _
        Friend FullName As String

        ' This is serialized even though it is private.
        <DataMember()> _
        Private Age As Integer

        ' This is not serialized because the DataMemberAttribute 
        ' has not been applied.
        Private MailingAddress As String

        ' This is not serialized, but the property is.
        Private telephoneNumberValue As String

        <DataMember()> _
        Public Property TelephoneNumber() As String
            Get
                Return telephoneNumberValue
            End Get
            Set
                telephoneNumberValue = value
            End Set
        End Property
    End Class
    '</snippet2>
End Namespace

Namespace SecurityConsiderations
    '<snippet3>
    <DataContract()> _
    Public Class SpaceStationAirlock
        <DataMember()> Private innerDoorOpenValue As Boolean = False
        <DataMember()> Private outerDoorOpenValue As Boolean = False

        Public Property InnerDoorOpen() As Boolean
            Get

                Return innerDoorOpenValue
            End Get
            Set(ByVal value As Boolean)
                If (value & outerDoorOpenValue) Then
                    Throw New Exception("Cannot open both doors!")
                Else
                    innerDoorOpenValue = value
                End If
            End Set
        End Property

        Public Property OuterDoorOpen() As Boolean
            Get
                Return outerDoorOpenValue
            End Get
            Set(ByVal value As Boolean)
                If (value & innerDoorOpenValue) Then
                    Throw New Exception("Cannot open both doors!")
                Else
                    outerDoorOpenValue = value
                End If
            End Set
        End Property
    End Class
    '</snippet3>
End Namespace

Namespace XmlAndADO1
    '<snippet4>
    <DataContract([Namespace]:="http://schemas.contoso.com")> _
    Public Class MyDataContract
        <DataMember()> _
        Public myDataMember As XmlElement

        Public Sub TestClass()
            Dim xd As New XmlDocument()
            myDataMember = xd.CreateElement("myElement")
            myDataMember.InnerText = "myContents"
            myDataMember.SetAttribute("myAttribute", "myValue")

        End Sub
    End Class
    '</snippet4>
End Namespace

Namespace XmlAndADO2
    '<snippet5>
    <DataContract([Namespace]:="http://schemas.contoso.com")> _
    Public Class MyDataContract
        <DataMember()> _
        Public myDataMember(3) As XmlNode

        Public Sub TestClass()
            Dim xd As New XmlDocument()
            Dim xe As XmlElement = xd.CreateElement("myElement")
            xe.InnerText = "myContents"
            xe.SetAttribute("myAttribute", "myValue")

            Dim atr As XmlAttribute = xe.Attributes(0)
            Dim cmnt As XmlComment = xd.CreateComment("myComment")

            myDataMember(0) = atr
            myDataMember(1) = cmnt
            myDataMember(2) = xe
            myDataMember(3) = xe

        End Sub

    End Class
    '</snippet5>
End Namespace
