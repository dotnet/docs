
module SocketServer =

    open System.Net
    open System.Net.Sockets
    open System.Collections.Generic

    let toIList<'T> (data : 'T array) =
        let segment = new System.ArraySegment<'T>(data)
        let data = new List<System.ArraySegment<'T>>() :> IList<System.ArraySegment<'T>>
        data.Add(segment)
        data

    type Socket with
        member this.MyAcceptAsync() =
            Async.FromBeginEnd((fun (callback, state) -> this.BeginAccept(callback, state)),
                               this.EndAccept)
        member this.MyConnectAsync(ipAddress : IPAddress, port : int) =
            Async.FromBeginEnd(ipAddress, port,
                               (fun (ipAddress:IPAddress, port, callback, state) ->
                                   this.BeginConnect(ipAddress, port, callback, state)),
                               this.EndConnect)
        member this.MySendAsync(data : byte array, flags : SocketFlags) =
            Async.FromBeginEnd(toIList data, flags, 
                               (fun (data : IList<System.ArraySegment<byte>>,
                                     flags : SocketFlags, callback, state) ->
                                         this.BeginSend(data, flags, callback, state)),
                               this.EndSend)
        member this.MyReceiveAsync(data : byte array, flags : SocketFlags) =
            Async.FromBeginEnd(toIList data, flags, 
                               (fun (data : IList<System.ArraySegment<byte>>,
                                     flags : SocketFlags, callback, state) ->
                                         this.BeginReceive(data, flags, callback, state)),
                               this.EndReceive)

    let port = 11000

    let socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    let ipHostInfo = Dns.Resolve(Dns.GetHostName())
    let localIPAddress = ipHostInfo.AddressList.[0]
    let localEndPoint = new IPEndPoint(localIPAddress, port)
    socket.Bind(localEndPoint)


    let connectSendReceive (socket : Socket) =
        async {
            do! socket.MyConnectAsync(ipHostInfo.AddressList.[0], 11000)
            let buffer1 = [| 0uy .. 255uy |]
            let buffer2 = Array.zeroCreate<byte> 255
            let flags = new SocketFlags()
            let! flag = socket.MySendAsync(buffer1, flags)
            let! result = socket.MyReceiveAsync(buffer2, flags)
            return buffer2
        }

    let acceptReceiveSend (socket : Socket) =
        async {
            printfn "Listening..."
            socket.Listen(10)
            printfn "Accepting..."
            let! socket = socket.MyAcceptAsync()
            
            let buffer1 = Array.zeroCreate<byte> 256
            let flags = new SocketFlags()
            printfn "Receiving..."
            let! nBytes = socket.MyReceiveAsync(buffer1, flags)
            printfn "Received %d bytes from client computer." nBytes
            let buffer2 = Array.rev buffer1
            printfn "Sending..."
            let! flag = socket.MySendAsync(buffer2, flags)
            printfn "Completed."
            return buffer2
        }

    let taskServer = Async.StartAsTask(acceptReceiveSend(socket))    
    taskServer.Wait()
    socket.Close()