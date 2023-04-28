
using BenchmarkDotNet.Attributes;
namespace CodeSamples.SpanSamples.StringProcessing;

[MemoryDiagnoser]
public class StringProcessing
{
    public static readonly string originalString = "Hello, World!";
    public static readonly int[] numberList = new int[] { 1, 2, 3, 4 };
    [Benchmark]
    public void ExtractString()
    {
        string subString = originalString.Substring(7, 5);
        Console.WriteLine(subString);
    }
    [Benchmark]
    public void ExtractStringWithReadOnlySpan()
    {
        ReadOnlySpan<char> subString = originalString.AsSpan();
        for (int i = 0; i < subString.Length; i++)
        {
            Console.WriteLine(subString[i]);
        }
    }
    [Benchmark]
    public void ExtractStringWithReadOnlyMemory()
    {
        ReadOnlyMemory<char> subString = originalString.AsMemory();
        for (int i = 0; i < subString.Length; i++)
        {
            Console.WriteLine(subString.Span[i]);
        }
    }
    [Benchmark]
    public void ExtractNumbers()
    {
        foreach (int number in numberList)
        {
            Console.WriteLine(number);
        }
    }
    [Benchmark]
    public void ExtractNumbersWithSpan()
    {
        Span<int> numbers = numberList.AsSpan();
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
    [Benchmark]
    public void ExtractNumbersWithMemory()
    {
        Memory<int> numbers = numberList.AsMemory();
        foreach (int number in numbers.Span)
        {
            Console.WriteLine(number);
        }
    }
}