<!-- <Snippet1> -->
<!-- <Snippet2> -->
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
//</Snippet2>
//<Snippet100>
        sb.AppendLine(TestActiveXControls());
//</Snippet100>
        //<Snippet101>
        sb.AppendLine(TestAdapters());
        //</Snippet101>
        //<Snippet102>
        sb.AppendLine(TestAOL());
        //</Snippet102>
        //<Snippet103>
        sb.AppendLine(TestBackgroundSounds());
        //</Snippet103>
        //<Snippet104>
        sb.AppendLine(TestBeta());
        //</Snippet104>
        //<Snippet105>
        sb.AppendLine(TestBrowser());
        //</Snippet105>
        //<Snippet106>
        sb.AppendLine(TestBrowserID());
        //</Snippet106>
        //<Snippet107>
        sb.AppendLine(TestBrowsers());
        //</Snippet107>
        //<Snippet108>
        sb.AppendLine(TestCanCall());
        //</Snippet108>
        //<Snippet109>
        sb.AppendLine(TestCanRenderAfter());
        //</Snippet109>
        //<Snippet110>
        sb.AppendLine(TestCanRenderEmpty());
        //</Snippet110>
        //<Snippet111>
        sb.AppendLine(TestCanRenderInputSelectTogether());
        //</Snippet111>
        //<Snippet112>
        sb.AppendLine(TestCanRenderMixedSelects());
        //</Snippet112>
        //<Snippet113>
        sb.AppendLine(TestCanRenderOneventPrevTogether());
        //</Snippet113>
        //<Snippet114>
        sb.AppendLine(TestCanRenderPostBackCards());
        //</Snippet114>
        //<Snippet115>
        sb.AppendLine(TestCanRenderSetvar());
        //</Snippet115>
        //<Snippet116>
        sb.AppendLine(TestCanSendMail());
        //</Snippet116>
        //<Snippet117>
        sb.AppendLine(TestCDF());
        //</Snippet117>
        //<Snippet118>
        sb.AppendLine(TestCLRVersion());
        //</Snippet118>
        //<Snippet119>
        sb.AppendLine(TestCombineDeck());
        //</Snippet119>
        //<Snippet120>
        sb.AppendLine(TestDefaultSubmitButton());
        //</Snippet120>
        //<Snippet121>
        sb.AppendLine(TestECMAScriptVersion());
        //</Snippet121>
        //<Snippet123>
        sb.AppendLine(TestGatewayMajorVersion());
        //</Snippet123>
        //<Snippet124>
        sb.AppendLine(TestGatewayMinorVersion());
        //</Snippet124>
        //<Snippet125>
        sb.AppendLine(TestGatewayVersion());
        //</Snippet125>
        //<Snippet126>
        sb.AppendLine(TestHasBackButton());
        //</Snippet126>
        //<Snippet127>
        sb.AppendLine(TestHideRtAlignScrollBars());
        //</Snippet127>
        //<Snippet128>
        sb.AppendLine(TestInputType());
        //</Snippet128>
        //<Snippet129>
        sb.AppendLine(TestIsBrowser());
        //</Snippet129>
        //<Snippet130>
        sb.AppendLine(TestIsColor());
        //</Snippet130>
        //<Snippet131>
        sb.AppendLine(TestIsCrawler());
        //</Snippet131>
        //<Snippet132>
        sb.AppendLine(TestIsMobileDevice());
        //</Snippet132>
        //<Snippet133>
        sb.AppendLine(TestJavaScript());
        //</Snippet133>
        //<Snippet134>
        sb.AppendLine(TestJScriptVersion());
        //</Snippet134>
        //<Snippet135>
        sb.AppendLine(TestMajorVersion());
        //</Snippet135>
        //<Snippet136>
        sb.AppendLine(TestMaximumHrefLength());
        //</Snippet136>
        //<Snippet137>
        sb.AppendLine(TestMaximumRenderedPageSize());
        //</Snippet137>
        //<Snippet138>
        sb.AppendLine(TestMaximumSoftkeyLabelLength());
        //</Snippet138>
        //<Snippet139>
        sb.AppendLine(TestMinorVersion());
        //</Snippet139>
        //<Snippet140>
        sb.AppendLine(TestMinorVersionString());
        //</Snippet140>
        //<Snippet141>
        sb.AppendLine(TestMobileDeviceManufacturer());
        //</Snippet141>
        //<Snippet142>
        sb.AppendLine(TestMobileDeviceModel());
        //</Snippet142>
        //<Snippet143>
        sb.AppendLine(TestMSDomVersion());
        //</Snippet143>
        //<Snippet144>
        sb.AppendLine(TestNumberOfSoftKeys());
        //</Snippet144>
        //<Snippet145>
        sb.AppendLine(TestPlatform());
        //</Snippet145>
        //<Snippet146>
        sb.AppendLine(TestPreferredImageMime());
        //</Snippet146>
        //<Snippet147>
        sb.AppendLine(TestPreferredRenderingMime());
        //</Snippet147>
        //<Snippet148>
        sb.AppendLine(TestPreferredRenderingType());
        //</Snippet148>
        //<Snippet149>
        sb.AppendLine(TestPreferredRequestEncoding());
        //</Snippet149>
        //<Snippet150>
        sb.AppendLine(TestPreferredResponseEncoding());
        //</Snippet150>
        //<Snippet151>
        sb.AppendLine(TestRenderBreakBeforeWmlSelectAndInput());
        //</Snippet151>
        //<Snippet152>
        sb.AppendLine(TestRendersBreaksAfterHtmlLists());
        //</Snippet152>
        //<Snippet153>
        sb.AppendLine(TestRendersBreaksAfterWmlAnchor());
        //</Snippet153>
        //<Snippet154>
        sb.AppendLine(TestRendersBreaksAfterWmlInput());
        //</Snippet154>
        //<Snippet155>
        sb.AppendLine(TestRendersWmlDoAcceptsInline());
        //</Snippet155>
        //<Snippet157>
        sb.AppendLine(TestRendersWmlSelectsAsMenuCards());
        //</Snippet157>
        //<Snippet158>
        sb.AppendLine(TestRequiredMetaTagNameValue());
        //</Snippet158>
        //<Snippet159>
        sb.AppendLine(TestRequiresAttributeColonSubstitution());
        //</Snippet159>
        //<Snippet160>
        sb.AppendLine(TestRequiresContentTypeMetaTag());
        //</Snippet160>
        //<Snippet161>
        sb.AppendLine(TestRequiresControlStateInSession());
        //</Snippet161>
        //<Snippet162>
        sb.AppendLine(TestRequiresDBCSCharacter());
        //</Snippet162>
        //<Snippet163>
        sb.AppendLine(TestRequiresHtmlAdaptiveErrorReporting());
        //</Snippet163>
        //<Snippet164>
        sb.AppendLine(TestRequiresLeadingPageBreak());
        //</Snippet164>
        //<Snippet165>
        sb.AppendLine(TestRequiresNoBreakInFormatting());
        //</Snippet165>
        //<Snippet166>
        sb.AppendLine(TestRequiresOutputOptimization());
        //</Snippet166>
        //<Snippet167>
        sb.AppendLine(TestRequiresPhoneNumberAsPlainText());
        //</Snippet167>
        //<Snippet168>
        sb.AppendLine(TestRequiresSpecialViewStateEncoding());
        //</Snippet168>
        //<Snippet169>
        sb.AppendLine(TestRequiresUniqueFilePathSuffix());
        //</Snippet169>
        //<Snippet170>
        sb.AppendLine(TestRequiresUniqueHtmlCheckboxNames());
        //</Snippet170>
        //<Snippet171>
        sb.AppendLine(TestRequiresUniqueHtmlInputNames());
        //</Snippet171>
        //<Snippet172>
        sb.AppendLine(TestRequiresUrlEncodedPostfieldValues());
        //</Snippet172>
        //<Snippet173>
        sb.AppendLine(TestScreenBitDepth());
        //</Snippet173>
        //<Snippet174>
        sb.AppendLine(TestScreenCharactersHeight());
        //</Snippet174>
        //<Snippet175>
        sb.AppendLine(TestScreenCharactersWidth());
        //</Snippet175>
        //<Snippet176>
        sb.AppendLine(TestScreenPixelsHeight());
        //</Snippet176>
        //<Snippet177>
        sb.AppendLine(TestScreenPixelsWidth());
        //</Snippet177>
        //<Snippet178>
        sb.AppendLine(TestScreenAccesskeyAttribute());
        //</Snippet178>
        //<Snippet179>
        sb.AppendLine(TestSupportsBodyColor());
        //</Snippet179>
        //<Snippet180>
        sb.AppendLine(TestSupportsBold());
        //</Snippet180>
        //<Snippet181>
        sb.AppendLine(TestSupportsCacheControlMetaTag());
        //</Snippet181>
        //<Snippet182>
        sb.AppendLine(TestSupportsCallback());
        //</Snippet182>
        //<Snippet183>
        sb.AppendLine(TestSupportsCookies());
        //</Snippet183>
        //<Snippet184>
        sb.AppendLine(TestSupportsCss());
        //</Snippet184>
        //<Snippet185>
        sb.AppendLine(TestSupportsDivAlign());
        //</Snippet185>
        //<Snippet186>
        sb.AppendLine(TestSupportsDivNoWrap());
        //</Snippet186>
        //<Snippet187>
        sb.AppendLine(TestSupportsEmptyStringInCookieValue());
        //</Snippet187>
        //<Snippet188>
        sb.AppendLine(TestSupportsFontColor());
        //</Snippet188>
        //<Snippet189>
        sb.AppendLine(TestSupportsFontName());
        //</Snippet189>
        //<Snippet190>
        sb.AppendLine(TestSupportsFontSize());
        //</Snippet190>
        //<Snippet192>
        sb.AppendLine(TestSupportsFrames());
        //</Snippet192>
        //<Snippet193>
        sb.AppendLine(TestSupportsImageSubmit());
        //</Snippet193>
        //<Snippet194>
        sb.AppendLine(TestSupportsIModeSymbols());
        //</Snippet194>
        //<Snippet195>
        sb.AppendLine(TestSupportsInputIStyle());
        //</Snippet195>
        //<Snippet196>
        sb.AppendLine(TestSupportsInputMode());
        //</Snippet196>
        //<Snippet197>
        sb.AppendLine(TestSupportsItalic());
        //</Snippet197>
        //<Snippet198>
        sb.AppendLine(TestSupportsJava());
        //</Snippet198>
        //<Snippet199>
        sb.AppendLine(TestSupportsJPhoneMultiMediaAttributes());
        //</Snippet199>
        //<Snippet200>
        sb.AppendLine(TestSupportsJPhoneSymbols());
        //</Snippet200>
        //<Snippet201>
        sb.AppendLine(TestSupportsQueryStringInFormAction());
        //</Snippet201>
        //<Snippet202>
        sb.AppendLine(TestSupportsRedirectWithCookie());
        //</Snippet202>
        //<Snippet203>
        sb.AppendLine(TestSupportsSelectMultiple());
        //</Snippet203>
        //<Snippet204>
        sb.AppendLine(TestSupportsUncheck());
        //</Snippet204>
        //<Snippet205>
        sb.AppendLine(TestSupportsXmlHttp());
        //</Snippet205>
        //<Snippet206>
        sb.AppendLine(TestTables());
        //</Snippet206>
        //<Snippet207>
        sb.AppendLine(TestType());
        //</Snippet207>
        //<Snippet208>
        sb.AppendLine(TestVBScript());
        //</Snippet208>
        //<Snippet209>
        sb.AppendLine(TestVersion());
        //</Snippet209>
        //<Snippet210>
        sb.AppendLine(TestW3CDomVersion());
        //</Snippet210>
        //<Snippet211>
        sb.AppendLine(TestWin16());
        //</Snippet211>
        //<Snippet212>
        sb.AppendLine(TestWin32());
        //</Snippet212>        
//<Snippet3>
        return sb.ToString().Replace(Environment.NewLine,"<br />");
    }
//</Snippet3>
//<Snippet300>
    String TestActiveXControls() 
    {
        return String.Format("Supports ActiveX controls: {0}",
            bCaps.ActiveXControls); 
    }
//</Snippet300>

    //<Snippet301>
    String TestAdapters()
    {
        return String.Format("Adapter count: {0}", 
            bCaps.Adapters.Count);
    }
    //</Snippet301>
        
    //<Snippet302>
    String TestAOL()
    {
        return String.Format("Is an AOL browser: {0}", 
            bCaps.AOL.ToString());
    }
    //</Snippet302>

    //<Snippet303>
    String TestBackgroundSounds()
    {
        return String.Format("Supports background sounds: {0}",
            bCaps.BackgroundSounds);
    }
    //</Snippet303>
        
    //<Snippet304>
    String TestBeta()
    {
        return String.Format("Is a beta version: {0}", 
            bCaps.Beta);
    }
    //</Snippet304>
        
    //<Snippet305>
    String TestBrowser()
    {
        return String.Format("Browser type: {0}", 
            bCaps.Browser);
    }
    //</Snippet305>

    //<Snippet307>
    String TestBrowsers()
    {
        return String.Format("Number of browsers in dictionary: {0}",
            bCaps.Browsers.Count);
    }
    //</Snippet307>

    //<Snippet319>
    String TestCombineDeck()
    {
        return String.Format("Can combine forms in deck: {0}",
            bCaps.CanCombineFormsInDeck);
    }
    //</Snippet319>

    //<Snippet308>
    String TestCanCall()
    {
        return String.Format("Can initiate voice call: {0}",
            bCaps.CanInitiateVoiceCall);
    }
    //</Snippet308>

    //<Snippet309>
    String TestCanRenderAfter()
    {
        return String.Format("Can render {0}: {1}",
            "after input or select element",
            bCaps.CanRenderAfterInputOrSelectElement);
    }
    //</Snippet309>

    //<Snippet310>
    String TestCanRenderEmpty()
    {
        return String.Format("Can render empty selects: {0}",
            bCaps.CanRenderEmptySelects);
    }
    //</Snippet310>

    //<Snippet311>
    String TestCanRenderInputSelectTogether()
    {
        return String.Format("Can render {0} together: {1}",
            "input and select elements",
            bCaps.CanRenderInputAndSelectElementsTogether);
    }
    //</Snippet311>

    //<Snippet312>
    String TestCanRenderMixedSelects()
    {
        return String.Format("Can render mixed selects: {0}",
            bCaps.CanRenderMixedSelects);
    }
    //</Snippet312>

    //<Snippet313>
    String TestCanRenderOneventPrevTogether()
    {
        return String.Format("Can render {0} together: {1}",
            "OnEvent and Prev elements",
            bCaps.CanRenderOneventAndPrevElementsTogether);
    }
    //</Snippet313>

    //<Snippet314>
    String TestCanRenderPostBackCards()
    {
        return String.Format("Can render postback cards: {0}",
            bCaps.CanRenderPostBackCards);
    }
    //</Snippet314>

    //<Snippet315>
    String TestCanRenderSetvar()
    {
        return String.Format("Can render {0}: {1}",
            "setvar elements with a value of 0",
            bCaps.CanRenderSetvarZeroWithMultiSelectionList);
    }
    //</Snippet315>

    //<Snippet316>
    String TestCanSendMail()
    {
        return String.Format("Can send mail: {0}",
            bCaps.CanSendMail);
    }
    //</Snippet316>

    //<Snippet317>
    String TestCDF()
    {
        return String.Format("Supports {0}: {1}",
            "Channel Definition Format",
            bCaps.CDF.ToString());
    }
    //</Snippet317>

    //<Snippet318>
    String TestCLRVersion()
    {
        return String.Format("CLR version on client: {0}",
            bCaps.ClrVersion);
    }
    //</Snippet318>

    //<Snippet383>
    String TestSupportsCookies()
    {
        return String.Format("Supports cookies: {0}",
            bCaps.Cookies);
    }
    //</Snippet383>

    //<Snippet331>
    String TestIsCrawler()
    {
        return String.Format("Is a crawler: {0}",
            bCaps.Crawler);
    }
    //</Snippet331>
        
    //<Snippet320>
    String TestDefaultSubmitButton()
    {
        return String.Format("Submit button limit: {0}",
            bCaps.DefaultSubmitButtonLimit);
    }
    //</Snippet320>

    //<Snippet321>
    String TestECMAScriptVersion()
    {
        return String.Format("ECMA script version: {0}",
            bCaps.EcmaScriptVersion);
    }
    //</Snippet321>

    //<Snippet392>
    String TestSupportsFrames()
    {
        return String.Format("Supports frames: {0}",
            bCaps.Frames);
    }
    //</Snippet392>

    //<Snippet323>
    String TestGatewayMajorVersion()
    {
        return String.Format("Gateway major version: {0}",
            bCaps.GatewayMajorVersion.ToString());
    }
    //</Snippet323>

    //<Snippet324>
    String TestGatewayMinorVersion()
    {
        return String.Format("Gateway minor version: {0}",
            bCaps.GatewayMinorVersion.ToString());
    }
    //</Snippet324>

    //<Snippet325>
    String TestGatewayVersion()
    {
        return String.Format("Gateway version: {0}",
            bCaps.GatewayVersion.ToString());
    }
    //</Snippet325>

    //<Snippet326>
    String TestHasBackButton()
    {
        return String.Format("Has back button: {0}",
            bCaps.HasBackButton.ToString());
    }
    //</Snippet326>

    //<Snippet327>
    String TestHideRtAlignScrollBars()
    {
        return String.Format("Hide right-aligned {0}: {1}",
            "multi-select scrollbars",
            bCaps.HidesRightAlignedMultiselectScrollbars.ToString());
    }
    //</Snippet327>

    //<Snippet306>
    String TestBrowserID()
    {
        return String.Format("Browser ID: {0}",
            bCaps.Id);
    }
    //</Snippet306>

    //<Snippet328>
    String TestInputType()
    {
        return String.Format("Supported input type: {0}",
            bCaps.InputType);
    }
    //</Snippet328>

    //<Snippet329>
    String TestIsBrowser()
    {
        return String.Format("Is client a given browser: {0}",
            bCaps.IsBrowser("IE").ToString());
    }
    //</Snippet329>

    //<Snippet330>
    String TestIsColor()
    {
        return String.Format("Is color display: {0}",
            bCaps.IsColor.ToString());
    }
    //</Snippet330>

    //<Snippet332>
    String TestIsMobileDevice()
    {
        return String.Format("Is mobile device: {0}",
            bCaps.IsMobileDevice.ToString());
    }
    //</Snippet332>

    //<Snippet398>
    String TestSupportsJava()
    {
        return String.Format("Supports Java: {0}",
            bCaps.JavaApplets.ToString());
    }
    //</Snippet398>

    //<Snippet333>
    String TestJavaScript()
    {
        return String.Format("Supports JavaScript: {0}",
            bCaps.JavaScript.ToString());
    }
    //</Snippet333>

    //<Snippet334>
    String TestJScriptVersion()
    {
        return String.Format("JScript version: {0}",
            bCaps.JScriptVersion.ToString());
    }
    //</Snippet334>

    //<Snippet335>
    String TestMajorVersion()
    {
        return String.Format("Major version of browser: {0}",
            bCaps.MajorVersion.ToString());
    }
    //</Snippet335>

    //<Snippet336>
    String TestMaximumHrefLength()
    {
        return String.Format("Max. href length: {0}",
            bCaps.MaximumHrefLength.ToString());
    }
    //</Snippet336>

    //<Snippet337>
    String TestMaximumRenderedPageSize()
    {
        return String.Format("Max. rendered page size in bytes: {0}",
            bCaps.MaximumRenderedPageSize.ToString());
    }
    //</Snippet337>
        
    //<Snippet338>
    String TestMaximumSoftkeyLabelLength()
    {
        return String.Format("Max. softkey label length: {0}",
            bCaps.MaximumSoftkeyLabelLength.ToString());
    }
    //</Snippet338>
        
    //<Snippet339>
    String TestMinorVersion()
    {
        return String.Format("Minor browser version: {0}",
            bCaps.MinorVersion.ToString());
    }
    //</Snippet339>
        
    //<Snippet340>
    String TestMinorVersionString()
    {
        return String.Format("Minor browser version {0}: {1}",
            "(as string)",
            bCaps.MinorVersionString);
    }
    //</Snippet340>
        
    //<Snippet341>
    String TestMobileDeviceManufacturer()
    {
        return String.Format("Mobile device manufacturer: {0}",
            bCaps.MobileDeviceManufacturer);
    }
    //</Snippet341>

    //<Snippet342>
    String TestMobileDeviceModel()
    {
        return String.Format("Mobile device model: {0}",
            bCaps.MobileDeviceModel);
    }
    //</Snippet342>

    //<Snippet343>
    String TestMSDomVersion()
    { 
        return String.Format("MS DOM version: {0}",
            bCaps.MSDomVersion.ToString());
    }
    //</Snippet343>

    //<Snippet344>
    String TestNumberOfSoftKeys()
    {
        return String.Format("Number of soft keys: {0}",
            bCaps.NumberOfSoftkeys.ToString());
    }
    //</Snippet344>

    //<Snippet345>
    String TestPlatform()
    {
        return String.Format("Platform of client: {0}",
            bCaps.Platform);
    }
    //</Snippet345>

    //<Snippet346>
    String TestPreferredImageMime()
    {
        return String.Format("Preferred image MIME: {0}",
            bCaps.PreferredImageMime);
    }
    //</Snippet346>

    //<Snippet347>
    String TestPreferredRenderingMime()
    {
        return String.Format("Preferred rendering MIME: {0}",
            bCaps.PreferredRenderingMime);
    }
    //</Snippet347>

    //<Snippet348>
    String TestPreferredRenderingType()
    {
        return String.Format("Preferred rendering type: {0}",
            bCaps.PreferredRenderingType);
    }
    //</Snippet348>

    //<Snippet349>
    String TestPreferredRequestEncoding()
    {
        return String.Format("Preferred request encoding: {0}",
            bCaps.PreferredRequestEncoding);
    }
    //</Snippet349>

    //<Snippet350>
    String TestPreferredResponseEncoding()
    {
        return String.Format("Preferred response encoding: {0}",
            bCaps.PreferredResponseEncoding);
    }
    //</Snippet350>

    //<Snippet351>
    String TestRenderBreakBeforeWmlSelectAndInput()
    {
        return String.Format("Renders {0}: {1}",
            "break before WML select/input",
            bCaps.RendersBreakBeforeWmlSelectAndInput.ToString());
    }
    //</Snippet351>

    //<Snippet352>
    String TestRendersBreaksAfterHtmlLists()
    {
        return String.Format("Renders breaks after HTML lists: {0}",
            bCaps.RendersBreaksAfterHtmlLists);
    }
    //</Snippet352>

    //<Snippet353>
    String TestRendersBreaksAfterWmlAnchor()
    {
        return String.Format("Renders breaks after Wml anchor: {0}",
            bCaps.RendersBreaksAfterWmlAnchor);
    }
    //</Snippet353>

    //<Snippet354>
    String TestRendersBreaksAfterWmlInput()
    {
        return String.Format("Renders breaks after Wml input: {0}",
            bCaps.RendersBreaksAfterWmlInput);
    }
    //</Snippet354>

    //<Snippet355>
    String TestRendersWmlDoAcceptsInline()
    {
        return String.Format("Renders Wml do accepts inline: {0}",
            bCaps.RendersWmlDoAcceptsInline);
    }
    //</Snippet355>

    //<Snippet357>
    String TestRendersWmlSelectsAsMenuCards()
    {
        return String.Format("Renders {0}: {1}",
            "break before WML select/input",
            bCaps.RendersWmlSelectsAsMenuCards);
    }
    //</Snippet357>

    //<Snippet358>
    String TestRequiredMetaTagNameValue()
    {
        return String.Format("Required meta tag name value: {0}",
            bCaps.RequiredMetaTagNameValue);
    }
    //</Snippet358>

    //<Snippet359>
    String TestRequiresAttributeColonSubstitution()
    {
        return String.Format("Requires {0}: {1}",
            "break before WML select/input",
            bCaps.RequiresAttributeColonSubstitution);
    }
    //</Snippet359>

    //<Snippet360>
    String TestRequiresContentTypeMetaTag()
    {
        return String.Format("Requires content type meta tag: {0}",
            bCaps.RequiresContentTypeMetaTag);
    }
    //</Snippet360>

    //<Snippet361>
    String TestRequiresControlStateInSession()
    {
        return String.Format("Requires {0}: {1}",
            "control state in session",
            bCaps.RequiresControlStateInSession);
    }
    //</Snippet361>

    //<Snippet362>
    String TestRequiresDBCSCharacter()
    {
        return String.Format("Requires DBCS character: {0}",
            bCaps.RequiresDBCSCharacter);
    }
    //</Snippet362>
        
    //<Snippet363>
    String TestRequiresHtmlAdaptiveErrorReporting()
    {
        return String.Format("Requires HTML adaptive error reporting: {0}",
            bCaps.RequiresHtmlAdaptiveErrorReporting);
    }
    //</Snippet363>

    //<Snippet364>
    String TestRequiresLeadingPageBreak()
    {
        return String.Format("Requires leading page break: {0}",
            bCaps.RequiresLeadingPageBreak);
    }
    //</Snippet364>

    //<Snippet365>
    String TestRequiresNoBreakInFormatting()
    {
        return String.Format("Requires no break in formatting: {0}",
            bCaps.RequiresNoBreakInFormatting);
    }
    //</Snippet365>

    //<Snippet366>
    String TestRequiresOutputOptimization()
    {
        return String.Format("Requires output optimization: {0}",
            bCaps.RequiresOutputOptimization);
    }
    //</Snippet366>

    //<Snippet367>
    String TestRequiresPhoneNumberAsPlainText()
    {
        return String.Format("Requires phone number as text: {0}",
            bCaps.RequiresPhoneNumbersAsPlainText);
    }
    //</Snippet367>

    //<Snippet368>
    String TestRequiresSpecialViewStateEncoding()
    {
        return String.Format("Requires special viewstate encoding: {0}",
            bCaps.RequiresSpecialViewStateEncoding);
    }
    //</Snippet368>

    //<Snippet369>
    String TestRequiresUniqueFilePathSuffix()
    {
        return String.Format("Requires unique file path suffix: {0}",
            bCaps.RequiresUniqueFilePathSuffix);
    }
    //</Snippet369>

    //<Snippet370>
    String TestRequiresUniqueHtmlCheckboxNames()
    {
        return String.Format("Requires unique HTML checkbox names: {0}",
            bCaps.RequiresUniqueHtmlCheckboxNames);
    }
    //</Snippet370>

    //<Snippet371>
    String TestRequiresUniqueHtmlInputNames()
    {
        return String.Format("Requires unique HTML input names: {0}",
            bCaps.RequiresUniqueHtmlInputNames);
    }
    //</Snippet371>

    //<Snippet372>
    String TestRequiresUrlEncodedPostfieldValues()
    {
        return String.Format("Requires URL encoded postfield values: {0}",
            bCaps.RequiresUrlEncodedPostfieldValues);
    }
    //</Snippet372>

    //<Snippet373>
    String TestScreenBitDepth()
    {
        return String.Format("Screen bit depth: {0}",
            bCaps.ScreenBitDepth);
    }
    //</Snippet373>

    //<Snippet374>
    String TestScreenCharactersHeight()
    {
        return String.Format("Screen height in character lines: {0}",
            bCaps.ScreenCharactersHeight);
    }
    //</Snippet374>

    //<Snippet375>
    String TestScreenCharactersWidth()
    {
        return String.Format("Screen width in characters: {0}",
            bCaps.ScreenCharactersWidth);
    }
    //</Snippet375>

    //<Snippet376>
    String TestScreenPixelsHeight()
    {
        return String.Format("Screen height in pixels: {0}",
            bCaps.ScreenPixelsHeight);
    }
    //</Snippet376>

    //<Snippet377>
    String TestScreenPixelsWidth()
    {
        return String.Format("Screen width in pixels: {0}",
            bCaps.ScreenPixelsWidth);
    }
    //</Snippet377>

    //<Snippet378>
    String TestScreenAccesskeyAttribute()
    {
        return String.Format("Supports ACCESSKEY: {0}",
            bCaps.SupportsAccesskeyAttribute);
    }
    //</Snippet378>

    //<Snippet379>
    String TestSupportsBodyColor()
    {
        return String.Format("Supports body color: {0}",
            bCaps.SupportsBodyColor);
    }
    //</Snippet379>

    //<Snippet380>
    String TestSupportsBold()
    {
        return String.Format("Supports bold: {0}",
            bCaps.SupportsBold);
    }
    //</Snippet380>

    //<Snippet381>
    String TestSupportsCacheControlMetaTag()
    {
        return String.Format("Supports cache-control meta tag: {0}",
            bCaps.SupportsCacheControlMetaTag);
    }
    //</Snippet381>

    //<Snippet382>
    String TestSupportsCallback()
    {
        return String.Format("Supports callback: {0}",
            bCaps.SupportsCallback);
    }
    //</Snippet382>

    //<Snippet384>
    String TestSupportsCss()
    {
        return String.Format("Supports CSS: {0}",
            bCaps.SupportsCss);
    }
    //</Snippet384>

    //<Snippet385>
    String TestSupportsDivAlign()
    {
        return String.Format("Supports DIV align: {0}",
            bCaps.SupportsDivAlign);
    }
    //</Snippet385>

    //<Snippet386>
    String TestSupportsDivNoWrap()
    {
        return String.Format("Supports DIV nowrap: {0}",
            bCaps.SupportsDivNoWrap);
    }
    //</Snippet386>

    //<Snippet387>
    String TestSupportsEmptyStringInCookieValue()
    {
        return String.Format("Supports empty string in cookie value: {0}",
            bCaps.SupportsEmptyStringInCookieValue);
    }
    //</Snippet387>

    //<Snippet388>
    String TestSupportsFontColor()
    {
        return String.Format("Supports font color: {0}",
            bCaps.SupportsFontColor);
    }
    //</Snippet388>

    //<Snippet389>
    String TestSupportsFontName()
    {
        return String.Format("Supports font name: {0}",
            bCaps.SupportsFontName);
    }
    //</Snippet389>

    //<Snippet390>
    String TestSupportsFontSize()
    {
        return String.Format("Supports font size: {0}",
            bCaps.SupportsFontSize);
    }
    //</Snippet390>

    //<Snippet393>
    String TestSupportsImageSubmit()
    {
        return String.Format("Supports image submit: {0}",
            bCaps.SupportsImageSubmit);
    }
    //</Snippet393>

    //<Snippet394>
    String TestSupportsIModeSymbols()
    {
        return String.Format("Supports i-mode symbols: {0}",
            bCaps.SupportsIModeSymbols);
    }
    //</Snippet394>

    //<Snippet395>
    String TestSupportsInputIStyle()
    {
        return String.Format("Supports input istyle attribute: {0}",
            bCaps.SupportsInputIStyle);
    }
    //</Snippet395>

    //<Snippet396>
    String TestSupportsInputMode()
    {
        return String.Format("Supports input mode: {0}",
            bCaps.SupportsInputMode);
    }
    //</Snippet396>

    //<Snippet397>
    String TestSupportsItalic()
    {
        return String.Format("Supports italics: {0}",
            bCaps.SupportsItalic);
    }
    //</Snippet397>

    //<Snippet399>
    String TestSupportsJPhoneMultiMediaAttributes()
    {
        return String.Format("Supports JPhone multimedia attributes: {0}",
            bCaps.SupportsJPhoneMultiMediaAttributes);
    }
    //</Snippet399>

    //<Snippet400>
    String TestSupportsJPhoneSymbols()
    {
        return String.Format("Supports JPhone picture symbols: {0}",
            bCaps.SupportsJPhoneSymbols);
    }
    //</Snippet400>

    //<Snippet401>
    String TestSupportsQueryStringInFormAction()
    {
        return String.Format("Supports querystring in form action: {0}",
            bCaps.SupportsQueryStringInFormAction);
    }
    //</Snippet401>

    //<Snippet402>
    String TestSupportsRedirectWithCookie()
    {
        return String.Format("Supports redirect with cookie: {0}",
            bCaps.SupportsRedirectWithCookie);
    }
    //</Snippet402>

    //<Snippet403>
    String TestSupportsSelectMultiple()
    {
        return String.Format("Supports select multiple: {0}",
            bCaps.SupportsSelectMultiple);
    }
    //</Snippet403>

    //<Snippet404>
    String TestSupportsUncheck()
    {
        return String.Format("Supports uncheck: {0}",
            bCaps.SupportsUncheck);
    }
    //</Snippet404>

    //<Snippet405>
    String TestSupportsXmlHttp()
    {
        return String.Format("Supports receiving XML over HTTP: {0}",
            bCaps.SupportsXmlHttp);
    }
    //</Snippet405>

    //<Snippet406>
    String TestTables()
    {
        return String.Format("Supports tables: {0}",
            bCaps.Tables);
    }
    //</Snippet406>
    
    //<Snippet407>
    String TestType()
    {
        return String.Format("Gets the browser name/version: {0}",
            bCaps.Type);
    }
    //</Snippet407>

    //<Snippet408>
    String TestVBScript()
    {
        return String.Format("Supports VBScript: {0}",
            bCaps.VBScript);
    }
    //</Snippet408>

    //<Snippet409>
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
    //</Snippet409>

    //<Snippet410>
    String TestW3CDomVersion()
    {
        return String.Format("W3C DOM version: {0}",
            bCaps.W3CDomVersion);
    }
    //</Snippet410>

    //<Snippet411>
    String TestWin16()
    {
        return String.Format("Is Win16-based computer: {0}",
            bCaps.Win16);
    }
    //</Snippet411>

    //<Snippet412>
    String TestWin32()
    {
        return String.Format("Is Win32-based computer: {0}",
            bCaps.Win32);
    }
    //</Snippet412>
// <Snippet4>        
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
<!-- </Snippet4> -->
<!-- </Snippet1> -->
