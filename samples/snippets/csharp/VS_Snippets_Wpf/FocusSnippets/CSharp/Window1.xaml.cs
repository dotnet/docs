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


namespace SDKSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

            //<SnippetFocusSetIsFocusScope>
            StackPanel focuseScope2 = new StackPanel();
            FocusManager.SetIsFocusScope(focuseScope2, true);
            //</SnippetFocusSetIsFocusScope>

            Button button3 = new Button();
            focuseScope2.Children.Add(button3);
            Button button4 = new Button();
            focuseScope2.Children.Add(button4);
            mainStackPanel.Children.Add(focuseScope2);

            GetFocusedElement();
        }

        public void GetFocusedElement()
        {
            //<SnippetFocusGetSetFocusedElement>
            // Sets the focused element in focusScope1
            // focusScope1 is a StackPanel.
            FocusManager.SetFocusedElement(focusScope1, button2);

            // Gets the focused element for focusScope 1
            IInputElement focusedElement = FocusManager.GetFocusedElement(focusScope1);
            //</SnippetFocusGetSetFocusedElement>

            MessageBox.Show(focusedElement.ToString());
        }



    }
}