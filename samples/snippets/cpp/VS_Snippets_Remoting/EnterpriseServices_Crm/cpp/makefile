all: CrmServer.dll CrmClient.exe

CrmServer.dll: CrmServer.cpp CrmServer.key
# <snipper41>
	cl /c /FoCrmServer.obj /clr:pure CrmServer.cpp
	link /DLL /KEYFILE:"CrmServer.key" CrmServer.obj
# </snipper41>

CrmServer.key:
# <snipper42>
	sn -k CrmServer.key
# </snipper42>

CrmClient.exe: CrmClient.cpp CrmServer.dll
# <snipper43>
	cl /FeCrmClient.exe /clr:pure CrmClient.cpp /FUCrmServer.dll
# </snipper43>

install:
# <snipper44>
	regsvcs CrmServer.dll
# </snipper44>
