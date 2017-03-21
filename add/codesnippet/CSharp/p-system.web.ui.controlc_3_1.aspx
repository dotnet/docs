    // Create a method that enuberates through a 
    // button//s ControlCollection in a thread-safe manner.  
    public void ListControlCollection(object sender, EventArgs e)
    {
       IEnumerator myEnumerator = myButton.Controls.GetEnumerator();

       // Check the IsSynchronized property. If False,
       // use the SyncRoot method to get an object that 
       // allows the enumeration of all controls to be 
       // thread safe.
       if (myButton.Controls.IsSynchronized == false)
       {
           lock (myButton.Controls.SyncRoot)
           {
               while (myEnumerator.MoveNext())
               {

                   Object myObject = myEnumerator.Current;

                   LiteralControl childControl = (LiteralControl)myEnumerator.Current;
                   Response.Write("<b><br /> This is the  text of the child Control  </b>: " +
                                  childControl.Text);
               }
               msgReadOnly.Text = myButton.Controls.IsReadOnly.ToString();
           }
       }       
    }