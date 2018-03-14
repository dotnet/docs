all:Bin\MyChromeCS.dll
Bin\MyChromeCS.dll:MyChrome.cs
	IF NOT EXIST Bin md Bin
	csc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /out:Bin\MyChromeCS.dll MyChrome.cs
