' snippet

Imports System.Collections
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Collections.Generic

<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution:=True)>
Namespace Microsoft.Security.Samples
    ' <Snippet8>
    <DataContract()> _
    Public Class CountryOrRegion2
        <DataMember()> _
        Public officialLanguages() As String
        <DataMember()> _
        Public holidays() As DateTime
        <DataMember()> _
        Public cities As Cities
        <DataMember()> _
        Public otherInfo() As Object
    End Class

    <CollectionDataContract(ItemName:="city", KeyName:="cityName", ValueName:="population")> _
    Public Class Cities
        Inherits Dictionary(Of String, Integer)
    End Class
    ' </Snippet8>

    ' <Snippet9>
    <DataContract()> _
    Public Class CountryOrRegion3

        <DataMember()> _
        Public officialLanguages As BindingList(Of String)

        <DataMember()> _
        Public holidays As BindingList(Of DateTime)

        <DataMember()> _
        Public cities As Cities

        <DataMember()> _
        Public otherInfo As BindingList(Of Object)

    End Class

    <CollectionDataContract(ItemName:="city", _
                            KeyName:="cityName", _
                            ValueName:="population")> _
    Public Class Cities3
        Inherits Hashtable
    End Class
    ' </Snippet9>

    ' <Snippet10>
    <DataContract()> _
    Public Class CountryOrRegion4

        <DataMember()> _
        Public officialLanguages() As String

        <DataMember()> _
        Public holidays() As DateTime

        <DataMember()> _
        Public cities As Cities

        <DataMember()> _
        Public otherInfo() As Object

    End Class

    <CollectionDataContract(ItemName:="city", _
                            KeyName:="cityName", _
                            ValueName:="population")> _
    Public Class Cities4
        Inherits Dictionary(Of String, Integer)
    End Class
    ' </Snippet10>

    ' <Snippet11>
    <DataContract()> _
    Public Class Student

        <DataMember()> _
        Public name As String

        <DataMember()> _
        Public testMarks As IList(Of Integer)

    End Class

    Public Class Marks1
        Inherits List(Of Integer)
    End Class

    <CollectionDataContract(ItemName:="mark")> _
    Public Class Marks2
        Inherits List(Of Integer)
    End Class
    ' </Snippet11>

    <CollectionDataContract(Name:="Custom{0}List", _
                            ItemName:="CustomItem")> _
    Public Class CustomList(Of T)
        Inherits List(Of T)

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal items() As T)
            MyBase.New()
            For Each item As T In items
                Add(item)
            Next item
        End Sub
    End Class

    ' This is the generated code. Note that the class is renamed to "CustomBookList", 
    ' and the ItemName is set to "CustomItem".
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"), _
    System.Runtime.Serialization.CollectionDataContractAttribute(ItemName:="CustomItem")> _
    Public Class CustomBookList
        Inherits System.Collections.Generic.List(Of Microsoft.Security.Samples.Book)
    End Class

    <ServiceContract()> _
    Public Interface ICatalog
        <OperationContract()> _
        Function Books() As CustomList(Of Book)
    End Interface

    Public Class Catalog
        Implements ICatalog

        Private Sub New()
            Dim Twain As New Book()
            Twain.Author = "Twain, Mark"
            Twain.Title = "Huckleberry Finn"
            booksProperty_Value.Add(Twain)
        End Sub

        Private booksProperty_Value As CustomList(Of Book)

        Public Property BooksProperty() As CustomList(Of Book)
            Get
                Return booksProperty_Value
            End Get
            Set(ByVal value As CustomList(Of Book))
                booksProperty_Value = value
            End Set
        End Property

        Public Function Books() As CustomList(Of Book) Implements ICatalog.Books
            Return booksProperty_Value
        End Function
    End Class

    Public Class Test

        Shared Sub Main()
            Dim t As New Test()
            Console.WriteLine("Starting....")
            t.Run()
        End Sub

        Private Sub Run()
            '<snippet12>
            Dim myBinding As New WSHttpBinding()
            With myBinding.Security
                .Mode = SecurityMode.Message
                .Message.ClientCredentialType = MessageCredentialType.Windows
            End With

            ' Create the Type instances for later use and the Uri for 
            ' the base address.
            Dim contractType = GetType(ICatalog)
            Dim serviceType = GetType(Catalog)
            Dim baseAddress As New Uri("http://localhost:8036/serviceModelSamples/")

            ' Create the ServiceHost and add an endpoint, then start
            ' the service.
            Dim myServiceHost As New ServiceHost(serviceType, baseAddress)

            myServiceHost.AddServiceEndpoint(contractType, myBinding, "secureCatalog")
            AddMetabehaviors(myServiceHost)
            myServiceHost.Open()

            '</snippet12>
            Console.WriteLine("Listening")
            Console.WriteLine("Press Enter to close the service")
            Console.ReadLine()
            myServiceHost.Close()

        End Sub

        Friend Sub AddMetabehaviors(ByRef sh As ServiceHost)

            Dim sb As New ServiceMetadataBehavior()
            sb.HttpGetEnabled = True
            With sh.Description.Behaviors
                .Add(sb)
                .Find(Of ServiceDebugBehavior)().IncludeExceptionDetailInFaults = True
            End With

        End Sub
    End Class

    Public Class Address
        'Dim houseNumber As Integer
        'Dim streetName As String
    End Class

    Public Class Collection(Of T)
        'Private firstMember As T
    End Class

    Public Class Item
        'Private firstMember As Integer
    End Class


    ' <Snippet1>
    <DataContract(Name:="Customer")> _
    Public Class Customer1

        <DataMember()> _
        Public customerName As String

        <DataMember()> _
        Public addresses As Collection(Of Address)

    End Class

    <DataContract(Name:="Customer")> _
    Public Class Customer2

        <DataMember()> _
        Public customerName As String

        <DataMember()> _
        Public addresses As ICollection(Of Address)

    End Class
    ' </Snippet1>

    ' <Snippet2>
    <CollectionDataContract()> _
    Public Class CustomerList2
        Inherits Collection(Of String)
    End Class
    ' </Snippet2>

    ' <Snippet3>
    <CollectionDataContract(Name:="cust_list")> _
    Public Class CustomerList3
        Inherits Collection(Of String)
    End Class
    ' </Snippet3>

    ' <Snippet4>
    <CollectionDataContract(ItemName:="customer")> _
    Public Class CustomerList4
        Inherits Collection(Of String)
    End Class
    ' </Snippet4>

    ' <Snippet5>
    <CollectionDataContract(Name:="CountriesOrRegionsWithCapitals", _
                            ItemName:="entry", KeyName:="countryorregion", _
                            ValueName:="capital")> _
    Public Class CountriesOrRegionsWithCapitals2
        Inherits Dictionary(Of String, String)
    End Class
    ' </Snippet5>

    ' <Snippet6>
    <DataContract()> _
    Public Class Employee

        <DataMember()> _
        Public name As String = "John Doe"

        <DataMember()> _
        Public payrollRecord As Payroll

        <DataMember()> _
        Public trainingRecord As Training

    End Class

    <DataContract(), KnownType(GetType(Integer())), KnownType(GetType(ArrayList))> _
    Public Class Payroll

        <DataMember()> _
        Public salaryPayments As Object = New Integer(11) {}

        'float[] not needed in known types because polymorphic assignment is to another collection type
        <DataMember()> _
        Public stockAwards As IEnumerable(Of Single) = New Single(11) {}

        <DataMember()> _
        Public otherPayments As Object = New ArrayList()

    End Class

    'required because List<object> is used polymorphically
    'does not conflict with ArrayList above because it's a different scope, 
    'even though it's the same data contract
    <DataContract(), KnownType(GetType(List(Of Object))), _
                     KnownType(GetType(InHouseTraining)), _
                     KnownType(GetType(OutsideTraining))> _
    Public Class Training
        <DataMember()> _
        Public training As Object = New List(Of Object)()
    End Class

    <DataContract()> _
    Public Class InHouseTraining
        'code omitted…
    End Class

    <DataContract()> _
    Public Class OutsideTraining
        'code omitted…
    End Class
    ' </Snippet6>


    ' <Snippet7>
    <DataContract()> _
    Public Class CountryOrRegion

        <DataMember()> _
        Public officialLanguages As Collection(Of String)

        <DataMember()> _
        Public holidays As List(Of DateTime)

        <DataMember()> _
        Public cities As CityList

        <DataMember()> _
        Public otherInfo As ArrayList

    End Class

    Public Class Person
        Public Sub New(ByVal fName As String, ByVal lName As String)
            Me.firstName = fName
            Me.lastName = lName
        End Sub

        Public firstName As String
        Public lastName As String
    End Class

    Public Class PeopleEnum
        Implements IEnumerator

        Public _people() As Person
        ' Enumerators are positioned before the first element
        ' until the first MoveNext() call.
        Private position As Integer = -1

        Public Sub New(ByVal list() As Person)
            _people = list
        End Sub

        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            position += 1
            Return position < _people.Length
        End Function

        Public Sub Reset() Implements IEnumerator.Reset
            position = -1
        End Sub

        Public ReadOnly Property Current() As Object Implements IEnumerator.Current
            Get
                Try
                    Return _people(position)
                Catch e1 As IndexOutOfRangeException
                    Throw New InvalidOperationException()
                End Try
            End Get
        End Property
    End Class

    <CollectionDataContract(Name:="Cities", _
                            ItemName:="city", _
                            KeyName:="cityName", _
                            ValueName:="population")> _
    Public Class CityList
        Implements IDictionary(Of String, Integer), IEnumerable(Of System.Collections.Generic.KeyValuePair(Of String, Integer))

        Private _people() As Person = Nothing

        Public Function ContainsKey(ByVal s As String) As Boolean Implements IDictionary(Of String, Integer).ContainsKey
            Return True
        End Function

        Public Function Contains(ByVal s As String) As Boolean
            Return True
        End Function

        Public Function Contains(ByVal item As KeyValuePair(Of String, Integer)) As Boolean Implements IDictionary(Of String, Integer).Contains
            Return (True)
        End Function

        Public Sub Add(ByVal key As String, _
                       ByVal value As Integer) Implements IDictionary(Of String, Integer).Add
        End Sub

        Public Sub Add(ByVal keykValue As KeyValuePair(Of String, Integer)) Implements IDictionary(Of String, Integer).Add
        End Sub

        Public Function Remove(ByVal s As String) As Boolean Implements IDictionary(Of String, Integer).Remove
            Return True
        End Function

        Public Function TryGetValue(ByVal d As String, _
                                    <System.Runtime.InteropServices.Out()> ByRef i As Integer) _
                                    As Boolean Implements IDictionary(Of String, Integer).TryGetValue
            i = 0
            Return (True)
        End Function

        Public ReadOnly Property Keys() As ICollection(Of String) Implements IDictionary(Of String, Integer).Keys
            Get
                Return CType(New Stack(Of String)(), System.Collections.Generic.ICollection(Of String))
            End Get
        End Property

        Default Public Property Item(ByVal s As String) As Integer Implements IDictionary(Of String, Integer).Item
            Get
                Return 0
            End Get
            Set(ByVal value As Integer)
            End Set
        End Property

        Public ReadOnly Property Values() As ICollection(Of Integer) Implements IDictionary(Of String, Integer).Values
            Get
                Return CType(New Stack(Of String)(), System.Collections.Generic.ICollection(Of Integer))
            End Get
        End Property

        Public Sub Clear() Implements IDictionary(Of String, Integer).Clear
        End Sub

        Public Sub CopyTo(ByVal array() As KeyValuePair(Of String, Integer), _
                          ByVal index As Integer) Implements IDictionary(Of String, Integer).CopyTo
        End Sub

        Public Function Remove(ByVal item As KeyValuePair(Of String, Integer)) As Boolean Implements IDictionary(Of String, Integer).Remove
            Return True
        End Function

        Public ReadOnly Property Count() As Integer Implements IDictionary(Of String, Integer).Count
            Get
                Return 0
            End Get
        End Property

        Public ReadOnly Property IsReadOnly() As Boolean Implements IDictionary(Of String, Integer).IsReadOnly
            Get
                Return True
            End Get
        End Property

        Private Function IEnumerable_GetEnumerator() As IEnumerator(Of KeyValuePair(Of String, Integer)) _
            Implements System.Collections.Generic.IEnumerable(Of System.Collections.Generic.KeyValuePair(Of String, Integer)).GetEnumerator

            Return CType(New PeopleEnum(_people), IEnumerator(Of KeyValuePair(Of String, Integer)))
        End Function

        Public Function GetEnumerator() As IEnumerator Implements System.Collections.IEnumerable.GetEnumerator

            Return New PeopleEnum(_people)

        End Function

    End Class

    ' </Snippet7>

    ' <Snippet0>
    <DataContract(Name:="PurchaseOrder")> _
    Public Class PurchaseOrder1

        <DataMember()> _
        Public customerName As String

        <DataMember()> _
        Public items As Collection(Of Item)

        <DataMember()> _
        Public comments() As String

    End Class

    <DataContract(Name:="PurchaseOrder")> _
    Public Class PurchaseOrder2

        <DataMember()> _
        Public customerName As String

        <DataMember()> _
        Public items As List(Of Item)

        <DataMember()> _
        Public comments As BindingList(Of String)

    End Class
    ' </Snippet0>

    <DataContract()> _
    Public Class Book

        <DataMember()> _
        Public Author As String

        <DataMember()> _
        Public Title As String

    End Class
End Namespace
