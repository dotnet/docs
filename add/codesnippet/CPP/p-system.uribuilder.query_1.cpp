    UriBuilder^ baseUri = gcnew UriBuilder 
        ("http://www.contoso.com/default.aspx?Param1=7890");
    String^ queryToAppend = "param2=1234";
    if (baseUri->Query != nullptr && baseUri->Query->Length > 1)
    {
        baseUri->Query = baseUri->Query->Substring(1)+ "&" + queryToAppend;
    }

    else
    {
        baseUri->Query = queryToAppend;
    }