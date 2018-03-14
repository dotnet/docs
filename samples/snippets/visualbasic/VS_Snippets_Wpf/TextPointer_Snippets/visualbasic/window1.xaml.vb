Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes

Imports System.IO

Imports System.Text

Namespace TextPointer_Snippets
    Partial Public Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub WindowLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
            Dim x As Integer = GetOffsetRelativeToParagraph(fdsv.Document.ContentStart)

            Dim tp As TextPointer = FindFirstRunInTextContainer(fdsv.Document)
        End Sub

        ' <Snippet_TextPointer_GetInsertionPosition>
        ' Tests to see if the specified TextElement is empty (has no printatble content).
        Private Function IsElementEmpty(ByVal element As TextElement) As Boolean
            ' Find starting and ending insertion positions in the element.
            ' Inward-facing directions are used to make sure that insertion position
            ' will be found correctly in case when the element may contain inline 
            ' formatting elements (such as a Span or Run that contains Bold or Italic elements).
            Dim start As TextPointer = element.ContentStart.GetInsertionPosition(LogicalDirection.Forward)
            Dim [end] As TextPointer = element.ContentEnd.GetInsertionPosition(LogicalDirection.Backward)

            ' The element has no printable content if its first and last insertion positions are equal.
            Return start.CompareTo([end]) = 0

        End Function ' End IsEmptyElement method.
        ' </Snippet_TextPointer_GetInsertionPosition>

        Private Sub GetXAML(ByVal sender As Object, ByVal args As RoutedEventArgs)
            tb.Text = GetXaml_Renamed(fdsv.Document.Blocks.FirstBlock)

            Dim tp As TextPointer = bold.ContentStart

            tp.InsertTextInRun("Inserted text 1...")
            tp.InsertTextInRun("Inserted text 2...")


            tb.Text += GetXaml_Renamed(fdsv.Document.Blocks.FirstBlock)
            tb.Text += GetXaml_Renamed(fdsv.Document.Blocks.FirstBlock.NextBlock)

            buic.ContentStart.InsertParagraphBreak()

            tb.Text += GetXaml_Renamed(fdsv.Document.Blocks.FirstBlock)
            tb.Text += GetXaml_Renamed(fdsv.Document.Blocks.FirstBlock.NextBlock)
            tb.Text += GetXaml_Renamed(fdsv.Document.Blocks.FirstBlock.NextBlock.NextBlock)
        End Sub

        Private Sub BoldMe(ByVal sender As Object, ByVal args As RoutedEventArgs)
            Dim tr As New TextRange(fdsv.Document.ContentStart, fdsv.Document.ContentEnd)
            Dim s As Stream = New MemoryStream()
            tr.Save(s, DataFormats.Xaml)

            Dim bs As Stream = BoldFormatStream(s, DataFormats.Xaml)

            tr.Load(bs, DataFormats.Xaml)
        End Sub

        ' <Snippet_TextPointer_GetNextContextPosition>
        ' This method will extract and return a string that contains a representation of 
        ' the XAML structure of content elements in a given TextElement.        
        Private Function GetXaml_Renamed(ByVal element As TextElement) As String
            Dim buffer As New StringBuilder()

            ' Position a "navigator" pointer before the opening tag of the element.
            Dim navigator As TextPointer = element.ElementStart

            Do While navigator.CompareTo(element.ElementEnd) < 0
                Select Case navigator.GetPointerContext(LogicalDirection.Forward)
                    Case TextPointerContext.ElementStart
                        ' Output opening tag of a TextElement
                        buffer.AppendFormat("<{0}>", navigator.GetAdjacentElement(LogicalDirection.Forward).GetType().Name)
                    Case TextPointerContext.ElementEnd
                        ' Output closing tag of a TextElement
                        buffer.AppendFormat("</{0}>", navigator.GetAdjacentElement(LogicalDirection.Forward).GetType().Name)
                    Case TextPointerContext.EmbeddedElement
                        ' Output simple tag for embedded element
                        buffer.AppendFormat("<{0}/>", navigator.GetAdjacentElement(LogicalDirection.Forward).GetType().Name)
                    Case TextPointerContext.Text
                        ' Output the text content of this text run
                        buffer.Append(navigator.GetTextInRun(LogicalDirection.Forward))
                End Select

                ' Advance the naviagtor to the next context position.
                navigator = navigator.GetNextContextPosition(LogicalDirection.Forward)

            Loop ' End while.

            Return buffer.ToString()

        End Function ' End GetXaml method.
        ' </Snippet_TextPointer_GetNextContextPosition>

        ' <Snippet_TextPointer_GetNextInsertionPosition>
        ' This method returns the number of pagragraphs between two
        ' specified TextPointers.
        Private Function GetParagraphCount(ByVal start As TextPointer, ByVal [end] As TextPointer) As Integer
            Dim paragraphCount As Integer = 0

            Do While start IsNot Nothing AndAlso start.CompareTo([end]) < 0
                Dim paragraph As Paragraph = start.Paragraph

                If paragraph IsNot Nothing Then
                    paragraphCount += 1

                    ' Advance start to the end of the current paragraph.
                    start = paragraph.ContentEnd
                End If

                ' Use the GetNextInsertionPosition method to skip over any interceding
                ' content element tags.
                start = start.GetNextInsertionPosition(LogicalDirection.Forward)

            Loop ' End while.

            Return paragraphCount

        End Function ' End GetParagraphCount.
        ' </Snippet_TextPointer_GetNextInsertionPosition>

        ' <Snippet_TextPointer_GetOffsetToPosition>
        Private Structure SelectionOffsets
            Friend Start As Integer
            Friend [End] As Integer
        End Structure

        Private Function GetSelectionOffsetsRTB(ByVal richTextBox As RichTextBox) As SelectionOffsets
            Dim selectionOffsets As SelectionOffsets

            Dim contentStart As TextPointer = richTextBox.Document.ContentStart

            ' Find the offset for the starting and ending TextPointers.
            selectionOffsets.Start = contentStart.GetOffsetToPosition(richTextBox.Selection.Start)
            selectionOffsets.End = contentStart.GetOffsetToPosition(richTextBox.Selection.End)

            Return selectionOffsets
        End Function

        Private Sub RestoreSelectionOffsetsRTB(ByVal richTextBox As RichTextBox, ByVal selectionOffsets As SelectionOffsets)
            Dim contentStart As TextPointer = richTextBox.Document.ContentStart

            ' Use previously determined offsets to create corresponding TextPointers,
            ' and use these to restore the selection.
            richTextBox.Selection.Select(contentStart.GetPositionAtOffset(selectionOffsets.Start), contentStart.GetPositionAtOffset(selectionOffsets.End))
        End Sub
        ' </Snippet_TextPointer_GetOffsetToPosition>

        ' <Snippet_TextPointer_GetOffsetToPosition2>
        ' Calculate and return the relative balance of opening and closing element tags
        ' between two specified TextPointers.
        Private Function GetElementTagBalance(ByVal start As TextPointer, ByVal [end] As TextPointer) As Integer
            Dim balance As Integer = 0

            Do While start IsNot Nothing AndAlso start.CompareTo([end]) < 0
                Dim forwardContext As TextPointerContext = start.GetPointerContext(LogicalDirection.Forward)

                If forwardContext = TextPointerContext.ElementStart Then
                    balance += 1
                ElseIf forwardContext = TextPointerContext.ElementEnd Then
                    balance -= 1
                End If

                start = start.GetNextContextPosition(LogicalDirection.Forward)

            Loop ' End while.

            Return balance

        End Function ' End GetElementTagBalance
        ' </Snippet_TextPointer_GetOffsetToPosition2>

        ' <Snippet_TextPointer_GetPositionAtOffset>
        ' Returns the offset for the specified position relative to any containing paragraph.
        Private Function GetOffsetRelativeToParagraph(ByVal position As TextPointer) As Integer
            ' Adjust the pointer to the closest forward insertion position, and look for any
            ' containing paragraph.
            Dim paragraph As Paragraph = (position.GetInsertionPosition(LogicalDirection.Forward)).Paragraph

            ' Some positions may be not within any Paragraph 
            ' this method returns an offset of -1 to indicate this condition.
            Return If((paragraph Is Nothing), -1, paragraph.ContentStart.GetOffsetToPosition(position))
        End Function

        ' Returns a TextPointer to a specified offset into a specified paragraph. 
        Private Function GetTextPointerRelativeToParagraph(ByVal paragraph As Paragraph, ByVal offsetRelativeToParagraph As Integer) As TextPointer
            ' Verify that the specified offset falls within the specified paragraph.  If the offset is
            ' past the end of the paragraph, return a pointer to the farthest offset position in the paragraph.
            ' Otherwise, return a TextPointer to the specified offset in the specified paragraph.
            Return If((offsetRelativeToParagraph > paragraph.ContentStart.GetOffsetToPosition(paragraph.ContentEnd)), paragraph.ContentEnd, paragraph.ContentStart.GetPositionAtOffset(offsetRelativeToParagraph))
        End Function
        ' </Snippet_TextPointer_GetPositionAtOffset>

        ' <Snippet_TextPointer_GetTextInRun>
        ' Returns a string containing the text content between two specified TextPointers.
        Private Function GetTextBetweenTextPointers(ByVal start As TextPointer, ByVal [end] As TextPointer) As String
            Dim buffer As New StringBuilder()

            Do While start IsNot Nothing AndAlso start.CompareTo([end]) < 0
                If start.GetPointerContext(LogicalDirection.Forward) = TextPointerContext.Text Then
                    buffer.Append(start.GetTextInRun(LogicalDirection.Forward))
                End If

                ' Note that when the TextPointer points into a text run, this skips over the entire
                ' run, not just the current character in the run.
                start = start.GetNextContextPosition(LogicalDirection.Forward)
            Loop
            Return buffer.ToString()

        End Function ' End GetTextBetweenPointers.
        ' </Snippet_TextPointer_GetTextInRun>

        ' <Snippet_TextPointer_IsInSameDocument>
        ' This method first checks for compatible text container scope, and then checks whether
        ' a specified position is between two other specified positions.
        Private Function IsPositionContainedBetween(ByVal positionToTest As TextPointer, ByVal start As TextPointer, ByVal [end] As TextPointer) As Boolean
            ' Note that without this check, an exception will be raised by CompareTo if positionToTest 
            ' does not point to a position that is in the same text container used by start and end.
            '
            ' This test also implicitely indicates whether start and end share a common text container.
            If (Not positionToTest.IsInSameDocument(start)) OrElse (Not positionToTest.IsInSameDocument([end])) Then
                Return False
            End If

            Return start.CompareTo(positionToTest) <= 0 AndAlso positionToTest.CompareTo([end]) <= 0
        End Function
        ' </Snippet_TextPointer_IsInSameDocument>

        ' <Snippet_TextPointer_TextPointer1>
        ' This method returns the position just inside of the first text Run (if any) in a 
        ' specified text container.
        Private Function FindFirstRunInTextContainer(ByVal container As DependencyObject) As TextPointer
            Dim position As TextPointer = Nothing

            If container IsNot Nothing Then
                If TypeOf container Is FlowDocument Then
                    position = (CType(container, FlowDocument)).ContentStart
                ElseIf TypeOf container Is TextBlock Then
                    position = (CType(container, TextBlock)).ContentStart
                Else
                    Return position
                End If
            End If
            '<SnippetFCEParent>
            ' Traverse content in forward direction until the position is immediately after the opening 
            ' tag of a Run element, or the end of content is encountered.
            Do While position IsNot Nothing
                ' Is the current position just after an opening element tag?
                If position.GetPointerContext(LogicalDirection.Backward) = TextPointerContext.ElementStart Then
                    ' If so, is the tag a Run?
                    If TypeOf position.Parent Is Run Then
                        Exit Do
                    End If
                End If

                ' Not what we're looking for on to the next position.
                position = position.GetNextContextPosition(LogicalDirection.Forward)
            Loop
            '</SnippetFCEParent>

            ' This will be either null if no Run is found, or a position just inside of the first Run element in the
            ' specifed text container.  Because position is formed from ContentStart, it will have a logical direction
            ' of Backward.
            Return position
        End Function
        ' </Snippet_TextPointer_TextPointer1>

        ' <Snippet_TextPointer_TextPointer2>
        ' This method will search for a specified word (string) starting at a specified position.
        Private Function FindWordFromPosition(ByVal position As TextPointer, ByVal word As String) As TextPointer
            Do While position IsNot Nothing
                If position.GetPointerContext(LogicalDirection.Forward) = TextPointerContext.Text Then
                    Dim textRun As String = position.GetTextInRun(LogicalDirection.Forward)

                    ' Find the starting index of any substring that matches "word".
                    Dim indexInRun As Integer = textRun.IndexOf(word)
                    If indexInRun >= 0 Then
                        position = position.GetPositionAtOffset(indexInRun)
                        Exit Do
                    End If
                Else
                    position = position.GetNextContextPosition(LogicalDirection.Forward)
                End If
            Loop

            ' position will be null if "word" is not found.
            Return position
        End Function
        ' </Snippet_TextPointer_TextPointer2>

        ' <Snippet_TextRange_Text>
        ' This method returns a plain text representation of a specified FlowDocument.
        Private Function GetTextFromFlowDocument(ByVal flowDoc As FlowDocument) As String
            ' Create a new TextRanage that takes the entire FlowDocument as the current selection.
            Dim flowDocSelection As New TextRange(flowDoc.ContentStart, flowDoc.ContentEnd)

            ' Use the Text property to extract a string that contains the unformatted text contents 
            ' of the FlowDocument.
            Return flowDocSelection.Text
        End Function
        ' </Snippet_TextRange_Text>

        ' <Snippet_TextRange_StartEnd>
        ' This method returns true if two specified selections overlap, including when the
        ' end of one selection serves as the beginning of the other.
        Private Function DoSelectionsOverlap(ByVal selection1 As TextRange, ByVal selection2 As TextRange) As Boolean
            ' Is either end of selection2 contained by selection1?
            If selection1.Contains(selection2.Start) OrElse selection1.Contains(selection2.End) Then
                ' If so, the selections overlap.
                Return True
                ' If not, selection2 may still entirely contain selection1.
                ' Is either end of selection1 contained by seleciotn2?
            ElseIf selection2.Contains(selection1.Start) OrElse selection2.Contains(selection1.End) Then
                ' If so, the selections overlap.
                Return True
                ' If neither selection contains the begging or end of the other selection, 
                'the selections do not overlap.
            Else
                Return False
            End If
        End Function
        ' </Snippet_TextRange_StartEnd>

        ' <Snippet_TextRange_LoadSave>
        ' This method accepts an input stream and a corresponding data format.  The method
        ' will attempt to load the input stream into a TextRange selection, apply Bold formatting
        ' to the selection, save the reformatted selection to an alternat stream, and return 
        ' the reformatted stream.  
        Private Function BoldFormatStream(ByVal inputStream As Stream, ByVal dataFormat As String) As Stream
            ' A text container to read the stream into.
            Dim workDoc As New FlowDocument()
            Dim selection As New TextRange(workDoc.ContentStart, workDoc.ContentEnd)
            Dim outputStream As Stream = New MemoryStream()

            Try
                ' Check for a valid data format, and then attempt to load the input stream
                ' into the current selection.  Note that CanLoad ONLY checks whether dataFormat
                ' is a currently supported data format for loading a TextRange.  It does not 
                ' verify that the stream actually contains the specified format.  An exception 
                ' may be raised when there is a mismatch between the specified data format and 
                ' the data in the stream. 
                If selection.CanLoad(dataFormat) Then
                    selection.Load(inputStream, dataFormat)
                End If
            Catch e As Exception ' Load failure return a null stream. 
                Return outputStream
            End Try

            ' Apply Bold formatting to the selection, if it is not empty.
            If Not selection.IsEmpty Then
                selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold)
            End If

            ' Save the formatted selection to a stream, and return the stream.
            If selection.CanSave(dataFormat) Then
                selection.Save(outputStream, dataFormat)
            End If

            Return outputStream
        End Function
        ' </Snippet_TextRange_LoadSave>

    End Class ' End class Window1

End Namespace ' End namespace TextPointer_Snippets