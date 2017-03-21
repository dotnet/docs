   // Get 'Validators' of the page to myCollection.
   ValidatorCollection myCollection1 = Page.Validators;

   // Get 'IsReadOnly' property of 'ValidatorCollection'.
   bool readOnly_bool = myCollection1.IsReadOnly;

   // Get 'IsSynchronized' property of 'ValidatorCollection'.
   bool synchronized_bool = myCollection1.IsSynchronized;

   // Get a synchronized object of the 'ValidatorCollection'.
   ValidatorCollection myCollection2 = (ValidatorCollection)myCollection1.SyncRoot;
   myCollection1.Add(myCollection1[0]);