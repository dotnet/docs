      // Create a StateBag object to contain the view state 
      // associated with the custom control named myControl. Use the
      // StateBag.GetEnumerator method to create an
      // IDictionaryEnumerator named myDictionaryEnumerator.
      ctlViewState1 ctlOne = new ctlViewState1();
      StateBag myStateBag = new StateBag(); 
      myStateBag = ctlOne.GetState();
      IDictionaryEnumerator myDictionaryEnumerator = myStateBag.GetEnumerator();