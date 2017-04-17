'<Snippet2>
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Drawing

Namespace UpdatePanelTutorialCustom.VB

    Public Class ProductsView
        Inherits CompositeControl

        Private _pageSize As Integer
        Private _cart As ArrayList
        Private Shared ReadOnly EventRowCommand As Object = New Object()

        Public Property PageSize() As Integer
            Get
                Return _pageSize
            End Get
            Set(ByVal value As Integer)
                _pageSize = value
            End Set
        End Property


        Public ReadOnly Property Cart() As ArrayList
            Get
                Return _cart
            End Get
        End Property

        '<Snippet3>
        Protected Overrides Sub CreateChildControls()
            MyBase.CreateChildControls()

            Dim parent As Control
            Dim container As Control

            ' Get a reference to the ScriptManager object for the page
            ' if one exists.
            Dim sm As ScriptManager = ScriptManager.GetCurrent(Page)

            If sm Is Nothing OrElse Not sm.EnablePartialRendering Then
                ' If partial rendering is not enabled, set the parent
                ' and container as a basic control. 
                container = New Control()
                parent = container
            Else
                ' If partial rendering is enabled, set the parent as
                ' a new UpdatePanel object and the container to the 
                ' content template of the UpdatePanel object.
                Dim up As UpdatePanel = New UpdatePanel()
                container = up.ContentTemplateContainer
                parent = up
            End If

            AddDataboundControls(container)

            Controls.Add(parent)
        End Sub
        '</Snippet3>

        Private Sub GridView_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

            Dim productID As String

            If e.CommandName = "AddToCart" Then
                productID = CType(sender, GridView).DataKeys(Convert.ToInt32(e.CommandArgument)).Value.ToString()
                If _cart Is Nothing Then GetCart()
                If _cart.IndexOf(productID) = -1 Then _
                    _cart.Add(productID)
                ViewState("Cart") = _cart
            End If

            If e.CommandName = "RemoveFromCart" Then
                productID = CType(sender, GridView).DataKeys(Convert.ToInt32(e.CommandArgument)).Value.ToString()
                If _cart Is Nothing Then GetCart()
                _cart.Remove(productID)
                ViewState("Cart") = _cart
            End If

            Me.OnRowCommand(New EventArgs())
        End Sub

        Private Sub GetCart()
            If ViewState("Cart") Is Nothing Then
                _cart = New ArrayList()
            Else
                _cart = CType(ViewState("Cart"), ArrayList)
            End If
        End Sub

        Custom Event RowCommand As EventHandler
            RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
            End RaiseEvent
            AddHandler(ByVal value As EventHandler)
                Events.AddHandler(EventRowCommand, value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler)
                Events.RemoveHandler(EventRowCommand, value)
            End RemoveHandler
        End Event

        Protected Overridable Sub OnRowCommand(ByVal e As EventArgs)
            Dim handler As EventHandler = CType(Events(EventRowCommand), EventHandler)
            If handler IsNot Nothing Then
                handler(Me, e)
            End If
        End Sub

        Private Sub AddDataboundControls(ByVal parent As Control)
            Dim ds As SqlDataSource = New SqlDataSource()
            ds.ID = "ProductsSqlDataSource"
            ds.ConnectionString = _
              ConfigurationManager.ConnectionStrings("AdventureWorksConnectionString").ConnectionString
            ds.SelectCommand = _
              "SELECT Production.ProductDescription.Description, Production.Product.Name, Production.ProductPhoto.ThumbnailPhotoFileName, " & _
              "Production.Product.ProductID " & _
              "FROM Production.Product INNER JOIN " & _
              "Production.ProductProductPhoto ON Production.Product.ProductID = Production.ProductProductPhoto.ProductID INNER JOIN " & _
              "Production.ProductPhoto ON Production.ProductProductPhoto.ProductPhotoID = Production.ProductPhoto.ProductPhotoID INNER JOIN " & _
              "Production.ProductModelProductDescriptionCulture ON  " & _
              "Production.Product.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID INNER JOIN " & _
              "Production.ProductDescription ON  " & _
              "Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID"

            Dim gv As GridView = New GridView()
            gv.ID = "ProductsGridView"
            gv.DataSourceID = ds.ID
            gv.AutoGenerateColumns = False
            gv.DataKeyNames = New String() {"ProductID"}
            gv.GridLines = GridLines.None
            gv.HeaderStyle.BackColor = Color.LightGray
            gv.AlternatingRowStyle.BackColor = Color.LightBlue
            gv.AllowPaging = True
            gv.PageSize = _pageSize
            AddHandler gv.RowCommand, AddressOf Me.GridView_RowCommand

            Dim if1 As ImageField = New ImageField()
            if1.HeaderText = "Product"
            if1.DataImageUrlField = "ThumbnailPhotoFileName"
            if1.DataImageUrlFormatString = "..\images\thumbnails\{0}"

            Dim bf1 As BoundField = New BoundField()
            bf1.HeaderText = "Name"
            bf1.DataField = "Name"

            Dim bf2 As BoundField = New BoundField()
            bf2.HeaderText = "Description"
            bf2.DataField = "Description"

            Dim btf1 As ButtonField = New ButtonField()
            btf1.Text = "Add"
            btf1.CommandName = "AddToCart"

            Dim btf2 As ButtonField = New ButtonField()
            btf2.Text = "Remove"
            btf2.CommandName = "RemoveFromCart"

            gv.Columns.Add(if1)
            gv.Columns.Add(bf1)
            gv.Columns.Add(bf2)
            gv.Columns.Add(btf1)
            gv.Columns.Add(btf2)

            parent.Controls.Add(New LiteralControl("<br />"))
            parent.Controls.Add(gv)
            parent.Controls.Add(New LiteralControl("<br />"))
            parent.Controls.Add(ds)
        End Sub
    End Class
End Namespace
'</Snippet2>
