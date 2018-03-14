' Interaction logic for AnnotationsWindow.xaml

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.IO
Imports System.Windows.Annotations
Imports System.Windows.Annotations.Storage
Imports System.Globalization
Imports System.Collections
Imports System.Windows.Markup
Imports System.Collections.ObjectModel

Namespace SDKSample

    Public Class StyleMetaData
        Inherits DependencyObject

        ' Methods
        Shared Sub New()
            StyleMetaData.KeyProperty = DependencyProperty.Register("Key", GetType(String), GetType(StyleMetaData))
        End Sub


        Public Sub New(ByVal key As String, ByVal value As Style)
            Me.Key = key
            Me.Value = value
        End Sub

        ' Properties
        Public Property Key() As String
            Get
                Return CStr(MyBase.GetValue(StyleMetaData.KeyProperty))
            End Get
            Set(ByVal value As String)
                MyBase.SetValue(StyleMetaData.KeyProperty, value)
            End Set
        End Property

        ' Fields
        Public Shared KeyProperty As DependencyProperty
        Public Value As Style

    End Class

    <ValueConversion(GetType(Collection(Of StyleMetaData)), GetType(Collection(Of ResourceDictionary)))> _
    Public Class ResourceEntryToComboItemConverter
        Implements IValueConverter

        ' Methods
        Public Sub New()
        End Sub

        Public Function [Convert](ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
            Dim collection1 As Collection(Of ResourceDictionary) = TryCast(value, Collection(Of ResourceDictionary))
            Dim collection2 As New Collection(Of StyleMetaData)

            Dim dictionary1 As ResourceDictionary
            For Each dictionary1 In collection1
                Dim text1 As String
                For Each text1 In dictionary1.Keys
                    Dim style1 As Style = TryCast(dictionary1.Item(text1), Style)
                    If ((Not style1 Is Nothing) AndAlso style1.TargetType.Equals(GetType(StickyNoteControl))) Then
                        collection2.Add(New StyleMetaData(text1, style1))
                    End If
                Next
            Next
            Return collection2
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Return Nothing
        End Function

    End Class

    Partial Public Class AnnotationsWindow
        Inherits System.Windows.Window

        Private _annotationStream As Stream

        Public Sub New()
            Me.InitializeComponent()
            Using stream1 As FileStream = New FileStream("AFlowDocument.xaml", FileMode.Open, FileAccess.Read)
                Dim document1 As FlowDocument = TryCast(XamlReader.Load(stream1), FlowDocument)
                Me.Viewer.Document = document1
            End Using
        End Sub

        Private Sub OnStyleSelected(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
            Dim box1 As ComboBox = DirectCast(e.Source, ComboBox)
            Dim data1 As StyleMetaData = DirectCast(box1.SelectedItem, StyleMetaData)
            Dim style1 As New Style(GetType(StickyNoteControl))
            style1.BasedOn = data1.Value
            Dim type1 As Type = GetType(StickyNoteControl)
            If Me.Viewer.Resources.Contains(type1) Then
                Me.Viewer.Resources.Remove(type1)
            End If
            Me.Viewer.Resources.Add(type1, style1)
            Dim service1 As AnnotationService = AnnotationService.GetService(DirectCast(Me.Viewer, DocumentViewerBase))
            service1.Disable()
            service1.Enable(service1.Store)

        End Sub

        Private Sub OnLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim service1 As AnnotationService = AnnotationService.GetService(DirectCast(Me.Viewer, DocumentViewerBase))
            If (service1 Is Nothing) Then
                _annotationStream = New FileStream("annotations.xml", FileMode.OpenOrCreate)
                service1 = New AnnotationService(Me.Viewer)
                Dim store1 As AnnotationStore = New XmlStreamStore(_annotationStream)
                service1.Enable(store1)
            End If
        End Sub

        Private Sub OnUnloaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim service1 As AnnotationService = AnnotationService.GetService(DirectCast(Me.Viewer, DocumentViewerBase))
            If ((Not service1 Is Nothing) AndAlso service1.IsEnabled) Then
                service1.Store.Flush()
                service1.Disable()
                _annotationStream.Close()
            End If
        End Sub

    End Class

End Namespace