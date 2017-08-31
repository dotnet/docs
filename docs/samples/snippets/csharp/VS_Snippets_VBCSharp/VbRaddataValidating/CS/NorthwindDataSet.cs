namespace CS
{
    partial class NorthwindDataSet
    {
        partial class Order_DetailsDataTable
        {
            //<Snippet2>

            public override void EndInit()
            {
                base.EndInit();
                ColumnChanging += SampleColumnChangingEvent;

            }


            private void SampleColumnChangingEvent(object sender, System.Data.DataColumnChangeEventArgs e)
            {
                if (e.Column.ColumnName == QuantityColumn.ColumnName)
                {
                    if ((short)e.ProposedValue <= 0)
                    {
                        e.Row.SetColumnError("Quantity", "Quantity must be greater than 0");
                    }
                    else
                    {
                        e.Row.SetColumnError("Quantity", "");
                    }
                }
            }

 //</Snippet2>


           
            
            //<Snippet4>

            //public override void EndInit()
            //{
            //    base.EndInit();
            //    Order_DetailsRowChanging += TestRowChangeEvent;

            //}


            //public void TestRowChangeEvent(object sender, Order_DetailsRowChangeEvent e)
            //{
            //    if ((short)e.Row.Quantity <= 0)
            //    {
            //        e.Row.SetColumnError("Quantity", "Quantity must be greater than 0");
            //    }
            //    else
            //    {
            //        e.Row.SetColumnError("Quantity", "");
            //    }
            //}
             //</Snippet4>
        }
    }
}
