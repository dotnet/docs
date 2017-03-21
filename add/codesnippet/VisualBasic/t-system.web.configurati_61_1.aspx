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
        sb.AppendLine(TestActiveXControls())
        sb.AppendLine(TestAdapters())
        sb.AppendLine(TestAOL())
        sb.AppendLine(TestBackgroundSounds())
        sb.AppendLine(TestBeta())
        sb.AppendLine(TestBrowser())
        sb.AppendLine(TestBrowserID())
        sb.AppendLine(TestBrowsers())
        sb.AppendLine(TestCanCall())
        sb.AppendLine(TestCanRenderAfter())
        sb.AppendLine(TestCanRenderEmpty())
        sb.AppendLine(TestCanRenderInputSelectTogether())
        sb.AppendLine(TestCanRenderMixedSelects())
        sb.AppendLine(TestCanRenderOneventPrevTogether())
        sb.AppendLine(TestCanRenderPostBackCards())
        sb.AppendLine(TestCanRenderSetvar())
        sb.AppendLine(TestCanSendMail())
        sb.AppendLine(TestCDF())
        sb.AppendLine(TestCLRVersion())
        sb.AppendLine(TestCombineDeck())
        sb.AppendLine(TestDefaultSubmitButton())
        sb.AppendLine(TestECMAScriptVersion())
        sb.AppendLine(TestGatewayMajorVersion())
        sb.AppendLine(TestGatewayMinorVersion())
        sb.AppendLine(TestGatewayVersion())
        sb.AppendLine(TestHasBackButton())
        sb.AppendLine(TestHideRtAlignScrollBars())
        sb.AppendLine(TestInputType())
        sb.AppendLine(TestIsBrowser())
        sb.AppendLine(TestIsColor())
        sb.AppendLine(TestIsCrawler())
        sb.AppendLine(TestIsMobileDevice())
        sb.AppendLine(TestJavaScript())
        sb.AppendLine(TestJScriptVersion())
        sb.AppendLine(TestMajorVersion())
        sb.AppendLine(TestMaximumHrefLength())
        sb.AppendLine(TestMaximumRenderedPageSize())
        sb.AppendLine(TestMaximumSoftkeyLabelLength())
        sb.AppendLine(TestMinorVersion())
        sb.AppendLine(TestMinorVersionString())
        sb.AppendLine(TestMobileDeviceManufacturer())
        sb.AppendLine(TestMobileDeviceModel())
        sb.AppendLine(TestMSDomVersion())
        sb.AppendLine(TestNumberOfSoftKeys())
        sb.AppendLine(TestPlatform())
        sb.AppendLine(TestPreferredImageMime())
        sb.AppendLine(TestPreferredRenderingMime())
        sb.AppendLine(TestPreferredRenderingType())
        sb.AppendLine(TestPreferredRequestEncoding())
        sb.AppendLine(TestPreferredResponseEncoding())
        sb.AppendLine(TestRenderBreakBeforeWmlSelectAndInput())
        sb.AppendLine(TestRendersBreaksAfterHtmlLists())
        sb.AppendLine(TestRendersBreaksAfterWmlAnchor())
        sb.AppendLine(TestRendersBreaksAfterWmlInput())
        sb.AppendLine(TestRendersWmlDoAcceptsInline())
        sb.AppendLine(TestRendersWmlSelectsAsMenuCards())
        sb.AppendLine(TestRequiredMetaTagNameValue())
        sb.AppendLine(TestRequiresAttributeColonSubstitution())
        sb.AppendLine(TestRequiresContentTypeMetaTag())
        sb.AppendLine(TestRequiresControlStateInSession())
        sb.AppendLine(TestRequiresDBCSCharacter())
        sb.AppendLine(TestRequiresHtmlAdaptiveErrorReporting())
        sb.AppendLine(TestRequiresLeadingPageBreak())
        sb.AppendLine(TestRequiresNoBreakInFormatting())
        sb.AppendLine(TestRequiresOutputOptimization())
        sb.AppendLine(TestRequiresPhoneNumberAsPlainText())
        sb.AppendLine(TestRequiresSpecialViewStateEncoding())
        sb.AppendLine(TestRequiresUniqueFilePathSuffix())
        sb.AppendLine(TestRequiresUniqueHtmlCheckboxNames())
        sb.AppendLine(TestRequiresUniqueHtmlInputNames())
        sb.AppendLine(TestRequiresUrlEncodedPostfieldValues())
        sb.AppendLine(TestScreenBitDepth())
        sb.AppendLine(TestScreenCharactersHeight())
        sb.AppendLine(TestScreenCharactersWidth())
        sb.AppendLine(TestScreenPixelsHeight())
        sb.AppendLine(TestScreenPixelsWidth())
        sb.AppendLine(TestScreenAccesskeyAttribute())
        sb.AppendLine(TestSupportsBodyColor())
        sb.AppendLine(TestSupportsBold())
        sb.AppendLine(TestSupportsCacheControlMetaTag())
        sb.AppendLine(TestSupportsCallback())
        sb.AppendLine(TestSupportsCookies())
        sb.AppendLine(TestSupportsCss())
        sb.AppendLine(TestSupportsDivAlign())
        sb.AppendLine(TestSupportsDivNoWrap())
        sb.AppendLine(TestSupportsEmptyStringInCookieValue())
        sb.AppendLine(TestSupportsFontColor())
        sb.AppendLine(TestSupportsFontName())
        sb.AppendLine(TestSupportsFontSize())
        sb.AppendLine(TestSupportsFrames())
        sb.AppendLine(TestSupportsImageSubmit())
        sb.AppendLine(TestSupportsIModeSymbols())
        sb.AppendLine(TestSupportsInputIStyle())
        sb.AppendLine(TestSupportsInputMode())
        sb.AppendLine(TestSupportsItalic())
        sb.AppendLine(TestSupportsJava())
        sb.AppendLine(TestSupportsJPhoneMultiMediaAttributes())
        sb.AppendLine(TestSupportsJPhoneSymbols())
        sb.AppendLine(TestSupportsQueryStringInFormAction())
        sb.AppendLine(TestSupportsRedirectWithCookie())
        sb.AppendLine(TestSupportsSelectMultiple())
        sb.AppendLine(TestSupportsUncheck())
        sb.AppendLine(TestSupportsXmlHttp())
        sb.AppendLine(TestTables())
        sb.AppendLine(TestType())
        sb.AppendLine(TestVBScript())
        sb.AppendLine(TestVersion())
        sb.AppendLine(TestW3CDomVersion())
        sb.AppendLine(TestWin16())
        sb.AppendLine(TestWin32())

        Return sb.ToString().Replace(Environment.NewLine, "<br />")
    End Function

    Function TestActiveXControls() As String
        Return String.Format("Supports ActiveX controls: {0}", _
            bCaps.ActiveXControls)
    End Function

    Function TestAdapters() As String
        Return String.Format("Adapter count: {0}", _
            bCaps.Adapters.Count)
    End Function
    
    Function TestAOL() As String
        Return String.Format("Is an AOL browser: {0}", _
            bCaps.AOL.ToString())
    End Function

    Function TestBackgroundSounds() As String
        Return String.Format("Supports background sounds: {0}", _
            bCaps.BackgroundSounds)
    End Function
    
    Function TestBeta() As String
        Return String.Format("Is a beta version: {0}", _
            bCaps.Beta)
    End Function
    
    Function TestBrowser() As String
        Return String.Format("Browser type: {0}", _
            bCaps.Browser)
    End Function

    Function TestBrowsers() As String
        Return String.Format("# of browsers in dictionary: {0}", _
            bCaps.Browsers.Count)
    End Function

    Function TestCombineDeck() As String
        Return String.Format("Can combine forms in deck: {0}", _
            bCaps.CanCombineFormsInDeck)
    End Function

    Function TestCanCall() As String
        Return String.Format("Can initiate voice call: {0}", _
            bCaps.CanInitiateVoiceCall)
    End Function

    Function TestCanRenderAfter() As String
        Return String.Format("Can render {0}: {1}", _
            "after input or select element", _
            bCaps.CanRenderAfterInputOrSelectElement)
    End Function

    Function TestCanRenderEmpty() As String
        Return String.Format("Can render empty selects: {0}", _
            bCaps.CanRenderEmptySelects)
    End Function

    Function TestCanRenderInputSelectTogether() As String
        Return String.Format("Can render {0} together: {1}", _
            "input and select elements", _
            bCaps.CanRenderInputAndSelectElementsTogether)
    End Function

    Function TestCanRenderMixedSelects() As String
        Return String.Format("Can render mixed selects: {0}", _
            bCaps.CanRenderMixedSelects)
    End Function

    Function TestCanRenderOneventPrevTogether() As String
        Return String.Format("Can render {0} together: {1}", _
            "OnEvent and Prev elements", _
            bCaps.CanRenderOneventAndPrevElementsTogether)
    End Function

    Function TestCanRenderPostBackCards() As String
        Return String.Format("Can render postback cards: {0}", _
            bCaps.CanRenderPostBackCards)
    End Function

    Function TestCanRenderSetvar() As String
        Return String.Format("Can render {0}: {1}", _
            "setvar elements with a value of 0", _
            bCaps.CanRenderSetvarZeroWithMultiSelectionList)
    End Function

    Function TestCanSendMail() As String
        Return String.Format("Can send mail: {0}", _
            bCaps.CanSendMail)
    End Function

    Function TestCDF() As String
        Return String.Format("Supports {0}: {1}", _
            "Channel Definition Format", _
            bCaps.CDF.ToString())
    End Function

    Function TestCLRVersion() As String
        Return String.Format("CLR version on client: {0}", _
            bCaps.ClrVersion)
    End Function

    Function TestSupportsCookies() As String
        Return String.Format("Supports cookies: {0}", _
            bCaps.Cookies)
    End Function

    Function TestIsCrawler() As String
        Return String.Format("Is a crawler: {0}", _
            bCaps.Crawler)
    End Function
    
    Function TestDefaultSubmitButton() As String
        Return String.Format("Submit button limit: {0}", _
            bCaps.DefaultSubmitButtonLimit)
    End Function

    Function TestECMAScriptVersion() As String
        Return String.Format("ECMA script version: {0}", _
            bCaps.EcmaScriptVersion)
    End Function

    Function TestSupportsFrames() As String
        Return String.Format("Supports frames: {0}", _
            bCaps.Frames)
    End Function

    Function TestGatewayMajorVersion() As String
        Return String.Format("Gateway major version: {0}", _
            bCaps.GatewayMajorVersion.ToString())
    End Function

    Function TestGatewayMinorVersion() As String
        Return String.Format("Gateway minor version: {0}", _
            bCaps.GatewayMinorVersion.ToString())
    End Function

    Function TestGatewayVersion() As String
        Return String.Format("Gateway version: {0}", _
            bCaps.GatewayVersion.ToString())
    End Function

    Function TestHasBackButton() As String
        Return String.Format("Has back button: {0}", _
            bCaps.HasBackButton.ToString())
    End Function

    Function TestHideRtAlignScrollBars() As String
        Return String.Format("Hide hide right-aligned {0}: {1}", _
            "multi-select scrollbars", _
            bCaps.HidesRightAlignedMultiselectScrollbars.ToString())
    End Function

    Function TestBrowserID() As String
        Return String.Format("Browser ID: {0}", _
            bCaps.Id)
    End Function

    Function TestInputType() As String
        Return String.Format("Supported input type: {0}", _
            bCaps.InputType)
    End Function

    Function TestIsBrowser() As String
        Return String.Format("Is client a given browser: {0}", _
            bCaps.IsBrowser("IE").ToString())
    End Function

    Function TestIsColor() As String
        Return String.Format("Is color display: {0}", _
            bCaps.IsColor.ToString())
    End Function

    Function TestIsMobileDevice() As String
        Return String.Format("Is mobile device: {0}", _
            bCaps.IsMobileDevice.ToString())
    End Function

    Function TestSupportsJava() As String
        Return String.Format("Supports Java: {0}", _
            bCaps.JavaApplets.ToString())
    End Function

    Function TestJavaScript() As String
        Return String.Format("Supports JavaScript: {0}", _
            bCaps.JavaScript.ToString())
    End Function

    Function TestJScriptVersion() As String
        Return String.Format("JScript version: {0}", _
            bCaps.JScriptVersion.ToString())
    End Function

    Function TestMajorVersion() As String
        Return String.Format("Major version of browser: {0}", _
            bCaps.MajorVersion.ToString())
    End Function

    Function TestMaximumHrefLength() As String
        Return String.Format("Max. href length: {0}", _
            bCaps.MaximumHrefLength.ToString())
    End Function

    Function TestMaximumRenderedPageSize() As String
        Return String.Format("Max. {0}: {1}", _
            "rendered page size in bytes", _
            bCaps.MaximumRenderedPageSize.ToString())
    End Function
    
    Function TestMaximumSoftkeyLabelLength() As String
        Return String.Format("Max. softkey label length: {0}", _
            bCaps.MaximumSoftkeyLabelLength.ToString())
    End Function
    
    Function TestMinorVersion() As String
        Return String.Format("Minor browser version: {0}", _
            bCaps.MinorVersion.ToString())
    End Function
    
    Function TestMinorVersionString() As String
        Return String.Format("Minor browser version {0}: {1}", _
            "(as string)", _
            bCaps.MinorVersionString)
    End Function
    
    Function TestMobileDeviceManufacturer() As String
        Return String.Format("Mobile device manufacturer: {0}", _
            bCaps.MobileDeviceManufacturer)
    End Function

    Function TestMobileDeviceModel() As String
        Return String.Format("Mobile device model: {0}", _
            bCaps.MobileDeviceModel)
    End Function

    Function TestMSDomVersion() As String
        Return String.Format("MS DOM version: {0}", _
            bCaps.MSDomVersion.ToString())
    End Function

    Function TestNumberOfSoftKeys() As String
        Return String.Format("Number of soft keys: {0}", _
            bCaps.NumberOfSoftkeys.ToString())
    End Function

    Function TestPlatform() As String
        Return String.Format("Platform of client: {0}", _
            bCaps.Platform)
    End Function

    Function TestPreferredImageMime() As String
        Return String.Format("Preferred image MIME: {0}", _
            bCaps.PreferredImageMime)
    End Function

    Function TestPreferredRenderingMime() As String
        Return String.Format("Preferred rendering MIME: {0}", _
            bCaps.PreferredRenderingMime)
    End Function

    Function TestPreferredRenderingType() As String
        Return String.Format("Preferred rendering type: {0}", _
            bCaps.PreferredRenderingType)
    End Function

    Function TestPreferredRequestEncoding() As String
        Return String.Format("Preferred request encoding: {0}", _
            bCaps.PreferredRequestEncoding)
    End Function

    Function TestPreferredResponseEncoding() As String
        Return String.Format("Preferred response encoding: {0}", _
            bCaps.PreferredResponseEncoding)
    End Function

    Function TestRenderBreakBeforeWmlSelectAndInput() As String
        Return String.Format("Renders break {0}: {1}", _
            "before WML select/input", _
            bCaps.RendersBreakBeforeWmlSelectAndInput.ToString())
    End Function

    Function TestRendersBreaksAfterHtmlLists() As String
        Return String.Format("Renders breaks {0}: {1}", _
            "after HTML lists", _
            bCaps.RendersBreaksAfterHtmlLists)
    End Function

    Function TestRendersBreaksAfterWmlAnchor() As String
        Return String.Format("Renders breaks {0}: {1}", _
            "after Wml anchor", _
            bCaps.RendersBreaksAfterWmlAnchor)
    End Function

    Function TestRendersBreaksAfterWmlInput() As String
        Return String.Format("Renders breaks after Wml input: {0}", _
            bCaps.RendersBreaksAfterWmlInput)
    End Function

    Function TestRendersWmlDoAcceptsInline() As String
        Return String.Format("Renders Wml do accepts inline: {0}", _
            bCaps.RendersWmlDoAcceptsInline)
    End Function

    Function TestRendersWmlSelectsAsMenuCards() As String
        Return String.Format("Renders Wml {0}: {1}", _
            "selects as menu cards", _
            bCaps.RendersWmlSelectsAsMenuCards)
    End Function

    Function TestRequiredMetaTagNameValue() As String
        Return String.Format("Required meta tag name value: {0}", _
            bCaps.RequiredMetaTagNameValue)
    End Function

    Function TestRequiresAttributeColonSubstitution() As String
        Return String.Format("Requires {0}: {1}", _
            "attribute colon substitution", _
            bCaps.RequiresAttributeColonSubstitution)
    End Function

    Function TestRequiresContentTypeMetaTag() As String
        Return String.Format("Requires content type meta tag: {0}", _
            bCaps.RequiresContentTypeMetaTag)
    End Function

    Function TestRequiresControlStateInSession() As String
        Return String.Format("Requires {0}: {1}", _
            "control state in session", _
            bCaps.RequiresControlStateInSession)
    End Function

    Function TestRequiresDBCSCharacter() As String
        Return String.Format("Requires DBCS character: {0}", _
            bCaps.RequiresDBCSCharacter)
    End Function
    
    Function TestRequiresHtmlAdaptiveErrorReporting() As String
        Return String.Format("Requires {0}: {1}", _
            "control state in session", _
            bCaps.RequiresHtmlAdaptiveErrorReporting)
    End Function

    Function TestRequiresLeadingPageBreak() As String
        Return String.Format("Requires leading page break: {0}", _
            bCaps.RequiresLeadingPageBreak)
    End Function

    Function TestRequiresNoBreakInFormatting() As String
        Return String.Format("Requires {0}: {1}", _
            "no break in formatting", _
            bCaps.RequiresNoBreakInFormatting)
    End Function

    Function TestRequiresOutputOptimization() As String
        Return String.Format("Requires output optimization: {0}", _
            bCaps.RequiresOutputOptimization)
    End Function

    Function TestRequiresPhoneNumberAsPlainText() As String
        Return String.Format("Requires phone number as text: {0}", _
            bCaps.RequiresPhoneNumbersAsPlainText)
    End Function

    Function TestRequiresSpecialViewStateEncoding() As String
        Return String.Format("Requires {0}: {1}", _
            "special viewstate encoding", _
            bCaps.RequiresSpecialViewStateEncoding)
    End Function

    Function TestRequiresUniqueFilePathSuffix() As String
        Return String.Format("Requires {0}: {1}", _
            "unique file path suffix", _
            bCaps.RequiresUniqueFilePathSuffix)
    End Function

    Function TestRequiresUniqueHtmlCheckboxNames() As String
        Return String.Format("Requires {0}: {1}", _
            "unique HTML checkbox names", _
            bCaps.RequiresUniqueHtmlCheckboxNames)
    End Function

    Function TestRequiresUniqueHtmlInputNames() As String
        Return String.Format("Requires {0}: {1}", _
            "unique HTML input names", _
            bCaps.RequiresUniqueHtmlInputNames)
    End Function

    Function TestRequiresUrlEncodedPostfieldValues() As String
        Return String.Format("Requires {0}: {1}", _
            "URL encoded postfield values", _
            bCaps.RequiresUrlEncodedPostfieldValues)
    End Function

    Function TestScreenBitDepth() As String
        Return String.Format("Screen bit depth: {0}", _
            bCaps.ScreenBitDepth)
    End Function

    Function TestScreenCharactersHeight() As String
        Return String.Format("Screen height {0}: {1}", _
            "in character lines", _
            bCaps.ScreenCharactersHeight)
    End Function

    Function TestScreenCharactersWidth() As String
        Return String.Format("Screen width in characters: {0}", _
            bCaps.ScreenCharactersWidth)
    End Function

    Function TestScreenPixelsHeight() As String
        Return String.Format("Screen height in pixels: {0}", _
            bCaps.ScreenPixelsHeight)
    End Function

    Function TestScreenPixelsWidth() As String
        Return String.Format("Screen width in pixels: {0}", _
            bCaps.ScreenPixelsWidth)
    End Function

    Function TestScreenAccesskeyAttribute() As String
        Return String.Format("Supports ACCESSKEY: {0}", _
            bCaps.SupportsAccesskeyAttribute)
    End Function

    Function TestSupportsBodyColor() As String
        Return String.Format("Supports body color: {0}", _
            bCaps.SupportsBodyColor)
    End Function

    Function TestSupportsBold() As String
        Return String.Format("Supports bold: {0}", _
            bCaps.SupportsBold)
    End Function

    Function TestSupportsCacheControlMetaTag() As String
        Return String.Format("Supports {0}: {1}", _
            "cache-control meta tag", _
            bCaps.SupportsCacheControlMetaTag)
    End Function

    Function TestSupportsCallback() As String
        Return String.Format("Supports callback: {0}", _
            bCaps.SupportsCallback)
    End Function

    Function TestSupportsCss() As String
        Return String.Format("Supports CSS: {0}", _
            bCaps.SupportsCss)
    End Function

    Function TestSupportsDivAlign() As String
        Return String.Format("Supports DIV align: {0}", _
            bCaps.SupportsDivAlign)
    End Function

    Function TestSupportsDivNoWrap() As String
        Return String.Format("Supports DIV nowrap: {0}", _
            bCaps.SupportsDivNoWrap)
    End Function

    Function TestSupportsEmptyStringInCookieValue() As String
        Return String.Format("Supports {0}: {1}", _
            "cache-control meta tag", _
            bCaps.SupportsEmptyStringInCookieValue)
    End Function

    Function TestSupportsFontColor() As String
        Return String.Format("Supports font color: {0}", _
            bCaps.SupportsFontColor)
    End Function

    Function TestSupportsFontName() As String
        Return String.Format("Supports font name: {0}", _
            bCaps.SupportsFontName)
    End Function

    Function TestSupportsFontSize() As String
        Return String.Format("Supports font size: {0}", _
            bCaps.SupportsFontSize)
    End Function

    Function TestSupportsImageSubmit() As String
        Return String.Format("Supports image submit: {0}", _
            bCaps.SupportsImageSubmit)
    End Function

    Function TestSupportsIModeSymbols() As String
        Return String.Format("Supports i-mode symbols: {0}", _
            bCaps.SupportsIModeSymbols)
    End Function

    Function TestSupportsInputIStyle() As String
        Return String.Format("Supports {0}: {1}", _
            "input istyle attribute", _
            bCaps.SupportsInputIStyle)
    End Function

    Function TestSupportsInputMode() As String
        Return String.Format("Supports input mode: {0}", _
            bCaps.SupportsInputMode)
    End Function

    Function TestSupportsItalic() As String
        Return String.Format("Supports italics: {0}", _
            bCaps.SupportsItalic)
    End Function

    Function TestSupportsJPhoneMultiMediaAttributes() As String
        Return String.Format("Supports {0}: {1}", _
            "JPhone multimedia attributes", _
            bCaps.SupportsJPhoneMultiMediaAttributes)
    End Function

    Function TestSupportsJPhoneSymbols() As String
        Return String.Format("Supports JPhone picture symbols: {0}", _
            bCaps.SupportsJPhoneSymbols)
    End Function

    Function TestSupportsQueryStringInFormAction() As String
        Return String.Format("Supports {0}: {1}", _
            "querystring in form action", _
            bCaps.SupportsQueryStringInFormAction)
    End Function

    Function TestSupportsRedirectWithCookie() As String
        Return String.Format("Supports redirect with cookie: {0}", _
            bCaps.SupportsRedirectWithCookie)
    End Function

    Function TestSupportsSelectMultiple() As String
        Return String.Format("Supports select multiple: {0}", _
            bCaps.SupportsSelectMultiple)
    End Function

    Function TestSupportsUncheck() As String
        Return String.Format("Supports uncheck: {0}", _
            bCaps.SupportsUncheck)
    End Function

    Function TestSupportsXmlHttp() As String
        Return String.Format("Supports {0}: {1}", _
            "receiving XML over HTTP", _
            bCaps.SupportsXmlHttp)
    End Function

    Function TestTables() As String
        Return String.Format("Supports tables: {0}", _
            bCaps.Tables)
    End Function

    Function TestType() As String

        Return String.Format("Gets the browser name/version: {0}", _
            bCaps.Type)
    End Function

    Function TestVBScript() As String
        Return String.Format("Supports VBScript: {0}", _
            bCaps.VBScript)
    End Function

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

    Function TestW3CDomVersion() As String
        Return String.Format("W3C DOM version: {0}", _
            bCaps.W3CDomVersion)
    End Function

    Function TestWin16() As String
        Return String.Format("Is Win16-based computer: {0}", _
            bCaps.Win16)
    End Function

    Function TestWin32() As String
        Return String.Format("Is Win32-based computer: {0}", _
            bCaps.Win32)
    End Function
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