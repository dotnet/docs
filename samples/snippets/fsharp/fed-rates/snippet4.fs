open System.Net
open System.IO


let loadRates maturity =
    // The following tuples associate various maturity durations, in years,
    // with codes defined for treasury bills by the Federal Reserve.
    let maturitiesMap = Map.ofList [(1, "e30653a4b627e9d1f2490a0277d9f1ac")
                                    (2, "c66ea77a2e8f0919c5133c7633065908")
                                    (5, "fbb02942bfdbff31a479e98bcbe26388")
                                    (10, "bcb44e57fb57efbe90002369321bfb3f")
                                    (20, "a1ebeb6e84ca6389772dd054dc980191")]
    let seriesID = Map.find maturity maturitiesMap

    let url = sprintf "http://www.federalreserve.gov/datadownload/Output.aspx?rel=H15&series=%s&lastObs=&from=&to=&filetype=csv&label=include&layout=seriescolumn" seriesID
    let req = WebRequest.Create(url, Timeout = 10000000)
    let resp = req.GetResponse()
    let stream = resp.GetResponseStream()
    let reader = new StreamReader(stream)
    let csv = reader.ReadToEnd()



    let interest =
        csv.Split([|'\n'|])
        |> Seq.skip 8
        |> Seq.map (fun line -> line.Trim())
        |> Seq.filter (fun line -> not (line.EndsWith("ND")))
        |> Seq.filter (fun line -> not (line.Length = 0))
        |> Seq.map (fun line -> line.Split([|','|]))
        |> Seq.map ( fun values ->
            System.DateTime.Parse(values.[0], CultureInfo.CreateSpecificCulture("en-US")),
            float values.[1])

    interest