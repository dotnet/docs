 private void CopyToArray(){
    // Declare the array.
    object [] myArray = new object [100];
    ((ICollection)this.BindingContext).CopyTo(myArray, 0);
 }       