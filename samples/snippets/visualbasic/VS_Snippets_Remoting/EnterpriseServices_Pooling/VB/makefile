all: Inspector.dll
Inspector.snk:
# <snippet11>
	sn -k Inspector.snk
# </snippet11>
Inspector.dll: Inspector.vb Inspector.snk
# <snippet12>
	vbc /t:library Inspector.vb
# </snippet12>
install: Inspector.dll
# <snippet13>
	regsvcs Inspector.dll
# </snippet13>
