//<snippet00>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

public class Form1 : Form
{
    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    private DataGridView dataGridView1 = new DataGridView();

    public Form1()
    {
        dataGridView1.Dock = DockStyle.Fill;
        Controls.Add(dataGridView1);
        Width *= 2;
        Text = "DataGridView Sizing Scenarios";
    }

    protected override void OnLoad(EventArgs e)
    {
        //<snippet10>
        DataGridViewTextBoxColumn idColumn =
            new DataGridViewTextBoxColumn();
        idColumn.HeaderText = "ID";
        idColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        idColumn.Resizable = DataGridViewTriState.False;
        idColumn.ReadOnly = true;
        idColumn.Width = 20;
        //</snippet10>

        //<snippet20>
        DataGridViewTextBoxColumn titleColumn =
            new DataGridViewTextBoxColumn();
        titleColumn.HeaderText = "Title";
        titleColumn.AutoSizeMode =
            DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        //</snippet20>

        //<snippet30>
        dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        DataGridViewTextBoxColumn subTitleColumn =
            new DataGridViewTextBoxColumn();
        subTitleColumn.HeaderText = "Subtitle";
        subTitleColumn.MinimumWidth = 50;
        subTitleColumn.FillWeight = 100;

        DataGridViewTextBoxColumn summaryColumn =
            new DataGridViewTextBoxColumn();
        summaryColumn.HeaderText = "Summary";
        summaryColumn.MinimumWidth = 50;
        summaryColumn.FillWeight = 200;

        DataGridViewTextBoxColumn contentColumn =
            new DataGridViewTextBoxColumn();
        contentColumn.HeaderText = "Content";
        contentColumn.MinimumWidth = 50;
        contentColumn.FillWeight = 300;
        //</snippet30>

        //<snippet40>
        dataGridView1.Columns.AddRange(new DataGridViewTextBoxColumn[] { 
            idColumn, titleColumn, subTitleColumn, 
            summaryColumn, contentColumn });
        dataGridView1.Rows.Add(new String[] { "1", 
            "A Short Title", "A Longer SubTitle", 
            "A short description of the main point.", 
            "The full contents of the topic, with detailed examples." });
        //</snippet40>

        base.OnLoad(e);
    }
}
//</snippet00>