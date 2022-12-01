using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<LengthVsHashCode>();

/*
|                        Method |          Mean |     Error |    StdDev |
|------------------------------ |--------------:|----------:|----------:|
|                    Switch1New |    28.0032 ns | 0.1477 ns | 0.1309 ns |
|                    Switch1Old |    43.8506 ns | 0.2998 ns | 0.2805 ns |
|            NotALengthMatchNew |     0.4228 ns | 0.0023 ns | 0.0022 ns |
|            NotALengthMatchOld |     5.4909 ns | 0.0151 ns | 0.0134 ns |
|                      DenseNew |   960.5969 ns | 9.2361 ns | 8.6395 ns |
|                      DenseOld |   951.7943 ns | 6.4528 ns | 5.3884 ns |
|                   DenseFewNew |   165.1076 ns | 2.3569 ns | 2.2047 ns |
|                   DenseFewOld |   155.8870 ns | 2.0038 ns | 1.8743 ns |
|                     SparseNew | 1,482.9110 ns | 6.4001 ns | 5.9867 ns |
|                     SparseOld | 1,495.7279 ns | 4.0566 ns | 3.3874 ns |
|                ContentTypeNew |    13.5836 ns | 0.2536 ns | 0.2248 ns |
|                ContentTypeOld |    25.5421 ns | 0.1449 ns | 0.1284 ns |
|      ContentTypeAsListPattern |    17.3515 ns | 0.0695 ns | 0.0616 ns |
|                   CyrusSwitch |    17.9155 ns | 0.1048 ns | 0.0981 ns |
|                     CyrusTrie |   917.7107 ns | 2.9565 ns | 2.4688 ns |
| CyrusTrieWithoutOptimizations |   929.3835 ns | 3.9046 ns | 3.4613 ns |
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
    public int ContentTypeNew() => NewRoslyn.ContentType();
    [Benchmark]
    public int ContentTypeOld() => OldRoslyn.ContentType();
    [Benchmark]
    public int ContentTypeAsListPattern() => OldRoslyn.ContentTypeAsListPattern();

    [Benchmark]
    public int CyrusSwitch() => OldRoslyn.CyrusSwitch();
    [Benchmark]
    public int CyrusTrie() => OldRoslyn.CyrusTrie();
    [Benchmark]
    public int CyrusTrieWithoutOptimizations() => OldRoslyn.CyrusTrieWithoutOptimizations();
}
