using System;

namespace CS
{
    class Class1
    {
        //---------------------------------------------------------------------
        void OtherSnips1()
        {

            //---------------------------------------------
            System.Data.SqlClient.SqlDataAdapter SqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.DataSet Dataset1 = new System.Data.DataSet();
            Dataset1.Tables.Add(new System.Data.DataTable("Table1"));
            
            //<Snippet26>
            try
            {
                SqlDataAdapter1.Update(Dataset1.Tables["Table1"]);
            }
            catch (Exception e)
            {
                // Error during Update, add code to locate error, reconcile 
                // and try to update again.
            }
            //</Snippet26>


            //---------------------------------------------
            NorthwindDataSet northwindDataSet = new NorthwindDataSet();
        
            //<Snippet12>
            string xmlData = northwindDataSet.GetXml();
            //</Snippet12>

            //<Snippet13>
            string filePath = "ENTER A VALID FILEPATH";
            northwindDataSet.WriteXml(filePath);
            //</Snippet13>


            //---------------------------------------------
            //<Snippet15>
            NorthwindDataSetTableAdapters.RegionTableAdapter regionTableAdapter = 
                new NorthwindDataSetTableAdapters.RegionTableAdapter();

            regionTableAdapter.Insert(5, "NorthWestern");
            //</Snippet15>


            //---------------------------------------------
            //<Snippet16>
            System.Data.SqlClient.SqlConnection sqlConnection1 = 
                new System.Data.SqlClient.SqlConnection("YOUR CONNECTION STRING");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT Region (RegionID, RegionDescription) VALUES (5, 'NorthWestern')";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            //</Snippet16>
        }


        //---------------------------------------------------------------------
        void OtherSnips2()
        {
            //---------------------------------------------
            //<Snippet18>
            NorthwindDataSetTableAdapters.RegionTableAdapter regionTableAdapter = 
                new NorthwindDataSetTableAdapters.RegionTableAdapter();

            regionTableAdapter.Update(1, "East", 1, "Eastern");
            //</Snippet18>


            //---------------------------------------------
            //<Snippet19>
            System.Data.SqlClient.SqlConnection sqlConnection1 = 
                new System.Data.SqlClient.SqlConnection("YOUR CONNECTION STRING");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Region SET [RegionDescription] = @RegionDescription WHERE [RegionID] = @RegionID";
            cmd.Parameters.AddWithValue("@RegionDescription", "East");
            cmd.Parameters.AddWithValue("@RegionID", "1");
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            //</Snippet19>
        }


        //---------------------------------------------------------------------
        void OtherSnips3()
        {
            //---------------------------------------------
            //<Snippet21>
            NorthwindDataSetTableAdapters.RegionTableAdapter regionTableAdapter = 
                new NorthwindDataSetTableAdapters.RegionTableAdapter();

            regionTableAdapter.Delete(5, "NorthWestern");
            //</Snippet21>


            //---------------------------------------------
            //<Snippet22>
            System.Data.SqlClient.SqlConnection sqlConnection1 = 
                new System.Data.SqlClient.SqlConnection("YOUR CONNECTION STRING ");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE Region WHERE RegionID = 5 AND RegionDescription = 'NorthWestern'";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            //</Snippet22>
        }


        //---------------------------------------------------------------------
        NorthwindDataSet dsNorthwind1 = new NorthwindDataSet();
        System.Data.SqlClient.SqlDataAdapter daOrders = new System.Data.SqlClient.SqlDataAdapter();
        System.Data.SqlClient.SqlDataAdapter daCustomers = new System.Data.SqlClient.SqlDataAdapter();
        
        //<Snippet28>
        void UpdateDB()
        {
            System.Data.DataTable DeletedChildRecords = 
                dsNorthwind1.Orders.GetChanges(System.Data.DataRowState.Deleted);

            System.Data.DataTable NewChildRecords = 
                dsNorthwind1.Orders.GetChanges(System.Data.DataRowState.Added);

            System.Data.DataTable ModifiedChildRecords = 
                dsNorthwind1.Orders.GetChanges(System.Data.DataRowState.Modified);

            try
            {
                if (DeletedChildRecords != null)
                {
                    daOrders.Update(DeletedChildRecords);
                }
                if (NewChildRecords != null)
                {
                    daOrders.Update(NewChildRecords);
                }
                if (ModifiedChildRecords != null)
                {
                    daOrders.Update(ModifiedChildRecords);
                }

                dsNorthwind1.AcceptChanges();
            }

            catch (Exception ex)
            {
                // Update error, resolve and try again
            }

            finally
            {
                if (DeletedChildRecords != null)
                {
                    DeletedChildRecords.Dispose();
                }
                if (NewChildRecords != null)
                {
                    NewChildRecords.Dispose();
                }
                if (ModifiedChildRecords != null)
                {
                    ModifiedChildRecords.Dispose();
                }
            }
        }
        //</Snippet28>


    }
}
