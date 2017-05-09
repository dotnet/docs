using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;
using System.Windows.Input;

namespace InkPresenterSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    //<Snippet1>   
    public partial class Window1 : Window
    {
        InkPresenter inkPresenter1;

        public Window1()
        {
            InitializeComponent();

        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            inkPresenter1 = new InkPresenter();

            this.Content = inkPresenter1;

            StylusPoint segment1Start = new StylusPoint(200, 110);
            StylusPoint segment1End = new StylusPoint(185, 150);
            StylusPoint segment2Start = new StylusPoint(185, 150);
            StylusPoint segment2End = new StylusPoint(135, 150);
            StylusPoint segment3Start = new StylusPoint(135, 150);
            StylusPoint segment3End = new StylusPoint(175, 180);
            StylusPoint segment4Start = new StylusPoint(175, 180);
            StylusPoint segment4End = new StylusPoint(160, 220);
            StylusPoint segment5Start = new StylusPoint(160, 220);
            StylusPoint segment5End = new StylusPoint(200, 195);
            StylusPoint segment6Start = new StylusPoint(200, 195);
            StylusPoint segment6End = new StylusPoint(240, 220);
            StylusPoint segment7Start = new StylusPoint(240, 220);
            StylusPoint segment7End = new StylusPoint(225, 180);
            StylusPoint segment8Start = new StylusPoint(225, 180);
            StylusPoint segment8End = new StylusPoint(265, 150);
            StylusPoint segment9Start = new StylusPoint(265, 150);
            StylusPoint segment9End = new StylusPoint(215, 150);
            StylusPoint segment10Start = new StylusPoint(215, 150);
            StylusPoint segment10End = new StylusPoint(200, 110);

            StylusPointCollection strokePoints = new StylusPointCollection();

            strokePoints.Add(segment1Start);
            strokePoints.Add(segment1End);
            strokePoints.Add(segment2Start);
            strokePoints.Add(segment2End);
            strokePoints.Add(segment3Start);
            strokePoints.Add(segment3End);
            strokePoints.Add(segment4Start);
            strokePoints.Add(segment4End);
            strokePoints.Add(segment5Start);
            strokePoints.Add(segment5End);
            strokePoints.Add(segment6Start);
            strokePoints.Add(segment6End);
            strokePoints.Add(segment7Start);
            strokePoints.Add(segment7End);
            strokePoints.Add(segment8Start);
            strokePoints.Add(segment8End);
            strokePoints.Add(segment9Start);
            strokePoints.Add(segment9End);
            strokePoints.Add(segment10Start);
            strokePoints.Add(segment10End);

            Stroke newStroke = new Stroke(strokePoints);
            inkPresenter1.Strokes.Add(newStroke);
        }
    }
    //</Snippet1>
}