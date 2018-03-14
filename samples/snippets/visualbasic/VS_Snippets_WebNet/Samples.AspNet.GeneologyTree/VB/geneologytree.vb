 ' <snippet2>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB.Controls

    <AspNetHostingPermission(SecurityAction.Demand, _
      Level:=AspNetHostingPermissionLevel.Minimal), _
      AspNetHostingPermission(SecurityAction.InheritanceDemand, _
      Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class GeneologyTree
        Inherits HierarchicalDataBoundControl

        Dim MaxDepth As Integer = 0

        Private aRootNode As TreeNode
        Public ReadOnly Property RootNode() As TreeNode
            Get
                If aRootNode Is Nothing Then
                    aRootNode = New TreeNode(String.Empty)
                End If
                Return aRootNode
            End Get
        End Property

        Private alNodes As ArrayList
        Public ReadOnly Property Nodes() As ArrayList
            Get
                If alNodes Is Nothing Then
                    alNodes = New ArrayList()
                End If
                Return alNodes
            End Get
        End Property
        ' <snippet3>

        Public Property DataTextField() As String
            Get
                Dim o As Object = ViewState("DataTextField")
                If o Is Nothing Then
                    Return String.Empty
                Else
                    Return CStr(o)
                End If
            End Get
            Set(ByVal value As String)
                ViewState("DataTextField") = value
                If Initialized Then
                    OnDataPropertyChanged()
                End If
            End Set
        End Property
        ' </snippet3>

        ' <snippet4>
        Protected Overrides Sub PerformDataBinding()
            MyBase.PerformDataBinding()

            ' Do not attempt to bind data if there is no
            ' data source set.
            If Not IsBoundUsingDataSourceID AndAlso DataSource Is Nothing Then
                Return
            End If

            Dim view As HierarchicalDataSourceView = GetData(RootNode.DataPath)

            If view Is Nothing Then
                Throw New InvalidOperationException _
                ("No view returned by data source control.")
            End If

            Dim enumerable As IHierarchicalEnumerable = view.Select()
            If Not (enumerable Is Nothing) Then

                Nodes.Clear()

                Try
                    RecurseDataBindInternal(RootNode, enumerable, 1)
                Finally
                End Try
            End If

        End Sub ' PerformDataBinding

        ' <snippet5>
        Private Sub RecurseDataBindInternal(ByVal node As TreeNode, _
            ByVal enumerable As IHierarchicalEnumerable, _
            ByVal depth As Integer)

            Dim item As Object
            For Each item In enumerable

                Dim data As IHierarchyData = enumerable.GetHierarchyData(item)

                If Not data Is Nothing Then

                    ' Create an object that represents the bound data
                    ' to the control.
                    Dim newNode As New TreeNode()
                    Dim rvnode As New RootViewNode()

                    rvnode.Node = newNode
                    rvnode.Depth = depth

                    ' The dataItem is not just a string, but potentially
                    ' an XML node or some other container. 
                    ' If DataTextField is set, use it to determine which 
                    ' field to render. Otherwise, use the first field.                    
                    If DataTextField.Length > 0 Then
                        newNode.Text = DataBinder.GetPropertyValue _
                        (data, DataTextField, Nothing)
                    Else
                        Dim props As PropertyDescriptorCollection = _
                        TypeDescriptor.GetProperties(data)

                        ' Set the "default" value of the node.
                        newNode.Text = String.Empty

                        ' Set the true data-bound value of the TextBox,
                        ' if possible.
                        If props.Count >= 1 Then
                            If Not props(0).GetValue(data) Is Nothing Then
                                newNode.Text = props(0).GetValue(data).ToString()
                            End If
                        End If
                    End If

                    Nodes.Add(rvnode)

                    If data.HasChildren Then
                        Dim newEnumerable As IHierarchicalEnumerable = _
                            data.GetChildren()
                        If Not (newEnumerable Is Nothing) Then
                            RecurseDataBindInternal(newNode, _
                            newEnumerable, depth + 1)
                        End If
                    End If

                    If MaxDepth < depth Then
                        MaxDepth = depth
                    End If
                End If
            Next item

        End Sub 'RecurseDataBindInternal

        ' </snippet4>
        ' </snippet5>
        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)

            writer.WriteLine("<PRE>")
            Dim currentDepth As Integer = 1
            Dim currentTextLen As Integer = 0

            Dim rvnode As RootViewNode
            For Each rvnode In Nodes
                If rvnode.Depth = currentDepth Then
                    Dim output As String = "  " + rvnode.Node.Text + "  "
                    writer.Write(output)
                    currentTextLen = currentTextLen + output.Length
                Else
                    writer.WriteLine("")

                    ' Some very basic whitespace formatting.
                    ' The implicit conversion to an Integer is fine, as 
                    ' a general estimate is acceptable for this 
                    ' simple example.
                    Dim halfLine As Integer = CInt(currentTextLen / 2)
                    Dim i As Integer
                    For i = 0 To halfLine
                        writer.Write(" "c)
                    Next i
                    writer.Write("|"c)
                    writer.WriteLine("")
                    currentDepth += 1
                    Dim j As Integer
                    For j = 0 To halfLine
                        writer.Write(" "c)
                    Next j
                    Dim output As String = "  " + rvnode.Node.Text + "  "
                    writer.Write(output)
                    currentTextLen = currentTextLen + output.Length
                End If
            Next rvnode
            writer.WriteLine("</PRE>")

        End Sub 'Render


        Private Class RootViewNode
            Public Node As TreeNode
            Public Depth As Integer
        End Class 'RootViewNode
    End Class 'GeneologyTree
End Namespace
' </snippet2>