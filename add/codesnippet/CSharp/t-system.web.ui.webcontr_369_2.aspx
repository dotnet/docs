    <asp:LinqDataSource 
      ContextTypeName="ExampleDataContext" 
      TableName="Products" 
      GroupBy="new(ProductCategory, Color)"
      Select="new(Key,
              It As Products,
              Max(ListPrice) As MaxListPrice, 
              Min(ListPrice) As MinListPrice)"
      ID="LinqDataSource1" 
      runat="server">
    </asp:LinqDataSource>