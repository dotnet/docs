all:Bin\UserInfoWebPartVB.dll 
Bin\UserInfoWebPartVB.dll:UserInfoWebPart.vb
	IF NOT EXIST Bin md Bin
	vbc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /out:Bin\UserInfoWebPartVB.dll UserInfoWebPart.vb
