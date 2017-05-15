all:  cookiecollection_item_2.dll CookiesPages.dll

cookiecollection_item_2.dll:  cookiecollection_item_2.vb
	if not exist bin md bin
	vbc /t:library /out:bin/cookiecollection_item_2.dll  cookiecollection_item_2.vb
CookiesPages.dll: CookiesPage.vb
	if not exist bin md bin
	vbc /t:library /out:bin/CookiesPages.dll  CookiesPage.vb
