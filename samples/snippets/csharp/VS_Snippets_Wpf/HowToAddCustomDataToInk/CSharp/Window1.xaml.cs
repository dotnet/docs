//<Snippet3>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Ink;

/// <summary>
/// Interaction logic for Window1.xaml
/// </summary>

public partial class Window1 : Window
{
    Guid authorGuid = new Guid("12345678-9012-3456-7890-123456789012");
    DrawingAttributes teachersDA = new DrawingAttributes();
    DrawingAttributes studentsDA = new DrawingAttributes();
    string teacher = "teacher";
    string student = "student";
    bool useStudentPen = false;

    public Window1()
    {
        InitializeComponent();

        teachersDA.Color = Colors.Red;
        teachersDA.Width = 5;
        teachersDA.Height = 5;
        teachersDA.AddPropertyData(authorGuid, teacher);

        studentsDA.Color = Colors.Blue;
        studentsDA.Width = 5;
        studentsDA.Height = 5;
        studentsDA.AddPropertyData(authorGuid, student);

        inkCanvas1.DefaultDrawingAttributes = teachersDA;
    }

    // Switch between using the 'pen' DrawingAttributes and the
    // 'highlighter' DrawingAttributes.
    void switchAuthor_click(Object sender, RoutedEventArgs e)
    {
        useStudentPen = !useStudentPen;

        if (useStudentPen)
        {
            switchAuthor.Content = "Use teacher's pen";
            inkCanvas1.DefaultDrawingAttributes = studentsDA;
        }
        else
        {
            switchAuthor.Content = "Use student's pen";
            inkCanvas1.DefaultDrawingAttributes = teachersDA;
        }
    }

    // Change the color of the ink that on the InkCanvas that used the pen.
    void changeColor_click(Object sender, RoutedEventArgs e)
    {
        foreach (Stroke s in inkCanvas1.Strokes)
        {
            if (s.DrawingAttributes.ContainsPropertyData(authorGuid))
            {
                object data = s.DrawingAttributes.GetPropertyData(authorGuid);

                if ((data is string) && ((string)data == teacher))
                {
                    s.DrawingAttributes.Color = Colors.Black;
                }
                if ((data is string) && ((string)data == student))
                {
                    s.DrawingAttributes.Color = Colors.Green;
                }
            }
        }
    }
}
//</Snippet3>

class CodeSnippet
{
    InkCanvas inkCanvas1;
    //<Snippet1>
    Guid timestamp = new Guid("12345678-9012-3456-7890-123456789012");

    // Add a timestamp to the StrokeCollection.
    private void AddTimestamp()
    {

        inkCanvas1.Strokes.AddPropertyData(timestamp, DateTime.Now);
    }

    // Get the timestamp of the StrokeCollection.
    private void GetTimestamp()
    {

        if (inkCanvas1.Strokes.ContainsPropertyData(timestamp))
        {
            object date = inkCanvas1.Strokes.GetPropertyData(timestamp);

            if (date is DateTime)
            {
                MessageBox.Show("This StrokeCollection's timestamp is " +
                    ((DateTime)date).ToString());
            }
        }
        else
        {
            MessageBox.Show(
                "The StrokeCollection does not have a timestamp.");
        }
    }
    //</Snippet1>
}
