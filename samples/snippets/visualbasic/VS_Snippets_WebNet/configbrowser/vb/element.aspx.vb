' <Snippet91>
Imports System.Web.UI.HtmlControls
' </Snippet91>

Partial Public Class Element
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub


    ' <Snippet92>
    Protected Sub ListView1_ItemDataBound(ByVal sender As Object,
                                          ByVal e As ListViewItemEventArgs)

        Dim ei As ElementItemHeaderInfo =
            TryCast(e.Item.DataItem, ElementItemHeaderInfo)

        Dim ods As ObjectDataSource =
            CType(e.Item.FindControl("InnerObjectDataSource"), 
                ObjectDataSource)
        ods.SelectParameters("sectionName").DefaultValue = ei.SectionName
        ods.SelectParameters("elementName").DefaultValue = ei.Name
        'propertiesListView.DataBind();
        ods.SelectParameters("index").DefaultValue = ei.Index.ToString()
    End Sub
    ' </Snippet92>

    ' <Snippet93>
    Protected Sub ListView1_PreRender(ByVal sender As Object, ByVal e As EventArgs)
        Dim elementName As String =
            (OuterObjectDataSource.SelectParameters("sectionName").DefaultValue.ToString() _
                & "/") + _
            OuterObjectDataSource.SelectParameters("elementName").DefaultValue.ToString()

        If Request.QueryString("Section") IsNot Nothing Then
            elementName = (Request.QueryString("Section") & "/") _
                + Request.QueryString("Element")
        End If

        HeadingLabel.Text = HeadingLabel.Text.Replace("[name]", elementName)

        Dim tableCaption As HtmlGenericControl =
            TryCast(ListView1.FindControl("ElementTableCaption"), 
                System.Web.UI.HtmlControls.HtmlGenericControl)
        If tableCaption IsNot Nothing Then
            tableCaption.InnerText =
                tableCaption.InnerText.Replace("[name]", elementName)
        End If

        Dim noElementsLabel As Label =
            TryCast(ListView1.Controls(0).FindControl("NoElementsLabel"), 
                Label)
        If noElementsLabel IsNot Nothing Then
            noElementsLabel.Text =
                noElementsLabel.Text.Replace("[name]", elementName)
        End If
    End Sub
    ' </Snippet93>

    ' <Snippet94>
    Protected Function GetElementHeaderID(ByVal item As ListViewItem) _
        As String

        Return "hdrElement" & item.DataItemIndex.ToString()
    End Function
    Protected Function GetPropertyHeaderID(ByVal item As ListViewItem) _
        As String

        Return "hdrProperty" & CType(item.DataItem, ElementItemInfo).UniqueID
    End Function
    ' </Snippet94>

    ' <Snippet95>
    Protected Function GetColumnHeaderIDs(ByVal item As ListViewDataItem,
                                          ByVal columnHeader As String) _
                                      As String

        Dim elementHeaderID As String =
            GetElementHeaderID(
                CType(item.NamingContainer.NamingContainer, 
                    ListViewItem))

        Dim propertyHeaderID As String = GetPropertyHeaderID(item)

        Return String.Format("{0} {1} {2}",
                             elementHeaderID,
                             propertyHeaderID,
                             columnHeader)
    End Function
    ' </Snippet95>

End Class