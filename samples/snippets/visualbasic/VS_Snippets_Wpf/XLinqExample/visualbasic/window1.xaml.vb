Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Imports System.Xml.Linq

Namespace BindToResults
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>
	Partial Public Class Window1
		Inherits Window
		Private planetsDoc As XDocument
		Public Sub New()
			InitializeComponent()

			Button_Click_LoadXMLFromFile(Nothing, Nothing)
		End Sub

		Private Sub CheckBox_Checked_Sort(ByVal sender As Object, ByVal e As RoutedEventArgs)
'<SnippetBindToResults>
			stacky.DataContext = From c In planetsDoc.Element("{http://planetsNS}SolarSystemPlanets").Elements()
			                     Order By Int32.Parse(c.Element("{http://planetsNS}DiameterKM").Value)
			                     Select c
'</snippetBindToResults>
		End Sub

		Private Sub CheckBox_Unchecked_NoSort(ByVal sender As Object, ByVal e As RoutedEventArgs)
			stacky.DataContext = From c In planetsDoc.Element("{http://planetsNS}SolarSystemPlanets").Elements()
			                     Select c
		End Sub

		Private Sub Button_Click_LoadXMLFromFile(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'<SnippetLoadDCFromFile>
			planetsDoc = XDocument.Load("../../Planets.xml")
			stacky.DataContext = planetsDoc.Element("{http://planetsNS}SolarSystemPlanets").Elements()
			'</SnippetLoadDCFromFile>
			sortCheckBox.IsChecked = False
		End Sub

		Private Sub Button_Click_LoadXMLFromXAML(ByVal sender As Object, ByVal e As RoutedEventArgs)
'<SnippetLoadDCFromXAML>
			planetsDoc = CType((CType(Resources("justTwoPlanets"), ObjectDataProvider)).Data, XDocument)
			stacky.DataContext = planetsDoc.Element("{http://planetsNS}SolarSystemPlanets").Elements()
'</SnippetLoadDCFromXAML>
			sortCheckBox.IsChecked = False
		End Sub
	End Class
End Namespace
