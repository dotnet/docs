
private bool myVal=false;

[DefaultValue(false)]
 public bool MyProperty {
    get {
       return myVal;
    }
    set {
       myVal=value;
    }
 }