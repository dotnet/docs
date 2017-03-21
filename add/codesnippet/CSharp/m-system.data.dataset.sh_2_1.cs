public  class DerivedDataSet:System.Data.DataSet 
{
    public void ResetDataSetRelations()
    {
        // Check the ShouldPersistTable method 
        // before invoking Reset.
        if(!this.ShouldSerializeTables())
        {
            this.Reset();
        }
    }
}