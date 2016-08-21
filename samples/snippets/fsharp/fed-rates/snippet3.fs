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