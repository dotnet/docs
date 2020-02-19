---
title: "How to: Display Validation Errors in a Rehosted Designer"
ms.date: "03/30/2017"
ms.assetid: 5aa8fb53-8f75-433b-bc06-7c7d33583d5d
---
# How to: Display Validation Errors in a Rehosted Designer
This topic describes how to retrieve and publish validation errors in a rehosted Windows Workflow Designer. This provides us with a procedure to confirm that a workflow in a rehosted designer is valid.  
  
 This task has two parts. The first is to provide an implementation <xref:System.Activities.Presentation.Validation.IValidationErrorService>.  There is one critical method to implement on this interface, <xref:System.Activities.Presentation.Validation.IValidationErrorService.ShowValidationErrors%2A> which will pass you a list of <xref:System.Activities.Presentation.Validation.ValidationErrorInfo> objects containing information about the errors to the debug log.  After implementing the interface, you retrieve the error information by publishing an instance of that implementation to the editing context.  
  
### Implement the IValidationErrorService Interface  
  
1. Here is a code sample for a simple implementation that will write out the validation errors to the debug log.  
  
    ```csharp  
    using System.Activities.Presentation.Validation;  
    using System.Collections.Generic;  
    using System.Diagnostics;  
    using System.Linq;  
  
    namespace VariableFinderShell  
    {  
        class DebugValidationErrorService : IValidationErrorService  
        {  
            public void ShowValidationErrors(IList<ValidationErrorInfo> errors)  
            {  
                errors.ToList().ForEach(vei => Debug.WriteLine($"Error: {vei.Message}"));  
            }  
        }  
    }  
    ```  
  
### Publishing to the Editing Context  
  
1. Here is the code that will publish this to the editing context.  
  
    ```csharp  
    wd.Context.Services.Publish<IValidationErrorService>(new DebugValidationErrorService());  
    ```
