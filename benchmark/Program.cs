using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<LengthVsHashCode>();

/*
|                   Method |          Mean |     Error |    StdDev |
|------------------------- |--------------:|----------:|----------:|
|               Switch1New |    27.6447 ns | 0.1740 ns | 0.1543 ns |
|               Switch1Old |    44.1037 ns | 0.2957 ns | 0.2766 ns |
|       NotALengthMatchNew |     0.4219 ns | 0.0064 ns | 0.0060 ns |
|       NotALengthMatchOld |     5.4925 ns | 0.0270 ns | 0.0253 ns |
|                 DenseNew |   945.3718 ns | 8.4476 ns | 7.9019 ns |
|                 DenseOld |   954.5867 ns | 8.7684 ns | 8.2020 ns |
|              DenseFewNew |   165.3166 ns | 3.2272 ns | 4.6283 ns |
|              DenseFewOld |   156.7531 ns | 1.8161 ns | 1.6988 ns |
|                SparseNew | 1,475.7378 ns | 4.6374 ns | 4.3378 ns |
|                SparseOld | 1,477.8633 ns | 6.1797 ns | 5.7805 ns |
|              ContentType |    13.2868 ns | 0.0501 ns | 0.0391 ns |
| ContentTypeAsListPattern |    17.2237 ns | 0.1384 ns | 0.1227 ns |
*/
public class LengthVsHashCode
{
    [Benchmark]
    public int Switch1New() => NewRoslyn.Switch1();
    [Benchmark]
    public int Switch1Old() => OldRoslyn.Switch1();

    [Benchmark]
    public int NotALengthMatchNew() => NewRoslyn.NotALengthMatch();
    [Benchmark]
    public int NotALengthMatchOld() => OldRoslyn.NotALengthMatch();

    [Benchmark]
    public int DenseNew() => NewRoslyn.Dense();
    [Benchmark]
    public int DenseOld() => OldRoslyn.Dense();

    [Benchmark]
    public int DenseFewNew() => NewRoslyn.DenseFew();
    [Benchmark]
    public int DenseFewOld() => OldRoslyn.DenseFew();

    [Benchmark]
    public int SparseNew() => NewRoslyn.Sparse();
    [Benchmark]
    public int SparseOld() => OldRoslyn.Sparse();

    [Benchmark]
    public int ContentType() => NewRoslyn.ContentType();
    [Benchmark]
    public int ContentTypeAsListPattern() => NewRoslyn.ContentTypeAsListPattern();
}
