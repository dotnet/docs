' This sample can go in the VisualStyleElement class overview or a conceptual topic
' to give the new user a chance to view what each of the defined elements looks like. 
' This sample also gives them the ability to preview each element at three different sizes.

' <Snippet0>
Imports System
Imports System.Text
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace VisualStyleElementViewer

    Class Form1
        Inherits Form

        Public Sub New()
            Dim ElementViewer1 As New ElementViewer()
            With Me
                .Controls.Add(ElementViewer1)
                .Text = ElementViewer1.Text
                .Size = New Size(700, 550)
            End With
        End Sub

        <STAThread()> Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub
    End Class

    Public Class ElementViewer
        Inherits UserControl

        Private element As VisualStyleElement
        Private renderer As VisualStyleRenderer
        Private elementDictionary As New Dictionary(Of String, _
            VisualStyleElement)
        Private descriptionRect As Rectangle
        Private displayRect As Rectangle
        Private displayRectFull As Rectangle
        Private currentTrueSize As New Size()
        Private elementDescription As New StringBuilder()
        Private label1 As New Label()
        Private WithEvents treeView1 As New TreeView()
        Private WithEvents domainUpDown1 As New DomainUpDown()
        Private drawElement As Boolean = False

        Public Sub New()
            With Me
                .Location = New Point(10, 10)
                .Size = New Size(650, 500)
                .Text = "VisualStyleElement Viewer"
                .Font = SystemFonts.IconTitleFont
                .BackColor = Color.White
                .BorderStyle = BorderStyle.Fixed3D
                .AutoSize = True
            End With
        End Sub 'New

        Private Sub ElementViewer_Load(ByVal sender As Object, _
            ByVal e As EventArgs) Handles Me.Load

            ' Make sure the visual styles are enabled before 
            ' going any further.
            If Not Application.RenderWithVisualStyles Then
                Return
            End If

            With label1
                .Location = New Point(320, 10)
                .Size = New Size(300, 60)
                .Text = "Expand the element class nodes in the " + _
                    "tree view to access visual style elements. " + _
                    "Click an element name to draw the element " + _
                    "below. To change the size of a resizable " + _
                    "element, use the spin control."
            End With

            With domainUpDown1
                .Location = New Point(320, 80)
                .Size = New Size(70, 30)
                .ReadOnly = True
                .Items.Add(elementSizes.Large)
                .Items.Add(elementSizes.Medium)
                .Items.Add(elementSizes.TrueSize)
                .SelectedIndex = 2
                .DownButton()
            End With

            descriptionRect = New Rectangle(320, 120, 250, 50)
            displayRect = New Rectangle(320, 160, 0, 0)
            displayRectFull = New Rectangle(320, 160, 300, 200)

            ' Initialize the element and renderer to known good values.
            element = VisualStyleElement.Button.PushButton.Normal
            renderer = New VisualStyleRenderer(element)

            SetupElementCollection()
            SetupTreeView()

            Me.Controls.AddRange(New Control() {treeView1, _
                domainUpDown1, label1})
        End Sub

        ' Use reflection to build a Dictionary of all 
        ' VisualStyleElement objects exposed in the 
        ' System.Windows.Forms.VisualStyles namespace.
        Private Sub SetupElementCollection()
            Dim elementName As New StringBuilder()
            Dim currentElement As VisualStyleElement
            Dim tempObject As Object
            Dim plusSignIndex As Integer = 0

            ' Get array of first-level nested types within 
            ' VisualStyleElement; these are the element classes.
            Dim elementClasses As Type() = _
                GetType(VisualStyleElement).GetNestedTypes()

            Dim elementClass As Type
            For Each elementClass In elementClasses

                ' Get an array of second-level nested types within
                ' VisualStyleElement; these are the element parts.
                Dim elementParts As Type() = _
                    elementClass.GetNestedTypes()

                ' Get the index of the first '+' character in 
                ' the full element class name.
                plusSignIndex = elementClass.FullName.IndexOf("+")

                Dim elementPart As Type
                For Each elementPart In elementParts

                    ' Get an array of Shared property details 
                    ' for  the current type. Each of these types have 
                    ' properties that return VisualStyleElement objects.
                    Dim elementProperties As PropertyInfo() = _
                        elementPart.GetProperties( _
                        (BindingFlags.Static Or BindingFlags.Public))

                    ' For each property, insert the unique full element   
                    ' name and the element into the collection.
                    Dim elementProperty As PropertyInfo
                    For Each elementProperty In elementProperties

                        ' Get the element.
                        tempObject = elementProperty.GetValue( _
                            Nothing, BindingFlags.Static, Nothing, _
                            Nothing, Nothing)
                        currentElement = CType(tempObject, _
                            VisualStyleElement)

                        ' Append the full element name.
                        elementName.Append(elementClass.FullName, _
                            plusSignIndex + 1, _
                            elementClass.FullName.Length - _
                            plusSignIndex - 1)
                        elementName.Append(("." + _
                            elementPart.Name.ToString() + _
                            "." + elementProperty.Name))

                        ' Add the element and element name to 
                        ' the Dictionary.
                        elementDictionary.Add(elementName.ToString(), _
                            currentElement)

                        ' Clear the element name for the next iteration.
                        elementName.Remove(0, elementName.Length)
                    Next elementProperty
                Next elementPart
            Next elementClass
        End Sub

        ' Initialize the tree view with the element names.
        Private Sub SetupTreeView()

            With treeView1
                .Location = New Point(10, 10)
                .Size = New Size(300, 450)
                .BorderStyle = BorderStyle.FixedSingle
                .BackColor = Color.WhiteSmoke
                .SelectedNode = Nothing
                .BeginUpdate()
            End With

            ' An index into the top-level tree nodes.
            Dim nodeIndex As Integer = 0

            ' An index into the first '.' character in an element name.
            Dim firstDotIndex As Integer = 0

            ' Initialize the element class name to compare 
            ' with the class name of the first element 
            ' in the Dictionary, and set this name to the first 
            ' top-level node.
            Dim compareClassName As New StringBuilder("Button")
            treeView1.Nodes.Add( _
                New TreeNode(compareClassName.ToString()))

            ' The current element class name.
            Dim currentClassName As New StringBuilder()

            ' The text for each second-level node.
            Dim nodeText As New StringBuilder()

            Dim entry As KeyValuePair(Of String, VisualStyleElement)
            For Each entry In elementDictionary

                ' Isolate the class name of the current element.
                firstDotIndex = entry.Key.IndexOf(".")
                currentClassName.Append(entry.Key, 0, firstDotIndex)

                ' Determine whether we need to increment to the next 
                ' element class.
                If currentClassName.ToString() <> _
                    compareClassName.ToString() Then

                    ' Increment the index to the next top-level node 
                    ' in the tree view.
                    nodeIndex += 1

                    ' Update the class name to compare with.
                    compareClassName.Remove(0, compareClassName.Length)
                    compareClassName.Append(entry.Key)
                    compareClassName.Remove(firstDotIndex, _
                        compareClassName.Length - firstDotIndex)

                    ' Add a new top-level node to the tree view.
                    Dim node As New TreeNode(compareClassName.ToString())
                    treeView1.Nodes.Add(node)
                End If

                ' Get the text for the new second-level node.
                nodeText.Append(entry.Key, firstDotIndex + 1, _
                    entry.Key.Length - firstDotIndex - 1)

                ' Create and insert the new second-level node.
                Dim newNode As New TreeNode(nodeText.ToString())
                newNode.Name = entry.Key
                treeView1.Nodes(nodeIndex).Nodes.Add(newNode)

                currentClassName.Remove(0, currentClassName.Length)
                nodeText.Remove(0, nodeText.Length)
            Next entry

            treeView1.EndUpdate()
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            ' Do nothing further if visual styles are disabled.
            If Not Application.RenderWithVisualStyles Then
                Me.Text = "Visual styles are disabled."
                TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, _
                    Me.Location, Me.ForeColor)
                Return
            End If

            ' Draw the element description.
            TextRenderer.DrawText(e.Graphics, _
                elementDescription.ToString(), Me.Font, _
                descriptionRect, Me.ForeColor, _
                TextFormatFlags.WordBreak)

            ' Draw the element, if an element is selected.
            If drawElement Then
                renderer.DrawBackground(e.Graphics, Me.displayRect)
            End If
        End Sub

        ' Set the element to draw.
        Private Sub treeView1_AfterSelect(ByVal sender As Object, _
            ByVal e As TreeViewEventArgs) Handles treeView1.AfterSelect

            ' Clear the element description.
            elementDescription.Remove(0, elementDescription.Length)

            ' If the user clicked a first-level node, disable drawing.
            If e.Node.Nodes.Count > 0 Then
                drawElement = False
                elementDescription.Append("No element is selected")
                domainUpDown1.Enabled = False

            ' The user clicked an element node.
            Else
                ' Add the element name to the description.
                elementDescription.Append(e.Node.Text)

                ' Get the element that corresponds to the selected  
                ' node's name.
                Dim key As String = e.Node.Name
                element = elementDictionary(key)

                ' Disable resizing if the element is not defined.
                If Not VisualStyleRenderer.IsElementDefined(element) Then
                    drawElement = False
                    elementDescription.Append(" is not defined.")
                    domainUpDown1.Enabled = False
                Else
                    ' Set the element to the renderer.
                    drawElement = True
                    renderer.SetParameters(element)
                    elementDescription.Append(" is defined.")

                    ' Get the system-defined size of the element.
                    Dim g As Graphics = Me.CreateGraphics()
                    currentTrueSize = renderer.GetPartSize(g, _
                        ThemeSizeType.True)
                    g.Dispose()
                    displayRect.Size = currentTrueSize

                    domainUpDown1.Enabled = True
                    domainUpDown1.SelectedIndex = 2
                End If
            End If
            Invalidate()
        End Sub

        ' Resize the element display area.
        Private Sub domainUpDown1_SelectedItemChanged(ByVal sender As Object, _
            ByVal e As EventArgs) _
            Handles domainUpDown1.SelectedItemChanged

            Select Case CInt(domainUpDown1.SelectedItem)
                Case CInt(elementSizes.TrueSize)
                    displayRect.Size = currentTrueSize
                Case CInt(elementSizes.Medium)
                    displayRect.Size = _
                        New Size(displayRectFull.Width / 2, _
                        displayRectFull.Height / 2)
                Case CInt(elementSizes.Large)
                    displayRect.Size = displayRectFull.Size
            End Select

            Invalidate()
        End Sub

        ' These values represent the options in the UpDown control.
        Private Enum elementSizes
            TrueSize
            Medium
            Large
        End Enum

    End Class
End Namespace
' </Snippet0>