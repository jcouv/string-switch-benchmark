#nullable disable

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

//_ = BenchmarkRunner.Run<LengthVsHashCode>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_Switch1>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_NotALengthMatch>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_CyrusSwitch>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_ShortSwitch>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_DenseWithTwoCandidatesPerBucket>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_DenseWithThreeCandidatesPerBucket>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_SparseLongWithThreeCandidatesPerBucket>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_SparseLongWithThreeCandidatesPerBucket_Mix>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_DenseWithFourCandidatesPerBucket>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_SparseLongWithFourCandidatesPerBucket>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_SparseWithFiveCandidatesPerBucket>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_SparseWithSixCandidatesPerBucket>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_SparseWithSevenCandidatesPerBucket>();
_ = BenchmarkRunner.Run<LengthVsHashCode_GetContents>();
_ = BenchmarkRunner.Run<LengthVsHashCode_GetContents_Mix>();
_ = BenchmarkRunner.Run<LengthVsHashCode_TryParseStatusFile>();
_ = BenchmarkRunner.Run<LengthVsHashCode_TryParseStatusFile_Mix>();
_ = BenchmarkRunner.Run<LengthVsHashCode_GetHashForChannelBinding>();
_ = BenchmarkRunner.Run<LengthVsHashCode_GetHashForChannelBinding_Mix>();

public partial class LengthVsHashCode_Switch1
{
    /*
    |  Switch1New | 29.54 ns | 0.609 ns | 0.626 ns |
    | Switch1Trie | 29.03 ns | 0.600 ns | 0.736 ns |
    |  Switch1Old | 45.58 ns | 0.442 ns | 0.392 ns |
     */
    [Benchmark]
    public int Switch1New() => NewRoslyn.Switch1();
    [Benchmark]
    public int Switch1Trie() => TrieRoslyn.Switch1();
    [Benchmark]
    public int Switch1Old() => OldRoslyn.Switch1();
}
public partial class LengthVsHashCode_NotALengthMatch
{
    /*
    |  NotALengthMatchNew | 0.4191 ns | 0.0083 ns | 0.0078 ns |
    | NotALengthMatchTrie | 0.4311 ns | 0.0061 ns | 0.0054 ns |
    |  NotALengthMatchOld | 5.5596 ns | 0.0369 ns | 0.0327 ns |
    */
    [Benchmark]
    public int NotALengthMatchNew() => NewRoslyn.NotALengthMatch();
    [Benchmark]
    public int NotALengthMatchTrie() => TrieRoslyn.NotALengthMatch();
    [Benchmark]
    public int NotALengthMatchOld() => OldRoslyn.NotALengthMatch();
}
public partial class LengthVsHashCode
{
    [Benchmark]
    public int DenseNew() => NewRoslyn.Dense();
    [Benchmark]
    public int DenseTrie() => TrieRoslyn.Dense();
    [Benchmark]
    public int DenseOld() => OldRoslyn.Dense();

    [Benchmark]
    public int DenseFew_Match_New() => NewRoslyn.DenseFew_Match();
    [Benchmark]
    public int DenseFew_Match_Old() => OldRoslyn.DenseFew_Match();

    [Benchmark]
    public int DenseFew_DoesNotMatch_New() => NewRoslyn.DenseFew_DoesNotMatch();
    [Benchmark]
    public int DenseFew_DoesNotMatch_Old() => OldRoslyn.DenseFew_DoesNotMatch();

    [Benchmark]
    public int SparseFew_Match_New() => NewRoslyn.SparseFew_Match();
    [Benchmark]
    public int SparseFew_Match_Old() => OldRoslyn.SparseFew_Match();

    [Benchmark]
    public int SparseFew_DoesNotMatch_New() => NewRoslyn.SparseFew_DoesNotMatch();
    [Benchmark]
    public int SparseFew_DoesNotMatch_Old() => OldRoslyn.SparseFew_DoesNotMatch();

    [Benchmark]
    public int ContentTypeNew() => NewRoslyn.ContentType();
    [Benchmark]
    public int ContentTypeOld() => OldRoslyn.ContentType();
    [Benchmark]
    public int ContentTypeAsListPattern() => OldRoslyn.ContentTypeAsListPattern();
}
public class LengthVsHashCode_CyrusSwitch
{
    /*
    |  CyrusSwitchNew | hello | 12.659 ns | 0.2749 ns | 0.3055 ns |
    | CyrusSwitchTrie | hello |  8.551 ns | 0.1915 ns | 0.1967 ns |
    |  CyrusSwitchOld | hello |  5.319 ns | 0.0298 ns | 0.0265 ns |
    |  CyrusSwitchNew | world |  8.472 ns | 0.0456 ns | 0.0404 ns |
    | CyrusSwitchTrie | world | 11.098 ns | 0.0813 ns | 0.0720 ns |
    |  CyrusSwitchOld | world |  5.841 ns | 0.0169 ns | 0.0150 ns |
    */
    [Params("hello", "world")]
    public string Value { get; set; }
    [Benchmark]
    public int CyrusSwitchNew() => NewRoslyn.CyrusSwitch(Value);
    [Benchmark]
    public int CyrusSwitchTrie() => TrieRoslyn.CyrusSwitch(Value);
    [Benchmark]
    public int CyrusSwitchOld() => OldRoslyn.CyrusSwitch(Value);
    //[Benchmark]
    //public int CyrusTrie() => OldRoslyn.CyrusTrie();
    //[Benchmark]
    //public int CyrusTrieWithoutOptimizations() => OldRoslyn.CyrusTrieWithoutOptimizations();
}
public class LengthVsHashCode_ShortSwitch
{
    /*
    |           Method |  Value |      Mean |     Error |    StdDev |    Median |
    |----------------- |------- |----------:|----------:|----------:|----------:|
    |  ShortSwitch_New | DELETE | 1.1680 ns | 0.0461 ns | 0.0900 ns | 1.0987 ns |
    | ShortSwitch_Trie | DELETE | 1.4300 ns | 0.0510 ns | 0.1141 ns | 1.4374 ns |
    |  ShortSwitch_Old | DELETE | 1.4893 ns | 0.0105 ns | 0.0088 ns | 1.4919 ns |
    |  ShortSwitch_New |    GET | 1.3162 ns | 0.0249 ns | 0.0233 ns | 1.3073 ns |
    | ShortSwitch_Trie |    GET | 1.4884 ns | 0.0344 ns | 0.0321 ns | 1.4992 ns |
    |  ShortSwitch_Old |    GET | 0.6469 ns | 0.0042 ns | 0.0037 ns | 0.6479 ns |
    |  ShortSwitch_New |   POST | 0.9529 ns | 0.0417 ns | 0.1069 ns | 0.8806 ns |
    | ShortSwitch_Trie |   POST | 1.2870 ns | 0.0487 ns | 0.1366 ns | 1.2996 ns |
    |  ShortSwitch_Old |   POST | 0.5027 ns | 0.0357 ns | 0.0334 ns | 0.4897 ns |
    |  ShortSwitch_New |    PUT | 1.3078 ns | 0.0096 ns | 0.0085 ns | 1.3059 ns |
    | ShortSwitch_Trie |    PUT | 1.4436 ns | 0.0130 ns | 0.0122 ns | 1.4411 ns |
    |  ShortSwitch_Old |    PUT | 1.2810 ns | 0.0092 ns | 0.0072 ns | 1.2838 ns |
    */
    [Params("GET", "POST", "PUT", "DELETE")]
    public string Value { get; set; }

    [Benchmark]
    public int ShortSwitch_New() => NewRoslyn.ShortSwitchCore(Value);
    [Benchmark]
    public int ShortSwitch_Trie() => TrieRoslyn.ShortSwitchCore(Value);
    [Benchmark]
    public int ShortSwitch_Old() => OldRoslyn.ShortSwitchCore(Value);
}
public partial class LengthVsHashCode
{
    [Benchmark]
    public DriveType GetDriveType_Mix_New() => NewRoslyn.GetDriveType_Mix();
    [Benchmark]
    public DriveType GetDriveType_Mix_Trie() => TrieRoslyn.GetDriveType_Mix();
    [Benchmark]
    public DriveType GetDriveType_Mix_Old() => OldRoslyn.GetDriveType_Mix();
}
public partial class LengthVsHashCode_DenseWithTwoCandidatesPerBucket
{
    /*
    |                               Method | Value |     Mean |     Error |    StdDev |   Median |
    |------------------------------------- |------ |---------:|----------:|----------:|---------:|
    |  DenseWithTwoCandidatesPerBucket_New |   aba | 1.253 ns | 0.0475 ns | 0.1090 ns | 1.311 ns |
    | DenseWithTwoCandidatesPerBucket_Trie |   aba | 1.614 ns | 0.0138 ns | 0.0130 ns | 1.612 ns |
    |  DenseWithTwoCandidatesPerBucket_Old |   aba | 2.531 ns | 0.0071 ns | 0.0063 ns | 2.532 ns |
    |  DenseWithTwoCandidatesPerBucket_New |   abb | 1.312 ns | 0.0184 ns | 0.0172 ns | 1.309 ns |
    | DenseWithTwoCandidatesPerBucket_Trie |   abb | 1.429 ns | 0.0157 ns | 0.0147 ns | 1.426 ns |
    |  DenseWithTwoCandidatesPerBucket_Old |   abb | 2.521 ns | 0.0124 ns | 0.0116 ns | 2.517 ns |
    |  DenseWithTwoCandidatesPerBucket_New |   baa | 1.408 ns | 0.0240 ns | 0.0224 ns | 1.414 ns |
    | DenseWithTwoCandidatesPerBucket_Trie |   baa | 1.324 ns | 0.0199 ns | 0.0186 ns | 1.317 ns |
    |  DenseWithTwoCandidatesPerBucket_Old |   baa | 2.697 ns | 0.0073 ns | 0.0065 ns | 2.696 ns |
    |  DenseWithTwoCandidatesPerBucket_New |   bab | 1.289 ns | 0.0069 ns | 0.0061 ns | 1.287 ns |
    | DenseWithTwoCandidatesPerBucket_Trie |   bab | 1.279 ns | 0.0187 ns | 0.0156 ns | 1.285 ns |
    |  DenseWithTwoCandidatesPerBucket_Old |   bab | 2.584 ns | 0.0184 ns | 0.0172 ns | 2.584 ns |
    |  DenseWithTwoCandidatesPerBucket_New |   cdc | 1.237 ns | 0.0295 ns | 0.0276 ns | 1.242 ns |
    | DenseWithTwoCandidatesPerBucket_Trie |   cdc | 1.297 ns | 0.0116 ns | 0.0108 ns | 1.298 ns |
    |  DenseWithTwoCandidatesPerBucket_Old |   cdc | 2.927 ns | 0.0114 ns | 0.0101 ns | 2.928 ns |
    |  DenseWithTwoCandidatesPerBucket_New |   cdd | 1.248 ns | 0.0089 ns | 0.0079 ns | 1.247 ns |
    | DenseWithTwoCandidatesPerBucket_Trie |   cdd | 1.280 ns | 0.0119 ns | 0.0106 ns | 1.278 ns |
    |  DenseWithTwoCandidatesPerBucket_Old |   cdd | 2.910 ns | 0.0110 ns | 0.0098 ns | 2.909 ns |
    |  DenseWithTwoCandidatesPerBucket_New |   dcc | 1.393 ns | 0.0182 ns | 0.0170 ns | 1.395 ns |
    | DenseWithTwoCandidatesPerBucket_Trie |   dcc | 1.289 ns | 0.0111 ns | 0.0104 ns | 1.289 ns |
    |  DenseWithTwoCandidatesPerBucket_Old |   dcc | 2.703 ns | 0.0043 ns | 0.0033 ns | 2.704 ns |
    |  DenseWithTwoCandidatesPerBucket_New |   dcd | 1.276 ns | 0.0055 ns | 0.0049 ns | 1.276 ns |
    | DenseWithTwoCandidatesPerBucket_Trie |   dcd | 1.278 ns | 0.0028 ns | 0.0023 ns | 1.279 ns |
    |  DenseWithTwoCandidatesPerBucket_Old |   dcd | 2.824 ns | 0.0082 ns | 0.0069 ns | 2.824 ns |
    |  DenseWithTwoCandidatesPerBucket_New |   efe | 1.373 ns | 0.0417 ns | 0.0370 ns | 1.364 ns |
    | DenseWithTwoCandidatesPerBucket_Trie |   efe | 1.290 ns | 0.0106 ns | 0.0088 ns | 1.294 ns |
    |  DenseWithTwoCandidatesPerBucket_Old |   efe | 2.711 ns | 0.0089 ns | 0.0070 ns | 2.712 ns |
    |  DenseWithTwoCandidatesPerBucket_New |   eff | 1.236 ns | 0.0072 ns | 0.0067 ns | 1.235 ns |
    | DenseWithTwoCandidatesPerBucket_Trie |   eff | 1.271 ns | 0.0213 ns | 0.0199 ns | 1.268 ns |
    |  DenseWithTwoCandidatesPerBucket_Old |   eff | 2.717 ns | 0.0091 ns | 0.0076 ns | 2.715 ns |
    |  DenseWithTwoCandidatesPerBucket_New |   fee | 1.227 ns | 0.0333 ns | 0.0312 ns | 1.231 ns |
    | DenseWithTwoCandidatesPerBucket_Trie |   fee | 1.105 ns | 0.0180 ns | 0.0159 ns | 1.106 ns |
    |  DenseWithTwoCandidatesPerBucket_Old |   fee | 2.511 ns | 0.0063 ns | 0.0053 ns | 2.510 ns |
    |  DenseWithTwoCandidatesPerBucket_New |   fef | 1.047 ns | 0.0209 ns | 0.0196 ns | 1.046 ns |
    | DenseWithTwoCandidatesPerBucket_Trie |   fef | 1.273 ns | 0.0163 ns | 0.0136 ns | 1.275 ns |
    |  DenseWithTwoCandidatesPerBucket_Old |   fef | 2.354 ns | 0.0171 ns | 0.0160 ns | 2.348 ns |
    */
    [Params("aba", "abb", "baa", "bab", "cdc", "cdd", "dcc", "dcd", "efe", "eff", "fee", "fef")]
    public string Value { get; set; }

    [Benchmark]
    public int DenseWithTwoCandidatesPerBucket_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket(Value);
    [Benchmark]
    public int DenseWithTwoCandidatesPerBucket_Trie() => TrieRoslyn.DenseWithTwoCandidatesPerBucket(Value);
    [Benchmark]
    public int DenseWithTwoCandidatesPerBucket_Old() => OldRoslyn.DenseWithTwoCandidatesPerBucket(Value);
}
public class LengthVsHashCode_DenseWithThreeCandidatesPerBucket
{
    [Params("aac", "aba", "acb", "bac", "bba", "bcb", "cac", "cba", "ccb")]
    public string Value { get; set; }

    [Benchmark]
    public int DenseWithThreeCandidatesPerBucket_New() => NewRoslyn.DenseWithThreeCandidatesPerBucket(Value);
    [Benchmark]
    public int DenseWithThreeCandidatesPerBucket_Trie() => TrieRoslyn.DenseWithThreeCandidatesPerBucket(Value);
    [Benchmark]
    public int DenseWithThreeCandidatesPerBucket_Old() => OldRoslyn.DenseWithThreeCandidatesPerBucket(Value);
}
public class LengthVsHashCode_SparseLongWithThreeCandidatesPerBucket
{
    [Params("xxxxx-xxxxx-xxxxx-xxxxx-aaq", "xxxxx-xxxxx-xxxxx-xxxxx-aia", "xxxxx-xxxxx-xxxxx-xxxxx-aqi", "xxxxx-xxxxx-xxxxx-xxxxx-iaq",
        "xxxxx-xxxxx-xxxxx-xxxxx-iia", "xxxxx-xxxxx-xxxxx-xxxxx-iqi", "xxxxx-xxxxx-xxxxx-xxxxx-qaq", "xxxxx-xxxxx-xxxxx-xxxxx-qia", "xxxxx-xxxxx-xxxxx-xxxxx-qqi")]
    public string Value { get; set; }

    [Benchmark]
    public int SparseLongWithThreeCandidatesPerBucket_New() => NewRoslyn.SparseLongWithThreeCandidatesPerBucket(Value);
    [Benchmark]
    public int SparseLongWithThreeCandidatesPerBucket_Trie() => TrieRoslyn.SparseLongWithThreeCandidatesPerBucket(Value);
    [Benchmark]
    public int SparseLongWithThreeCandidatesPerBucket_Old() => OldRoslyn.SparseLongWithThreeCandidatesPerBucket(Value);
}
public partial class LengthVsHashCode_SparseLongWithThreeCandidatesPerBucket_Mix
{
    /*
    |                                          Method |      Mean |    Error |   StdDev |
    |------------------------------------------------ |----------:|---------:|---------:|
    |  SparseLongWithThreeCandidatesPerBucket_Mix_New | 154.76 ns | 0.634 ns | 0.562 ns |
    | SparseLongWithThreeCandidatesPerBucket_Mix_Trie |  96.47 ns | 1.415 ns | 1.254 ns |
    |  SparseLongWithThreeCandidatesPerBucket_Mix_Old | 154.52 ns | 0.994 ns | 0.930 ns |
    */
    [Benchmark]
    public int SparseLongWithThreeCandidatesPerBucket_Mix_New() => NewRoslyn.SparseLongWithThreeCandidatesPerBucket_Mix();
    [Benchmark]
    public int SparseLongWithThreeCandidatesPerBucket_Mix_Trie() => TrieRoslyn.SparseLongWithThreeCandidatesPerBucket_Mix();
    [Benchmark]
    public int SparseLongWithThreeCandidatesPerBucket_Mix_Old() => OldRoslyn.SparseLongWithThreeCandidatesPerBucket_Mix();
}
public class LengthVsHashCode_DenseWithFourCandidatesPerBucket
{
    /*
    |  DenseWithFourCandidatesPerBucket_New |   aad | 1.1145 ns | 0.0356 ns | 0.0333 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   aad | 1.5374 ns | 0.0366 ns | 0.0342 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   aad | 3.0134 ns | 0.0791 ns | 0.0813 ns |
    |  DenseWithFourCandidatesPerBucket_New |   aba | 1.5124 ns | 0.0517 ns | 0.0878 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   aba | 1.5045 ns | 0.0309 ns | 0.0274 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   aba | 2.7090 ns | 0.0178 ns | 0.0158 ns |
    |  DenseWithFourCandidatesPerBucket_New |   acb | 1.6819 ns | 0.0114 ns | 0.0095 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   acb | 1.5575 ns | 0.0528 ns | 0.0687 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   acb | 2.8004 ns | 0.0205 ns | 0.0160 ns |
    |  DenseWithFourCandidatesPerBucket_New |   adc | 2.2588 ns | 0.0148 ns | 0.0138 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   adc | 1.4614 ns | 0.0170 ns | 0.0159 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   adc | 2.6959 ns | 0.0235 ns | 0.0220 ns |
    |  DenseWithFourCandidatesPerBucket_New |   bad | 1.0663 ns | 0.0112 ns | 0.0105 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   bad | 1.2824 ns | 0.0035 ns | 0.0028 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   bad | 3.0595 ns | 0.0229 ns | 0.0203 ns |
    |  DenseWithFourCandidatesPerBucket_New |   bba | 1.2312 ns | 0.0058 ns | 0.0052 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   bba | 1.2839 ns | 0.0058 ns | 0.0051 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   bba | 2.8541 ns | 0.0238 ns | 0.0222 ns |
    |  DenseWithFourCandidatesPerBucket_New |   bcb | 1.6744 ns | 0.0071 ns | 0.0059 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   bcb | 1.2808 ns | 0.0032 ns | 0.0025 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   bcb | 2.8868 ns | 0.0482 ns | 0.0451 ns |
    |  DenseWithFourCandidatesPerBucket_New |   bdc | 2.2373 ns | 0.0102 ns | 0.0090 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   bdc | 1.2842 ns | 0.0043 ns | 0.0038 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   bdc | 2.6431 ns | 0.0275 ns | 0.0243 ns |
    |  DenseWithFourCandidatesPerBucket_New |   cad | 0.8678 ns | 0.0085 ns | 0.0079 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   cad | 1.2899 ns | 0.0061 ns | 0.0051 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   cad | 2.9276 ns | 0.0311 ns | 0.0291 ns |
    |  DenseWithFourCandidatesPerBucket_New |   cba | 1.2316 ns | 0.0098 ns | 0.0087 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   cba | 1.3027 ns | 0.0181 ns | 0.0160 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   cba | 2.5510 ns | 0.0354 ns | 0.0332 ns |
    |  DenseWithFourCandidatesPerBucket_New |   ccb | 1.6833 ns | 0.0159 ns | 0.0149 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   ccb | 1.2461 ns | 0.0114 ns | 0.0107 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   ccb | 2.8604 ns | 0.0293 ns | 0.0274 ns |
    |  DenseWithFourCandidatesPerBucket_New |   cdc | 2.2526 ns | 0.0086 ns | 0.0080 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   cdc | 1.4357 ns | 0.0071 ns | 0.0063 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   cdc | 2.8622 ns | 0.0156 ns | 0.0146 ns |
    |  DenseWithFourCandidatesPerBucket_New |   dad | 1.0627 ns | 0.0062 ns | 0.0058 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   dad | 1.2490 ns | 0.0078 ns | 0.0069 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   dad | 2.7282 ns | 0.0184 ns | 0.0153 ns |
    |  DenseWithFourCandidatesPerBucket_New |   dba | 1.2401 ns | 0.0130 ns | 0.0122 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   dba | 1.2432 ns | 0.0055 ns | 0.0051 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   dba | 2.6736 ns | 0.0056 ns | 0.0044 ns |
    |  DenseWithFourCandidatesPerBucket_New |   dcb | 1.6828 ns | 0.0119 ns | 0.0111 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   dcb | 1.2510 ns | 0.0176 ns | 0.0138 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   dcb | 2.8753 ns | 0.0315 ns | 0.0279 ns |
    |  DenseWithFourCandidatesPerBucket_New |   ddc | 1.9443 ns | 0.0078 ns | 0.0065 ns |
    | DenseWithFourCandidatesPerBucket_Trie |   ddc | 1.2422 ns | 0.0092 ns | 0.0086 ns |
    |  DenseWithFourCandidatesPerBucket_Old |   ddc | 2.7242 ns | 0.0209 ns | 0.0174 ns |
    */
    [Params("aad", "aba", "acb", "adc", "bad", "bba", "bcb", "bdc", "cad", "cba", "ccb", "cdc", "dad", "dba", "dcb", "ddc")]
    public string Value { get; set; }

    [Benchmark]
    public int DenseWithFourCandidatesPerBucket_New() => NewRoslyn.DenseWithFourCandidatesPerBucket(Value);
    [Benchmark]
    public int DenseWithFourCandidatesPerBucket_Trie() => TrieRoslyn.DenseWithFourCandidatesPerBucket(Value);
    [Benchmark]
    public int DenseWithFourCandidatesPerBucket_Old() => OldRoslyn.DenseWithFourCandidatesPerBucket(Value);
}
public partial class LengthVsHashCode_SparseLongWithFourCandidatesPerBucket
{
    [Params("xxxxx-xxxxx-xxxxx-xxxxx-aay", "xxxxx-xxxxx-xxxxx-xxxxx-aia", "xxxxx-xxxxx-xxxxx-xxxxx-aqi", "xxxxx-xxxxx-xxxxx-xxxxx-ayq",
            "xxxxx-xxxxx-xxxxx-xxxxx-iay", "xxxxx-xxxxx-xxxxx-xxxxx-iia", "xxxxx-xxxxx-xxxxx-xxxxx-iqi", "xxxxx-xxxxx-xxxxx-xxxxx-iyq",
            "xxxxx-xxxxx-xxxxx-xxxxx-qay", "xxxxx-xxxxx-xxxxx-xxxxx-qia", "xxxxx-xxxxx-xxxxx-xxxxx-qqi", "xxxxx-xxxxx-xxxxx-xxxxx-qyq",
            "xxxxx-xxxxx-xxxxx-xxxxx-yay", "xxxxx-xxxxx-xxxxx-xxxxx-yia", "xxxxx-xxxxx-xxxxx-xxxxx-yqi", "xxxxx-xxxxx-xxxxx-xxxxx-yyq")]
    public string Value { get; set; }

    [Benchmark]
    public int SparseLongWithFourCandidatesPerBucket_New() => NewRoslyn.SparseLongWithFourCandidatesPerBucket(Value);
    [Benchmark]
    public int SparseLongWithFourCandidatesPerBucket_Trie() => TrieRoslyn.SparseLongWithFourCandidatesPerBucket(Value);
    [Benchmark]
    public int SparseLongWithFourCandidatesPerBucket_Old() => OldRoslyn.SparseLongWithFourCandidatesPerBucket(Value);
}
public partial class LengthVsHashCode_SparseWithFiveCandidatesPerBucket
{
    [Params("aaA", "aia", "aqi", "ayq", "aAy", "iaA", "iia", "iqi", "iyq", "iAy", "qaA", "qia", "qqi", "qyq", "qAy", "yaA", "yia", "yqi", "yyq", "yAy")]
    public string Value { get; set; }

    [Benchmark]
    public int SparseWithFiveCandidatesPerBucket_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket(Value);
    [Benchmark]
    public int SparseWithFiveCandidatesPerBucket_Trie() => OldRoslyn.SparseWithFiveCandidatesPerBucketTrie(Value);
    [Benchmark]
    public int SparseWithFiveCandidatesPerBucket_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket(Value);
}
public partial class LengthVsHashCode_SparseWithSixCandidatesPerBucket
{
    [Params("aaI", "aia", "aqi", "ayq", "aAy", "aIA", "iaI", "iia", "iqi", "iyq", "iAy", "iIA")]
    public string Value { get; set; }

    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_New() => NewRoslyn.SparseWithSixCandidatesPerBucket(Value);
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Trie() => TrieRoslyn.SparseWithSixCandidatesPerBucket(Value);
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket(Value);
}
public partial class LengthVsHashCode_SparseWithSevenCandidatesPerBucket
{
    /*
    |  SparseWithSevenCandidatesPerBucket_New |   aAy | 2.792 ns | 0.0128 ns | 0.0107 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   aAy | 1.482 ns | 0.0118 ns | 0.0110 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   aAy | 2.530 ns | 0.0109 ns | 0.0102 ns |
    |  SparseWithSevenCandidatesPerBucket_New |   aIA | 2.985 ns | 0.0260 ns | 0.0243 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   aIA | 1.486 ns | 0.0218 ns | 0.0204 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   aIA | 2.847 ns | 0.0348 ns | 0.0326 ns |
    |  SparseWithSevenCandidatesPerBucket_New |   aQI | 2.803 ns | 0.0305 ns | 0.0285 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   aQI | 1.490 ns | 0.0117 ns | 0.0109 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   aQI | 2.948 ns | 0.0148 ns | 0.0124 ns |
    |  SparseWithSevenCandidatesPerBucket_New |   aaQ | 2.693 ns | 0.0108 ns | 0.0101 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   aaQ | 1.571 ns | 0.0187 ns | 0.0166 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   aaQ | 2.678 ns | 0.0030 ns | 0.0025 ns |
    |  SparseWithSevenCandidatesPerBucket_New |   aia | 2.799 ns | 0.0269 ns | 0.0252 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   aia | 1.496 ns | 0.0106 ns | 0.0094 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   aia | 2.723 ns | 0.0188 ns | 0.0176 ns |
    |  SparseWithSevenCandidatesPerBucket_New |   aqi | 2.580 ns | 0.0192 ns | 0.0179 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   aqi | 1.501 ns | 0.0212 ns | 0.0198 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   aqi | 2.468 ns | 0.0053 ns | 0.0041 ns |
    |  SparseWithSevenCandidatesPerBucket_New |   ayq | 2.683 ns | 0.0090 ns | 0.0075 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   ayq | 1.894 ns | 0.0150 ns | 0.0140 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   ayq | 2.673 ns | 0.0217 ns | 0.0203 ns |
    |  SparseWithSevenCandidatesPerBucket_New |   iAy | 2.600 ns | 0.0158 ns | 0.0148 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   iAy | 1.493 ns | 0.0177 ns | 0.0157 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   iAy | 2.668 ns | 0.0069 ns | 0.0064 ns |
    |  SparseWithSevenCandidatesPerBucket_New |   iIA | 2.895 ns | 0.0148 ns | 0.0131 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   iIA | 1.702 ns | 0.0132 ns | 0.0117 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   iIA | 2.723 ns | 0.0170 ns | 0.0159 ns |
    |  SparseWithSevenCandidatesPerBucket_New |   iQI | 2.484 ns | 0.0121 ns | 0.0113 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   iQI | 1.686 ns | 0.0115 ns | 0.0108 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   iQI | 2.661 ns | 0.0231 ns | 0.0217 ns |
    |  SparseWithSevenCandidatesPerBucket_New |   iaQ | 2.874 ns | 0.0060 ns | 0.0050 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   iaQ | 1.683 ns | 0.0051 ns | 0.0045 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   iaQ | 3.112 ns | 0.0674 ns | 0.0631 ns |
    |  SparseWithSevenCandidatesPerBucket_New |   iia | 2.698 ns | 0.0549 ns | 0.0513 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   iia | 1.745 ns | 0.0398 ns | 0.0372 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   iia | 2.922 ns | 0.0332 ns | 0.0294 ns |
    |  SparseWithSevenCandidatesPerBucket_New |   iqi | 2.616 ns | 0.0538 ns | 0.0504 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   iqi | 1.989 ns | 0.0401 ns | 0.0375 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   iqi | 2.526 ns | 0.0355 ns | 0.0332 ns |
    |  SparseWithSevenCandidatesPerBucket_New |   iyq | 2.736 ns | 0.0346 ns | 0.0323 ns |
    | SparseWithSevenCandidatesPerBucket_Trie |   iyq | 1.682 ns | 0.0077 ns | 0.0072 ns |
    |  SparseWithSevenCandidatesPerBucket_Old |   iyq | 2.526 ns | 0.0219 ns | 0.0204 ns |
    */
    [Params("aaQ", "aia", "aqi", "ayq", "aAy", "aIA", "aQI", "iaQ", "iia", "iqi", "iyq", "iAy", "iIA", "iQI")]
    public string Value { get; set; }

    [Benchmark]
    public int SparseWithSevenCandidatesPerBucket_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket(Value);
    [Benchmark]
    public int SparseWithSevenCandidatesPerBucket_Trie() => TrieRoslyn.SparseWithSevenCandidatesPerBucket(Value);
    [Benchmark]
    public int SparseWithSevenCandidatesPerBucket_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket(Value);
}
public partial class LengthVsHashCode
{
    [Benchmark]
    public int GetHashCodeBenchmark()
    {
        int last = 0;
        for (int i = 0; i < 1000; i++)
        {
            last = "hello world".GetHashCode();
        }
        return last;
    }

    string field = "hello world";
    [Benchmark]
    public int StringEquality()
    {
        string value = field;
        string other = "hello worl";
        other += "d";
        int last = 0;
        for (int i = 0; i < 1000; i++)
        {
            last = other == value ? 0 : 1;
        }
        return last;
    }
}
public partial class LengthVsHashCode_GetContents
{
    [Params("1.2.840.10040.4.1", "1.2.840.10040.4.3", "1.2.840.10045.2.1", "1.2.840.10045.1.1", "1.2.840.10045.1.2", "1.2.840.10045.3.1.7",
        "1.2.840.10045.4.1", "1.2.840.10045.4.3.2", "1.2.840.10045.4.3.3", "1.2.840.10045.4.3.4", "1.2.840.113549.1.1.1", "1.2.840.113549.1.1.5",
        "1.2.840.113549.1.1.7", "1.2.840.113549.1.1.8", "1.2.840.113549.1.1.9", "1.2.840.113549.1.1.10", "1.2.840.113549.1.1.11", "1.2.840.113549.1.1.12",
        "1.2.840.113549.1.1.13", "1.2.840.113549.1.5.3", "1.2.840.113549.1.5.10", "1.2.840.113549.1.5.11", "1.2.840.113549.1.5.12", "1.2.840.113549.1.5.13",
        "1.2.840.113549.1.7.1", "1.2.840.113549.1.7.2", "1.2.840.113549.1.7.3", "1.2.840.113549.1.7.6", "1.2.840.113549.1.9.1", "1.2.840.113549.1.9.3",
        "1.2.840.113549.1.9.4", "1.2.840.113549.1.9.5", "1.2.840.113549.1.9.6", "1.2.840.113549.1.9.7", "1.2.840.113549.1.9.14", "1.2.840.113549.1.9.15",
        "1.2.840.113549.1.9.16.1.4", "1.2.840.113549.1.9.16.2.12", "1.2.840.113549.1.9.16.2.14", "1.2.840.113549.1.9.16.2.47", "1.2.840.113549.1.9.20",
        "1.2.840.113549.1.9.21", "1.2.840.113549.1.9.22.1", "1.2.840.113549.1.12.1.3", "1.2.840.113549.1.12.1.5", "1.2.840.113549.1.12.1.6", "1.2.840.113549.1.12.10.1.1",
        "1.2.840.113549.1.12.10.1.2", "1.2.840.113549.1.12.10.1.3", "1.2.840.113549.1.12.10.1.5", "1.2.840.113549.1.12.10.1.6", "1.2.840.113549.2.5", "1.2.840.113549.2.7",
        "1.2.840.113549.2.9", "1.2.840.113549.2.10", "1.2.840.113549.2.11", "1.2.840.113549.3.2", "1.2.840.113549.3.7", "1.3.6.1.4.1.311.17.1",
        "1.3.6.1.4.1.311.17.3.20", "1.3.6.1.4.1.311.20.2.3", "1.3.6.1.4.1.311.88.2.1", "1.3.6.1.4.1.311.88.2.2", "1.3.6.1.5.5.7.3.1", "1.3.6.1.5.5.7.3.2",
        "1.3.6.1.5.5.7.3.3", "1.3.6.1.5.5.7.3.4", "1.3.6.1.5.5.7.3.8", "1.3.6.1.5.5.7.3.9", "1.3.6.1.5.5.7.6.2", "1.3.6.1.5.5.7.48.1", "1.3.6.1.5.5.7.48.1.2",
        "1.3.6.1.5.5.7.48.2", "1.3.14.3.2.26", "1.3.14.3.2.7", "1.3.132.0.34", "1.3.132.0.35", "2.5.4.3", "2.5.4.5", "2.5.4.6", "2.5.4.7", "2.5.4.8", "2.5.4.10",
        "2.5.4.11", "2.5.4.97", "2.5.29.14", "2.5.29.15", "2.5.29.17", "2.5.29.19", "2.5.29.20", "2.5.29.35", "2.16.840.1.101.3.4.1.2", "2.16.840.1.101.3.4.1.22",
        "2.16.840.1.101.3.4.1.42", "2.16.840.1.101.3.4.2.1", "2.16.840.1.101.3.4.2.2", "2.16.840.1.101.3.4.2.3", "2.23.140.1.2.1", "2.23.140.1.2.2")]
    public string Value { get; set; }

    [Benchmark]
    public string GetContents_New() => NewRoslyn.GetContents(Value);
    [Benchmark]
    public string GetContents_Old() => OldRoslyn.GetContents(Value);
}

public partial class LengthVsHashCode_GetContents_Mix
{
    [Benchmark]
    public string GetDriveType_Mix_New() => NewRoslyn.GetContents_Mix();
    [Benchmark]
    public string GetDriveType_Mix_Old() => OldRoslyn.GetContents_Mix();
}

public partial class LengthVsHashCode_TryParseStatusFile
{
    [Params("Pid", "VmHWM", "VmRSS", "VmData", "VmSwap", "VmSize", "VmPeak", "VmStk")]
    public string Value { get; set; }

    [Benchmark]
    public string TryParseStatusFile_New() => NewRoslyn.TryParseStatusFile(Value);
    [Benchmark]
    public string TryParseStatusFile_Old() => OldRoslyn.TryParseStatusFile(Value);
}

public partial class LengthVsHashCode_TryParseStatusFile_Mix
{
    [Benchmark]
    public string TryParseStatusFile_New_Mix() => NewRoslyn.TryParseStatusFile_Mix();
    [Benchmark]
    public string TryParseStatusFile_Old_Mix() => OldRoslyn.TryParseStatusFile_Mix();
}

public partial class LengthVsHashCode_GetHashForChannelBinding
{
    [Params("1.2.840.113549.2.5", "1.2.840.113549.1.1.4", "1.3.14.3.2.26", "1.2.840.10040.4.3", "1.2.840.10045.4.1", "1.2.840.113549.1.1.5",
        "2.16.840.1.101.3.4.2.1", "1.2.840.10045.4.3.2", "1.2.840.113549.1.1.11", "2.16.840.1.101.3.4.2.2", "1.2.840.10045.4.3.3",
        "1.2.840.113549.1.1.12", "2.16.840.1.101.3.4.2.3", "1.2.840.10045.4.3.4", "1.2.840.113549.1.1.13")]
    public string Value { get; set; }

    [Benchmark]
    public string GetHashForChannelBinding_New() => NewRoslyn.GetHashForChannelBinding(Value);
    [Benchmark]
    public string GetHashForChannelBinding_Old() => OldRoslyn.GetHashForChannelBinding(Value);
}

public partial class LengthVsHashCode_GetHashForChannelBinding_Mix
{
    [Benchmark]
    public string GetHashForChannelBinding_New_Mix() => NewRoslyn.GetHashForChannelBinding_Mix();
    [Benchmark]
    public string GetHashForChannelBinding_Old_Mix() => OldRoslyn.GetHashForChannelBinding_Mix();
}

