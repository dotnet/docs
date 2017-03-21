        private void CheckCurrencyManager(CurrencyManager myCurrencyManager) {
            // This code is from a class named MyDataGridColumnStyle derived
            // from DataGridColumnStyle.
            MyDataGridColumnStyle myGridColumn = this;
            try {
                myGridColumn.CheckValidDataSource(myCurrencyManager);
            }
            catch (ArgumentNullException e) {
                Console.WriteLine(e.Message);
            }
            catch (ApplicationException e) {
                Console.WriteLine(e.Message);
            }
        }