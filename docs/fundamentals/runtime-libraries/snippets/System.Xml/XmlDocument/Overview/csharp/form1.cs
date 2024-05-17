using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace XMLProcessingApp
{
    public partial class Form1 : Form
    {
        private string _globalTag = "";
        private XMLHelperMethods _xmlHelperMethods;
        private string _ISBNOfSelectedBookNode = "";
        private XmlDocument _doc = null;
        private int _selectionStart;
        private int _selectionLength;
        private XmlNode _currentlySelectedNode = null;
        public Form1()
        {
            InitializeComponent();
            _xmlHelperMethods = new XMLHelperMethods();
        }

        //************************************************************************************
        //
        // Load Xml from file. Keep white spaces and newlines.
        // Then, call a method to populate a tree view control with the elements of the XML.
        //
        //************************************************************************************
        private void loadXML(bool generateXML, bool validateXML, bool generateSchema)
        {
            if (validateXML)
            {
                _doc = _xmlHelperMethods.LoadDocumentWithSchemaValidation(generateXML, generateSchema);
            }
            else
            {
                _doc = _xmlHelperMethods.LoadDocument(generateXML);
            }

            if (_doc == null)
            {
                MessageBox.Show("Unable to load XML file or schema. The XML file or schema validation file does not exist. Consider generating the XML file and/or schema file");
            }
            else
            {
                XmlTextBox.Text = _doc.InnerXml;
                populateTreeView(_doc);
            }
        }

        //************************************************************************************
        //
        // Populate the TreeView control with the elements of the XML file.
        //
        //************************************************************************************
        private void populateTreeView(XmlDocument doc)
        {
            xmlTreeView.Nodes.Clear();
            addTreeNodes(doc.DocumentElement.ChildNodes, xmlTreeView);
            xmlTreeView.ExpandAll();
        }

        //************************************************************************************
        //
        // Helper method for populating the TreeView control with the elements of the XML file.
        //
        //************************************************************************************
        private void addTreeNode_Recursive(XmlNode xmlNode, TreeNode treeNode)
        {
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes)
            {
                xNodeList = xmlNode.ChildNodes;
                foreach (XmlNode node in xmlNode.ChildNodes)
                {
                    if (node.NodeType != XmlNodeType.Whitespace)
                    {
                        TreeNode tempTreeNode = new TreeNode(node.Name);
                        if (node.Attributes != null)
                        {
                            XmlNode tempXMLNode = node.Attributes.GetNamedItem("ISBN");
                            if (tempXMLNode != null)
                            {
                                _globalTag = tempXMLNode.Value;
                            }
                        }
                        tempTreeNode.Tag = _globalTag;
                        treeNode.Nodes.Add(tempTreeNode);
                        addTreeNode_Recursive(node, tempTreeNode);
                    }
                }
            }
            else
            {
                treeNode.Text = xmlNode.OuterXml.Trim();
            }
        }

        private void addTreeNodes(XmlNodeList books, TreeView treeView)
        {

            foreach (XmlNode book in books)
            {
                if (book.NodeType == XmlNodeType.Element)
                {
                    XmlElement bookElement = (XmlElement)book;
                    TreeNode tempTreeNode = new TreeNode(bookElement["title"].InnerText);
                    XmlNode tempXMLNode = bookElement.Attributes.GetNamedItem("ISBN");
                    _globalTag = tempXMLNode.Value;
                    tempTreeNode.Tag = _globalTag;
                    treeView.Nodes.Add(tempTreeNode);
                }
            }
        }

        //************************************************************************************
        //
        // When an item is selected in the TreeView, highlight the related XMLNode in the RichTextBox.
        //
        //************************************************************************************
        private void xmlTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            filterTreeView.SelectedNode = null;
            unHighlightXML();
            _ISBNOfSelectedBookNode = (string)e.Node.Tag;
            if (_ISBNOfSelectedBookNode != null)
            {
                highlightXML();
            }
        }
        //************************************************************************************
        //
        // Remove the highlighted XML in the XML pane.
        //
        //************************************************************************************
        private void unHighlightXML()
        {
            // Set any previously selected text back to black.
            XmlTextBox.Select(_selectionStart, _selectionLength);
            Font tempFont = new Font(FontFamily.GenericSansSerif, 10F, FontStyle.Regular);
            XmlTextBox.SelectionFont = tempFont;
            XmlTextBox.SelectionColor = Color.White;
        }
        //************************************************************************************
        //
        // Highlight XML in the XML pane. Use the current selection in the TreeView node to
        // choose which element to highlight.
        //
        //************************************************************************************
        private bool highlightXML()
        {
            XmlNode selectedBookNode = _xmlHelperMethods.GetBook(_ISBNOfSelectedBookNode, _doc);

            if (selectedBookNode != null)
            {
                _currentlySelectedNode = selectedBookNode;

                // Use node to get search string.
                string stringToHighlight = selectedBookNode.OuterXml;

                // Cannot search RichTextBox with newlines so do some magic to get the highlight string.
                int numberOfCharactersBefore = stringToHighlight.Substring(0, stringToHighlight.IndexOf(_ISBNOfSelectedBookNode)).Length;
                int lengthOfSelection = stringToHighlight.Length - Constants.lengthOfNamespaceDeclaration;

                // Highlight the new selected text.
                XmlTextBox.SelectionLength = _ISBNOfSelectedBookNode.Length;
                int tempSelectionIndex = XmlTextBox.Find(_ISBNOfSelectedBookNode);

                // Select the entire node in the RichTextBox. Not just the attribute value.
                XmlTextBox.SelectionStart = tempSelectionIndex - numberOfCharactersBefore;
                XmlTextBox.SelectionLength = lengthOfSelection;

                // Store globally because user can manually select XML Text box and we need to know highlighted area later.
                _selectionStart = XmlTextBox.SelectionStart;
                _selectionLength = XmlTextBox.SelectionLength;

                Font tempFont = new Font(FontFamily.GenericSansSerif, 9F, FontStyle.Bold);
                XmlTextBox.SelectionFont = tempFont;
                XmlTextBox.SelectionColor = Color.Yellow;
                XmlTextBox.ScrollToCaret();

                populateEditBoxes();

                return true;
            }
            else
            {
                return false;
            }
        }
        //************************************************************************************
        //
        // As the user selects nodes in the treeview control, populate edit boxes in the edit pane
        // with information from the selected element.
        //
        //************************************************************************************
        private void populateEditBoxes()
        {
            // Get attribute and element values of a node.
            string title = "";
            string ISBN = "";
            string publicationDate = "";
            string genre = "";
            string price = "";

            // get book values.
            _xmlHelperMethods.GetBookInformation(ref title, ref ISBN, ref publicationDate,
                ref price, ref genre, _currentlySelectedNode);

            // populate edit boxes.
            editTitleTextBox.Text = title;
            editISBNTextBox.Text = ISBN;
            editPubDateTextBox.Text = publicationDate;
            editPriceTextBox.Text = price;
            editGenreTextBox.Text = genre;
        }

        //************************************************************************************
        //
        // Add an XML Element to the XMLDocument object.
        //
        //************************************************************************************
        private void addNewBookButton_Click(object sender, EventArgs e)
        {
            if (_doc != null)
            {
                if (newISBNTextBox.Text != "")
                {
                    // Create a book element.
                    XmlElement bookElement = _xmlHelperMethods.AddNewBook(newGenreTextBox.Text,
                        newISBNTextBox.Text, newPubDateTextBox.Text, newTitleTextBox.Text, newPriceTextBox.Text, _doc);

                    if (bookElement != null)
                    {
                        XmlNode selectedBookNode = null;

                        if (positionComboBox.Text == Constants.positionAbove)
                        {
                            selectedBookNode = _xmlHelperMethods.GetBook(_ISBNOfSelectedBookNode, _doc);
                        }
                        else if (positionComboBox.Text == Constants.positionBelow)
                        {
                            selectedBookNode = _xmlHelperMethods.GetBook(_ISBNOfSelectedBookNode, _doc);
                        }

                        //Insert book element at the beginning, end, before a specific element
                        // or after one depending on what option the user selects.
                        _xmlHelperMethods.InsertBookElement(bookElement, positionComboBox.Text, selectedBookNode, validateCheckBox.Checked, generateSchemaCheckBox.Checked);

                        // Populate the RichTextBox again.

                        XmlTextBox.Text = _doc.InnerXml;
                        populateTreeView(_doc);

                        // Highlight the newly added item.
                        _ISBNOfSelectedBookNode = newISBNTextBox.Text;
                        if (highlightXML())
                        {
                            // Clear the text box controls.
                            newGenreTextBox.Text = "";
                            newISBNTextBox.Text = "";
                            newPubDateTextBox.Text = "";
                            newTitleTextBox.Text = "";
                            newPriceTextBox.Text = "";
                        }
                    }
                  }
                else
                {
                    MessageBox.Show("Please provide an ISBN number");
                }
            }
            else
            {
                MessageBox.Show("Please load the XML first by using the Load XML tab");
            }
        }

        //************************************************************************************
        //
        // Helper method to create custom color tabs. In this case, call black.
        //
        //************************************************************************************
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush fillbrush = new SolidBrush(Color.Black);
            //draw rectangle behind the tabs
            Rectangle lasttabrect = tabControl1.GetTabRect(tabControl1.TabPages.Count - 1);
            Rectangle background = new Rectangle();
            background.Location = new Point(lasttabrect.Right, 0);

            //pad the rectangle to cover the 1 pixel line between the top of the tabpage and the start of the tabs
            background.Size = new Size(tabControl1.Right - background.Left, lasttabrect.Height + 1);
            e.Graphics.FillRectangle(fillbrush, background);

            TabPage page = tabControl1.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, this.Font, paddedBounds, page.ForeColor);
        }
        //************************************************************************************
        //
        // Load XML into the DOM when the user chooses the Load XML button.
        //
        //************************************************************************************
        private void loadButton_Click(object sender, EventArgs e)
        {
            loadXML(generateCheckBox.Checked,
                validateCheckBox.Checked, generateSchemaCheckBox.Checked);

            // Clear the text box controls.
            newGenreTextBox.Text = "";
            newISBNTextBox.Text = "";
            newPubDateTextBox.Text = "";
            newTitleTextBox.Text = "";
            newPriceTextBox.Text = "";
        }
        //************************************************************************************
        //
        // To show and hide the generate XML Schema checkboxes.
        //
        //************************************************************************************
        private void validateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (validateCheckBox.Checked == true)
            {
                generateSchemaCheckBox.Enabled = true;
                generateSchemaCheckBox.Visible = true;
            }
            else
            {
                generateSchemaCheckBox.Enabled = false;
                generateSchemaCheckBox.Visible = false;
            }
        }
        //************************************************************************************
        //
        // Update XML element when user submits changes that they've made to edit boxes.
        //
        //************************************************************************************
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (_currentlySelectedNode != null)
            {
                _xmlHelperMethods.editBook(editTitleTextBox.Text, editISBNTextBox.Text,
                    editPubDateTextBox.Text, editGenreTextBox.Text, editPriceTextBox.Text,
                    _currentlySelectedNode, validateCheckBox.Checked, generateCheckBox.Checked);

                // Populate the RichTextBox again.
                XmlTextBox.Text = _doc.InnerXml;
                populateTreeView(_doc);

                highlightXML();
            }
        }
        //************************************************************************************
        //
        // Delete an element from the DOM.
        //
        //************************************************************************************
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (_currentlySelectedNode != null)
            {
                _xmlHelperMethods.deleteBook(_currentlySelectedNode);
                _currentlySelectedNode = null;
                XmlTextBox.Text = _doc.InnerXml;
                populateTreeView(_doc);

                // populate edit boxes.
                editTitleTextBox.Text = "";
                editISBNTextBox.Text = "";
                editPubDateTextBox.Text = "";
                editPriceTextBox.Text = "";
                editGenreTextBox.Text = "";
            }
        }
        //************************************************************************************
        //
        // Position an element up one level in the list of XML elements.
        //
        //************************************************************************************
        private void positionUpButton_Click(object sender, EventArgs e)
        {
            if (_currentlySelectedNode != null && xmlTreeView.SelectedNode != null)
            {
                _xmlHelperMethods.MoveElementUp(_currentlySelectedNode);
                XmlTextBox.Text = _doc.InnerXml;

                unHighlightXML();
                if (_ISBNOfSelectedBookNode != null)
                {
                    highlightXML();
                }

                // Move items up the tree.

                TreeNode selectedNode = xmlTreeView.SelectedNode;
                TreeNode previousNode = xmlTreeView.SelectedNode.PrevNode;

                if (previousNode != null)
                {
                    xmlTreeView.Nodes.Remove(selectedNode);
                    TreeNode insertedNode = xmlTreeView.Nodes.Insert(previousNode.Index, selectedNode.Text);
                    insertedNode.Tag = selectedNode.Tag;
                    xmlTreeView.SelectedNode = insertedNode;
                }
                xmlTreeView.Focus();
            }
            else
            {
                MessageBox.Show("Select the node that you want to reposition in the list");
            }
        }
        //************************************************************************************
        //
        // Position an element one level down in the list of XML elements.
        //
        //************************************************************************************
        private void positionDownButton_Click(object sender, EventArgs e)
        {
            if (_currentlySelectedNode != null && xmlTreeView.SelectedNode != null)
            {
                _xmlHelperMethods.MoveElementDown(_currentlySelectedNode);
                XmlTextBox.Text = _doc.InnerXml;

                unHighlightXML();
                if (_ISBNOfSelectedBookNode != null)
                {
                    highlightXML();
                }

                // Move items down in the tree.

                TreeNode selectedNode = xmlTreeView.SelectedNode;
                TreeNode nextNode = xmlTreeView.SelectedNode.NextNode;

                if (nextNode != null)
                {
                    int insertionIndex = nextNode.Index;
                    TreeNode insertedNode = null;
                    xmlTreeView.Nodes.Remove(selectedNode);
                    if (insertionIndex < xmlTreeView.Nodes.Count)
                    {
                        insertedNode = xmlTreeView.Nodes.Insert(insertionIndex, selectedNode.Text);
                    }
                    else
                    {
                        insertedNode = xmlTreeView.Nodes.Add(selectedNode.Text);
                    }

                    insertedNode.Tag = selectedNode.Tag;
                    xmlTreeView.SelectedNode = insertedNode;
                    xmlTreeView.Focus();
                }
                xmlTreeView.Focus();
            }
            else
            {
                MessageBox.Show("Select the node that you want to reposition in the list");
            }
        }
        //************************************************************************************
        //
        // Save XML.
        //
        //************************************************************************************
        private void saveButton_Click(object sender, EventArgs e)
        {
            _xmlHelperMethods.SaveXML(_doc);
            MessageBox.Show("XML saved.");
        }

        //************************************************************************************
        //
        // Add a filter condition to the list of filter conditions in the UI.
        //
        //************************************************************************************
        private void addFilterButton_Click(object sender, EventArgs e)
        {
            if (condition1Panel.Visible != true)
            {
                condition1Panel.Visible = true;
                applyLabel.Visible = true;
                matchesLabel.Visible = true;
                matchesComboBox.Visible = true;
            }
            else if (condition2Panel.Visible != true)
            {
                condition2Panel.Visible = true;
            }
            else if (condition3Panel.Visible != true)
            {
                condition3Panel.Visible = true;
            }
            else
            {
                condition4Panel.Visible = true;
            }
        }
        //************************************************************************************
        //
        // Clear conditions from the list of conditions.
        //
        //************************************************************************************
        private void clearButton_Click(object sender, EventArgs e)
        {
            if (condition4Panel.Visible != false)
            {
                condition4Panel.Visible = false;
                condition4CheckBox.Checked = false;
            }
            else if (condition3Panel.Visible != false)
            {
                condition3Panel.Visible = false;
                condition3CheckBox.Checked = false;
            }
            else if (condition2Panel.Visible != false)
            {
                condition2Panel.Visible = false;
                condition2CheckBox.Checked = false;
            }
            else
            {
                condition1Panel.Visible = false;
                applyLabel.Visible = false;
                matchesComboBox.Visible = false;
                matchesLabel.Visible = false;
                condition1CheckBox.Checked = false;
            }
        }
        //************************************************************************************
        //
        // Handle condition 1 combobox
        //
        //************************************************************************************
        private void condition1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateOperatorComboBox(condition1ComboBox, operator1ComboBox);
        }
        //************************************************************************************
        //
        // Handle condition 2 combobox
        //
        //************************************************************************************
        private void condition2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateOperatorComboBox(condition2ComboBox, operator2ComboBox);
        }
        //************************************************************************************
        //
        // Handle condition 3 combobox
        //
        //************************************************************************************
        private void condition3ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateOperatorComboBox(condition3ComboBox, operator3ComboBox);
        }
        //************************************************************************************
        //
        // Handle condition 4 combobox
        //
        //************************************************************************************
        private void condition4ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateOperatorComboBox(condition4ComboBox, operator4ComboBox);
        }

        //************************************************************************************
        //
        // Based on which type of filter condition, the user selects, choose the relevant operators
        // and populate the operator combo box with those values.
        //
        //************************************************************************************
        public void populateOperatorComboBox(ComboBox conditionComboBox,
    ComboBox operatorComboBox)
        {
            operatorComboBox.Items.Clear();

            switch (conditionComboBox.Text)
            {
                case Constants.Title:
                    operatorComboBox.Items.Add("=");
                    operatorComboBox.Items.Add("Contains");
                    operatorComboBox.Items.Add("Excludes");
                    break;
                case Constants.Genre:
                    operatorComboBox.Items.Add("=");
                    break;
                case Constants.PubDate:
                    operatorComboBox.Items.Add("=");
                    break;
                case Constants.Price:
                    operatorComboBox.Items.Add("=");
                    operatorComboBox.Items.Add(">");
                    operatorComboBox.Items.Add("<");
                    operatorComboBox.Items.Add(">=");
                    operatorComboBox.Items.Add("<=");
                    operatorComboBox.Items.Add("<>");
                    break;
                case Constants.ISBN:
                    operatorComboBox.Items.Add("=");
                    operatorComboBox.Items.Add("Contains");
                    operatorComboBox.Items.Add("Excludes");
                    break;
                default:
                    break;
            }
        }
        //************************************************************************************
        //
        // Handle condition 1 checkbox.
        //
        //************************************************************************************
        private void condition1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConditionCheckChanged((CheckBox)sender);
        }
        //************************************************************************************
        //
        // Handle condition 2 checkbox.
        //
        //************************************************************************************
        private void condition2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConditionCheckChanged((CheckBox)sender);
        }
        //************************************************************************************
        //
        // Handle condition 3 checkbox.
        //
        //************************************************************************************
        private void condition3CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConditionCheckChanged((CheckBox)sender);
        }
        //************************************************************************************
        //
        // Handle condition 4 checkbox.
        //
        //************************************************************************************
        private void condition4CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ConditionCheckChanged((CheckBox)sender);
        }
        //************************************************************************************
        //
        // Handle when any checkbox is checked or cleared. Queue up the conditions, operators
        // and values for each selected condition and pass them to a method for processing.
        //
        //************************************************************************************
        private void ConditionCheckChanged(CheckBox conditionCheckBox)
        {
            ArrayList Conditions = new ArrayList();
            ArrayList Operators = new ArrayList();
            ArrayList Values =new ArrayList();

            if (condition1CheckBox.Checked == true)
            {
                Conditions.Add(condition1ComboBox.Text);
                Operators.Add(operator1ComboBox.Text);
                Values.Add(condition1TextBox.Text);
            }
            if (condition2CheckBox.Checked == true)
            {
                Conditions.Add(condition2ComboBox.Text);
                Operators.Add(operator2ComboBox.Text);
                Values.Add(condition2TextBox.Text);
            }
            if (condition3CheckBox.Checked == true)
            {
                Conditions.Add(condition3ComboBox.Text);
                Operators.Add(operator3ComboBox.Text);
                Values.Add(condition3TextBox.Text);
            }
            if (condition4CheckBox.Checked == true)
            {
                Conditions.Add(condition4ComboBox.Text);
                Operators.Add(operator4ComboBox.Text);
                Values.Add(condition4TextBox.Text);
            }

            FilterChecked(Conditions, Operators, Values, conditionCheckBox);
        }
        //************************************************************************************
        //
        // Clear filter treeview and requery for filter conditions.
        //
        //************************************************************************************
        private void RemoveFilter()
        {
            filterTreeView.Nodes.Clear();

            if (condition1CheckBox.Checked == true)
            {
                ConditionCheckChanged(condition1CheckBox);
            }
            else if (condition2CheckBox.Checked == true)
            {
                ConditionCheckChanged(condition2CheckBox);
            }
            else if (condition3CheckBox.Checked == true)
            {
                ConditionCheckChanged(condition3CheckBox);
            }
            else if (condition4CheckBox.Checked == true)
            {
                ConditionCheckChanged(condition4CheckBox);
            }
        }
        //************************************************************************************
        //
        // Show or hide the filtered results box based on whether filter conditions are selected.
        //
        //************************************************************************************
        private void ShowOrHideFilterBox()
        {
            if (condition1CheckBox.Checked == false &&
                condition2CheckBox.Checked == false &&
                condition3CheckBox.Checked == false &&
                condition4CheckBox.Checked == false)
            {
                filterBox.Visible = false;
            }
            else
            {
                filterBox.Visible = true;
            }
        }
        //************************************************************************************
        //
        // Query XML Document based on filter conditions.
        //
        //************************************************************************************
        private void FilterChecked(ArrayList conditions, ArrayList operatorSymbols, ArrayList values, CheckBox conditionCheckBox)
        {
            if (conditionCheckBox.Checked == true)
            {
                XmlNodeList nodes = null;

                bool failure = false;
                foreach (string _condition in conditions)
                {
                    if (_condition == Constants.Condition)
                    {
                        MessageBox.Show("Missing a condition");
                        conditionCheckBox.Checked = false;
                        failure = true;
                        break;
                    }
                }
                foreach (string _value in values)
                {
                    if (_value == "")
                    {
                        MessageBox.Show("Missing a value");
                        conditionCheckBox.Checked = false;
                        failure = true;
                        break;
                     }
                 }
                if (failure != true)
                {
                    nodes = _xmlHelperMethods.ApplyFilters
                    (conditions, operatorSymbols, values, _doc, matchesComboBox.Text);
                    filterTreeView.Nodes.Clear();
                    if (nodes == null)
                    {
                        MessageBox.Show("No results found");
                        conditionCheckBox.Checked = false;
                    }
                    else if (nodes.Count == 0)
                    {
                        MessageBox.Show("No results found");
                        conditionCheckBox.Checked = false;
                    }
                    else
                    {
                        addTreeNodes(nodes, filterTreeView);
                    }
                }
            }
            else
            {
                RemoveFilter();
            }
            ShowOrHideFilterBox();
        }

        //************************************************************************************
        //
        // Handle when items in the filtered results viewed are selected by the user.
        //
        //************************************************************************************
        private void filterTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            xmlTreeView.SelectedNode = null;
            unHighlightXML();
            _ISBNOfSelectedBookNode = (string)e.Node.Tag;
            if (_ISBNOfSelectedBookNode != null)
            {
                highlightXML();
            }
        }

        //************************************************************************************
        //
        // Handle when the user chooses to "All" or "Any" in the "Matches" combo box.
        //
        //************************************************************************************
        private void matchesComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            RemoveFilter();
        }
    }
    }
