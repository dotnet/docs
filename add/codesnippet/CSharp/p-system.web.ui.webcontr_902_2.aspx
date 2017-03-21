        <asp:LinqDataSource 
           ContextTypeName="DataClassesDataContext" 
           TableName="Products" 
           GroupBy="CategoryID" 
           OrderGroupsBy="Average(UnitPrice)"
           Select="new(Key, Average(UnitPrice) As AvePrice)" 
           ID="LinqDataSource1" 
           runat="server" >
        </asp:LinqDataSource>