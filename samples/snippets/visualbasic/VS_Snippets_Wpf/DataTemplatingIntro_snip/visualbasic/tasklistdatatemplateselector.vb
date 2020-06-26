'<SnippetDTSClass>

Namespace SDKSample
	Public Class TaskListDataTemplateSelector
		Inherits DataTemplateSelector
		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate

            Dim element As FrameworkElement
            element = TryCast(container, FrameworkElement)

            If element IsNot Nothing AndAlso item IsNot Nothing AndAlso TypeOf item Is Task Then

                Dim taskitem As Task = TryCast(item, Task)

                If taskitem.Priority = 1 Then
                    Return TryCast(element.FindResource("importantTaskTemplate"), DataTemplate)
                Else
                    Return TryCast(element.FindResource("myTaskTemplate"), DataTemplate)
                End If
            End If

			Return Nothing
		End Function
	End Class
End Namespace
'</SnippetDTSClass>