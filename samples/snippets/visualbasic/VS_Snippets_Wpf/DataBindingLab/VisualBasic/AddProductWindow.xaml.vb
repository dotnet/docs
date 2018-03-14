Partial Public Class AddProductWindow
    Inherits Window

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub SubmitProduct(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim item As AuctionItem = CType((Me.DataContext), AuctionItem)
        CType(Application.Current, DataBindingLabApp).AuctionItems.Add(item)
        Me.Close()
    End Sub

    Private Sub OnInit(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.DataContext = New AuctionItem("Type your description here", ProductCategory.DVDs, 1, DateTime.Now, CType(Application.Current, DataBindingLabApp).CurrentUser, SpecialFeatures.None)
    End Sub

End Class
