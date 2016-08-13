
module SocketClient =

    open System.Net
    open System.Net.Sockets
    open System.Collections.Generic

    let toIList<'T> (data : 'T array) =
        let segment = new System.ArraySegment<'T>(data)
        let data = new List<System.ArraySegment<'T>>() :> IList<System.ArraySegment<'T>>
        data.Add(segment)
        data

    type Socket with
        member this.MyAcceptAsync(receiveSize) =
            Async.FromBeginEnd(receiveSize,
                               (fun (receiveSize, callback, state) ->
                                   this.BeginAccept(receiveSize, callback, state)),
                               this.EndConnect)
        member this.MyConnectAsync(ipAddress : IPAddress, port : int) =
            Async.FromBeginEnd(ipAddress, port,
                               (fun (ipAddress:IPAddress, port, callback, state) ->
                                   this.BeginConnect(ipAddress, port, callback, state)),
                               this.EndConnect)
        member this.MySendAsync(data, flags : SocketFlags) =
            Async.FromBeginEnd(toIList data, flags, 
                               (fun (data : IList<System.ArraySegment<byte>>,
                                     flags : SocketFlags, callback, state) ->
                                         this.BeginSend(data, flags, callback, state)),
                               this.EndSend)
        member this.MyReceiveAsync(data, flags : SocketFlags) =
            Async.FromBeginEnd(toIList data, flags, 
                               (fun (data : IList<System.ArraySegment<byte>>,
                                     flags : SocketFlags, callback, state) ->
                                         this.BeginReceive(data, flags, callback, state)),
                               this.EndReceive)

    let port = 11000

    let socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    let ipHostEntry = Dns.Resolve("hostname.contoso.com")
    printfn "Server address: %s" (ipHostEntry.AddressList.[0].ToString())
    
    let connectSendReceive (socket : Socket) =
        async {
            do! socket.MyConnectAsync(ipHostEntry.AddressList.[0], 11000)
            printfn "Connected to remote host."
            let buffer1 = [| 0uy .. 255uy |]
            let buffer2 = Array.zeroCreate<byte> 255
            let flags = new SocketFlags()
            printfn "Sending data..."
            let! flag = socket.MySendAsync(buffer1, flags)
            printfn "Receiving data..."
            let! result = socket.MyReceiveAsync(buffer2, flags)
            printfn "Received data from remote host."
            return buffer2
        }

    let acceptReceiveSend (socket : Socket) =
        async {
            socket.Listen(1)
            do! socket.MyAcceptAsync(256)
            let buffer1 = Array.zeroCreate<byte> 255
            let flags = new SocketFlags()
            let! flag = socket.MyReceiveAsync(buffer1, flags)
            let buffer2 = Array.rev buffer1
            let! flag = socket.MySendAsync(buffer2, flags)
            return buffer2
        }

    let taskClient = Async.StartAsTask(connectSendReceive(socket))
    
    taskClient.Wait()
    taskClient.Result |> Array.iter (fun elem -> printf "%d " elem)