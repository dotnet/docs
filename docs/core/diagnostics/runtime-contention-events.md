# Contention Events

These runtime events capture information about managed thread contentions.

This category consists of the following events:

- [ContentionStart_V1](#contentionstart_v1-event)
- [ContentionStop_V1](#contentionstop_v1-event)

## ContentionStart_V1 Event

This event is emitted at the start of a managed thread contention.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ContentionKeyword` (0x4000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ContentionStart_V1`|81|A managed thread contention starts.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|Flags|win:UInt8|0 for managed; 1 for native.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

## ContentionStop_V1 Event

This event is emitted at the end of a managed thread contention.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ContentionKeyword` (0x4000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ContentionStop_V1`|91|A managed thread contention ends.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|Flags|win:UInt8|0 for managed; 1 for native.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|
|DurationNs|win:Double|Duration of the contention in nanoseconds.|
