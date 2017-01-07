using System.IO;
using System.IO.Compression;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Jobs;

namespace Benchmark
{
    [ClrJob]
    public class Compression
    {
        private static readonly byte[] HelloWorld = Encoding.UTF8.GetBytes("HELLO WORLD TEST STRING OF AVERAGE SIZE");
        private static readonly MemoryStream memoryStream = new MemoryStream(100 * 1024);

        [Benchmark]
        public static void LegecyDeflateShortString()
        {
            memoryStream.SetLength(0);
            using (var deflateStream = new DeflateStream(memoryStream, CompressionLevel.Optimal, true))
            {
                deflateStream.Write(HelloWorld, 0, HelloWorld.Length);
            }
        }

        [Benchmark]
        public static void AsyncDeflateShortString()
        {
            memoryStream.SetLength(0);
            using (var deflateStream = new AsyncDeflate.DeflateStream(memoryStream, CompressionLevel.Optimal, true))
            {
                deflateStream.Write(HelloWorld, 0, HelloWorld.Length);
                deflateStream.Flush();
            }
        }

        [Benchmark]
        public static void LegecyDeflateLongString()
        {
            memoryStream.SetLength(0);
            using (var deflateStream = new DeflateStream(memoryStream, CompressionLevel.Optimal, true))
            {
                deflateStream.Write(LongText.Text, 0, HelloWorld.Length);
            }
        }

        [Benchmark]
        public static void AsyncDeflateLongString()
        {
            memoryStream.SetLength(0);
            using (var deflateStream = new AsyncDeflate.DeflateStream(memoryStream, CompressionLevel.Optimal, true))
            {
                deflateStream.Write(LongText.Text, 0, HelloWorld.Length);
                deflateStream.Flush();
            }
        }
    }
}