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
