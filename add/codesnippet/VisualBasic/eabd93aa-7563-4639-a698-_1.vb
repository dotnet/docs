            ' Create a random access view, from the 256th megabyte (the offset)
            ' to the 768th megabyte (the offset plus length).
            Using accessor = mmf.CreateViewAccessor(offset, length)
                Dim colorSize As Integer = Marshal.SizeOf(GetType(MyColor))
                Dim color As MyColor
                Dim i As Long = 0

                ' Make changes to the view.
                Do While (i < length)
                    accessor.Read(i, color)
                    color.Brighten(10)
                    accessor.Write(i, color)
                    i += colorSize
                Loop
            End Using