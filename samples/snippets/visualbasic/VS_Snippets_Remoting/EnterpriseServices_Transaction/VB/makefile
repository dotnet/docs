all: transaction.dll
transaction.snk:
# <snippet11>
	sn -k transaction.snk
# </snippet11>
transaction.dll: transaction.vb transaction.snk
# <snippet12>
	vbc /t:library transaction.vb
# </snippet12>
install: transaction.dll
# <snippet13>
	regsvcs transaction.dll
# </snippet13>
