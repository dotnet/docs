   // Get 'Validators' of the page to myCollection.
   ValidatorCollection myCollection = Page.Validators;

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