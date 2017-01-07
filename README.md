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
## Benchmark summary
[Benchmark sources](blob/master/Test/Benchmark/Compression.cs)

```
BenchmarkDotNet=v0.10.1, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6700HQ CPU 2.60GHz, ProcessorCount=8
Frequency=2531251 Hz, Resolution=395.0616 ns, Timer=TSC
  [Host] : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1586.0
  Clr    : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1586.0

Job=Clr  Runtime=Clr

                   Method |       Mean |    StdDev |  Gen 0 | Allocated |
------------------------- |----------- |---------- |------- |---------- |
 Net4DeflateShortString   | 12.8679 us | 0.1262 us | 2.4597 |   8.79 kB |
  AsyncDeflateShortString | 10.4021 us | 0.0748 us | 2.3275 |   8.48 kB |
 Net4DeflateLongString    | 13.2276 us | 0.1628 us | 2.1118 |   8.79 kB |
  AsyncDeflateLongString  | 11.1165 us | 0.0864 us | 2.3600 |   8.48 kB |
```
