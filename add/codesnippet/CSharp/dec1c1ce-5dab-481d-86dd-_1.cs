 private void GetManagerEnumerator(){
    IEnumerator myEnumerator;
    myEnumerator = ((IEnumerable)this.BindingContext).GetEnumerator();
    ForEachEnumerator();
 }
 
 private void ForEachEnumerator(){
    foreach( IEnumerator myEnumerator in this.BindingContext){
       Console.WriteLine(myEnumerator.ToString());
    }
 } 