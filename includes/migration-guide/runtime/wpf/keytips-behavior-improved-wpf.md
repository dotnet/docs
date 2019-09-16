### Keytips behavior improved in WPF

|   |   |
|---|---|
|Details|Keytips behavior has been modified to bring parity with behavior on Microsoft Word and Windows Explorer. By checking whether keytip state is enabled or not in the case of a <xref:System.Windows.Input.KeyEventArgs.SystemKey> (in particular, <xref:System.Windows.Input.Key> or <xref:System.Windows.Input.Key.F11>) being pressed, WPF handles keytip keys appropriately. Keytips now dismiss a menu even when it is opened by mouse.|
|Suggestion|N/A|
|Scope|Edge|
|Version|4.7.2|
|Type|Runtime|
