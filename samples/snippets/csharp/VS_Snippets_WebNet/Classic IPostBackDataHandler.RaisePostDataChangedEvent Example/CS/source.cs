using System;

public class Sample {
    
// <Snippet1>
 public virtual void RaisePostDataChangedEvent() {
     OnTextChanged(EventArgs.Empty);
 }

// </Snippet1>

    public void OnTextChanged(EventArgs e) {

    }
}
