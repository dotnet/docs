open System

let GetDirectoriesAsync path =
    let fn = new Func<_, _>(System.IO.Directory.GetDirectories)
    Async.FromBeginEnd(path, fn.BeginInvoke, fn.EndInvoke)