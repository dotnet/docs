using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Input;

namespace Input_Ovw
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class Page1 : Page
    {
        private void OnLoaded(object sender, EventArgs e)
        {
            //<SnippetInput_OvwHandlingInputCodeBehind>
            // Create the UI elements.
            StackPanel inputStackPanel= new StackPanel();
            Button inputButton = new Button();
            TextBox inputTextBox = new TextBox();

            // Attach the Button and TextBox to the StackPanel.
            inputStackPanel.Children.Add(inputButton);
            inputStackPanel.Children.Add(inputTextBox);

            // Attach the event handlers.
            inputStackPanel.KeyDown += new KeyEventHandler(OnOverviewKeyDown);
            inputButton.Click += new RoutedEventHandler(OnOverviewButtonClick);
            //</SnippetInput_OvwHandlingInputCodeBehind>



            //<SnippetInput_OvwKeyboardExampleUICodeBehind>
            // Create the UI elements.
            StackPanel keyboardStackPanel = new StackPanel();
            Button keyboardButton1 = new Button();

            // Set properties on Buttons.
            keyboardButton1.Background = Brushes.AliceBlue;
            keyboardButton1.Content = "Button 1";

            // Attach Buttons to StackPanel.
            keyboardStackPanel.Children.Add(keyboardButton1);

            // Attach event handler.
            keyboardButton1.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            //</SnippetInput_OvwKeyboardExampleUICodeBehind>

 


            //<SnippetInput_OvwMouseExampleUICodeBehind>
            // Create the UI elements.
            StackPanel mouseMoveStackPanel = new StackPanel();
            Button mouseMoveButton = new Button();

            // Set properties on Button.
            mouseMoveButton.Background = Brushes.AliceBlue;
            mouseMoveButton.Content = "Button";

            // Attach Buttons to StackPanel.
            mouseMoveStackPanel.Children.Add(mouseMoveButton);

            // Attach event handler.
            mouseMoveButton.MouseEnter += new MouseEventHandler(OnMouseExampleMouseEnter);
            mouseMoveButton.MouseLeave += new MouseEventHandler(OnMosueExampleMouseLeave);
            //</SnippetInput_OvwMouseExampleUICodeBehind>

            //<SnippetInput_OvwTextInputUICodeBehind>
            // Create the UI elements.
            StackPanel textInputStackPanel = new StackPanel();
            Button textInputeButton = new Button();
            TextBox textInputTextBox = new TextBox();
            textInputeButton.Content = "Open";

            // Attach elements to StackPanel.
            textInputStackPanel.Children.Add(textInputeButton);
            textInputStackPanel.Children.Add(textInputTextBox);

            // Attach event handlers.
            textInputStackPanel.KeyDown += new KeyEventHandler(OnTextInputKeyDown);
            textInputeButton.Click += new RoutedEventHandler(OnTextInputButtonClick);
            //</SnippetInput_OvwTextInputUICodeBehind>

            // Attach to main Stackpanel.
            mainStackPanel.Children.Add(inputStackPanel);
            mainStackPanel.Children.Add(keyboardStackPanel);
            mainStackPanel.Children.Add(mouseMoveStackPanel);
            mainStackPanel.Children.Add(textInputStackPanel);
        }

        //<SnippetInput_OvwHandlingInputKeyDownHandler>
        private void OnOverviewKeyDown(object sender, KeyEventArgs e) 
        {
            // If the "A" key is is pressed, open a MessageBox.
            if (e.Key == Key.A) 
            {
                MessageBox.Show("The A key was pressed!");
            }
        }
        //</SnippetInput_OvwHandlingInputKeyDownHandler>

        //<SnippetInput_OvwHandlingInputClickHandler>
        private void OnOverviewButtonClick(object sender, RoutedEventArgs e) 
        {
            // If the Button is clicked, open a MessageBox.
            MessageBox.Show("The Button was Clicked");
        }
        //</SnippetInput_OvwHandlingInputClickHandler>

        //<SnippetInput_OvwKeyboardExampleHandlerCodeBehind>
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            Button source = e.Source as Button;
            if (source != null)
            {
                if (e.Key == Key.Left)
                {
                    source.Background = Brushes.LemonChiffon;
                }
                else
                {
                    source.Background = Brushes.AliceBlue;
                }
            }
        }
        //</SnippetInput_OvwKeyboardExampleHandlerCodeBehind>

        //<SnippetInput_OvwMouseExampleEneterHandler>
        private void OnMouseExampleMouseEnter(object sender, MouseEventArgs e)
        {
            // Cast the source of the event to a Button.
            Button source = e.Source as Button;

            // If source is a Button.
            if (source != null)
            {
                source.Background = Brushes.SlateGray;
            }
        }
        //</SnippetInput_OvwMouseExampleEneterHandler>

        //<SnippetInput_OvwMouseExampleLeaveHandler>
        private void OnMosueExampleMouseLeave(object sender, MouseEventArgs e)
        {
            // Cast the source of the event to a Button.
            Button source = e.Source as Button;

            // If source is a Button.
            if (source != null)
            {
                source.Background = Brushes.AliceBlue;
            }
        }
        //</SnippetInput_OvwMouseExampleLeaveHandler>


        //<SnippetInput_OvwTextInputHandlersCodeBehind>
        private void OnTextInputKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.O && Keyboard.Modifiers == ModifierKeys.Control)
            {
                handle();
                e.Handled = true;
            }
        }

        private void OnTextInputButtonClick(object sender, RoutedEventArgs e)
        {
            handle();
            e.Handled = true;
        } 

        public void handle()
        {
            MessageBox.Show("Pretend this opens a file");
        }
        //</SnippetInput_OvwTextInputHandlersCodeBehind>



        private void handler1(object sender, MouseButtonEventArgs e)
        {

        }
        private void handler2(object sender, MouseButtonEventArgs e)
        {

        }

    }
}