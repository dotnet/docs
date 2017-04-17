all: CrmServer.dll CrmClient.exe

CrmServer.dll: CrmServer.cs CrmServer.key
# <snipper41>
	csc /t:library CrmServer.cs /keyfile:CrmServer.key
# </snipper41>

CrmServer.key:
# <snipper42>
	sn -k CrmServer.key
# </snipper42>

CrmClient.exe: CrmClient.cs CrmServer.dll
# <snipper43>
	csc CrmClient.cs /r:CrmServer.dll
# </snipper43>

install:
# <snipper44>
	regsvcs CrmServer.dll
# </snipper44>
