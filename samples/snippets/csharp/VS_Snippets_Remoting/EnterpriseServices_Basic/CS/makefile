all: calculator.dll
calculator.snk:
# <snippet11>
	sn -k calculator.snk
# </snippet11>
calculator.dll: calculator.cs calculator.snk
# <snippet12>
	csc /t:library calculator.cs
# </snippet12>
install: calculator.dll
# <snippet13>
	regsvcs calculator.dll
# </snippet13>
