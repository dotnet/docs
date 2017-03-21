//<SnippetFavoritesCODEBEHIND>
using System.Windows; // Window
using System.Windows.Input; // CanExecuteRoutedEventArgs, ExecutedRoutedEventArgs

namespace SDKSample
{
    public partial class Favorites : Window
    {
        public Favorites()
        {
            InitializeComponent();
        }

        void navigationCommandFavorites_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Can always handle favorites
            e.CanExecute = true;
        }

        void navigationCommandFavorites_Executed(object target, ExecutedRoutedEventArgs e)
        {
            // Implement custom Favorites handling code
        }
    }
}
//</SnippetFavoritesCODEBEHIND>