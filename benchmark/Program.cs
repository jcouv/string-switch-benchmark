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
//_ = BenchmarkRunner.Run<LengthVsHashCode_GetContents>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_GetContents_Mix>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_TryParseStatusFile>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_TryParseStatusFile_Mix>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_GetHashForChannelBinding>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_GetHashForChannelBinding_Mix>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_WriteEntityRef>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_WriteEntityRef_Mix>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_FunctionAvailable>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_FunctionAvailable_Mix>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_NormalizeTimeZone>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_NormalizeTimeZone_Mix>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_AcceptCommand>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_AcceptCommand_Mix>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_EmitIL>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_EmitIL_Mix>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_GetWellKnownType>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_GetWellKnownType_Mix>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_GetLocalizedString>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_GetLocalizedString_Mix>();
//_ = BenchmarkRunner.Run<LengthVsHashCode_ParseGraphicsUnits>();
_ = BenchmarkRunner.Run<LengthVsHashCode_ParseGraphicsUnits_Mix>();

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
    /*
    |          Method |                Value |      Mean |     Error |    StdDev |
    |---------------- |--------------------- |----------:|----------:|----------:|
    | GetContents_New |    1.2.840.10040.4.1 |  2.483 ns | 0.0213 ns | 0.0189 ns |
    | GetContents_Old |    1.2.840.10040.4.1 |  7.875 ns | 0.0126 ns | 0.0098 ns |
    | GetContents_New |    1.2.840.10040.4.3 |  2.483 ns | 0.0253 ns | 0.0212 ns |
    | GetContents_Old |    1.2.840.10040.4.3 |  8.284 ns | 0.0652 ns | 0.0578 ns |
    | GetContents_New |    1.2.840.10045.1.1 |  3.576 ns | 0.0513 ns | 0.0480 ns |
    | GetContents_Old |    1.2.840.10045.1.1 |  8.335 ns | 0.0895 ns | 0.0794 ns |
    | GetContents_New |    1.2.840.10045.1.2 |  2.485 ns | 0.0286 ns | 0.0254 ns |
    | GetContents_Old |    1.2.840.10045.1.2 |  8.183 ns | 0.0720 ns | 0.0638 ns |
    | GetContents_New |    1.2.840.10045.2.1 |  2.858 ns | 0.0415 ns | 0.0368 ns |
    | GetContents_Old |    1.2.840.10045.2.1 |  8.364 ns | 0.1750 ns | 0.1551 ns |
    | GetContents_New |  1.2.840.10045.3.1.7 |  2.525 ns | 0.0601 ns | 0.0532 ns |
    | GetContents_Old |  1.2.840.10045.3.1.7 |  9.309 ns | 0.0283 ns | 0.0237 ns |
    | GetContents_New |    1.2.840.10045.4.1 |  3.761 ns | 0.0100 ns | 0.0078 ns |
    | GetContents_Old |    1.2.840.10045.4.1 |  8.013 ns | 0.0237 ns | 0.0198 ns |
    | GetContents_New |  1.2.840.10045.4.3.2 |  2.541 ns | 0.0273 ns | 0.0242 ns |
    | GetContents_Old |  1.2.840.10045.4.3.2 |  9.518 ns | 0.0431 ns | 0.0404 ns |
    | GetContents_New |  1.2.840.10045.4.3.3 |  2.482 ns | 0.0397 ns | 0.0331 ns |
    | GetContents_Old |  1.2.840.10045.4.3.3 |  9.649 ns | 0.1388 ns | 0.1159 ns |
    | GetContents_New |  1.2.840.10045.4.3.4 |  2.506 ns | 0.0340 ns | 0.0284 ns |
    | GetContents_Old |  1.2.840.10045.4.3.4 |  9.271 ns | 0.0692 ns | 0.0647 ns |
    | GetContents_New | 1.2.840.113549.1.1.1 |  2.737 ns | 0.0467 ns | 0.0414 ns |
    | GetContents_Old | 1.2.840.113549.1.1.1 | 10.274 ns | 0.0341 ns | 0.0284 ns |
    | GetContents_New | 1.2.8(...).1.10 [21] |  2.724 ns | 0.0171 ns | 0.0152 ns |
    | GetContents_Old | 1.2.8(...).1.10 [21] | 11.078 ns | 0.0141 ns | 0.0110 ns |
    | GetContents_New | 1.2.8(...).1.11 [21] |  2.521 ns | 0.0275 ns | 0.0257 ns |
    | GetContents_Old | 1.2.8(...).1.11 [21] | 11.233 ns | 0.1173 ns | 0.0980 ns |
    | GetContents_New | 1.2.8(...).1.12 [21] |  2.508 ns | 0.0095 ns | 0.0079 ns |
    | GetContents_Old | 1.2.8(...).1.12 [21] | 10.793 ns | 0.0454 ns | 0.0379 ns |
    | GetContents_New | 1.2.8(...).1.13 [21] |  2.508 ns | 0.0190 ns | 0.0168 ns |
    | GetContents_Old | 1.2.8(...).1.13 [21] | 11.102 ns | 0.0342 ns | 0.0303 ns |
    | GetContents_New | 1.2.840.113549.1.1.5 |  2.502 ns | 0.0105 ns | 0.0087 ns |
    | GetContents_Old | 1.2.840.113549.1.1.5 |  9.957 ns | 0.0345 ns | 0.0288 ns |
    | GetContents_New | 1.2.840.113549.1.1.7 |  2.509 ns | 0.0206 ns | 0.0183 ns |
    | GetContents_Old | 1.2.840.113549.1.1.7 | 10.327 ns | 0.0423 ns | 0.0353 ns |
    | GetContents_New | 1.2.840.113549.1.1.8 |  2.505 ns | 0.0100 ns | 0.0089 ns |
    | GetContents_Old | 1.2.840.113549.1.1.8 | 10.080 ns | 0.0279 ns | 0.0233 ns |
    | GetContents_New | 1.2.840.113549.1.1.9 |  2.471 ns | 0.0129 ns | 0.0121 ns |
    | GetContents_Old | 1.2.840.113549.1.1.9 | 10.103 ns | 0.0181 ns | 0.0161 ns |
    | GetContents_New | 1.2.8(...)2.1.3 [23] |  2.468 ns | 0.0070 ns | 0.0059 ns |
    | GetContents_Old | 1.2.8(...)2.1.3 [23] | 13.168 ns | 0.0595 ns | 0.0527 ns |
    | GetContents_New | 1.2.8(...)2.1.5 [23] |  2.469 ns | 0.0074 ns | 0.0062 ns |
    | GetContents_Old | 1.2.8(...)2.1.5 [23] | 14.324 ns | 0.0259 ns | 0.0230 ns |
    | GetContents_New | 1.2.8(...)2.1.6 [23] |  2.467 ns | 0.0064 ns | 0.0053 ns |
    | GetContents_Old | 1.2.8(...)2.1.6 [23] | 13.772 ns | 0.0464 ns | 0.0434 ns |
    | GetContents_New | 1.2.8(...)0.1.1 [26] |  2.504 ns | 0.0207 ns | 0.0184 ns |
    | GetContents_Old | 1.2.8(...)0.1.1 [26] | 15.211 ns | 0.0612 ns | 0.0511 ns |
    | GetContents_New | 1.2.8(...)0.1.2 [26] |  2.895 ns | 0.0081 ns | 0.0076 ns |
    | GetContents_Old | 1.2.8(...)0.1.2 [26] | 15.382 ns | 0.0463 ns | 0.0410 ns |
    | GetContents_New | 1.2.8(...)0.1.3 [26] |  2.490 ns | 0.0181 ns | 0.0161 ns |
    | GetContents_Old | 1.2.8(...)0.1.3 [26] | 15.367 ns | 0.0563 ns | 0.0499 ns |
    | GetContents_New | 1.2.8(...)0.1.5 [26] |  2.473 ns | 0.0120 ns | 0.0106 ns |
    | GetContents_Old | 1.2.8(...)0.1.5 [26] | 15.506 ns | 0.0895 ns | 0.0837 ns |
    | GetContents_New | 1.2.8(...)0.1.6 [26] |  2.482 ns | 0.0260 ns | 0.0217 ns |
    | GetContents_Old | 1.2.8(...)0.1.6 [26] | 15.472 ns | 0.0454 ns | 0.0402 ns |
    | GetContents_New | 1.2.8(...).5.10 [21] |  2.923 ns | 0.0334 ns | 0.0296 ns |
    | GetContents_Old | 1.2.8(...).5.10 [21] | 10.871 ns | 0.0413 ns | 0.0366 ns |
    | GetContents_New | 1.2.8(...).5.11 [21] |  3.116 ns | 0.0146 ns | 0.0129 ns |
    | GetContents_Old | 1.2.8(...).5.11 [21] | 11.116 ns | 0.0363 ns | 0.0340 ns |
    | GetContents_New | 1.2.8(...).5.12 [21] |  2.901 ns | 0.0054 ns | 0.0051 ns |
    | GetContents_Old | 1.2.8(...).5.12 [21] | 11.077 ns | 0.0222 ns | 0.0197 ns |
    | GetContents_New | 1.2.8(...).5.13 [21] |  2.896 ns | 0.0206 ns | 0.0183 ns |
    | GetContents_Old | 1.2.8(...).5.13 [21] | 10.984 ns | 0.0288 ns | 0.0255 ns |
    | GetContents_New | 1.2.840.113549.1.5.3 |  2.727 ns | 0.0178 ns | 0.0167 ns |
    | GetContents_Old | 1.2.840.113549.1.5.3 | 10.182 ns | 0.0318 ns | 0.0298 ns |
    | GetContents_New | 1.2.840.113549.1.7.1 |  3.103 ns | 0.0054 ns | 0.0048 ns |
    | GetContents_Old | 1.2.840.113549.1.7.1 | 10.135 ns | 0.0194 ns | 0.0162 ns |
    | GetContents_New | 1.2.840.113549.1.7.2 |  2.508 ns | 0.0177 ns | 0.0165 ns |
    | GetContents_Old | 1.2.840.113549.1.7.2 | 10.254 ns | 0.0480 ns | 0.0426 ns |
    | GetContents_New | 1.2.840.113549.1.7.3 |  2.913 ns | 0.0265 ns | 0.0234 ns |
    | GetContents_Old | 1.2.840.113549.1.7.3 | 10.033 ns | 0.0368 ns | 0.0308 ns |
    | GetContents_New | 1.2.840.113549.1.7.6 |  2.495 ns | 0.0150 ns | 0.0125 ns |
    | GetContents_Old | 1.2.840.113549.1.7.6 | 10.264 ns | 0.0354 ns | 0.0296 ns |
    | GetContents_New | 1.2.840.113549.1.9.1 |  3.313 ns | 0.0153 ns | 0.0128 ns |
    | GetContents_Old | 1.2.840.113549.1.9.1 | 10.351 ns | 0.0501 ns | 0.0444 ns |
    | GetContents_New | 1.2.8(...).9.14 [21] |  2.482 ns | 0.0107 ns | 0.0090 ns |
    | GetContents_Old | 1.2.8(...).9.14 [21] | 10.936 ns | 0.0646 ns | 0.0604 ns |
    | GetContents_New | 1.2.8(...).9.15 [21] |  2.486 ns | 0.0113 ns | 0.0100 ns |
    | GetContents_Old | 1.2.8(...).9.15 [21] | 10.626 ns | 0.0361 ns | 0.0320 ns |
    | GetContents_New | 1.2.8(...)6.1.4 [25] |  2.063 ns | 0.0074 ns | 0.0066 ns |
    | GetContents_Old | 1.2.8(...)6.1.4 [25] | 14.859 ns | 0.0413 ns | 0.0386 ns |
    | GetContents_New | 1.2.8(...).2.12 [26] |  2.512 ns | 0.0118 ns | 0.0110 ns |
    | GetContents_Old | 1.2.8(...).2.12 [26] | 15.399 ns | 0.0624 ns | 0.0584 ns |
    | GetContents_New | 1.2.8(...).2.14 [26] |  2.476 ns | 0.0200 ns | 0.0188 ns |
    | GetContents_Old | 1.2.8(...).2.14 [26] | 15.310 ns | 0.0521 ns | 0.0462 ns |
    | GetContents_New | 1.2.8(...).2.47 [26] |  2.465 ns | 0.0108 ns | 0.0101 ns |
    | GetContents_Old | 1.2.8(...).2.47 [26] | 15.256 ns | 0.0683 ns | 0.0570 ns |
    | GetContents_New | 1.2.8(...).9.20 [21] |  3.305 ns | 0.0072 ns | 0.0060 ns |
    | GetContents_Old | 1.2.8(...).9.20 [21] | 10.773 ns | 0.0430 ns | 0.0359 ns |
    | GetContents_New | 1.2.8(...).9.21 [21] |  3.305 ns | 0.0113 ns | 0.0095 ns |
    | GetContents_Old | 1.2.8(...).9.21 [21] | 11.037 ns | 0.0382 ns | 0.0358 ns |
    | GetContents_New | 1.2.8(...).22.1 [23] |  2.458 ns | 0.0053 ns | 0.0042 ns |
    | GetContents_Old | 1.2.8(...).22.1 [23] | 13.253 ns | 0.0399 ns | 0.0353 ns |
    | GetContents_New | 1.2.840.113549.1.9.3 |  3.102 ns | 0.0145 ns | 0.0129 ns |
    | GetContents_Old | 1.2.840.113549.1.9.3 | 10.228 ns | 0.0305 ns | 0.0270 ns |
    | GetContents_New | 1.2.840.113549.1.9.4 |  2.462 ns | 0.0197 ns | 0.0153 ns |
    | GetContents_Old | 1.2.840.113549.1.9.4 | 10.288 ns | 0.0517 ns | 0.0484 ns |
    | GetContents_New | 1.2.840.113549.1.9.5 |  2.890 ns | 0.0122 ns | 0.0108 ns |
    | GetContents_Old | 1.2.840.113549.1.9.5 | 10.221 ns | 0.0360 ns | 0.0320 ns |
    | GetContents_New | 1.2.840.113549.1.9.6 |  2.886 ns | 0.0083 ns | 0.0069 ns |
    | GetContents_Old | 1.2.840.113549.1.9.6 | 10.224 ns | 0.0827 ns | 0.0773 ns |
    | GetContents_New | 1.2.840.113549.1.9.7 |  2.879 ns | 0.0066 ns | 0.0052 ns |
    | GetContents_Old | 1.2.840.113549.1.9.7 | 10.266 ns | 0.0539 ns | 0.0450 ns |
    | GetContents_New |  1.2.840.113549.2.10 |  2.466 ns | 0.0145 ns | 0.0128 ns |
    | GetContents_Old |  1.2.840.113549.2.10 |  9.208 ns | 0.0571 ns | 0.0506 ns |
    | GetContents_New |  1.2.840.113549.2.11 |  2.497 ns | 0.0119 ns | 0.0099 ns |
    | GetContents_Old |  1.2.840.113549.2.11 |  9.466 ns | 0.0404 ns | 0.0358 ns |
    | GetContents_New |   1.2.840.113549.2.5 |  2.469 ns | 0.0162 ns | 0.0135 ns |
    | GetContents_Old |   1.2.840.113549.2.5 |  8.858 ns | 0.0281 ns | 0.0263 ns |
    | GetContents_New |   1.2.840.113549.2.7 |  2.511 ns | 0.0216 ns | 0.0191 ns |
    | GetContents_Old |   1.2.840.113549.2.7 |  8.883 ns | 0.0376 ns | 0.0352 ns |
    | GetContents_New |   1.2.840.113549.2.9 |  2.463 ns | 0.0060 ns | 0.0050 ns |
    | GetContents_Old |   1.2.840.113549.2.9 |  8.901 ns | 0.0449 ns | 0.0398 ns |
    | GetContents_New |   1.2.840.113549.3.2 |  2.497 ns | 0.0133 ns | 0.0118 ns |
    | GetContents_Old |   1.2.840.113549.3.2 |  8.780 ns | 0.0185 ns | 0.0164 ns |
    | GetContents_New |   1.2.840.113549.3.7 |  2.675 ns | 0.0063 ns | 0.0052 ns |
    | GetContents_Old |   1.2.840.113549.3.7 |  8.448 ns | 0.0496 ns | 0.0440 ns |
    | GetContents_New |         1.3.132.0.34 |  2.494 ns | 0.0087 ns | 0.0077 ns |
    | GetContents_Old |         1.3.132.0.34 |  6.317 ns | 0.0209 ns | 0.0185 ns |
    | GetContents_New |         1.3.132.0.35 |  2.461 ns | 0.0057 ns | 0.0045 ns |
    | GetContents_Old |         1.3.132.0.35 |  6.079 ns | 0.0401 ns | 0.0355 ns |
    | GetContents_New |        1.3.14.3.2.26 |  2.068 ns | 0.0138 ns | 0.0115 ns |
    | GetContents_Old |        1.3.14.3.2.26 |  6.943 ns | 0.0304 ns | 0.0270 ns |
    | GetContents_New |         1.3.14.3.2.7 |  2.471 ns | 0.0242 ns | 0.0214 ns |
    | GetContents_Old |         1.3.14.3.2.7 |  5.899 ns | 0.0361 ns | 0.0338 ns |
    | GetContents_New | 1.3.6.1.4.1.311.17.1 |  3.735 ns | 0.0125 ns | 0.0111 ns |
    | GetContents_Old | 1.3.6.1.4.1.311.17.1 | 10.371 ns | 0.0495 ns | 0.0439 ns |
    | GetContents_New | 1.3.6(...).3.20 [23] |  2.467 ns | 0.0110 ns | 0.0103 ns |
    | GetContents_Old | 1.3.6(...).3.20 [23] | 13.146 ns | 0.0650 ns | 0.0608 ns |
    | GetContents_New | 1.3.6(...)0.2.3 [22] |  2.464 ns | 0.0193 ns | 0.0161 ns |
    | GetContents_Old | 1.3.6(...)0.2.3 [22] | 11.633 ns | 0.0803 ns | 0.0751 ns |
    | GetContents_New | 1.3.6(...)8.2.1 [22] |  2.460 ns | 0.0084 ns | 0.0070 ns |
    | GetContents_Old | 1.3.6(...)8.2.1 [22] | 11.600 ns | 0.0203 ns | 0.0180 ns |
    | GetContents_New | 1.3.6(...)8.2.2 [22] |  2.878 ns | 0.0055 ns | 0.0046 ns |
    | GetContents_Old | 1.3.6(...)8.2.2 [22] | 11.585 ns | 0.0513 ns | 0.0455 ns |
    | GetContents_New |    1.3.6.1.5.5.7.3.1 |  4.158 ns | 0.0153 ns | 0.0128 ns |
    | GetContents_Old |    1.3.6.1.5.5.7.3.1 |  7.897 ns | 0.0342 ns | 0.0320 ns |
    | GetContents_New |    1.3.6.1.5.5.7.3.2 |  2.905 ns | 0.0258 ns | 0.0241 ns |
    | GetContents_Old |    1.3.6.1.5.5.7.3.2 |  8.148 ns | 0.0498 ns | 0.0416 ns |
    | GetContents_New |    1.3.6.1.5.5.7.3.3 |  2.696 ns | 0.0162 ns | 0.0136 ns |
    | GetContents_Old |    1.3.6.1.5.5.7.3.3 |  7.943 ns | 0.1096 ns | 0.1025 ns |
    | GetContents_New |    1.3.6.1.5.5.7.3.4 |  2.469 ns | 0.0105 ns | 0.0099 ns |
    | GetContents_Old |    1.3.6.1.5.5.7.3.4 |  7.850 ns | 0.0420 ns | 0.0372 ns |
    | GetContents_New |    1.3.6.1.5.5.7.3.8 |  2.462 ns | 0.0097 ns | 0.0081 ns |
    | GetContents_Old |    1.3.6.1.5.5.7.3.8 |  8.308 ns | 0.0417 ns | 0.0390 ns |
    | GetContents_New |    1.3.6.1.5.5.7.3.9 |  2.459 ns | 0.0103 ns | 0.0086 ns |
    | GetContents_Old |    1.3.6.1.5.5.7.3.9 |  8.278 ns | 0.0447 ns | 0.0374 ns |
    | GetContents_New |   1.3.6.1.5.5.7.48.1 |  2.492 ns | 0.0049 ns | 0.0041 ns |
    | GetContents_Old |   1.3.6.1.5.5.7.48.1 |  8.948 ns | 0.0316 ns | 0.0296 ns |
    | GetContents_New | 1.3.6.1.5.5.7.48.1.2 |  2.887 ns | 0.0136 ns | 0.0114 ns |
    | GetContents_Old | 1.3.6.1.5.5.7.48.1.2 | 10.052 ns | 0.0423 ns | 0.0375 ns |
    | GetContents_New |   1.3.6.1.5.5.7.48.2 |  2.883 ns | 0.0047 ns | 0.0039 ns |
    | GetContents_Old |   1.3.6.1.5.5.7.48.2 |  8.910 ns | 0.0279 ns | 0.0247 ns |
    | GetContents_New |    1.3.6.1.5.5.7.6.2 |  3.314 ns | 0.0132 ns | 0.0117 ns |
    | GetContents_Old |    1.3.6.1.5.5.7.6.2 |  8.439 ns | 0.0582 ns | 0.0516 ns |
    | GetContents_New | 2.16.(...)4.1.2 [22] |  2.298 ns | 0.0135 ns | 0.0113 ns |
    | GetContents_Old | 2.16.(...)4.1.2 [22] | 11.876 ns | 0.2258 ns | 0.2112 ns |
    | GetContents_New | 2.16.(...).1.22 [23] |  2.458 ns | 0.0063 ns | 0.0052 ns |
    | GetContents_Old | 2.16.(...).1.22 [23] | 14.120 ns | 0.0499 ns | 0.0467 ns |
    | GetContents_New | 2.16.(...).1.42 [23] |  2.697 ns | 0.0179 ns | 0.0167 ns |
    | GetContents_Old | 2.16.(...).1.42 [23] | 13.218 ns | 0.0680 ns | 0.0636 ns |
    | GetContents_New | 2.16.(...)4.2.1 [22] |  2.828 ns | 0.0049 ns | 0.0041 ns |
    | GetContents_Old | 2.16.(...)4.2.1 [22] | 12.701 ns | 0.0614 ns | 0.0575 ns |
    | GetContents_New | 2.16.(...)4.2.2 [22] |  3.304 ns | 0.0156 ns | 0.0139 ns |
    | GetContents_Old | 2.16.(...)4.2.2 [22] | 11.648 ns | 0.1193 ns | 0.1116 ns |
    | GetContents_New | 2.16.(...)4.2.3 [22] |  3.518 ns | 0.0090 ns | 0.0080 ns |
    | GetContents_Old | 2.16.(...)4.2.3 [22] | 12.693 ns | 0.0733 ns | 0.0650 ns |
    | GetContents_New |       2.23.140.1.2.1 |  2.253 ns | 0.0159 ns | 0.0149 ns |
    | GetContents_Old |       2.23.140.1.2.1 |  6.769 ns | 0.0259 ns | 0.0217 ns |
    | GetContents_New |       2.23.140.1.2.2 |  2.258 ns | 0.0159 ns | 0.0141 ns |
    | GetContents_Old |       2.23.140.1.2.2 |  6.426 ns | 0.0123 ns | 0.0109 ns |
    | GetContents_New |            2.5.29.14 |  2.562 ns | 0.0113 ns | 0.0094 ns |
    | GetContents_Old |            2.5.29.14 |  5.134 ns | 0.0311 ns | 0.0291 ns |
    | GetContents_New |            2.5.29.15 |  2.506 ns | 0.0172 ns | 0.0152 ns |
    | GetContents_Old |            2.5.29.15 |  4.914 ns | 0.0142 ns | 0.0119 ns |
    | GetContents_New |            2.5.29.17 |  2.462 ns | 0.0053 ns | 0.0045 ns |
    | GetContents_Old |            2.5.29.17 |  4.932 ns | 0.0394 ns | 0.0329 ns |
    | GetContents_New |            2.5.29.19 |  2.460 ns | 0.0076 ns | 0.0067 ns |
    | GetContents_Old |            2.5.29.19 |  5.107 ns | 0.0189 ns | 0.0158 ns |
    | GetContents_New |            2.5.29.20 |  2.286 ns | 0.0207 ns | 0.0193 ns |
    | GetContents_Old |            2.5.29.20 |  4.929 ns | 0.0157 ns | 0.0139 ns |
    | GetContents_New |            2.5.29.35 |  2.889 ns | 0.0238 ns | 0.0211 ns |
    | GetContents_Old |            2.5.29.35 |  5.124 ns | 0.0274 ns | 0.0256 ns |
    | GetContents_New |             2.5.4.10 |  2.077 ns | 0.0126 ns | 0.0105 ns |
    | GetContents_Old |             2.5.4.10 |  4.500 ns | 0.0185 ns | 0.0164 ns |
    | GetContents_New |             2.5.4.11 |  2.263 ns | 0.0353 ns | 0.0313 ns |
    | GetContents_Old |             2.5.4.11 |  4.695 ns | 0.0144 ns | 0.0120 ns |
    | GetContents_New |              2.5.4.3 |  2.469 ns | 0.0199 ns | 0.0167 ns |
    | GetContents_Old |              2.5.4.3 |  4.291 ns | 0.0232 ns | 0.0206 ns |
    | GetContents_New |              2.5.4.5 |  2.460 ns | 0.0107 ns | 0.0095 ns |
    | GetContents_Old |              2.5.4.5 |  4.077 ns | 0.0098 ns | 0.0082 ns |
    | GetContents_New |              2.5.4.6 |  2.464 ns | 0.0082 ns | 0.0077 ns |
    | GetContents_Old |              2.5.4.6 |  4.080 ns | 0.0224 ns | 0.0187 ns |
    | GetContents_New |              2.5.4.7 |  2.458 ns | 0.0090 ns | 0.0084 ns |
    | GetContents_Old |              2.5.4.7 |  4.292 ns | 0.0203 ns | 0.0190 ns |
    | GetContents_New |              2.5.4.8 |  2.520 ns | 0.0262 ns | 0.0245 ns |
    | GetContents_Old |              2.5.4.8 |  4.900 ns | 0.0123 ns | 0.0109 ns |
    | GetContents_New |             2.5.4.97 |  2.251 ns | 0.0138 ns | 0.0115 ns |
    | GetContents_Old |             2.5.4.97 |  4.507 ns | 0.0451 ns | 0.0400 ns | 
     */
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
    /*
    |               Method |       Mean |   Error |  StdDev |
    |--------------------- |-----------:|--------:|--------:|
    | GetContents_Mix_New |   524.8 ns | 2.83 ns | 2.65 ns |
    | GetContents_Mix_Old | 1,206.9 ns | 7.83 ns | 7.33 ns |
     */
    [Benchmark]
    public string GetContents_Mix_New() => NewRoslyn.GetContents_Mix();
    [Benchmark]
    public string GetContents_Mix_Old() => OldRoslyn.GetContents_Mix();
}

public partial class LengthVsHashCode_TryParseStatusFile
{
    /*
    |                 Method |  Value |     Mean |     Error |    StdDev |
    |----------------------- |------- |---------:|----------:|----------:|
    | TryParseStatusFile_New |    Pid | 1.500 ns | 0.0136 ns | 0.0114 ns |
    | TryParseStatusFile_Old |    Pid | 3.480 ns | 0.0161 ns | 0.0143 ns |
    | TryParseStatusFile_New | VmData | 1.705 ns | 0.0189 ns | 0.0158 ns |
    | TryParseStatusFile_Old | VmData | 4.307 ns | 0.0114 ns | 0.0101 ns |
    | TryParseStatusFile_New |  VmHWM | 2.043 ns | 0.0053 ns | 0.0044 ns |
    | TryParseStatusFile_Old |  VmHWM | 3.878 ns | 0.0077 ns | 0.0064 ns |
    | TryParseStatusFile_New | VmPeak | 1.713 ns | 0.0245 ns | 0.0230 ns |
    | TryParseStatusFile_Old | VmPeak | 4.296 ns | 0.0120 ns | 0.0106 ns |
    | TryParseStatusFile_New |  VmRSS | 2.251 ns | 0.0223 ns | 0.0197 ns |
    | TryParseStatusFile_Old |  VmRSS | 3.481 ns | 0.0359 ns | 0.0318 ns |
    | TryParseStatusFile_New | VmSize | 1.924 ns | 0.0229 ns | 0.0214 ns |
    | TryParseStatusFile_Old | VmSize | 3.904 ns | 0.0366 ns | 0.0342 ns |
    | TryParseStatusFile_New |  VmStk | 1.979 ns | 0.0185 ns | 0.0173 ns |
    | TryParseStatusFile_Old |  VmStk | 3.887 ns | 0.0205 ns | 0.0192 ns |
    | TryParseStatusFile_New | VmSwap | 1.700 ns | 0.0136 ns | 0.0120 ns |
    | TryParseStatusFile_Old | VmSwap | 3.654 ns | 0.0114 ns | 0.0089 ns | 
     */
    [Params("Pid", "VmHWM", "VmRSS", "VmData", "VmSwap", "VmSize", "VmPeak", "VmStk")]
    public string Value { get; set; }

    [Benchmark]
    public string TryParseStatusFile_New() => NewRoslyn.TryParseStatusFile(Value);
    [Benchmark]
    public string TryParseStatusFile_Old() => OldRoslyn.TryParseStatusFile(Value);
}

public partial class LengthVsHashCode_TryParseStatusFile_Mix
{
    /*
    |                     Method |     Mean |    Error |   StdDev |
    |--------------------------- |---------:|---------:|---------:|
    | TryParseStatusFile_New_Mix | 32.41 ns | 0.108 ns | 0.084 ns |
    | TryParseStatusFile_Old_Mix | 46.58 ns | 0.274 ns | 0.243 ns |
     */
    [Benchmark]
    public string TryParseStatusFile_New_Mix() => NewRoslyn.TryParseStatusFile_Mix();
    [Benchmark]
    public string TryParseStatusFile_Old_Mix() => OldRoslyn.TryParseStatusFile_Mix();
}

public partial class LengthVsHashCode_GetHashForChannelBinding
{
    /*
    |                       Method |                Value |      Mean |     Error |    StdDev |
    |----------------------------- |--------------------- |----------:|----------:|----------:|
    | GetHashForChannelBinding_New |    1.2.840.10040.4.3 |  1.931 ns | 0.0139 ns | 0.0130 ns |
    | GetHashForChannelBinding_Old |    1.2.840.10040.4.3 |  7.588 ns | 0.0592 ns | 0.0495 ns |
    | GetHashForChannelBinding_New |    1.2.840.10045.4.1 |  1.719 ns | 0.0136 ns | 0.0120 ns |
    | GetHashForChannelBinding_Old |    1.2.840.10045.4.1 |  7.439 ns | 0.0399 ns | 0.0354 ns |
    | GetHashForChannelBinding_New |  1.2.840.10045.4.3.2 |  2.143 ns | 0.0154 ns | 0.0144 ns |
    | GetHashForChannelBinding_Old |  1.2.840.10045.4.3.2 |  9.074 ns | 0.0414 ns | 0.0345 ns |
    | GetHashForChannelBinding_New |  1.2.840.10045.4.3.3 |  2.139 ns | 0.0125 ns | 0.0110 ns |
    | GetHashForChannelBinding_Old |  1.2.840.10045.4.3.3 |  9.110 ns | 0.0426 ns | 0.0398 ns |
    | GetHashForChannelBinding_New |  1.2.840.10045.4.3.4 |  2.341 ns | 0.0091 ns | 0.0081 ns |
    | GetHashForChannelBinding_Old |  1.2.840.10045.4.3.4 |  9.111 ns | 0.0581 ns | 0.0544 ns |
    | GetHashForChannelBinding_New | 1.2.8(...).1.11 [21] |  2.126 ns | 0.0124 ns | 0.0103 ns |
    | GetHashForChannelBinding_Old | 1.2.8(...).1.11 [21] | 10.485 ns | 0.0325 ns | 0.0304 ns |
    | GetHashForChannelBinding_New | 1.2.8(...).1.12 [21] |  2.140 ns | 0.0200 ns | 0.0177 ns |
    | GetHashForChannelBinding_Old | 1.2.8(...).1.12 [21] | 10.404 ns | 0.0374 ns | 0.0332 ns |
    | GetHashForChannelBinding_New | 1.2.8(...).1.13 [21] |  2.186 ns | 0.0555 ns | 0.0433 ns |
    | GetHashForChannelBinding_Old | 1.2.8(...).1.13 [21] | 10.754 ns | 0.2077 ns | 0.1943 ns |
    | GetHashForChannelBinding_New | 1.2.840.113549.1.1.4 |  1.936 ns | 0.0217 ns | 0.0192 ns |
    | GetHashForChannelBinding_Old | 1.2.840.113549.1.1.4 |  9.744 ns | 0.0748 ns | 0.0700 ns |
    | GetHashForChannelBinding_New | 1.2.840.113549.1.1.5 |  1.971 ns | 0.0192 ns | 0.0179 ns |
    | GetHashForChannelBinding_Old | 1.2.840.113549.1.1.5 | 10.155 ns | 0.2438 ns | 0.4333 ns |
    | GetHashForChannelBinding_New |   1.2.840.113549.2.5 |  1.743 ns | 0.0278 ns | 0.0260 ns |
    | GetHashForChannelBinding_Old |   1.2.840.113549.2.5 |  8.762 ns | 0.2161 ns | 0.3300 ns |
    | GetHashForChannelBinding_New |        1.3.14.3.2.26 |  1.713 ns | 0.0169 ns | 0.0141 ns |
    | GetHashForChannelBinding_Old |        1.3.14.3.2.26 |  6.084 ns | 0.1349 ns | 0.1262 ns |
    | GetHashForChannelBinding_New | 2.16.(...)4.2.1 [22] |  2.350 ns | 0.0289 ns | 0.0271 ns |
    | GetHashForChannelBinding_Old | 2.16.(...)4.2.1 [22] | 11.460 ns | 0.0751 ns | 0.0666 ns |
    | GetHashForChannelBinding_New | 2.16.(...)4.2.2 [22] |  2.138 ns | 0.0160 ns | 0.0142 ns |
    | GetHashForChannelBinding_Old | 2.16.(...)4.2.2 [22] | 11.482 ns | 0.0650 ns | 0.0543 ns |
    | GetHashForChannelBinding_New | 2.16.(...)4.2.3 [22] |  2.169 ns | 0.0274 ns | 0.0256 ns |
    | GetHashForChannelBinding_Old | 2.16.(...)4.2.3 [22] | 11.454 ns | 0.0524 ns | 0.0438 ns |
    */
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
    /*
    |                           Method |      Mean |    Error |   StdDev |
    |--------------------------------- |----------:|---------:|---------:|
    | GetHashForChannelBinding_New_Mix |  68.42 ns | 0.417 ns | 0.390 ns |
    | GetHashForChannelBinding_Old_Mix | 167.26 ns | 1.549 ns | 1.373 ns |
    */
    [Benchmark]
    public string GetHashForChannelBinding_New_Mix() => NewRoslyn.GetHashForChannelBinding_Mix();
    [Benchmark]
    public string GetHashForChannelBinding_Old_Mix() => OldRoslyn.GetHashForChannelBinding_Mix();
}

public partial class LengthVsHashCode_WriteEntityRef
{
    /*
    |             Method | Value |     Mean |     Error |    StdDev |   Median |
    |------------------- |------ |---------:|----------:|----------:|---------:|
    | WriteEntityRef_New |   amp | 1.626 ns | 0.0761 ns | 0.1067 ns | 1.590 ns |
    | WriteEntityRef_Old |   amp | 1.582 ns | 0.0349 ns | 0.0291 ns | 1.576 ns |
    | WriteEntityRef_New |  apos | 2.043 ns | 0.0206 ns | 0.0172 ns | 2.040 ns |
    | WriteEntityRef_Old |  apos | 1.488 ns | 0.0303 ns | 0.0253 ns | 1.488 ns |
    | WriteEntityRef_New |    gt | 1.510 ns | 0.0421 ns | 0.0373 ns | 1.511 ns |
    | WriteEntityRef_Old |    gt | 1.596 ns | 0.0708 ns | 0.1852 ns | 1.521 ns |
    | WriteEntityRef_New |    lt | 1.530 ns | 0.0498 ns | 0.0416 ns | 1.515 ns |
    | WriteEntityRef_Old |    lt | 1.950 ns | 0.0364 ns | 0.0304 ns | 1.947 ns |
    | WriteEntityRef_New |  quot | 1.972 ns | 0.0287 ns | 0.0254 ns | 1.975 ns |
    | WriteEntityRef_Old |  quot | 1.973 ns | 0.0608 ns | 0.0539 ns | 1.962 ns |
    */
    [Params("amp", "apos", "gt", "lt", "quot")]
    public string Value { get; set; }

    [Benchmark]
    public string WriteEntityRef_New() => NewRoslyn.WriteEntityRef(Value);
    [Benchmark]
    public string WriteEntityRef_Old() => OldRoslyn.WriteEntityRef(Value);
}

public partial class LengthVsHashCode_WriteEntityRef_Mix
{
    /*
    |                 Method |     Mean |    Error |   StdDev |
    |----------------------- |---------:|---------:|---------:|
    | WriteEntityRef_New_Mix | 22.24 ns | 0.420 ns | 0.393 ns |
    | WriteEntityRef_Old_Mix | 19.46 ns | 0.430 ns | 0.695 ns |
     */
    [Benchmark]
    public string WriteEntityRef_New_Mix() => NewRoslyn.WriteEntityRef_Mix();
    [Benchmark]
    public string WriteEntityRef_Old_Mix() => OldRoslyn.WriteEntityRef_Mix();
}

public partial class LengthVsHashCode_FunctionAvailable
{
    /*
    |                Method |            Value |     Mean |     Error |    StdDev |
    |---------------------- |----------------- |---------:|----------:|----------:|
    | FunctionAvailable_New |          boolean | 1.949 ns | 0.0260 ns | 0.0217 ns |
    | FunctionAvailable_Old |          boolean | 4.526 ns | 0.0405 ns | 0.0379 ns |
    | FunctionAvailable_New |          ceiling | 1.926 ns | 0.0183 ns | 0.0162 ns |
    | FunctionAvailable_Old |          ceiling | 3.970 ns | 0.0179 ns | 0.0167 ns |
    | FunctionAvailable_New |           concat | 2.120 ns | 0.0083 ns | 0.0069 ns |
    | FunctionAvailable_Old |           concat | 4.112 ns | 0.0123 ns | 0.0096 ns |
    | FunctionAvailable_New |         contains | 2.130 ns | 0.0124 ns | 0.0097 ns |
    | FunctionAvailable_Old |         contains | 4.537 ns | 0.0189 ns | 0.0158 ns |
    | FunctionAvailable_New |            count | 2.156 ns | 0.0358 ns | 0.0317 ns |
    | FunctionAvailable_Old |            count | 3.699 ns | 0.0442 ns | 0.0413 ns |
    | FunctionAvailable_New |            false | 2.031 ns | 0.0140 ns | 0.0124 ns |
    | FunctionAvailable_Old |            false | 3.511 ns | 0.0515 ns | 0.0482 ns |
    | FunctionAvailable_New |            floor | 2.342 ns | 0.0136 ns | 0.0114 ns |
    | FunctionAvailable_Old |            floor | 3.495 ns | 0.0337 ns | 0.0316 ns |
    | FunctionAvailable_New |               id | 1.702 ns | 0.0076 ns | 0.0067 ns |
    | FunctionAvailable_Old |               id | 3.005 ns | 0.0186 ns | 0.0155 ns |
    | FunctionAvailable_New |             lang | 1.950 ns | 0.0114 ns | 0.0101 ns |
    | FunctionAvailable_Old |             lang | 3.266 ns | 0.0214 ns | 0.0189 ns |
    | FunctionAvailable_New |             last | 2.129 ns | 0.0162 ns | 0.0144 ns |
    | FunctionAvailable_Old |             last | 3.468 ns | 0.0082 ns | 0.0072 ns |
    | FunctionAvailable_New |       local-name | 1.920 ns | 0.0133 ns | 0.0118 ns |
    | FunctionAvailable_Old |       local-name | 4.555 ns | 0.0217 ns | 0.0192 ns |
    | FunctionAvailable_New |             name | 2.131 ns | 0.0129 ns | 0.0121 ns |
    | FunctionAvailable_Old |             name | 3.470 ns | 0.0128 ns | 0.0100 ns |
    | FunctionAvailable_New |    namespace-uri | 2.346 ns | 0.0134 ns | 0.0112 ns |
    | FunctionAvailable_Old |    namespace-uri | 6.195 ns | 0.0274 ns | 0.0214 ns |
    | FunctionAvailable_New |  normalize-space | 2.139 ns | 0.0194 ns | 0.0182 ns |
    | FunctionAvailable_Old |  normalize-space | 6.936 ns | 0.0459 ns | 0.0383 ns |
    | FunctionAvailable_New |              not | 2.352 ns | 0.0259 ns | 0.0230 ns |
    | FunctionAvailable_Old |              not | 3.007 ns | 0.0182 ns | 0.0161 ns |
    | FunctionAvailable_New |           number | 2.139 ns | 0.0181 ns | 0.0170 ns |
    | FunctionAvailable_Old |           number | 3.567 ns | 0.0310 ns | 0.0275 ns |
    | FunctionAvailable_New |         position | 1.915 ns | 0.0060 ns | 0.0053 ns |
    | FunctionAvailable_Old |         position | 4.145 ns | 0.0116 ns | 0.0103 ns |
    | FunctionAvailable_New |            round | 1.919 ns | 0.0139 ns | 0.0130 ns |
    | FunctionAvailable_Old |            round | 3.333 ns | 0.0264 ns | 0.0220 ns |
    | FunctionAvailable_New |      starts-with | 1.923 ns | 0.0189 ns | 0.0167 ns |
    | FunctionAvailable_Old |      starts-with | 5.184 ns | 0.0279 ns | 0.0261 ns |
    | FunctionAvailable_New |           string | 1.932 ns | 0.0188 ns | 0.0175 ns |
    | FunctionAvailable_Old |           string | 3.697 ns | 0.0137 ns | 0.0122 ns |
    | FunctionAvailable_New |    string-length | 2.129 ns | 0.0091 ns | 0.0076 ns |
    | FunctionAvailable_Old |    string-length | 6.058 ns | 0.0733 ns | 0.0650 ns |
    | FunctionAvailable_New |        substring | 2.136 ns | 0.0203 ns | 0.0180 ns |
    | FunctionAvailable_Old |        substring | 4.756 ns | 0.0255 ns | 0.0239 ns |
    | FunctionAvailable_New |  substring-after | 1.923 ns | 0.0143 ns | 0.0119 ns |
    | FunctionAvailable_Old |  substring-after | 7.029 ns | 0.0651 ns | 0.0543 ns |
    | FunctionAvailable_New | substring-before | 1.914 ns | 0.0086 ns | 0.0072 ns |
    | FunctionAvailable_Old | substring-before | 7.445 ns | 0.0173 ns | 0.0154 ns |
    | FunctionAvailable_New |              sum | 2.131 ns | 0.0139 ns | 0.0116 ns |
    | FunctionAvailable_Old |              sum | 3.642 ns | 0.0298 ns | 0.0279 ns |
    | FunctionAvailable_New |        translate | 1.932 ns | 0.0171 ns | 0.0152 ns |
    | FunctionAvailable_Old |        translate | 4.532 ns | 0.0095 ns | 0.0089 ns |
    | FunctionAvailable_New |             true | 2.133 ns | 0.0264 ns | 0.0247 ns |
    | FunctionAvailable_Old |             true | 3.254 ns | 0.0080 ns | 0.0071 ns |
     */
    [Params("last", "position", "name", "namespace-uri", "local-name", "count", "id",
             "string", "concat", "starts-with", "contains", "substring-before", "substring-after",
             "substring", "string-length", "normalize-space", "translate", "boolean", "not", "true",
             "false", "lang", "number", "sum", "floor", "ceiling", "round")]
    public string Value { get; set; }

    [Benchmark]
    public string FunctionAvailable_New() => NewRoslyn.FunctionAvailable(Value);
    [Benchmark]
    public string FunctionAvailable_Old() => OldRoslyn.FunctionAvailable(Value);
}

public partial class LengthVsHashCode_FunctionAvailable_Mix
{
    /*
    |                    Method |     Mean |   Error |  StdDev |
    |-------------------------- |---------:|--------:|--------:|
    | FunctionAvailable_New_Mix | 122.2 ns | 1.04 ns | 0.97 ns |
    | FunctionAvailable_Old_Mix | 164.8 ns | 0.61 ns | 0.57 ns |
     */
    [Benchmark]
    public string FunctionAvailable_New_Mix() => NewRoslyn.FunctionAvailable_Mix();
    [Benchmark]
    public string FunctionAvailable_Old_Mix() => OldRoslyn.FunctionAvailable_Mix();
}

public partial class LengthVsHashCode_NormalizeTimeZone
{
    /*
    |                Method | Value |     Mean |     Error |    StdDev |
    |---------------------- |------ |---------:|----------:|----------:|
    | NormalizeTimeZone_New |     A | 2.026 ns | 0.0509 ns | 0.0476 ns |
    | NormalizeTimeZone_Old |     A | 3.128 ns | 0.0993 ns | 0.0928 ns |
    | NormalizeTimeZone_New |     B | 2.008 ns | 0.0728 ns | 0.0646 ns |
    | NormalizeTimeZone_Old |     B | 3.435 ns | 0.0428 ns | 0.0357 ns |
    | NormalizeTimeZone_New |     C | 2.294 ns | 0.0267 ns | 0.0237 ns |
    | NormalizeTimeZone_Old |     C | 2.781 ns | 0.0331 ns | 0.0310 ns |
    | NormalizeTimeZone_New |   CDT | 2.357 ns | 0.0314 ns | 0.0293 ns |
    | NormalizeTimeZone_Old |   CDT | 3.419 ns | 0.0363 ns | 0.0340 ns |
    | NormalizeTimeZone_New |   CST | 2.581 ns | 0.0317 ns | 0.0281 ns |
    | NormalizeTimeZone_Old |   CST | 3.415 ns | 0.0320 ns | 0.0300 ns |
    | NormalizeTimeZone_New |     D | 1.964 ns | 0.0182 ns | 0.0152 ns |
    | NormalizeTimeZone_Old |     D | 2.769 ns | 0.0344 ns | 0.0321 ns |
    | NormalizeTimeZone_New |     E | 1.961 ns | 0.0229 ns | 0.0191 ns |
    | NormalizeTimeZone_Old |     E | 2.985 ns | 0.0185 ns | 0.0173 ns |
    | NormalizeTimeZone_New |   EDT | 2.124 ns | 0.0281 ns | 0.0263 ns |
    | NormalizeTimeZone_Old |   EDT | 3.606 ns | 0.0339 ns | 0.0300 ns |
    | NormalizeTimeZone_New |   EST | 2.595 ns | 0.0362 ns | 0.0338 ns |
    | NormalizeTimeZone_Old |   EST | 3.843 ns | 0.0443 ns | 0.0415 ns |
    | NormalizeTimeZone_New |     F | 2.227 ns | 0.0571 ns | 0.0534 ns |
    | NormalizeTimeZone_Old |     F | 2.992 ns | 0.0491 ns | 0.0460 ns |
    | NormalizeTimeZone_New |     G | 1.989 ns | 0.0526 ns | 0.0492 ns |
    | NormalizeTimeZone_Old |     G | 3.174 ns | 0.0282 ns | 0.0264 ns |
    | NormalizeTimeZone_New |   GMT | 2.127 ns | 0.0103 ns | 0.0091 ns |
    | NormalizeTimeZone_Old |   GMT | 3.598 ns | 0.0211 ns | 0.0187 ns |
    | NormalizeTimeZone_New |     H | 1.978 ns | 0.0162 ns | 0.0151 ns |
    | NormalizeTimeZone_Old |     H | 3.190 ns | 0.0256 ns | 0.0227 ns |
    | NormalizeTimeZone_New |     I | 1.971 ns | 0.0119 ns | 0.0099 ns |
    | NormalizeTimeZone_Old |     I | 2.774 ns | 0.0227 ns | 0.0201 ns |
    | NormalizeTimeZone_New |     K | 2.191 ns | 0.0161 ns | 0.0142 ns |
    | NormalizeTimeZone_Old |     K | 2.565 ns | 0.0283 ns | 0.0264 ns |
    | NormalizeTimeZone_New |     L | 2.111 ns | 0.0364 ns | 0.0340 ns |
    | NormalizeTimeZone_Old |     L | 2.367 ns | 0.0188 ns | 0.0167 ns |
    | NormalizeTimeZone_New |     M | 1.972 ns | 0.0212 ns | 0.0198 ns |
    | NormalizeTimeZone_Old |     M | 3.177 ns | 0.0223 ns | 0.0208 ns |
    | NormalizeTimeZone_New |   MDT | 2.530 ns | 0.0111 ns | 0.0093 ns |
    | NormalizeTimeZone_Old |   MDT | 3.212 ns | 0.0167 ns | 0.0148 ns |
    | NormalizeTimeZone_New |   MST | 2.592 ns | 0.0131 ns | 0.0123 ns |
    | NormalizeTimeZone_Old |   MST | 2.995 ns | 0.0097 ns | 0.0091 ns |
    | NormalizeTimeZone_New |     N | 2.193 ns | 0.0135 ns | 0.0126 ns |
    | NormalizeTimeZone_Old |     N | 2.987 ns | 0.0230 ns | 0.0215 ns |
    | NormalizeTimeZone_New |     O | 1.976 ns | 0.0184 ns | 0.0163 ns |
    | NormalizeTimeZone_Old |     O | 2.343 ns | 0.0189 ns | 0.0167 ns |
    | NormalizeTimeZone_New |     P | 2.008 ns | 0.0712 ns | 0.0666 ns |
    | NormalizeTimeZone_Old |     P | 3.175 ns | 0.0222 ns | 0.0197 ns |
    | NormalizeTimeZone_New |   PDT | 2.129 ns | 0.0289 ns | 0.0270 ns |
    | NormalizeTimeZone_Old |   PDT | 3.628 ns | 0.0457 ns | 0.0405 ns |
    | NormalizeTimeZone_New |   PST | 2.781 ns | 0.0120 ns | 0.0106 ns |
    | NormalizeTimeZone_Old |   PST | 3.212 ns | 0.0293 ns | 0.0274 ns |
    | NormalizeTimeZone_New |     Q | 1.974 ns | 0.0179 ns | 0.0167 ns |
    | NormalizeTimeZone_Old |     Q | 2.767 ns | 0.0191 ns | 0.0179 ns |
    | NormalizeTimeZone_New |     R | 2.186 ns | 0.0111 ns | 0.0098 ns |
    | NormalizeTimeZone_Old |     R | 2.970 ns | 0.0107 ns | 0.0094 ns |
    | NormalizeTimeZone_New |     S | 1.989 ns | 0.0213 ns | 0.0199 ns |
    | NormalizeTimeZone_Old |     S | 2.967 ns | 0.0123 ns | 0.0109 ns |
    | NormalizeTimeZone_New |     T | 1.961 ns | 0.0149 ns | 0.0132 ns |
    | NormalizeTimeZone_Old |     T | 2.995 ns | 0.0415 ns | 0.0388 ns |
    | NormalizeTimeZone_New |     U | 1.981 ns | 0.0137 ns | 0.0128 ns |
    | NormalizeTimeZone_Old |     U | 2.950 ns | 0.0245 ns | 0.0230 ns |
    | NormalizeTimeZone_New |    UT | 1.676 ns | 0.0076 ns | 0.0068 ns |
    | NormalizeTimeZone_Old |    UT | 2.980 ns | 0.0214 ns | 0.0190 ns |
    | NormalizeTimeZone_New |     V | 2.198 ns | 0.0208 ns | 0.0194 ns |
    | NormalizeTimeZone_Old |     V | 2.984 ns | 0.0206 ns | 0.0172 ns |
    | NormalizeTimeZone_New |     W | 2.001 ns | 0.0272 ns | 0.0227 ns |
    | NormalizeTimeZone_Old |     W | 2.750 ns | 0.0176 ns | 0.0147 ns |
    | NormalizeTimeZone_New |     X | 1.968 ns | 0.0132 ns | 0.0123 ns |
    | NormalizeTimeZone_Old |     X | 2.964 ns | 0.0172 ns | 0.0153 ns |
    | NormalizeTimeZone_New |     Y | 1.976 ns | 0.0127 ns | 0.0106 ns |
    | NormalizeTimeZone_Old |     Y | 2.770 ns | 0.0284 ns | 0.0266 ns |
    | NormalizeTimeZone_New |     Z | 1.980 ns | 0.0204 ns | 0.0191 ns |
    | NormalizeTimeZone_Old |     Z | 3.750 ns | 0.0335 ns | 0.0314 ns |
    */
    [Params("UT", "Z", "GMT", "A", "B", "C", "D", "EDT", "E", "EST", "CDT", "F", "CST", "MDT",
        "G", "MST", "PDT", "H", "PST", "I", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
        "U", "V", "W", "X", "Y")]
    public string Value { get; set; }

    [Benchmark]
    public string NormalizeTimeZone_New() => NewRoslyn.NormalizeTimeZone(Value);
    [Benchmark]
    public string NormalizeTimeZone_Old() => OldRoslyn.NormalizeTimeZone(Value);
}

public partial class LengthVsHashCode_NormalizeTimeZone_Mix
{
    /*
    |                    Method |     Mean |   Error |  StdDev |
    |-------------------------- |---------:|--------:|--------:|
    | NormalizeTimeZone_New_Mix | 159.2 ns | 1.25 ns | 0.98 ns |
    | NormalizeTimeZone_Old_Mix | 174.8 ns | 2.82 ns | 2.50 ns |
    */
    [Benchmark]
    public string NormalizeTimeZone_New_Mix() => NewRoslyn.NormalizeTimeZone_Mix();
    [Benchmark]
    public string NormalizeTimeZone_Old_Mix() => OldRoslyn.NormalizeTimeZone_Mix();
}

public partial class LengthVsHashCode_AcceptCommand
{
    /*
    |            Method |                Value |      Mean |     Error |    StdDev |
    |------------------ |--------------------- |----------:|----------:|----------:|
    | AcceptCommand_New |      Debugger.enable |  2.274 ns | 0.0578 ns | 0.0513 ns |
    | AcceptCommand_Old |      Debugger.enable |  7.062 ns | 0.0469 ns | 0.0416 ns |
    | AcceptCommand_New | Debug(...)Frame [28] |  1.829 ns | 0.0608 ns | 0.0569 ns |
    | AcceptCommand_Old | Debug(...)Frame [28] | 16.830 ns | 0.1216 ns | 0.1078 ns |
    | AcceptCommand_New | Debug(...)oints [31] |  1.872 ns | 0.0357 ns | 0.0316 ns |
    | AcceptCommand_Old | Debug(...)oints [31] | 18.719 ns | 0.1316 ns | 0.1231 ns |
    | AcceptCommand_New | Debug(...)ource [24] |  1.962 ns | 0.0114 ns | 0.0101 ns |
    | AcceptCommand_Old | Debug(...)ource [24] | 13.697 ns | 0.0813 ns | 0.0721 ns |
    | AcceptCommand_New | Debug(...)point [25] |  2.202 ns | 0.0405 ns | 0.0379 ns |
    | AcceptCommand_Old | Debug(...)point [25] | 14.572 ns | 0.1128 ns | 0.1055 ns |
    | AcceptCommand_New |      Debugger.resume |  1.967 ns | 0.0129 ns | 0.0108 ns |
    | AcceptCommand_Old |      Debugger.resume |  6.945 ns | 0.0093 ns | 0.0072 ns |
    | AcceptCommand_New | Debug(...)point [22] |  2.013 ns | 0.0583 ns | 0.0545 ns |
    | AcceptCommand_Old | Debug(...)point [22] | 11.640 ns | 0.0855 ns | 0.0799 ns |
    | AcceptCommand_New | Debug(...)ByUrl [27] |  2.231 ns | 0.0474 ns | 0.0420 ns |
    | AcceptCommand_Old | Debug(...)ByUrl [27] | 15.965 ns | 0.1109 ns | 0.1038 ns |
    | AcceptCommand_New | Debug(...)tions [29] |  1.837 ns | 0.0445 ns | 0.0394 ns |
    | AcceptCommand_Old | Debug(...)tions [29] | 17.300 ns | 0.1592 ns | 0.1489 ns |
    | AcceptCommand_New | Debug(...)Value [25] |  1.975 ns | 0.0428 ns | 0.0400 ns |
    | AcceptCommand_Old | Debug(...)Value [25] | 14.544 ns | 0.0821 ns | 0.0768 ns |
    | AcceptCommand_New |    Debugger.stepInto |  1.994 ns | 0.0515 ns | 0.0482 ns |
    | AcceptCommand_Old |    Debugger.stepInto |  7.764 ns | 0.0301 ns | 0.0267 ns |
    | AcceptCommand_New |     Debugger.stepOut |  1.949 ns | 0.0089 ns | 0.0070 ns |
    | AcceptCommand_Old |     Debugger.stepOut |  7.615 ns | 0.0914 ns | 0.0855 ns |
    | AcceptCommand_New |    Debugger.stepOver |  2.014 ns | 0.0455 ns | 0.0425 ns |
    | AcceptCommand_Old |    Debugger.stepOver |  8.023 ns | 0.0458 ns | 0.0406 ns |
    | AcceptCommand_New | Dotne(...)erUrl [33] |  1.991 ns | 0.0365 ns | 0.0341 ns |
    | AcceptCommand_Old | Dotne(...)erUrl [33] | 20.172 ns | 0.0527 ns | 0.0467 ns |
    | AcceptCommand_New | Dotne(...)dates [27] |  1.845 ns | 0.0642 ns | 0.0600 ns |
    | AcceptCommand_Old | Dotne(...)dates [27] | 15.985 ns | 0.1013 ns | 0.0948 ns |
    | AcceptCommand_New | Dotne(...)ation [32] |  1.854 ns | 0.0393 ns | 0.0328 ns |
    | AcceptCommand_Old | Dotne(...)ation [32] | 18.840 ns | 0.0828 ns | 0.0647 ns |
    | AcceptCommand_New | Dotne(...)perty [34] |  1.982 ns | 0.0480 ns | 0.0449 ns |
    | AcceptCommand_Old | Dotne(...)perty [34] | 20.452 ns | 0.1109 ns | 0.1037 ns |
    | AcceptCommand_New | Dotne(...)extIP [24] |  2.004 ns | 0.0507 ns | 0.0474 ns |
    | AcceptCommand_Old | Dotne(...)extIP [24] | 13.996 ns | 0.0448 ns | 0.0419 ns |
    | AcceptCommand_New | Runti(...)ionOn [22] |  2.009 ns | 0.0536 ns | 0.0501 ns |
    | AcceptCommand_Old | Runti(...)ionOn [22] | 11.398 ns | 0.0885 ns | 0.0828 ns |
    | AcceptCommand_New | Runti(...)cript [21] |  1.987 ns | 0.0400 ns | 0.0374 ns |
    | AcceptCommand_Old | Runti(...)cript [21] | 10.612 ns | 0.0561 ns | 0.0524 ns |
    | AcceptCommand_New |     Runtime.evaluate |  1.831 ns | 0.0342 ns | 0.0320 ns |
    | AcceptCommand_Old |     Runtime.evaluate |  7.195 ns | 0.0133 ns | 0.0104 ns |
    | AcceptCommand_New | Runti(...)rties [21] |  1.982 ns | 0.0341 ns | 0.0303 ns |
    | AcceptCommand_Old | Runti(...)rties [21] | 10.931 ns | 0.0588 ns | 0.0550 ns |
    | AcceptCommand_New | Runti(...)bject [21] |  2.420 ns | 0.0676 ns | 0.0633 ns |
    | AcceptCommand_Old | Runti(...)bject [21] | 10.649 ns | 0.0874 ns | 0.0818 ns |
    | AcceptCommand_New | Targe(...)arget [21] |  2.033 ns | 0.0205 ns | 0.0171 ns |
    | AcceptCommand_Old | Targe(...)arget [21] | 10.546 ns | 0.0784 ns | 0.0734 ns |
     */
    [Params("Target.attachToTarget", "Debugger.enable", "Debugger.getScriptSource", "Runtime.compileScript", "Debugger.getPossibleBreakpoints",
        "Debugger.setBreakpoint", "Debugger.setBreakpointByUrl", "Debugger.removeBreakpoint", "Debugger.resume", "Debugger.stepInto",
        "Debugger.setVariableValue", "Debugger.stepOut", "Debugger.stepOver", "Runtime.evaluate", "Debugger.evaluateOnCallFrame",
        "Runtime.getProperties", "Runtime.releaseObject", "Debugger.setPauseOnExceptions", "DotnetDebugger.setDebuggerProperty",
        "DotnetDebugger.setNextIP", "DotnetDebugger.applyUpdates", "DotnetDebugger.addSymbolServerUrl", "DotnetDebugger.getMethodLocation",
        "Runtime.callFunctionOn")]
    public string Value { get; set; }

    [Benchmark]
    public string AcceptCommand_New() => NewRoslyn.AcceptCommand(Value);
    [Benchmark]
    public string AcceptCommand_Old() => OldRoslyn.AcceptCommand(Value);
}

public partial class LengthVsHashCode_AcceptCommand_Mix
{
    /*
    |                Method |     Mean |   Error |  StdDev |
    |---------------------- |---------:|--------:|--------:|
    | AcceptCommand_New_Mix | 104.4 ns | 0.66 ns | 0.59 ns |
    | AcceptCommand_Old_Mix | 349.0 ns | 0.99 ns | 0.92 ns |
    */
    [Benchmark]
    public string AcceptCommand_New_Mix() => NewRoslyn.AcceptCommand_Mix();
    [Benchmark]
    public string AcceptCommand_Old_Mix() => OldRoslyn.AcceptCommand_Mix();
}


public partial class LengthVsHashCode_EmitIL
{
    /*
    |      Method |              Value |     Mean |     Error |    StdDev |
    |------------ |------------------- |---------:|----------:|----------:|
    | EmiltIL_New |                Add | 1.754 ns | 0.0044 ns | 0.0041 ns |
    | EmiltIL_Old |                Add | 4.470 ns | 0.0191 ns | 0.0179 ns |
    | EmiltIL_New |      AddByteOffset | 1.960 ns | 0.0094 ns | 0.0078 ns |
    | EmiltIL_Old |      AddByteOffset | 6.777 ns | 0.0200 ns | 0.0177 ns |
    | EmiltIL_New |            AreSame | 2.175 ns | 0.0108 ns | 0.0096 ns |
    | EmiltIL_Old |            AreSame | 4.940 ns | 0.0113 ns | 0.0094 ns |
    | EmiltIL_New |                 As | 2.169 ns | 0.0078 ns | 0.0069 ns |
    | EmiltIL_Old |                 As | 3.634 ns | 0.0105 ns | 0.0093 ns |
    | EmiltIL_New |          AsPointer | 1.941 ns | 0.0069 ns | 0.0061 ns |
    | EmiltIL_Old |          AsPointer | 4.767 ns | 0.0157 ns | 0.0131 ns |
    | EmiltIL_New |              AsRef | 2.609 ns | 0.0215 ns | 0.0201 ns |
    | EmiltIL_Old |              AsRef | 4.759 ns | 0.0301 ns | 0.0251 ns |
    | EmiltIL_New |         ByteOffset | 1.755 ns | 0.0082 ns | 0.0073 ns |
    | EmiltIL_Old |         ByteOffset | 4.985 ns | 0.0166 ns | 0.0155 ns |
    | EmiltIL_New |               Copy | 1.985 ns | 0.0503 ns | 0.0446 ns |
    | EmiltIL_Old |               Copy | 4.087 ns | 0.0061 ns | 0.0048 ns |
    | EmiltIL_New |          CopyBlock | 1.966 ns | 0.0118 ns | 0.0110 ns |
    | EmiltIL_Old |          CopyBlock | 4.974 ns | 0.0168 ns | 0.0149 ns |
    | EmiltIL_New | CopyBlockUnaligned | 1.953 ns | 0.0054 ns | 0.0048 ns |
    | EmiltIL_Old | CopyBlockUnaligned | 8.511 ns | 0.0402 ns | 0.0357 ns |
    | EmiltIL_New |          InitBlock | 2.179 ns | 0.0089 ns | 0.0083 ns |
    | EmiltIL_Old |          InitBlock | 5.792 ns | 0.0211 ns | 0.0165 ns |
    | EmiltIL_New | InitBlockUnaligned | 1.961 ns | 0.0063 ns | 0.0052 ns |
    | EmiltIL_Old | InitBlockUnaligned | 8.355 ns | 0.0084 ns | 0.0075 ns |
    | EmiltIL_New |          IsNullRef | 1.955 ns | 0.0101 ns | 0.0090 ns |
    | EmiltIL_Old |          IsNullRef | 5.183 ns | 0.0243 ns | 0.0203 ns |
    | EmiltIL_New |            NullRef | 1.751 ns | 0.0098 ns | 0.0082 ns |
    | EmiltIL_Old |            NullRef | 4.728 ns | 0.0138 ns | 0.0107 ns |
    | EmiltIL_New |               Read | 1.751 ns | 0.0120 ns | 0.0100 ns |
    | EmiltIL_Old |               Read | 3.890 ns | 0.0124 ns | 0.0104 ns |
    | EmiltIL_New |      ReadUnaligned | 1.970 ns | 0.0175 ns | 0.0164 ns |
    | EmiltIL_Old |      ReadUnaligned | 6.210 ns | 0.0532 ns | 0.0498 ns |
    | EmiltIL_New |           SkipInit | 1.950 ns | 0.0068 ns | 0.0053 ns |
    | EmiltIL_Old |           SkipInit | 5.350 ns | 0.0189 ns | 0.0158 ns |
    | EmiltIL_New |           Subtract | 1.955 ns | 0.0077 ns | 0.0068 ns |
    | EmiltIL_Old |           Subtract | 4.745 ns | 0.0255 ns | 0.0239 ns |
    | EmiltIL_New | SubtractByteOffset | 1.961 ns | 0.0044 ns | 0.0037 ns |
    | EmiltIL_Old | SubtractByteOffset | 8.497 ns | 0.0566 ns | 0.0502 ns |
    | EmiltIL_New |              Unbox | 2.178 ns | 0.0075 ns | 0.0063 ns |
    | EmiltIL_Old |              Unbox | 4.710 ns | 0.0093 ns | 0.0078 ns |
    | EmiltIL_New |              Write | 1.968 ns | 0.0212 ns | 0.0177 ns |
    | EmiltIL_Old |              Write | 4.303 ns | 0.0075 ns | 0.0059 ns |
    | EmiltIL_New |     WriteUnaligned | 1.754 ns | 0.0069 ns | 0.0058 ns |
    | EmiltIL_Old |     WriteUnaligned | 6.869 ns | 0.0474 ns | 0.0420 ns |
    */
    [Params("AsPointer", "As", "AsRef", "Add", "AddByteOffset", "Copy", "CopyBlock", "CopyBlockUnaligned",
        "InitBlock", "InitBlockUnaligned", "Read", "Write", "ReadUnaligned", "WriteUnaligned", "AreSame",
        "ByteOffset", "NullRef", "IsNullRef", "SkipInit", "Subtract", "SubtractByteOffset", "Unbox")]
    public string Value { get; set; }

    [Benchmark]
    public string EmiltIL_New() => NewRoslyn.EmitIL(Value);
    [Benchmark]
    public string EmiltIL_Old() => OldRoslyn.EmitIL(Value);
}

public partial class LengthVsHashCode_EmitIL_Mix
{
    /*
    |          Method |      Mean |    Error |   StdDev |
    |---------------- |----------:|---------:|---------:|
    | EmiltIL_New_Mix |  92.81 ns | 0.451 ns | 0.400 ns |
    | EmiltIL_Old_Mix | 158.47 ns | 1.056 ns | 0.936 ns |
    */
    [Benchmark]
    public string EmiltIL_New_Mix() => NewRoslyn.EmitIL_Mix();
    [Benchmark]
    public string EmiltIL_Old_Mix() => OldRoslyn.EmitIL_Mix();
}


public partial class LengthVsHashCode_GetWellKnownType
{
    /*
    |               Method |                Value |      Mean |     Error |    StdDev |    Median |
    |--------------------- |--------------------- |----------:|----------:|----------:|----------:|
    | GetWellKnownType_New |                Array |  1.717 ns | 0.0117 ns | 0.0103 ns |  1.720 ns |
    | GetWellKnownType_Old |                Array |  3.499 ns | 0.0257 ns | 0.0228 ns |  3.494 ns |
    | GetWellKnownType_New |            Attribute |  1.726 ns | 0.0113 ns | 0.0100 ns |  1.724 ns |
    | GetWellKnownType_Old |            Attribute |  4.550 ns | 0.1286 ns | 0.2769 ns |  4.428 ns |
    | GetWellKnownType_New | NotSu(...)ption [21] |  1.571 ns | 0.0104 ns | 0.0097 ns |  1.568 ns |
    | GetWellKnownType_Old | NotSu(...)ption [21] | 10.437 ns | 0.0322 ns | 0.0301 ns | 10.432 ns |
    | GetWellKnownType_New |           Nullable`1 |  1.941 ns | 0.0296 ns | 0.0277 ns |  1.936 ns |
    | GetWellKnownType_Old |           Nullable`1 |  4.738 ns | 0.0224 ns | 0.0198 ns |  4.732 ns |
    | GetWellKnownType_New |               Object |  2.156 ns | 0.0147 ns | 0.0131 ns |  2.157 ns |
    | GetWellKnownType_Old |               Object |  3.940 ns | 0.0589 ns | 0.0522 ns |  3.915 ns |
    | GetWellKnownType_New |               String |  1.913 ns | 0.0040 ns | 0.0035 ns |  1.912 ns |
    | GetWellKnownType_Old |               String |  4.124 ns | 0.0277 ns | 0.0246 ns |  4.119 ns |
    | GetWellKnownType_New |                 Type |  1.705 ns | 0.0061 ns | 0.0051 ns |  1.706 ns |
    | GetWellKnownType_Old |                 Type |  3.691 ns | 0.0206 ns | 0.0193 ns |  3.687 ns |
    | GetWellKnownType_New |                 Void |  1.708 ns | 0.0103 ns | 0.0096 ns |  1.709 ns |
    | GetWellKnownType_Old |                 Void |  3.478 ns | 0.0123 ns | 0.0109 ns |  3.477 ns |
    */
    [Params("String", "Nullable`1", "Type", "Array", "Attribute", "Object", "NotSupportedException", "Void")]
    public string Value { get; set; }

    [Benchmark]
    public string GetWellKnownType_New() => NewRoslyn.GetWellKnownType(Value);
    [Benchmark]
    public string GetWellKnownType_Old() => OldRoslyn.GetWellKnownType(Value);
}

public partial class LengthVsHashCode_GetWellKnownType_Mix
{
    /*
    |                   Method |     Mean |    Error |   StdDev |
    |------------------------- |---------:|---------:|---------:|
    | GetWellKnownType_New_Mix | 34.31 ns | 0.343 ns | 0.286 ns |
    | GetWellKnownType_Old_Mix | 53.41 ns | 0.420 ns | 0.393 ns |
     */
    [Benchmark]
    public string GetWellKnownType_New_Mix() => NewRoslyn.GetWellKnownType_Mix();
    [Benchmark]
    public string GetWellKnownType_Old_Mix() => OldRoslyn.GetWellKnownType_Mix();
}


public partial class LengthVsHashCode_GetLocalizedString
{
    /*
    |                 Method |        Value |     Mean |     Error |    StdDev |
    |----------------------- |------------- |---------:|----------:|----------:|
    | GetLocalizedString_New |       Action | 2.020 ns | 0.0233 ns | 0.0207 ns |
    | GetLocalizedString_Old |       Action | 3.910 ns | 0.0411 ns | 0.0364 ns |
    | GetLocalizedString_New |   Appearance | 1.708 ns | 0.0100 ns | 0.0094 ns |
    | GetLocalizedString_Old |   Appearance | 4.777 ns | 0.0150 ns | 0.0140 ns |
    | GetLocalizedString_New | Asynchronous | 1.514 ns | 0.0225 ns | 0.0199 ns |
    | GetLocalizedString_Old | Asynchronous | 5.769 ns | 0.0324 ns | 0.0287 ns |
    | GetLocalizedString_New |     Behavior | 1.920 ns | 0.0150 ns | 0.0133 ns |
    | GetLocalizedString_Old |     Behavior | 4.566 ns | 0.0332 ns | 0.0311 ns |
    | GetLocalizedString_New |       Config | 2.007 ns | 0.0194 ns | 0.0172 ns |
    | GetLocalizedString_Old |       Config | 3.694 ns | 0.0238 ns | 0.0199 ns |
    | GetLocalizedString_New |          DDE | 1.713 ns | 0.0110 ns | 0.0092 ns |
    | GetLocalizedString_Old |          DDE | 3.266 ns | 0.0094 ns | 0.0074 ns |
    | GetLocalizedString_New |         Data | 1.502 ns | 0.0101 ns | 0.0094 ns |
    | GetLocalizedString_Old |         Data | 3.696 ns | 0.0289 ns | 0.0270 ns |
    | GetLocalizedString_New |      Default | 1.501 ns | 0.0139 ns | 0.0130 ns |
    | GetLocalizedString_Old |      Default | 3.955 ns | 0.0543 ns | 0.0508 ns |
    | GetLocalizedString_New |       Design | 2.007 ns | 0.0237 ns | 0.0222 ns |
    | GetLocalizedString_Old |       Design | 4.343 ns | 0.0348 ns | 0.0309 ns |
    | GetLocalizedString_New |     DragDrop | 1.941 ns | 0.0335 ns | 0.0314 ns |
    | GetLocalizedString_Old |     DragDrop | 4.559 ns | 0.0249 ns | 0.0221 ns |
    | GetLocalizedString_New |        Focus | 1.915 ns | 0.0069 ns | 0.0057 ns |
    | GetLocalizedString_Old |        Focus | 4.123 ns | 0.0172 ns | 0.0161 ns |
    | GetLocalizedString_New |         Font | 1.510 ns | 0.0206 ns | 0.0193 ns |
    | GetLocalizedString_Old |         Font | 3.479 ns | 0.0320 ns | 0.0283 ns |
    | GetLocalizedString_New |       Format | 2.024 ns | 0.0233 ns | 0.0218 ns |
    | GetLocalizedString_Old |       Format | 4.323 ns | 0.0189 ns | 0.0168 ns |
    | GetLocalizedString_New |          Key | 1.502 ns | 0.0103 ns | 0.0086 ns |
    | GetLocalizedString_Old |          Key | 3.469 ns | 0.0113 ns | 0.0105 ns |
    | GetLocalizedString_New |       Layout | 2.005 ns | 0.0200 ns | 0.0178 ns |
    | GetLocalizedString_Old |       Layout | 4.323 ns | 0.0190 ns | 0.0178 ns |
    | GetLocalizedString_New |         List | 2.122 ns | 0.0110 ns | 0.0098 ns |
    | GetLocalizedString_Old |         List | 3.691 ns | 0.0204 ns | 0.0171 ns |
    | GetLocalizedString_New |        Mouse | 1.714 ns | 0.0127 ns | 0.0113 ns |
    | GetLocalizedString_Old |        Mouse | 3.695 ns | 0.0105 ns | 0.0088 ns |
    | GetLocalizedString_New |     Position | 1.709 ns | 0.0095 ns | 0.0079 ns |
    | GetLocalizedString_Old |     Position | 4.547 ns | 0.0217 ns | 0.0181 ns |
    | GetLocalizedString_New |        Scale | 1.717 ns | 0.0131 ns | 0.0116 ns |
    | GetLocalizedString_Old |        Scale | 3.907 ns | 0.0141 ns | 0.0118 ns |
    | GetLocalizedString_New |         Text | 1.912 ns | 0.0149 ns | 0.0140 ns |
    | GetLocalizedString_Old |         Text | 3.680 ns | 0.0134 ns | 0.0112 ns |
    | GetLocalizedString_New |  WindowStyle | 1.495 ns | 0.0098 ns | 0.0082 ns |
    | GetLocalizedString_Old |  WindowStyle | 5.496 ns | 0.0189 ns | 0.0158 ns |
    */
    [Params("Action", "Appearance", "Asynchronous", "Behavior", "Config", "Data", "DDE", "Default",
        "Design", "DragDrop", "Focus", "Font", "Format", "Key", "Layout", "List", "Mouse",
        "Position", "Scale", "Text", "WindowStyle")]
    public string Value { get; set; }

    [Benchmark]
    public string GetLocalizedString_New() => NewRoslyn.GetLocalizedString(Value);
    [Benchmark]
    public string GetLocalizedString_Old() => OldRoslyn.GetLocalizedString(Value);
}

public partial class LengthVsHashCode_GetLocalizedString_Mix
{
    /*
    |                     Method |      Mean |    Error |   StdDev |
    |--------------------------- |----------:|---------:|---------:|
    | GetLocalizedString_New_Mix |  94.59 ns | 1.132 ns | 1.004 ns |
    | GetLocalizedString_Old_Mix | 126.86 ns | 1.304 ns | 1.219 ns |
    */
    [Benchmark]
    public string GetLocalizedString_New_Mix() => NewRoslyn.GetLocalizedString_Mix();
    [Benchmark]
    public string GetLocalizedString_Old_Mix() => OldRoslyn.GetLocalizedString_Mix();
}


public partial class LengthVsHashCode_ParseGraphicsUnits
{
    /*
    |                 Method |   Value |     Mean |     Error |    StdDev |
    |----------------------- |-------- |---------:|----------:|----------:|
    | ParseGraphicsUnits_New | display | 1.717 ns | 0.0198 ns | 0.0176 ns |
    | ParseGraphicsUnits_Old | display | 3.917 ns | 0.0222 ns | 0.0197 ns |
    | ParseGraphicsUnits_New |     doc | 1.712 ns | 0.0170 ns | 0.0159 ns |
    | ParseGraphicsUnits_Old |     doc | 3.519 ns | 0.0644 ns | 0.0571 ns |
    | ParseGraphicsUnits_New |      in | 1.825 ns | 0.0254 ns | 0.0212 ns |
    | ParseGraphicsUnits_Old |      in | 2.784 ns | 0.0145 ns | 0.0136 ns |
    | ParseGraphicsUnits_New |      mm | 1.911 ns | 0.0052 ns | 0.0046 ns |
    | ParseGraphicsUnits_Old |      mm | 3.008 ns | 0.0109 ns | 0.0091 ns |
    | ParseGraphicsUnits_New |      pt | 2.309 ns | 0.0192 ns | 0.0179 ns |
    | ParseGraphicsUnits_Old |      pt | 2.811 ns | 0.0178 ns | 0.0157 ns |
    | ParseGraphicsUnits_New |      px | 1.927 ns | 0.0133 ns | 0.0111 ns |
    | ParseGraphicsUnits_Old |      px | 3.004 ns | 0.0134 ns | 0.0119 ns |
    | ParseGraphicsUnits_New |   world | 1.705 ns | 0.0092 ns | 0.0081 ns |
    | ParseGraphicsUnits_Old |   world | 3.501 ns | 0.0206 ns | 0.0183 ns |
     */
    [Params("display", "doc", "pt", "in", "mm", "px", "world")]
    public string Value { get; set; }

    [Benchmark]
    public string ParseGraphicsUnits_New() => NewRoslyn.ParseGraphicsUnits(Value);
    [Benchmark]
    public string ParseGraphicsUnits_Old() => OldRoslyn.ParseGraphicsUnits(Value);
}

public partial class LengthVsHashCode_ParseGraphicsUnits_Mix
{
    /*
    |                     Method |     Mean |    Error |   StdDev |
    |--------------------------- |---------:|---------:|---------:|
    | ParseGraphicsUnits_New_Mix | 31.64 ns | 0.389 ns | 0.364 ns |
    | ParseGraphicsUnits_Old_Mix | 37.68 ns | 0.612 ns | 0.573 ns |
     */
    [Benchmark]
    public string ParseGraphicsUnits_New_Mix() => NewRoslyn.ParseGraphicsUnits_Mix();
    [Benchmark]
    public string ParseGraphicsUnits_Old_Mix() => OldRoslyn.ParseGraphicsUnits_Mix();
}
