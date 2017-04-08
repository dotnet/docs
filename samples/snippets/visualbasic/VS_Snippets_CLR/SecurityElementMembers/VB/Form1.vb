' This sample demonstrates how to use  members of the SecurityElement class.
' The sample creates a SecurityElement for the root of the XML tree and 
' demonstrates how to add attributes and child elements.
'<Snippet1>
Imports System
Imports System.Security
Imports System.Collections



Class SecurityElementMembers

    <STAThread()> _
    Shared Sub Main(ByVal args() As String)
        '<Snippet3>
        Dim xmlRootElement As New SecurityElement("RootTag", "XML security tree")
        '</Snippet3>
        AddAttribute(xmlRootElement, "creationdate", DateTime.Now.ToString())
        AddChildElement(xmlRootElement, "destroytime", DateTime.Now.AddSeconds(1.0).ToString())

        '<Snippet2>
        Dim windowsRoleElement As New SecurityElement("WindowsMembership.WindowsRole")
        '</Snippet2>
        '<Snippet4>
        windowsRoleElement.AddAttribute("version", "1.00")
        '</Snippet4>
        ' Add a child element and a creationdate attribute.
        AddChildElement(windowsRoleElement, "BabyElement", "This is a child element")
        AddAttribute(windowsRoleElement, "creationdate", DateTime.Now.ToString())

        '<Snippet5>
        xmlRootElement.AddChild(windowsRoleElement)
        '</Snippet5>
        CompareAttributes(xmlRootElement, "creationdate")
        ConvertToHashTable(xmlRootElement)

        DisplaySummary(xmlRootElement)

        ' Determine if the security element is too old to keep.
        xmlRootElement = DestroyTree(xmlRootElement)
        If Not (xmlRootElement Is Nothing) Then
            '<Snippet23>
            Dim elementInXml As String = xmlRootElement.ToString()
            '</Snippet23>
            Console.WriteLine(elementInXml)
        End If

        Console.WriteLine("This sample completed successfully; " + "press Enter to exit.")
        Console.ReadLine()

    End Sub 'Main


    ' Add an attribute to the specified security element.
    Private Shared Function AddAttribute(ByVal xmlElement As SecurityElement, ByVal attributeName As String, ByVal attributeValue As String) As SecurityElement
        If Not (xmlElement Is Nothing) Then
            ' Verify that the attribute name and value are valid XML formats.
            '<Snippet6>
            '<Snippet7>
            If SecurityElement.IsValidAttributeName(attributeName) AndAlso SecurityElement.IsValidAttributeValue(attributeValue) Then
                '</Snippet7>
                '</Snippet6>
                ' Add the attribute to the security element.
                '<Snippet8>
                xmlElement.AddAttribute(attributeName, attributeValue)
            End If
            '</Snippet8>
        End If
        Return xmlElement

    End Function 'AddAttribute


    ' Add a child element to the specified security element.
    Private Shared Function AddChildElement(ByVal parentElement As SecurityElement, ByVal tagName As String, ByVal tagText As String) As SecurityElement
        If Not (parentElement Is Nothing) Then
            ' Ensure that the tag text is in valid XML format.
            '<Snippet9>
            If Not SecurityElement.IsValidText(tagText) Then
                '</Snippet9>
                ' Replace invalid text with valid XML text 
                ' to enforce proper XML formatting.
                '<Snippet19>
                tagText = SecurityElement.Escape(tagText)
            End If
            '</Snippet19>

            ' Determine whether the tag is in valid XML format.
            '<Snippet10>
            If SecurityElement.IsValidTag(tagName) Then
                '</Snippet10>
                '<Snippet24>
                Dim childElement As SecurityElement
                childElement = parentElement.SearchForChildByTag(tagName)
                '</Snippet24>
                If Not (childElement Is Nothing) Then
                    '<Snippet25>
                    Dim elementText As String
                    elementText = parentElement.SearchForTextOfTag(tagName)
                    '</Snippet25>
                    If Not elementText.Equals(tagText) Then
                        ' Add child element to the parent security element.
                        parentElement.AddChild(New SecurityElement(tagName, tagText))
                    End If
                Else
                    ' Add child element to the parent security element.
                    parentElement.AddChild(New SecurityElement(tagName, tagText))
                End If
            End If
        End If
        Return parentElement

    End Function 'AddChildElement


    ' Create and display a summary sentence 
    ' about the specified security element.
    Private Shared Sub DisplaySummary(ByVal xmlElement As SecurityElement)
        ' Retrieve tag name for the security element.
        '<Snippet11>
        Dim xmlTreeName As String = xmlElement.Tag.ToString()
        '</Snippet11>
        ' Retrieve tag text for the security element.
        '<Snippet12>
        Dim xmlTreeDescription As String = xmlElement.Text
        '</Snippet12>
        ' Retrieve value of the creationdate attribute.
        '<Snippet13>
        Dim xmlCreationDate As String = xmlElement.Attribute("creationdate")
        '</Snippet13>
        ' Retrieve the number of children under the security element.
        '<Snippet14>
        Dim childrenCount As String = xmlElement.Children.Count.ToString()
        '</Snippet14>
        Dim outputMessage As String = "The security XML tree named " + xmlTreeName
        outputMessage += "(" + xmlTreeDescription + ")"
        outputMessage += " was created on " + xmlCreationDate + " and "
        outputMessage += "contains " + childrenCount + " child elements."

        Console.WriteLine(outputMessage)

    End Sub 'DisplaySummary


    ' Compare the first two occurrences of an attribute 
    ' in the specified security element.
    Private Shared Sub CompareAttributes(ByVal xmlElement As SecurityElement, ByVal attributeName As String)
        ' Create a hash table containing the security element's attributes.
        '<Snippet15>
        Dim attributeKeys As Hashtable = xmlElement.Attributes
        Dim attributeValue As String = attributeKeys(attributeName).ToString()
        '</Snippet15>
        Dim xmlChild As SecurityElement
        For Each xmlChild In xmlElement.Children
            If attributeValue.Equals(xmlChild.Attribute(attributeName)) Then
            End If
        Next xmlChild
        ' The security elements were created at the exact same time.
    End Sub 'CompareAttributes


    ' Convert the contents of the specified security element 
    ' to hash codes stored in a hash table.
    Private Shared Sub ConvertToHashTable(ByVal xmlElement As SecurityElement)
        ' Create a hash table to hold hash codes of the security elements.
        '<Snippet16>
        Dim xmlAsHash As New Hashtable()
        Dim rootIndex As Integer = xmlElement.GetHashCode()
        xmlAsHash.Add(rootIndex, "root")
        '</Snippet16>
        Dim parentNum As Integer = 0

        Dim xmlParent As SecurityElement
        For Each xmlParent In xmlElement.Children
            parentNum += 1
            xmlAsHash.Add(xmlParent.GetHashCode(), "parent" + parentNum.ToString())
            If Not (xmlParent.Children Is Nothing) AndAlso xmlParent.Children.Count > 0 Then
                Dim childNum As Integer = 0
                Dim xmlChild As SecurityElement
                For Each xmlChild In xmlParent.Children
                    childNum += 1
                    xmlAsHash.Add(xmlChild.GetHashCode(), "child" + childNum.ToString())
                Next xmlChild
            End If
        Next xmlParent

    End Sub 'ConvertToHashTable


    ' Delete the specified security element if the current time is past
    ' the time stored in the destroytime tag.
    Private Shared Function DestroyTree(ByVal xmlElement As SecurityElement) As SecurityElement
        Dim localXmlElement As SecurityElement = xmlElement
        Dim destroyElement As SecurityElement = localXmlElement.SearchForChildByTag("destroytime")

        ' Verify that a destroytime tag exists.
        '<Snippet17>
        If Not (localXmlElement.SearchForChildByTag("destroytime") Is Nothing) Then
            '</Snippet17>
            ' Retrieve the destroytime text to get the time 
            ' the tree can be destroyed.
            '<Snippet18>
            Dim storedDestroyTime As String = localXmlElement.SearchForTextOfTag("destroytime")
            '</Snippet18>
            Dim destroyTime As DateTime = DateTime.Parse(storedDestroyTime)
            If DateTime.Now > destroyTime Then
                localXmlElement = Nothing
                Console.WriteLine("The XML security tree has been deleted.")
            End If
        End If

        ' Verify that xmlElement is of type SecurityElement.
        '<Snippet21>
        If xmlElement.GetType().Equals(GetType(System.Security.SecurityElement)) Then
            '</Snippet21>
            ' Determine whether the localXmlElement object 
            ' differs from xmlElement.
            '<Snippet20>
            If xmlElement.Equals(localXmlElement) Then
                '</Snippet20>
                ' Verify that the tags, attributes and children of the
                ' two security elements are identical.
                '<Snippet22>
                If xmlElement.Equal(localXmlElement) Then
                    '</Snippet22>
                    ' Return the original security element.
                    Return xmlElement
                End If
            End If
        End If

        ' Return the modified security element.
        Return localXmlElement

    End Function 'DestroyTree
End Class 'SecurityElementMembers
'
' This sample produces the following output:
' 
' The security XML tree named RootTag(XML security tree) 
' was created on 2/23/2004 1:23:00 PM and contains 2 child elements.
'<RootTag creationdate="2/23/2004 1:23:00 PM">XML security tree
'   <destroytime>2/23/2004 1:23:01 PM</destroytime>
'   <WindowsMembership.WindowsRole version="1.00"
'                                  creationdate="2/23/2004 1:23:00 PM">
'      <BabyElement>This is a child element.</BabyElement>
'   </WindowsMembership.WindowsRole>
'</RootTag>
'
'This sample completed successfully; press Exit to continue.
'</Snippet1>