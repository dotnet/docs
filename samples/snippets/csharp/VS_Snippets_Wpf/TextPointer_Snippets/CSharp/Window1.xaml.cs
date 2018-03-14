using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.IO;

using System.Text;

namespace TextPointer_Snippets
{
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        void WindowLoaded(Object sender, RoutedEventArgs args)
        {
            int x = GetOffsetRelativeToParagraph(fdsv.Document.ContentStart);

            TextPointer tp = FindFirstRunInTextContainer(fdsv.Document);
        }

        // <Snippet_TextPointer_GetInsertionPosition>
        // Tests to see if the specified TextElement is empty (has no printatble content).
        bool IsElementEmpty(TextElement element)
        {
            // Find starting and ending insertion positions in the element.
            // Inward-facing directions are used to make sure that insertion position
            // will be found correctly in case when the element may contain inline 
            // formatting elements (such as a Span or Run that contains Bold or Italic elements).
            TextPointer start = element.ContentStart.GetInsertionPosition(LogicalDirection.Forward);
            TextPointer end = element.ContentEnd.GetInsertionPosition(LogicalDirection.Backward);
             
            // The element has no printable content if its first and last insertion positions are equal.
            return start.CompareTo(end) == 0;
        
        } // End IsEmptyElement method.
        // </Snippet_TextPointer_GetInsertionPosition>

        void GetXAML(object sender, RoutedEventArgs args) 
        {
            tb.Text = GetXaml(fdsv.Document.Blocks.FirstBlock);

            TextPointer tp = bold.ContentStart;

            tp.InsertTextInRun("Inserted text 1...");
            tp.InsertTextInRun("Inserted text 2...");


            tb.Text += GetXaml(fdsv.Document.Blocks.FirstBlock);
            tb.Text += GetXaml(fdsv.Document.Blocks.FirstBlock.NextBlock);
            
            buic.ContentStart.InsertParagraphBreak();

            tb.Text += GetXaml(fdsv.Document.Blocks.FirstBlock);
            tb.Text += GetXaml(fdsv.Document.Blocks.FirstBlock.NextBlock);
            tb.Text += GetXaml(fdsv.Document.Blocks.FirstBlock.NextBlock.NextBlock);
        }

        void BoldMe(object sender, RoutedEventArgs args)
        {
            TextRange tr = new TextRange(fdsv.Document.ContentStart, fdsv.Document.ContentEnd);
            Stream s = new MemoryStream();
            tr.Save(s, DataFormats.Xaml);

            Stream bs = BoldFormatStream(s, DataFormats.Xaml);

            tr.Load(bs, DataFormats.Xaml);
        }

        // <Snippet_TextPointer_GetNextContextPosition>
        // This method will extract and return a string that contains a representation of 
        // the XAML structure of content elements in a given TextElement.        
        string GetXaml(TextElement element)
        {
            StringBuilder buffer = new StringBuilder();
         
            // Position a "navigator" pointer before the opening tag of the element.
            TextPointer navigator = element.ElementStart;

            while (navigator.CompareTo(element.ElementEnd) < 0)
            {
                switch (navigator.GetPointerContext(LogicalDirection.Forward))
                {
                    case TextPointerContext.ElementStart : 
                        // Output opening tag of a TextElement
                        buffer.AppendFormat("<{0}>", navigator.GetAdjacentElement(LogicalDirection.Forward).GetType().Name);
                        break;
                    case TextPointerContext.ElementEnd :
                        // Output closing tag of a TextElement
                        buffer.AppendFormat("</{0}>", navigator.GetAdjacentElement(LogicalDirection.Forward).GetType().Name);
                        break;
                    case TextPointerContext.EmbeddedElement :
                        // Output simple tag for embedded element
                        buffer.AppendFormat("<{0}/>", navigator.GetAdjacentElement(LogicalDirection.Forward).GetType().Name);
                        break;
                    case TextPointerContext.Text :
                        // Output the text content of this text run
                        buffer.Append(navigator.GetTextInRun(LogicalDirection.Forward));
                        break;
                }
         
                // Advance the naviagtor to the next context position.
                navigator = navigator.GetNextContextPosition(LogicalDirection.Forward);
            
            } // End while.

            return buffer.ToString();

        } // End GetXaml method.
        // </Snippet_TextPointer_GetNextContextPosition>

        // <Snippet_TextPointer_GetNextInsertionPosition>
        // This method returns the number of pagragraphs between two
        // specified TextPointers.
        int GetParagraphCount(TextPointer start, TextPointer end)
        {
            int paragraphCount = 0;
         
            while (start != null && start.CompareTo(end) < 0)
            {
                Paragraph paragraph = start.Paragraph;
         
                if (paragraph != null)
                {
                    paragraphCount++;
         
                    // Advance start to the end of the current paragraph.
                    start = paragraph.ContentEnd;
                 }
         
                 // Use the GetNextInsertionPosition method to skip over any interceding
                 // content element tags.
                 start = start.GetNextInsertionPosition(LogicalDirection.Forward);

             } // End while.
         
                 return paragraphCount;
         
        }  // End GetParagraphCount.
        // </Snippet_TextPointer_GetNextInsertionPosition>

        // <Snippet_TextPointer_GetOffsetToPosition>
        struct SelectionOffsets { internal int Start; internal int End; }
         
        SelectionOffsets GetSelectionOffsetsRTB(RichTextBox richTextBox)
        {
            SelectionOffsets selectionOffsets;
         
            TextPointer contentStart = richTextBox.Document.ContentStart;

            // Find the offset for the starting and ending TextPointers.
            selectionOffsets.Start = contentStart.GetOffsetToPosition(richTextBox.Selection.Start);
            selectionOffsets.End = contentStart.GetOffsetToPosition(richTextBox.Selection.End);

            return selectionOffsets;
        }

        void RestoreSelectionOffsetsRTB(RichTextBox richTextBox, SelectionOffsets selectionOffsets)
        {
            TextPointer contentStart = richTextBox.Document.ContentStart;
         
            // Use previously determined offsets to create corresponding TextPointers,
            // and use these to restore the selection.
            richTextBox.Selection.Select(
               contentStart.GetPositionAtOffset(selectionOffsets.Start),
               contentStart.GetPositionAtOffset(selectionOffsets.End)
            );
        }
        // </Snippet_TextPointer_GetOffsetToPosition>

        // <Snippet_TextPointer_GetOffsetToPosition2>
        // Calculate and return the relative balance of opening and closing element tags
        // between two specified TextPointers.
        int GetElementTagBalance(TextPointer start, TextPointer end)
        {
            int balance = 0;
         
            while (start != null && start.CompareTo(end) < 0)
            {
                TextPointerContext forwardContext = start.GetPointerContext(LogicalDirection.Forward);
         
                if (forwardContext == TextPointerContext.ElementStart)     balance++;
                else if (forwardContext == TextPointerContext.ElementEnd)  balance--;
                     
                start = start.GetNextContextPosition(LogicalDirection.Forward);
            
            } // End while.
         
            return balance;

        } // End GetElementTagBalance
        // </Snippet_TextPointer_GetOffsetToPosition2>

        // <Snippet_TextPointer_GetPositionAtOffset>
        // Returns the offset for the specified position relative to any containing paragraph.
        int GetOffsetRelativeToParagraph(TextPointer position)
        {
            // Adjust the pointer to the closest forward insertion position, and look for any
            // containing paragraph.
            Paragraph paragraph = (position.GetInsertionPosition(LogicalDirection.Forward)).Paragraph;

            // Some positions may be not within any Paragraph; 
            // this method returns an offset of -1 to indicate this condition.
            return (paragraph == null) ? -1 : paragraph.ContentStart.GetOffsetToPosition(position);
        }
        
        // Returns a TextPointer to a specified offset into a specified paragraph. 
        TextPointer GetTextPointerRelativeToParagraph(Paragraph paragraph, int offsetRelativeToParagraph)
        {
            // Verify that the specified offset falls within the specified paragraph.  If the offset is
            // past the end of the paragraph, return a pointer to the farthest offset position in the paragraph.
            // Otherwise, return a TextPointer to the specified offset in the specified paragraph.
            return (offsetRelativeToParagraph > paragraph.ContentStart.GetOffsetToPosition(paragraph.ContentEnd)) 
                ? paragraph.ContentEnd : paragraph.ContentStart.GetPositionAtOffset(offsetRelativeToParagraph);
        }
        // </Snippet_TextPointer_GetPositionAtOffset>

        // <Snippet_TextPointer_GetTextInRun>
        // Returns a string containing the text content between two specified TextPointers.
        string GetTextBetweenTextPointers(TextPointer start, TextPointer end)
        {
            StringBuilder buffer = new StringBuilder();
         
            while (start != null && start.CompareTo(end) < 0)
            {
                if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                    buffer.Append(start.GetTextInRun(LogicalDirection.Forward));
         
                // Note that when the TextPointer points into a text run, this skips over the entire
                // run, not just the current character in the run.
                start = start.GetNextContextPosition(LogicalDirection.Forward);
            }
            return buffer.ToString();

        } // End GetTextBetweenPointers.
        // </Snippet_TextPointer_GetTextInRun>

        // <Snippet_TextPointer_IsInSameDocument>
        // This method first checks for compatible text container scope, and then checks whether
        // a specified position is between two other specified positions.
        bool IsPositionContainedBetween(TextPointer positionToTest, TextPointer start, TextPointer end)
        {
            // Note that without this check, an exception will be raised by CompareTo if positionToTest 
            // does not point to a position that is in the same text container used by start and end.
            //
            // This test also implicitely indicates whether start and end share a common text container.
            if (!positionToTest.IsInSameDocument(start) || !positionToTest.IsInSameDocument(end)) 
                return false;
            
            return start.CompareTo(positionToTest) <= 0 && positionToTest.CompareTo(end) <= 0;
        }
        // </Snippet_TextPointer_IsInSameDocument>

        // <Snippet_TextPointer_TextPointer1>
        // This method returns the position just inside of the first text Run (if any) in a 
        // specified text container.
        TextPointer FindFirstRunInTextContainer(DependencyObject container)
        {
            TextPointer position = null;

            if (container != null){
                if (container is FlowDocument)
                    position = ((FlowDocument)container).ContentStart;
                else if (container is TextBlock)
                    position = ((TextBlock)container).ContentStart;
                else
                    return position;
            }
//<SnippetFCEParent>
            // Traverse content in forward direction until the position is immediately after the opening 
            // tag of a Run element, or the end of content is encountered.
            while (position != null)
            {
                // Is the current position just after an opening element tag?
                if (position.GetPointerContext(LogicalDirection.Backward) == TextPointerContext.ElementStart)
                {
                    // If so, is the tag a Run?
                    if (position.Parent is Run)
                        break;
                }

                // Not what we're looking for; on to the next position.
                position = position.GetNextContextPosition(LogicalDirection.Forward);
            }
//</SnippetFCEParent>
                
            // This will be either null if no Run is found, or a position just inside of the first Run element in the
            // specifed text container.  Because position is formed from ContentStart, it will have a logical direction
            // of Backward.
            return position;
        } 
        // </Snippet_TextPointer_TextPointer1>

        // <Snippet_TextPointer_TextPointer2>
        // This method will search for a specified word (string) starting at a specified position.
        TextPointer FindWordFromPosition(TextPointer position, string word)
        {
            while (position != null)
            {
                 if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                 {
                     string textRun = position.GetTextInRun(LogicalDirection.Forward);

                     // Find the starting index of any substring that matches "word".
                     int indexInRun = textRun.IndexOf(word);
                     if (indexInRun >= 0)
                     {
                         position = position.GetPositionAtOffset(indexInRun);
                         break;
                     }
                 }
                 else
                    position = position.GetNextContextPosition(LogicalDirection.Forward);
             }

             // position will be null if "word" is not found.
             return position; 
        }
        // </Snippet_TextPointer_TextPointer2>

        // <Snippet_TextRange_Text>
        // This method returns a plain text representation of a specified FlowDocument.
        string GetTextFromFlowDocument(FlowDocument flowDoc)
        {
             // Create a new TextRanage that takes the entire FlowDocument as the current selection.
             TextRange flowDocSelection = new TextRange(flowDoc.ContentStart, flowDoc.ContentEnd);
              
             // Use the Text property to extract a string that contains the unformatted text contents 
             // of the FlowDocument.
             return flowDocSelection.Text;
        }
        // </Snippet_TextRange_Text>

        // <Snippet_TextRange_StartEnd>
        // This method returns true if two specified selections overlap, including when the
        // end of one selection serves as the beginning of the other.
        bool DoSelectionsOverlap(TextRange selection1, TextRange selection2)
        {
            // Is either end of selection2 contained by selection1?
            if (selection1.Contains(selection2.Start) || selection1.Contains(selection2.End))
            {
                // If so, the selections overlap.
                return true;
            }
            // If not, selection2 may still entirely contain selection1.
            // Is either end of selection1 contained by seleciotn2?
            else if (selection2.Contains(selection1.Start) || selection2.Contains(selection1.End))
            {
                // If so, the selections overlap.
                return true;
            }
            // If neither selection contains the begging or end of the other selection, 
            //the selections do not overlap.
            else return false;    
        }
        // </Snippet_TextRange_StartEnd>

        // <Snippet_TextRange_LoadSave>
        // This method accepts an input stream and a corresponding data format.  The method
        // will attempt to load the input stream into a TextRange selection, apply Bold formatting
        // to the selection, save the reformatted selection to an alternat stream, and return 
        // the reformatted stream.  
        Stream BoldFormatStream(Stream inputStream, string dataFormat)
        {
            // A text container to read the stream into.
            FlowDocument workDoc = new FlowDocument();
            TextRange selection = new TextRange(workDoc.ContentStart, workDoc.ContentEnd);
            Stream outputStream = new MemoryStream();

            try
            {
                // Check for a valid data format, and then attempt to load the input stream
                // into the current selection.  Note that CanLoad ONLY checks whether dataFormat
                // is a currently supported data format for loading a TextRange.  It does not 
                // verify that the stream actually contains the specified format.  An exception 
                // may be raised when there is a mismatch between the specified data format and 
                // the data in the stream. 
                if (selection.CanLoad(dataFormat))
                    selection.Load(inputStream, dataFormat);
            }
            catch (Exception e) { return outputStream; /* Load failure; return a null stream. */ }

            // Apply Bold formatting to the selection, if it is not empty.
            if (!selection.IsEmpty)
                selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);

            // Save the formatted selection to a stream, and return the stream.
            if (selection.CanSave(dataFormat))
                selection.Save(outputStream, dataFormat);

            return outputStream;
        }
        // </Snippet_TextRange_LoadSave>

    }  // End class Window1

}  // End namespace TextPointer_Snippets