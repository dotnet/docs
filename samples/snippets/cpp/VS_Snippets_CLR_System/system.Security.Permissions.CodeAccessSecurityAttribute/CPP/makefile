all: NameIdPermission.dll NameIdPermissionAttribute.dll

NameIdPermission.dll : nameidpermission.cpp
	cl /clr:pure /LD nameidpermission.cpp /link /CLRUNMANAGEDCODECHECK:NO

NameIdPermissionAttribute.dll : nameidpermissionattribute.cpp
	cl /clr:pure /LD nameidpermissionattribute.cpp /link /CLRUNMANAGEDCODECHECK:NO


