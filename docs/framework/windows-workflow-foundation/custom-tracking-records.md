---
title: "Custom Tracking Records"
ms.date: "03/30/2017"
ms.assetid: 24284565-c68b-40bf-b7f1-e148d151a6fc
---
# Custom Tracking Records
This topic demonstrates how to create custom tracking records and populate them with data to be emitted along with the records.  
  
## Emitting Custom Tracking Records  
 Custom tracking records can be emitted from a code activity as shown in the following example.  
  
```  
protected override void Execute(CodeActivityContext context)  
{  
…  
            CustomTrackingRecord customRecord = new CustomTrackingRecord("CustomEmailSentEvent");  
            customRecord.Data.Add("SendTime", sendTime);  
            context.Track(customRecord);  
}  
```  
  
 A <xref:System.Activities.Tracking.CustomTrackingRecord> is emitted in a code activity by invoking the <xref:System.Activities.NativeActivityContext.Track%2A> method on the `ActvityContext`.  
  
## See also
 [Windows Server App Fabric Monitoring](https://go.microsoft.com/fwlink/?LinkId=201273)  
 [Monitoring Applications with App Fabric](https://go.microsoft.com/fwlink/?LinkId=201275)
