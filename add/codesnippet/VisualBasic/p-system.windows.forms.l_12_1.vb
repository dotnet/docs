   Private Sub DisplayHScroll()
        ' Make sure no items are displayed partially.
      listBox1.IntegralHeight = True
      Dim x As Integer

      ' Add items that are wide to the ListBox.
      For x = 0 To 10
         listBox1.Items.Add("Item  " + x.ToString() + " is a very large value that requires scroll bars")
      Next x

      ' Display a horizontal scroll bar.
      listBox1.HorizontalScrollbar = True

      ' Create a Graphics object to use when determining the size of the largest item in the ListBox.
      Dim g As System.Drawing.Graphics = listBox1.CreateGraphics()


      ' Determine the size for HorizontalExtent using the MeasureString method using the last item in the list.
      Dim hzSize As Integer = g.MeasureString(listBox1.Items(listBox1.Items.Count - 1).ToString(), listBox1.Font).Width
      ' Set the HorizontalExtent property.
      listBox1.HorizontalExtent = hzSize
   End Sub