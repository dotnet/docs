        Dim MyAttr As FileAttribute
        ' Assume file TESTFILE is normal and readonly.
        MyAttr = GetAttr("C:\TESTFILE.txt")   ' Returns vbNormal.

        ' Test for normal.
        If (MyAttr And FileAttribute.Normal) = FileAttribute.Normal Then
            MsgBox("This file is normal.")
        End If

        ' Test for normal and readonly.
        Dim normalReadonly As FileAttribute
        normalReadonly = FileAttribute.Normal Or FileAttribute.ReadOnly
        If (MyAttr And normalReadonly) = normalReadonly Then
            MsgBox("This file is normal and readonly.")
        End If

        ' Assume MYDIR is a directory or folder.
        MyAttr = GetAttr("C:\MYDIR")
        If (MyAttr And FileAttribute.Directory) = FileAttribute.Directory Then
            MsgBox("MYDIR is a directory")
        End If