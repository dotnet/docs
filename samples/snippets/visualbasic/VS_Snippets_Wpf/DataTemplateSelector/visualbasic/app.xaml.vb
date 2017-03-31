Imports System.Xml
Imports System.Configuration
Imports System.Collections.ObjectModel


Namespace SDKSample
	''' <summary>
	''' Interaction logic for app.xaml
	''' </summary>

	Partial Public Class app
		Inherits Application
		Private Sub AppStartup(ByVal sender As Object, ByVal args As StartupEventArgs)
			LoadAuctionData()
			Dim mainWindow As New Window1()

			mainWindow.Show()
		End Sub
        Private _auctionItems As New ObservableCollection(Of AuctionItem)()

		Public Property AuctionItems() As ObservableCollection(Of AuctionItem)
			Get
                Return Me._auctionItems
			End Get
			Set(ByVal value As ObservableCollection(Of AuctionItem))
                Me._auctionItems = value
			End Set
		End Property

		Public Sub LoadAuctionData()
		  Dim item As AuctionItem
		  item = New AuctionItem()
		  item.Description = "SnowBoard"
		  item.CurrentPrice = 500
		  Me.AuctionItems.Add(item)

		  item = New AuctionItem()
		  item.Description = "Soccer"
		  item.SpecialFeatures = SpecialFeatures.Color
		  item.CurrentPrice = 100
		  Me.AuctionItems.Add(item)


		  item = New AuctionItem()
		  item.Description = "bike"
		  item.SpecialFeatures = SpecialFeatures.Color
		  item.CurrentPrice = 530

		  Me.AuctionItems.Add(item)


		  item = New AuctionItem()
		  item.Description = "Laptop"
		  item.SpecialFeatures = SpecialFeatures.Color
		  item.CurrentPrice = 720

		  Me.AuctionItems.Add(item)

		  item = New AuctionItem()
		  item.Description = "tennis"
		  item.SpecialFeatures = SpecialFeatures.Color
		  item.CurrentPrice = 222
		  Me.AuctionItems.Add(item)

		  item = New AuctionItem()


		  item = New AuctionItem()
		  item.Description = "Digital camera"
		  item.CurrentPrice = 680

		  Me.AuctionItems.Add(item)


		  item = New AuctionItem()
		  item.Description = "Keyboard"
		  item.CurrentPrice = 55

		  Me.AuctionItems.Add(item)


		End Sub
	End Class
End Namespace