using BenchmarkDotNet.Attributes;
using System.IO.Compression;

namespace CompressionBenchmark
{
    // Enable memory allocation diagnostics
    [MemoryDiagnoser]
    public class DeflateBenchmark
    {
        // Specify the compression level parameter for Deflate compression
        [Params(CompressionLevel.Optimal, CompressionLevel.Fastest, CompressionLevel.NoCompression, CompressionLevel.SmallestSize)]
        public CompressionLevel CompressionLevel { get; set; }

        // Define some sample data to compress
        private byte[] data = System.Text.Encoding.UTF8.GetBytes("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed quis lorem vitae nisi consequat varius. Morbi id leo quis augue aliquet lacinia. Fusce vitae semper nisl. Mauris quis leo sit amet lacus tincidunt sagittis. Vivamus euismod, nisi quis condimentum ultrices, nunc eros malesuada leo, at tincidunt lectus urna sed leo. Quisque nec sapien ut nisl vulputate ullamcorper. Sed id semper diam. Donec eget justo et justo aliquam sollicitudin. Suspendisse potenti. Curabitur sit amet lorem ac erat sagittis consequat.");

        // Define a stream for Deflate compression
        private MemoryStream compressedStream;

        // Initialize the Deflate compression stream
        [GlobalSetup]
        public void Setup()
        {
            compressedStream = new MemoryStream();
        }

        // Measure the performance of Deflate compression on the sample data
        [Benchmark]
        public void Compress()
        {
            compressedStream.Position = 0;
            var deflateStream = new DeflateStream(compressedStream, CompressionLevel, true);
            deflateStream.Write(data, 0, data.Length);
            deflateStream.Flush();
        }

        // Dispose the Deflate compression stream
        [GlobalCleanup]
        public void Cleanup()
        {
            compressedStream.Dispose();
        }
    }
}

