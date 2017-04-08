all: NameIdPermission.dll NameIdPermissionAttribute.dll

NameIdPermission.dll : nameidpermission.vb
	vbc /t:library nameidpermission.vb 

NameIdPermissionAttribute.dll : nameidpermissionattribute.vb
  vbc /t:library nameidpermissionattribute.vb /r:NameIdPermission.dll 