all:Bin\TextDisplayWebPartVB.dll 
Bin\TextDisplayWebPartVB.dll:TextDisplayWebPart.vb
	IF NOT EXIST Bin md Bin
	vbc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /out:Bin\TextDisplayWebPartVB.dll TextDisplayWebPart.vb
