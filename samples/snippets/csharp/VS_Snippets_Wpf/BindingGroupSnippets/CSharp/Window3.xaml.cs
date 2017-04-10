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
using System.Windows.Shapes;

namespace BindingGroupSnippets
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        //<SnippetUpdateSourcesClick>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sp1.BindingGroup.UpdateSources();
        }
        //</SnippetUpdateSourcesClick>

        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());

            }
        }
    }

    //<SnippetBindingGroupNameValidationRule>
    public class Type1
    {
        public string PropertyA { get; set; }

        public Type1()
        {
            PropertyA = "Default Value";
        }
    }

    public class Type2
    {
        public string PropertyB { get; set; }

        public Type2()
        {
        }
    }

    public class BindingGroupValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            BindingGroup bg = value as BindingGroup;

            Type1 object1 = null;
            Type2 object2 = null;

            foreach (object item in bg.Items)
            {
                if (item is Type1)
                {
                    object1 = item as Type1;
                }

                if (item is Type2)
                {
                    object2 = item as Type2;
                }
            }

            if (object1 == null || object2 == null)
            {
                return new ValidationResult(false, "BindingGroup did not find source object.");
            }

            string string1 = bg.GetValue(object1, "PropertyA") as string;
            string string2 = bg.GetValue(object2, "PropertyB") as string;

            if (string1 != string2)
            {
                return new ValidationResult(false, "The two strings must be identical.");
            }

            return ValidationResult.ValidResult;

        }

    }
    //</SnippetBindingGroupNameValidationRule>

    //<SnippetValueIsNotNull>
    public class ValueIsNotNull : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string str = value as string;

            if (!string.IsNullOrEmpty(str))
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "Value must not be null");
            }
        }
    }
    //</SnippetValueIsNotNull>

}
