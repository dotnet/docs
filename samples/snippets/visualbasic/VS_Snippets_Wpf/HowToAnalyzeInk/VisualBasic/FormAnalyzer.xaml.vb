 '<Snippet2>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Ink
Imports System.Windows.Threading



Class FormAnalyzer
    Inherits Window

    Private analyzer As InkAnalyzer
    
    Private hintNodeTitle As AnalysisHintNode
    Private hintNodeDirector As AnalysisHintNode
    Private hintNodeStarring As AnalysisHintNode
    Private hintNodeRating As AnalysisHintNode
    Private hintNodeYear As AnalysisHintNode
    Private hintNodeGenre As AnalysisHintNode
    
    ' Timer that raises an event to
    ' clear the InkCanvas.
    Private strokeRemovalTimer As DispatcherTimer
    
    Private Const CLEAR_STROKES_DELAY As Integer = 5
        
    Public Sub New() 

        InitializeComponent()
    
    End Sub 'New
    
    Protected Overrides Sub OnContentRendered(ByVal e As EventArgs) 
        MyBase.OnContentRendered(e)
        
        ' Initialize the Analyzer.
        analyzer = New InkAnalyzer()
        AddHandler analyzer.ResultsUpdated, AddressOf analyzer_ResultsUpdated
        
        ' Add analysis hints for each form area.
        ' Use the absolute Width and Height of the Grid's
        ' RowDefinition and ColumnDefinition properties defined in XAML, 
        ' to calculate the bounds of the AnalysisHintNode objects.
        hintNodeTitle = analyzer.CreateAnalysisHint(New Rect(100, 0, 740, 100))
        hintNodeDirector = analyzer.CreateAnalysisHint(New Rect(100, 100, 740, 100))
        hintNodeStarring = analyzer.CreateAnalysisHint(New Rect(100, 200, 740, 100))
        hintNodeRating = analyzer.CreateAnalysisHint(New Rect(100, 300, 320, 100))
        hintNodeYear = analyzer.CreateAnalysisHint(New Rect(520, 300, 320, 100))
        hintNodeGenre = analyzer.CreateAnalysisHint(New Rect(100, 400, 740, 100))
        
        'Set the factoids on the hints.
        hintNodeTitle.Factoid = "(!IS_DEFAULT)"
        hintNodeDirector.Factoid = "(!IS_PERSONALNAME_FULLNAME)"
        hintNodeStarring.Factoid = "(!IS_PERSONALNAME_FULLNAME)"
        hintNodeRating.Factoid = "(!IS_DEFAULT)"
        hintNodeYear.Factoid = "(!IS_DATE_YEAR)"
        hintNodeGenre.Factoid = "(!IS_DEFAULT)"
    
    End Sub 'OnContentRendered

    ' <summary>
    ' InkCanvas.StrokeCollected event handler.  Begins 
    ' ink analysis and starts the timer to clear the strokes.
    ' If five seconds pass without a Stroke being added,
    ' the strokes on the InkCanvas will be cleared.
    ' </summary>
    ' <param name="sender">InkCanvas that raises the
    ' StrokeCollected event.</param>
    ' <param name="args">Contains the event data.</param>
    Private Sub RestartAnalysis(ByVal sender As Object, ByVal args As InkCanvasStrokeCollectedEventArgs) 
        
        ' If strokeRemovalTimer is enabled, stop it.
        If Not (strokeRemovalTimer Is Nothing) AndAlso strokeRemovalTimer.IsEnabled Then
            strokeRemovalTimer.Stop()
        End If
        
        ' Restart the timer to clear the strokes in five seconds
        strokeRemovalTimer = New DispatcherTimer( _
                             TimeSpan.FromSeconds(CLEAR_STROKES_DELAY), _
                             DispatcherPriority.Normal, _
                             AddressOf ClearCanvas, _
                             System.Windows.Threading.Dispatcher.CurrentDispatcher)
        
        ' Add the new stroke to the InkAnalyzer and
        ' begin background analysis.
        analyzer.AddStroke(args.Stroke)
        analyzer.BackgroundAnalyze()
    
    End Sub 'RestartAnalysis
    
    ' <summary>
    ' Analyzer.ResultsUpdated event handler.
    ' </summary>
    ' <param name="sender">InkAnalyzer that raises the
    ' event.</param>
    ' <param name="e">Event data</param>
    ' <remarks>This method checks each AnalysisHint for 
    ' analyzed ink and then populated the TextBlock that 
    ' corresponds to the area on the form.</remarks>
    Private Sub analyzer_ResultsUpdated(ByVal sender As Object, ByVal e As ResultsUpdatedEventArgs)

        Dim recoText As String

        recoText = hintNodeTitle.GetRecognizedString()
        If recoText <> "" Then
            xaml_blockTitle.Text = recoText
        End If

        recoText = hintNodeDirector.GetRecognizedString()
        If recoText <> "" Then
            xaml_blockDirector.Text = recoText
        End If

        recoText = hintNodeStarring.GetRecognizedString()
        If recoText <> "" Then
            xaml_blockStarring.Text = recoText
        End If

        recoText = hintNodeRating.GetRecognizedString()
        If recoText <> "" Then
            xaml_blockRating.Text = recoText
        End If

        recoText = hintNodeYear.GetRecognizedString()
        If recoText <> "" Then
            xaml_blockYear.Text = recoText
        End If

        recoText = hintNodeGenre.GetRecognizedString()
        If recoText <> "" Then
            xaml_blockGenre.Text = recoText
        End If

    End Sub 'analyzer_ResultsUpdated
     
    'Clear the canvas, but leave the current strokes in the analyzer.
    Private Sub ClearCanvas(ByVal sender As Object, ByVal args As EventArgs) 

        strokeRemovalTimer.Stop()
        
        xaml_writingCanvas.Strokes.Clear()
    
    End Sub 'ClearCanvas
End Class 'FormAnalyzer
'</Snippet2>