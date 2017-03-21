<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
System.Web.HttpBrowserCapabilities bCaps;

    void Page_Load(Object Sender, EventArgs e)
    {
        bCaps = Request.Browser;
        OutputLabel.Text = TestCaps();
    }   

    String TestCaps()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(TestActiveXControls());
        sb.AppendLine(TestAdapters());
        sb.AppendLine(TestAOL());
        sb.AppendLine(TestBackgroundSounds());
        sb.AppendLine(TestBeta());
        sb.AppendLine(TestBrowser());
        sb.AppendLine(TestBrowserID());
        sb.AppendLine(TestBrowsers());
        sb.AppendLine(TestCanCall());
        sb.AppendLine(TestCanRenderAfter());
        sb.AppendLine(TestCanRenderEmpty());
        sb.AppendLine(TestCanRenderInputSelectTogether());
        sb.AppendLine(TestCanRenderMixedSelects());
        sb.AppendLine(TestCanRenderOneventPrevTogether());
        sb.AppendLine(TestCanRenderPostBackCards());
        sb.AppendLine(TestCanRenderSetvar());
        sb.AppendLine(TestCanSendMail());
        sb.AppendLine(TestCDF());
        sb.AppendLine(TestCLRVersion());
        sb.AppendLine(TestCombineDeck());
        sb.AppendLine(TestDefaultSubmitButton());
        sb.AppendLine(TestECMAScriptVersion());
        sb.AppendLine(TestGatewayMajorVersion());
        sb.AppendLine(TestGatewayMinorVersion());
        sb.AppendLine(TestGatewayVersion());
        sb.AppendLine(TestHasBackButton());
        sb.AppendLine(TestHideRtAlignScrollBars());
        sb.AppendLine(TestInputType());
        sb.AppendLine(TestIsBrowser());
        sb.AppendLine(TestIsColor());
        sb.AppendLine(TestIsCrawler());
        sb.AppendLine(TestIsMobileDevice());
        sb.AppendLine(TestJavaScript());
        sb.AppendLine(TestJScriptVersion());
        sb.AppendLine(TestMajorVersion());
        sb.AppendLine(TestMaximumHrefLength());
        sb.AppendLine(TestMaximumRenderedPageSize());
        sb.AppendLine(TestMaximumSoftkeyLabelLength());
        sb.AppendLine(TestMinorVersion());
        sb.AppendLine(TestMinorVersionString());
        sb.AppendLine(TestMobileDeviceManufacturer());
        sb.AppendLine(TestMobileDeviceModel());
        sb.AppendLine(TestMSDomVersion());
        sb.AppendLine(TestNumberOfSoftKeys());
        sb.AppendLine(TestPlatform());
        sb.AppendLine(TestPreferredImageMime());
        sb.AppendLine(TestPreferredRenderingMime());
        sb.AppendLine(TestPreferredRenderingType());
        sb.AppendLine(TestPreferredRequestEncoding());
        sb.AppendLine(TestPreferredResponseEncoding());
        sb.AppendLine(TestRenderBreakBeforeWmlSelectAndInput());
        sb.AppendLine(TestRendersBreaksAfterHtmlLists());
        sb.AppendLine(TestRendersBreaksAfterWmlAnchor());
        sb.AppendLine(TestRendersBreaksAfterWmlInput());
        sb.AppendLine(TestRendersWmlDoAcceptsInline());
        sb.AppendLine(TestRendersWmlSelectsAsMenuCards());
        sb.AppendLine(TestRequiredMetaTagNameValue());
        sb.AppendLine(TestRequiresAttributeColonSubstitution());
        sb.AppendLine(TestRequiresContentTypeMetaTag());
        sb.AppendLine(TestRequiresControlStateInSession());
        sb.AppendLine(TestRequiresDBCSCharacter());
        sb.AppendLine(TestRequiresHtmlAdaptiveErrorReporting());
        sb.AppendLine(TestRequiresLeadingPageBreak());
        sb.AppendLine(TestRequiresNoBreakInFormatting());
        sb.AppendLine(TestRequiresOutputOptimization());
        sb.AppendLine(TestRequiresPhoneNumberAsPlainText());
        sb.AppendLine(TestRequiresSpecialViewStateEncoding());
        sb.AppendLine(TestRequiresUniqueFilePathSuffix());
        sb.AppendLine(TestRequiresUniqueHtmlCheckboxNames());
        sb.AppendLine(TestRequiresUniqueHtmlInputNames());
        sb.AppendLine(TestRequiresUrlEncodedPostfieldValues());
        sb.AppendLine(TestScreenBitDepth());
        sb.AppendLine(TestScreenCharactersHeight());
        sb.AppendLine(TestScreenCharactersWidth());
        sb.AppendLine(TestScreenPixelsHeight());
        sb.AppendLine(TestScreenPixelsWidth());
        sb.AppendLine(TestScreenAccesskeyAttribute());
        sb.AppendLine(TestSupportsBodyColor());
        sb.AppendLine(TestSupportsBold());
        sb.AppendLine(TestSupportsCacheControlMetaTag());
        sb.AppendLine(TestSupportsCallback());
        sb.AppendLine(TestSupportsCookies());
        sb.AppendLine(TestSupportsCss());
        sb.AppendLine(TestSupportsDivAlign());
        sb.AppendLine(TestSupportsDivNoWrap());
        sb.AppendLine(TestSupportsEmptyStringInCookieValue());
        sb.AppendLine(TestSupportsFontColor());
        sb.AppendLine(TestSupportsFontName());
        sb.AppendLine(TestSupportsFontSize());
        sb.AppendLine(TestSupportsFrames());
        sb.AppendLine(TestSupportsImageSubmit());
        sb.AppendLine(TestSupportsIModeSymbols());
        sb.AppendLine(TestSupportsInputIStyle());
        sb.AppendLine(TestSupportsInputMode());
        sb.AppendLine(TestSupportsItalic());
        sb.AppendLine(TestSupportsJava());
        sb.AppendLine(TestSupportsJPhoneMultiMediaAttributes());
        sb.AppendLine(TestSupportsJPhoneSymbols());
        sb.AppendLine(TestSupportsQueryStringInFormAction());
        sb.AppendLine(TestSupportsRedirectWithCookie());
        sb.AppendLine(TestSupportsSelectMultiple());
        sb.AppendLine(TestSupportsUncheck());
        sb.AppendLine(TestSupportsXmlHttp());
        sb.AppendLine(TestTables());
        sb.AppendLine(TestType());
        sb.AppendLine(TestVBScript());
        sb.AppendLine(TestVersion());
        sb.AppendLine(TestW3CDomVersion());
        sb.AppendLine(TestWin16());
        sb.AppendLine(TestWin32());
        return sb.ToString().Replace(Environment.NewLine,"<br />");
    }
    String TestActiveXControls() 
    {
        return String.Format("Supports ActiveX controls: {0}",
            bCaps.ActiveXControls); 
    }

    String TestAdapters()
    {
        return String.Format("Adapter count: {0}", 
            bCaps.Adapters.Count);
    }
        
    String TestAOL()
    {
        return String.Format("Is an AOL browser: {0}", 
            bCaps.AOL.ToString());
    }

    String TestBackgroundSounds()
    {
        return String.Format("Supports background sounds: {0}",
            bCaps.BackgroundSounds);
    }
        
    String TestBeta()
    {
        return String.Format("Is a beta version: {0}", 
            bCaps.Beta);
    }
        
    String TestBrowser()
    {
        return String.Format("Browser type: {0}", 
            bCaps.Browser);
    }

    String TestBrowsers()
    {
        return String.Format("Number of browsers in dictionary: {0}",
            bCaps.Browsers.Count);
    }

    String TestCombineDeck()
    {
        return String.Format("Can combine forms in deck: {0}",
            bCaps.CanCombineFormsInDeck);
    }

    String TestCanCall()
    {
        return String.Format("Can initiate voice call: {0}",
            bCaps.CanInitiateVoiceCall);
    }

    String TestCanRenderAfter()
    {
        return String.Format("Can render {0}: {1}",
            "after input or select element",
            bCaps.CanRenderAfterInputOrSelectElement);
    }

    String TestCanRenderEmpty()
    {
        return String.Format("Can render empty selects: {0}",
            bCaps.CanRenderEmptySelects);
    }

    String TestCanRenderInputSelectTogether()
    {
        return String.Format("Can render {0} together: {1}",
            "input and select elements",
            bCaps.CanRenderInputAndSelectElementsTogether);
    }

    String TestCanRenderMixedSelects()
    {
        return String.Format("Can render mixed selects: {0}",
            bCaps.CanRenderMixedSelects);
    }

    String TestCanRenderOneventPrevTogether()
    {
        return String.Format("Can render {0} together: {1}",
            "OnEvent and Prev elements",
            bCaps.CanRenderOneventAndPrevElementsTogether);
    }

    String TestCanRenderPostBackCards()
    {
        return String.Format("Can render postback cards: {0}",
            bCaps.CanRenderPostBackCards);
    }

    String TestCanRenderSetvar()
    {
        return String.Format("Can render {0}: {1}",
            "setvar elements with a value of 0",
            bCaps.CanRenderSetvarZeroWithMultiSelectionList);
    }

    String TestCanSendMail()
    {
        return String.Format("Can send mail: {0}",
            bCaps.CanSendMail);
    }

    String TestCDF()
    {
        return String.Format("Supports {0}: {1}",
            "Channel Definition Format",
            bCaps.CDF.ToString());
    }

    String TestCLRVersion()
    {
        return String.Format("CLR version on client: {0}",
            bCaps.ClrVersion);
    }

    String TestSupportsCookies()
    {
        return String.Format("Supports cookies: {0}",
            bCaps.Cookies);
    }

    String TestIsCrawler()
    {
        return String.Format("Is a crawler: {0}",
            bCaps.Crawler);
    }
        
    String TestDefaultSubmitButton()
    {
        return String.Format("Submit button limit: {0}",
            bCaps.DefaultSubmitButtonLimit);
    }

    String TestECMAScriptVersion()
    {
        return String.Format("ECMA script version: {0}",
            bCaps.EcmaScriptVersion);
    }

    String TestSupportsFrames()
    {
        return String.Format("Supports frames: {0}",
            bCaps.Frames);
    }

    String TestGatewayMajorVersion()
    {
        return String.Format("Gateway major version: {0}",
            bCaps.GatewayMajorVersion.ToString());
    }

    String TestGatewayMinorVersion()
    {
        return String.Format("Gateway minor version: {0}",
            bCaps.GatewayMinorVersion.ToString());
    }

    String TestGatewayVersion()
    {
        return String.Format("Gateway version: {0}",
            bCaps.GatewayVersion.ToString());
    }

    String TestHasBackButton()
    {
        return String.Format("Has back button: {0}",
            bCaps.HasBackButton.ToString());
    }

    String TestHideRtAlignScrollBars()
    {
        return String.Format("Hide right-aligned {0}: {1}",
            "multi-select scrollbars",
            bCaps.HidesRightAlignedMultiselectScrollbars.ToString());
    }

    String TestBrowserID()
    {
        return String.Format("Browser ID: {0}",
            bCaps.Id);
    }

    String TestInputType()
    {
        return String.Format("Supported input type: {0}",
            bCaps.InputType);
    }

    String TestIsBrowser()
    {
        return String.Format("Is client a given browser: {0}",
            bCaps.IsBrowser("IE").ToString());
    }

    String TestIsColor()
    {
        return String.Format("Is color display: {0}",
            bCaps.IsColor.ToString());
    }

    String TestIsMobileDevice()
    {
        return String.Format("Is mobile device: {0}",
            bCaps.IsMobileDevice.ToString());
    }

    String TestSupportsJava()
    {
        return String.Format("Supports Java: {0}",
            bCaps.JavaApplets.ToString());
    }

    String TestJavaScript()
    {
        return String.Format("Supports JavaScript: {0}",
            bCaps.JavaScript.ToString());
    }

    String TestJScriptVersion()
    {
        return String.Format("JScript version: {0}",
            bCaps.JScriptVersion.ToString());
    }

    String TestMajorVersion()
    {
        return String.Format("Major version of browser: {0}",
            bCaps.MajorVersion.ToString());
    }

    String TestMaximumHrefLength()
    {
        return String.Format("Max. href length: {0}",
            bCaps.MaximumHrefLength.ToString());
    }

    String TestMaximumRenderedPageSize()
    {
        return String.Format("Max. rendered page size in bytes: {0}",
            bCaps.MaximumRenderedPageSize.ToString());
    }
        
    String TestMaximumSoftkeyLabelLength()
    {
        return String.Format("Max. softkey label length: {0}",
            bCaps.MaximumSoftkeyLabelLength.ToString());
    }
        
    String TestMinorVersion()
    {
        return String.Format("Minor browser version: {0}",
            bCaps.MinorVersion.ToString());
    }
        
    String TestMinorVersionString()
    {
        return String.Format("Minor browser version {0}: {1}",
            "(as string)",
            bCaps.MinorVersionString);
    }
        
    String TestMobileDeviceManufacturer()
    {
        return String.Format("Mobile device manufacturer: {0}",
            bCaps.MobileDeviceManufacturer);
    }

    String TestMobileDeviceModel()
    {
        return String.Format("Mobile device model: {0}",
            bCaps.MobileDeviceModel);
    }

    String TestMSDomVersion()
    { 
        return String.Format("MS DOM version: {0}",
            bCaps.MSDomVersion.ToString());
    }

    String TestNumberOfSoftKeys()
    {
        return String.Format("Number of soft keys: {0}",
            bCaps.NumberOfSoftkeys.ToString());
    }

    String TestPlatform()
    {
        return String.Format("Platform of client: {0}",
            bCaps.Platform);
    }

    String TestPreferredImageMime()
    {
        return String.Format("Preferred image MIME: {0}",
            bCaps.PreferredImageMime);
    }

    String TestPreferredRenderingMime()
    {
        return String.Format("Preferred rendering MIME: {0}",
            bCaps.PreferredRenderingMime);
    }

    String TestPreferredRenderingType()
    {
        return String.Format("Preferred rendering type: {0}",
            bCaps.PreferredRenderingType);
    }

    String TestPreferredRequestEncoding()
    {
        return String.Format("Preferred request encoding: {0}",
            bCaps.PreferredRequestEncoding);
    }

    String TestPreferredResponseEncoding()
    {
        return String.Format("Preferred response encoding: {0}",
            bCaps.PreferredResponseEncoding);
    }

    String TestRenderBreakBeforeWmlSelectAndInput()
    {
        return String.Format("Renders {0}: {1}",
            "break before WML select/input",
            bCaps.RendersBreakBeforeWmlSelectAndInput.ToString());
    }

    String TestRendersBreaksAfterHtmlLists()
    {
        return String.Format("Renders breaks after HTML lists: {0}",
            bCaps.RendersBreaksAfterHtmlLists);
    }

    String TestRendersBreaksAfterWmlAnchor()
    {
        return String.Format("Renders breaks after Wml anchor: {0}",
            bCaps.RendersBreaksAfterWmlAnchor);
    }

    String TestRendersBreaksAfterWmlInput()
    {
        return String.Format("Renders breaks after Wml input: {0}",
            bCaps.RendersBreaksAfterWmlInput);
    }

    String TestRendersWmlDoAcceptsInline()
    {
        return String.Format("Renders Wml do accepts inline: {0}",
            bCaps.RendersWmlDoAcceptsInline);
    }

    String TestRendersWmlSelectsAsMenuCards()
    {
        return String.Format("Renders {0}: {1}",
            "break before WML select/input",
            bCaps.RendersWmlSelectsAsMenuCards);
    }

    String TestRequiredMetaTagNameValue()
    {
        return String.Format("Required meta tag name value: {0}",
            bCaps.RequiredMetaTagNameValue);
    }

    String TestRequiresAttributeColonSubstitution()
    {
        return String.Format("Requires {0}: {1}",
            "break before WML select/input",
            bCaps.RequiresAttributeColonSubstitution);
    }

    String TestRequiresContentTypeMetaTag()
    {
        return String.Format("Requires content type meta tag: {0}",
            bCaps.RequiresContentTypeMetaTag);
    }

    String TestRequiresControlStateInSession()
    {
        return String.Format("Requires {0}: {1}",
            "control state in session",
            bCaps.RequiresControlStateInSession);
    }

    String TestRequiresDBCSCharacter()
    {
        return String.Format("Requires DBCS character: {0}",
            bCaps.RequiresDBCSCharacter);
    }
        
    String TestRequiresHtmlAdaptiveErrorReporting()
    {
        return String.Format("Requires HTML adaptive error reporting: {0}",
            bCaps.RequiresHtmlAdaptiveErrorReporting);
    }

    String TestRequiresLeadingPageBreak()
    {
        return String.Format("Requires leading page break: {0}",
            bCaps.RequiresLeadingPageBreak);
    }

    String TestRequiresNoBreakInFormatting()
    {
        return String.Format("Requires no break in formatting: {0}",
            bCaps.RequiresNoBreakInFormatting);
    }

    String TestRequiresOutputOptimization()
    {
        return String.Format("Requires output optimization: {0}",
            bCaps.RequiresOutputOptimization);
    }

    String TestRequiresPhoneNumberAsPlainText()
    {
        return String.Format("Requires phone number as text: {0}",
            bCaps.RequiresPhoneNumbersAsPlainText);
    }

    String TestRequiresSpecialViewStateEncoding()
    {
        return String.Format("Requires special viewstate encoding: {0}",
            bCaps.RequiresSpecialViewStateEncoding);
    }

    String TestRequiresUniqueFilePathSuffix()
    {
        return String.Format("Requires unique file path suffix: {0}",
            bCaps.RequiresUniqueFilePathSuffix);
    }

    String TestRequiresUniqueHtmlCheckboxNames()
    {
        return String.Format("Requires unique HTML checkbox names: {0}",
            bCaps.RequiresUniqueHtmlCheckboxNames);
    }

    String TestRequiresUniqueHtmlInputNames()
    {
        return String.Format("Requires unique HTML input names: {0}",
            bCaps.RequiresUniqueHtmlInputNames);
    }

    String TestRequiresUrlEncodedPostfieldValues()
    {
        return String.Format("Requires URL encoded postfield values: {0}",
            bCaps.RequiresUrlEncodedPostfieldValues);
    }

    String TestScreenBitDepth()
    {
        return String.Format("Screen bit depth: {0}",
            bCaps.ScreenBitDepth);
    }

    String TestScreenCharactersHeight()
    {
        return String.Format("Screen height in character lines: {0}",
            bCaps.ScreenCharactersHeight);
    }

    String TestScreenCharactersWidth()
    {
        return String.Format("Screen width in characters: {0}",
            bCaps.ScreenCharactersWidth);
    }

    String TestScreenPixelsHeight()
    {
        return String.Format("Screen height in pixels: {0}",
            bCaps.ScreenPixelsHeight);
    }

    String TestScreenPixelsWidth()
    {
        return String.Format("Screen width in pixels: {0}",
            bCaps.ScreenPixelsWidth);
    }

    String TestScreenAccesskeyAttribute()
    {
        return String.Format("Supports ACCESSKEY: {0}",
            bCaps.SupportsAccesskeyAttribute);
    }

    String TestSupportsBodyColor()
    {
        return String.Format("Supports body color: {0}",
            bCaps.SupportsBodyColor);
    }

    String TestSupportsBold()
    {
        return String.Format("Supports bold: {0}",
            bCaps.SupportsBold);
    }

    String TestSupportsCacheControlMetaTag()
    {
        return String.Format("Supports cache-control meta tag: {0}",
            bCaps.SupportsCacheControlMetaTag);
    }

    String TestSupportsCallback()
    {
        return String.Format("Supports callback: {0}",
            bCaps.SupportsCallback);
    }

    String TestSupportsCss()
    {
        return String.Format("Supports CSS: {0}",
            bCaps.SupportsCss);
    }

    String TestSupportsDivAlign()
    {
        return String.Format("Supports DIV align: {0}",
            bCaps.SupportsDivAlign);
    }

    String TestSupportsDivNoWrap()
    {
        return String.Format("Supports DIV nowrap: {0}",
            bCaps.SupportsDivNoWrap);
    }

    String TestSupportsEmptyStringInCookieValue()
    {
        return String.Format("Supports empty string in cookie value: {0}",
            bCaps.SupportsEmptyStringInCookieValue);
    }

    String TestSupportsFontColor()
    {
        return String.Format("Supports font color: {0}",
            bCaps.SupportsFontColor);
    }

    String TestSupportsFontName()
    {
        return String.Format("Supports font name: {0}",
            bCaps.SupportsFontName);
    }

    String TestSupportsFontSize()
    {
        return String.Format("Supports font size: {0}",
            bCaps.SupportsFontSize);
    }

    String TestSupportsImageSubmit()
    {
        return String.Format("Supports image submit: {0}",
            bCaps.SupportsImageSubmit);
    }

    String TestSupportsIModeSymbols()
    {
        return String.Format("Supports i-mode symbols: {0}",
            bCaps.SupportsIModeSymbols);
    }

    String TestSupportsInputIStyle()
    {
        return String.Format("Supports input istyle attribute: {0}",
            bCaps.SupportsInputIStyle);
    }

    String TestSupportsInputMode()
    {
        return String.Format("Supports input mode: {0}",
            bCaps.SupportsInputMode);
    }

    String TestSupportsItalic()
    {
        return String.Format("Supports italics: {0}",
            bCaps.SupportsItalic);
    }

    String TestSupportsJPhoneMultiMediaAttributes()
    {
        return String.Format("Supports JPhone multimedia attributes: {0}",
            bCaps.SupportsJPhoneMultiMediaAttributes);
    }

    String TestSupportsJPhoneSymbols()
    {
        return String.Format("Supports JPhone picture symbols: {0}",
            bCaps.SupportsJPhoneSymbols);
    }

    String TestSupportsQueryStringInFormAction()
    {
        return String.Format("Supports querystring in form action: {0}",
            bCaps.SupportsQueryStringInFormAction);
    }

    String TestSupportsRedirectWithCookie()
    {
        return String.Format("Supports redirect with cookie: {0}",
            bCaps.SupportsRedirectWithCookie);
    }

    String TestSupportsSelectMultiple()
    {
        return String.Format("Supports select multiple: {0}",
            bCaps.SupportsSelectMultiple);
    }

    String TestSupportsUncheck()
    {
        return String.Format("Supports uncheck: {0}",
            bCaps.SupportsUncheck);
    }

    String TestSupportsXmlHttp()
    {
        return String.Format("Supports receiving XML over HTTP: {0}",
            bCaps.SupportsXmlHttp);
    }

    String TestTables()
    {
        return String.Format("Supports tables: {0}",
            bCaps.Tables);
    }
    
    String TestType()
    {
        return String.Format("Gets the browser name/version: {0}",
            bCaps.Type);
    }

    String TestVBScript()
    {
        return String.Format("Supports VBScript: {0}",
            bCaps.VBScript);
    }

    String TestVersion()
    {
        string dVer = bCaps.MajorVersion + "." + bCaps.MinorVersion;
        if (Double.Parse(dVer) > 5.01)
        {
            return String.Format("Uplevel version: {0}",
                bCaps.Version);
        }
        else
        {
            return String.Format("Old version: {0}",
                bCaps.Version);
        }
    }

    String TestW3CDomVersion()
    {
        return String.Format("W3C DOM version: {0}",
            bCaps.W3CDomVersion);
    }

    String TestWin16()
    {
        return String.Format("Is Win16-based computer: {0}",
            bCaps.Win16);
    }

    String TestWin32()
    {
        return String.Format("Is Win32-based computer: {0}",
            bCaps.Win32);
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Browser Capabilities Sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        The current browser has the following capabilities:
        <br />
        <asp:Label ID="OutputLabel" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>