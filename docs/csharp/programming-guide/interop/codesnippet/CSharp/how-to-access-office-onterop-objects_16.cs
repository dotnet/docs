            // The AutoFormat method has seven optional value parameters. The
            // following call specifies a value for the first parameter, and uses 
            // the default values for the other six. 

            // Call to AutoFormat in Visual C# 2008. This code is not part of the
            // current solution.
            excelApp.get_Range("A1", "B4").AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatTable3, 
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                Type.Missing);