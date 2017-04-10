'<snippet1>
Imports System
Imports System.Xml
Imports System.Xml.XPath

Public Class XPathExpressionExample

    Public Shared Sub Main()
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim expression1 As XPathExpression = XPathExpression.Compile(".//bk:price/text()*10")  ' Returns a number.
        Dim expression2 As XPathExpression = XPathExpression.Compile("bk:bookstore/bk:book/bk:price")  ' Returns a nodeset.

        Dim manager As XmlNamespaceManager = New XmlNamespaceManager(navigator.NameTable)
        manager.AddNamespace("bk", "http://www.contoso.com/books")

        expression1.SetContext(manager)
        expression2.SetContext(manager)

        Evaluate(expression1, navigator)
        Evaluate(expression2, navigator)

    End Sub

    Public Shared Sub Evaluate(ByVal expression As XPathExpression, ByVal navigator As XPathNavigator)

        Select Case expression.ReturnType
            Case XPathResultType.Number
                Console.WriteLine(navigator.Evaluate(expression))
                Exit Sub

            Case XPathResultType.NodeSet
                Dim nodes As XPathNodeIterator = navigator.Select(expression)
                While nodes.MoveNext()
                    Console.WriteLine(nodes.Current.ToString())
                End While

            Case XPathResultType.Boolean
                If CType(navigator.Evaluate(expression), Boolean) Then
                    Console.WriteLine("True!")
                End If

            Case XPathResultType.String
                Console.WriteLine(navigator.Evaluate(expression))
        End Select

    End Sub
End Class
'</snippet1>