
namespace Widgets

module WidgetModule1 =
   let widgetFunction x y =
      printfn "Module1 %A %A" x y
module WidgetModule2 =
   let widgetFunction x y =
      printfn "Module2 %A %A" x y

module useWidgets =

  do
     WidgetModule1.widgetFunction 10 20
     WidgetModule2.widgetFunction 5 6