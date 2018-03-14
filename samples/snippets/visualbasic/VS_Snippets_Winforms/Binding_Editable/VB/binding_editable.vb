Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    ' sample for IEditableObject
    '<snippet1>
    Public Class Customer
        Implements IEditableObject

        Structure CustomerData
            Friend id As String
            Friend firstName As String
            Friend lastName As String
        End Structure 

        Public parent As CustomersList
        Private custData As CustomerData
        Private backupData As CustomerData
        Private inTxn As Boolean = False


        ' Implements IEditableObject
        Sub BeginEdit() Implements IEditableObject.BeginEdit
            Console.WriteLine("Start BeginEdit")
            If Not inTxn Then
                Me.backupData = custData
                inTxn = True
                Console.WriteLine(("BeginEdit - " + Me.backupData.lastName))
            End If
            Console.WriteLine("End BeginEdit")
        End Sub 


        Sub CancelEdit() Implements IEditableObject.CancelEdit
            Console.WriteLine("Start CancelEdit")
            If inTxn Then
                Me.custData = backupData
                inTxn = False
                Console.WriteLine(("CancelEdit - " + Me.custData.lastName))
            End If
            Console.WriteLine("End CancelEdit")
        End Sub 


        Sub EndEdit() Implements IEditableObject.EndEdit
            Console.WriteLine(("Start EndEdit" + Me.custData.id + Me.custData.lastName))
            If inTxn Then
                backupData = New CustomerData()
                inTxn = False
                Console.WriteLine(("Done EndEdit - " + Me.custData.id + Me.custData.lastName))
            End If
            Console.WriteLine("End EndEdit")
        End Sub 


        Public Sub New(ByVal ID As String)
            Me.custData = New CustomerData()
            Me.custData.id = ID
            Me.custData.firstName = ""
            Me.custData.lastName = ""
        End Sub 


        Public ReadOnly Property ID() As String
            Get
                Return Me.custData.id
            End Get
        End Property


        Public Property FirstName() As String
            Get
                Return Me.custData.firstName
            End Get
            Set(ByVal Value As String)
                Me.custData.firstName = Value
                Me.OnCustomerChanged()
            End Set
        End Property


        Public Property LastName() As String
            Get
                Return Me.custData.lastName
            End Get
            Set(ByVal Value As String)
                Me.custData.lastName = Value
                Me.OnCustomerChanged()
            End Set
        End Property


        Friend Property Parents() As CustomersList
            Get
                Return Parent
            End Get
            Set(ByVal Value As CustomersList)
                parent = Value
            End Set
        End Property


        Private Sub OnCustomerChanged()
            If Not inTxn And (Parent IsNot Nothing) Then
                Parent.CustomerChanged(Me)
            End If
        End Sub 

        
        Public Overrides Function ToString() As String
            Dim sb As New StringWriter()
            sb.Write(Me.FirstName)
            sb.Write(" ")
            sb.Write(Me.LastName)
            Return sb.ToString()
        End Function 
    End Class

    '</snippet1>
    _
    ' end of Customer class - sample for IEditableObject

    ' sample for IBindingList
    '<snippet2>
    Public Class CustomersList
        Inherits CollectionBase
        Implements IBindingList 

        Private resetEvent As New ListChangedEventArgs(ListChangedType.Reset, -1)
        Private onListChanged1 As ListChangedEventHandler


        Public Sub LoadCustomers()
            Dim l As IList = CType(Me, IList)
            l.Add(ReadCustomer1())
            l.Add(ReadCustomer2())
            OnListChanged(resetEvent)
        End Sub 


        Default Public Property Item(ByVal index As Integer) As Customer
            Get
                Return CType(List(index), Customer)
            End Get
            Set(ByVal Value As Customer)
                List(index) = Value
            End Set
        End Property


        Public Function Add(ByVal value As Customer) As Integer
            Return List.Add(value)
        End Function 


        Public Function AddNew2() As Customer
            Return CType(CType(Me, IBindingList).AddNew(), Customer)
        End Function 


        Public Sub Remove(ByVal value As Customer)
            List.Remove(value)
        End Sub 



        Protected Overridable Sub OnListChanged(ByVal ev As ListChangedEventArgs)
            If (onListChanged1 IsNot Nothing) Then
                onListChanged1(Me, ev)
            End If
        End Sub 



        Protected Overrides Sub OnClear()
            Dim c As Customer
            For Each c In List
                c.parent = Nothing
            Next c
        End Sub 


        Protected Overrides Sub OnClearComplete()
            OnListChanged(resetEvent)
        End Sub 


        Protected Overrides Sub OnInsertComplete(ByVal index As Integer, ByVal value As Object)
            Dim c As Customer = CType(value, Customer)
            c.parent = Me
            OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, index))
        End Sub 


        Protected Overrides Sub OnRemoveComplete(ByVal index As Integer, ByVal value As Object)
            Dim c As Customer = CType(value, Customer)
            c.parent = Me
            OnListChanged(New ListChangedEventArgs(ListChangedType.ItemDeleted, index))
        End Sub 


        Protected Overrides Sub OnSetComplete(ByVal index As Integer, ByVal oldValue As Object, ByVal newValue As Object)
            If oldValue <> newValue Then

                Dim oldcust As Customer = CType(oldValue, Customer)
                Dim newcust As Customer = CType(newValue, Customer)

                oldcust.parent = Nothing
                newcust.parent = Me

                OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, index))
            End If
        End Sub 


        ' Called by Customer when it changes.
        Friend Sub CustomerChanged(ByVal cust As Customer)
            Dim index As Integer = List.IndexOf(cust)
            OnListChanged(New ListChangedEventArgs(ListChangedType.ItemChanged, index))
        End Sub 


        ' Implements IBindingList.

        ReadOnly Property AllowEdit() As Boolean Implements IBindingList.AllowEdit
            Get
                Return True
            End Get
        End Property

        ReadOnly Property AllowNew() As Boolean Implements IBindingList.AllowNew
            Get
                Return True
            End Get
        End Property

        ReadOnly Property AllowRemove() As Boolean Implements IBindingList.AllowRemove
            Get
                Return True
            End Get
        End Property

        ReadOnly Property SupportsChangeNotification() As Boolean Implements IBindingList.SupportsChangeNotification
            Get
                Return True
            End Get
        End Property

        ReadOnly Property SupportsSearching() As Boolean Implements IBindingList.SupportsSearching
            Get
                Return False
            End Get
        End Property

        ReadOnly Property SupportsSorting() As Boolean Implements IBindingList.SupportsSorting
            Get
                Return False
            End Get
        End Property

        ' Events.
        Public Event ListChanged As ListChangedEventHandler Implements IBindingList.ListChanged


        ' Methods.
        Function AddNew() As Object Implements IBindingList.AddNew
            Dim c As New Customer(Me.Count.ToString())
            List.Add(c)
            Return c
        End Function 


        ' Unsupported properties.

        ReadOnly Property IsSorted() As Boolean Implements IBindingList.IsSorted
            Get
                Throw New NotSupportedException()
            End Get
        End Property

        ReadOnly Property SortDirection() As ListSortDirection Implements IBindingList.SortDirection
            Get
                Throw New NotSupportedException()
            End Get
        End Property


        ReadOnly Property SortProperty() As PropertyDescriptor Implements IBindingList.SortProperty
            Get
                Throw New NotSupportedException()
            End Get
        End Property


        ' Unsupported Methods.
        Sub AddIndex(ByVal prop As PropertyDescriptor) Implements IBindingList.AddIndex
            Throw New NotSupportedException()
        End Sub 


        Sub ApplySort(ByVal prop As PropertyDescriptor, ByVal direction As ListSortDirection) Implements IBindingList.ApplySort
            Throw New NotSupportedException()
        End Sub 


        Function Find(ByVal prop As PropertyDescriptor, ByVal key As Object) As Integer Implements IBindingList.Find
            Throw New NotSupportedException()
        End Function 


        Sub RemoveIndex(ByVal prop As PropertyDescriptor) Implements IBindingList.RemoveIndex
            Throw New NotSupportedException()
        End Sub 


        Sub RemoveSort() Implements IBindingList.RemoveSort
            Throw New NotSupportedException()
        End Sub 


        ' Worker functions to populate the list with data.
        Private Shared Function ReadCustomer1() As Customer
            Dim cust As New Customer("536-45-1245")
            cust.FirstName = "Jo"
            cust.LastName = "Brown"
            Return cust
        End Function 


        Private Shared Function ReadCustomer2() As Customer
            Dim cust As New Customer("246-12-5645")
            cust.FirstName = "Robert"
            cust.LastName = "Brown"
            Return cust
        End Function 
    End Class

    '</snippet2>

End Class
