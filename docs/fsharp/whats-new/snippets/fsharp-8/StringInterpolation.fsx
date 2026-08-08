let classAttr = "item-panel"

// <Before>
let cssOld = $""".{classAttr}:hover {{background-color: #eee;}}"""
// </Before>
printfn "CSS Old: %s" cssOld

// <After>
let cssNew = $$""".{{classAttr}}:hover {background-color: #eee;}"""
// </After>
printfn "CSS New: %s" cssNew

// <Template>
let templateNew = $$$"""
<div class="{{{classAttr}}}">
  <p>{{title}}</p>
</div>
"""
// </Template>
printfn "Template: %s" templateNew
