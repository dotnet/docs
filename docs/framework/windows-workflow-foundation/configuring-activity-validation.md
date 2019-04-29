---
title: "Configuring Activity Validation"
ms.date: "03/30/2017"
ms.assetid: 25a4eccb-b8fc-4857-a01d-2683b6341219
---
# Configuring Activity Validation
Activity validation enables activity authors and users to identify and report errors in an activity’s configuration prior to its execution. Windows Workflow Foundation (WF) provides the following three types of activity validation:  
  
- `RequiredArgument` and `OverloadGroup` attributes.  
  
- Imperative code-based validation.  
  
- Declarative constraints.  
  
 `RequiredArgument` and `OverloadGroup` attributes indicate that certain arguments on an activity are required. Imperative code-based validation provides a simple way for an activity to provide validation about itself, and declarative constraints enable validation about the activity and its relationship with the containing workflow. If an activity is not configured properly according to the validation requirements, validation errors and warnings are returned. If the containing workflow is created using the workflow designer, any validation errors and warnings are displayed in the designer. If the workflow is created outside of the workflow designer any validation errors are returned when the workflow is invoked. Regardless of how the workflow was created, a workflow with validation errors is never allowed to execute. This section provides an overview of these types of activity validation and how activity validation is invoked.  
  
## In This Section  
 [Required Arguments and Overload Groups](required-arguments-and-overload-groups.md)  
 Describes how to use the `RequiredArgument` and `OverloadGroup` attributes to provide validation.  
  
 [Imperative Code-Based Validation](imperative-code-based-validation.md)  
 Describes how to use code-based validation for <xref:System.Activities.CodeActivity> and <xref:System.Activities.NativeActivity> based activities.  
  
 [Declarative Constraints](declarative-constraints.md)  
 Describes how to use declarative constraints to provide complex activity validation.  
  
 [Invoking Activity Validation](invoking-activity-validation.md)  
 Discusses when activity validation is invoked automatically and how to explicitly invoke validation.  
  
## Reference  
  
## Related Sections
