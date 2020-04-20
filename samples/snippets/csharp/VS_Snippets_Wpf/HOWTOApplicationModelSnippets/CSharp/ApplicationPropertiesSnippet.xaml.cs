using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SDKSample {
  /// <summary>
  /// Interaction logic for ApplicationPropertiesSnippet.xaml
  /// </summary>

  public class CustomType {}

  public partial class ApplicationPropertiesSnippet : Window {

    public ApplicationPropertiesSnippet() {
      InitializeComponent();
    }

    void GetCurrentApplication() {

      //<SnippetGetCurrentApplication>
      // Get a reference to the current Application object
      Application currentApplication = Application.Current;
      //</SnippetGetCurrentApplication>
    }

    void SetApplicationProperties() {
      //<SnippetSetApplicationScopeProperty>
      // Set an application-scope property
      Application.Current.Properties["MyApplicationScopeProperty"] = "myApplicationScopePropertyValue";
      //</SnippetSetApplicationScopeProperty>

      //<SnippetSetApplicationScopePropertyCustomType>
      // Set an application-scope property with a custom type
      CustomType customType = new CustomType();
      Application.Current.Properties["CustomType"] = customType;
      //</SnippetSetApplicationScopePropertyCustomType>
    }

    void GetApplicationProperties() {

      //<SnippetGetApplicationScopeProperty>
      // Get an application-scope property
      // NOTE: Need to convert since Application.Properties is a dictionary of System.Object
      string myApplicationScopeProperty = (string)Application.Current.Properties["MyApplicationScopeProperty"];
      //</SnippetGetApplicationScopeProperty>

      //<SnippetGetApplicationScopePropertyCustomType>
      // Get an application-scope property
      // NOTE: Need to convert since Application.Properties is a dictionary of System.Object
      CustomType customType = (CustomType)Application.Current.Properties["CustomType"];
      //</SnippetGetApplicationScopePropertyCustomType>
    }

    void SetApplicationScopeResources() {
      //<SnippetSetApplicationScopeResourceCODE>
      // Set an application-scope resource
      Application.Current.Resources["ApplicationScopeResource"] = Brushes.White;
      //</SnippetSetApplicationScopeResourceCODE>
    }

    void GetApplicationScopeResources() {
      //<SnippetGetApplicationScopeResourceCODE>
      // Get an application-scope resource
      Brush whiteBrush = (Brush)Application.Current.Resources["ApplicationScopeResource"];
      //</SnippetGetApplicationScopeResourceCODE>
    }
  }
}