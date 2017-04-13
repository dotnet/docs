//<SnippetMyCustomContentStateCODE>
using System;
using System.Windows.Controls;
using System.Windows.Navigation;
[Serializable]
public class MyCustomContentState : CustomContentState
{
    string dateCreated;
    TextBlock dateTextBlock;

    public MyCustomContentState(string dateCreated, TextBlock dateTextBlock)
    {
        this.dateCreated = dateCreated;
        this.dateTextBlock = dateTextBlock;
    }

    public override string JournalEntryName
    {
        get
        {
            return "Journal Entry " + this.dateCreated;
        }
    }

    public override void Replay(NavigationService navigationService, NavigationMode mode)
    {
        this.dateTextBlock.Text = this.dateCreated;
    }
}
//</SnippetMyCustomContentStateCODE>