using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VSMGoToElementState
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GenerateNumber();
            //Show the answer in the title bar for testing purposes.
            Title = this.number.ToString();

        }

        //<SnippetGoToElementStateCode>
        int number;

        private void GenerateNumber()
        {
            System.Random r = new System.Random();
            number = r.Next(100) + 1;
        }

        private void OnGuess(object sender, System.Windows.RoutedEventArgs e)
        {
            int guess;

            if (int.TryParse(this.Guess.Text, out guess))
            {
                if (guess < this.number)
                {
                    VisualStateManager.GoToElementState(this.LayoutRoot, "TooLow", true);
                    this.Result.Text = "Too Low!";
                }
                else if (guess > this.number)
                {
                    VisualStateManager.GoToElementState(this.LayoutRoot, "TooHigh", true);
                    this.Result.Text = "Too High!";
                }
                else
                {
                    VisualStateManager.GoToElementState(this.LayoutRoot, "Correct", true);
                    this.Result.Text = "Correct!";
                }
            }
        }

        private void OnTypingGuess(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            VisualStateManager.GoToElementState(this.LayoutRoot, "Guessing", true);
            this.Result.Text = "";
        }
        //</SnippetGoToElementStateCode>
    }
}
