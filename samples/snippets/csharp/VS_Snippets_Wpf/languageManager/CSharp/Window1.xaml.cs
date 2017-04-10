using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Globalization;

namespace languageManagerSample
{

	public partial class Window1 : Window
	{
 
        private void changeLang(object sender, RoutedEventArgs e)
            {
                // <Snippet1>
                this.Dispatcher.Thread.CurrentCulture.Name.ToString();
                InputLanguageManager.SetInputLanguage(myTextBox, CultureInfo.CreateSpecificCulture("fr"));
                tb2.Text = "Available Input Languages:";
                lb1.ItemsSource = InputLanguageManager.Current.AvailableInputLanguages;
                tb3.Text = "Input Language of myTextBox is " + InputLanguageManager.GetInputLanguage(myTextBox).ToString();
                tb4.Text = "CurrentCulture is Set to " + this.Dispatcher.Thread.CurrentCulture.Name.ToString();
                // </Snippet1>

                // <Snippet2>
                InputMethod.SetPreferredImeState(myTextBox, InputMethodState.On);
                InputMethod.Current.ImeSentenceMode = ImeSentenceModeValues.Automatic;
                InputMethod.Current.HandwritingState = InputMethodState.On;
                InputMethod.Current.SpeechMode = SpeechMode.Dictation;
                InputScope myInputScope = new InputScope();
                myInputScope.RegularExpression = "W|P|F";
                InputMethod.SetInputScope(myTextBox, myInputScope);
                tb6.Text = "Configuration UI Available?: " + InputMethod.Current.CanShowConfigurationUI.ToString();
                // </Snippet2>    
        }

        private void inputManager(object sender, RoutedEventArgs e)
            {
                // <Snippet3>
                InputLanguageManager.SetInputLanguage(tb1, CultureInfo.CreateSpecificCulture("fr"));
                tb1.Text = "Current Input Language is " + InputLanguageManager.Current.CurrentInputLanguage.ToString();
                // </Snippet3>
            }

	}
}