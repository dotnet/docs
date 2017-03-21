    myButton.Attributes.Clear();
    myTextBox.Attributes.Clear();
    myButton.Attributes["onClick"] = 
                    "javascript:alert('Visiting msn.com');";
    
    myTextBox.Attributes["name"] = "MyTextBox";
    
    myTextBox.Attributes["onBlur"] = 
                     "javascript:alert('Leaving MyTextBox...');";
                               
    HttpResponse myHttpResponse = Response;
    HtmlTextWriter myHtmlTextWriter  = 
                     new HtmlTextWriter(myHttpResponse.Output);

    myButton.Attributes.AddAttributes(myHtmlTextWriter);
    myTextBox.Attributes.AddAttributes(myHtmlTextWriter);