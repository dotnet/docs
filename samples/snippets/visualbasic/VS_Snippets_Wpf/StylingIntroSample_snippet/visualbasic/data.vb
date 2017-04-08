Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.ComponentModel

Namespace StylingIntroSample
	Public Class Photo
		Public Sub New(ByVal path As String)
			_source = path
		End Sub

		Public Overrides Function ToString() As String
			Return Source
		End Function

		Private _source As String
		Public ReadOnly Property Source() As String
			Get
				Return _source
			End Get
		End Property

	End Class

	Public Class PhotoList
		Inherits ObservableCollection(Of Photo)
		Public Sub New()
		End Sub

		Public Sub New(ByVal path As String)
			Me.New(New DirectoryInfo(path))
		End Sub

		Public Sub New(ByVal directory As DirectoryInfo)
			_directory = directory
			Update()
		End Sub

		Public Property Path() As String
			Set(ByVal value As String)
				_directory = New DirectoryInfo(value)
				Update()
			End Set
			Get
				Return _directory.FullName
			End Get
		End Property

		Public Property Directory() As DirectoryInfo
			Set(ByVal value As DirectoryInfo)
				_directory = value
				Update()
			End Set
			Get
				Return _directory
			End Get
		End Property

		Private Sub Update()
			For Each f As FileInfo In _directory.GetFiles("*.jpg")
				Add(New Photo(f.FullName))
			Next f
		End Sub

		Private _directory As DirectoryInfo
	End Class
End Namespace
