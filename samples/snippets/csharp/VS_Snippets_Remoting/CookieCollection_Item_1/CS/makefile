all:  cookiecollection_item_1.dll CookiesPage.dll

cookiecollection_item_1.dll:  cookiecollection_item_1.cs
	if not exist bin md bin
	csc /t:library /out:bin/cookiecollection_item_1.dll  cookiecollection_item_1.cs
CookiesPage.dll:   CookiesPage.cs
	if not exist bin md bin
	csc /t:library /out:bin/CookiesPage.dll   CookiesPage.cs
