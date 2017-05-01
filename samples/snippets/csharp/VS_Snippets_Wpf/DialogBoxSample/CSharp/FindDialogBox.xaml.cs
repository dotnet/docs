//<SnippetTextFoundEventCODEBEHIND1>
//<SnippetTextFoundEventRaiseCODEBEHIND1>
//<SnippetFindDialogCloseCODEBEHIND1>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace SDKSample
{
    public partial class FindDialogBox : Window
    {
        //</SnippetTextFoundEventRaiseCODEBEHIND1>
        //</SnippetFindDialogCloseCODEBEHIND1>
        public event TextFoundEventHandler TextFound;
        protected virtual void OnTextFound()
        {
            TextFoundEventHandler textFound = this.TextFound;
            if (textFound != null) textFound(this, EventArgs.Empty);
        }
        //</SnippetTextFoundEventCODEBEHIND1>

        public FindDialogBox(TextBox textBoxToSearch)
        {
            InitializeComponent();

            this.textBoxToSearch = textBoxToSearch;

            // If text box that's being searched is changed, reset search
            this.textBoxToSearch.TextChanged += textBoxToSearch_TextChanged;
        }

        // Text to search
        TextBox textBoxToSearch;

        // Find results
        MatchCollection matches;
        int matchIndex = 0;

        // Search results
        int index = 0;
        int length = 0;

        public int Index
        {
            get { return this.index; }
            set { this.index = value; }
        }

        public int Length
        {
            get { return this.length; }
            set { this.length = value; }
        }

        //<SnippetTextFoundEventRaiseCODEBEHIND2>
        void findNextButton_Click(object sender, RoutedEventArgs e)
        {
            //</SnippetTextFoundEventRaiseCODEBEHIND2>

            // Find matches
            if (this.matches == null)
            {
                string pattern = this.findWhatTextBox.Text;

                // Match whole word?
                if ((bool)this.matchWholeWordCheckBox.IsChecked) pattern = @"(?<=\W{0,1})" + pattern + @"(?=\W)";

                // Case sensitive
                if (!(bool)this.caseSensitiveCheckBox.IsChecked) pattern = "(?i)" + pattern;

                // Find matches
                this.matches = Regex.Matches(this.textBoxToSearch.Text, pattern);
                this.matchIndex = 0;

                // Word not found?
                if (this.matches.Count == 0)
                {
                    MessageBox.Show("'" + this.findWhatTextBox.Text + "' not found.", "Find");
                    this.matches = null;
                    return;
                }
            }

            // Start at beginning of matches if the last find selected the last match
            if (this.matchIndex == this.matches.Count)
            {
                MessageBoxResult result = MessageBox.Show("Nmore matches found. Start at beginning?", "Find", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No) return;
                
                // Reset
                this.matchIndex = 0;
            }

            // Return match details to client so it can select the text
            Match match = this.matches[this.matchIndex];
            if (TextFound != null)
            {
                //<SnippetTextFoundEventRaiseCODEBEHIND3>
                // Text found
                this.index = match.Index;
                this.length = match.Length;
                OnTextFound();
                //</SnippetTextFoundEventRaiseCODEBEHIND3>
            }
            this.matchIndex++;
            //<SnippetTextFoundEventRaiseCODEBEHIND4>
        }
        //</SnippetTextFoundEventRaiseCODEBEHIND4>

        void textBoxToSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ResetFind();
        }

        void findWhatTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ResetFind();
        }

        void criteria_Click(object sender, RoutedEventArgs e)
        {
            ResetFind();
        }

        void ResetFind()
        {
            this.findNextButton.IsEnabled = true;
            this.matches = null;
        }
        //<SnippetFindDialogCloseCODEBEHIND2>
        void closeButton_Click(object sender, RoutedEventArgs e)
        {
            // Close dialog box
            this.Close();
        }
        //<SnippetTextFoundEventCODEBEHIND2>
        //<SnippetTextFoundEventRaiseCODEBEHIND5>
    }
}
//</SnippetTextFoundEventCODEBEHIND2>
//</SnippetTextFoundEventRaiseCODEBEHIND5>
//</SnippetFindDialogCloseCODEBEHIND2>