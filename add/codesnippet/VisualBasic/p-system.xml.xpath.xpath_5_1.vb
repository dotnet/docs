    Shared Sub XPathNavigatorMethods_MoveToNext()

        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()
        Dim nodeset As XPathNodeIterator = navigator.Select("descendant::book[author/last-name='Melville']")

        While nodeset.MoveNext()
            ' Clone iterator here when working with it.
            RecursiveWalk(nodeset.Current.Clone())
        End While

    End Sub

    Shared Sub RecursiveWalk(ByVal navigator As XPathNavigator)

        Select Case navigator.NodeType
            Case XPathNodeType.Element
                If navigator.Prefix = String.Empty Then
                    Console.WriteLine("<{0}>", navigator.LocalName)
                Else
                    Console.Write("<{0}:{1}>", navigator.Prefix, navigator.LocalName)
                    Console.WriteLine(vbTab + navigator.NamespaceURI)
                End If
            Case XPathNodeType.Text
                Console.WriteLine(vbTab + navigator.Value)
        End Select

        If navigator.MoveToFirstChild() Then
            Do
                RecursiveWalk(navigator)
            Loop While (navigator.MoveToNext())

            navigator.MoveToParent()
            If (navigator.NodeType = XPathNodeType.Element) Then
                Console.WriteLine("</{0}>", navigator.Name)
            End If
        Else
            If navigator.NodeType = XPathNodeType.Element Then
                Console.WriteLine("</{0}>", navigator.Name)
            End If
        End If

    End Sub