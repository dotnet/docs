        '  Create a variable to hold a new object.
        Dim FS As System.IO.FileStream
        ' Assign a new object to the variable.
        FS = New System.IO.FileStream("C:\tmp.txt", 
            System.IO.FileMode.Open)