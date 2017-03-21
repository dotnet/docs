        <asp:sqldatasource
            id="SqlDataSource1"
            runat="server"
            datasourcemode="DataSet"
            connectionstring="<%$ ConnectionStrings:MyNorthwind%>"
            selectcommand="getordertotal"
            onselected="OnSelectedHandler">
            <selectparameters>
              <asp:querystringparameter name="empId" querystringfield="empId" />
              <asp:parameter name="total" type="Int32" direction="Output" defaultvalue="0" />
              <asp:parameter name="_ret" type="Int32" direction="ReturnValue" defaultvalue="0" />
            </selectparameters>
        </asp:sqldatasource>