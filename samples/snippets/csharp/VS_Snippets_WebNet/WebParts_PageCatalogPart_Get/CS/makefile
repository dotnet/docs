all: Bin\UserInfoWebPartCS.dll
Bin\UserInfoWebPartCS.dll: UserInfoWebPart.cs
	IF NOT EXIST Bin md Bin
	csc /r:System.dll,System.Design.dll,System.Drawing.dll,System.Web.dll /t:library /out:Bin\UserInfoWebPartCS.dll UserInfoWebPart.cs
