'<snippet4>
Imports System.Xml
Imports System.Xml.XPath
Module Module1

    Sub Main()
        Dim doc As New XPathDocument("contosoBooks.xml")
        Dim nav As XPathNavigator = doc.CreateNavigator()

        Dim expr As XPathExpression
        expr = nav.Compile("/bookstore/book")

        expr.AddSort("price", XmlSortOrder.Descending, _
                          XmlCaseOrder.None, "", XmlDataType.Number)

        Dim iterator As XPathNodeIterator = nav.Select(expr)
        Do While iterator.MoveNext()

            If (iterator.Current.HasChildren()) Then
                Dim childIter As XPathNodeIterator = _
                iterator.Current.SelectChildren(XPathNodeType.Element)
                Do While childIter.MoveNext()
                    Console.WriteLine(childIter.Current.Value)
                Loop

            End If
        Loop

    End Sub

End Module

'</snippet4>
