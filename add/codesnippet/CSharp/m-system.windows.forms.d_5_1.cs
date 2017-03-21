        private void NavToGrid(System.Windows.Forms.DataGrid dataGrid)
        {
            // Presumes a relationship named OrderDetails exists.
            dataGrid.NavigateTo(2, "OrderDetails");
        }