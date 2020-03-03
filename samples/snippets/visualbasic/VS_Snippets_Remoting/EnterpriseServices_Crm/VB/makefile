all: CrmServer.dll CrmClient.exe

CrmServer.dll: CrmServer.vb CrmServer.key
# <snipper41>
	vbc /t:library CrmServer.vb /keyfile:CrmServer.key
# </snipper41>

CrmServer.key:
# <snipper42>
	sn -k CrmServer.key
# </snipper42>

CrmClient.exe: CrmClient.vb CrmServer.dll
# <snipper43>
	vbc CrmClient.vb /r:CrmServer.dll
# </snipper43>

install:
# <snipper44>
	regsvcs CrmServer.dll
# </snipper44>
