using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Input;

namespace FocusSample
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
        //<SnippetFocusSampleSetFocus>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Sets keyboard focus on the first Button in the sample.
            Keyboard.Focus(firstButton);
        }
        //</SnippetFocusSampleSetFocus>

 //<SnippetFEPredictFocus>
        private void OnPredictFocus(object sender, RoutedEventArgs e)
        {
            DependencyObject predictionElement = null;

            UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;

            if (elementWithFocus != null)
            {
                // Only these four directions are currently supported
                // by PredictFocus, so we need to filter on these only.
                if ((_focusMoveValue == FocusNavigationDirection.Up) ||
                    (_focusMoveValue == FocusNavigationDirection.Down) ||
                    (_focusMoveValue == FocusNavigationDirection.Left) ||
                    (_focusMoveValue == FocusNavigationDirection.Right))
                {

                    // Get the element which would receive focus if focus were changed.
                    predictionElement = elementWithFocus.PredictFocus(_focusMoveValue);

                    Control controlElement = predictionElement as Control;

                    // If a ContentElement.
                    if (controlElement != null)
                    {
                        controlElement.Foreground = Brushes.DarkBlue;
                        controlElement.FontSize += 10;
                        controlElement.FontWeight = FontWeights.ExtraBold;

                        // Fields used to reset the UI when the mouse
                        // button is released.
                        _focusPredicted = true;
                        _predictedControl = controlElement;
                    }
                }
            }
        }
 //</SnippetFEPredictFocus>

        private void OnMoveFocus(object sender, RoutedEventArgs e)
        {
            //<SnippetFocusSampleMoveFocus>
            // Creating a FocusNavigationDirection object and setting it to a
            // local field that contains the direction selected.
            FocusNavigationDirection focusDirection = _focusMoveValue;

            // MoveFocus takes a TraveralReqest as its argument.
            TraversalRequest request = new TraversalRequest(focusDirection);

            //<SnippetGetKeyboardFocusedElement>
            // Gets the element with keyboard focus.
            UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;
            //</SnippetGetKeyboardFocusedElement>

            // Change keyboard focus.
            if (elementWithFocus != null)
            {
                elementWithFocus.MoveFocus(request);
            }
            //</SnippetFocusSampleMoveFocus>
        }

        // Sets the FocusNavigationDirection.
        private void OnFocusSelected(object sender, RoutedEventArgs e)
        {
            RadioButton source = e.Source as RadioButton;

            if (source != null)
            {
                _focusMoveValue = (FocusNavigationDirection)Enum.Parse(
                    typeof(FocusNavigationDirection), (string)source.Content);
            }
        }

        // Resets the UI after PredictFocus changes the UI.
        private void OnPredictFocusMouseUp(object sender, RoutedEventArgs e)
        {

            if (_focusPredicted == true)
            {
                _predictedControl.Foreground = Brushes.Black;
                _predictedControl.FontSize -= 10;
                _predictedControl.FontWeight = FontWeights.Normal;

                _focusPredicted = false;
            }
        }

        // The direction to move/predict focus.
        private FocusNavigationDirection _focusMoveValue;

        // Used to keep track of when a PredictFocus has happened.
        private bool _focusPredicted = false;
        private Control _predictedControl;
    }
}