using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


public class Form1 : System.Windows.Forms.Form
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public Form1()
    {
        //
        // Required for Windows Form Designer support
        //
        InitializeComponent();

        //
        // TODO: Add any constructor code after InitializeComponent call
        //
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.Size = new System.Drawing.Size(300, 300);
        this.Text = "ChangeColumnAlignment";
    }
    #endregion

    #region "DataGridViewContentAlignment"
    System.Windows.Forms.DataGridView songsDataGridView = new DataGridView();

    // The below example shows how to change the alignment of columns of data.  The example requires a form with 
    // a DataGridView named songsDataGridView that is populated with some data.
    //<snippet1>
    private void ChangeColumnAlignment()
    {
        songsDataGridView.Columns["Title"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        songsDataGridView.Columns["Title"].Name = DataGridViewContentAlignment.BottomCenter.ToString();

        songsDataGridView.Columns["Artist"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
        songsDataGridView.Columns["Artist"].Name = DataGridViewContentAlignment.BottomLeft.ToString();

        songsDataGridView.Columns["Album"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
        songsDataGridView.Columns["Album"].Name = DataGridViewContentAlignment.BottomRight.ToString();

        songsDataGridView.Columns["Release Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        songsDataGridView.Columns["Release Date"].Name = DataGridViewContentAlignment.MiddleCenter.ToString();

        songsDataGridView.Columns["Track"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        songsDataGridView.Columns["Track"].Name = DataGridViewContentAlignment.MiddleLeft.ToString();
    }
    //</snippet1>

    #endregion

    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }
}
