all:  cookiecollection_item_2.dll CookiesPage.dll

cookiecollection_item_2.dll:  cookiecollection_item_2.cs
	if not exist bin md bin
	csc /t:library /out:bin/cookiecollection_item_2.dll  cookiecollection_item_2.cs
CookiesPage.dll:   CookiesPage.cs
	if not exist bin md bin
	csc /t:library /out:bin/CookiesPage.dll   CookiesPage.cs
