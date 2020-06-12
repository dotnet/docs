using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

public class Program
{
    static void Main(string[] args)
    {
    //<Snippet1>
    // The following code causes an error if ISampleInterface is an embedded interop type.
    ISampleInterface<SampleType> sample;
    //</Snippet1>
    }
}

interface ISampleInterface<T> { }

public class SampleType { }

//<Snippet5>
public class Client
{
    public void Main()
    {
        Utility util = new Utility();

        // The following code causes an error.
        List<Range> rangeList1 = util.GetRange1();

        // The following code is valid.
        List<Range> rangeList2 = (List<Range>)util.GetRange2();
    }
}
//</Snippet5>
