<!-- <Snippet10> -->
<!-- <Snippet4> -->
<%@ page language="C#" %>
<%@ register tagprefix="aspSample" 
    assembly="DesignerServicesAndListsCS" 
    namespace="Samples.AspNet.CS.Controls" %>
<!-- </Snippet4> -->
<!-- <Snippet5> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>Designer Samples</title>
</head>

<body>
  <form id="form1" runat="server">
      <p style="font-family:tahoma;font-size:larger;
      font-weight:bold">
        Using Action Lists and Designer Host Services</p>
      <div style="font-family:tahoma;font-size:x-small">
        <span style="font-size: 10pt">Control #1 (ControlWithStyleTasksDesigner):
        PanelContainerDesigner using a DesignerActionList, which
        obtains a list of XML files in the project and sets 
        the style using the XML element
        definitions.</span><p />
      </div>
      <aspSample:ControlWithStyleTasks id="ctl1" 
        runat="server" 
        backcolor="Red" forecolor="White">
          Hello there.</aspSample:ControlWithStyleTasks>
      <br />
      <div style="font-family:tahoma;font-size:x-small">
        <span style="font-size: 10pt">Control #2 (ControlWithConfigurationSettingDesigner):
        PanelContainerDesigner using configuration settings
        to obtain 
        the FrameCaption value.</span><p />
      </div>
      <aspSample:ControlWithConfigurationSetting 
        id="ctl2" runat="server">
        Hello There
      </aspSample:ControlWithConfigurationSetting>
      <br />
      <div style="font-family:tahoma;font-size:x-small">
        <span style="font-size: 10pt">Control #3 (ControlWithButtonTasksDesigner):
        PanelContainerDesigner using a smart-task action 
        item to insert a new button to the Web Form.</span><p />
      </div>
      <aspSample:ControlWithButtonTasks 
        id="ctl3" runat="server">
        Hello There
      </aspSample:ControlWithButtonTasks>
      &nbsp; &nbsp;
  </form>
</body>
</html>
<!-- </Snippet5> -->
<!-- </Snippet10> -->