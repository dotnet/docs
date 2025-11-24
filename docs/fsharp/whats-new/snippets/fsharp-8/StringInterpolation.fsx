// Extended string interpolation syntax
let classAttr = "item-panel"

// Before F# 8 - braces must be doubled
let cssOld = $""".{classAttr}:hover {{background-color: #eee;}}"""
printfn "CSS Old: %s" cssOld

// With F# 8 - multiple $ signs to define interpolation level
let cssNew = $$""".{{classAttr}}:hover {background-color: #eee;}"""
printfn "CSS New: %s" cssNew

// HTML templating with triple $$$
let templateNew = $$$"""
<div class="{{{classAttr}}}">
  <p>{{title}}</p>
</div>
"""
printfn "Template: %s" templateNew
