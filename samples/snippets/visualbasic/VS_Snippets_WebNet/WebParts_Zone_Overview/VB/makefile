all:Bin\ZoneWebPartsVB.dll 
Bin\ZoneWebPartsVB.dll:ZoneWebParts.vb
	IF NOT EXIST Bin md Bin
	vbc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /out:Bin\ZoneWebPartsVB.dll ZoneWebParts.vb
