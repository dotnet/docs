 private void LayeredWindows() {
    // Gets the version of the layered windows feature.
    Version myVersion =
        OSFeature.Feature.GetVersionPresent(OSFeature.LayeredWindows);
 
    // Prints whether the feature is available.
    if (myVersion != null)
       textBox1.Text = "Layered windows feature is installed.\n";
    else
       textBox1.Text = "Layered windows feature is not installed.\n";
 }
 