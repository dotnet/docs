using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public abstract class Coll1: EventDescriptorCollection {

    public Coll1() : base(null) {
    }

    
    protected void Method() {
        // <Snippet1>
        this.InternalSort(new string[]{"D", "B"});
        // </Snippet1>
    }
}
