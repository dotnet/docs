all: transaction.dll
transaction.snk:
# <snippet11>
	sn -k transaction.snk
# </snippet11>
transaction.dll: transaction.cs transaction.snk
# <snippet12>
	csc /t:library transaction.cs
# </snippet12>
install: transaction.dll
# <snippet13>
	regsvcs transaction.dll
# </snippet13>
