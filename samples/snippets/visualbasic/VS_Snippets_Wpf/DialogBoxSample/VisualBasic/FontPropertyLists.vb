Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Media

Namespace SDKSample

Public Class FontPropertyLists

    Public Shared Function CanParseFontStyle(ByVal fontStyleName As String) As Boolean
        Try
            Dim converter As FontStyleConverter = New FontStyleConverter()
            converter.ConvertFromString(fontStyleName)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function CanParseFontWeight(ByVal fontWeightName As String) As Boolean
        Try
            Dim converter As FontWeightConverter = New FontWeightConverter()
            converter.ConvertFromString(fontWeightName)
            Return True
        Catch obj1 As Exception
            Return False
        End Try
    End Function

    Public Shared Function ParseFontStyle(ByVal fontStyleName As String) As FontStyle
        Dim converter As New FontStyleConverter
        Return DirectCast(converter.ConvertFromString(fontStyleName), FontStyle)
    End Function

    Public Shared Function ParseFontWeight(ByVal fontWeightName As String) As FontWeight
        Dim converter As New FontWeightConverter
        Return DirectCast(converter.ConvertFromString(fontWeightName), FontWeight)
    End Function

    Public Shared ReadOnly Property FontFaces() As ICollection(Of FontFamily)
        Get
            If (FontPropertyLists._fontFaces Is Nothing) Then
                FontPropertyLists._fontFaces = New Collection(Of FontFamily)
            End If
            Dim family As FontFamily
            For Each family In Fonts.SystemFontFamilies
                FontPropertyLists._fontFaces.Add(family)
            Next
            Return FontPropertyLists._fontFaces
        End Get
    End Property

    Public Shared ReadOnly Property FontSizes() As Collection(Of Double)
        Get
            If (FontPropertyLists._fontSizes Is Nothing) Then
                FontPropertyLists._fontSizes = New Collection(Of Double)
                Dim size As Double = 8
                Do While (size <= 40)
                    FontPropertyLists._fontSizes.Add(size)
                    size = (size + 1)
                Loop
            End If
            Return FontPropertyLists._fontSizes
        End Get
    End Property

    Public Shared ReadOnly Property FontStyles() As ICollection
        Get
            If (FontPropertyLists._fontStyles Is Nothing) Then
                FontPropertyLists._fontStyles = New Collection(Of FontStyle)
                FontPropertyLists._fontStyles.Add(System.Windows.FontStyles.Normal)
                FontPropertyLists._fontStyles.Add(System.Windows.FontStyles.Oblique)
                FontPropertyLists._fontStyles.Add(System.Windows.FontStyles.Italic)
            End If
            Return FontPropertyLists._fontStyles
        End Get
    End Property

    Public Shared ReadOnly Property FontWeights() As ICollection
        Get
            If (FontPropertyLists._fontWeights Is Nothing) Then
                FontPropertyLists._fontWeights = New Collection(Of FontWeight)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.Thin)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.Light)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.Regular)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.Normal)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.Medium)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.Heavy)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.SemiBold)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.DemiBold)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.Bold)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.Black)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.ExtraLight)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.ExtraBold)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.ExtraBlack)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.UltraLight)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.UltraBold)
                FontPropertyLists._fontWeights.Add(System.Windows.FontWeights.UltraBlack)
            End If
            Return FontPropertyLists._fontWeights
        End Get
    End Property

    Private Shared _fontFaces As Collection(Of FontFamily)
    Private Shared _fontSizes As Collection(Of Double)
    Private Shared _fontStyles As Collection(Of FontStyle)
    Private Shared _fontWeights As Collection(Of FontWeight)

End Class

End Namespace