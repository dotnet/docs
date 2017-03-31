// System.Windows.Forms.DataGridColumnStyle.ResetHeaderText

/*
   The following example demonstrates 'ResetHeaderText' method of 'DataGridColumnStyle' class.
   A 'DataGrid' and two Buttons are added to a form. An instance of 'DataGridColumnStyle' 
   is mapped to column of 'DataGrid'.On clicking the set button,the Header Text is set. The 
   reset button resets the HeaderText to its default value.
 */
     using System;
     using System.Drawing;
     using System.Windows.Forms;
     using System.Data;
     public class DataGridColumnStyle_Header : Form
     {
         private DataGrid myDataGrid;
         private Button resetButton;
         private Button setButton;
         DataGridTableStyle myDataGridTableStyle = new DataGridTableStyle();
         DataGridColumnStyle myDataGridColumnStyle  = new DataGridTextBoxColumn();

         private void InitializeComponent()
         {
            setButton = new Button();
            resetButton = new Button();
            myDataGrid = new DataGrid();
            setButton.Location = new Point(32, 208);
            setButton.Size = new Size(120, 23);
            setButton.Text = "Set Header Text";
            setButton.Click += new EventHandler(SetHeaderText);
            resetButton.Location = new Point(152, 208);
            resetButton.Size = new Size(120, 23);
            resetButton.Text = "Reset Header Text";
            resetButton.Click += new EventHandler(ResetHeaderText);
            // Grid Initialisation.
            myDataGrid.DataMember = "";
            myDataGrid.Location = new Point(56, 32);
            myDataGrid.Name = "myDataGrid";
            myDataGrid.CaptionText="DataGrid";
            myDataGrid.Size = new Size(120, 130);
            myDataGrid.TabIndex = 0;
            ClientSize = new Size(292, 273);
            Controls.AddRange(new Control[] {resetButton,
                                             myDataGrid,
                                             setButton});
            Name = "DataGridColumnStyle_Width";
            Text = "Change Header Text";
            Load += new System.EventHandler(DataGridColumnStyle_Reset_Header);
         }
            static void Main() 
            {
               Application.Run(new DataGridColumnStyle_Header());
            }
            public DataGridColumnStyle_Header()
            {
               InitializeComponent();
               CreateDataSet();
            }
            private void CreateDataSet()
            {
               DataSet myDataSet = new DataSet("myDataSet");
               DataTable myEmpTable = new DataTable("Employee");
               DataColumn myEmpID = new DataColumn("EmpID", typeof(int));
               myEmpTable.Columns.Add(myEmpID);
               myDataSet.Tables.Add(myEmpTable);
               DataRow newRow1;
               for(int i = 1; i < 6; i++)
               {
                  newRow1 = myEmpTable.NewRow();
                  newRow1["EmpID"] = i;
                  myEmpTable.Rows.Add(newRow1);
               }    
               myDataGrid.SetDataBinding(myDataSet, "Employee");
            }
            private void DataGridColumnStyle_Reset_Header(object sender, System.EventArgs e)
            {
               myDataGridTableStyle.MappingName = "Employee";
               myDataGridColumnStyle.MappingName = "EmpID";
               myDataGridColumnStyle.Width = 50;
               myDataGridTableStyle.GridColumnStyles.Add(myDataGridColumnStyle);
               myDataGrid.TableStyles.Add(myDataGridTableStyle);
            }
// <Snippet1>
            private void SetHeaderText(object sender, System.EventArgs e)
            {
               // Set the HeaderText property.
               myDataGridColumnStyle.HeaderText = "Emp ID";
               myDataGrid.Invalidate();
            } 
            private void ResetHeaderText(object sender, System.EventArgs e)
            {
               // Reset the HeaderText property to its default value.
               myDataGridColumnStyle.ResetHeaderText();
               myDataGrid.Invalidate();
               }
// </Snippet1>
         }

