module TestProp1

// <Snippet3>
open System
open System.IO

module FileUtilities =
    type EncodingType =
        | None = 0
        | Unknown = -1
        | Utf8 = 1
        | Utf16 = 2
        | Utf32 = 3

    let getEncodingType (fs: FileStream) = 
        task {
            let bytes = Array.zeroCreate<byte> 4
            let! bytesRead = fs.ReadAsync(bytes, 0, 4)
            if bytesRead < 2 then
                return EncodingType.None

            elif bytesRead >= 3 && bytes[0] = 0xEFuy && bytes[1] = 0xBBuy && bytes[2] = 0xBFuy then
                return EncodingType.Utf8
            else
                let value = BitConverter.ToUInt32(bytes, 0)
                if bytesRead = 4 && (value = 0x0000FEFFu || value = 0xFEFF0000u) then
                    return EncodingType.Utf32
                else
                    let value16 = BitConverter.ToUInt16(bytes, 0)
                    if value16 = 0xFEFFus || value16 = 0xFFFEus then
                        return EncodingType.Utf16
                    else
                        return EncodingType.Unknown
        }

let main _ = 
    task {
        let name = @".\TestFile.dat"
        let fs = new FileStream(name, FileMode.Create, FileAccess.Write)
        let! et = FileUtilities.getEncodingType fs
        printfn $"Filename: {name}, Encoding: {et}"
    }

// The example displays the following output:
//    Unhandled Exception: System.NotSupportedException: Stream does not support reading.
//       at System.IO.FileStream.BeginRead(Byte[] array, Int32 offset, Int32 numBytes, AsyncCallback callback, Object state)
//       at System.IO.Stream.<>c.<BeginEndReadAsync>b__46_0(Stream stream, ReadWriteParameters args, AsyncCallback callback, Object state)
//       at System.Threading.Tasks.TaskFactory`1.FromAsyncTrim[TInstance, TArgs](TInstance thisRef, TArgs args, Func`5 beginMethod, Func`3 endMethod)
//       at System.IO.Stream.BeginEndReadAsync(Byte[] buffer, Int32 offset, Int32 count)
//       at System.IO.FileStream.ReadAsync(Byte[] buffer, Int32 offset, Int32 count, CancellationToken cancellationToken)
//       at System.IO.Stream.ReadAsync(Byte[] buffer, Int32 offset, Int32 count)
//       at FileUtilities.GetEncodingType(FileStream fs)
//       at Example.Main()
//       at Example.<Main>()
// </Snippet3>