        <asp:LinqDataSource 
           ContextTypeName="DataClassesDataContext" 
           TableName="Products" 
           GroupBy="new (CategoryID, Discontinued)" 
           OrderGroupsBy="Key.CategoryID"
           Select="new(Key.CategoryID, Key.Discontinued, Average(UnitPrice) As AvePrice)" 
           ID="LinqDataSource1" 
           runat="server" >
        </asp:LinqDataSource>