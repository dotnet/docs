        ' compile with: /target:library
        Module Module1
            ' valid with or without /netcf
            Declare Sub DllSub Lib "SomeLib.dll" ()

            ' not valid with /netcf
            Declare Auto Sub DllSub1 Lib "SomeLib.dll" ()
            Declare Ansi Sub DllSub2 Lib "SomeLib.dll" ()
            Declare Unicode Sub DllSub3 Lib "SomeLib.dll" ()
        End Module