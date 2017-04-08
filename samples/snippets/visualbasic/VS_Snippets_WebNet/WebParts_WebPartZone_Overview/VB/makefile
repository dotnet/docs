all:Bin\MyWebPartZoneVB.dll 
Bin\MyWebPartZoneVB.dll:MyWebPartZone.vb
	IF NOT EXIST Bin md Bin
	vbc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /out:Bin\MyWebPartZoneVB.dll MyWebPartZone.vb
