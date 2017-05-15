all: NameIdPermission.dll NameIdPermissionAttribute.dll

NameIdPermission.dll : nameidpermission.cs
	csc /t:library nameidpermission.cs 

NameIdPermissionAttribute.dll : nameidpermissionattribute.cs
  csc /t:library nameidpermissionattribute.cs /r:NameIdPermission.dll 


