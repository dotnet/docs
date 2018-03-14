 'This is a list of commonly used namespaces for a pane.
Imports System
Imports System.Windows
Imports System.Windows.Documents
Imports System.Windows.Controls
Imports System.Windows.Navigation
Imports System.Windows.Input
Imports System.Windows.Media


Namespace ImageElementExample


    Class SampleViewer
        Inherits Window
        '
        'ToDo: Error processing original source shown below
        '{
        '   public partial class SampleViewer : Window
        '-----------^--- 'class', 'struct', 'interface' or 'delegate' expected
        '
        'ToDo: Error processing original source shown below
        '{
        '   public partial class SampleViewer : Window
        '-------------------^--- Syntax error: ';' expected
        Public Sub New()
            InitializeComponent()

        End Sub 'New
    End Class 'SampleViewer 
End Namespace 'ImageElementExample
