﻿//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamedAndOptionalSnippets
{
    class NamedAndOptCOM
    {
        static void Main()
        {
            TestCOM();
        }

        static void TestCOM()
        {
            //<Snippet13>
            // The following code shows the same call to AutoFormat in C# 4.0. Only
            // the argument for which you want to provide a specific value is listed.
            excelApp.Range["A1", "B4"].AutoFormat( Format: myFormat );
            //</Snippet13>
        }
    }
}
