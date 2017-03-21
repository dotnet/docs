            ' Write a message to the file dependent upon
            ' the value of the TotalBytes property.
            If Request.TotalBytes > 1000 Then
                sw.WriteLine("The request is 1KB or greater")
            Else
                sw.WriteLine("The request is less than 1KB")
            End If