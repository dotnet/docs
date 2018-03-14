'This is a list of commonly used namespaces for a pane.

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Shapes
Imports System.Windows.Media


Namespace SDKSample
	''' <summary>
	''' Interaction logic for Pane1.xaml
	''' </summary>

	Partial Public Class Pane1
		Inherits Window

		Private Sub TimingSnippets(ByVal ellipse1 As Ellipse)
			'set tooltip timing 
			'<SnippetToolTipServiceTimingCode>

			'<SnippetSetInitialShowDelay>
			ToolTipService.SetInitialShowDelay(ellipse1, 1000)
			'</SnippetSetInitialShowDelay>

			'<SnippetSetBetweenShowDelay>
			ToolTipService.SetBetweenShowDelay(ellipse1, 2000)
			'</SnippetSetBetweenShowDelay>

			'<SnippetSetShowDuration>
			ToolTipService.SetShowDuration(ellipse1, 7000)
			'</SnippetSetShowDuration>

			'</SnippetToolTipServiceTimingCode>

		End Sub

		Private Sub OnLoad(ByVal sender As Object, ByVal e As RoutedEventArgs)

			'<SnippetToolTipCode>            
			'Create an ellipse that will have a 
			'ToolTip control. 
			Dim ellipse1 As New Ellipse()
			ellipse1.Height = 25
			ellipse1.Width = 50
			ellipse1.Fill = Brushes.Gray
			ellipse1.HorizontalAlignment = HorizontalAlignment.Left

			'Create a tooltip and set its position.
			'<SnippetToolTipControlPlacement>
			Dim tooltip As New ToolTip()
			tooltip.Placement = PlacementMode.Right
			tooltip.PlacementRectangle = New Rect(50, 0, 0, 0)
			tooltip.HorizontalOffset = 10
			tooltip.VerticalOffset = 20
			'</SnippetToolTipControlPlacement>

			'Create BulletDecorator and set it
			'as the tooltip content.
			Dim bdec As New BulletDecorator()
			Dim littleEllipse As New Ellipse()
			littleEllipse.Height = 10
			littleEllipse.Width = 20
			littleEllipse.Fill = Brushes.Blue
			bdec.Bullet = littleEllipse
			Dim tipText As New TextBlock()
			tipText.Text = "Uses the ToolTip class"
			bdec.Child = tipText
			tooltip.Content = bdec

			'set tooltip on ellipse
			ellipse1.ToolTip = tooltip
			'</SnippetToolTipCode>            


			stackPanel_1_1.Children.Add(ellipse1)

			'set event handlers for the Opened and Closed events
			'<SnippetToolTipEventHandlers>
			AddHandler tooltip.Opened, AddressOf whenToolTipOpens
			AddHandler tooltip.Closed, AddressOf whenToolTipCloses
			'</SnippetToolTipEventHandlers>

			'set drop shadow effect
			'<SnippetToolTipHasDropShadow>
			tooltip.HasDropShadow = False
			'</SnippetToolTipHasDropShadow>


			'/////////////////////////////////////////////////////////////////////
			'<SnippetNoToolTipCode>            
			'Create and Ellipse with the BulletDecorator as 
			'the tooltip 
			Dim ellipse2 As New Ellipse()
			ellipse2.Name = "ellipse2"
			Me.RegisterName(ellipse2.Name, ellipse2)
			ellipse2.Height = 25
			ellipse2.Width = 50
			ellipse2.Fill = Brushes.Gray
			ellipse2.HorizontalAlignment = HorizontalAlignment.Left

			'set tooltip timing
			ToolTipService.SetInitialShowDelay(ellipse2, 1000)
			ToolTipService.SetBetweenShowDelay(ellipse2, 2000)
			ToolTipService.SetShowDuration(ellipse2, 7000)

			'set tooltip placement
			'<SnippetNonToolTipControlPlacement>

			'<SnippetSetPlacement>
			ToolTipService.SetPlacement(ellipse2, PlacementMode.Right)
			'</SnippetSetPlacement>

			'<SnippetSetPlacementRectangle>
			ToolTipService.SetPlacementRectangle(ellipse2, New Rect(50, 0, 0, 0))
			'</SnippetSetPlacementRectangle>

			'<SnippetSetHorizontalOffset>
			ToolTipService.SetHorizontalOffset(ellipse2, 10.0)
			'</SnippetSetHorizontalOffset>

			'<SnippetSetVerticalOffset>
			ToolTipService.SetVerticalOffset(ellipse2, 20.0)
			'</SnippetSetVerticalOffset>

			'</SnippetNonToolTipControlPlacement>

			'<SnippetSetHasDropShadow>
			ToolTipService.SetHasDropShadow(ellipse2, False)
			'</SnippetSetHasDropShadow>

			'<SnippetSetIsEnabled>
			ToolTipService.SetIsEnabled(ellipse2, True)
			'</SnippetSetIsEnabled>

			'<SnippetSetShowOnDisabled>
			ToolTipService.SetShowOnDisabled(ellipse2, True)
			'</SnippetSetShowOnDisabled>

			'<SnippetToolTipServiceEventHandlers>
			ellipse2.AddHandler(ToolTipService.ToolTipOpeningEvent, New RoutedEventHandler(AddressOf whenToolTipOpens))
			ellipse2.AddHandler(ToolTipService.ToolTipClosingEvent, New RoutedEventHandler(AddressOf whenToolTipCloses))
			'</SnippetToolTipServiceEventHandlers>

			'define tooltip content
			'<SnippetSetToolTip>
			Dim bdec2 As New BulletDecorator()
			Dim littleEllipse2 As New Ellipse()
			littleEllipse2.Height = 10
			littleEllipse2.Width = 20
			littleEllipse2.Fill = Brushes.Blue
			bdec2.Bullet = littleEllipse2
			Dim tipText2 As New TextBlock()
			tipText2.Text = "Uses the ToolTipService class"
			bdec2.Child = tipText2
			'<SnippetSetToolTip2>
			ToolTipService.SetToolTip(ellipse2, bdec2)
			'</SnippetSetToolTip2>
			stackPanel_1_2.Children.Add(ellipse2)
			'</SnippetSetToolTip>

			'</SnippetNoToolTipCode>            

		End Sub

		'<SnippetToolTipOpenAndCloseHandler>

		'<SnippetToolTipOpeningHandler>
		Private Sub whenToolTipOpens(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim ell As New Ellipse()
			If sender.GetType().FullName.Equals("System.Windows.Shapes.Ellipse") Then
				ell = CType(sender, Ellipse)
				ell.Fill = Brushes.Blue
			ElseIf sender.GetType().FullName.Equals("System.Windows.Controls.ToolTip") Then
				Dim t As ToolTip = CType(sender, ToolTip)
				Dim p As Popup = CType(t.Parent, Popup)
				ell = CType(p.PlacementTarget, Ellipse)
				ell.Fill = Brushes.Blue
			End If
		End Sub
		'</SnippetToolTipOpeningHandler>

		'<SnippetToolTipClosingHandler>
		Private Sub whenToolTipCloses(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim ell As New Ellipse()
			If sender.GetType().FullName.Equals("System.Windows.Shapes.Ellipse") Then
				ell = CType(sender, Ellipse)
				ell.Fill = Brushes.Gray
			ElseIf sender.GetType().FullName.Equals("System.Windows.Controls.ToolTip") Then
				Dim t As ToolTip = CType(sender, ToolTip)
				Dim p As Popup = CType(t.Parent, Popup)
				ell = CType(p.PlacementTarget, Ellipse)
				ell.Fill = Brushes.Gray
			End If
		End Sub
		'</SnippetToolTipClosingHandler>

		'</SnippetToolTipOpenAndCloseHandler>

		Private Sub showProperties(ByVal sender As Object, ByVal e As RoutedEventArgs)
			ttProperties.ClearValue(TextBlock.TextProperty)
			ttPropertyValues.ClearValue(TextBlock.TextProperty)
			'<SnippetGetBetweenShowDelay>
			Dim myInt As Integer = ToolTipService.GetBetweenShowDelay(CType(FindName("ellipse2"), DependencyObject))
			'</SnippetGetBetweenShowDelay>
			AddTextString(ttProperties, ttPropertyValues, "BetweenShowDelay", myInt.ToString())
			'<SnippetGetInitialShowDelay>
			myInt = ToolTipService.GetInitialShowDelay(CType(FindName("ellipse2"), DependencyObject))
			'</SnippetGetInitialShowDelay>
			AddTextString(ttProperties, ttPropertyValues, "InitialShowDelay", myInt.ToString())
			'<SnippetGetShowDuration>
			myInt = ToolTipService.GetShowDuration(CType(FindName("ellipse2"), DependencyObject))
			'</SnippetGetShowDuration>
			AddTextString(ttProperties, ttPropertyValues, "ShowDuration", myInt.ToString())
			'<SnippetGetHasDropShadow>
			Dim myBool As Boolean = ToolTipService.GetHasDropShadow(CType(FindName("ellipse2"), DependencyObject))
			'</SnippetGetHasDropShadow>
			AddTextString(ttProperties, ttPropertyValues, "HasDropShadow", myBool.ToString())
			'<SnippetGetHorizontalOffset>
			Dim myDouble As Double = ToolTipService.GetHorizontalOffset(CType(FindName("ellipse2"), DependencyObject))
			'</SnippetGetHorizontalOffset>
			AddTextString(ttProperties, ttPropertyValues, "HorizontalOffset", myDouble.ToString())
			'<SnippetGetVerticalOffset>
			myDouble = ToolTipService.GetVerticalOffset(CType(FindName("ellipse2"), DependencyObject))
			'</SnippetGetVerticalOffset>
			AddTextString(ttProperties, ttPropertyValues, "VerticalOffset", myDouble.ToString())
			'<SnippetGetPlacement>
			Dim myMode As PlacementMode = ToolTipService.GetPlacement(CType(FindName("ellipse2"), DependencyObject))
			'</SnippetGetPlacement>
			AddTextString(ttProperties, ttPropertyValues, "Placement", myMode.ToString())
			'<SnippetGetPlacementRectangle>
			Dim myRect As Rect = ToolTipService.GetPlacementRectangle(CType(FindName("ellipse2"), DependencyObject))
			'</SnippetGetPlacementRectangle>
			AddTextString(ttProperties, ttPropertyValues, "PlacementRectangle", myRect.ToString())
			'<SnippetGetPlacementTarget>
			Dim target As New UIElement()
			target = ToolTipService.GetPlacementTarget(CType(FindName("ellipse2"), DependencyObject))
			'</SnippetGetPlacementTarget>
			If target Is Nothing Then
				AddTextString(ttProperties, ttPropertyValues, "PlacementTarget", "null")
			Else
				AddTextString(ttProperties, ttPropertyValues, "PlacementTarget", target.ToString())
			End If
			'<SnippetGetIsDropShadow>
			myBool = ToolTipService.GetHasDropShadow(CType(FindName("ellipse2"), DependencyObject))
			'</SnippetGetIsDropShadow>
			AddTextString(ttProperties, ttPropertyValues, "HasDropShadow", myBool.ToString())
			'<SnippetGetIsEnabled>
			myBool = ToolTipService.GetIsEnabled(CType(FindName("ellipse2"), DependencyObject))
			'</SnippetGetIsEnabled>
			AddTextString(ttProperties, ttPropertyValues, "IsEnabled", myBool.ToString())
			'<SnippetGetIsOpen>
			myBool = ToolTipService.GetIsOpen(CType(FindName("ellipse2"), DependencyObject))
			'</SnippetGetIsOpen>
			AddTextString(ttProperties, ttPropertyValues, "IsOpen", myBool.ToString())
			'<SnippetGetShowOnDisabled>
			myBool = ToolTipService.GetShowOnDisabled(CType(FindName("ellipse2"), DependencyObject))
			'</SnippetGetShowOnDisabled>
			AddTextString(ttProperties, ttPropertyValues, "ShowOnDisabled", myBool.ToString())
			'<SnippetGetToolTip>
			target = CType(ToolTipService.GetToolTip(CType(FindName("ellipse2"), DependencyObject)), UIElement)
			'</SnippetGetToolTip>
			AddTextString(ttProperties, ttPropertyValues, "ToolTip", target.ToString())

		End Sub

		Private Sub AddTextString(ByVal tBlock As TextBlock, ByVal pName As String, ByVal value As String)
			tBlock.Text += pName & vbTab & value & vbLf
		End Sub

		Private Sub AddTextString(ByVal tBlock As TextBlock, ByVal vBlock As TextBlock, ByVal pName As String, ByVal value As String)
			tBlock.Text += pName & vbLf
			vBlock.Text += value & vbLf
		End Sub

	End Class
End Namespace