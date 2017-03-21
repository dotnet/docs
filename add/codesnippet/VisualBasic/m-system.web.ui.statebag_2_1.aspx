   ' Create a StateBag object to contain the view state 
   ' associated with the custom control named myControl. Use the
   ' StateBag.GetEnumerator method to create an
   ' IDictionaryEnumerator named myDictionaryEnumerator.
   Dim ctlOne As New ctlViewState1()
   Dim myStateBag As New StateBag()
   myStateBag = ctlOne.GetState()
   Dim myDictionaryEnumerator As IDictionaryEnumerator = myStateBag.GetEnumerator()
   