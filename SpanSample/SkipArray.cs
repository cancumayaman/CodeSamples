using BenchmarkDotNet.Attributes;

namespace CodeSamples.SpanSample.SkipArray;

[MemoryDiagnoser]
public class SkipArray
{
    private int[] _myArray;

    [Params(100, 1000, 10000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void SetUp()
    {
        _myArray = new int[Size];
        for (int index = 0; index < Size; index++)
        {
            _myArray[index] = index;
        }
    }
    [Benchmark(Baseline = true)]
    public int[] Original()
    {
        return _myArray.Skip(Size / 2).Take(Size / 4).ToArray();
    }

    [Benchmark]
    public int[] ArrayCopy()
    {
        var copy = new int[Size / 4];
        Array.Copy(_myArray, Size / 2, copy, 0, Size / 4);
        return copy;
    }

    [Benchmark]
    public Span<int> Span()
    {
        return _myArray.AsSpan().Slice(Size / 2, Size / 4);
    }
}
