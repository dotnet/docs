all:  cookiecollection_item_1.dll cookiespage.dll

cookiecollection_item_1.dll:  cookiecollection_item_1.vb
	if not exist bin md bin
	vbc /t:library /out:bin/cookiecollection_item_1.dll  cookiecollection_item_1.vb
cookiespage.dll: cookiespage.vb
	if not exist bin md bin
	vbc /t:library /out:bin/cookiespage.dll  cookiespage.vb