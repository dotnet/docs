using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 private void LayeredWindows() {
    // Gets the version of the layered windows feature.
    Version myVersion =
        OSFeature.Feature.GetVersionPresent(OSFeature.LayeredWindows);
 
    // Prints whether the feature is available.
    if (OSFeature.Feature.IsPresent(OSFeature.LayeredWindows))
       textBox1.Text = "Layered windows feature is installed.";
    else
       textBox1.Text = "Layered windows feature is not installed.";
 }
 
// </Snippet1>
}
