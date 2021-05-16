/*!
 @file		WKContentScrubberScripts.js
 @brief		WKWebView's content scrubbing scripts
 
 @author	Roopa Natarajan (ronata)
 @copyright	Copyright (C) Microsoft Corporation. All rights reserved.
 */
(function(sourceHTML, shouldBlockExternalContent, shouldDetectLinksAndEmailAddresses, isActionableMessage, base64FontMappings, fontsDirectory, contentNotEditable) {
	
	// Returns the doctype as a string
	function _getDoctype(document) {
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('Start of _getDoctype');
		var doctype = document.doctype;

		if (_isNil(doctype)) {
			window.webkit.messageHandlers.JSLoggingBridge.postMessage('_getDoctype doctype is nil');
			return null;
		}

		// Determine arguments
		var args = [
			doctype.name,
			!_isNil(doctype.publicId) ? ('PUBLIC "' + doctype.publicId + '"') : null,
			(_isNil(doctype.publicId) && !_isNil(doctype.systemId)) ? 'SYSTEM' : null,
			!_isNil(doctype.systemId) ? '"' + doctype.systemId + '"' : null
		];

		// Filter out null arguments
		args = args.filter(function(arg) {
			return arg !== null;
		});
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('_getDoctype join args and return doctype');
		return '<!DOCTYPE ' + args.join(' ') + '>';
	}

	// Create DOM
	function _createDocument(sourceHTML) {
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('Start of _createDocument');
		// Create parser
		var DOM_PARSER = new DOMParser();
		// Decode from base64 string
		var decodedHTML = _decodeBase64(sourceHTML);
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('_createDocument createDOM and return');
		// Create DOM
		return DOM_PARSER.parseFromString(decodedHTML, 'text/html');
	}
	
	/*
	 Link detection scripts
	 */
	function _detectLinksAndAddAnchorTags(text) {
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('Start of _detectLinksAndAddAnchorTags');
		var reEmail = /([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+)/gi;
		var reUrl = /(?:(?:https?|ftp|file|smb):\/\/|www\\.|ftp\\.)(?:\\([-A-Z0-9+&@#\\/%=~_|$?!:,.]*\\)|[-A-Z0-9+&@#\\/%=~_|$?!:,.])*(?:\\([-A-Z0-9+&@#\\/%=~_|$?!:,.]*\\)|[A-Z0-9+&@#\\/%=~_|$])/igm;
		return text.replace(reUrl, function(url) {
		return '<a href=' + url + '>' + url + '</a>';
		}).replace(reEmail, function(email) {
		 return '<a href=mailto:' + email + '>' + email + '</a>';
		});
	}
																																											 
	/*
	 Font scrubbing scripts
	 */

	function scrubFontFaces(document, base64FontMappings, fontsDirectory)
	{
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('Start of scrubFontFaces');
		var jsonString = atob(base64FontMappings);
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('scrubFontFaces parsing JSON to fontFamilyMappings');
		var fontFamilyMappings = JSON.parse(jsonString);
		// Get all style elements from the document
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('scrubFontFaces get all style elements');
		var styleDeclarations = document.getElementsByTagName('style');
		var foundCalibriFontFace = false;
		for (var s=0; s<styleDeclarations.length; s++) {
			/*
			 This is what the following code does:
			 1. Take a style element's innerHTML and split it at new line characters
			 2. Copy each line into a new modifiedStyleTextLines
			 3. Whenever the current line has @font-face, iterate further until we reach the font-family (and keep copying into the modifiedStyleTextLines)
			 4. When we find the font-family, retrieve the font-family name (and convert it to lowercase, remove extraneous characters from it
			 5. Check if we have the font-family in the fontFamilyMappings and push an additional line for the src into modifiedStyleTextLines if a match is found
			 6. Handle a special case here if font-family is the only line in the font-face and ends with a } (isEndOfLine logic)
			 7. Repeat for other font-faces
			 8. Set the style element's innerHTML as the modifiedStyleTextLines
			 */
			var styleDeclaration = styleDeclarations[s].innerHTML;
			var styleTextLines = styleDeclaration.split('\n');
			var modifiedStyleTextLines = [];
			var foundFontFace = false;
			for (var i=0; i<styleTextLines.length; i++) {
				modifiedStyleTextLines.push(styleTextLines[i]);
				if (styleTextLines[i] == '@font-face') {
					foundFontFace = true;
				}
				if (foundFontFace) {
					var foundFontFamily = false;
					while (!foundFontFamily) {
						if (styleTextLines[i].includes('font-family')) {
							foundFontFamily = true;
							var fontFamilyParts = styleTextLines[i].split(':');
							var isEndOfLine = fontFamilyParts[1].includes('}');
							var fontFamily = fontFamilyParts[1].replace(/;|}|\"| /gi, '').toLowerCase();
							if (fontFamily.localeCompare('calibri') === 0)
								foundCalibriFontFace = true;
							var srcUrls = fontFamilyMappings[fontFamily];
							if (srcUrls !== undefined) {
								if (isEndOfLine) {
									var fontFamilyLine = modifiedStyleTextLines.pop();
									modifiedStyleTextLines.push(fontFamilyLine.replace('}', ';'));
									modifiedStyleTextLines.push(srcUrls.concat('}'));
								} else {
									modifiedStyleTextLines.push(srcUrls);
								}
							}
							foundFontFace = false;
						} else {
							i++;
							modifiedStyleTextLines.push(styleTextLines[i]);
						}
					}
				}
			}
			window.webkit.messageHandlers.JSLoggingBridge.postMessage('scrubFontFaces setting innerHTML from modifiedStyleTextLines');
			document.getElementsByTagName('style')[s].innerHTML = modifiedStyleTextLines.join('\n');
		}
		/*
		 Set the document body's default fontFamily and fontSize
		 If any of the body elements do not have a font style, Calibri will be used as a fallback
		 Unsupported fonts will still fallback to webkit-standard font and not Calibri
		 */
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('scrubFontFaces setting body default font family and size');
		document.body.style.fontFamily = 'Calibri';
		document.body.style.fontSize = 14;
		/*
		 If no styleDeclarations were found or Calibri font face was never found, add one with a @font-face for Calibri
		 */
		if (styleDeclarations.length == 0 || foundCalibriFontFace == false) {
			window.webkit.messageHandlers.JSLoggingBridge.postMessage('scrubFontFaces adding default Calibri font face');
			var styleElement = document.createElement('style');
			styleElement.innerHTML = '@font-face {font-family:Calibri; src:url('+fontsDirectory+'Calibri.ttf);}';
			document.getElementsByTagName('head')[0].appendChild(styleElement);
		}
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('End of scrubFontFaces');
	}
	/*
	 End of font scrubbing scripts
	 */
	
	/*
	 Content blocker scripts
	 */
	// HTML by removing external content
	function _blockExternalContent(document) {

		window.webkit.messageHandlers.JSLoggingBridge.postMessage('Start of _blockExternalContent');
		var BLOCKER_URL = 'content-blocker://';

		var documentElement = document.documentElement;

		// Clear external links
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('_blockExternalContent clearing external links');
		var links = documentElement.querySelectorAll('link');
		_forEach(links, function(link) {
			link.parentElement.removeChild(link);
		});

		// Clear src on img, video, audio etc. Refer: https://www.w3schools.com/tags/att_src.asp
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('_blockExternalContent clearing src on resources');
		var elements = documentElement.querySelectorAll('audio, embed, iframe, img, input, script, source, track, video, bgsound');
		_forEach(elements, function(element) {
			// Don't block inline attachments
			if (!_isInlineAttachment(element)) {
				element.src = BLOCKER_URL;
				element.srcset = BLOCKER_URL;
				element.style.borderRadius = '0';
			}
		});

		// Clear url on style sheets, e.g. url("http://outlook.com") -> url('content-blocker://')
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('_blockExternalContent clearing url on style sheets');
		var regex = _regexThatMatchesURLs();
		var replaceTemplate = '$1\'' + BLOCKER_URL + '\'$3';
		var styles = documentElement.querySelectorAll('style');
		_forEach(styles, function(style) {
			style.innerHTML = style.innerHTML.replace(regex, replaceTemplate);
		});

		// Clear urls that appear in inline css
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('_blockExternalContent clearing urls in inline css');
		var allElements = documentElement.querySelectorAll("*");
		_forEach(allElements, function(element) {
			var cssText = element.style.cssText;
			element.style.cssText = cssText.replace(regex, replaceTemplate);
		});

		// Clear `background` attribute (dated HTML standard)
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('_blockExternalContent clearing background attribute');
		var backgroundElements = documentElement.querySelectorAll('[background]');
		_forEach(backgroundElements, function(element) {
			element.setAttribute('background', BLOCKER_URL);
		});
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('End of _blockExternalContent');
	}

	function _isInlineAttachment(element) {

		// Base64 image
		if (_hasPrefix(element.src, 'data:image')) {
			return true;
		}

		// Example: <img src="cid:1234">
		if (_hasPrefix(element.src, 'cid:')) {
			return true;
		}
		return false;
	}

	// Refer: https://stackoverflow.com/questions/30106476/using-javascripts-atob-to-decode-base64-doesnt-properly-decode-utf-8-strings
	function _decodeBase64(string) {
		return decodeURIComponent(Array.prototype.map.call(atob(string), function(c) {
			return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
		}).join(''));
	}

	// Parse query string to object
	function _parseQuery(query) {
		var object = {};
		query.replace(/([^=&]+)=([^&]*)/g, function(m, key, value) {
			object[decodeURIComponent(key)] = decodeURIComponent(value);
		});
		return object;
	}

	// Note:
	//  - This regex matches url() but ignores base64 images
	//  - url('http://o.com'), url("http://o.com") and url(http://o.com) are valid syntaxes
	//  - url(       "       http://o.com     ") is also valid
	//  - Regex could be tested here: https://regex101.com/r/ZD1vMQ/3
	//
	// Examples:
	//  - url("http://o.com") an external image, block it
	//  - url(data:image/png;base64) a local image, skip it
	//  - url(    '  https://o.com  ') very ugly and it's an external image, block it
	//  - url(   "  data:image/png  ") very ugly but it's a local image, skip it

	function _regexThatMatchesURLs() {
		return new RegExp('(url\\()((?! *["\']{0,1} *data:image).*)(\\))', 'ig');
	}

	function _forEach(iterable, handler) {
		Array.prototype.forEach.call(iterable, handler);
	}

	function _isNil(value) {
		return value == null;
	}

	function _isEmpty(value) {
		return _isNil(value) || value.length == 0;
	}

	function _hasPrefix(string, prefix) {
		return string.lastIndexOf(prefix, 0) === 0;
	}

	function _hasSuffix(string, suffix) {
		if (string) {
			return string.indexOf(suffix, string.length - suffix.length) !== -1;
		} else {
			return false;
		}
	}

	function _containsNetworkResources(document) {
		var documentElement = document.documentElement;
		// Clear src on img, video, audio etc. Refer: https://www.w3schools.com/tags/att_src.asp
		var elements = documentElement.querySelectorAll('audio, embed, iframe, img, input, script, source, track, video, bgsound');
		for (var i = 0; i < elements.length; i++) {
			if (!_isInlineAttachment(elements[i])) {
				return true;
			}
		}
		return false;
	}
							 
	/*
		Actionable messages scripts
	*/
	
	// These vars have to match with the ones declared in OLActionableWKWebView.js
	var ACTIONABLE_MESSAGE_ID 		= 'actionable-message';
	var AM_WRAPPER_ID 				= 'am-wrapper';
	var MAILBODY_ID 				= 'mainframe';
	var AM_SNACKBAR_WRAPPER_ID		= 'amSnackBarWrapper';
	var AM_SNACKBAR_ID 				= 'amSnackBar';

	function AddSnackBarDiv(document) {
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('Start of AddSnackBarDiv');
		if (!document.getElementById(AM_SNACKBAR_WRAPPER_ID)) {
			window.webkit.messageHandlers.JSLoggingBridge.postMessage('AddSnackBarDiv no AM_SNACKBAR_WRAPPER_ID Element');
			var divForSnackbarWrapper = document.createElement('div');
			divForSnackbarWrapper.id = AM_SNACKBAR_WRAPPER_ID;
			divForSnackbarWrapper.classList.add('amsnackbarwrapper');
			var divForSnackbar = document.createElement('div');
			divForSnackbar.id = AM_SNACKBAR_ID;
			divForSnackbar.classList.add('amsnackbar');
			divForSnackbarWrapper.appendChild(divForSnackbar);
			document.body.appendChild(divForSnackbarWrapper);
		}
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('End of AddSnackBarDiv');
	}

	function AddActionableMessageDiv(document) {
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('Start of AddActionableMessageDiv');
		if (document.getElementById(AM_WRAPPER_ID)) {
			return;
		} else {
			window.webkit.messageHandlers.JSLoggingBridge.postMessage('AddActionableMessageDiv no AM_WRAPPER_ID Element');
			var divForAMWrapper = document.createElement('div');
			divForAMWrapper.id = AM_WRAPPER_ID;
			//hide the wrapper div initially and show it the rendering JS
			divForAMWrapper.style.display = 'none';

			var divForAM = document.createElement('div');
			divForAM.id = ACTIONABLE_MESSAGE_ID;
			divForAMWrapper.appendChild(divForAM);
			document.body.prepend(divForAMWrapper);
			AddSnackBarDiv(document);
		}
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('End of AddActionableMessageDiv');
	}

	function AddMailBodyDiv(document) {
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('Start of AddMailBodyDiv');
		var divForMailbody = document.createElement('div');
		divForMailbody.id = MAILBODY_ID;
		// Move the body's children into wrapper div
		while (document.body.firstChild) {
			divForMailbody.appendChild(document.body.firstChild);
		}

		// Append the wrapper div to the body
		document.body.appendChild(divForMailbody);
		//hide the wrapper div
		divForMailbody.style.display = 'none';
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('End of AddMailBodyDiv');
	}
                                                                                                                                                                            
    function makeContentNotEditable(document) {
        document.body.contentEditable = false;
    }
                                                                                                                                                                             
	// Create DOM
	var document = _createDocument(sourceHTML);
	window.webkit.messageHandlers.JSLoggingBridge.postMessage('Created document');

	var doesContainExternalContent = _containsNetworkResources(document);
	if (shouldBlockExternalContent && doesContainExternalContent) {
		_blockExternalContent(document);
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('Blocked external content');
	}

	if (shouldDetectLinksAndEmailAddresses) {
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('Start of detectLinksAndEmailAddresses');
		var walker = document.createTreeWalker(document.documentElement, NodeFilter.SHOW_TEXT, null, false);
		var nextNode = walker.nextNode();
		while (nextNode) {
			var node = nextNode;
			nextNode = walker.nextNode();
			var encodedHTML = node.nodeValue.replaceAll('&','&amp;').replaceAll('>', '&gt;').replaceAll('<', '&lt;').replaceAll('\"','&quot;').replaceAll('\'', '&#39;');
			if (node.parentElement.tagName != 'A' && node.parentNode.nodeName != 'STYLE' && node.parentNode.nodeName != 'SCRIPT') {
			 var tempParent = node.parentElement.ownerDocument.createElement('tempParent');
				 tempParent.innerHTML = _detectLinksAndAddAnchorTags(encodedHTML);
				 if (!(tempParent.childNodes.length == 1 && tempParent.firstChild.nodeType == 3)) {
					 var lastNewNode = tempParent.lastChild;
					 if (lastNewNode) {
						 var parentNode = node.parentNode;
						 node.replaceWith(lastNewNode);
						 var newNode = tempParent.firstChild;
						 while (newNode) {
							 parentNode.insertBefore(newNode, lastNewNode);
							 newNode = tempParent.firstChild;
						 }
					 }
				 }
			 }
		}
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('End of detectLinksAndEmailAddresses ');
	}

	if (isActionableMessage) {
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('Start of AddDivs for AM');
		AddMailBodyDiv(document);
		AddActionableMessageDiv(document);
		window.webkit.messageHandlers.JSLoggingBridge.postMessage('End of AddDivs for AM');
	}
	
	scrubFontFaces(document, base64FontMappings, fontsDirectory);
	window.webkit.messageHandlers.JSLoggingBridge.postMessage('ScrubbedFontFaces');
	if (contentNotEditable)
		makeContentNotEditable(document);
							 
	// Create doctype, HTML
	var resultHTML;
	var components = [_getDoctype(document), document.documentElement.outerHTML];

	var html = components.filter(function(element) {
		return !_isNil(element);
	});
	window.webkit.messageHandlers.JSLoggingBridge.postMessage('Reconstructed html');
	resultHTML = html.join('\n');

	return {
		'doesContainExternalContent': doesContainExternalContent,
		'resultHTML': resultHTML
	};
})
