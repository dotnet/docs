all: Bin\ZoneWebPartsCS.dll
Bin\ZoneWebPartsCS.dll: ZoneWebParts.cs
	IF NOT EXIST Bin md Bin
	csc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /out:Bin\ZoneWebPartsCS.dll ZoneWebParts.cs
