
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes



'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Class Window1
    Inherits Window '
    'ToDo: Error processing original source shown below
    '
    '    public partial class Window1 : Window
    '------------^--- 'class', 'struct', 'interface' or 'delegate' expected
    '
    'ToDo: Error processing original source shown below
    '
    '    public partial class Window1 : Window
    '--------------------^--- Syntax error: ';' expected
    
    Private eraser As InkEraser
    
    
    Public Sub New() 
        InitializeComponent()
        eraser = New InkEraser()
        Me.Content = eraser
        
        Me.WindowState = WindowState.Maximized
    
    End Sub 'New
End Class 'Window1 