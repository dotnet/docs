//<Snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

public enum MergeSample
{
    None,
    Append,
    InsertInSameLocation,
    InsertInSameLocationPreservingOrder,
    ReplacingItems,
    MatchOnly
}
public class Form1 : Form
{
    ContextMenuStrip cmsBase;
    ContextMenuStrip cmsItemsToMerge;

    public Form1()
    {
        InitializeComponent();

        if (components == null)
        {
            components = new Container();
        }
        cmsBase = new ContextMenuStrip(components);
        cmsItemsToMerge = new ContextMenuStrip(components);

        // cmsBase is the base ContextMenuStrip.
        cmsBase.Items.Add("one");
        cmsBase.Items.Add("two");
        cmsBase.Items.Add("three");
        cmsBase.Items.Add("four");


        // cmsItemsToMerge contains the items to merge.
        cmsItemsToMerge.Items.Add("one");
        cmsItemsToMerge.Items.Add("two");
        cmsItemsToMerge.Items.Add("three");
        cmsItemsToMerge.Items.Add("four");

        //<Snippet2>
        // Distinguish the merged items by setting the shortcut display string.
        foreach (ToolStripMenuItem tsmi in cmsItemsToMerge.Items)
        {
            tsmi.ShortcutKeyDisplayString = "Merged Item";
        }
        //</Snippet2>
        // Associate the ContextMenuStrip with the form so that it displays when
        // the user clicks the right mouse button.
        this.ContextMenuStrip = cmsBase;

        CreateCombo();

    }


    #region ComboBox switching code.
    private void CreateCombo()
    {
        //<Snippet3>
        // This ComboBox allows the user to switch between the samples.
        ComboBox sampleSelectorCombo = new ComboBox();
        sampleSelectorCombo.DataSource = Enum.GetValues(typeof(MergeSample));
        sampleSelectorCombo.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
        sampleSelectorCombo.Dock = DockStyle.Top;
        this.Controls.Add(sampleSelectorCombo);
        //</Snippet3>

        TextBox textBox = new TextBox();
        textBox.Multiline = true;
        textBox.Dock = DockStyle.Left;
        textBox.DataBindings.Add("Text", this, "ScenarioText");
        textBox.ReadOnly = true;
        textBox.Width = 150;
        this.Controls.Add(textBox);
        this.BackColor = ProfessionalColors.MenuStripGradientBegin;
        this.Text = "Right click under selection.";
    }
    void comboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboBox sampleSelectorCombo = sender as ComboBox;
        if (sampleSelectorCombo.SelectedValue != null)
        {
            CurrentSample = (MergeSample)sampleSelectorCombo.SelectedValue;
        }
    }

    private string scenarioText;

    public string ScenarioText
    {
        get { return scenarioText; }
        set
        {
            scenarioText = value;
            if (ScenarioTextChanged != null)
            {
                ScenarioTextChanged(this, EventArgs.Empty);
            }
        }
    }

    public event EventHandler ScenarioTextChanged;

    #endregion

    private void RebuildItemsToMerge()
    {
        // This handles cases where the items collection changes for the sample.
        cmsItemsToMerge.SuspendLayout();
        cmsItemsToMerge.Items.Clear();
        cmsItemsToMerge.Items.Add("one");
        cmsItemsToMerge.Items.Add("two");
        cmsItemsToMerge.Items.Add("three");
        cmsItemsToMerge.Items.Add("four");
        // Distinguish the merged items by setting the shortcut display string.
        foreach (ToolStripMenuItem tsmi in cmsItemsToMerge.Items)
        {
            tsmi.ShortcutKeyDisplayString = "Merged Item";
        }
        cmsItemsToMerge.ResumeLayout();
    }
    #region Switching current samples.
    private MergeSample currentSample = MergeSample.None;
    //<Snippet4>
    private MergeSample CurrentSample
    {
        get { return currentSample; }
        set
        {
            if (currentSample != value)
            {
                bool resetRequired = false;

                if (currentSample == MergeSample.MatchOnly)
                {
                    resetRequired = true;
                }
                currentSample = value;
                // Undo previous merge, if any.
                ToolStripManager.RevertMerge(cmsBase, cmsItemsToMerge);
                if (resetRequired)
                {
                    RebuildItemsToMerge();
                }

                switch (currentSample)
                {
                    case MergeSample.None:
                        return;
                    case MergeSample.Append:
                        ScenarioText = "This sample adds items to the end of the list using MergeAction.Append.\r\n\r\nThis is the default setting for MergeAction. A typical scenario is adding menu items to the end of the menu when some part of the program is activated.";
                        ShowAppendSample();
                        break;
                    case MergeSample.InsertInSameLocation:
                        ScenarioText = "This sample adds items to the middle of the list using MergeAction.Insert.\r\n\r\nNotice here how the items are added in reverse order: four, three, two, one. This is because they all have the same merge index.\r\n\r\nA typical scenario is adding menu items to the middle or beginning of the menu when some part of the program is activated. ";
                        ShowInsertInSameLocationSample();
                        break;
                    case MergeSample.InsertInSameLocationPreservingOrder:
                        ScenarioText = "This sample is the same as InsertInSameLocation, except the items are added in normal order by increasing the MergeIndex of \"two merged items\" to be 3, \"three merged items\" to be 5, and so on.\r\n  You could also add the original items backwards to the source ContextMenuStrip.";
                        ShowInsertInSameLocationPreservingOrderSample();
                        break;
                    case MergeSample.ReplacingItems:
                        ScenarioText = "This sample replaces a menu item using MergeAction.Replace. Use this for the MDI scenario where saving does something completely different.\r\n\r\nMatching is based on the Text property. If there is no text match, merging reverts to MergeIndex.";
                        ShowReplaceSample();
                        break;
                    case MergeSample.MatchOnly:
                        ScenarioText = "This sample adds only the subitems from the child to the target ContextMenuStrip.";
                        ShowMatchOnlySample();
                        break;

                }
                // Reapply with the new settings.
                ToolStripManager.Merge(cmsItemsToMerge, cmsBase);
            }
        }
    }
    //</Snippet4>
    #endregion

    #region MergeSample.Append
    /* Example 1 - Add all items to the end of the list.
        * one
        * two
        * three
        * four
        * merge-one
        * merge-two
        * merge-three
        * merge-four
         */
    public void ShowAppendSample()
    {
        foreach (ToolStripItem item in cmsItemsToMerge.Items)
        {
            item.MergeAction = MergeAction.Append;
        }
    }
    #endregion

    #region MergeSample.InsertInSameLocation
    /*  Example 2 - Place all in the same location.
          * one
          * two
          * merge-four
          * merge-three
          * merge-two
          * merge-one
          * three
          * four
           
          */
    //<Snippet5>
    public void ShowInsertInSameLocationSample()
    {
        // Notice how the items are in backward order.  
        // This is because "merge-one" gets applied, then a search occurs for the new second position 
        // for "merge-two", and so on.
        foreach (ToolStripItem item in cmsItemsToMerge.Items)
        {
            item.MergeAction = MergeAction.Insert;
            item.MergeIndex = 2;
        }
    }
    //</Snippet5>
    #endregion

    #region MergeSample.InsertInSameLocationPreservingOrder
    /* Example 3 - Insert items in the right order.
        * one
        * two
        * merge-one
        * merge-two
        * merge-three
        * merge-four
        * three
        * four               
        */
    public void ShowInsertInSameLocationPreservingOrderSample()
    {

        // Undo previous merges, if any.
        ToolStripManager.RevertMerge(cmsBase, cmsItemsToMerge);

        // This is the same as above, but increases the MergeIndex so that
        // subsequent items are placed afterwards.
        int i = 0;
        foreach (ToolStripItem item in cmsItemsToMerge.Items)
        {
            item.MergeAction = MergeAction.Insert;
            item.MergeIndex = 2 + i++;
        }

        // Reapply with new settings.
        ToolStripManager.Merge(cmsItemsToMerge, cmsBase);
    }
    #endregion

    #region MergeSample.ReplacingItems
    /* Example 4 - 
        * merge-one
        * merge-two
        * merge-three
        * merge-four
         */
    public void ShowReplaceSample()
    {

        // MergeAction.Replace compares Text property values. 
        // If matching text is not found, Replace reverts to MergeIndex.                    

        foreach (ToolStripItem item in cmsItemsToMerge.Items)
        {
            item.MergeAction = MergeAction.Replace;
        }



    }
    #endregion

    #region MergeSample.MatchOnly
    /* Example 5 - Match to add subitems to a menu item.
         * Add items to the flyout menus for the original collection.
         * one -> subitem from "one merged item"
         * two -> subitem from "two merged items"
         * three -> subitem from "three merged items"
         * four -> subitem from "four merged items"
         */
    public void ShowMatchOnlySample()
    {

        foreach (ToolStripMenuItem item in cmsItemsToMerge.Items)
        {
            item.MergeAction = MergeAction.MatchOnly;
            item.DropDownItems.Add("subitem from \"" + item.Text + " " + item.ShortcutKeyDisplayString + "\"");
        }


    }
    #endregion

    private System.ComponentModel.IContainer components = null;
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Form1";
    }
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}
//</Snippet1>