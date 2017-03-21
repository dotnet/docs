	<CollectionDataContract(Name := "Custom{0}List", ItemName := "CustomItem")> _
	Public Class CustomList(Of T)
		Inherits List(Of T)
		Public Sub New()
			MyBase.New()
		End Sub

		Public Sub New(ByVal items() As T)
			MyBase.New()
			For Each item As T In items
				Add(item)
			Next item
		End Sub
	End Class