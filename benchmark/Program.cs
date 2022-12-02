using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<LengthVsHashCode>();

/*
|                        Method |          Mean |      Error |     StdDev |
|------------------------------ |--------------:|-----------:|-----------:|
|                    Switch1New |    27.5369 ns |  0.2459 ns |  0.2180 ns |
|                    Switch1Old |    49.2474 ns |  0.6492 ns |  0.5422 ns |
|            NotALengthMatchNew |     0.4575 ns |  0.0057 ns |  0.0051 ns |
|            NotALengthMatchOld |     5.4837 ns |  0.0126 ns |  0.0105 ns |
|                      DenseNew |   967.0538 ns | 13.1026 ns | 12.2562 ns |
|                      DenseOld |   957.8737 ns | 11.8835 ns | 11.1158 ns |
|                   DenseFewNew |   160.1468 ns |  3.1985 ns |  4.6884 ns |
|                   DenseFewOld |   150.5322 ns |  0.9715 ns |  0.8612 ns |
|                     SparseNew | 1,493.6215 ns |  5.3962 ns |  5.0476 ns |
|                     SparseOld | 1,485.7408 ns |  6.2772 ns |  5.5646 ns |
|                ContentTypeNew |    13.9853 ns |  0.2892 ns |  0.2841 ns |
|                ContentTypeOld |    26.4736 ns |  0.5511 ns |  0.5155 ns |
|      ContentTypeAsListPattern |    17.4763 ns |  0.2054 ns |  0.1821 ns |
|                   CyrusSwitch |    18.1227 ns |  0.1852 ns |  0.1546 ns |
|                     CyrusTrie |   936.4015 ns | 14.5780 ns | 13.6363 ns |
| CyrusTrieWithoutOptimizations |   932.6640 ns |  5.2049 ns |  4.8686 ns |
|           ShortSwitch_FirstCase_New | 1.4805 ns | 0.0038 ns | 0.0032 ns |
|           ShortSwitch_FirstCase_Old | 0.8435 ns | 0.0035 ns | 0.0033 ns |
|          ShortSwitch_SecondCase_New | 1.0636 ns | 0.0053 ns | 0.0042 ns |
|          ShortSwitch_SecondCase_Old | 0.6337 ns | 0.0024 ns | 0.0020 ns |
|           ShortSwitch_ThirdCase_New | 1.3864 ns | 0.0117 ns | 0.0104 ns |
|           ShortSwitch_ThirdCase_Old | 1.2695 ns | 0.0058 ns | 0.0055 ns |
|          ShortSwitch_FourthCase_New | 1.2811 ns | 0.0130 ns | 0.0122 ns |
|          ShortSwitch_FourthCase_Old | 1.4670 ns | 0.0068 ns | 0.0063 ns |
|  ShortSwitchLongWords_FirstCase_New | 1.4200 ns | 0.0035 ns | 0.0031 ns |
|  ShortSwitchLongWords_FirstCase_Old | 0.8674 ns | 0.0094 ns | 0.0084 ns |
| ShortSwitchLongWords_SecondCase_New | 1.6516 ns | 0.0093 ns | 0.0087 ns |
| ShortSwitchLongWords_SecondCase_Old | 1.0659 ns | 0.0084 ns | 0.0079 ns |
|  ShortSwitchLongWords_ThirdCase_New | 1.6673 ns | 0.0117 ns | 0.0103 ns |
|  ShortSwitchLongWords_ThirdCase_Old | 1.3307 ns | 0.0110 ns | 0.0098 ns |
| ShortSwitchLongWords_FourthCase_New | 1.4205 ns | 0.0037 ns | 0.0029 ns |
| ShortSwitchLongWords_FourthCase_Old | 1.4777 ns | 0.0090 ns | 0.0084 ns |
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

    [Benchmark]
    public int ShortSwitch_FirstCase_New() => NewRoslyn.ShortSwitch_FirstCase();
    [Benchmark]
    public int ShortSwitch_FirstCase_Old() => OldRoslyn.ShortSwitch_FirstCase();

    [Benchmark]
    public int ShortSwitch_SecondCase_New() => NewRoslyn.ShortSwitch_SecondCase();
    [Benchmark]
    public int ShortSwitch_SecondCase_Old() => OldRoslyn.ShortSwitch_SecondCase();

    [Benchmark]
    public int ShortSwitch_ThirdCase_New() => NewRoslyn.ShortSwitch_ThirdCase();
    [Benchmark]
    public int ShortSwitch_ThirdCase_Old() => OldRoslyn.ShortSwitch_ThirdCase();

    [Benchmark]
    public int ShortSwitch_FourthCase_New() => NewRoslyn.ShortSwitch_FourthCase();
    [Benchmark]
    public int ShortSwitch_FourthCase_Old() => OldRoslyn.ShortSwitch_FourthCase();

    [Benchmark]
    public int ShortSwitchLongWords_FirstCase_New() => NewRoslyn.ShortSwitchLongWords_FirstCase();
    [Benchmark]
    public int ShortSwitchLongWords_FirstCase_Old() => OldRoslyn.ShortSwitchLongWords_FirstCase();

    [Benchmark]
    public int ShortSwitchLongWords_SecondCase_New() => NewRoslyn.ShortSwitchLongWords_SecondCase();
    [Benchmark]
    public int ShortSwitchLongWords_SecondCase_Old() => OldRoslyn.ShortSwitchLongWords_SecondCase();

    [Benchmark]
    public int ShortSwitchLongWords_ThirdCase_New() => NewRoslyn.ShortSwitchLongWords_ThirdCase();
    [Benchmark]
    public int ShortSwitchLongWords_ThirdCase_Old() => OldRoslyn.ShortSwitchLongWords_ThirdCase();

    [Benchmark]
    public int ShortSwitchLongWords_FourthCase_New() => NewRoslyn.ShortSwitchLongWords_FourthCase();
    [Benchmark]
    public int ShortSwitchLongWords_FourthCase_Old() => OldRoslyn.ShortSwitchLongWords_FourthCase();
}
