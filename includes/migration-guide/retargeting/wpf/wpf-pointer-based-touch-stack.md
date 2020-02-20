### WPF Pointer-Based Touch Stack

|   |   |
|---|---|
|Details|This change adds the ability to enable an optional WM_POINTER based WPF touch/stylus stack.  Developers that do not explicitly enable this should see no change in WPF touch/stylus behavior.Current Known Issues With optional WM_POINTER based touch/stylus stack:<ul><li>No support for real-time inking.</li><li>While inking and StylusPlugins will still work, they will be processed on the UI Thread which can lead to poor performance.</li><li>Behavioral changes due to changes in promotion from touch/stylus events to mouse events</li><li>Manipulation may behave differently</li><li>Drag/Drop will not show appropriate feedback for touch input</li><li>This does not affect stylus input</li><li>Drag/Drop can no longer be initiated on touch/stylus events</li><li>This can potentially hang the application until mouse input is detected.</li><li>Instead, developers should initiate drag and drop from mouse events.</li></ul>|
|Suggestion|Developers who wish to enable this stack can add/merge the following to their application's App.config file:<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.System.Windows.Input.Stylus.EnablePointerSupport=true&quot;/&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>Removing this or setting the value to false will turn this optional stack off.Note that this stack is available only on Windows 10 Creators Update and above.|
|Scope|Edge|
|Version|4.7|
|Type|Retargeting|
