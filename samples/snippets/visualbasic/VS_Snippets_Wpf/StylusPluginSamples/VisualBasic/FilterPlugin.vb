
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes

Imports System.Diagnostics
Imports System.Collections.ObjectModel
Imports System.Reflection

Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Input.StylusPlugIns



' <Snippet1>
' EventArgs for the StrokeRendered event.
Public Class StrokeRenderedEventArgs
    Inherits EventArgs

    Private currentStrokePoints As StylusPointCollection

    Public Sub New(ByVal points As StylusPointCollection)

        currentStrokePoints = points

    End Sub 'New


    Public ReadOnly Property StrokePoints() As StylusPointCollection
        Get
            Return currentStrokePoints
        End Get
    End Property
End Class 'StrokeRenderedEventArgs

' EventHandler for the StrokeRendered event.
Public Delegate Sub StrokeRenderedEventHandler(ByVal sender As Object, ByVal e As StrokeRenderedEventArgs) 


' A StylusPlugin that restricts the input area
Class FilterPlugin
    Inherits StylusPlugIn

    Private collectedPoints As StylusPointCollection
    Private currentStylus As Integer = -1
    Public Event StrokeRendered As StrokeRenderedEventHandler


    Protected Overrides Sub OnStylusDown(ByVal rawStylusInput As RawStylusInput)

        ' Run the base class before we modify the data
        MyBase.OnStylusDown(rawStylusInput)

        If currentStylus = -1 Then

            Dim pointsFromEvent As StylusPointCollection = rawStylusInput.GetStylusPoints()

            ' Create an emtpy StylusPointCollection to contain the filtered
            ' points.
            collectedPoints = New StylusPointCollection(pointsFromEvent.Description)

            ' Restrict the stylus input and add the filtered 
            ' points to collectedPoints. 
            Dim points As StylusPointCollection = FilterPackets(pointsFromEvent)
            rawStylusInput.SetStylusPoints(points)
            collectedPoints.Add(points)

            currentStylus = rawStylusInput.StylusDeviceId

        End If

    End Sub 'OnStylusDown


    Protected Overrides Sub OnStylusMove(ByVal rawStylusInput As RawStylusInput)

        ' Run the base class before we modify the data
        MyBase.OnStylusMove(rawStylusInput)

        If currentStylus = rawStylusInput.StylusDeviceId Then

            Dim pointsFromEvent As StylusPointCollection = rawStylusInput.GetStylusPoints()

            ' Restrict the stylus input and add the filtered 
            ' points to collectedPoints. 
            Dim points As StylusPointCollection = FilterPackets(pointsFromEvent)
            rawStylusInput.SetStylusPoints(points)
            collectedPoints.Add(points)

        End If

    End Sub 'OnStylusMove

    Protected Overrides Sub OnStylusUp(ByVal rawStylusInput As RawStylusInput)

        ' Run the base class before we modify the data
        MyBase.OnStylusUp(rawStylusInput)

        If currentStylus = rawStylusInput.StylusDeviceId Then

            Dim pointsFromEvent As StylusPointCollection = rawStylusInput.GetStylusPoints()

            ' Restrict the stylus input and add the filtered 
            ' points to collectedPoints. 
            Dim points As StylusPointCollection = FilterPackets(pointsFromEvent)
            rawStylusInput.SetStylusPoints(points)
            collectedPoints.Add(points)

            RecordPoints(collectedPoints, "collectPoints - StylusUp")
            ' Subscribe to the OnStylusUpProcessed method.
            rawStylusInput.NotifyWhenProcessed(collectedPoints)

            currentStylus = -1

        End If

    End Sub 'OnStylusUp


    Private Function FilterPackets(ByVal stylusPoints As StylusPointCollection) As StylusPointCollection

        ' Modify the (X,Y) data to move the points 
        ' inside the acceptable input area, if necessary.
        Dim i As Integer

        For i = 0 To stylusPoints.Count - 1

            Dim sp As StylusPoint = stylusPoints(i)

            If sp.X < 50 Then
                sp.X = 50
            End If

            If sp.X > 250 Then
                sp.X = 250
            End If

            If sp.Y < 50 Then
                sp.Y = 50
            End If

            If sp.Y > 250 Then
                sp.Y = 250
            End If

            stylusPoints(i) = sp

        Next i

        ' Return the modified StylusPoints.
        Return stylusPoints

    End Function 'FilterPackets

    ' This is called on the application thread.
    Protected Overrides Sub OnStylusUpProcessed(ByVal callbackData As Object, _
                                                ByVal targetVerified As Boolean)

        ' Check that the element actually receive the OnStylusUp input.
        If targetVerified Then
            Dim strokePoints As StylusPointCollection

            strokePoints = CType(callbackData, StylusPointCollection)

            If strokePoints Is Nothing Then
                Return
            End If

            ' Raise the StrokeRendered event so the consumer of the plugin can
            ' add the filtered stroke to its StrokeCollection.
            RecordPoints(strokePoints, "onStylusUpProcessed")
            Dim e As New StrokeRenderedEventArgs(strokePoints)
            OnStrokeRendered(e)
        End If

    End Sub 'OnStylusUpProcessed


    Protected Overridable Sub OnStrokeRendered(ByVal e As StrokeRenderedEventArgs)

        RaiseEvent StrokeRendered(Me, e)

    End Sub 'OnStrokeRendered

    Public Sub RecordPoints(ByVal points As StylusPointCollection, ByVal name As String)

        System.Diagnostics.Debug.WriteLine(name)
        For Each point As StylusPoint In points
            System.Diagnostics.Debug.WriteLine("   x: " & point.X & " y: " & point.Y)
        Next
    End Sub
End Class 'FilterPlugin
' </Snippet1>

Class PacketTracer
    
    Public Shared Sub WriteDescriptionInfo(ByVal points As StylusPointCollection) 
        Dim pointsDescription As StylusPointDescription = points.Description
        Dim properties As ReadOnlyCollection(Of StylusPointPropertyInfo) = pointsDescription.GetStylusPointProperties()
        
        Debug.WriteLine("Property Count:" + pointsDescription.PropertyCount.ToString())
        
        Dim aProperty As StylusPointPropertyInfo
        For Each aProperty In properties
            ' GetStylusPointPropertyName is defined below and returns the
            ' name of the property.
            Debug.WriteLine("  name = " + GetStylusPointPropertyName(aProperty))
        Next aProperty
     
    End Sub 'WriteDescriptionInfo

    ' Use reflection to get the name of currentProperty.
    Private Shared Function GetStylusPointPropertyName(ByVal currentProperty As StylusPointProperty) As String 
        Dim guid As Guid = currentProperty.Id
        
        ' Iterate through the StylusPointProperties to find the StylusPointProperty
        ' that matches currentProperty, then return the name.
        Dim theFieldInfo As FieldInfo
        For Each theFieldInfo In  GetType(StylusPointProperties).GetFields()
            Dim [property] As StylusPointProperty = CType(theFieldInfo.GetValue(currentProperty), StylusPointProperty)
            If [property].Id = guid Then
                Return theFieldInfo.Name
            End If
        Next theFieldInfo
        Return "Not found"
    
    End Function 'GetStylusPointPropertyName
End Class 'PacketTracer 


Class CustomPluginSamples
    Inherits StylusPlugIn
    
    '<Snippet8>
    Protected Overrides Sub OnStylusDown(ByVal rawStylusInput As RawStylusInput) 
        ' Run the base class before we modify the data
        MyBase.OnStylusDown(rawStylusInput)
        
        ' Get the StylusPoints that have come in
        Dim stylusPoints As StylusPointCollection = rawStylusInput.GetStylusPoints()
        
        ' Modify the (X,Y) data to move the points 
        ' inside the acceptable input area, if necessary.
        Dim i As Integer

        For i = 0 To stylusPoints.Count - 1

            Dim sp As StylusPoint = stylusPoints(i)

            If sp.X < 50 Then
                sp.X = 50
            End If

            If sp.X > 250 Then
                sp.X = 250
            End If

            If sp.Y < 50 Then
                sp.Y = 50
            End If

            If sp.Y > 250 Then
                sp.Y = 250
            End If

            stylusPoints(i) = sp
        Next i
        
        ' Copy the modified StylusPoints back to the RawStylusInput
        rawStylusInput.SetStylusPoints(stylusPoints)
    
    End Sub 'OnStylusDown
    '</Snippet8>

    '<Snippet9>
    Protected Overrides Sub OnStylusMove(ByVal rawStylusInput As RawStylusInput) 

        ' Run the base class before we modify the data
        MyBase.OnStylusMove(rawStylusInput)
        
        ' Get the StylusPoints that have come in
        Dim stylusPoints As StylusPointCollection = rawStylusInput.GetStylusPoints()
        
        ' Modify the (X,Y) data to move the points 
        ' inside the acceptable input area, if necessary.
        Dim i As Integer
        For i = 0 To stylusPoints.Count - 1

            Dim sp As StylusPoint = stylusPoints(i)

            If sp.X < 50 Then
                sp.X = 50
            End If

            If sp.X > 250 Then
                sp.X = 250
            End If

            If sp.Y < 50 Then
                sp.Y = 50
            End If

            If sp.Y > 250 Then
                sp.Y = 250
            End If

            stylusPoints(i) = sp

        Next i
        
        ' Copy the modified StylusPoints back to the RawStylusInput.
        rawStylusInput.SetStylusPoints(stylusPoints)
    
    End Sub 'OnStylusMove
    '</Snippet9>

    '<Snippet10>
    Protected Overrides Sub OnStylusUp(ByVal rawStylusInput As RawStylusInput) 

        ' Run the base class before we modify the data
        MyBase.OnStylusUp(rawStylusInput)
        
        ' Get the StylusPoints that have come in
        Dim stylusPoints As StylusPointCollection = rawStylusInput.GetStylusPoints()
        
        ' Modify the (X,Y) data to move the points 
        ' inside the acceptable input area, if necessary
        Dim i As Integer

        For i = 0 To stylusPoints.Count - 1

            Dim sp As StylusPoint = stylusPoints(i)

            If sp.X < 50 Then
                sp.X = 50
            End If

            If sp.X > 250 Then
                sp.X = 250
            End If

            If sp.Y < 50 Then
                sp.Y = 50
            End If

            If sp.Y > 250 Then
                sp.Y = 250
            End If

            stylusPoints(i) = sp

        Next i
        
        ' Copy the modified StylusPoints back to the RawStylusInput.
        rawStylusInput.SetStylusPoints(stylusPoints)
    
    End Sub 'OnStylusUp
    '</Snippet10>
End Class 'CustomPluginSamples 