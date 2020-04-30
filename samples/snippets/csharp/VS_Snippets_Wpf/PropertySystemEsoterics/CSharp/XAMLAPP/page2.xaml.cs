
using System;
using System.Windows;
using System.Collections;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Text;
using System.Windows.Media.Animation;

namespace SDKSample {
    public partial class XAMLAPPPage2{
      void OnDPSelectionChanged(object sender, SelectionChangedEventArgs e)
      {
        ListBoxItem selected = (ListBoxItem) e.AddedItems[0]; // we won't handle multiselect
        PropertyMetadata pm;
        DependencyProperty dp = null;
        switch (selected.Content.ToString())
        {
          case ("ToggleButton.IsChecked"):
            dp = ToggleButton.IsCheckedProperty;
            break;
          case("Control.Background"):
            dp = Control.BackgroundProperty;
            break;
          case ("Storyboard.TargetName"):
            dp = Storyboard.TargetNameProperty;
            break;
          case ("FrameworkElement.DataContext"):
            dp = FrameworkElement.DataContextProperty;
            break;
          case ("FrameworkElement.Margin"):
            dp = FrameworkElement.MarginProperty;
            break;
          case ("ToolBar.Orientation"):
            dp = ToolBar.OrientationProperty;
            break;
          case ("UIElement.Visibility"):
            dp = UIElement.VisibilityProperty;
            break;
        }
        //<SnippetDPProps>
        //<SnippetDPGetMetadataSingle>
        pm = dp.GetMetadata(dp.OwnerType);
        //</SnippetDPGetMetadataSingle>
        MetadataClass.Text = pm.GetType().Name;
        TypeofPropertyValue.Text = dp.PropertyType.Name;
        DefaultPropertyValue.Text = (pm.DefaultValue!=null) ? pm.DefaultValue.ToString() : "null";
        HasCoerceValue.Text = (pm.CoerceValueCallback == null) ? "No" : pm.CoerceValueCallback.Method.Name;
        HasPropertyChanged.Text = (pm.PropertyChangedCallback == null) ? "No" : pm.PropertyChangedCallback.Method.Name;
        ReadOnly.Text = (dp.ReadOnly) ? "Yes" : "No";
        //</SnippetDPProps>
        //<SnippetFPMProperties>
        FrameworkPropertyMetadata fpm = pm as FrameworkPropertyMetadata;
        if (fpm!=null) {
            AffectsArrange.Text = (fpm.AffectsArrange) ? "Yes" : "No";
            AffectsMeasure.Text = (fpm.AffectsMeasure) ? "Yes" : "No";
            AffectsRender.Text = (fpm.AffectsRender) ? "Yes" : "No";
            Inherits.Text = (fpm.Inherits) ? "Yes" : "No";
            IsDataBindingAllowed.Text = (fpm.IsDataBindingAllowed) ? "Yes" : "No";
            BindsTwoWayByDefault.Text = (fpm.BindsTwoWayByDefault) ? "Yes" : "No";
        }
        //</SnippetFPMProperties>
        else
        {
            AffectsArrange.Text = "N/A";
            AffectsMeasure.Text = "N/A";
            AffectsRender.Text = "N/A";
            Inherits.Text = "N/A";
            IsDataBindingAllowed.Text = "N/A";
            BindsTwoWayByDefault.Text = "N/A";
        }
        //<SnippetDPDefaultValue>
        PropertyMetadata pmDefault = dp.DefaultMetadata;
        //</SnippetDPDefaultValue>
      }
      //<SnippetTrySetValue>
      void TrySetValue(DependencyObject target, DependencyProperty dp, object providedValue) {
        if (dp.IsValidType(providedValue))
        {
          target.SetValue(dp, providedValue);
        }
      }
      //</SnippetTrySetValue>
      //<SnippetTrySetValueWithValidate>
      void TrySetValueWithValidate(DependencyObject target, DependencyProperty dp, object providedValue)
      {
        if (dp.IsValidValue(providedValue))
        {
          target.SetValue(dp, providedValue);
        }
      }
      //</SnippetTrySetValueWithValidate>
  }
}