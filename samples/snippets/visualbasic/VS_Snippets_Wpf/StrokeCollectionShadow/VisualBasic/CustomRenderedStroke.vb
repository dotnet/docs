
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Media

'<Snippet1>

Class ShadowedStroke
    Inherits Stroke
    
    Private shadow As New Guid("12345678-9012-3456-7890-123456789012")

    Public Sub New(ByVal stylusPoints As StylusPointCollection, ByVal drawingAttributes As DrawingAttributes)
        MyBase.New(stylusPoints, drawingAttributes)

        AddHandler Me.DrawingAttributes.PropertyDataChanged, AddressOf DrawingAttributes_PropertyDataChanged

    End Sub 'New

    Public Property Shadowed() As Boolean 

        ' Return the value of the custom property, shadow.
        ' If there is no custom property, return false.
        Get
            If Not Me.DrawingAttributes.ContainsPropertyData(shadow) Then
                Return False
            End If
            
            Dim propertyData As Object = Me.DrawingAttributes.GetPropertyData(shadow)
            
            If TypeOf propertyData Is Boolean Then
                Return CType(propertyData, Boolean)
            Else
                Return False
            End If
        End Get
        
        ' Set the value of the custom property.
        Set
            Me.DrawingAttributes.AddPropertyData(shadow, value)
        End Set 

    End Property
    
    
    Private Sub DrawingAttributes_PropertyDataChanged(ByVal sender As Object, ByVal e As PropertyDataChangedEventArgs)

        Me.OnInvalidated(New EventArgs())

    End Sub

    Protected Overrides Sub DrawCore(ByVal context As System.Windows.Media.DrawingContext, _
                                     ByVal overriddenAttributes As DrawingAttributes)
        ' create a drop shadow
        '
        If Me.Shadowed Then
            Dim pathGeometry As Geometry = Me.GetGeometry(overriddenAttributes).Clone()
            pathGeometry.Transform = New TranslateTransform(5, 0)
            Try
                context.PushOpacity(0.5)
                context.DrawGeometry(Brushes.DarkGray, Nothing, pathGeometry)
            Finally
                context.Pop()
            End Try
        End If
        MyBase.DrawCore(context, overriddenAttributes)

    End Sub 'DrawCore
End Class 'ShadowedStroke
'</Snippet1>