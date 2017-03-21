        private void CancelEdit()
        {
            // Gets the CurrencyManager which is returned when the 
            // data source is a DataView.
            BindingManagerBase myMgr = 
                (CurrencyManager) BindingContext[myDataView]; 

            // Gets the current row and changes a value. Then cancels the 
            // edit and thereby discards the changes.
            DataRowView tempRowView = (DataRowView) myMgr.Current;
            Console.WriteLine("Original: {0}", tempRowView["myCol"]);
            tempRowView["myCol"] = "These changes will be discarded";
            Console.WriteLine("Edit: {0}", tempRowView["myCol"]);
            myMgr.CancelCurrentEdit();
            Console.WriteLine("After CanceCurrentlEdit: {0}", 
                tempRowView["myCol"]);
        }

        private void EndEdit()
        {
            // Gets the CurrencyManager which is returned when the 
            // data source is a DataView.
            BindingManagerBase myMgr = 
                (CurrencyManager) BindingContext[myDataView];

            // Gets the current row and changes a value. Then ends the 
            // edit and thereby keeps the changes.
            DataRowView tempRowView = (DataRowView) myMgr.Current;
            Console.WriteLine("Original: {0}", tempRowView["myCol"]);
            tempRowView["myCol"] = "These changes will be kept";
            Console.WriteLine("Edit: {0}", tempRowView["myCol"]);
            myMgr.EndCurrentEdit();
            Console.WriteLine("After EndCurrentEdit: {0}", 
                tempRowView["myCol"]);
        }
