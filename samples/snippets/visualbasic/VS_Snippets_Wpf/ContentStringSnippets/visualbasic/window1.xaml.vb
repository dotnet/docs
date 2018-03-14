Imports Microsoft.VisualBasic
Imports System
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
Imports System.Collections.ObjectModel

Namespace ContentStringSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class

	'<SnippetGroupStyleData>
	' The converter to group the items.
	Public Class GroupByPrice
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert

			If Not(TypeOf value Is Double) Then
				Return Nothing
			End If

			Dim itemPrice As Double = CDbl(value)

			If itemPrice < 100 Then
				Return 100
			End If

			If itemPrice < 250 Then
				Return 250
			End If

			If itemPrice < 500 Then
				Return 500
			End If

			Return 1000



		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
			Throw New NotImplementedException()
		End Function
	End Class

	' The type of objects that are added to the ItemsControl.
	Public Class PurchaseItem
		Public Property Description() As String
		Public Property Price() As Double
		Public Property OfferExpires() As Date

		Public Sub New()
		End Sub

		Public Sub New(ByVal desc As String, ByVal price As Double, ByVal endDate As Date)
			Description = desc
			Me.Price = price
			OfferExpires = endDate
		End Sub

		Public Overrides Function ToString() As String
			Return String.Format("{0}, {1:c}, {2:D}", Description, Price, OfferExpires)
		End Function
	End Class

	' The source of the ItemsControl.
	Public Class ItemsForSale
		Inherits ObservableCollection(Of PurchaseItem)

		Public Sub New()
			Add((New PurchaseItem("Snowboard and bindings", 120, New Date(2009, 1, 1))))
            Add((New PurchaseItem("Inside VB, second edition", 10, New Date(2009, 2, 2))))
			Add((New PurchaseItem("Laptop - only 1 year old", 499.99, New Date(2009, 2, 28))))
			Add((New PurchaseItem("Set of 6 chairs", 120, New Date(2009, 2, 28))))
			Add((New PurchaseItem("My DVD Collection", 15, New Date(2009, 1, 1))))
			Add((New PurchaseItem("TV Drama Series", 39.985, New Date(2009, 1, 1))))
			Add((New PurchaseItem("Squash racket", 60, New Date(2009, 2, 28))))

		End Sub

	End Class
	'</SnippetGroupStyleData>

	'TabControl.ContentStringFormat
	#Region "TabControlData"
	Public Class Student
		Implements IFormattable

		Public Property Name() As String
		Private Property Courses() As ObservableCollection(Of Course)

		Public Sub New()
			Me.New("")

		End Sub

		Public Sub New(ByVal name As String)
			Me.Name = name
			Courses = New ObservableCollection(Of Course)()
		End Sub

		' Add a course to the student's schedule.
		Public Sub AddCourse(ByVal name As String, ByVal id As Integer, ByVal desc As String)
			Courses.Add(New Course(name, id, desc))
		End Sub

		'<SnippetTabControlToString>
		Public Overloads Function ToString(ByVal format As String, ByVal formatProvider As IFormatProvider) As String Implements IFormattable.ToString
			' 'n': print the name only.
			If format = "n" Then
				Return Name
			End If

			' 'cl': print the course list.
			If format = "cl" Then
				Dim stringFormat As String = "{0,-25}{1,-30}{2,-10}" & vbCrLf

				Dim str As New StringBuilder()

				str.AppendLine()
				str.AppendFormat(stringFormat, "Title", "Description", "ID")
				str.AppendLine()

				For Each c As Course In Courses
					str.AppendFormat(stringFormat, c.Title, c.Description, c.SectionID)
				Next c

				Return str.ToString()
			End If

			Return Me.ToString()
		End Function
		'</SnippetTabControlToString>
	End Class

	Public Class Course
		Public Property Title() As String
		Public Property SectionID() As Integer
		Public Property Description() As String

		Public Sub New()
		End Sub

		Public Sub New(ByVal title As String, ByVal section As Integer, ByVal desc As String)
			Me.Title = title
			SectionID = section
			Description = desc
		End Sub
	End Class

	Public Class Students
		Inherits ObservableCollection(Of Student)
		Public Sub New()
			Dim s1 As New Student("Sunil Uppal")
			s1.AddCourse("Calculus 303", 19, "Advanced Calculus")
			s1.AddCourse("History 110", 35, "Introduction to World History")
			s1.AddCourse("Psychology 110", 40, "Behavioral Psychology")
			s1.AddCourse("Physical Education 204", 80, "Racquetball")
			Me.Add(s1)

			Dim s2 As New Student("Alice Ciccu")
			s2.AddCourse("English 200", 50, "Advanced Composition")
			s2.AddCourse("English 315", 100, "Shakespear's Sonnets")
			s2.AddCourse("History 230", 38, "European History 1000-1500")
			Me.Add(s2)


			Dim s3 As New Student("Jeff Price")
			s3.AddCourse("History 230", 38, "European History 1000-1500")
			s3.AddCourse("History 110", 35, "Introduction to World History")
			s3.AddCourse("Physical Education 204", 80, "Racquetball")
			Me.Add(s3)


		End Sub
	End Class

	#End Region
End Namespace
