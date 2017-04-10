all: Inspector.dll
Inspector.snk:
# <snippet11>
	sn -k Inspector.snk
# </snippet11>
Inspector.dll: Inspector.cs Inspector.snk
# <snippet12>
	csc /t:library Inspector.cs
# </snippet12>
install: Inspector.dll
# <snippet13>
	regsvcs Inspector.dll
# </snippet13>
