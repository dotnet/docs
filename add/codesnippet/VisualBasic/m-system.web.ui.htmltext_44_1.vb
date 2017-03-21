          ' Assign a value to a string variable,
          ' encode it, and write it to a page.
          colHeads = "<custID> & <invoice#>" 
          writer.WriteEncodedText(colHeads)
          writer.WriteBreak()