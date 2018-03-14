
Imports System
Imports System.IO
Imports wpf = System.Windows
Imports System.Windows.Input

' Using Statements for winforms
'<SnippetUsingWinforms>
Imports Microsoft.Ink
Imports System.Drawing
'</SnippetUsingWinforms>
' Using Statements for WPF.
'<SnippetUsingWPF>
Imports System.Windows.Ink

'</SnippetUsingWPF>


Class WinformInk
    Private theInk As Ink
    Private points() As System.Drawing.Point
    Private points2() As System.Drawing.Point
    
    Private stroke1 As Microsoft.Ink.Stroke
    Private stroke2 As Microsoft.Ink.Stroke
    
    
    Public Sub New() 
        theInk = New Ink()
    
    End Sub 'New
     
    
    
    Private Sub CreateStrokes() 
        If theInk.Strokes.Count > 0 Then
            Return
        End If
        points = New System.Drawing.Point() {New System.Drawing.Point(0, 0), New System.Drawing.Point(100, 100)}
        points2 = New System.Drawing.Point() {New System.Drawing.Point(0, 0), New System.Drawing.Point(150, 150)}
        
        stroke1 = theInk.CreateStroke(points)
        stroke2 = theInk.CreateStroke(points)
    
    End Sub 'CreateStrokes
    
    
    Public Sub ReportStrokes() 
        Dim stroke As Microsoft.Ink.Stroke
        For Each stroke In  theInk.Strokes
            Console.Write("StrokePoints: ")
            Dim p As System.Drawing.Point
            For Each p In  stroke.GetPoints()
                Console.Write(p.ToString() + ", ")
            Next p
            Console.WriteLine()
        Next stroke
        
        Console.WriteLine()
    
    End Sub 'ReportStrokes
    
    
    ' Test method that proves the Stylus packet data is copied into a stroke.
    Public Sub ChangeStylusPoints() 
        CreateStrokes()
        ReportStrokes()
        stroke2.SetPoints(points2)
        ReportStrokes()
        
        Console.ReadLine()
    
    End Sub 'ChangeStylusPoints
    
    
    Public Function SaveInk() As MemoryStream 
        CreateStrokes()
        
        Return SaveInkInWinforms(theInk)
    
    End Function 'SaveInk
    
    
    '<SnippetSaveWinforms>
    '/ <summary>
    '/ Saves the digital ink from a Windows Forms application.
    '/ </summary>
    '/ <param name="inkToSave">An Ink object that contains the 
    '/ digital ink.</param>
    '/ <returns>A MemoryStream containing the digital ink.</returns>
    Function SaveInkInWinforms(ByVal inkToSave As Ink) As MemoryStream 
        Dim savedInk As Byte() = inkToSave.Save()
        
        Return New MemoryStream(savedInk)
    
    End Function 'SaveInkInWinforms
    '</SnippetSaveWinforms>

    '<SnippetLoadWinforms>
    '/ <summary>
    '/ Loads digital ink into a Windows Forms application.
    '/ </summary>
    '/ <param name="savedInk">A MemoryStream containing the digital ink.</param>
    Public Sub LoadInkInWinforms(ByVal savedInk As MemoryStream) 
        theInk = New Ink()
        theInk.Load(savedInk.ToArray())
    
    End Sub 'LoadInkInWinforms
    '</SnippetLoadWinforms>
End Class 'WinformInk 


Class WPFInk
    Private strokes As StrokeCollection
    
    
    Public Sub New() 
    
    End Sub 'New
    
    
    Public Function SaveInk() As MemoryStream 
        CreateStrokes()
        
        Return SaveInkInWPF(strokes)
    
    End Function 'SaveInk
    
    
    Public Sub ChangeStylusPoints() 
        If Not (strokes Is Nothing) Then
            Return
        End If
        
        Dim points() As wpf.Point = {New wpf.Point(0, 100), New wpf.Point(200, 200)}
        
        Dim stylusPoints As New StylusPointCollection(points)
        Dim stroke1 = New System.Windows.Ink.Stroke(stylusPoints)
        Dim stroke2 = New System.Windows.Ink.Stroke(stylusPoints)
        
        strokes = New StrokeCollection()
        strokes.Add(stroke1)
        strokes.Add(stroke2)
        
        ReportStrokes()
        
        Dim point As StylusPoint = stroke2.StylusPoints(1)
        point.Y = 300
        stroke2.StylusPoints(1) = point
        
        ReportStrokes()
    
    End Sub 'ChangeStylusPoints
    
    
    '<SnippetSaveWPF>
    '/ <summary>
    '/ Saves the digital ink from a WPF application.
    '/ </summary>
    '/ <param name="inkToSave">A StrokeCollection that contains the 
    '/ digital ink.</param>
    '/ <returns>A MemoryStream containing the digital ink.</returns>
    Function SaveInkInWPF(ByVal strokesToSave As StrokeCollection) As MemoryStream 
        Dim savedInk As New MemoryStream()
        
        strokesToSave.Save(savedInk)
        
        Return savedInk
    
    End Function 'SaveInkInWPF
    
    '</SnippetSaveWPF>
    '<SnippetLoadWPF>
    '/ <summary>
    '/ Loads digital ink into a StrokeCollection, which can be 
    '/ used by a WPF application.
    '/ </summary>
    '/ <param name="savedInk">A MemoryStream containing the digital ink.</param>
    Public Sub LoadInkInWPF(ByVal inkStream As MemoryStream) 
        strokes = New StrokeCollection(inkStream)
    
    End Sub 'LoadInkInWPF
    
    '</SnippetLoadWPF>
    Sub CreateStrokes() 
        Dim points() As wpf.Point = {New wpf.Point(0, 0), New wpf.Point(100, 100)}
        Dim points2() As wpf.Point = {New wpf.Point(0, 0), New wpf.Point(150, 150)}
        
        strokes = New StrokeCollection()
        Dim stroke1 As New System.Windows.Ink.Stroke(New StylusPointCollection(points))
        Dim stroke2 As New System.Windows.Ink.Stroke(New StylusPointCollection(points2))
        
        strokes.Add(stroke1)
        strokes.Add(stroke2)
    
    End Sub 'CreateStrokes
    
    
    Public Sub ReportStrokes() 
        If strokes Is Nothing Then
            Console.WriteLine("Strokes is null")
            Return
        End If
        
        Dim stroke As System.Windows.Ink.Stroke
        For Each stroke In  strokes
            Console.Write("StrokePoints({0}): ", stroke.StylusPoints.Count)
            Dim sp As StylusPoint
            For Each sp In  stroke.StylusPoints
                Console.Write(sp.ToPoint().ToString() + ", ")
            Next sp
            Console.WriteLine()
        Next stroke
        Console.WriteLine()
    
    End Sub 'ReportStrokes
End Class 'WPFInk


Class Program
    
    
    Shared Sub Main(ByVal args() As String) 
        Dim winformTest As New WinformInk()
        Dim wpfTest As New WPFInk()
        Dim savedStrokes As MemoryStream
        
        'winformTest.ChangeStylusPoints();
        ' First save the ink in winforms and load it into WPF.
        Console.WriteLine("Winforms Saved Ink:")
        savedStrokes = winformTest.SaveInk()
        winformTest.ReportStrokes()
        
        Console.WriteLine(vbLf + "WPF Loaded Ink:")
        wpfTest.LoadInkInWPF(savedStrokes)
        wpfTest.ReportStrokes()
        savedStrokes = Nothing
        
        ' Then save ink in WPF and load it into winforms.
        Console.WriteLine(vbLf + "WPF savedInk")
        savedStrokes = wpfTest.SaveInk()
        wpfTest.ReportStrokes()
        
        Console.WriteLine(vbLf + "Winform Loaded Iml")
        winformTest.LoadInkInWinforms(savedStrokes)
        winformTest.ReportStrokes()
        
        Console.WriteLine(vbLf + "WPF StylusPointTest")
        Dim stylusPointTest As New WPFInk()
        stylusPointTest.ChangeStylusPoints()
        
        Console.ReadLine()
    
    End Sub 'Main 
End Class 'Program