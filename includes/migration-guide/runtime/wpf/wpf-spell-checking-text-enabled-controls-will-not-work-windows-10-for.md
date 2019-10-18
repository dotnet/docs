### WPF spell checking in text-enabled controls will not work in Windows 10 for languages not in the OS's input language list

|   |   |
|---|---|
|Details|When running on Windows 10, the spell checker may not work for WPF text-enabled controls because platform spell-checking capabilities are available only for languages present in the input languages list.In Windows 10, when a language is added to the list of available keyboards, Windows automatically downloads and installs a corresponding Feature on Demand (FOD) package that provides spell-checking capabilities. By adding the language to the input languages list, the spell checker will be supported.|
|Suggestion|Be aware that the language or text to be spell-checked must be added as an input language for spell-checking to work in Windows 10.|
|Scope|Edge|
|Version|4.6|
|Type|Runtime|
