using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Controls;

namespace BrowserInteropHelperSnippet {
  public partial class Page1 : Page {

    public Page1() {
      InitializeComponent();
    }

    protected override void OnInitialized(EventArgs e) {
      base.OnInitialized(e);

      //<SnippetIsBrowserHostedCODE>
      // Detect if browser hosted
      if (BrowserInteropHelper.IsBrowserHosted) 
      {
          // Note: can only inspect BrowserInteropHelper.Source property if page is browser-hosted.
          this.dataTextBlock.Text = "Is Browser Hosted: " + BrowserInteropHelper.Source.ToString();
      }
      else 
      {
          this.dataTextBlock.Text = "Is not browser hosted";
      }
      //</SnippetIsBrowserHostedCODE>
    }
  }
}