        // This event handler updates the ListView control when the
        // PrimeNumberCalculator raises the CalculatePrimeCompleted
        // event. The ListView item is updated with the appropriate
        // outcome of the calculation: Canceled, Error, or result.
        private void primeNumberCalculator1_CalculatePrimeCompleted(
            object sender, 
            CalculatePrimeCompletedEventArgs e)
        {
            Guid taskId = (Guid)e.UserState;

            if (e.Cancelled)
            {   
                string result = "Canceled";

                ListViewItem lvi = UpdateListViewItem(taskId, result);

                if (lvi != null)
                {
                    lvi.BackColor = Color.Pink;
                    lvi.Tag = null;
                }
            }
            else if (e.Error != null)
            {
                string result = "Error";

                ListViewItem lvi = UpdateListViewItem(taskId, result);

                if (lvi != null)
                {
                    lvi.BackColor = Color.Red;
                    lvi.ForeColor = Color.White;
                    lvi.Tag = null;
                }
            }
            else
            {   
                bool result = e.IsPrime;

                ListViewItem lvi = UpdateListViewItem(
                    taskId, 
                    result, 
                    e.FirstDivisor);

                if (lvi != null)
                {
                    lvi.BackColor = Color.LightGray;
                    lvi.Tag = null;
                }
            }
        }