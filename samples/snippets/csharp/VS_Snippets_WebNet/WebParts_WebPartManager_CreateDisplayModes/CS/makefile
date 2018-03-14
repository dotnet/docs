all: Bin\CustomDisplayModeCS.dll
Bin\CustomDisplayModeCS.dll: CustomDisplayMode.cs
	IF NOT EXIST Bin md Bin
	csc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /out:Bin\CustomDisplayModeCS.dll CustomDisplayMode.cs
