# Optimization for Shared Web Hosting

If you are the administrator for a server that is shared by hosting several small Web sites, you can optimize performance and increase site capacity by adding the following `gcTrimCommitOnLowMemory` setting to the runtime node in the **Aspnet.config** file in the .NET Framework directory:

`<gcTrimCommitOnLowMemory enabled="true|false"/>`

> **Note**
>
> This setting is recommended only for shared Web hosting scenarios.

Because the garbage collector retains memory for future allocations, its committed space can be more than what is strictly needed. You can reduce this space to accommodate times when there is a heavy load on system memory. Reducing this committed space improves performance and expands the capacity to host more sites. 

When the `gcTrimCommitOnLowMemory` setting is enabled, the garbage collector evaluates the system memory load and enters a trimming mode when the load reaches 90%. It maintains the trimming mode until the load drops under 85%. 

When conditions permit, the garbage collector can decide that the `gcTrimCommitOnLowMemory` setting will not help the current application and ignore it.

## Example

The following XML fragment shows how to enable the `gcTrimCommitOnLowMemory` setting. Ellipses indicate other settings that would be in the runtime node. 

```
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
    <runtime>
    . . .
    <gcTrimCommitOnLowMemory enabled="true"/>
    </runtime>
    . . .
</configuration>
```

## See Also

[Garbage Collection](essentials\gc\garbagecollection.md)

