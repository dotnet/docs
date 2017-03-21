    public MyPropertyEnum MyProperty {
        set {
           // Checks to see if the value passed is valid.
           if (!TypeDescriptor.GetConverter(typeof(MyPropertyEnum)).IsValid(value)) {
              throw new ArgumentException();
           }
           // The value is valid. Insert code to set the property.
        }
     }