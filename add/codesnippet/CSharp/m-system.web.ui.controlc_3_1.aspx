         // Create an event handler that uses the 
         // ControlCollection.Contains method to verify
         // the existence of a Radio3 server control in
         // the ControlCollection of the myForm server control.
         // When a user clicks the button associated
         // with this event handler, Radio3 is removed
         // from the collection.
         void RemoveBtn_Click(Object sender, EventArgs e){
             if (myForm.Controls.Contains(Radio3))
             { 
                myForm.Controls.Remove(Radio3);
             }
         }