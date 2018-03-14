//<Snippet2>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

public class Utility
{
    // The following code causes an error when called by a client assembly.
    public List<Range> GetRange1() {
        //</Snippet2>
        return null;
        //<Snippet3>
    }

    // The following code is valid for calls from a client assembly.
    public IList<Range> GetRange2() {
        //</Snippet3>
        return null;
        //<Snippet4>
    }
}
//</Snippet4>

