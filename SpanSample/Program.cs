using BenchmarkDotNet.Running;
using CodeSamples.SpanSample.SkipArray;
using CodeSamples.SpanSamples.StringProcessing;

BenchmarkRunner.Run<StringProcessing>();
BenchmarkRunner.Run<SkipArray>();
