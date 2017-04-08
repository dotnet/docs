using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MyNameSpace {
   class MyDataGridColumnStyle: DataGridTextBoxColumn {
      CurrencyManager myCurrencyManager;
      DataGrid dataGrid1;
      // <Snippet1>
private void UpdateGridUI() {
   // Get the MyDataGridColumnStyle to update.
   // MyDataGridColumnStyle is a class derived from DataGridColumnStyle.
   MyDataGridColumnStyle myGridColumn = 
   (MyDataGridColumnStyle)dataGrid1.TableStyles[0].GridColumnStyles["CompanyName"];
   // Call UpdateUI.
   myGridColumn.UpdateUI(myCurrencyManager, 10, "my new value");
}       
        // </Snippet1>

        protected void SetDataGrid(DataGrid dataGrid2, CurrencyManager curMan2) {
            myCurrencyManager = curMan2;
            dataGrid1 = dataGrid2;
        }
        
        protected override void Edit(System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Rectangle bounds, bool readOnly1, string displayText, bool cellIsVisiblen) {

        }

        protected override bool Commit(System.Windows.Forms.CurrencyManager dataSource, int rowNum) {
            return true;
        }

        protected override System.Drawing.Size GetPreferredSize(System.Drawing.Graphics g, object value) {
            return new Size(new Point(1, 2));
        }

        protected override int GetPreferredHeight(System.Drawing.Graphics g, object value) {
            return 1;
        }

        protected override int GetMinimumHeight() {
            return 1;
        }

        protected override void Abort(int rowNum) {
        
        }

        protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, bool b) {
        }
        
        protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum) {

        }
    }
}

