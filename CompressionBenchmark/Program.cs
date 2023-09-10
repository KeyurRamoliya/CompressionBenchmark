using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace CompressionBenchmark;

// Specify the number of warmup and benchmark iterations
[SimpleJob(warmupCount: 3, iterationCount: 5)]

// Export the results to a markdown table
[MarkdownExporterAttribute.GitHub]
class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<BrotliBenchmark>();
        summary = BenchmarkRunner.Run<GzipBenchmark>();
        summary = BenchmarkRunner.Run<DeflateBenchmark>();

        Console.WriteLine("Done");
        Console.ReadLine();
    }
}