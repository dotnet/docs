//<Snippet2>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Threading;

public partial class FormAnalyzer : Window
{
    private InkAnalyzer analyzer;

    private AnalysisHintNode hintNodeTitle;
    private AnalysisHintNode hintNodeDirector;
    private AnalysisHintNode hintNodeStarring;
    private AnalysisHintNode hintNodeRating;
    private AnalysisHintNode hintNodeYear;
    private AnalysisHintNode hintNodeGenre;

    // Timer that raises an event to
    // clear the InkCanvas.
    private DispatcherTimer strokeRemovalTimer;

    private const int CLEAR_STROKES_DELAY = 5;

    public FormAnalyzer()
    {
        InitializeComponent();
    }

    protected override void OnContentRendered(EventArgs e)
    {
        base.OnContentRendered(e);

        // Initialize the Analyzer.
        analyzer = new InkAnalyzer();
        analyzer.ResultsUpdated += 
            new ResultsUpdatedEventHandler(analyzer_ResultsUpdated);

        // Add analysis hints for each form area.
        // Use the absolute Width and Height of the Grid's
        // RowDefinition and ColumnDefinition properties defined in XAML, 
        // to calculate the bounds of the AnalysisHintNode objects.
        hintNodeTitle = analyzer.CreateAnalysisHint(
                                    new Rect(100, 0, 740, 100));
        hintNodeDirector = analyzer.CreateAnalysisHint(
                                    new Rect(100, 100, 740, 100));
        hintNodeStarring = analyzer.CreateAnalysisHint(
                                    new Rect(100, 200, 740, 100));
        hintNodeRating = analyzer.CreateAnalysisHint(
                                    new Rect(100, 300, 320, 100));
        hintNodeYear = analyzer.CreateAnalysisHint(
                                    new Rect(520, 300, 320, 100));
        hintNodeGenre = analyzer.CreateAnalysisHint(
                                    new Rect(100, 400, 740, 100));

        //Set the factoids on the hints.
        hintNodeTitle.Factoid = "(!IS_DEFAULT)";
        hintNodeDirector.Factoid = "(!IS_PERSONALNAME_FULLNAME)";
        hintNodeStarring.Factoid = "(!IS_PERSONALNAME_FULLNAME)";
        hintNodeRating.Factoid = "(!IS_DEFAULT)";
        hintNodeYear.Factoid = "(!IS_DATE_YEAR)";
        hintNodeGenre.Factoid = "(!IS_DEFAULT)";
    }

    /// <summary>
    /// InkCanvas.StrokeCollected event handler.  Begins 
    /// ink analysis and starts the timer to clear the strokes.
    /// If five seconds pass without a Stroke being added,
    /// the strokes on the InkCanvas will be cleared.
    /// </summary>
    /// <par    am name="sender">InkCanvas that raises the
    /// StrokeCollected event.</param>
    /// <param name="args">Contains the event data.</param>
    private void RestartAnalysis(object sender,
                    InkCanvasStrokeCollectedEventArgs args)
    {

        // If strokeRemovalTimer is enabled, stop it.
        if (strokeRemovalTimer != null && strokeRemovalTimer.IsEnabled)
        {
            strokeRemovalTimer.Stop();
        }

        // Restart the timer to clear the strokes in five seconds
        strokeRemovalTimer = new DispatcherTimer(
                             TimeSpan.FromSeconds(CLEAR_STROKES_DELAY),
                             DispatcherPriority.Normal,
                             ClearCanvas,
                             Dispatcher.CurrentDispatcher);

        // Add the new stroke to the InkAnalyzer and
        // begin background analysis.
        analyzer.AddStroke(args.Stroke);
        analyzer.BackgroundAnalyze();
    }

    /// <summary>
    /// Analyzer.ResultsUpdated event handler.
    /// </summary>
    /// <param name="sender">InkAnalyzer that raises the
    /// event.</param>
    /// <param name="e">Event data</param>
    /// <remarks>This method checks each AnalysisHint for 
    /// analyzed ink and then populated the TextBlock that 
    /// corresponds to the area on the form.</remarks>
    void analyzer_ResultsUpdated(object sender, ResultsUpdatedEventArgs e)
    {
        string recoText;

        recoText = hintNodeTitle.GetRecognizedString();
        if (recoText != "") xaml_blockTitle.Text = recoText;

        recoText = hintNodeDirector.GetRecognizedString();
        if (recoText != "") xaml_blockDirector.Text = recoText;

        recoText = hintNodeStarring.GetRecognizedString();
        if (recoText != "") xaml_blockStarring.Text = recoText;

        recoText = hintNodeRating.GetRecognizedString();
        if (recoText != "") xaml_blockRating.Text = recoText;

        recoText = hintNodeYear.GetRecognizedString();
        if (recoText != "") xaml_blockYear.Text = recoText;

        recoText = hintNodeGenre.GetRecognizedString();
        if (recoText != "") xaml_blockGenre.Text = recoText;
    }

    //Clear the canvas, but leave the current strokes in the analyzer.
    private void ClearCanvas(object sender, EventArgs args)
    {
        strokeRemovalTimer.Stop();

        xaml_writingCanvas.Strokes.Clear();
    }
}
//</Snippet2>