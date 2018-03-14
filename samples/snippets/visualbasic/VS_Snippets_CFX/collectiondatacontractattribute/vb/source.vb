
Imports System
Imports System.Collections
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.Security.Permissions
Imports System.Collections.Generic

<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution:=True)>
Namespace Microsoft.Security.Samples
	'<snippet1>
	<CollectionDataContract(Name := "Custom{0}List", ItemName := "CustomItem")> _
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
	'</snippet1>

	'<snippet2>
	' This is the generated code. Note that the class is renamed to "CustomBookList", 
	' and the ItemName is set to "CustomItem".
	<System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"), System.Runtime.Serialization.CollectionDataContractAttribute(ItemName := "CustomItem")> _
	Public Class CustomBookList
		Inherits System.Collections.Generic.List(Of Microsoft.Security.Samples.Book)
	End Class
	'</snippet2>


	<ServiceContract> _
	Public Interface ICatalog
		<OperationContract> _
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
			Dim myBinding As New WSHttpBinding()
			myBinding.Security.Mode = SecurityMode.Message
			myBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows

			' Create the Type instances for later use and the Uri for 
			' the base address.
			Dim contractType As Type = GetType(ICatalog)
			Dim serviceType As Type = GetType(Catalog)
			Dim baseAddress As New Uri("http://localhost:8036/serviceModelSamples/")

			' Create the ServiceHost and add an endpoint, then start
			' the service.
			Dim myServiceHost As New ServiceHost(serviceType, baseAddress)
			myServiceHost.AddServiceEndpoint (contractType, myBinding, "secureCatalog")
			AddMetabehaviors(myServiceHost)
			myServiceHost.Open()

			Console.WriteLine("Listening")
			Console.WriteLine("Press Enter to close the service")
			Console.ReadLine()
			myServiceHost.Close()
		End Sub

		Friend Sub AddMetabehaviors(ByRef sh As ServiceHost)
			Dim sb As New ServiceMetadataBehavior()
			sb.HttpGetEnabled = True
			sh.Description.Behaviors.Add(sb)
			sh.Description.Behaviors.Find(Of ServiceDebugBehavior)().IncludeExceptionDetailInFaults = True
		End Sub
	End Class


	<DataContract> _
	Public Class Book
		<DataMember> _
		Public Author As String
		<DataMember> _
		Public Title As String
	End Class
End Namespace