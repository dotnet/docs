Before executing the cookie files, please configure as follows:

This provides the steps essential for the running of all Cookies related snippets.

Provided with the snippets are two files CookiesPage.cs and CookiesServer.aspx. On a machine that has IIS server installed and .NET Framework installed perform the following steps to set up the cookies site :
1)	Create a virtual directory from IIS and map it to a real directory.
2)	Copy the CookiesServer.aspx to the real directory as specified in the step 1 above.
3)	Create a subdirectory called bin in the real directory specified in the step 1 above.
4)	Create a dll from CookiesPage.cs and copy the dll to the bin directory created in the step 3 above. 

        Now you have the CookiesServer.aspx running, specify this as the argument in all the snippets for cookies.
