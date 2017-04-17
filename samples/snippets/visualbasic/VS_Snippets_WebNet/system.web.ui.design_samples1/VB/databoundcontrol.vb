Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Collections
Imports System.Diagnostics
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Examples.AspNet

   <DefaultEvent("SelectedIndexChanged"), _ 
      DefaultProperty("DataSource"), _
      DesignerAttribute(GetType(Examples.AspNet.Design.TemplatedListDesigner), _
       GetType(IDesigner))> _
   Public Class TemplatedList
      Inherits WebControl
      Implements INamingContainer

      
#Region "Statics and Constants"
      Private Shared EventSelectedIndexChanged As New Object()
      Private Shared EventItemCreated As New Object()
      Private Shared EventItemDataBound As New Object()
      Private Shared EventItemCommand As New Object()
#End Region

#Region "Member variables"
      Private _dataSource As IEnumerable
      Private _itemStyle As TableItemStyle '
      Private _alternatingItemStyle As TableItemStyle
      Private _selectedItemStyle As TableItemStyle
      Private _itemTemplate As ITemplate
#End Region

#Region "Properties"

      Public Overridable ReadOnly Property AlternatingItemStyle() As TableItemStyle
         Get
            If _alternatingItemStyle Is Nothing Then
               _alternatingItemStyle = New TableItemStyle()
               If IsTrackingViewState Then
                  CType(_alternatingItemStyle, IStateManager).TrackViewState()
               End If
            End If
            Return _alternatingItemStyle
         End Get
      End Property

      Public Overridable Property CellPadding() As Integer
         Get
            If ControlStyleCreated = False Then
               Return - 1
            End If
            Return CType(ControlStyle, TableStyle).CellPadding
         End Get
         Set
            CType(ControlStyle, TableStyle).CellPadding = value
         End Set
      End Property


      Public Overridable Property CellSpacing() As Integer
         Get
            If ControlStyleCreated = False Then
               Return 0
            End If
            Return CType(ControlStyle, TableStyle).CellSpacing
         End Get
         Set
            CType(ControlStyle, TableStyle).CellSpacing = value
         End Set
      End Property

      Public Property DataSource() As IEnumerable
         Get
            Return _dataSource
         End Get
         Set
            _dataSource = value
         End Set
      End Property

      Public Overridable Property GridLines() As GridLines
         Get
            If ControlStyleCreated = False Then
               Return GridLines.None
            End If
            Return CType(ControlStyle, TableStyle).GridLines
         End Get
         Set
            CType(ControlStyle, TableStyle).GridLines = value
         End Set
      End Property


      Public Overridable ReadOnly Property ItemStyle() As TableItemStyle
         Get
            If _itemStyle Is Nothing Then
               _itemStyle = New TableItemStyle()
               If IsTrackingViewState Then
                  CType(_itemStyle, IStateManager).TrackViewState()
               End If
            End If
            Return _itemStyle
         End Get
      End Property


      Public Overridable Property ItemTemplate() As ITemplate
         Get
            Return _itemTemplate
         End Get
         Set
            _itemTemplate = value
         End Set
      End Property


      Public Overridable Property SelectedIndex() As Integer
         Get
            Dim o As Object = ViewState("SelectedIndex")
            If Not (o Is Nothing) Then
               Return CInt(o)
            End If
            Return - 1
         End Get
         Set
            If value < - 1 Then
               Throw New ArgumentOutOfRangeException()
            End If
            Dim oldSelectedIndex As Integer = SelectedIndex
            ViewState("SelectedIndex") = value
            
            If HasControls() Then
               Dim table As Table = CType(Controls(0), Table)
               Dim item As TemplatedListItem
               
               If oldSelectedIndex <> - 1 And table.Rows.Count > oldSelectedIndex Then
                  item = CType(table.Rows(oldSelectedIndex), TemplatedListItem)
                  
                  If item.ItemType <> ListItemType.EditItem Then
                     Dim itemType As ListItemType = ListItemType.Item
                     If oldSelectedIndex Mod 2 <> 0 Then
                        itemType = ListItemType.AlternatingItem
                     End If
                     item.SetItemType(itemType)
                  End If
               End If
               If value <> - 1 And table.Rows.Count > value Then
                  item = CType(table.Rows(value), TemplatedListItem)
                  item.SetItemType(ListItemType.SelectedItem)
               End If
            End If
         End Set
      End Property


      Public Overridable ReadOnly Property SelectedItemStyle() As TableItemStyle
         Get
            If _selectedItemStyle Is Nothing Then
               _selectedItemStyle = New TableItemStyle()
               If IsTrackingViewState Then
                  CType(_selectedItemStyle, IStateManager).TrackViewState()
               End If
            End If
            Return _selectedItemStyle
         End Get
      End Property
#End Region
      
#Region "Events"
      Protected Overridable Sub OnItemCommand(e As TemplatedListCommandEventArgs)
         Dim onItemCommandHandler As TemplatedListCommandEventHandler = CType(Events(EventItemCommand), TemplatedListCommandEventHandler)
         If Not (onItemCommandHandler Is Nothing) Then
            onItemCommandHandler(Me, e)
         End If
      End Sub
       
      Protected Overridable Sub OnItemCreated(e As TemplatedListItemEventArgs)
         Dim onItemCreatedHandler As TemplatedListItemEventHandler = CType(Events(EventItemCreated), TemplatedListItemEventHandler)
         If Not (onItemCreatedHandler Is Nothing) Then
            onItemCreatedHandler(Me, e)
         End If
      End Sub
       
      Protected Overridable Sub OnItemDataBound(e As TemplatedListItemEventArgs)
         Dim onItemDataBoundHandler As TemplatedListItemEventHandler = CType(Events(EventItemDataBound), TemplatedListItemEventHandler)
         If Not (onItemDataBoundHandler Is Nothing) Then
            onItemDataBoundHandler(Me, e)
         End If
      End Sub
       
      Protected Overridable Sub OnSelectedIndexChanged(e As EventArgs)
         Dim handler As EventHandler = CType(Events(EventSelectedIndexChanged), EventHandler)
         If Not (handler Is Nothing) Then
            handler(Me, e)
         End If
      End Sub
      

      Public Event ItemCommand As TemplatedListCommandEventHandler
      

      Public Event ItemCreated As TemplatedListItemEventHandler
      
      Public Event ItemDataBound As TemplatedListItemEventHandler
      
      Public Event SelectedIndexChanged As EventHandler
#End Region

#Region "Methods and Implementation"
      Protected Overrides Sub CreateChildControls()
         Controls.Clear() 
         If Not (ViewState("ItemCount") Is Nothing) Then
            ' Create the control hierarchy using the view state, 
            ' not the data source.
            CreateControlHierarchy(False)
         End If
      End Sub
      
      Private Sub CreateControlHierarchy(useDataSource As Boolean)
         Dim dataSource As IEnumerable = Nothing
         Dim count As Integer = - 1
         
         If useDataSource = False Then
            ' ViewState must have a non-null value for ItemCount 
            ' because this is checked in CreateChildControls.
            count = CInt(ViewState("ItemCount"))
            If count <> - 1 Then
               dataSource = New DummyDataSource(count)
            End If
         Else
            dataSource = Me._dataSource
         End If
         
         If Not (dataSource Is Nothing) Then
            Dim table As New Table()
            Controls.Add(table)
            
            Dim selectedItemIndex As Integer = SelectedIndex
            Dim index As Integer = 0
            
            count = 0
            Dim dataItem As Object
            For Each dataItem In  dataSource
               Dim itemType As ListItemType = ListItemType.Item
               If index = selectedItemIndex Then
                  itemType = ListItemType.SelectedItem
               Else
                  If index Mod 2 <> 0 Then
                     itemType = ListItemType.AlternatingItem
                  End If
               End If 
               CreateItem(table, index, itemType, useDataSource, dataItem)
               count += 1
               index += 1
            Next dataItem
         End If
         
         If useDataSource Then
            ' Save the number of items contained for use in round trips.
            If Not (dataSource Is Nothing) Then
               ViewState("ItemCount") = count
            Else
               ViewState("ItemCount") = -1
            End If
         End If
      End Sub
      
      
      Protected Overrides Function CreateControlStyle() As Style
         ' Since the TemplatedList control renders an HTML table, 
         ' an instance of  the TableStyle class is used as the control style.
         Dim style As New TableStyle(ViewState)
         ' Set up default initial state.
         style.CellSpacing = 0
         Return style
      End Function
      
      Private Function CreateItem(table As Table, itemIndex As Integer, _
        itemType As ListItemType, dataBind As Boolean, _
        dataItem As Object) As TemplatedListItem
         Dim item As New TemplatedListItem(itemIndex, itemType)
         Dim e As New TemplatedListItemEventArgs(item)
         
         If Not (_itemTemplate Is Nothing) Then
            _itemTemplate.InstantiateIn(item.Cells(0))
         End If
         If dataBind Then
            item.DataItem = dataItem
         End If
         OnItemCreated(e)
         table.Rows.Add(item)
         
         If dataBind Then
            item.DataBind()
            OnItemDataBound(e)
            
            item.DataItem = Nothing
         End If
         
         Return item
      End Function
      
      Public Overrides Sub DataBind()
         ' Controls with a data-source property perform their custom data binding
         ' by overriding DataBind.
         ' Evaluate any data-binding expressions on the control itself.
         MyBase.OnDataBinding(EventArgs.Empty)
         
         ' Reset the control state.
         Controls.Clear()
         ClearChildViewState()
         
         '  Create the control hierarchy using the data source.
         CreateControlHierarchy(True)
         ChildControlsCreated = True
         
         TrackViewState()
      End Sub
      
      Protected Overrides Sub LoadViewState(savedState As Object)
         ' Customized state management to handle saving state of contained objects.
         If Not (savedState Is Nothing) Then
            Dim myState As Object() = CType(savedState, Object())
            
            If Not (myState(0) Is Nothing) Then
               MyBase.LoadViewState(myState(0))
            End If
            If Not (myState(1) Is Nothing) Then
               CType(ItemStyle, IStateManager).LoadViewState(myState(1))
            End If
            If Not (myState(2) Is Nothing) Then
               CType(SelectedItemStyle, IStateManager).LoadViewState(myState(2))
            End If
            If Not (myState(3) Is Nothing) Then
               CType(AlternatingItemStyle, IStateManager).LoadViewState(myState(3))
            End If
         End If
      End Sub
       
      Protected Overrides Function OnBubbleEvent( _
        source As Object, e As EventArgs) As Boolean
         ' Handle events raised by children by overriding OnBubbleEvent.
         Dim handled As Boolean = False
         
         If TypeOf e Is TemplatedListCommandEventArgs Then
            Dim ce As TemplatedListCommandEventArgs = CType( _
              e, TemplatedListCommandEventArgs)
            
            OnItemCommand(ce)
            handled = True
            
            If String.Compare(ce.CommandName, "Select", True) = 0 Then
               SelectedIndex = ce.Item.ItemIndex
               OnSelectedIndexChanged(EventArgs.Empty)
            End If
         End If
         
         Return handled
      End Function
      
      Private Sub PrepareControlHierarchy()
         If HasControls() = False Then
            Return
         End If
         
         Debug.Assert(TypeOf Controls(0) Is Table)
         Dim table As Table = CType(Controls(0), Table)
         
         table.CopyBaseAttributes(Me)
         If ControlStyleCreated Then
            table.ApplyStyle(ControlStyle)
         End If
         
         ' The composite alternating item style; do just one
         ' merge style on the actual item.
         Dim altItemStyle As Style = Nothing
         If Not (_alternatingItemStyle Is Nothing) Then
            altItemStyle = New TableItemStyle()
            altItemStyle.CopyFrom(_itemStyle)
            altItemStyle.CopyFrom(_alternatingItemStyle)
         Else
            altItemStyle = _itemStyle
         End If
         
         Dim rowCount As Integer = table.Rows.Count
         Dim i As Integer
         For i = 0 To rowCount - 1
            Dim item As TemplatedListItem = CType(table.Rows(i), TemplatedListItem)
            Dim compositeStyle As Style = Nothing
            
            Select Case item.ItemType
               Case ListItemType.Item
                  compositeStyle = _itemStyle
               
               Case ListItemType.AlternatingItem
                  compositeStyle = altItemStyle
               
               Case ListItemType.SelectedItem
                  If (True) Then
                     compositeStyle = New TableItemStyle()
                     
                     If item.ItemIndex Mod 2 <> 0 Then
                        compositeStyle.CopyFrom(altItemStyle)
                     Else
                        compositeStyle.CopyFrom(_itemStyle)
                     End If
                     compositeStyle.CopyFrom(_selectedItemStyle)
                  End If
            End Select
            
            If Not (compositeStyle Is Nothing) Then
               item.MergeStyle(compositeStyle)
            End If
         Next i
      End Sub
      
      Protected Overrides Sub Render(writer As HtmlTextWriter)
         ' Apply styles to the control hierarchy
         ' and then render it out.
         ' Apply styles during render phase, so the user can change styles
         ' after calling DataBind without the property changes ending
         ' up in view state.
         PrepareControlHierarchy()
         
         RenderContents(writer)
      End Sub
      
      Protected Overrides Function SaveViewState() As Object
         ' Customize state management to handle saving state
         ' of contained objects such as styles.
         Dim baseState As Object = MyBase.SaveViewState()
         Dim itemStyleState As Object 
         Dim selectedItemStyleState As Object
         Dim alternatingItemStyleState As Object

         If Not (_itemStyle Is Nothing) Then 
            itemStyleState = CType(_itemStyle, IStateManager).SaveViewState()
         Else
            itemStyleState = Nothing
         End If

         If Not (_selectedItemStyle Is Nothing) Then
            selectedItemStyleState = CType( _
              _selectedItemStyle, IStateManager).SaveViewState()
         Else
            selectedItemStyleState = Nothing
         End If

         If Not (_alternatingItemStyle Is Nothing) Then
            alternatingItemStyleState = CType( _
             _alternatingItemStyle, IStateManager).SaveViewState()
         Else
            alternatingItemStyleState = Nothing
         End If
        
         Dim myState(4) As Object
         myState(0) = baseState
         myState(1) = itemStyleState
         myState(2) = selectedItemStyleState
         myState(3) = alternatingItemStyleState
         
         Return myState
      End Function
      
      Protected Overrides Sub TrackViewState()
         ' Customize state management to handle saving state
         ' of contained objects such as styles.
         MyBase.TrackViewState()
         
         If Not (_itemStyle Is Nothing) Then
            CType(_itemStyle, IStateManager).TrackViewState()
         End If
         If Not (_selectedItemStyle Is Nothing) Then
            CType(_selectedItemStyle, IStateManager).TrackViewState()
         End If
         If Not (_alternatingItemStyle Is Nothing) Then
            CType(_alternatingItemStyle, IStateManager).TrackViewState()
         End If
      End Sub
 #End Region
   End Class
   
   Public Class TemplatedListItem
      Inherits TableRow
      Implements INamingContainer
      Private _itemIndex As Integer
      Private _itemType As ListItemType
      Private _dataItem As Object
      
      Public Sub New(itemIndex As Integer, itemType As ListItemType)
         Me._itemIndex = itemIndex
         Me._itemType = itemType
         
         Cells.Add(New TableCell())
      End Sub
      
      Public Overridable Property DataItem() As Object
         Get
            Return _dataItem
         End Get
         Set
            _dataItem = value
         End Set
      End Property
      
      Public Overridable ReadOnly Property ItemIndex() As Integer
         Get
            Return _itemIndex
         End Get
      End Property
      
      Public Overridable ReadOnly Property ItemType() As ListItemType
         Get
            Return _itemType
         End Get
      End Property
      
      Protected Overrides Function OnBubbleEvent( _
      source As Object, e As EventArgs) As Boolean
         If TypeOf e Is CommandEventArgs Then
            ' Add the information about Item to CommandEvent.
            Dim args As New TemplatedListCommandEventArgs( _
             Me, source, CType(e, CommandEventArgs))
            
            RaiseBubbleEvent(Me, args)
            Return True
         End If
         Return False
      End Function
      
      Friend Sub SetItemType(itemType As ListItemType)
         Me._itemType = itemType
      End Sub
   End Class
   
   NotInheritable Public Class TemplatedListCommandEventArgs
      Inherits CommandEventArgs
      
      Private _item As TemplatedListItem
      Private _commandSource As Object
      
      Public Sub New(item As TemplatedListItem, commandSource As Object, _
        originalArgs As CommandEventArgs)
         MyBase.New(originalArgs)
         Me._item = item
         Me._commandSource = commandSource
      End Sub
      
      Public ReadOnly Property Item() As TemplatedListItem
         Get
            Return _item
         End Get
      End Property
      
      
      Public ReadOnly Property CommandSource() As Object
         Get
            Return _commandSource
         End Get
      End Property
   End Class
   
   Public Delegate Sub TemplatedListCommandEventHandler(source As Object, _
    e As TemplatedListCommandEventArgs)
   
   NotInheritable Public Class TemplatedListItemEventArgs
      Inherits EventArgs
      
      Private _item As TemplatedListItem
      
      Public Sub New(item As TemplatedListItem)
         Me._item = item
      End Sub
      
      Public ReadOnly Property Item() As TemplatedListItem
         Get
            Return _item
         End Get
      End Property
   End Class
   
   Public Delegate Sub TemplatedListItemEventHandler(sender As Object, _
     e As TemplatedListItemEventArgs)
   
   NotInheritable Friend Class DummyDataSource
      Implements ICollection
      
      Private dataItemCount As Integer
      
      Public Sub New(dataItemCount As Integer)
         Me.dataItemCount = dataItemCount
      End Sub
      
      Public ReadOnly Property Count() As Integer Implements ICollection.Count
         Get
            Return dataItemCount
         End Get
      End Property
      
      Public ReadOnly Property IsReadOnly() As Boolean
         Get
            Return False
         End Get
      End Property
      
      Public ReadOnly Property IsSynchronized() As Boolean _
       Implements ICollection.IsSynchronized
         Get
            Return False
         End Get
      End Property
      
      Public ReadOnly Property SyncRoot() As Object Implements ICollection.SyncRoot
         Get
            Return Me
         End Get
      End Property
      
      Public Sub CopyTo(array As Array, index As Integer) Implements ICollection.CopyTo
         Dim e As IEnumerator
         
         While e.MoveNext()
            array.SetValue(e.Current, index)
            index += 1
         End While
      End Sub
       
      Public Function GetEnumerator() As IEnumerator _
       Implements ICollection.GetEnumerator
         Return New DummyDataSourceEnumerator(dataItemCount)
      End Function
      
      Private Class DummyDataSourceEnumerator
         Implements IEnumerator
         
         Private count As Integer
         Private index As Integer
         
         Public Sub New(count As Integer)
            Me.count = count
            Me.index = - 1
         End Sub
         
         Public ReadOnly Property Current() As Object Implements IEnumerator.Current
            Get
               Return Nothing
            End Get
         End Property
         
         Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            index += 1
            Return index < count
         End Function
         
         Public Sub Reset() Implements IEnumerator.Reset
            Me.index = - 1
         End Sub
      End Class
   End Class
End Namespace
