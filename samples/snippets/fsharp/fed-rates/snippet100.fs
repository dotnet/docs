
open System.Net
open System.IO

let url = sprintf "http://www.federalreserve.gov/datadownload/Output.aspx?rel=H15&series=bcb44e57fb57efbe90002369321bfb3f&lastObs=&from=&to=&filetype=csv&label=include&layout=seriescolumn"
let req = WebRequest.Create(url, Timeout = 10000000)
let resp = req.GetResponse()
let stream = resp.GetResponseStream()
let reader = new StreamReader(stream)
let csv = reader.ReadToEnd()