# .NET DeflateStream class
This repo contains the DeflateStream class with the latest changes from the CoreFx repo updated for .NET 4.5 framework:
- increased perfomance from the use of native zlib
- Task based APIs
- Flush operation

## Build & Test Status
[![Build status](https://ci.appveyor.com/api/projects/status/f0yq6a5tx52f6hfg?svg=true)](https://ci.appveyor.com/project/chelaris/asyncdeflate)

## Quickstart
### Install
```
PM> Install-Package AsyncDeflate -Pre
```

### Compression
```cs
Stream outputStream = ...;
byte[] buffer = ...;
using (var deflateStream = new AsyncDeflate.DeflateStream(outputStream, CompressionLevel.Optimal, true))
{
    await deflateStream.WriteAsync(buffer, 0, buffer.Length);
    await deflateStream.FlushAsync();
}
```
