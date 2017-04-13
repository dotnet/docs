'<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Enum MergeSample
   None
   Append
   InsertInSameLocation
   InsertInSameLocationPreservingOrder
   ReplacingItems
   MatchOnly
End Enum

Public Class Form1
   Inherits Form
   Private cmsBase As ContextMenuStrip
   Private cmsItemsToMerge As ContextMenuStrip
   
   
   Public Sub New()
      InitializeComponent()
      
      If components Is Nothing Then
         components = New Container()
      End If
      cmsBase = New ContextMenuStrip(components)
      cmsItemsToMerge = New ContextMenuStrip(components)
      
      ' cmsBase is the base ContextMenuStrip.
      cmsBase.Items.Add("one")
      cmsBase.Items.Add("two")
      cmsBase.Items.Add("three")
      cmsBase.Items.Add("four")
      
      
      ' cmsItemsToMerge contains the items to merge.
      cmsItemsToMerge.Items.Add("one")
      cmsItemsToMerge.Items.Add("two")
      cmsItemsToMerge.Items.Add("three")
      cmsItemsToMerge.Items.Add("four")
      
      '<Snippet2>
      ' Distinguish the merged items by setting the shortcut display string.
      Dim tsmi As ToolStripMenuItem
      For Each tsmi In  cmsItemsToMerge.Items
         tsmi.ShortcutKeyDisplayString = "Merged Item"
      Next tsmi
      '</Snippet2>
      ' Associate the ContextMenuStrip with the form so that it displays when
      ' the user clicks the right mouse button.
      Me.ContextMenuStrip = cmsBase
      
      CreateCombo()
   End Sub
   
   
   #Region "ComboBox switching code."
   
   Private Sub CreateCombo()
      '<Snippet3>
      ' This ComboBox allows the user to switch between the samples.
      Dim sampleSelectorCombo As New ComboBox()
      sampleSelectorCombo.DataSource = [Enum].GetValues(GetType(MergeSample))
      AddHandler sampleSelectorCombo.SelectedIndexChanged, AddressOf comboBox_SelectedIndexChanged
      sampleSelectorCombo.Dock = DockStyle.Top
      Me.Controls.Add(sampleSelectorCombo)
      '</Snippet3>
      Dim textBox As New TextBox()
      textBox.Multiline = True
      textBox.Dock = DockStyle.Left
      textBox.DataBindings.Add("Text", Me, "ScenarioText")
      textBox.ReadOnly = True
      textBox.Width = 150
      Me.Controls.Add(textBox)
      Me.BackColor = ProfessionalColors.MenuStripGradientBegin
      Me.Text = "Right click under selection."
   End Sub
   
   Private Sub comboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
      Dim sampleSelectorCombo As ComboBox = sender 
      If Not (sampleSelectorCombo.SelectedValue Is Nothing) Then
         CurrentSample = CType(sampleSelectorCombo.SelectedValue, MergeSample)
      End If
   End Sub
   
   Private scenarioText1 As String
   
   
   Public Property ScenarioText() As String
      Get
         Return scenarioText1
      End Get
      Set
         scenarioText1 = value
         RaiseEvent ScenarioTextChanged(Me, EventArgs.Empty)
      End Set
   End Property
   
   Public Event ScenarioTextChanged As EventHandler
   
   #End Region
   
   
   Private Sub RebuildItemsToMerge()
      ' This handles cases where the items collection changes for the sample.
      cmsItemsToMerge.SuspendLayout()
      cmsItemsToMerge.Items.Clear()
      cmsItemsToMerge.Items.Add("one")
      cmsItemsToMerge.Items.Add("two")
      cmsItemsToMerge.Items.Add("three")
      cmsItemsToMerge.Items.Add("four")
      ' Distinguish the merged items by setting the shortcut display string.
      Dim tsmi As ToolStripMenuItem
      For Each tsmi In  cmsItemsToMerge.Items
         tsmi.ShortcutKeyDisplayString = "Merged Item"
      Next tsmi
      cmsItemsToMerge.ResumeLayout()
   End Sub
   #Region "Switching current samples."
   Private currentSample1 As MergeSample = MergeSample.None
   '<Snippet4>
   
   Private Property CurrentSample() As MergeSample
      Get
         Return currentSample1
      End Get
      Set
         If currentSample1 <> value Then
            Dim resetRequired As Boolean = False
            
            If currentSample1 = MergeSample.MatchOnly Then
               resetRequired = True
            End If
            currentSample1 = value
            ' Undo previous merge, if any.
            ToolStripManager.RevertMerge(cmsBase, cmsItemsToMerge)
            If resetRequired Then
               RebuildItemsToMerge()
            End If
            
            Select Case currentSample1
               Case MergeSample.None
                     Return
               Case MergeSample.Append
                  ScenarioText = "This sample adds items to the end of the list using MergeAction.Append." + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + "This is the default setting for MergeAction. A typical scenario is adding menu items to the end of the menu when some part of the program is activated."
                  ShowAppendSample()
               Case MergeSample.InsertInSameLocation
                  ScenarioText = "This sample adds items to the middle of the list using MergeAction.Insert." + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + "Notice here how the items are added in reverse order: four, three, two, one. This is because they all have the same merge index." + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + "A typical scenario is adding menu items to the middle or beginning of the menu when some part of the program is activated. "
                  ShowInsertInSameLocationSample()
               Case MergeSample.InsertInSameLocationPreservingOrder
                  ScenarioText = "This sample is the same as InsertInSameLocation, except the items are added in normal order by increasing the MergeIndex of ""two merged items"" to be 3, ""three merged items"" to be 5, and so on." + ControlChars.Cr + ControlChars.Lf + "  You could also add the original items backwards to the source ContextMenuStrip."
                  ShowInsertInSameLocationPreservingOrderSample()
               Case MergeSample.ReplacingItems
                  ScenarioText = "This sample replaces a menu item using MergeAction.Replace. Use this for the MDI scenario where saving does something completely different." + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + "Matching is based on the Text property. If there is no text match, merging reverts to MergeIndex."
                  ShowReplaceSample()
               Case MergeSample.MatchOnly
                  ScenarioText = "This sample adds only the subitems from the child to the target ContextMenuStrip."
                  ShowMatchOnlySample()
            End Select
            
            ' Reapply with the new settings.
            ToolStripManager.Merge(cmsItemsToMerge, cmsBase)
         End If
      End Set
   End Property
   '</Snippet4>
   #End Region
   
   #Region "MergeSample.Append"
   
   ' Example 1 - Add all items to the end of the list.
'        * one
'        * two
'        * three
'        * four
'        * merge-one
'        * merge-two
'        * merge-three
'        * merge-four
'         
   Public Sub ShowAppendSample()
      Dim item As ToolStripItem
      For Each item In  cmsItemsToMerge.Items
         item.MergeAction = MergeAction.Append
      Next item
   End Sub
   #End Region
   
   #Region "MergeSample.InsertInSameLocation"
   
   '  Example 2 - Place all in the same location.
'          * one
'          * two
'          * merge-four
'          * merge-three
'          * merge-two
'          * merge-one
'          * three
'          * four
'           
'          
   '<Snippet5>
   Public Sub ShowInsertInSameLocationSample()
      ' Notice how the items are in backward order.  
      ' This is because "merge-one" gets applied, then a search occurs for the new second position 
      ' for "merge-two", and so on.
      Dim item As ToolStripItem
      For Each item In  cmsItemsToMerge.Items
         item.MergeAction = MergeAction.Insert
         item.MergeIndex = 2
      Next item
   End Sub
   '</Snippet5>
   #End Region
   
   #Region "MergeSample.InsertInSameLocationPreservingOrder"
   
   ' Example 3 - Insert items in the right order.
'        * one
'        * two
'        * merge-one
'        * merge-two
'        * merge-three
'        * merge-four
'        * three
'        * four               
'        
   Public Sub ShowInsertInSameLocationPreservingOrderSample()
      
      ' Undo previous merges, if any.
      ToolStripManager.RevertMerge(cmsBase, cmsItemsToMerge)
      
      ' This is the same as above, but increases the MergeIndex so that
      ' subsequent items are placed afterwards.
      Dim i As Integer = 0
      Dim item As ToolStripItem
      For Each item In  cmsItemsToMerge.Items
         item.MergeAction = MergeAction.Insert
         item.MergeIndex = 2 + i
      Next item
      
      ' Reapply with new settings.
      ToolStripManager.Merge(cmsItemsToMerge, cmsBase)
   End Sub
   #End Region
   
   #Region "MergeSample.ReplacingItems"
   
   ' Example 4 - 
'        * merge-one
'        * merge-two
'        * merge-three
'        * merge-four
'         
   Public Sub ShowReplaceSample()
      
      ' MergeAction.Replace compares Text property values. 
      ' If matching text is not found, Replace reverts to MergeIndex.                    
      Dim item As ToolStripItem
      For Each item In  cmsItemsToMerge.Items
         item.MergeAction = MergeAction.Replace
      Next item
   End Sub
   
   
   #End Region
   
   #Region "MergeSample.MatchOnly"
   
   ' Example 5 - Match to add subitems to a menu item.
'         * Add items to the flyout menus for the original collection.
'         * one -> subitem from "one merged item"
'         * two -> subitem from "two merged items"
'         * three -> subitem from "three merged items"
'         * four -> subitem from "four merged items"
'         
   Public Sub ShowMatchOnlySample()
      
      Dim item As ToolStripMenuItem
      For Each item In  cmsItemsToMerge.Items
         item.MergeAction = MergeAction.MatchOnly
         item.DropDownItems.Add(("subitem from """ + item.Text + " " + item.ShortcutKeyDisplayString + """"))
      Next item
   End Sub
   
   #End Region
   
   Private components As System.ComponentModel.IContainer = Nothing
   
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso Not (components Is Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub
   
   
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Text = "Form1"
   End Sub
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New Form1())
   End Sub
End Class
'</Snippet1>