            // After the introduction of dynamic, the access to the Value property and
            // the conversion to Excel.Range are handled by the run-time COM binder.
            excelApp.Cells[1, 1].Value = "Name";
            Excel.Range range2010 = excelApp.Cells[1, 1];