'<snippetClientCredentials>
Imports NorthwindClient.Northwind
Imports System.Data.Services.Client
Imports System.Windows.Data
Imports System.Net
Imports System.Windows
Imports System.Security

Partial Public Class ClientCredentials
    Inherits Window

    ' Create the binding collections and the data service context.
    Private binding As DataServiceCollection(Of Customer)
    Private context As NorthwindEntities
    Private customerAddressViewSource As CollectionViewSource

    ' Instantiate the service URI and credentials.
    Dim serviceUri As Uri = New Uri("http://localhost:54321/Northwind.svc/")
    Private credentials As NetworkCredential = New NetworkCredential()

    Public Sub Main()
        InitializeComponent()
    End Sub

    Private Sub ClientCredentials_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

        Dim userName = String.Empty
        Dim domain = String.Empty
        Dim password = New SecureString()

        ' Get credentials for authentication.
        Dim login As New LoginWindow()
        login.ShowDialog()

        If login.DialogResult = True _
            AndAlso Not login.userNameBox.Text Is String.Empty _
            AndAlso login.passwordBox.SecurePassword.Length <> 0 Then

            ' Instantiate the context.
            context = New NorthwindEntities(serviceUri)

            ' Get the user name and domain from the login.
            Dim qualifiedUserName As String() = login.userNameBox.Text.Split(New [Char]() {"\"c})
            If qualifiedUserName.Length = 2 Then
                domain = qualifiedUserName(0)
                userName = qualifiedUserName(1)
            Else
                userName = login.userNameBox.Text
            End If
            password = login.passwordBox.SecurePassword

            ' Set the client authentication credentials.
            context.Credentials = _
                New NetworkCredential(userName, password, domain)


            ' Define an anonymous LINQ query that returns a collection of Customer types.
            Dim query = From c In context.Customers
                        Where c.Country = "Germany"
                        Select c

            Try
                ' Instantiate the binding collection, which executes the query.
                binding = New DataServiceCollection(Of Customer)(query)

                ' Load result pages into the binding collection.
                While Not binding.Continuation Is Nothing
                    ' Continue to execute the query until all pages are loaded.
                    binding.Load(context.Execute(Of Customer)(binding.Continuation.NextLinkUri))
                End While

                ' Assign the binding collection to the CollectionViewSource.
                customerAddressViewSource = _
                    CType(Me.Resources("customerViewSource"), CollectionViewSource)
                customerAddressViewSource.Source = binding
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf login.DialogResult = False Then
            MessageBox.Show("Login cancelled.")
        End If
    End Sub
End Class
'</snippetClientCredentials>