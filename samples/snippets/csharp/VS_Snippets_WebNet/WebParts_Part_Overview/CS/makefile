all:Bin\TextDisplayWebPartCS.dll 
Bin\TextDisplayWebPartCS.dll:TextDisplayWebPart.cs
	IF NOT EXIST Bin md Bin
	csc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /out:Bin\TextDisplayWebPartCS.dll TextDisplayWebPart.cs
