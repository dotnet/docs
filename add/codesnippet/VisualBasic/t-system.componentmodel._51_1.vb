	'This code segment implements the IContainer interface.  The code segment 
	'containing the implementation of ISite and IComponent can be found in the documentation
	'for those interfaces.
	
	'Implement the LibraryContainer using the IContainer interface.

Class LibraryContainer
    Implements IContainer
    Private m_bookList As ArrayList

    Public Sub New()
        m_bookList = New ArrayList()
    End Sub

    Public Sub Add(ByVal book As IComponent) Implements IContainer.Add
        'The book will be added without creation of the ISite object.
        m_bookList.Add(book)
    End Sub

    Public Sub Add(ByVal book As IComponent, ByVal ISNDNNum As String) Implements IContainer.Add

        Dim i As Integer
        Dim curObj As IComponent

        For i = 0 To m_bookList.Count - 1
            curObj = CType(m_bookList(i), IComponent)
            If curObj.Site IsNot Nothing Then
                If (curObj.Site.Name.Equals(ISNDNNum)) Then
                    Throw New SystemException("The ISBN number already exists in the container")
                End If
            End If
        Next i

        Dim data As ISBNSite = New ISBNSite(Me, book)
        data.Name = ISNDNNum
        book.Site = data
        m_bookList.Add(book)

    End Sub

    Public Sub Remove(ByVal book As IComponent) Implements IContainer.Remove
        Dim i As Integer
        Dim curComp As BookComponent = CType(book, BookComponent)

        For i = 0 To m_bookList.Count - 1
            If (curComp.Equals(m_bookList(i)) = True) Then
                m_bookList.RemoveAt(i)
                Exit For
            End If
        Next i
    End Sub


    Public ReadOnly Property Components() As ComponentCollection Implements IContainer.Components
        Get
            Dim datalist(m_bookList.Count - 1) As IComponent
            
            m_bookList.CopyTo(datalist)
            Return New ComponentCollection(datalist)
        End Get
    End Property

    Public Overridable Sub Dispose() Implements IDisposable.Dispose
        Dim i As Integer
        For i = 0 To m_bookList.Count - 1
            Dim curObj As IComponent = CType(m_bookList(i), IComponent)
            curObj.Dispose()
        Next i

        m_bookList.Clear()
    End Sub

    Public Shared Sub Main()
        Dim cntrExmpl As LibraryContainer = New LibraryContainer()

        Try
            Dim book1 As BookComponent = New BookComponent("Wizard's First Rule", "Terry Gooodkind")
            cntrExmpl.Add(book1, "0812548051")
            Dim book2 As BookComponent = New BookComponent("Stone of Tears", "Terry Gooodkind")
            cntrExmpl.Add(book2, "0812548094")
            Dim book3 As BookComponent = New BookComponent("Blood of the Fold", "Terry Gooodkind")
            cntrExmpl.Add(book3, "0812551478")
            Dim book4 As BookComponent = New BookComponent("The Soul of the Fire", "Terry Gooodkind")
            'This will generate an exception, because the ISBN already exists in the container.
            cntrExmpl.Add(book4, "0812551478")
        Catch e As SystemException
            Console.WriteLine("Error description: " + e.Message)
        End Try

        Dim datalist As ComponentCollection = cntrExmpl.Components
        Dim denum As IEnumerator = datalist.GetEnumerator()

        While (denum.MoveNext())
            Dim cmp As BookComponent = CType(denum.Current, BookComponent)
            Console.WriteLine("Book Title: " + cmp.Title)
            Console.WriteLine("Book Author: " + cmp.Author)
            Console.WriteLine("Book ISBN: " + cmp.Site.Name)
        End While
    End Sub
End Class