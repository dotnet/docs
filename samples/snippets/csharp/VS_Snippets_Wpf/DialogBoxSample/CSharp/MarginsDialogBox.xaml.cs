//<SnippetMarginsDialogBoxMainBitsCODEBEHIND1>
//<SnippetMarginsDialogBoxValidationCODEBEHIND1>
//<SnippetMarginsDialogBoxOKResultSetCODEBEHIND1>
//<SnippetMarginsDialogBoxCancelResultSetCODEBEHIND1>
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SDKSample
{
    public partial class MarginsDialogBox : Window
    {
        //</SnippetMarginsDialogBoxValidationCODEBEHIND1>
        //</SnippetMarginsDialogBoxOKResultSetCODEBEHIND1>
        //</SnippetMarginsDialogBoxCancelResultSetCODEBEHIND1>
        public MarginsDialogBox()
        {
            InitializeComponent();
        }
        //</SnippetMarginsDialogBoxMainBitsCODEBEHIND1>
        public Thickness DocumentMargin
        {
            get { return (Thickness)this.DataContext; }
            set { this.DataContext = value; }
        }

        //<SnippetMarginsDialogBoxCancelResultSetCODEBEHIND2>
        void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Dialog box canceled
            this.DialogResult = false;
        }
        //</SnippetMarginsDialogBoxCancelResultSetCODEBEHIND2>

        //<SnippetMarginsDialogBoxOKResultSetCODEBEHIND2>
        //<SnippetMarginsDialogBoxValidationCODEBEHIND2>
        void okButton_Click(object sender, RoutedEventArgs e)
        {
            //</SnippetMarginsDialogBoxOKResultSetCODEBEHIND2>
            // Don't accept the dialog box if there is invalid data
            if (!IsValid(this)) return;
            //</SnippetMarginsDialogBoxValidationCODEBEHIND2>

            //<SnippetMarginsDialogBoxOKResultSetCODEBEHIND3>
            // Dialog box accepted
            this.DialogResult = true;
            //<SnippetMarginsDialogBoxValidationCODEBEHIND3>
        }
        //</SnippetMarginsDialogBoxOKResultSetCODEBEHIND3>

        // Validate all dependency objects in a window
        bool IsValid(DependencyObject node)
        {
            // Check if dependency object was passed
            if (node != null)
            {
                // Check if dependency object is valid.
                // NOTE: Validation.GetHasError works for controls that have validation rules attached 
                bool isValid = !Validation.GetHasError(node);
                if (!isValid)
                {
                    // If the dependency object is invalid, and it can receive the focus,
                    // set the focus
                    if (node is IInputElement) Keyboard.Focus((IInputElement)node);
                    return false;
                }
            }

            // If this dependency object is valid, check all child dependency objects
            foreach (object subnode in LogicalTreeHelper.GetChildren(node))
            {
                if (subnode is DependencyObject)
                {   
                    // If a child dependency object is invalid, return false immediately,
                    // otherwise keep checking
                    if (IsValid((DependencyObject)subnode) == false) return false;
                }
            }

            // All dependency objects are valid
            return true;
        }
        //<SnippetMarginsDialogBoxMainBitsCODEBEHIND2>
        //<SnippetMarginsDialogBoxOKResultSetCODEBEHIND4>
        //<SnippetMarginsDialogBoxCancelResultSetCODEBEHIND3>
    }
}
//</SnippetMarginsDialogBoxMainBitsCODEBEHIND2>
//</SnippetMarginsDialogBoxValidationCODEBEHIND3>
//</SnippetMarginsDialogBoxOKResultSetCODEBEHIND4>
//</SnippetMarginsDialogBoxCancelResultSetCODEBEHIND3>