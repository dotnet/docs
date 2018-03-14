'<snippet0>
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Reflection
Imports System.Runtime.Serialization
Imports System.Xml

Namespace GeneratPathExample

    Class Program

        Shared Sub Main(ByVal args As String())

            ' Get the type of the class that defines the data contract.
            Dim t As Type = GetType(Order)

            ' Get the meta data for the specific members to be used in the query.
            Dim mi As MemberInfo() = t.GetMember("Product")
            Dim mi2 As MemberInfo() = t.GetMember("Value")
            Dim mi3 As MemberInfo() = t.GetMember("Quantity")

            ' Call the function below to generate and display the query.
            GenerateXPath(t, mi)
            GenerateXPath(t, mi2)
            GenerateXPath(t, mi3)


            ' Get the type of the second class that defines a data contract.
            Dim t2 As Type = GetType(Line)

            ' Get the meta data for the member to be used in the query.
            Dim mi4 As MemberInfo() = t2.GetMember("Items")

            GenerateXPath(t2, mi4)

            Console.ReadLine()
        End Sub

        Shared Sub GenerateXPath(ByVal t As Type, ByVal mi As MemberInfo())


            ' Create a new name table and name space manager.
            Dim nt As New NameTable()
            Dim xname As New XmlNamespaceManager(nt)


            ' Generate the query and print it.
            Dim query As String = XPathQueryGenerator.CreateFromDataContractSerializer( _
                t, mi, xname)
            Console.WriteLine(query)
            Console.WriteLine()


            ' Display the namespaces and prefixes used in the data contract.
            Dim s As String
            For Each s In xname
                Console.WriteLine("{0}  = {1}", s, xname.LookupNamespace(s))
            Next

            Console.WriteLine()

        End Sub
    End Class


    <DataContract(Namespace:="http://www.cohowinery.com/")> _
        Public Class Line

        Private itemsValue As Order()

        <DataMember()>
        Public Property Item() As Order()

            Get
                Return itemsValue
            End Get
            Set(ByVal value As Order())
                itemsValue = value
            End Set
        End Property

    End Class

    <DataContract(Namespace:="http://contoso.com")> _
    Public Class Order

        Private productValue As String
        Private quantityValue As Integer
        Private valueValue As Decimal

        <DataMember(Name:="cost")>
        Public Property Value() As String

            Get
                Return valueValue
            End Get
            Set(ByVal value As String)
                valueValue = value
            End Set
        End Property

        <DataMember(Name:="quantity")> _
        Public Property Quantity() As Integer

            Get
                Return quantityValue
            End Get
            set(ByVal value As Integer)
                quantityValue = value
            End Set
        End Property


        <DataMember(Name:="productName")> _
        Public Property Product() As String

            Get
                Return productValue
            End Get
            Set(ByVal value As String)
                productValue = value
            End Set
        End Property
    End Class
End Namespace
'</snippet0>