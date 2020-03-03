all: Bin\MyWebPartZoneCS.dll
Bin\MyWebPartZoneCS.dll: MyWebPartZone.cs
	IF NOT EXIST Bin md Bin
	csc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /out:Bin\MyWebPartZoneCS.dll MyWebPartZone.cs
