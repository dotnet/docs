 Private Sub GetManagerEnumerator()
    Dim myEnumerator As IEnumerator
    myEnumerator = CType(BindingContext,IEnumerable).GetEnumerator()
    ForEachEnumerator()
 End Sub
 
 Private Sub ForEachEnumerator()
    Dim myEnumerator As IEnumerator
    For Each myEnumerator In CType(BindingContext,IEnumerable)
       Console.WriteLine(myEnumerator.Current.ToString())
    Next
 End Sub 