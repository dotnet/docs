all: calculator.dll
calculator.snk:
# <snippet11>
	sn -k calculator.snk
# </snippet11>
calculator.dll: calculator.vb calculator.snk
# <snippet12>
	vbc /t:library calculator.vb
# </snippet12>
install: calculator.dll
# <snippet13>
	regsvcs calculator.dll
# </snippet13>
