all:Bin\MyChromeVB.dll
Bin\MyChromeVB.dll:MyChrome.vb
	IF NOT EXIST Bin md Bin
	vbc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /out:Bin\MyChromeVB.dll MyChrome.vb
