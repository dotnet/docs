Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Globalization
Imports System.ComponentModel
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Xml
Imports System.Windows.Automation.Peers
Imports System.Collections.Generic


Namespace SDKSample
	'<SnippetIVAPCreate>
	Public Class OneButtonHeaderView
		Inherits ViewBase
		Protected Overrides Function GetAutomationPeer(ByVal parent As ListView) As IViewAutomationPeer
			Return New OneButtonHeaderViewAutomationPeer(Me, parent)
		End Function
	'</SnippetIVAPCreate>

		Protected Overrides ReadOnly Property DefaultStyleKey() As Object
		  Get
			Return New ComponentResourceKey(Me.GetType(), "OneButtonHeaderViewDSK")
		  End Get
		End Property

		Protected Overrides ReadOnly Property ItemContainerDefaultStyleKey() As Object
		  Get
			Return New ComponentResourceKey(Me.GetType(), "OneButtonHeaderViewItemDSK")
		  End Get
		End Property
	End Class

	'<SnippetIVAP>
	Public Class OneButtonHeaderViewAutomationPeer
		Implements IViewAutomationPeer
		Private m_lv As ListView

		Public Sub New(ByVal control As OneButtonHeaderView, ByVal parent As ListView)
			m_lv = parent
		End Sub

		Private Function CreateItemAutomationPeer(ByVal item As Object) As ItemAutomationPeer Implements IViewAutomationPeer.CreateItemAutomationPeer
			Dim lvAP As ListViewAutomationPeer = TryCast(UIElementAutomationPeer.FromElement(m_lv), ListViewAutomationPeer)
			Return New ListBoxItemAutomationPeer(item, lvAP)
		End Function

		Private Function GetAutomationControlType() As AutomationControlType Implements IViewAutomationPeer.GetAutomationControlType
			Return AutomationControlType.List
		End Function

		Private Function GetChildren(ByVal children As List(Of AutomationPeer)) As List(Of AutomationPeer) Implements IViewAutomationPeer.GetChildren
			' the children parameter is a list of automation peers for all the known items
			' our view must add its banner button peer to this list.

			Dim b As Button = CType(m_lv.Template.FindName("BannerButton", m_lv), Button)
			Dim peer As AutomationPeer = UIElementAutomationPeer.CreatePeerForElement(b)

			'If children is null, we still need to create an empty list to insert the button
			If children Is Nothing Then
				children = New List(Of AutomationPeer)()
			End If

			children.Insert(0, peer)

			Return children
		End Function

		Private Function GetPattern(ByVal patternInterface As PatternInterface) As Object Implements IViewAutomationPeer.GetPattern
			' we can invoke the banner button 
			If patternInterface = PatternInterface.Invoke Then
				Dim b As Button = CType(m_lv.Template.FindName("BannerButton", m_lv), Button)
				Dim peer As AutomationPeer = UIElementAutomationPeer.FromElement(b)
				If peer IsNot Nothing Then
					Return peer
				End If
			End If

			' if this view does not have special handling for the pattern interface, return null
			' the ListViewAutomationPeer.GetPattern default handling will be used.
			Return Nothing
		End Function

		Private Sub ItemsChanged(ByVal e As System.Collections.Specialized.NotifyCollectionChangedEventArgs) Implements IViewAutomationPeer.ItemsChanged
		End Sub

		Private Sub ViewDetached() Implements IViewAutomationPeer.ViewDetached
		End Sub
	End Class
	'</SnippetIVAP>
End Namespace