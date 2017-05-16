' <Snippet1>

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Text
Imports LibraryContractsHAV
Imports System.AddIn.Hosting
Imports System.Xml


Namespace ListAdaptersHost
Friend Class Program
Shared Sub Main(ByVal args As String())

    ' <Snippet2>
    ' In this example, the pipeline root is the current directory.
    Dim pipeRoot As String = Environment.CurrentDirectory

    ' Rebuild the cache of pipeline and add-in information.
    Dim warnings As String() = AddInStore.Update(pipeRoot)
    If warnings.Length > 0 Then
        For Each one As String In warnings
            Console.WriteLine(one)
        Next one
    End If
    ' </Snippet2>

    ' <Snippet3>
    ' Find add-ins of type LibraryManager under the specified pipeline root directory.
    Dim tokens As Collection(Of AddInToken) = AddInStore.FindAddIns(GetType(LibraryManager), pipeRoot)
    ' </Snippet3>
    ' Determine which add-in to use.
    Dim selectedToken As AddInToken = ChooseAddIn(tokens)

    ' <Snippet4>
    ' Activate the selected AddInToken in a new
    ' application domain with a specified security trust level.
    Dim manager As LibraryManager = selectedToken.Activate(Of LibraryManager)(AddInSecurityLevel.FullTrust)
    ' </Snippet4>

    ' Create a collection of books.
    Dim books As IList(Of BookInfo) = CreateBooks()

    ' Show the collection count.
    Console.WriteLine("Number of books:  {0}",books.Count.ToString())

    ' Have the add-in process the books.
    ' The add-in will discount computer books by $20
    ' and list their before and after prices. It
    ' will also remove all horror books.
    manager.ProcessBooks(books)

    ' List the genre of each book. There
    ' should be no horror books.
    For Each bk As BookInfo In books
        Console.WriteLine(bk.Genre())
    Next bk

    Console.WriteLine("Number of books: {0}", books.Count.ToString())

    Console.WriteLine()
    ' Have the add-in pass a BookInfo object
    ' of the best selling book.
    Dim bestBook As BookInfo = manager.GetBestSeller()
    Console.WriteLine("Best seller is {0} by {1}", bestBook.Title(), bestBook.Author())

    ' Have the add-in show the sales tax rate.
    manager.Data("sales tax")

    ' <Snippet6>
    Dim ctrl As AddInController = AddInController.GetAddInController(manager)
    ctrl.Shutdown()
    ' </Snippet6>
    Console.WriteLine("Press any key to exit.")
    Console.ReadLine()
End Sub



Private Shared Function ChooseAddIn(ByVal tokens As Collection(Of AddInToken)) As AddInToken
    If tokens.Count = 0 Then
        Console.WriteLine("No add-ins of this type are available")
        Return Nothing
    End If
    Console.WriteLine("{0} Available add-in(s):",tokens.Count.ToString())
    ' <Snippet5>
    For i As Integer = 0 To tokens.Count - 1
        ' Show AddInToken properties.
        Console.WriteLine("[{0}] - {1}, Publisher: {2}, Version: {3}, Description: {4}", (i + 1).ToString(), tokens(i).Name, tokens(i).Publisher, tokens(i).Version, tokens(i).Description)
    Next i
    ' </Snippet5>
    Console.WriteLine("Select add-in by number:")
    Dim line As String = Console.ReadLine()
    Dim selection As Integer
    If Int32.TryParse(line, selection) Then
        If selection <= tokens.Count Then
            Return tokens(selection - 1)
        End If
    End If
    Console.WriteLine("Invalid selection: {0}. Please choose again.", line)
    Return ChooseAddIn(tokens)
End Function


Friend Shared Function CreateBooks() As IList(Of BookInfo)
    Dim books As List(Of BookInfo) = New List(Of BookInfo)()

    Dim ParamId As String = ""
    Dim ParamAuthor As String = ""
    Dim ParamTitle As String = ""
    Dim ParamGenre As String = ""
    Dim ParamPrice As String = ""
    Dim ParamPublish_Date As String = ""
    Dim ParamDescription As String = ""

    Dim xDoc As XmlDocument = New XmlDocument()
    xDoc.Load("c:\Books.xml")

     Dim xRoot As XmlNode = xDoc.DocumentElement
     If xRoot.Name = "catalog" Then
        Dim bklist As XmlNodeList = xRoot.ChildNodes
        For Each bk As XmlNode In bklist
            ParamId = bk.Attributes(0).Value
            Dim dataItems As XmlNodeList = bk.ChildNodes
            Dim items As Integer = dataItems.Count
            For Each di As XmlNode In dataItems
                Select Case di.Name
                    Case "author"
                        ParamAuthor = di.InnerText
                    Case "title"
                        ParamTitle = di.InnerText
                    Case "genre"
                        ParamGenre = di.InnerText
                     Case "price"
                        ParamPrice = di.InnerText
                     Case "publish_date"
                        ParamAuthor = di.InnerText
                     Case "description"
                        ParamDescription = di.InnerText
                      Case Else
                End Select

            Next di
            books.Add(New MyBookInfo(ParamId, ParamAuthor, ParamTitle, ParamGenre, ParamPrice, ParamPublish_Date, ParamDescription))
        Next bk

     End If
    Return books
End Function


End Class

Friend Class MyBookInfo
    Inherits BookInfo
    Private _id As String
    Private _author As String
    Private _title As String
    Private _genre As String
    Private _price As String
    Private _publish_date As String
    Private _description As String

    Public Sub New(ByVal id As String, ByVal author As String, ByVal title As String, ByVal genre As String, ByVal price As String, ByVal publish_date As String, ByVal description As String)
        _id = id
        _author = author
        _title = title
        _genre = genre
        _price = price
        _publish_date = publish_date
        _description = description
    End Sub

    Public Overrides Function ID() As String
        Return _id
    End Function

    Public Overrides Function Title() As String
        Return _title
    End Function

    Public Overrides Function Author() As String
        Return _author
    End Function

     Public Overrides Function Genre() As String
        Return _genre
     End Function
    Public Overrides Function Price() As String
        Return _price
    End Function
    Public Overrides Function Publish_Date() As String
        Return _publish_date
    End Function
    Public Overrides Function Description() As String
        Return _description
    End Function
End Class
End Namespace
' </Snippet1>