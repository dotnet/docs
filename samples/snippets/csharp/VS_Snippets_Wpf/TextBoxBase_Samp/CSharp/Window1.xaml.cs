using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SDKSample
{
    public partial class Window1 : Window
    {
        // <SnippetTextBoxBase3>
        private void initValues(object sender, EventArgs e)
        {
            myTB1.Text= "ExtentHeight is currently " + myTextBox.ExtentHeight.ToString();
            myTB2.Text= "ExtentWidth is currently " + myTextBox.ExtentWidth.ToString();
            myTB3.Text= "HorizontalOffset is currently " + myTextBox.HorizontalOffset.ToString();
            myTB4.Text= "VerticalOffset is currently " + myTextBox.VerticalOffset.ToString();
            myTB5.Text = "ViewportHeight is currently " + myTextBox.ViewportHeight.ToString();
            myTB6.Text = "ViewportWidth is currently " + myTextBox.ViewportWidth.ToString();
            radiobtn1.IsChecked = true;
        }
        // </SnippetTextBoxBase3>
        // <SnippetTextBoxBase4>
        private void copyText(object sender, RoutedEventArgs e)
        {
            myTextBox.Copy();
        }
        // </SnippetTextBoxBase4>
        // <SnippetTextBoxBase5>
        private void cutText(object sender, RoutedEventArgs e)
        {
            myTextBox.Cut();
        }
        // </SnippetTextBoxBase5>
        // <SnippetTextBoxBase6>
        private void pasteSelection(object sender, RoutedEventArgs e)
        {
            myTextBox.Paste();
        }
        // </SnippetTextBoxBase6>
        // <SnippetTextBoxBase7>
        private void selectAll(object sender, RoutedEventArgs e)
        {
            myTextBox.SelectAll();
        }
        // </SnippetTextBoxBase7>
        // <SnippetTextBoxBase8>
        private void undoAction(object sender, RoutedEventArgs e)
        {
            if (myTextBox.CanUndo == true)
            {
                myTextBox.Undo();
            }
        }
        // </SnippetTextBoxBase8>
        // <SnippetTextBoxBase9>
        private void redoAction(object sender, RoutedEventArgs e)
        {
            if (myTextBox.CanRedo == true)
            {
                myTextBox.Redo();
            }
        }
        // </SnippetTextBoxBase9>
        // <SnippetTextBoxBase10>
        private void selectChanged(object sender, RoutedEventArgs e)
        {
            myTextBox.AppendText("Selection Changed event in myTextBox2 has just occurred.");
        }
        // </SnippetTextBoxBase10>
        // <SnippetTextBoxBase11>
        private void tChanged(object sender, RoutedEventArgs e)
        {
            myTextBox.AppendText("Text content of myTextBox2 has changed.");
        }
        // </SnippetTextBoxBase11>
        // <SnippetTextBoxBase12>
        private void wrapOff(object sender, RoutedEventArgs e)
        {
            myTextBox.TextWrapping = TextWrapping.NoWrap;
        }
        // </SnippetTextBoxBase12>
        private void wrapOn(object sender, RoutedEventArgs e)
        {
            myTextBox.TextWrapping = TextWrapping.Wrap;
        }   
        private void clearTB1(object sender, RoutedEventArgs e)
        {
            myTextBox.Clear();
        }
        private void clearTB2(object sender, RoutedEventArgs e)
        {
            myTextBox2.Clear();
        }
        // <SnippetTextBoxBase13>
        private void lineDown(object sender, RoutedEventArgs e)
        {
            myTextBox.LineDown();
        }
        // </SnippetTextBoxBase13>
        // <SnippetTextBoxBase14>
        private void lineLeft(object sender, RoutedEventArgs e)
        {
            myTextBox.LineLeft();
        }
        // </SnippetTextBoxBase14>
        // <SnippetTextBoxBase15>
        private void lineRight(object sender, RoutedEventArgs e)
        {
            myTextBox.LineRight();
        }
        // </SnippetTextBoxBase15>
        // <SnippetTextBoxBase16>
        private void lineUp(object sender, RoutedEventArgs e)
        {
            myTextBox.LineUp();
        }
        // </SnippetTextBoxBase16>
        // <SnippetTextBoxBase17>
        private void pageDown(object sender, RoutedEventArgs e)
        {
            myTextBox.PageDown();
        }
        // </SnippetTextBoxBase17>
        // <SnippetTextBoxBase18>
        private void pageLeft(object sender, RoutedEventArgs e)
        {
            myTextBox.PageLeft();
        }
        // </SnippetTextBoxBase18>
        // <SnippetTextBoxBase19>
        private void pageRight(object sender, RoutedEventArgs e)
        {
            myTextBox.PageRight();
        }
        // </SnippetTextBoxBase19>
        // <SnippetTextBoxBase20>
        private void pageUp(object sender, RoutedEventArgs e)
        {
            myTextBox.PageUp();
        }
        // </SnippetTextBoxBase20>
        // <SnippetTextBoxBase21>
        private void scrollHome(object sender, RoutedEventArgs e)
        {
            myTextBox.ScrollToHome();
        }
        // </SnippetTextBoxBase21>
        // <SnippetTextBoxBase22>
        private void scrollEnd(object sender, RoutedEventArgs e)
        {
            myTextBox.ScrollToEnd();
        }
        // </SnippetTextBoxBase22>
    }
}