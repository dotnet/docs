Example1.exe: Example1.vb
        vbc Example1.vb

RegexLib.dll: Example1.exe
        Example1.exe

Example1a.exe: Example1a.vb RegexLib.dll
        vbc /r:RegexLib.dll Example1a.vb
