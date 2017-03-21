	'The following example demonstrates the implementation of 
	'ISite, IComponent, and IContainer for use in a simple library container.
	'
	'This example imports the System, System.ComponentModel, and System.Collections
	'namespaces.

	'This code segment implements the ISite and IComponent interfaces.
	'The implementation of the IContainer interface can be seen in the documentation 
	'of IContainer.

	'Implement the ISite interface.

	'The ISBNSite class represents the ISBN name of the book component
	
Class ISBNSite
    Implements ISite
    Private m_curComponent As IComponent
    Private m_curContainer As IContainer
    Private m_bDesignMode As Boolean
    Private m_ISBNCmpName As String

    Public Sub New(ByVal actvCntr As IContainer, ByVal prntCmpnt As IComponent)
        m_curComponent = prntCmpnt
        m_curContainer = actvCntr
        m_bDesignMode = False
        m_ISBNCmpName = Nothing
    End Sub

    'Support the ISite interface.
    Public ReadOnly Property Component() As IComponent Implements ISite.Component
        Get
            Return m_curComponent
        End Get
    End Property

    Public ReadOnly Property Container() As IContainer Implements ISite.Container
        Get
            Return m_curContainer
        End Get
    End Property

    Public ReadOnly Property DesignMode() As Boolean Implements ISite.DesignMode
        Get
            Return m_bDesignMode
        End Get
    End Property

    Public Property Name() As String Implements ISite.Name
        Get
            Return m_ISBNCmpName
        End Get
        Set(ByVal Value As String)
            m_ISBNCmpName = Value
        End Set
    End Property

    'Support the IServiceProvider interface.
    Public Function GetService(ByVal serviceType As Type) As Object Implements IServiceProvider.GetService
        'This example does not use any service object.
        GetService = Nothing
    End Function
End Class

'The BookComponent class represents the book component of the library container.
Class BookComponent
    Implements IComponent
    Public Event Disposed As EventHandler Implements IComponent.Disposed
    Private m_curISBNSite As ISite
    Private m_bookTitle As String
    Private m_bookAuthor As String

    Public Sub New(ByVal Title As String, ByVal Author As String)
        m_curISBNSite = Nothing
        m_bookTitle = Title
        m_bookAuthor = Author
    End Sub

    Public ReadOnly Property Title() As String
        Get
            Return m_bookTitle
        End Get
    End Property

    Public ReadOnly Property Author() As String
        Get
            Return m_bookAuthor
        End Get
    End Property

    Public Sub Dispose() Implements IDisposable.Dispose
        'There is nothing to clean.
        RaiseEvent Disposed(Me, EventArgs.Empty)
    End Sub

    Public Property Site() As ISite Implements IComponent.Site
        Get
            Return m_curISBNSite
        End Get
        Set(ByVal Value As ISite)
            m_curISBNSite = Value
        End Set
    End Property

    Public Overloads Function Equals(ByVal cmp As Object) As Boolean
        Dim cmpObj As BookComponent = CType(cmp, BookComponent)
        If (Me.Title.Equals(cmpObj.Title) And Me.Author.Equals(cmpObj.Author)) Then
            Equals = True
        Else
            Equals = False
        End If
    End Function

    Public Overrides Function GetHashCode() As Integer
        GetHashCode = MyBase.GetHashCode()
    End Function

End Class