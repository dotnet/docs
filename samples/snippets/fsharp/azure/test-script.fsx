#r "nuget: Azure.Storage.Blobs"
open Azure.Storage.Blobs
open Azure.Storage.Blobs.Models
open Azure.Storage.Blobs.Specialized

// Test if the APIs work
let testConnection = "DefaultEndpointsProtocol=https;AccountName=test;AccountKey=test;EndpointSuffix=core.windows.net"
let container = BlobContainerClient(testConnection, "test")
printfn "Container client created successfully using v12 SDK"