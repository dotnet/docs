'<SnippetDataTemplateSelector>

Namespace SDKSample
	Public Class AuctionItemDataTemplateSelector
		Inherits DataTemplateSelector
		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate

            Dim element As FrameworkElement = TryCast(container, FrameworkElement)

            If element isnot Nothing andalso item IsNot Nothing AndAlso TypeOf item Is AuctionItem Then

                Dim auctionItem As AuctionItem = TryCast(item, AuctionItem)

                Select Case auctionItem.SpecialFeatures
                    Case SpecialFeatures.None
                        Return TryCast(element.FindResource("AuctionItem_None"), DataTemplate)
                    Case SpecialFeatures.Color
                        Return TryCast(element.FindResource("AuctionItem_Color"), DataTemplate)
                End Select
            End If

			Return Nothing
		End Function
	End Class
End Namespace
'</SnippetDataTemplateSelector>
