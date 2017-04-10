Imports System.Collections.ObjectModel

Partial Public Class DataBindingLabApp
    Inherits Application

    Private CurrentUserValue As User
    Private AuctionItemsValue As New ObservableCollection(Of AuctionItem)

    Private Sub AppStartup(ByVal sender As Object, ByVal e As StartupEventArgs)
        LoadAuctionData()
        Dim MyMainWindow As MainWindow = New MainWindow
        MyMainWindow.Show()
        'Dim MyAddProductWindow As AddProductWindow = New AddProductWindow
        'MyAddProductWindow.Show()
    End Sub

    Public Property CurrentUser() As User
        Get
            Return CurrentUserValue
        End Get
        Set(ByVal value As User)
            CurrentUserValue = value
        End Set
    End Property

    Public Property AuctionItems() As ObservableCollection(Of AuctionItem)
        Get
            Return AuctionItemsValue
        End Get
        Set(ByVal value As ObservableCollection(Of AuctionItem))
            AuctionItemsValue = value
        End Set
    End Property

    Private Sub LoadAuctionData()
        CurrentUser = New User("John", 12, New DateTime(2003, 4, 20))

        Dim userMary As User = New User("Mary", 10, New DateTime(2000, 5, 2))
        Dim userAnna As User = New User("Anna", 5, New DateTime(2001, 9, 13))
        Dim userMike As User = New User("Mike", 13, New DateTime(1999, 11, 23))
        Dim userMark As User = New User("Mark", 15, New DateTime(2004, 6, 3))

        Dim camera As AuctionItem = New AuctionItem("Digital camera - good condition", ProductCategory.Electronics, 300, New DateTime(2005, 8, 23), userAnna, SpecialFeatures.None)
        camera.AddBid(New Bid(310, userMike))
        camera.AddBid(New Bid(312, userMark))
        camera.AddBid(New Bid(314, userMike))
        camera.AddBid(New Bid(320, userMark))

        Dim snowBoard As AuctionItem = New AuctionItem("Snowboard and bindings", ProductCategory.Sports, 120, New DateTime(2005, 7, 12), userMike, SpecialFeatures.Highlight)
        snowBoard.AddBid(New Bid(140, userAnna))
        snowBoard.AddBid(New Bid(142, userMary))
        snowBoard.AddBid(New Bid(150, userAnna))

        Dim insideCSharp As AuctionItem = New AuctionItem("Inside C#, second edition", ProductCategory.Books, 10, New DateTime(2005, 5, 29), Me.CurrentUser, SpecialFeatures.Color)
        insideCSharp.AddBid(New Bid(11, userMark))
        insideCSharp.AddBid(New Bid(13, userAnna))
        insideCSharp.AddBid(New Bid(14, userMary))
        insideCSharp.AddBid(New Bid(15, userAnna))

        Dim laptop As AuctionItem = New AuctionItem("Laptop - only 1 year old", ProductCategory.Computers, 500, New DateTime(2005, 8, 15), userMark, SpecialFeatures.Highlight)
        laptop.AddBid(New Bid(510, Me.CurrentUser))

        Dim setOfChairs As AuctionItem = New AuctionItem("Set of 6 chairs", ProductCategory.Home, 120, New DateTime(2005, 2, 20), userMike, SpecialFeatures.Color)

        Dim myDVDCollection As AuctionItem = New AuctionItem("My DVD Collection", ProductCategory.DVDs, 5, New DateTime(2005, 8, 3), userMary, SpecialFeatures.Highlight)
        myDVDCollection.AddBid(New Bid(6, userMike))
        myDVDCollection.AddBid(New Bid(8, Me.CurrentUser))

        Dim tvDrama As AuctionItem = New AuctionItem("TV Drama Series", ProductCategory.DVDs, 40, New DateTime(2005, 7, 28), userAnna, SpecialFeatures.None)
        tvDrama.AddBid(New Bid(42, userMike))
        tvDrama.AddBid(New Bid(45, userMark))
        tvDrama.AddBid(New Bid(50, userMike))
        tvDrama.AddBid(New Bid(51, Me.CurrentUser))

        Dim squashRacket As AuctionItem = New AuctionItem("Squash racket", ProductCategory.Sports, 60, New DateTime(2005, 4, 4), userMark, SpecialFeatures.Highlight)
        squashRacket.AddBid(New Bid(62, userMike))
        squashRacket.AddBid(New Bid(65, userAnna))

        Me.AuctionItems.Add(camera)
        Me.AuctionItems.Add(snowBoard)
        Me.AuctionItems.Add(insideCSharp)
        Me.AuctionItems.Add(laptop)
        Me.AuctionItems.Add(setOfChairs)
        Me.AuctionItems.Add(myDVDCollection)
        Me.AuctionItems.Add(tvDrama)
        Me.AuctionItems.Add(squashRacket)
    End Sub
End Class
