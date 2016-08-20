module RateAnalysis.Analyzer

open RateLoader

/// Provides analysis of historical interest rate data.
type Analyzer(ratesAndDates) =
    let rates =
        ratesAndDates
        |> Seq.map snd

    /// Construct Analyzer objects for each maturity category.
    static member GetAnalyzers(maturities) =
        maturities
        |> Seq.map loadRates
        |> Seq.map (fun ratesAndDates -> new Analyzer(ratesAndDates))

    member sa.Min =
        let date, minRate = (Seq.minBy (fun (_, rate) -> rate) ratesAndDates)
        (minRate, date.ToString("d"))

    member sa.Max =
        let date, maxRate = (Seq.maxBy (fun (_, rate) -> rate) ratesAndDates)
        (maxRate, date.ToString("d"))

    member sa.Current =
        rates |> List.ofSeq |> List.rev |> List.head