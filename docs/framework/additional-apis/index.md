---
title: Additional class libraries and APIs
description: Explore additional class libraries and APIs in .NET, including out-of-band (OOB) projects, platform-specific libraries, and private APIs.
ms.date: 08/11/2020
helpviewer_keywords:
  - "Additional class libraries"
  - "Additional managed libraries"
  - ".NET Framework out-of-band releases"
  - "out-of-band releases"
ms.assetid: cf2d9006-b631-4e5d-81cd-20aab78c60f1
ms.topic: conceptual
---
# Additional class libraries and APIs

This article lists .NET Framework APIs that either were released out of band, target a specific platform, or are private or internal types.

## OOB projects

To improve cross-platform development and introduce new functionality early, some .NET Framework features were released out of band (OOB).

| Project | Description |
| ------- | ----------- |
| <xref:System.Collections.Immutable> | Provides collections that are thread safe and guaranteed to never change their contents. |
| <xref:System.Net.Http.WinHttpHandler> | Provides a message handler for <xref:System.Net.Http.HttpClient> based on the WinHTTP interface of Windows. |
| <xref:System.Numerics> | Provides a library of vector types that can take advantage of SIMD hardware-based acceleration.|
| <xref:System.Threading.Tasks.Dataflow> | The TPL Dataflow Library provides dataflow components to help increase the robustness of concurrency-enabled applications. |

## Platform-specific libraries

Some libraries target specific platforms. For example, the <xref:System.Text.CodePagesEncodingProvider> class makes code page encodings available to UWP apps developed using .NET Framework.

| Project | Description |
| ------- | ----------- |
| <xref:System.Text.CodePagesEncodingProvider> | Extends the <xref:System.Text.EncodingProvider> class to make code page encodings available to apps that target the Universal Windows Platform. |

## Private APIs

These APIs support the product infrastructure and are not intended or supported to be used directly from your code.

* [Microsoft.SqlServer.Server.SmiOrderProperty.Item property](microsoft.sqlserver.server.smiorderproperty.item.md)
* [System.Exception.PrepForRemoting method](system.exception.prepforremoting.md)
* [System.Data.SqlTypes.SqlChars.Stream property](system.data.sqltypes.sqlchars.stream.md)
* [System.Data.SqlTypes.SqlStreamChars Constructor](system.data.sqltypes.sqlstreamchars.-ctor.md)
* [System.Data.SqlTypes.SqlStreamChars.CanSeek property](system.data.sqltypes.sqlstreamchars.canseek.md)
* [System.Data.SqlTypes.SqlStreamChars.IsNull property](system.data.sqltypes.sqlstreamchars.isnull.md)
* [System.Data.SqlTypes.SqlStreamChars.Length property](system.data.sqltypes.sqlstreamchars.length.md)
* [System.Data.SqlTypes.SqlStreamChars.Close method](system.data.sqltypes.sqlstreamchars.close.md)
* [System.Data.SqlTypes.SqlStreamChars.Dispose method](system.data.sqltypes.sqlstreamchars.dispose.md)
* [System.Data.SqlTypes.SqlStreamChars.Flush method](system.data.sqltypes.sqlstreamchars.flush.md)
* [System.Data.SqlTypes.SqlStreamChars.Read method](system.data.sqltypes.sqlstreamchars.read.md)
* [System.Data.SqlTypes.SqlStreamChars.Seek method](system.data.sqltypes.sqlstreamchars.seek.md)
* [System.Data.SqlTypes.SqlStreamChars.SetLength method](system.data.sqltypes.sqlstreamchars.setlength.md)
* [System.Data.SqlTypes.SqlStreamChars.Write method](system.data.sqltypes.sqlstreamchars.write.md)
* [System.IO.MemoryStream.InternalGetOriginAndLength method](system.io.memorystream.internalgetoriginandlength.md)
* [System.Net.ComNetOS class](system.net.comnetos.md)
* [System.Net.Connection class](connection.md)
* [System.Net.Connection.m\_WriteList field](m_writelist.md)
* [System.Net.ConnectionGroup class](connectiongroup.md)
* [System.Net.ConnectionGroup.m\_ConnectionList field](m_connectionlist.md)
* [System.Net.ConnectStream.Connection property](system.net.connectstream.connection.md)
* [System.Net.CoreResponseData class](coreresponsedata.md)
* [System.Net.CoreResponseData.m\_ResponseHeaders field](coreresponsedata_m_responseheaders.md)
* [System.Net.CoreResponseData.m\_StatusCode field](coreresponsedata_m_statuscode.md)
* [System.Net.ExceptionHelper class](system.net.exceptionhelper.md)
* [System.Net.HttpStatusDescription class](system.net.httpstatusdescription.md)
* [System.Net.HttpWebRequest.\_AutoRedirects field](_autoredirects.md)
* [System.Net.HttpWebRequest.\_CoreResponse field](httpwebrequest__coreresponse.md)
* [System.Net.HttpWebRequest.\_HttpResponse field](_httpresponse.md)
* [System.Net.Logging class](system.net.logging.md)
* [System.Net.Mail.MailAddressParser class](system.net.mail.mailaddressparser.md)
* [System.Net.Mail.QuotedPairReader class](system.net.mail.quotedpairreader.md)
* [System.Net.Mime.MailBnfHelper class](system.net.mime.mailbnfhelper.md)
* [System.Net.PooledStream.NetworkStream property](system.net.pooledstream.networkstream.md)
* [System.Net.RtcState class](system.net.rtcstate.md)
* [System.Net.Security.SslState.SslProtocol property](system.net.security.sslstate.sslprotocol.md)
* [System.Net.ServicePoint.m\_ConnectionGroupList field](m_connectiongrouplist.md)
* [System.Net.ServicePointManager.CloseConnectionGroups method](system.net.servicepointmanager.closeconnectiongroups.md)
* [System.Net.ServicePointManager.s\_ServicePointTable field](s_servicepointtable.md)
* [System.Net.TlsStream.m_Worker field](system.net.tlsstream.m_worker.md)
* [System.Net.UnsafeNclNativeMethods class](system.net.unsafenclnativemethods.md)
* [System.Net.WebHeaderCollection.AddInternal method](system.net.webheadercollection.addinternal.md)
* [System.ServiceModel.Channels.Message.BodyToString method](system.servicemodel.channels.message.bodytostring.md)
* [System.ServiceModel.Channels.Message.WriteStartHeaders method](system.servicemodel.channels.message.writestartheaders.md)
* [System.Web.Compilation.ControlBuilderInterceptor class](controlbuilderinterceptor-class.md)
* [System.Windows.Controls.GridViewHeaderRowPresenter.FindHeaderByColumn method](system.windows.controls.gridviewheaderrowpresenter.findheaderbycolumn.md)
* [System.Windows.Controls.GridViewHeaderRowPresenter.MakeParentItemsControlGotFocus method](system.windows.controls.gridviewheaderrowpresenter.makeparentitemscontrolgotfocus.md)
* [System.Windows.Controls.GridViewHeaderRowPresenter.PrepareHeaderDrag method](system.windows.controls.gridviewheaderrowpresenter.prepareheaderdrag.md)
* [System.Windows.Diagnostics.VisualDiagnostics.s\_isDebuggerCheckDisabledForTestPurposes field](s-isdebuggercheckdisabledfortestpurposes-field.md)
* [System.Windows.Forms.ContainerControl.ResetActiveAndFocusedControlsRecursive method](system-windows-forms/resetactiveandfocusedcontrolsrecursive-method.md)
* [System.Windows.Forms.Control.UpdateStylesCore method](system-windows-forms/updatestylescore-method.md)
* [System.Windows.Forms.ControlPaint.CalculateBackgroundImageRectangle method](system-windows-forms/calculatebackgroundimagerectangle-method.md)
* [System.Windows.Forms.Design.DataMemberFieldEditor class](datamemberfieldeditor-class.md)
* [System.Windows.Forms.Design.DataMemberListEditor class](datamemberlisteditor-class.md)
* [System.Xml.XmlReader.CreateSqlReader method](system.xml.xmlreader.createsqlreader.md)
* [adodb.Connection interface](adodb.connection.md)
* [adodb.EventReason enum](adodb.eventreasonenum.md)
* [adodb.EventStatus enum](adodb.eventstatusenum.md)
* [stdole.DISPPARAMS Structure](stdole.dispparams.md)
* [stdole.EXCEPINFO Structure](stdole.excepinfo.md)
* [stdole.IFont.Name property](stdole.ifont.name.md)
* [stdole.IFontDisp interface](stdole.ifontdisp.md)
* [stdole.IPicture.Handle property](stdole.ipicture.handle.md)
* [stdole.IPictureDisp.Handle property](stdole.ipicturedisp.handle.md)
* [stdole.StdFont interface](stdole.stdfont.md)
* [stdole.StdPicture interface](stdole.stdpicture.md)

## See also

* [.NET Framework and Out-of-Band Releases](../get-started/the-net-framework-and-out-of-band-releases.md)
