public void MoveMyForm()
 {
    // Create a Rectangle object that will be used as the bound of the form.
    Rectangle tempRect = new Rectangle(50,50,100,100);
    //  Set the bounds of the form using the Rectangle object.
    this.DesktopBounds = tempRect;
 }
   