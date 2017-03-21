      ' Get 'Validators' of the page to myCollection.
      Dim myCollection1 As ValidatorCollection = Page.Validators
      ' Get 'IsReadOnly' property of 'ValidatorCollection'.
      Dim readOnly_bool As Boolean = myCollection1.IsReadOnly

      ' Get 'IsSynchronized' property of 'ValidatorCollection'.
      Dim synchronized_bool As Boolean = myCollection1.IsSynchronized

      ' Get a synchronized object of the 'ValidatorCollection'.
      Dim myCollection2 As ValidatorCollection = CType(myCollection1.SyncRoot, ValidatorCollection)
      myCollection1.Add(myCollection1(0))