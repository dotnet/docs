using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharp
{
    public partial class DatePage : Page, IProvideCustomContentState
    {
        public DatePage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(DatePage_Loaded);
        }

        DateTime dateTime = DateTime.Now;

        void DatePage_Loaded(object sender, RoutedEventArgs e)
        {
            this.textBlockLabel.Text = this.dateTime.ToString();
        }

        void addBackEntryButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.AddBackEntry(new MyCustomContentState(this.dateTime.ToString(), this.textBlockLabel));
            this.dateTime = DateTime.Now;
            this.textBlockLabel.Text = this.dateTime.ToString();
        }

        //<SnippetGetJournalEntryCODEBEHIND>
        void removeJournalEntryButton_Click(object sender, RoutedEventArgs e)
        {
            // If there are journal entries on the back navigation stack
            if (this.NavigationService.CanGoBack)
            {
                // Remove and get the most recent entry on the back navigation stack
                JournalEntry journalEntry = this.NavigationService.RemoveBackEntry();

                string name = journalEntry.Name;
                string uri = journalEntry.Source.OriginalString;
                MessageBox.Show(name + " [" + uri + "] removed from back navigation.");
            }
        }
        //</SnippetGetJournalEntryCODEBEHIND>

        #region IProvideCustomContentState Members

        public CustomContentState GetContentState()
        {
            return new MyCustomContentState(this.textBlockLabel.Text, this.textBlockLabel);
        }

        #endregion
    }
}