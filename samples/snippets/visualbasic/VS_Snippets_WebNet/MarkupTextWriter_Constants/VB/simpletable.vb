Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class SimpleTable
        Inherits WebControl

        Private Const maxRows As Integer = 3
        Private Const maxCols As Integer = 5


        ' <snippet1>
        ' Override the RenderControl method to create a simple table.
        Public Overrides Sub RenderControl(ByVal writer As HtmlTextWriter)

            ' <snippet2>
            ' <snippet9>
            ' Create the opening tag of a table element
            ' with styles by using the HtmlTextWriter class. 
            writer.Write(HtmlTextWriter.TagLeftChar)
            writer.Write("table")
            ' </snippet9>

            ' <snippet5>       
            ' Write a space and a FontWeight
            ' attribute to the tag.
            writer.Write(HtmlTextWriter.SpaceChar)
            writer.Write("FontWeight")

            ' Set the FontWeight attribute to Bold.
            writer.Write(HtmlTextWriter.StyleEqualsChar)
            writer.Write(HtmlTextWriter.DoubleQuoteChar)
            writer.Write("bold")
            writer.Write(HtmlTextWriter.DoubleQuoteChar)

            ' </snippet5> 
            writer.Write(HtmlTextWriter.SpaceChar)

            ' Write the FontSize attribute and set it to
            ' 14pt.
            writer.Write("FontSize")
            writer.Write(HtmlTextWriter.StyleEqualsChar)
            writer.Write(HtmlTextWriter.DoubleQuoteChar)
            writer.Write("14pt")
            writer.Write(HtmlTextWriter.DoubleQuoteChar)
            writer.Write(HtmlTextWriter.SpaceChar)

            ' <snippet6>      
            ' Create a border attribute for the table,
            ' and set it to 1.
            writer.Write("border")
            writer.Write(HtmlTextWriter.EqualsDoubleQuoteString)
            writer.Write("1")
            writer.Write(HtmlTextWriter.DoubleQuoteChar)
            ' </snippet6>

            ' Write the last character of the table's 
            ' opening tag.
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            ' </snippet2>
            ' Indent for child elements for the table.
            writer.Indent += 1

            ' <snippet3>
            ' Create the number of <tr> elements
            ' specified in the maxRows constant.
            Dim i As Integer
            For i = 0 To maxRows - 1

                writer.WriteFullBeginTag("tr")
                writer.WriteLine()

                writer.Indent += 1

                ' In each row create the number of
                ' <td> elements specified in the
                ' maxCols constant.
                Dim j As Integer
                For j = 0 To maxCols - 1

                    writer.WriteBeginTag("td")
                    writer.WriteAttribute("valign", "top")
                    writer.WriteAttribute("bgcolor", "lightblue")
                    writer.Write(HtmlTextWriter.TagRightChar)

                    writer.Write(("Cell (" & i.ToString() + "," + j.ToString() & ")"))

                    writer.WriteEndTag("td")
                    writer.WriteLine()
                Next j

                writer.Indent -= 1
                writer.WriteEndTag("tr")
                writer.WriteLine()
            Next i
            ' </snippet3>
            writer.Indent -= 1

            ' <snippet4>
            ' Write the closing tag of a table element.
            writer.Write(HtmlTextWriter.EndTagLeftChars)
            writer.Write("table")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            ' </snippet4>
        End Sub
        ' </snippet1>

    End Class

End Namespace