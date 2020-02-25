
    type Widget = { ID: int; Rev: int }

    let compareWidgets widget1 widget2 =
       if widget1.ID < widget2.ID then -1 else
       if widget1.ID > widget2.ID then 1 else
       if widget1.Rev < widget2.Rev then -1 else
       if widget1.Rev > widget2.Rev then 1 else
       0

    let arrayToSort =
     [|
        { ID = 92; Rev = 1 }
        { ID = 110; Rev = 1 }
        { ID = 100; Rev = 5 }
        { ID = 100; Rev = 2 }
        { ID = 92; Rev = 1 }
     |]

    let sortedWidgetArray = Array.sortWith compareWidgets arrayToSort
    printfn "%A" sortedWidgetArray