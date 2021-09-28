let task1 = async {
        let x = 10
        let y = 15
        for i in x ..y do
           let logi = log (float i)
           printf "%d %f" i logi
        return x + y
   }

let task2 = async {
        let x = 10
        let y = 20
        for i in x ..y do
           printf "[%s] " (i.ToString())
        return x + y
   }

// Execute the code, mixing the results.
let results = Async.RunSynchronously (Async.Parallel [ task1; task2 ])