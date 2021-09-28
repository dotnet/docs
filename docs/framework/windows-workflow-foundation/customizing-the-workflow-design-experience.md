---
description: "Learn more about: Customizing the Workflow Design Experience"
title: "Customizing the Workflow Design Experience"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "extending [WF], Workflow Designer"
ms.assetid: 98135077-0f5d-4d16-9337-01094e843537
---
# Customizing the Workflow Design Experience

The scenarios for designing custom activities and for rehosting the Windows Workflow Designer have been greatly simplified in .NET Framework 4. Development and deployment are now both easier and more flexible. The key infrastructural change is that the new activity designer programming model is built upon Windows Presentation Foundation (WPF). This gives you the ability to define activity designers declaratively and to rehost the Workflow Designer in other applications with comparative easy. When rehosting, a custom expression editor can be developed to support IntelliSense or a simplified expression domain. The integration with Windows Communication Foundation (WCF) has become more seamless with use of workflow services. Custom activity designers and the Model Item Tree can be used to enhance design time experiences in rehosted workflow designers.

## In This Section

 [Using Custom Activity Designers and Templates](using-custom-activity-designers-and-templates.md)

 Describes how to create new custom activity designers and templates.

 [Rehosting the Workflow Designer](rehosting-the-workflow-designer.md)

 Describes how to re-host the Windows Workflow Designer outside of Visual Studio and how to display validation errors.

 [Using a Custom Expression Editor](using-a-custom-expression-editor.md)

 Describes how to implement a custom expression editor to use with workflow designers rehosted outside of Visual Studio 2010.

## Reference

<xref:System.Activities.Presentation.ActivityDesigner>

## See also

- [Extending Windows Workflow Foundation](extend.md)
- [Designer](./samples/designer.md)
- [Custom Activity Designers](./samples/custom-activity-designers.md)
- [Designer ReHosting](./samples/designer-rehosting.md)
