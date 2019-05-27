### Resgen refuses to load content from the web

|   |   |
|---|---|
|Details|.resx files may contain binary formatted input. If you attempt to use resgen to load a file that was downloaded from an untrusted location, it will fail to load the input by default.|
|Suggestion|Resgen users who require loading binary formatted input from untrusted locations can either remove the mark of the web from the input file or apply the opt-out quirk.Add the following registry setting to apply the machine wide opt-out quirk: [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft.NETFramework\SDK] &quot;AllowProcessOfUntrustedResourceFiles&quot;=&quot;true&quot;|
|Scope|Edge|
|Version|4.7.2|
|Type|Retargeting|
