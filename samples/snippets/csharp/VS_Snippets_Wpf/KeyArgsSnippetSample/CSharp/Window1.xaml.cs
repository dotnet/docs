using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;

namespace KeyArgsSnippetSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        private void KeyHandler(object sender, KeyEventArgs e)
        {
            btnKeyStates.Content = e.KeyStates.ToString();

            //<SnippetKeyEventArgsKeyStatesDown>
            // A bitwise AND operation is used in the comparison.
            // e is an instance of KeyEventArgs.
            // btnDown is a Button.
            if ((e.KeyStates & KeyStates.Down) > 0)
            {
                btnDown.Background = Brushes.Red;
            }
            //</SnippetKeyEventArgsKeyStatesDown>

            else
            {
                btnDown.Background = Brushes.AliceBlue;
            }

            if ((int)e.KeyStates == 3)
            {
                btnIsToggledAndDown.Background = Brushes.Blue;
            }
            else
            {
                btnIsToggledAndDown.Background = Brushes.AliceBlue;
            }

            //<SnippetKeyEventArgsKeyStatesNone>
            // e is an instance of KeyEventArgs.
            // btnNone is a Button.
            if ((e.KeyStates & KeyStates.None) > 0)
            {
                btnNone.Background = Brushes.Red;
            }
            //</SnippetKeyEventArgsKeyStatesNone>

            //<SnippetKeyEventArgsKeyBoardGetKeyStates>
            // Uses the Keyboard.GetKeyStates to determine if a key is down.
            // A bitwise AND operation is used in the comparison.
            // e is an instance of KeyEventArgs.
            if ((Keyboard.GetKeyStates(Key.Return) & KeyStates.Down) > 0)
            {
                btnNone.Background = Brushes.Red;
            }
            //</SnippetKeyEventArgsKeyBoardGetKeyStates>

            else
            {
                btnNone.Background = Brushes.AliceBlue;
            }

            //<SnippetKeyEventArgsKeyStatesToggled>
            // Uses the Keyboard.GetKeyStates to determine if a key is toggled.
            // A bitwise AND operation is used in the comparison.
            // e is a instance of KeyEventArgs.
            // btnToggled is a Button.
            if ((e.KeyStates & KeyStates.Toggled) > 0)
            {
                btnToggled.Background = Brushes.Red;
            }
            //</SnippetKeyEventArgsKeyStatesToggled>
            else
            {
                btnToggled.Background = Brushes.AliceBlue;
            }

            if (e.IsDown)
            {
                if (e.IsRepeat)
                {
                    btnIsRepeat.Background = Brushes.Red;
                }
            }

            //<SnippetKeyEventArgsIsDown>
            // e is an instance of KeyEventArgs.
            // btnIsDown is a Button.
            if (e.IsDown)
            {
                btnIsDown.Background = Brushes.Red;
            }
            //</SnippetKeyEventArgsIsDown>
            else
            {
                btnIsDown.Background = Brushes.AliceBlue;
            }

            //<SnippetKeyEventArgsKeyBoardIsKeyDown>
            // Uses the Keyboard.IsKeyDown to determine if a key is down.
            // e is an instance of KeyEventArgs.
            if (Keyboard.IsKeyDown(Key.Return))
            {
                btnIsDown.Background = Brushes.Red;
            }
            else
            {
                btnIsDown.Background = Brushes.AliceBlue;
            }
            //</SnippetKeyEventArgsKeyBoardIsKeyDown>

            if (e.IsUp)
            {
                // Turn Off Repeat Indicator
                if (btnIsRepeat.Background == Brushes.Red)
                {
                    btnIsRepeat.Background = Brushes.AliceBlue;
                }

                //<SnippetKeyEventArgsIsRepeat>
                // e is an instance of KeyEventArgs.
                // btnIsRepeat is a Button.
                if (e.IsRepeat)
                {
                    btnIsRepeat.Background = Brushes.AliceBlue;
                }
                //</SnippetKeyEventArgsIsRepeat>
            }

            //<SnippetKeyEventArgsIsUp>
            // e is an instance of KeyEventArgs.
            // btnIsUp is a Button.
            if (e.IsUp)
            {
                btnIsUp.Background = Brushes.Red;
            }
            //</SnippetKeyEventArgsIsUp>
            else
            {
                btnIsUp.Background = Brushes.AliceBlue;
            }

            //<SnippetKeyEventArgsKeyBoardIsKeyUp>
            // Uses the Keyboard.IsKeyUp to determine if a key is up.
            if (Keyboard.IsKeyUp(Key.Return))
            {
                btnIsUp.Background = Brushes.Red;
            }
            else
            {
                btnIsUp.Background = Brushes.AliceBlue;
            }
            //</SnippetKeyEventArgsKeyBoardIsKeyUp>

            //<SnippetKeyEventArgsIsToggled>
            // e is a instance of KeyEventArgs.
            // btnIsToggled is a Button.
            if (e.IsToggled)
            {
                btnIsToggle.Background = Brushes.Red;
            }
            //</SnippetKeyEventArgsIsToggled>
            else
            {
                btnIsToggle.Background = Brushes.AliceBlue;
            }
            //<SnippetKeyEventArgsKeyBoardIsToggled>
            // Uses the Keyboard.IsToggled to determine if a key is toggled.
            if (Keyboard.IsKeyToggled(Key.Return))
            {
                btnIsToggle.Background = Brushes.Red;
            }
            else
            {
                btnIsToggle.Background = Brushes.AliceBlue;
            }
            //</SnippetKeyEventArgsKeyBoardIsToggled>

            //<SnippetKeyboardModifiersBitOperation>
            if ((Keyboard.Modifiers & ModifierKeys.Control) > 0)
            {
                button1.Background = Brushes.Red;
            }
            else
            {
                button1.Background = Brushes.Blue;
            }
            //</SnippetKeyboardModifiersBitOperation>

            btnValue.Content = ((byte)e.KeyStates).ToString();
        }
    }
}