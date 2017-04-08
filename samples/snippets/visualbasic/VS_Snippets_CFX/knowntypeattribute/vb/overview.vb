'<snippet0>
Imports System
Imports System.Collections.Generic
Imports System.Collections
Imports System.Text
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Xml

Class Program

    Shared Sub Main(ByVal args() As String)
        Try
            Serialize("KnownTypeAttributeExample.xml")
            Deserialize("KnownTypeAttributeExample.xml")
            ' Run this twice. The second time, comment out the
            ' Serialize call and comment out the 
            ' KnownTypeAttribute on the Person class. The
            ' deserialization will then fail.
        Catch exc As SerializationException
            Console.WriteLine("{0}: {1}", exc.Message, exc.StackTrace)
        Finally
            Console.WriteLine("Press Enter to exit...")
            Console.ReadLine()
        End Try

    End Sub


    Public Shared Sub Serialize(ByVal path As String)
        Dim p As New Person()
        p.Miscellaneous.Add(DateTime.Now, "Hello")
        p.Miscellaneous.Add(DateTime.Now.AddSeconds(1), "World")
        Dim w As New IDInformation()
        w.ID = "1111 00000"
        p.Miscellaneous.Add(DateTime.Now.AddSeconds(2), w)
        Dim ser As New DataContractserializer(GetType(Person))
        Using fs As New FileStream(path, FileMode.OpenOrCreate)
            ser.WriteObject(fs, p)
        End Using
    End Sub

    Public Shared Sub Deserialize(ByVal path As String)
        Dim ser As New DataContractserializer(GetType(Person))
        Using fs As New FileStream(path, FileMode.OpenOrCreate)
            Dim p2 As Person = ser.ReadObject(fs)
            Console.WriteLine("Count {0}", p2.Miscellaneous.Count)
            For Each de As DictionaryEntry In p2.Miscellaneous
                Console.WriteLine("Key {0} Value: {1}", de.Key, _
                de.Value)
                If TypeOf (de.Value) Is IDInformation Then
                    Dim www As IDInformation = de.Value
                    Console.WriteLine( _
                    "Found ID Information. ID: {0}", www.ID)
                End If
            Next
        End Using
    End Sub

    ' Apply the KnownTypeAttribute to the class that 
    ' includes a member that returns a Hashtable.
    <System.Runtime.Serialization.KnownType(GetType(IDInformation))> _
    <DataContract()> _
    Public Class Person
        Implements IExtensibleDataObject
        Private MiscellaneousValue As New Hashtable()
        Private ExtensionDataObjectValue As ExtensionDataObject

        Public Property ExtensionData() As ExtensionDataObject _
            Implements IExtensibleDataObject.ExtensionData
            Get
                Return ExtensionDataObjectValue
            End Get
            Set(ByVal value As ExtensionDataObject)
                ExtensionDataObjectValue = value
            End Set
        End Property

        <DataMember()> _
        Public Property Miscellaneous() As Hashtable
            Get
                Return MiscellaneousValue
            End Get
            Set(ByVal value As Hashtable)
                MiscellaneousValue = value
            End Set
        End Property
    End Class

    <DataContract()> _
    Public Class IDInformation
        Implements IExtensibleDataObject

        Private ExtensionDataObjectValue As ExtensionDataObject

        Public Property ExtensionData() As ExtensionDataObject _
            Implements IExtensibleDataObject.ExtensionData
            Get
                Return ExtensionDataObjectValue
            End Get

            Set(ByVal value As ExtensionDataObject)
                ExtensionDataObjectValue = value
            End Set
        End Property

        <DataMember()> _
        Public ID As String
    End Class
End Class
'</snippet0>