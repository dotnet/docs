using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SDKSample
{
    //<SnippetPlainView>
    public class PlainView : ViewBase
    {

      public static readonly DependencyProperty
        ItemContainerStyleProperty =
        ItemsControl.ItemContainerStyleProperty.AddOwner(typeof(PlainView));

      public Style ItemContainerStyle
      {
          get { return (Style)GetValue(ItemContainerStyleProperty); }
          set { SetValue(ItemContainerStyleProperty, value); }
      }

      public static readonly DependencyProperty ItemTemplateProperty =
          ItemsControl.ItemTemplateProperty.AddOwner(typeof(PlainView));

      public DataTemplate ItemTemplate
      {
          get { return (DataTemplate)GetValue(ItemTemplateProperty); }
          set { SetValue(ItemTemplateProperty, value); }
      }

      public static readonly DependencyProperty ItemWidthProperty =
          WrapPanel.ItemWidthProperty.AddOwner(typeof(PlainView));

      public double ItemWidth
      {
          get { return (double)GetValue(ItemWidthProperty); }
          set { SetValue(ItemWidthProperty, value); }
      }

      public static readonly DependencyProperty ItemHeightProperty =
          WrapPanel.ItemHeightProperty.AddOwner(typeof(PlainView));

      public double ItemHeight
      {
          get { return (double)GetValue(ItemHeightProperty); }
          set { SetValue(ItemHeightProperty, value); }
      }

      protected override object DefaultStyleKey
      {
          get
          {
            return new ComponentResourceKey(GetType(), "myPlainViewDSK");
          }
      }
    }
//</SnippetPlainView>
    }
