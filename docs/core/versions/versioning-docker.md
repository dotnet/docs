
### Docker

A general Docker tag naming convention is to place the version number before the component name. This convention may continue to be utilized. The current tags include only the Runtime version as follows.

* 1.0.8-runtime
* 1.0.8-sdk
* 2.0.4-runtime
* 2.0.4-sdk
* 2.1.1-runtime
* 2.1.1-sdk

The SDK tags should be updated to represent the SDK version rather than Runtime.

It's also possible that the .NET Core CLI tools (included in the SDK) are fixed but reship with an existing runtime. In that case, the SDK version is increased (for example, to 2.1.2), and then the Runtime catches up the next time it ships (for example, both the Runtime and SDK ship the following time as 2.1.3).