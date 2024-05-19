Imports System.Xml
Imports System.Collections

Public Class Form1
    Dim _globalTag As String = ""
    Dim _xmlHelperMethods As XMLHelperMethods
    Dim _ISBNOfSelectedBookNode As String = ""
    Dim _doc As XmlDocument = Nothing
    Dim _selectionStart As Integer
    Dim _selectionLength As Integer
    Dim _currentlySelectedNode As XmlNode = Nothing

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        _xmlHelperMethods = New XMLHelperMethods

    End Sub

    '************************************************************************************
    '
    ' Load Xml from file. Keep white spaces and newlines.
    ' Then, call a method to populate a tree view control with the elements of the XML.
    '
    '************************************************************************************
    Private Sub loadXML(ByVal generateXML As Boolean, ByVal validateXML As Boolean, ByVal generateSchema As Boolean)
        If validateXML Then
            _doc = _xmlHelperMethods.LoadDocumentWithSchemaValidation(generateXML, generateSchema)
        Else
            _doc = _xmlHelperMethods.LoadDocument(generateXML)
        End If
        If (_doc Is Nothing) Then
            MessageBox.Show("Unable to load XML file or schema. The XML file or schema validation file does not exist. Consider ge" & _
                "nerating the XML file and/or schema file")
        Else
            XmlTextBox.Text = _doc.InnerXml
            populateTreeView(_doc)
        End If
    End Sub

    '************************************************************************************
    '
    ' Populate the TreeView control with the elements of the XML file.
    '
    '************************************************************************************
    Private Sub populateTreeView(ByVal doc As XmlDocument)

        xmlTreeView.Nodes.Clear()
        addTreeNodes(doc.DocumentElement.ChildNodes, xmlTreeView)
        xmlTreeView.ExpandAll()

    End Sub

    '************************************************************************************
    '
    ' Helper method for populating the TreeView control with the elements of the XML file.
    '
    '************************************************************************************
    Private Sub addTreeNode_Recursive(ByVal xmlNode As XmlNode, ByVal treeNode As TreeNode)

        Dim xNodeList As XmlNodeList

        If xmlNode.HasChildNodes Then
            xNodeList = xmlNode.ChildNodes
            For Each node As XmlNode In xmlNode.ChildNodes
                If (node.NodeType <> XmlNodeType.Whitespace) Then
                    Dim tempTreeNode As TreeNode = New TreeNode(node.Name)
                    If (Not (node.Attributes) Is Nothing) Then
                        Dim tempXMLNode As XmlNode = node.Attributes.GetNamedItem("ISBN")
                        If (Not (tempXMLNode) Is Nothing) Then
                            _globalTag = tempXMLNode.Value
                        End If
                    End If
                    tempTreeNode.Tag = _globalTag
                    treeNode.Nodes.Add(tempTreeNode)
                    addTreeNode_Recursive(node, tempTreeNode)
                End If
            Next
        Else
            treeNode.Text = xmlNode.OuterXml.Trim
        End If
    End Sub

    Private Sub addTreeNodes(ByVal books As XmlNodeList, ByVal treeView As TreeView)
        For Each book As XmlNode In books

            If (book.NodeType = XmlNodeType.Element) Then
                Dim bookElement As XmlElement = CType(book, XmlElement)
                Dim tempTreeNode As TreeNode = New TreeNode(bookElement("title").InnerText)
                Dim tempXMLNode As XmlNode = bookElement.Attributes.GetNamedItem("ISBN")
                _globalTag = tempXMLNode.Value
                tempTreeNode.Tag = _globalTag
                treeView.Nodes.Add(tempTreeNode)
            End If

        Next
    End Sub

    '************************************************************************************
    '
    ' When an item is selected in the TreeView, highlight the related XMLNode in the RichTextBox.
    '
    '************************************************************************************
    Private Sub xmlTreeView_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) _
        Handles xmlTreeView.AfterSelect
        filterTreeView.SelectedNode = Nothing
        unHighlightXML()
        _ISBNOfSelectedBookNode = CType(e.Node.Tag, String)
        If (Not (_ISBNOfSelectedBookNode) Is Nothing) Then
            highlightXML()
        End If
    End Sub

    '************************************************************************************
    '
    ' Remove the highlighted XML in the XML pane.
    '
    '************************************************************************************
    Private Sub unHighlightXML()
        ' Set any previously selected text back to black.
        XmlTextBox.Select(_selectionStart, _selectionLength)
        Dim tempFont As Font = New Font(FontFamily.GenericSansSerif, 10.0!, FontStyle.Regular)
        XmlTextBox.SelectionFont = tempFont
        XmlTextBox.SelectionColor = Color.White
    End Sub

    '************************************************************************************
    '
    ' Highlight XML in the XML pane. Use the current selection in the TreeView node to
    ' choose which element to highlight.
    '
    '************************************************************************************
    Private Function highlightXML() As Boolean
        Dim selectedBookNode As XmlNode = _xmlHelperMethods.GetBook(_ISBNOfSelectedBookNode, _doc)
        If (Not (selectedBookNode) Is Nothing) Then
            _currentlySelectedNode = selectedBookNode

            ' Use node to get search string.
            Dim stringToHighlight As String = selectedBookNode.OuterXml

            ' Cannot search RichTextBox with newlines so do some magic to get the highlight string.
            Dim numberOfCharactersBefore As Integer = stringToHighlight.Substring(0, stringToHighlight.IndexOf(_ISBNOfSelectedBookNode)).Length
            Dim lengthOfSelection As Integer = (stringToHighlight.Length - Constants.lengthOfNamespaceDeclaration)

            ' Highlight the new selected text.          
            XmlTextBox.SelectionLength = _ISBNOfSelectedBookNode.Length
            Dim tempSelectionIndex As Integer = XmlTextBox.Find(_ISBNOfSelectedBookNode)

            ' Select the entire node in the RichTextBox. Not just the attribute value.
            XmlTextBox.SelectionStart = (tempSelectionIndex - numberOfCharactersBefore)
            XmlTextBox.SelectionLength = lengthOfSelection

            ' Store globally because user can manually select XML Text box and we need to know highlighted area later.
            _selectionStart = XmlTextBox.SelectionStart
            _selectionLength = XmlTextBox.SelectionLength
            Dim tempFont As Font = New Font(FontFamily.GenericSansSerif, 9.0!, FontStyle.Bold)
            XmlTextBox.SelectionFont = tempFont
            XmlTextBox.SelectionColor = Color.Yellow
            XmlTextBox.ScrollToCaret()
            populateEditBoxes()
            Return True
        Else
            Return False
        End If
    End Function

    '************************************************************************************
    '
    ' As the user selects nodes in the treeview control, populate edit boxes in the edit pane
    ' with information from the selected element.
    '
    '************************************************************************************
    Private Sub populateEditBoxes()
        ' Get attribute and element values of a node.
        Dim title As String = ""
        Dim ISBN As String = ""
        Dim publicationDate As String = ""
        Dim genre As String = ""
        Dim price As String = ""

        ' get book values.
        _xmlHelperMethods.GetBookInformation(title, ISBN, publicationDate, price, genre, _currentlySelectedNode)

        ' populate edit boxes.
        editTitleTextBox.Text = title
        editISBNTextBox.Text = ISBN
        editPubDateTextBox.Text = publicationDate
        editPriceTextBox.Text = price
        editGenreTextBox.Text = genre
    End Sub

    '************************************************************************************
    '
    ' Add an XML Element to the XMLDocument object.
    '
    '************************************************************************************
    Private Sub addNewBookButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addNewBookButton.Click
        If (Not (_doc) Is Nothing) Then
            If (newISBNTextBox.Text <> "") Then
                ' Create a book element.
                Dim bookElement As XmlElement = _xmlHelperMethods.AddNewBook(newGenreTextBox.Text, newISBNTextBox.Text, newPubDateTextBox.Text, newTitleTextBox.Text, newPriceTextBox.Text, _doc)
                If (Not (bookElement) Is Nothing) Then
                    Dim selectedBookNode As XmlNode = Nothing
                    If (positionComboBox.Text = Constants.positionAbove) Then
                        selectedBookNode = _xmlHelperMethods.GetBook(_ISBNOfSelectedBookNode, _doc)
                    ElseIf (positionComboBox.Text = Constants.positionBelow) Then
                        selectedBookNode = _xmlHelperMethods.GetBook(_ISBNOfSelectedBookNode, _doc)
                    End If

                    'Insert book element at the beginning, end, before a specific element 
                    ' or after one depending on what option the user selects.
                    _xmlHelperMethods.InsertBookElement(bookElement, positionComboBox.Text, selectedBookNode, validateCheckBox.Checked, generateSchemaCheckBox.Checked)

                    ' Populate the RichTextBox again.
                    XmlTextBox.Text = _doc.InnerXml
                    populateTreeView(_doc)

                    ' Highlight the newly added item.
                    _ISBNOfSelectedBookNode = newISBNTextBox.Text
                    If highlightXML() Then
                        ' Clear the text box controls.
                        newGenreTextBox.Text = ""
                        newISBNTextBox.Text = ""
                        newPubDateTextBox.Text = ""
                        newTitleTextBox.Text = ""
                        newPriceTextBox.Text = ""
                    End If
                End If
            Else
                MessageBox.Show("Please provide an ISBN number")
            End If
        Else
            MessageBox.Show("Please load the XML first by using the Load XML tab")
        End If
    End Sub

    '************************************************************************************
    '
    ' Helper method to create custom color tabs. In this case, call black.
    '
    '************************************************************************************
    Private Sub tabControl1_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles tabControl1.DrawItem
        Dim fillbrush As SolidBrush = New SolidBrush(Color.Black)

        'draw rectangle behind the tabs
        Dim lasttabrect As Rectangle = tabControl1.GetTabRect((tabControl1.TabPages.Count - 1))
        Dim background As Rectangle = New Rectangle
        background.Location = New Point(lasttabrect.Right, 0)

        'pad the rectangle to cover the 1 pixel line between the top of the tabpage and the start of the tabs
        background.Size = New Size((tabControl1.Right - background.Left), (lasttabrect.Height + 1))
        e.Graphics.FillRectangle(fillbrush, background)
        Dim page As TabPage = tabControl1.TabPages(e.Index)
        e.Graphics.FillRectangle(New SolidBrush(page.BackColor), e.Bounds)
        Dim paddedBounds As Rectangle = e.Bounds
        Dim yOffset As Integer = (e.State = DrawItemState.Selected)

        'TODO: Warning!!!, inline IF is not supported ?
        paddedBounds.Offset(1, yOffset)
        TextRenderer.DrawText(e.Graphics, page.Text, Me.Font, paddedBounds, page.ForeColor)
    End Sub

    '************************************************************************************
    '
    ' Load XML into the DOM when the user chooses the Load XML button.
    '
    '************************************************************************************
    Private Sub loadButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadButton.Click

        loadXML(generateCheckBox.Checked, validateCheckBox.Checked, generateSchemaCheckBox.Checked)

        ' Clear the text box controls.
        newGenreTextBox.Text = ""
        newISBNTextBox.Text = ""
        newPubDateTextBox.Text = ""
        newTitleTextBox.Text = ""
        newPriceTextBox.Text = ""
    End Sub

    '************************************************************************************
    '
    ' To show and hide the generate XML Schema checkboxes.
    '
    '************************************************************************************
    Private Sub validateCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles validateCheckBox.CheckedChanged
        If (validateCheckBox.Checked = True) Then
            generateSchemaCheckBox.Enabled = True
            generateSchemaCheckBox.Visible = True
        Else
            generateSchemaCheckBox.Enabled = False
            generateSchemaCheckBox.Visible = False
        End If
    End Sub

    '************************************************************************************
    '
    ' Update XML element when user submits changes that they've made to edit boxes.
    '
    '************************************************************************************
    Private Sub submitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles submitButton.Click
        If (Not (_currentlySelectedNode) Is Nothing) Then
            _xmlHelperMethods.editBook(editTitleTextBox.Text, editISBNTextBox.Text, editPubDateTextBox.Text, editGenreTextBox.Text, editPriceTextBox.Text, _currentlySelectedNode, validateCheckBox.Checked, generateCheckBox.Checked)

            ' Populate the RichTextBox again.
            XmlTextBox.Text = _doc.InnerXml
            populateTreeView(_doc)
            highlightXML()
        End If
    End Sub

    '************************************************************************************
    '
    ' Delete an element from the DOM.
    '
    '************************************************************************************
    Private Sub deleteButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles deleteButton.Click
        If (Not (_currentlySelectedNode) Is Nothing) Then
            _xmlHelperMethods.deleteBook(_currentlySelectedNode)
            _currentlySelectedNode = Nothing
            XmlTextBox.Text = _doc.InnerXml
            populateTreeView(_doc)

            ' populate edit boxes.
            editTitleTextBox.Text = ""
            editISBNTextBox.Text = ""
            editPubDateTextBox.Text = ""
            editPriceTextBox.Text = ""
            editGenreTextBox.Text = ""
        End If
    End Sub

    '************************************************************************************
    '
    ' Position an element up one level in the list of XML elements.
    '
    '************************************************************************************
    Private Sub positionUpButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles positionUpButton.Click
        If ((Not (_currentlySelectedNode) Is Nothing) _
                    AndAlso (Not (xmlTreeView.SelectedNode) Is Nothing)) Then
            _xmlHelperMethods.MoveElementUp(_currentlySelectedNode)
            XmlTextBox.Text = _doc.InnerXml
            unHighlightXML()
            If (Not (_ISBNOfSelectedBookNode) Is Nothing) Then
                highlightXML()
            End If

            ' Move items up the tree.
            Dim selectedNode As TreeNode = xmlTreeView.SelectedNode
            Dim previousNode As TreeNode = xmlTreeView.SelectedNode.PrevNode
            If (Not (previousNode) Is Nothing) Then
                xmlTreeView.Nodes.Remove(selectedNode)
                Dim insertedNode As TreeNode = xmlTreeView.Nodes.Insert(previousNode.Index, selectedNode.Text)
                insertedNode.Tag = selectedNode.Tag
                xmlTreeView.SelectedNode = insertedNode
            End If
            xmlTreeView.Focus()
        Else
            MessageBox.Show("Select the node that you want to reposition in the list")
        End If
    End Sub

    '************************************************************************************
    '
    ' Position an element one level down in the list of XML elements.
    '
    '************************************************************************************
    Private Sub positionDownButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles positionDownButton.Click
        If ((Not (_currentlySelectedNode) Is Nothing) _
                    AndAlso (Not (xmlTreeView.SelectedNode) Is Nothing)) Then
            _xmlHelperMethods.MoveElementDown(_currentlySelectedNode)
            XmlTextBox.Text = _doc.InnerXml
            unHighlightXML()
            If (Not (_ISBNOfSelectedBookNode) Is Nothing) Then
                highlightXML()
            End If

            ' Move items down in the tree.
            Dim selectedNode As TreeNode = xmlTreeView.SelectedNode
            Dim nextNode As TreeNode = xmlTreeView.SelectedNode.NextNode
            If (Not (nextNode) Is Nothing) Then
                Dim insertionIndex As Integer = nextNode.Index
                Dim insertedNode As TreeNode = Nothing
                xmlTreeView.Nodes.Remove(selectedNode)
                If (insertionIndex < xmlTreeView.Nodes.Count) Then
                    insertedNode = xmlTreeView.Nodes.Insert(insertionIndex, selectedNode.Text)
                Else
                    insertedNode = xmlTreeView.Nodes.Add(selectedNode.Text)
                End If
                insertedNode.Tag = selectedNode.Tag
                xmlTreeView.SelectedNode = insertedNode
                xmlTreeView.Focus()
            End If
            xmlTreeView.Focus()
        Else
            MessageBox.Show("Select the node that you want to reposition in the list")
        End If
    End Sub

    '************************************************************************************
    '
    ' Save XML.
    '
    '************************************************************************************
    Private Sub saveButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles saveButton.Click
        _xmlHelperMethods.SaveXML(_doc)
        MessageBox.Show("XML saved.")
    End Sub

    '************************************************************************************
    '
    ' Add a filter condition to the list of filter conditions in the UI.
    '
    '************************************************************************************
    Private Sub addFilterButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addFilterButton.Click
        If (condition1Panel.Visible <> True) Then
            condition1Panel.Visible = True
            applyLabel.Visible = True
            matchesLabel.Visible = True
            matchesComboBox.Visible = True
        ElseIf (condition2Panel.Visible <> True) Then
            condition2Panel.Visible = True
        ElseIf (condition3Panel.Visible <> True) Then
            condition3Panel.Visible = True
        Else
            condition4Panel.Visible = True
        End If
    End Sub

    '************************************************************************************
    '
    ' Clear conditions from the list of conditions.
    '
    '************************************************************************************
    Private Sub clearButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearButton.Click
        If (condition4Panel.Visible <> False) Then
            condition4Panel.Visible = False
            condition4CheckBox.Checked = False
        ElseIf (condition3Panel.Visible <> False) Then
            condition3Panel.Visible = False
            condition3CheckBox.Checked = False
        ElseIf (condition2Panel.Visible <> False) Then
            condition2Panel.Visible = False
            condition2CheckBox.Checked = False
        Else
            condition1Panel.Visible = False
            applyLabel.Visible = False
            matchesComboBox.Visible = False
            matchesLabel.Visible = False
            condition1CheckBox.Checked = False
        End If
    End Sub

    '************************************************************************************
    '
    ' Handle condition 1 combobox
    '
    '************************************************************************************
    Private Sub condition1ComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles condition1ComboBox.SelectedIndexChanged
        populateOperatorComboBox(condition1ComboBox, operator1ComboBox)
    End Sub

    '************************************************************************************
    '
    ' Handle condition 2 combobox
    '
    '************************************************************************************
    Private Sub condition2ComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles condition2ComboBox.SelectedIndexChanged
        populateOperatorComboBox(condition2ComboBox, operator2ComboBox)
    End Sub

    '************************************************************************************
    '
    ' Handle condition 3 combobox
    '
    '************************************************************************************
    Private Sub condition3ComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles condition3ComboBox.SelectedIndexChanged
        populateOperatorComboBox(condition3ComboBox, operator3ComboBox)
    End Sub

    '************************************************************************************
    '
    ' Handle condition 4 combobox
    '
    '************************************************************************************
    Private Sub condition4ComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles condition4ComboBox.SelectedIndexChanged
        populateOperatorComboBox(condition4ComboBox, operator4ComboBox)
    End Sub

    '************************************************************************************
    '
    ' Based on which type of filter condition, the user selects, choose the relevant operators
    ' and populate the operator combo box with those values.
    '
    '************************************************************************************
    Public Sub populateOperatorComboBox(ByVal conditionComboBox As ComboBox, ByVal operatorComboBox As ComboBox)
        operatorComboBox.Items.Clear()

        Select Case (conditionComboBox.Text)

            Case Constants.Title
                operatorComboBox.Items.Add("=")
                operatorComboBox.Items.Add("Contains")
                operatorComboBox.Items.Add("Excludes")

            Case Constants.Genre
                operatorComboBox.Items.Add("=")

            Case Constants.PubDate
                operatorComboBox.Items.Add("=")

            Case Constants.Price
                operatorComboBox.Items.Add("=")
                operatorComboBox.Items.Add(">")
                operatorComboBox.Items.Add("<")
                operatorComboBox.Items.Add(">=")
                operatorComboBox.Items.Add("<=")
                operatorComboBox.Items.Add("<>")

            Case Constants.ISBN
                operatorComboBox.Items.Add("=")
                operatorComboBox.Items.Add("Contains")
                operatorComboBox.Items.Add("Excludes")

        End Select
    End Sub

    '************************************************************************************
    '
    ' Handle condition 1 checkbox.
    '
    '************************************************************************************
    Private Sub condition1CheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles condition1CheckBox.CheckedChanged
        ConditionCheckChanged(CType(sender, CheckBox))
    End Sub

    '************************************************************************************
    '
    ' Handle condition 2 checkbox.
    '
    '************************************************************************************
    Private Sub condition2CheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles condition2CheckBox.CheckedChanged
        ConditionCheckChanged(CType(sender, CheckBox))
    End Sub

    '************************************************************************************
    '
    ' Handle condition 3 checkbox.
    '
    '************************************************************************************
    Private Sub condition3CheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles condition3CheckBox.CheckedChanged
        ConditionCheckChanged(CType(sender, CheckBox))
    End Sub

    '************************************************************************************
    '
    ' Handle condition 4 checkbox.
    '
    '************************************************************************************
    Private Sub condition4CheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles condition4CheckBox.CheckedChanged
        ConditionCheckChanged(CType(sender, CheckBox))
    End Sub

    '************************************************************************************
    '
    ' Handle when any checkbox is checked or cleared. Queue up the conditions, operators
    ' and values for each selected condition and pass them to a method for processing.
    '
    '************************************************************************************
    Private Sub ConditionCheckChanged(ByVal conditionCheckBox As CheckBox)

        Dim Conditions As ArrayList = New ArrayList
        Dim Operators As ArrayList = New ArrayList
        Dim Values As ArrayList = New ArrayList

        If (condition1CheckBox.Checked = True) Then
            Conditions.Add(condition1ComboBox.Text)
            Operators.Add(operator1ComboBox.Text)
            Values.Add(condition1TextBox.Text)
        End If

        If (condition2CheckBox.Checked = True) Then
            Conditions.Add(condition2ComboBox.Text)
            Operators.Add(operator2ComboBox.Text)
            Values.Add(condition2TextBox.Text)
        End If

        If (condition3CheckBox.Checked = True) Then
            Conditions.Add(condition3ComboBox.Text)
            Operators.Add(operator3ComboBox.Text)
            Values.Add(condition3TextBox.Text)
        End If

        If (condition4CheckBox.Checked = True) Then
            Conditions.Add(condition4ComboBox.Text)
            Operators.Add(operator4ComboBox.Text)
            Values.Add(condition4TextBox.Text)
        End If

        FilterChecked(Conditions, Operators, Values, conditionCheckBox)
    End Sub

    '************************************************************************************
    '
    ' Clear filter treeview and requery for filter conditions.
    '
    '************************************************************************************
    Private Sub RemoveFilter()
        filterTreeView.Nodes.Clear()

        If (condition1CheckBox.Checked = True) Then
            ConditionCheckChanged(condition1CheckBox)

        ElseIf (condition2CheckBox.Checked = True) Then
            ConditionCheckChanged(condition2CheckBox)

        ElseIf (condition3CheckBox.Checked = True) Then
            ConditionCheckChanged(condition3CheckBox)

        ElseIf (condition4CheckBox.Checked = True) Then
            ConditionCheckChanged(condition4CheckBox)

        End If
    End Sub

    '************************************************************************************
    '
    ' Show or hide the filtered results box based on whether filter conditions are selected.
    '
    '************************************************************************************
    Private Sub ShowOrHideFilterBox()

        If ((condition1CheckBox.Checked = False) _
                    AndAlso ((condition2CheckBox.Checked = False) _
                    AndAlso ((condition3CheckBox.Checked = False) _
                    AndAlso (condition4CheckBox.Checked = False)))) Then
            filterBox.Visible = False
        Else
            filterBox.Visible = True
        End If
    End Sub

    '************************************************************************************
    '
    ' Query XML Document based on filter conditions.
    '
    '************************************************************************************
    Private Sub FilterChecked(ByVal conditions As ArrayList, ByVal operatorSymbols As ArrayList, ByVal values As ArrayList, ByVal conditionCheckBox As CheckBox)

        If (conditionCheckBox.Checked = True) Then
            Dim nodes As XmlNodeList = Nothing
            Dim failure As Boolean = False

            For Each _condition As String In conditions
                If (_condition = Constants.Condition) Then
                    MessageBox.Show("Missing a condition")
                    conditionCheckBox.Checked = False
                    failure = True
                    Exit For
                End If
            Next

            For Each _value As String In values
                If (_value = "") Then
                    MessageBox.Show("Missing a value")
                    conditionCheckBox.Checked = False
                    failure = True
                    Exit For
                End If
            Next

            If (failure <> True) Then
                nodes = _xmlHelperMethods.ApplyFilters(conditions, operatorSymbols, values, _doc, matchesComboBox.Text)
                filterTreeView.Nodes.Clear()
                If (nodes Is Nothing) Then
                    MessageBox.Show("No results found")
                    conditionCheckBox.Checked = False
                ElseIf (nodes.Count = 0) Then
                    MessageBox.Show("No results found")
                    conditionCheckBox.Checked = False
                Else
                    addTreeNodes(nodes, filterTreeView)
                End If
            End If
        Else
            RemoveFilter()
        End If
        ShowOrHideFilterBox()
    End Sub

    '************************************************************************************
    '
    ' Handle when items in the filtered results viewed are selected by the user.
    '
    '************************************************************************************
    Private Sub filterTreeView_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles filterTreeView.AfterSelect
        xmlTreeView.SelectedNode = Nothing
        unHighlightXML()
        _ISBNOfSelectedBookNode = CType(e.Node.Tag, String)
        If (Not (_ISBNOfSelectedBookNode) Is Nothing) Then
            highlightXML()
        End If
    End Sub

    '************************************************************************************
    '
    ' Handle when the user chooses to "All" or "Any" in the "Matches" combo box.
    '
    '************************************************************************************
    Private Sub matchesComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles matchesComboBox.SelectedValueChanged
        RemoveFilter()
    End Sub

End Class
