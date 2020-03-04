<!-- <Snippet1> -->
<!-- <Snippet2> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
Dim bCaps As System.Web.HttpBrowserCapabilities

    Sub Page_Load(ByVal Sender As Object, ByVal e As EventArgs)
        bCaps = Request.Browser
        OutputLabel.Text = TestCaps()
    End Sub

    Function TestCaps() As String
        Dim sb As StringBuilder
        sb = New StringBuilder()
        '</Snippet2>
        '<Snippet100>
        sb.AppendLine(TestActiveXControls())
        '</Snippet100>
        '<Snippet101>
        sb.AppendLine(TestAdapters())
        '</Snippet101>
        '<Snippet102>
        sb.AppendLine(TestAOL())
        '</Snippet102>
        '<Snippet103>
        sb.AppendLine(TestBackgroundSounds())
        '</Snippet103>
        '<Snippet104>
        sb.AppendLine(TestBeta())
        '</Snippet104>
        '<Snippet105>
        sb.AppendLine(TestBrowser())
        '</Snippet105>
        '<Snippet106>
        sb.AppendLine(TestBrowserID())
        '</Snippet106>
        '<Snippet107>
        sb.AppendLine(TestBrowsers())
        '</Snippet107>
        '<Snippet108>
        sb.AppendLine(TestCanCall())
        '</Snippet108>
        '<Snippet109>
        sb.AppendLine(TestCanRenderAfter())
        '</Snippet109>
        '<Snippet110>
        sb.AppendLine(TestCanRenderEmpty())
        '</Snippet110>
        '<Snippet111>
        sb.AppendLine(TestCanRenderInputSelectTogether())
        '</Snippet111>
        '<Snippet112>
        sb.AppendLine(TestCanRenderMixedSelects())
        '</Snippet112>
        '<Snippet113>
        sb.AppendLine(TestCanRenderOneventPrevTogether())
        '</Snippet113>
        '<Snippet114>
        sb.AppendLine(TestCanRenderPostBackCards())
        '</Snippet114>
        '<Snippet115>
        sb.AppendLine(TestCanRenderSetvar())
        '</Snippet115>
        '<Snippet116>
        sb.AppendLine(TestCanSendMail())
        '</Snippet116>
        '<Snippet117>
        sb.AppendLine(TestCDF())
        '</Snippet117>
        '<Snippet118>
        sb.AppendLine(TestCLRVersion())
        '</Snippet118>
        '<Snippet119>
        sb.AppendLine(TestCombineDeck())
        '</Snippet119>
        '<Snippet120>
        sb.AppendLine(TestDefaultSubmitButton())
        '</Snippet120>
        '<Snippet121>
        sb.AppendLine(TestECMAScriptVersion())
        '</Snippet121>
        '<Snippet123>
        sb.AppendLine(TestGatewayMajorVersion())
        '</Snippet123>
        '<Snippet124>
        sb.AppendLine(TestGatewayMinorVersion())
        '</Snippet124>
        '<Snippet125>
        sb.AppendLine(TestGatewayVersion())
        '</Snippet125>
        '<Snippet126>
        sb.AppendLine(TestHasBackButton())
        '</Snippet126>
        '<Snippet127>
        sb.AppendLine(TestHideRtAlignScrollBars())
        '</Snippet127>
        '<Snippet128>
        sb.AppendLine(TestInputType())
        '</Snippet128>
        '<Snippet129>
        sb.AppendLine(TestIsBrowser())
        '</Snippet129>
        '<Snippet130>
        sb.AppendLine(TestIsColor())
        '</Snippet130>
        '<Snippet131>
        sb.AppendLine(TestIsCrawler())
        '</Snippet131>
        '<Snippet132>
        sb.AppendLine(TestIsMobileDevice())
        '</Snippet132>
        '<Snippet133>
        sb.AppendLine(TestJavaScript())
        '</Snippet133>
        '<Snippet134>
        sb.AppendLine(TestJScriptVersion())
        '</Snippet134>
        '<Snippet135>
        sb.AppendLine(TestMajorVersion())
        '</Snippet135>
        '<Snippet136>
        sb.AppendLine(TestMaximumHrefLength())
        '</Snippet136>
        '<Snippet137>
        sb.AppendLine(TestMaximumRenderedPageSize())
        '</Snippet137>
        '<Snippet138>
        sb.AppendLine(TestMaximumSoftkeyLabelLength())
        '</Snippet138>
        '<Snippet139>
        sb.AppendLine(TestMinorVersion())
        '</Snippet139>
        '<Snippet140>
        sb.AppendLine(TestMinorVersionString())
        '</Snippet140>
        '<Snippet141>
        sb.AppendLine(TestMobileDeviceManufacturer())
        '</Snippet141>
        '<Snippet142>
        sb.AppendLine(TestMobileDeviceModel())
        '</Snippet142>
        '<Snippet143>
        sb.AppendLine(TestMSDomVersion())
        '</Snippet143>
        '<Snippet144>
        sb.AppendLine(TestNumberOfSoftKeys())
        '</Snippet144>
        '<Snippet145>
        sb.AppendLine(TestPlatform())
        '</Snippet145>
        '<Snippet146>
        sb.AppendLine(TestPreferredImageMime())
        '</Snippet146>
        '<Snippet147>
        sb.AppendLine(TestPreferredRenderingMime())
        '</Snippet147>
        '<Snippet148>
        sb.AppendLine(TestPreferredRenderingType())
        '</Snippet148>
        '<Snippet149>
        sb.AppendLine(TestPreferredRequestEncoding())
        '</Snippet149>
        '<Snippet150>
        sb.AppendLine(TestPreferredResponseEncoding())
        '</Snippet150>
        '<Snippet151>
        sb.AppendLine(TestRenderBreakBeforeWmlSelectAndInput())
        '</Snippet151>
        '<Snippet152>
        sb.AppendLine(TestRendersBreaksAfterHtmlLists())
        '</Snippet152>
        '<Snippet153>
        sb.AppendLine(TestRendersBreaksAfterWmlAnchor())
        '</Snippet153>
        '<Snippet154>
        sb.AppendLine(TestRendersBreaksAfterWmlInput())
        '</Snippet154>
        '<Snippet155>
        sb.AppendLine(TestRendersWmlDoAcceptsInline())
        '</Snippet155>
        '<Snippet157>
        sb.AppendLine(TestRendersWmlSelectsAsMenuCards())
        '</Snippet157>
        '<Snippet158>
        sb.AppendLine(TestRequiredMetaTagNameValue())
        '</Snippet158>
        '<Snippet159>
        sb.AppendLine(TestRequiresAttributeColonSubstitution())
        '</Snippet159>
        '<Snippet160>
        sb.AppendLine(TestRequiresContentTypeMetaTag())
        '</Snippet160>
        '<Snippet161>
        sb.AppendLine(TestRequiresControlStateInSession())
        '</Snippet161>
        '<Snippet162>
        sb.AppendLine(TestRequiresDBCSCharacter())
        '</Snippet162>
        '<Snippet163>
        sb.AppendLine(TestRequiresHtmlAdaptiveErrorReporting())
        '</Snippet163>
        '<Snippet164>
        sb.AppendLine(TestRequiresLeadingPageBreak())
        '</Snippet164>
        '<Snippet165>
        sb.AppendLine(TestRequiresNoBreakInFormatting())
        '</Snippet165>
        '<Snippet166>
        sb.AppendLine(TestRequiresOutputOptimization())
        '</Snippet166>
        '<Snippet167>
        sb.AppendLine(TestRequiresPhoneNumberAsPlainText())
        '</Snippet167>
        '<Snippet168>
        sb.AppendLine(TestRequiresSpecialViewStateEncoding())
        '</Snippet168>
        '<Snippet169>
        sb.AppendLine(TestRequiresUniqueFilePathSuffix())
        '</Snippet169>
        '<Snippet170>
        sb.AppendLine(TestRequiresUniqueHtmlCheckboxNames())
        '</Snippet170>
        '<Snippet171>
        sb.AppendLine(TestRequiresUniqueHtmlInputNames())
        '</Snippet171>
        '<Snippet172>
        sb.AppendLine(TestRequiresUrlEncodedPostfieldValues())
        '</Snippet172>
        '<Snippet173>
        sb.AppendLine(TestScreenBitDepth())
        '</Snippet173>
        '<Snippet174>
        sb.AppendLine(TestScreenCharactersHeight())
        '</Snippet174>
        '<Snippet175>
        sb.AppendLine(TestScreenCharactersWidth())
        '</Snippet175>
        '<Snippet176>
        sb.AppendLine(TestScreenPixelsHeight())
        '</Snippet176>
        '<Snippet177>
        sb.AppendLine(TestScreenPixelsWidth())
        '</Snippet177>
        '<Snippet178>
        sb.AppendLine(TestScreenAccesskeyAttribute())
        '</Snippet178>
        '<Snippet179>
        sb.AppendLine(TestSupportsBodyColor())
        '</Snippet179>
        '<Snippet180>
        sb.AppendLine(TestSupportsBold())
        '</Snippet180>
        '<Snippet181>
        sb.AppendLine(TestSupportsCacheControlMetaTag())
        '</Snippet181>
        '<Snippet182>
        sb.AppendLine(TestSupportsCallback())
        '</Snippet182>
        '<Snippet183>
        sb.AppendLine(TestSupportsCookies())
        '</Snippet183>
        '<Snippet184>
        sb.AppendLine(TestSupportsCss())
        '</Snippet184>
        '<Snippet185>
        sb.AppendLine(TestSupportsDivAlign())
        '</Snippet185>
        '<Snippet186>
        sb.AppendLine(TestSupportsDivNoWrap())
        '</Snippet186>
        '<Snippet187>
        sb.AppendLine(TestSupportsEmptyStringInCookieValue())
        '</Snippet187>
        '<Snippet188>
        sb.AppendLine(TestSupportsFontColor())
        '</Snippet188>
        '<Snippet189>
        sb.AppendLine(TestSupportsFontName())
        '</Snippet189>
        '<Snippet190>
        sb.AppendLine(TestSupportsFontSize())
        '</Snippet190>
        '<Snippet192>
        sb.AppendLine(TestSupportsFrames())
        '</Snippet192>
        '<Snippet193>
        sb.AppendLine(TestSupportsImageSubmit())
        '</Snippet193>
        '<Snippet194>
        sb.AppendLine(TestSupportsIModeSymbols())
        '</Snippet194>
        '<Snippet195>
        sb.AppendLine(TestSupportsInputIStyle())
        '</Snippet195>
        '<Snippet196>
        sb.AppendLine(TestSupportsInputMode())
        '</Snippet196>
        '<Snippet197>
        sb.AppendLine(TestSupportsItalic())
        '</Snippet197>
        '<Snippet198>
        sb.AppendLine(TestSupportsJava())
        '</Snippet198>
        '<Snippet199>
        sb.AppendLine(TestSupportsJPhoneMultiMediaAttributes())
        '</Snippet199>
        '<Snippet200>
        sb.AppendLine(TestSupportsJPhoneSymbols())
        '</Snippet200>
        '<Snippet201>
        sb.AppendLine(TestSupportsQueryStringInFormAction())
        '</Snippet201>
        '<Snippet202>
        sb.AppendLine(TestSupportsRedirectWithCookie())
        '</Snippet202>
        '<Snippet203>
        sb.AppendLine(TestSupportsSelectMultiple())
        '</Snippet203>
        '<Snippet204>
        sb.AppendLine(TestSupportsUncheck())
        '</Snippet204>
        '<Snippet205>
        sb.AppendLine(TestSupportsXmlHttp())
        '</Snippet205>
        '<Snippet206>
        sb.AppendLine(TestTables())
        '</Snippet206>
        '<Snippet207>
        sb.AppendLine(TestType())
        '</Snippet207>
        '<Snippet208>
        sb.AppendLine(TestVBScript())
        '</Snippet208>
        '<Snippet209>
        sb.AppendLine(TestVersion())
        '</Snippet209>
        '<Snippet210>
        sb.AppendLine(TestW3CDomVersion())
        '</Snippet210>
        '<Snippet211>
        sb.AppendLine(TestWin16())
        '</Snippet211>
        '<Snippet212>
        sb.AppendLine(TestWin32())
        '</Snippet212>

        '<Snippet3>
        Return sb.ToString().Replace(Environment.NewLine, "<br />")
    End Function
    '</Snippet3>

    '<Snippet300>
    Function TestActiveXControls() As String
        Return String.Format("Supports ActiveX controls: {0}", _
            bCaps.ActiveXControls)
    End Function
    '</Snippet300>

    '<Snippet301>
    Function TestAdapters() As String
        Return String.Format("Adapter count: {0}", _
            bCaps.Adapters.Count)
    End Function
    '</Snippet301>
    
    '<Snippet302>
    Function TestAOL() As String
        Return String.Format("Is an AOL browser: {0}", _
            bCaps.AOL.ToString())
    End Function
    '</Snippet302>

    '<Snippet303>
    Function TestBackgroundSounds() As String
        Return String.Format("Supports background sounds: {0}", _
            bCaps.BackgroundSounds)
    End Function
    '</Snippet303>
    
    '<Snippet304>
    Function TestBeta() As String
        Return String.Format("Is a beta version: {0}", _
            bCaps.Beta)
    End Function
    '</Snippet304>
    
    '<Snippet305>
    Function TestBrowser() As String
        Return String.Format("Browser type: {0}", _
            bCaps.Browser)
    End Function
    '</Snippet305>

    '<Snippet307>
    Function TestBrowsers() As String
        Return String.Format("# of browsers in dictionary: {0}", _
            bCaps.Browsers.Count)
    End Function
    '</Snippet307>

    '<Snippet319>
    Function TestCombineDeck() As String
        Return String.Format("Can combine forms in deck: {0}", _
            bCaps.CanCombineFormsInDeck)
    End Function
    '</Snippet319>

    '<Snippet308>
    Function TestCanCall() As String
        Return String.Format("Can initiate voice call: {0}", _
            bCaps.CanInitiateVoiceCall)
    End Function
    '</Snippet308>

    '<Snippet309>
    Function TestCanRenderAfter() As String
        Return String.Format("Can render {0}: {1}", _
            "after input or select element", _
            bCaps.CanRenderAfterInputOrSelectElement)
    End Function
    '</Snippet309>

    '<Snippet310>
    Function TestCanRenderEmpty() As String
        Return String.Format("Can render empty selects: {0}", _
            bCaps.CanRenderEmptySelects)
    End Function
    '</Snippet310>

    '<Snippet311>
    Function TestCanRenderInputSelectTogether() As String
        Return String.Format("Can render {0} together: {1}", _
            "input and select elements", _
            bCaps.CanRenderInputAndSelectElementsTogether)
    End Function
    '</Snippet311>

    '<Snippet312>
    Function TestCanRenderMixedSelects() As String
        Return String.Format("Can render mixed selects: {0}", _
            bCaps.CanRenderMixedSelects)
    End Function
    '</Snippet312>

    '<Snippet313>
    Function TestCanRenderOneventPrevTogether() As String
        Return String.Format("Can render {0} together: {1}", _
            "OnEvent and Prev elements", _
            bCaps.CanRenderOneventAndPrevElementsTogether)
    End Function
    '</Snippet313>

    '<Snippet314>
    Function TestCanRenderPostBackCards() As String
        Return String.Format("Can render postback cards: {0}", _
            bCaps.CanRenderPostBackCards)
    End Function
    '</Snippet314>

    '<Snippet315>
    Function TestCanRenderSetvar() As String
        Return String.Format("Can render {0}: {1}", _
            "setvar elements with a value of 0", _
            bCaps.CanRenderSetvarZeroWithMultiSelectionList)
    End Function
    '</Snippet315>

    '<Snippet316>
    Function TestCanSendMail() As String
        Return String.Format("Can send mail: {0}", _
            bCaps.CanSendMail)
    End Function
    '</Snippet316>

    '<Snippet317>
    Function TestCDF() As String
        Return String.Format("Supports {0}: {1}", _
            "Channel Definition Format", _
            bCaps.CDF.ToString())
    End Function
    '</Snippet317>

    '<Snippet318>
    Function TestCLRVersion() As String
        Return String.Format("CLR version on client: {0}", _
            bCaps.ClrVersion)
    End Function
    '</Snippet318>

    '<Snippet383>
    Function TestSupportsCookies() As String
        Return String.Format("Supports cookies: {0}", _
            bCaps.Cookies)
    End Function
    '</Snippet383>

    '<Snippet331>
    Function TestIsCrawler() As String
        Return String.Format("Is a crawler: {0}", _
            bCaps.Crawler)
    End Function
    '</Snippet331>
    
    '<Snippet320>
    Function TestDefaultSubmitButton() As String
        Return String.Format("Submit button limit: {0}", _
            bCaps.DefaultSubmitButtonLimit)
    End Function
    '</Snippet320>

    '<Snippet321>
    Function TestECMAScriptVersion() As String
        Return String.Format("ECMA script version: {0}", _
            bCaps.EcmaScriptVersion)
    End Function
    '</Snippet321>

    '<Snippet392>
    Function TestSupportsFrames() As String
        Return String.Format("Supports frames: {0}", _
            bCaps.Frames)
    End Function
    '</Snippet392>

    '<Snippet323>
    Function TestGatewayMajorVersion() As String
        Return String.Format("Gateway major version: {0}", _
            bCaps.GatewayMajorVersion.ToString())
    End Function
    '</Snippet323>

    '<Snippet324>
    Function TestGatewayMinorVersion() As String
        Return String.Format("Gateway minor version: {0}", _
            bCaps.GatewayMinorVersion.ToString())
    End Function
    '</Snippet324>

    '<Snippet325>
    Function TestGatewayVersion() As String
        Return String.Format("Gateway version: {0}", _
            bCaps.GatewayVersion.ToString())
    End Function
    '</Snippet325>

    '<Snippet326>
    Function TestHasBackButton() As String
        Return String.Format("Has back button: {0}", _
            bCaps.HasBackButton.ToString())
    End Function
    '</Snippet326>

    '<Snippet327>
    Function TestHideRtAlignScrollBars() As String
        Return String.Format("Hide hide right-aligned {0}: {1}", _
            "multi-select scrollbars", _
            bCaps.HidesRightAlignedMultiselectScrollbars.ToString())
    End Function
    '</Snippet327>

    '<Snippet306>
    Function TestBrowserID() As String
        Return String.Format("Browser ID: {0}", _
            bCaps.Id)
    End Function
    '</Snippet306>

    '<Snippet328>
    Function TestInputType() As String
        Return String.Format("Supported input type: {0}", _
            bCaps.InputType)
    End Function
    '</Snippet328>

    '<Snippet329>
    Function TestIsBrowser() As String
        Return String.Format("Is client a given browser: {0}", _
            bCaps.IsBrowser("IE").ToString())
    End Function
    '</Snippet329>

    '<Snippet330>
    Function TestIsColor() As String
        Return String.Format("Is color display: {0}", _
            bCaps.IsColor.ToString())
    End Function
    '</Snippet330>

    '<Snippet332>
    Function TestIsMobileDevice() As String
        Return String.Format("Is mobile device: {0}", _
            bCaps.IsMobileDevice.ToString())
    End Function
    '</Snippet332>

    '<Snippet398>
    Function TestSupportsJava() As String
        Return String.Format("Supports Java: {0}", _
            bCaps.JavaApplets.ToString())
    End Function
    '</Snippet398>

    '<Snippet333>
    Function TestJavaScript() As String
        Return String.Format("Supports JavaScript: {0}", _
            bCaps.JavaScript.ToString())
    End Function
    '</Snippet333>

    '<Snippet334>
    Function TestJScriptVersion() As String
        Return String.Format("JScript version: {0}", _
            bCaps.JScriptVersion.ToString())
    End Function
    '</Snippet334>

    '<Snippet335>
    Function TestMajorVersion() As String
        Return String.Format("Major version of browser: {0}", _
            bCaps.MajorVersion.ToString())
    End Function
    '</Snippet335>

    '<Snippet336>
    Function TestMaximumHrefLength() As String
        Return String.Format("Max. href length: {0}", _
            bCaps.MaximumHrefLength.ToString())
    End Function
    '</Snippet336>

    '<Snippet337>
    Function TestMaximumRenderedPageSize() As String
        Return String.Format("Max. {0}: {1}", _
            "rendered page size in bytes", _
            bCaps.MaximumRenderedPageSize.ToString())
    End Function
    '</Snippet337>
    
    '<Snippet338>
    Function TestMaximumSoftkeyLabelLength() As String
        Return String.Format("Max. softkey label length: {0}", _
            bCaps.MaximumSoftkeyLabelLength.ToString())
    End Function
    '</Snippet338>
    
    '<Snippet339>
    Function TestMinorVersion() As String
        Return String.Format("Minor browser version: {0}", _
            bCaps.MinorVersion.ToString())
    End Function
    '</Snippet339>
    
    '<Snippet340>
    Function TestMinorVersionString() As String
        Return String.Format("Minor browser version {0}: {1}", _
            "(as string)", _
            bCaps.MinorVersionString)
    End Function
    '</Snippet340>
    
    '<Snippet341>
    Function TestMobileDeviceManufacturer() As String
        Return String.Format("Mobile device manufacturer: {0}", _
            bCaps.MobileDeviceManufacturer)
    End Function
    '</Snippet341>

    '<Snippet342>
    Function TestMobileDeviceModel() As String
        Return String.Format("Mobile device model: {0}", _
            bCaps.MobileDeviceModel)
    End Function
    '</Snippet342>

    '<Snippet343>
    Function TestMSDomVersion() As String
        Return String.Format("MS DOM version: {0}", _
            bCaps.MSDomVersion.ToString())
    End Function
    '</Snippet343>

    '<Snippet344>
    Function TestNumberOfSoftKeys() As String
        Return String.Format("Number of soft keys: {0}", _
            bCaps.NumberOfSoftkeys.ToString())
    End Function
    '</Snippet344>

    '<Snippet345>
    Function TestPlatform() As String
        Return String.Format("Platform of client: {0}", _
            bCaps.Platform)
    End Function
    '</Snippet345>

    '<Snippet346>
    Function TestPreferredImageMime() As String
        Return String.Format("Preferred image MIME: {0}", _
            bCaps.PreferredImageMime)
    End Function
    '</Snippet346>

    '<Snippet347>
    Function TestPreferredRenderingMime() As String
        Return String.Format("Preferred rendering MIME: {0}", _
            bCaps.PreferredRenderingMime)
    End Function
    '</Snippet347>

    '<Snippet348>
    Function TestPreferredRenderingType() As String
        Return String.Format("Preferred rendering type: {0}", _
            bCaps.PreferredRenderingType)
    End Function
    '</Snippet348>

    '<Snippet349>
    Function TestPreferredRequestEncoding() As String
        Return String.Format("Preferred request encoding: {0}", _
            bCaps.PreferredRequestEncoding)
    End Function
    '</Snippet349>

    '<Snippet350>
    Function TestPreferredResponseEncoding() As String
        Return String.Format("Preferred response encoding: {0}", _
            bCaps.PreferredResponseEncoding)
    End Function
    '</Snippet350>

    '<Snippet351>
    Function TestRenderBreakBeforeWmlSelectAndInput() As String
        Return String.Format("Renders break {0}: {1}", _
            "before WML select/input", _
            bCaps.RendersBreakBeforeWmlSelectAndInput.ToString())
    End Function
    '</Snippet351>

    '<Snippet352>
    Function TestRendersBreaksAfterHtmlLists() As String
        Return String.Format("Renders breaks {0}: {1}", _
            "after HTML lists", _
            bCaps.RendersBreaksAfterHtmlLists)
    End Function
    '</Snippet352>

    '<Snippet353>
    Function TestRendersBreaksAfterWmlAnchor() As String
        Return String.Format("Renders breaks {0}: {1}", _
            "after Wml anchor", _
            bCaps.RendersBreaksAfterWmlAnchor)
    End Function
    '</Snippet353>

    '<Snippet354>
    Function TestRendersBreaksAfterWmlInput() As String
        Return String.Format("Renders breaks after Wml input: {0}", _
            bCaps.RendersBreaksAfterWmlInput)
    End Function
    '</Snippet354>

    '<Snippet355>
    Function TestRendersWmlDoAcceptsInline() As String
        Return String.Format("Renders Wml do accepts inline: {0}", _
            bCaps.RendersWmlDoAcceptsInline)
    End Function
    '</Snippet355>

    '<Snippet357>
    Function TestRendersWmlSelectsAsMenuCards() As String
        Return String.Format("Renders Wml {0}: {1}", _
            "selects as menu cards", _
            bCaps.RendersWmlSelectsAsMenuCards)
    End Function
    '</Snippet357>

    '<Snippet358>
    Function TestRequiredMetaTagNameValue() As String
        Return String.Format("Required meta tag name value: {0}", _
            bCaps.RequiredMetaTagNameValue)
    End Function
    '</Snippet358>

    '<Snippet359>
    Function TestRequiresAttributeColonSubstitution() As String
        Return String.Format("Requires {0}: {1}", _
            "attribute colon substitution", _
            bCaps.RequiresAttributeColonSubstitution)
    End Function
    '</Snippet359>

    '<Snippet360>
    Function TestRequiresContentTypeMetaTag() As String
        Return String.Format("Requires content type meta tag: {0}", _
            bCaps.RequiresContentTypeMetaTag)
    End Function
    '</Snippet360>

    '<Snippet361>
    Function TestRequiresControlStateInSession() As String
        Return String.Format("Requires {0}: {1}", _
            "control state in session", _
            bCaps.RequiresControlStateInSession)
    End Function
    '</Snippet361>

    '<Snippet362>
    Function TestRequiresDBCSCharacter() As String
        Return String.Format("Requires DBCS character: {0}", _
            bCaps.RequiresDBCSCharacter)
    End Function
    '</Snippet362>
    
    '<Snippet363>
    Function TestRequiresHtmlAdaptiveErrorReporting() As String
        Return String.Format("Requires {0}: {1}", _
            "control state in session", _
            bCaps.RequiresHtmlAdaptiveErrorReporting)
    End Function
    '</Snippet363>

    '<Snippet364>
    Function TestRequiresLeadingPageBreak() As String
        Return String.Format("Requires leading page break: {0}", _
            bCaps.RequiresLeadingPageBreak)
    End Function
    '</Snippet364>

    '<Snippet365>
    Function TestRequiresNoBreakInFormatting() As String
        Return String.Format("Requires {0}: {1}", _
            "no break in formatting", _
            bCaps.RequiresNoBreakInFormatting)
    End Function
    '</Snippet365>

    '<Snippet366>
    Function TestRequiresOutputOptimization() As String
        Return String.Format("Requires output optimization: {0}", _
            bCaps.RequiresOutputOptimization)
    End Function
    '</Snippet366>

    '<Snippet367>
    Function TestRequiresPhoneNumberAsPlainText() As String
        Return String.Format("Requires phone number as text: {0}", _
            bCaps.RequiresPhoneNumbersAsPlainText)
    End Function
    '</Snippet367>

    '<Snippet368>
    Function TestRequiresSpecialViewStateEncoding() As String
        Return String.Format("Requires {0}: {1}", _
            "special viewstate encoding", _
            bCaps.RequiresSpecialViewStateEncoding)
    End Function
    '</Snippet368>

    '<Snippet369>
    Function TestRequiresUniqueFilePathSuffix() As String
        Return String.Format("Requires {0}: {1}", _
            "unique file path suffix", _
            bCaps.RequiresUniqueFilePathSuffix)
    End Function
    '</Snippet369>

    '<Snippet370>
    Function TestRequiresUniqueHtmlCheckboxNames() As String
        Return String.Format("Requires {0}: {1}", _
            "unique HTML checkbox names", _
            bCaps.RequiresUniqueHtmlCheckboxNames)
    End Function
    '</Snippet370>

    '<Snippet371>
    Function TestRequiresUniqueHtmlInputNames() As String
        Return String.Format("Requires {0}: {1}", _
            "unique HTML input names", _
            bCaps.RequiresUniqueHtmlInputNames)
    End Function
    '</Snippet371>

    '<Snippet372>
    Function TestRequiresUrlEncodedPostfieldValues() As String
        Return String.Format("Requires {0}: {1}", _
            "URL encoded postfield values", _
            bCaps.RequiresUrlEncodedPostfieldValues)
    End Function
    '</Snippet372>

    '<Snippet373>
    Function TestScreenBitDepth() As String
        Return String.Format("Screen bit depth: {0}", _
            bCaps.ScreenBitDepth)
    End Function
    '</Snippet373>

    '<Snippet374>
    Function TestScreenCharactersHeight() As String
        Return String.Format("Screen height {0}: {1}", _
            "in character lines", _
            bCaps.ScreenCharactersHeight)
    End Function
    '</Snippet374>

    '<Snippet375>
    Function TestScreenCharactersWidth() As String
        Return String.Format("Screen width in characters: {0}", _
            bCaps.ScreenCharactersWidth)
    End Function
    '</Snippet375>

    '<Snippet376>
    Function TestScreenPixelsHeight() As String
        Return String.Format("Screen height in pixels: {0}", _
            bCaps.ScreenPixelsHeight)
    End Function
    '</Snippet376>

    '<Snippet377>
    Function TestScreenPixelsWidth() As String
        Return String.Format("Screen width in pixels: {0}", _
            bCaps.ScreenPixelsWidth)
    End Function
    '</Snippet377>

    '<Snippet378>
    Function TestScreenAccesskeyAttribute() As String
        Return String.Format("Supports ACCESSKEY: {0}", _
            bCaps.SupportsAccesskeyAttribute)
    End Function
    '</Snippet378>

    '<Snippet379>
    Function TestSupportsBodyColor() As String
        Return String.Format("Supports body color: {0}", _
            bCaps.SupportsBodyColor)
    End Function
    '</Snippet379>

    '<Snippet380>
    Function TestSupportsBold() As String
        Return String.Format("Supports bold: {0}", _
            bCaps.SupportsBold)
    End Function
    '</Snippet380>

    '<Snippet381>
    Function TestSupportsCacheControlMetaTag() As String
        Return String.Format("Supports {0}: {1}", _
            "cache-control meta tag", _
            bCaps.SupportsCacheControlMetaTag)
    End Function
    '</Snippet381>

    '<Snippet382>
    Function TestSupportsCallback() As String
        Return String.Format("Supports callback: {0}", _
            bCaps.SupportsCallback)
    End Function
    '</Snippet382>

    '<Snippet384>
    Function TestSupportsCss() As String
        Return String.Format("Supports CSS: {0}", _
            bCaps.SupportsCss)
    End Function
    '</Snippet384>

    '<Snippet385>
    Function TestSupportsDivAlign() As String
        Return String.Format("Supports DIV align: {0}", _
            bCaps.SupportsDivAlign)
    End Function
    '</Snippet385>

    '<Snippet386>
    Function TestSupportsDivNoWrap() As String
        Return String.Format("Supports DIV nowrap: {0}", _
            bCaps.SupportsDivNoWrap)
    End Function
    '</Snippet386>

    '<Snippet387>
    Function TestSupportsEmptyStringInCookieValue() As String
        Return String.Format("Supports {0}: {1}", _
            "cache-control meta tag", _
            bCaps.SupportsEmptyStringInCookieValue)
    End Function
    '</Snippet387>

    '<Snippet388>
    Function TestSupportsFontColor() As String
        Return String.Format("Supports font color: {0}", _
            bCaps.SupportsFontColor)
    End Function
    '</Snippet388>

    '<Snippet389>
    Function TestSupportsFontName() As String
        Return String.Format("Supports font name: {0}", _
            bCaps.SupportsFontName)
    End Function
    '</Snippet389>

    '<Snippet390>
    Function TestSupportsFontSize() As String
        Return String.Format("Supports font size: {0}", _
            bCaps.SupportsFontSize)
    End Function
    '</Snippet390>

    '<Snippet393>
    Function TestSupportsImageSubmit() As String
        Return String.Format("Supports image submit: {0}", _
            bCaps.SupportsImageSubmit)
    End Function
    '</Snippet393>

    '<Snippet394>
    Function TestSupportsIModeSymbols() As String
        Return String.Format("Supports i-mode symbols: {0}", _
            bCaps.SupportsIModeSymbols)
    End Function
    '</Snippet394>

    '<Snippet395>
    Function TestSupportsInputIStyle() As String
        Return String.Format("Supports {0}: {1}", _
            "input istyle attribute", _
            bCaps.SupportsInputIStyle)
    End Function
    '</Snippet395>

    '<Snippet396>
    Function TestSupportsInputMode() As String
        Return String.Format("Supports input mode: {0}", _
            bCaps.SupportsInputMode)
    End Function
    '</Snippet396>

    '<Snippet397>
    Function TestSupportsItalic() As String
        Return String.Format("Supports italics: {0}", _
            bCaps.SupportsItalic)
    End Function
    '</Snippet397>

    '<Snippet399>
    Function TestSupportsJPhoneMultiMediaAttributes() As String
        Return String.Format("Supports {0}: {1}", _
            "JPhone multimedia attributes", _
            bCaps.SupportsJPhoneMultiMediaAttributes)
    End Function
    '</Snippet399>

    '<Snippet400>
    Function TestSupportsJPhoneSymbols() As String
        Return String.Format("Supports JPhone picture symbols: {0}", _
            bCaps.SupportsJPhoneSymbols)
    End Function
    '</Snippet400>

    '<Snippet401>
    Function TestSupportsQueryStringInFormAction() As String
        Return String.Format("Supports {0}: {1}", _
            "querystring in form action", _
            bCaps.SupportsQueryStringInFormAction)
    End Function
    '</Snippet401>

    '<Snippet402>
    Function TestSupportsRedirectWithCookie() As String
        Return String.Format("Supports redirect with cookie: {0}", _
            bCaps.SupportsRedirectWithCookie)
    End Function
    '</Snippet402>

    '<Snippet403>
    Function TestSupportsSelectMultiple() As String
        Return String.Format("Supports select multiple: {0}", _
            bCaps.SupportsSelectMultiple)
    End Function
    '</Snippet403>

    '<Snippet404>
    Function TestSupportsUncheck() As String
        Return String.Format("Supports uncheck: {0}", _
            bCaps.SupportsUncheck)
    End Function
    '</Snippet404>

    '<Snippet405>
    Function TestSupportsXmlHttp() As String
        Return String.Format("Supports {0}: {1}", _
            "receiving XML over HTTP", _
            bCaps.SupportsXmlHttp)
    End Function
    '</Snippet405>

    '<Snippet406>
    Function TestTables() As String
        Return String.Format("Supports tables: {0}", _
            bCaps.Tables)
    End Function
    '</Snippet406>

    '<Snippet407>
    Function TestType() As String

        Return String.Format("Gets the browser name/version: {0}", _
            bCaps.Type)
    End Function
    '</Snippet407>

    '<Snippet408>
    Function TestVBScript() As String
        Return String.Format("Supports VBScript: {0}", _
            bCaps.VBScript)
    End Function
    '</Snippet408>

    '<Snippet409>
    Function TestVersion() As String
        Dim dVer As String
        dVer = bCaps.MajorVersion & "." & bCaps.MinorVersion
        If (Double.Parse(dVer) > 5.01) Then
            Return String.Format("Uplevel version: {0}", _
                bCaps.Version)
        Else
            Return String.Format("Old version: {0}", _
                bCaps.Version)
        End If
    End Function
    '</Snippet409>

    '<Snippet410>
    Function TestW3CDomVersion() As String
        Return String.Format("W3C DOM version: {0}", _
            bCaps.W3CDomVersion)
    End Function
    '</Snippet410>

    '<Snippet411>
    Function TestWin16() As String
        Return String.Format("Is Win16-based computer: {0}", _
            bCaps.Win16)
    End Function
    '</Snippet411>

    '<Snippet412>
    Function TestWin32() As String
        Return String.Format("Is Win32-based computer: {0}", _
            bCaps.Win32)
    End Function
    '</Snippet412>
    ' <Snippet4>        
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
