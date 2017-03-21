        Console.WriteLine("Path.AltDirectorySeparatorChar={0}", Path.AltDirectorySeparatorChar)
        Console.WriteLine("Path.DirectorySeparatorChar={0}", Path.DirectorySeparatorChar)
        Console.WriteLine("Path.PathSeparator={0}", Path.PathSeparator)
        Console.WriteLine("Path.VolumeSeparatorChar={0}", Path.VolumeSeparatorChar)

        Console.Write("Path.GetInvalidPathChars()=")
        Dim c As Char
        For Each c In Path.GetInvalidPathChars()
            Console.Write(c)
        Next c
        Console.WriteLine()

        ' This code produces output similar to the following:
        ' Note that the InvalidPathCharacters contain characters
        ' outside of the printable character set.
        '
        ' Path.AltDirectorySeparatorChar=/
        ' Path.DirectorySeparatorChar=\
        ' Path.PathSeparator=;
        ' Path.VolumeSeparatorChar=: