   // Get 'Validators' of the page to myCollection.
   ValidatorCollection myCollection = Page.Validators;

   // Print the values of Collection using 'Item' property.
   string myStr = " ";         
   for(int i = 0; i<myCollection.Count; i++)
   {
      myStr += myCollection[i].ToString();
      myStr += " ";
   }
   msgLabel.Text = myStr;        