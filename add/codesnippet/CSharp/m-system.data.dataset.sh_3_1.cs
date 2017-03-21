public  class DerivedDataSet:System.Data.DataSet 
{
    public void ResetDataSetRelations()
    {
        // Check the ShouldSerializeRelations methods 
        // before invoking Reset.
        if(!this.ShouldSerializeRelations())
        {
            this.Reset();
        }
    }
}