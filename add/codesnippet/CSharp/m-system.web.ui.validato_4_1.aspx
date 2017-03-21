   // Get 'Validators' of the page to myCollection.
   ValidatorCollection myCollection = Page.Validators ;
   // Object Array.
   Object[] myObjArray = new Object[5] { 0, 0, 0, 0, 0 };
   // Copy the 'Collection' to 'Array'. 
   myCollection.CopyTo(myObjArray,0); 
   // Print the values in the Array.
   string myStr = " ";         
   for(int i = 0; i<myCollection.Count; i++)
   {
      myStr += myObjArray[i].ToString();
      myStr += " ";
   }
   msgLabel.Text = myStr;