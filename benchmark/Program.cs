using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<LengthVsHashCode>();

/*
|             Method |          Mean |     Error |    StdDev |
|------------------- |--------------:|----------:|----------:|
|         Switch1New |    27.6114 ns | 0.1031 ns | 0.0964 ns |
|         Switch1Old |    45.8353 ns | 0.4962 ns | 0.4399 ns |
| NotALengthMatchNew |     0.4517 ns | 0.0071 ns | 0.0066 ns |
| NotALengthMatchOld |     5.4676 ns | 0.0139 ns | 0.0130 ns |
|           DenseNew |   943.7901 ns | 5.6309 ns | 4.9917 ns |
|           DenseOld |   955.1933 ns | 7.8330 ns | 7.3270 ns |
|        DenseFewNew |   163.6348 ns | 3.1624 ns | 3.1059 ns |
|        DenseFewOld |   150.8369 ns | 2.3141 ns | 2.1646 ns |
|          SparseNew | 1,477.3057 ns | 6.3452 ns | 5.9353 ns |
|          SparseOld | 1,473.9233 ns | 4.5532 ns | 4.0363 ns |
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
}
