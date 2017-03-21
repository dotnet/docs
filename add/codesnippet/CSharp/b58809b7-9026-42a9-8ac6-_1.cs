private void EditValue()
{ 
   int rowtoedit = 1;
   CurrencyManager myCurrencyManager = 
   (CurrencyManager)this.BindingContext[ds.Tables["Suppliers"]];
   myCurrencyManager.Position=rowtoedit;
   DataGridColumnStyle dgc = dataGrid1.TableStyles[0].GridColumnStyles[0];
   dataGrid1.BeginEdit(dgc, rowtoedit);
   // Insert code to edit the value.
   dataGrid1.EndEdit(dgc, rowtoedit, false);
}