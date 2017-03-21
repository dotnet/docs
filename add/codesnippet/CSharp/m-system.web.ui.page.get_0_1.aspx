    // Get 'Validators' of the page to myCollection.
    ValidatorCollection myCollection = Page.GetValidators(null);

    // Get the Enumerator.
    IEnumerator myEnumerator = myCollection.GetEnumerator();
    // Print the values in the ValidatorCollection.
    string myStr = " ";
    while ( myEnumerator.MoveNext() )
    {
        myStr += myEnumerator.Current.ToString();
        myStr += " ";
    }
    messageLabel.Text = myStr;