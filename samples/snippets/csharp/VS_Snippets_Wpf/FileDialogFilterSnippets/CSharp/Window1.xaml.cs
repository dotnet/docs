using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//<SnippetNSCODE>
using Microsoft.Win32;
//</SnippetNSCODE>

namespace FileDialogFilterSnippets
{
/// <summary>
/// Interaction logic for Window1.xaml
/// </summary>

public partial class Window1 : System.Windows.Window
{

public Window1()
{
InitializeComponent();
method8();
}

void method1()
{
//<SnippetFilterString1>
OpenFileDialog dlg = new OpenFileDialog();

// Show all files
dlg.Filter = string.Empty;

dlg.ShowDialog();
//</SnippetFilterString1>
}
void method2()
{
//<SnippetFilterString2>
OpenFileDialog dlg = new OpenFileDialog();

// Show all files
dlg.Filter = null;

dlg.ShowDialog();
//</SnippetFilterString2>
}
void method3()
{
//<SnippetFilterString3>
OpenFileDialog dlg = new OpenFileDialog();

// Filter by Word Documents
dlg.Filter = "Word Documents|*.doc";

dlg.ShowDialog();
//</SnippetFilterString3>
}
void method4()
{
//<SnippetFilterString4>
OpenFileDialog dlg = new OpenFileDialog();

// Filter by Excel Worksheets
dlg.Filter = "Excel Worksheets|*.xls";

dlg.ShowDialog();
//</SnippetFilterString4>
}
void method5()
{
//<SnippetFilterString5>
OpenFileDialog dlg = new OpenFileDialog();

// Filter by PowerPoint Presentations
dlg.Filter = "PowerPoint Presentations|*.ppt";

dlg.ShowDialog();
//</SnippetFilterString5>
}
void method6()
{
//<SnippetFilterString6>
OpenFileDialog dlg = new OpenFileDialog();

// Filter by Office Files
dlg.Filter = "Office Files|*.doc;*.xls;*.ppt";

dlg.ShowDialog();
//</SnippetFilterString6>
}
void method7()
{
//<SnippetFilterString7>
OpenFileDialog dlg = new OpenFileDialog();

// Filter by All Files
dlg.Filter = "All Files|*.*";

dlg.ShowDialog();
//</SnippetFilterString7>
}
void method8()
{
//<SnippetFilterString8>
OpenFileDialog dlg = new OpenFileDialog();

// Filter by Word Documents OR Excel Worksheets OR PowerPoint Presentations 
//           OR Office Files 
//           OR All Files
dlg.Filter = "Word Documents|*.doc|Excel Worksheets|*.xls|PowerPoint Presentations|*.ppt" +
             "|Office Files|*.doc;*.xls;*.ppt" +
             "|All Files|*.*";

dlg.ShowDialog();
//</SnippetFilterString8>
}
}
}