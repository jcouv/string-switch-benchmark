using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

_ = BenchmarkRunner.Run<LengthVsHashCode>();
_ = BenchmarkRunner.Run<LengthVsHashCode_ShortSwitch>();
_ = BenchmarkRunner.Run<LengthVsHashCode_DenseWithTwoCandidatesPerBucket>();
_ = BenchmarkRunner.Run<LengthVsHashCode_DenseWithThreeCandidatesPerBucket>();
_ = BenchmarkRunner.Run<LengthVsHashCode_SparseLongWithThreeCandidatesPerBucket>();
_ = BenchmarkRunner.Run<LengthVsHashCode_DenseWithFourCandidatesPerBucket>();
_ = BenchmarkRunner.Run<LengthVsHashCode_SparseLongWithFourCandidatesPerBucket>();
_ = BenchmarkRunner.Run<LengthVsHashCode_SparseWithFiveCandidatesPerBucket>();


/*
|                                           Method |          Mean |      Error |     StdDev |
|------------------------------------------------- |--------------:|-----------:|-----------:|
|                                       Switch1New |    28.3154 ns |  0.1655 ns |  0.1468 ns |
|                                       Switch1Old |    44.7493 ns |  0.2814 ns |  0.2197 ns |
|                               NotALengthMatchNew |     0.4405 ns |  0.0071 ns |  0.0063 ns |
|                               NotALengthMatchOld |     5.5831 ns |  0.0311 ns |  0.0291 ns |
|                                         DenseNew | 1,066.1028 ns | 17.1358 ns | 16.0288 ns |
|                                         DenseOld |   992.7607 ns | 16.9565 ns | 15.8612 ns |
|         DenseFew_Match_New | 23.116 ns | 0.2747 ns | 0.2435 ns | 23.106 ns |
|         DenseFew_Match_Old | 17.964 ns | 0.0874 ns | 0.0818 ns | 17.972 ns |
|  DenseFew_DoesNotMatch_New |  7.458 ns | 0.1232 ns | 0.1152 ns |  7.420 ns |
|  DenseFew_DoesNotMatch_Old |  9.431 ns | 0.0636 ns | 0.0564 ns |  9.440 ns |
|        SparseFew_Match_New | 18.362 ns | 0.1258 ns | 0.1051 ns | 18.372 ns |
|        SparseFew_Match_Old | 17.940 ns | 0.1317 ns | 0.1168 ns | 17.942 ns |
| SparseFew_DoesNotMatch_New |  7.578 ns | 0.1733 ns | 0.3462 ns |  7.381 ns |
| SparseFew_DoesNotMatch_Old |  9.392 ns | 0.0872 ns | 0.0815 ns |  9.386 ns |
|                                        SparseNew | 1,307.5357 ns |  9.7918 ns |  9.1593 ns |
|                                        SparseOld | 1,510.2573 ns | 24.8400 ns | 22.0200 ns |
|                                   ContentTypeNew |    13.5558 ns |  0.1417 ns |  0.1325 ns |
|                                   ContentTypeOld |    25.6514 ns |  0.0246 ns |  0.0192 ns |
|                         ContentTypeAsListPattern |    17.5518 ns |  0.1027 ns |  0.0910 ns |
|                                      CyrusSwitch |    18.2087 ns |  0.0818 ns |  0.0725 ns |
|                                        CyrusTrie |   920.9832 ns |  1.6754 ns |  1.4852 ns |
|                    CyrusTrieWithoutOptimizations |   920.7312 ns |  0.8594 ns |  0.7618 ns |
|                        ShortSwitch_FirstCase_New |     1.4812 ns |  0.0031 ns |  0.0028 ns |
|                        ShortSwitch_FirstCase_Old |     0.8437 ns |  0.0022 ns |  0.0019 ns |
|                       ShortSwitch_SecondCase_New |     1.0612 ns |  0.0023 ns |  0.0022 ns |
|                       ShortSwitch_SecondCase_Old |     0.6382 ns |  0.0028 ns |  0.0024 ns |
|                        ShortSwitch_ThirdCase_New |     1.3888 ns |  0.0112 ns |  0.0105 ns |
|                        ShortSwitch_ThirdCase_Old |     1.2956 ns |  0.0467 ns |  0.0437 ns |
|                       ShortSwitch_FourthCase_New |     1.2695 ns |  0.0018 ns |  0.0015 ns |
|                       ShortSwitch_FourthCase_Old |     1.4690 ns |  0.0020 ns |  0.0015 ns |
|               ShortSwitchLongWords_FirstCase_New |     1.4268 ns |  0.0063 ns |  0.0059 ns |
|               ShortSwitchLongWords_FirstCase_Old |     0.8542 ns |  0.0024 ns |  0.0021 ns |
|              ShortSwitchLongWords_SecondCase_New |     1.6522 ns |  0.0052 ns |  0.0049 ns |
|              ShortSwitchLongWords_SecondCase_Old |     1.0594 ns |  0.0036 ns |  0.0032 ns |
|               ShortSwitchLongWords_ThirdCase_New |     1.6694 ns |  0.0086 ns |  0.0072 ns |
|               ShortSwitchLongWords_ThirdCase_Old |     1.3043 ns |  0.0072 ns |  0.0068 ns |
|              ShortSwitchLongWords_FourthCase_New |     1.4223 ns |  0.0058 ns |  0.0051 ns |
|              ShortSwitchLongWords_FourthCase_Old |     1.4770 ns |  0.0053 ns |  0.0047 ns |
|                             GetDriveType_Mix_New |   225.2959 ns |  0.7816 ns |  0.6527 ns |
|                             GetDriveType_Mix_Old |   294.2904 ns |  1.3327 ns |  1.2466 ns |
|        DenseWithTwoCandidatesPerBucket_Case1_New |     1.1420 ns |  0.0030 ns |  0.0025 ns |
|        DenseWithTwoCandidatesPerBucket_Case1_Old |     2.4881 ns |  0.0026 ns |  0.0022 ns |
|        DenseWithTwoCandidatesPerBucket_Case2_New |     1.2348 ns |  0.0072 ns |  0.0067 ns |
|        DenseWithTwoCandidatesPerBucket_Case2_Old |     2.4395 ns |  0.0099 ns |  0.0092 ns |
|        DenseWithTwoCandidatesPerBucket_Case3_New |     1.2654 ns |  0.0054 ns |  0.0048 ns |
|        DenseWithTwoCandidatesPerBucket_Case3_Old |     2.6448 ns |  0.0114 ns |  0.0095 ns |
|        DenseWithTwoCandidatesPerBucket_Case4_New |     1.2772 ns |  0.0101 ns |  0.0094 ns |
|        DenseWithTwoCandidatesPerBucket_Case4_Old |     2.4768 ns |  0.0069 ns |  0.0058 ns |
|        DenseWithTwoCandidatesPerBucket_Case5_New |     1.0620 ns |  0.0085 ns |  0.0079 ns |
|        DenseWithTwoCandidatesPerBucket_Case5_Old |     2.7278 ns |  0.0102 ns |  0.0090 ns |
|        DenseWithTwoCandidatesPerBucket_Case6_New |     1.2758 ns |  0.0041 ns |  0.0034 ns |
|        DenseWithTwoCandidatesPerBucket_Case6_Old |     2.8711 ns |  0.0179 ns |  0.0167 ns |
|        DenseWithTwoCandidatesPerBucket_Case7_New |     1.2620 ns |  0.0041 ns |  0.0032 ns |
|        DenseWithTwoCandidatesPerBucket_Case7_Old |     2.6574 ns |  0.0112 ns |  0.0093 ns |
|        DenseWithTwoCandidatesPerBucket_Case8_New |     1.2736 ns |  0.0034 ns |  0.0027 ns |
|        DenseWithTwoCandidatesPerBucket_Case8_Old |     2.7367 ns |  0.0046 ns |  0.0036 ns |
|        DenseWithTwoCandidatesPerBucket_Case9_New |     1.2628 ns |  0.0028 ns |  0.0024 ns |
|        DenseWithTwoCandidatesPerBucket_Case9_Old |     2.6626 ns |  0.0216 ns |  0.0202 ns |
|       DenseWithTwoCandidatesPerBucket_Case10_New |     1.2316 ns |  0.0159 ns |  0.0141 ns |
|       DenseWithTwoCandidatesPerBucket_Case10_Old |     2.5328 ns |  0.0042 ns |  0.0035 ns |
|       DenseWithTwoCandidatesPerBucket_Case11_New |     1.0602 ns |  0.0049 ns |  0.0043 ns |
|       DenseWithTwoCandidatesPerBucket_Case11_Old |     2.4595 ns |  0.0122 ns |  0.0108 ns |
|       DenseWithTwoCandidatesPerBucket_Case12_New |     1.0175 ns |  0.0057 ns |  0.0051 ns |
|       DenseWithTwoCandidatesPerBucket_Case12_Old |     2.2764 ns |  0.0066 ns |  0.0061 ns |
|      DenseWithThreeCandidatesPerBucket_Case1_New |     1.1713 ns |  0.0075 ns |  0.0066 ns |
|      DenseWithThreeCandidatesPerBucket_Case1_Old |     2.9393 ns |  0.0138 ns |  0.0116 ns |
|      DenseWithThreeCandidatesPerBucket_Case2_New |     1.2291 ns |  0.0149 ns |  0.0139 ns |
|      DenseWithThreeCandidatesPerBucket_Case2_Old |     2.5567 ns |  0.0086 ns |  0.0076 ns |
|      DenseWithThreeCandidatesPerBucket_Case3_New |     1.6402 ns |  0.0046 ns |  0.0043 ns |
|      DenseWithThreeCandidatesPerBucket_Case3_Old |     2.7642 ns |  0.0115 ns |  0.0096 ns |
|      DenseWithThreeCandidatesPerBucket_Case4_New |     1.0601 ns |  0.0069 ns |  0.0061 ns |
|      DenseWithThreeCandidatesPerBucket_Case4_Old |     2.5524 ns |  0.0511 ns |  0.0478 ns |
|      DenseWithThreeCandidatesPerBucket_Case5_New |     1.2282 ns |  0.0090 ns |  0.0085 ns |
|      DenseWithThreeCandidatesPerBucket_Case5_Old |     2.6004 ns |  0.0176 ns |  0.0164 ns |
|      DenseWithThreeCandidatesPerBucket_Case6_New |     1.6493 ns |  0.0158 ns |  0.0148 ns |
|      DenseWithThreeCandidatesPerBucket_Case6_Old |     3.0091 ns |  0.0228 ns |  0.0178 ns |
|      DenseWithThreeCandidatesPerBucket_Case7_New |     0.8738 ns |  0.0143 ns |  0.0133 ns |
|      DenseWithThreeCandidatesPerBucket_Case7_Old |     2.9503 ns |  0.0251 ns |  0.0196 ns |
|      DenseWithThreeCandidatesPerBucket_Case8_New |     1.2224 ns |  0.0132 ns |  0.0123 ns |
|      DenseWithThreeCandidatesPerBucket_Case8_Old |     2.7388 ns |  0.0173 ns |  0.0153 ns |
|      DenseWithThreeCandidatesPerBucket_Case9_New |     1.4321 ns |  0.0061 ns |  0.0051 ns |
|      DenseWithThreeCandidatesPerBucket_Case9_Old |     2.7540 ns |  0.0156 ns |  0.0138 ns |

| SparseLongWithThreeCandidatesPerBucket_Case1_New |    14.5882 ns |  0.0748 ns |  0.0734 ns |
| SparseLongWithThreeCandidatesPerBucket_Case1_Old |    14.5781 ns |  0.0194 ns |  0.0182 ns |
| SparseLongWithThreeCandidatesPerBucket_Case2_New |    15.5492 ns |  0.0276 ns |  0.0215 ns |
| SparseLongWithThreeCandidatesPerBucket_Case2_Old |    15.3750 ns |  0.0432 ns |  0.0383 ns |
| SparseLongWithThreeCandidatesPerBucket_Case3_New |    14.4727 ns |  0.0341 ns |  0.0302 ns |
| SparseLongWithThreeCandidatesPerBucket_Case3_Old |    14.2530 ns |  0.0206 ns |  0.0183 ns |
| SparseLongWithThreeCandidatesPerBucket_Case4_New |    14.5517 ns |  0.0343 ns |  0.0286 ns |
| SparseLongWithThreeCandidatesPerBucket_Case4_Old |    14.3480 ns |  0.0267 ns |  0.0236 ns |
| SparseLongWithThreeCandidatesPerBucket_Case5_New |    14.4211 ns |  0.0234 ns |  0.0196 ns |
| SparseLongWithThreeCandidatesPerBucket_Case5_Old |    14.3083 ns |  0.0672 ns |  0.0596 ns |
| SparseLongWithThreeCandidatesPerBucket_Case6_New |    15.6058 ns |  0.0333 ns |  0.0312 ns |
| SparseLongWithThreeCandidatesPerBucket_Case6_Old |    15.3582 ns |  0.0884 ns |  0.0827 ns |
| SparseLongWithThreeCandidatesPerBucket_Case7_New |    14.1825 ns |  0.0566 ns |  0.0501 ns |
| SparseLongWithThreeCandidatesPerBucket_Case7_Old |    14.1895 ns |  0.0464 ns |  0.0411 ns |
| SparseLongWithThreeCandidatesPerBucket_Case8_New |    14.4031 ns |  0.0172 ns |  0.0134 ns |
| SparseLongWithThreeCandidatesPerBucket_Case8_Old |    14.3670 ns |  0.0732 ns |  0.0685 ns |
| SparseLongWithThreeCandidatesPerBucket_Case9_New |    14.5255 ns |  0.1751 ns |  0.1638 ns |
| SparseLongWithThreeCandidatesPerBucket_Case9_Old |    14.4348 ns |  0.0569 ns |  0.0505 ns |
|   SparseLongWithThreeCandidatesPerBucket_Mix_New |   150.7844 ns |  0.5945 ns |  0.5561 ns |
|   SparseLongWithThreeCandidatesPerBucket_Mix_Old |   149.6289 ns |  0.7926 ns |  0.7414 ns |
|       DenseWithFourCandidatesPerBucket_Case1_New |     2.0698 ns |  0.0084 ns |  0.0079 ns |
|       DenseWithFourCandidatesPerBucket_Case1_Old |     2.1139 ns |  0.0080 ns |  0.0075 ns |
|       DenseWithFourCandidatesPerBucket_Case2_New |     1.2398 ns |  0.0073 ns |  0.0065 ns |
|       DenseWithFourCandidatesPerBucket_Case2_Old |     2.6767 ns |  0.0130 ns |  0.0115 ns |
|       DenseWithFourCandidatesPerBucket_Case3_New |     1.6482 ns |  0.0098 ns |  0.0087 ns |
|       DenseWithFourCandidatesPerBucket_Case3_Old |     2.8893 ns |  0.0556 ns |  0.0520 ns |
|       DenseWithFourCandidatesPerBucket_Case4_New |     2.1275 ns |  0.0287 ns |  0.0268 ns |
|       DenseWithFourCandidatesPerBucket_Case4_Old |     2.7723 ns |  0.0697 ns |  0.0618 ns |
|       DenseWithFourCandidatesPerBucket_Case5_New |     1.0690 ns |  0.0093 ns |  0.0078 ns |
|       DenseWithFourCandidatesPerBucket_Case5_Old |     3.0071 ns |  0.0039 ns |  0.0031 ns |
|       DenseWithFourCandidatesPerBucket_Case6_New |     1.2341 ns |  0.0125 ns |  0.0110 ns |
|       DenseWithFourCandidatesPerBucket_Case6_Old |     2.8861 ns |  0.0764 ns |  0.0849 ns |
|       DenseWithFourCandidatesPerBucket_Case7_New |     1.8521 ns |  0.0081 ns |  0.0068 ns |
|       DenseWithFourCandidatesPerBucket_Case7_Old |     2.9065 ns |  0.0577 ns |  0.0511 ns |
|       DenseWithFourCandidatesPerBucket_Case8_New |     2.2778 ns |  0.0121 ns |  0.0113 ns |
|       DenseWithFourCandidatesPerBucket_Case8_Old |     2.5948 ns |  0.0254 ns |  0.0238 ns |
|       DenseWithFourCandidatesPerBucket_Case9_New |     0.8578 ns |  0.0073 ns |  0.0068 ns |
|       DenseWithFourCandidatesPerBucket_Case9_Old |     2.8550 ns |  0.0162 ns |  0.0144 ns |
|      DenseWithFourCandidatesPerBucket_Case10_New |     1.2199 ns |  0.0028 ns |  0.0025 ns |
|      DenseWithFourCandidatesPerBucket_Case10_Old |     2.5491 ns |  0.0069 ns |  0.0061 ns |
|      DenseWithFourCandidatesPerBucket_Case11_New |     1.6427 ns |  0.0059 ns |  0.0052 ns |
|      DenseWithFourCandidatesPerBucket_Case11_Old |     2.9011 ns |  0.0216 ns |  0.0202 ns |
|      DenseWithFourCandidatesPerBucket_Case12_New |     2.0654 ns |  0.0073 ns |  0.0068 ns |
|      DenseWithFourCandidatesPerBucket_Case12_Old |     2.9133 ns |  0.0269 ns |  0.0251 ns |
|      SparseWithFourCandidatesPerBucket_Case1_New |     1.0511 ns |  0.0032 ns |  0.0027 ns |
|      SparseWithFourCandidatesPerBucket_Case1_Old |     2.7924 ns |  0.0713 ns |  0.0667 ns |
|      SparseWithFourCandidatesPerBucket_Case2_New |     1.2225 ns |  0.0071 ns |  0.0066 ns |
|      SparseWithFourCandidatesPerBucket_Case2_Old |     2.7958 ns |  0.0485 ns |  0.0430 ns |
|      SparseWithFourCandidatesPerBucket_Case3_New |     1.4508 ns |  0.0124 ns |  0.0116 ns |
|      SparseWithFourCandidatesPerBucket_Case3_Old |     2.9103 ns |  0.0295 ns |  0.0261 ns |
|      SparseWithFourCandidatesPerBucket_Case4_New |     1.9560 ns |  0.0598 ns |  0.0560 ns |
|      SparseWithFourCandidatesPerBucket_Case4_Old |     2.9244 ns |  0.0209 ns |  0.0196 ns |
|      SparseWithFourCandidatesPerBucket_Case5_New |     1.0390 ns |  0.0100 ns |  0.0089 ns |
|      SparseWithFourCandidatesPerBucket_Case5_Old |     2.8518 ns |  0.0115 ns |  0.0102 ns |
|      SparseWithFourCandidatesPerBucket_Case6_New |     1.2224 ns |  0.0087 ns |  0.0081 ns |
|      SparseWithFourCandidatesPerBucket_Case6_Old |     2.7478 ns |  0.0173 ns |  0.0162 ns |
|      SparseWithFourCandidatesPerBucket_Case7_New |     1.6353 ns |  0.0045 ns |  0.0035 ns |
|      SparseWithFourCandidatesPerBucket_Case7_Old |     2.9018 ns |  0.0254 ns |  0.0237 ns |
|      SparseWithFourCandidatesPerBucket_Case8_New |     2.0566 ns |  0.0043 ns |  0.0040 ns |
|      SparseWithFourCandidatesPerBucket_Case8_Old |     2.9059 ns |  0.0256 ns |  0.0227 ns |
|      SparseWithFourCandidatesPerBucket_Case9_New |     1.2595 ns |  0.0028 ns |  0.0025 ns |
|      SparseWithFourCandidatesPerBucket_Case9_Old |     2.9654 ns |  0.0126 ns |  0.0118 ns |
|     SparseWithFourCandidatesPerBucket_Case10_New |     1.0982 ns |  0.0074 ns |  0.0070 ns |
|     SparseWithFourCandidatesPerBucket_Case10_Old |     2.9560 ns |  0.0157 ns |  0.0139 ns |
|     SparseWithFourCandidatesPerBucket_Case11_New |     1.4890 ns |  0.0032 ns |  0.0025 ns |
|     SparseWithFourCandidatesPerBucket_Case11_Old |     2.6780 ns |  0.0179 ns |  0.0149 ns |
|     SparseWithFourCandidatesPerBucket_Case12_New |     1.8782 ns |  0.0131 ns |  0.0116 ns |
|     SparseWithFourCandidatesPerBucket_Case12_Old |     2.7053 ns |  0.0246 ns |  0.0230 ns |
|  SparseLongWithFourCandidatesPerBucket_Case1_New |    14.7843 ns |  0.0807 ns |  0.0674 ns |
|  SparseLongWithFourCandidatesPerBucket_Case1_Old |    14.6838 ns |  0.0222 ns |  0.0186 ns |
|  SparseLongWithFourCandidatesPerBucket_Case2_New |    14.4833 ns |  0.0617 ns |  0.0515 ns |
|  SparseLongWithFourCandidatesPerBucket_Case2_Old |    14.7110 ns |  0.0988 ns |  0.0876 ns |
|  SparseLongWithFourCandidatesPerBucket_Case3_New |    14.5274 ns |  0.0610 ns |  0.0571 ns |
|  SparseLongWithFourCandidatesPerBucket_Case3_Old |    14.4219 ns |  0.0358 ns |  0.0317 ns |
|  SparseLongWithFourCandidatesPerBucket_Case4_New |    15.7076 ns |  0.0412 ns |  0.0365 ns |
|  SparseLongWithFourCandidatesPerBucket_Case4_Old |    15.5833 ns |  0.0490 ns |  0.0458 ns |
|  SparseLongWithFourCandidatesPerBucket_Case5_New |    14.6921 ns |  0.0532 ns |  0.0472 ns |
|  SparseLongWithFourCandidatesPerBucket_Case5_Old |    14.7157 ns |  0.0378 ns |  0.0335 ns |
|  SparseLongWithFourCandidatesPerBucket_Case6_New |    14.6484 ns |  0.0612 ns |  0.0572 ns |
|  SparseLongWithFourCandidatesPerBucket_Case6_Old |    14.6850 ns |  0.0490 ns |  0.0409 ns |
|  SparseLongWithFourCandidatesPerBucket_Case7_New |    14.4594 ns |  0.1219 ns |  0.1140 ns |
|  SparseLongWithFourCandidatesPerBucket_Case7_Old |    14.4818 ns |  0.0417 ns |  0.0390 ns |
|  SparseLongWithFourCandidatesPerBucket_Case8_New |    15.5012 ns |  0.0931 ns |  0.0727 ns |
|  SparseLongWithFourCandidatesPerBucket_Case8_Old |    15.6793 ns |  0.0509 ns |  0.0451 ns |
|  SparseLongWithFourCandidatesPerBucket_Case9_New |    14.6379 ns |  0.0373 ns |  0.0349 ns |
|  SparseLongWithFourCandidatesPerBucket_Case9_Old |    14.5471 ns |  0.0248 ns |  0.0194 ns |
| SparseLongWithFourCandidatesPerBucket_Case10_New |    14.4847 ns |  0.0404 ns |  0.0338 ns |
| SparseLongWithFourCandidatesPerBucket_Case10_Old |    14.4785 ns |  0.0568 ns |  0.0531 ns |
| SparseLongWithFourCandidatesPerBucket_Case11_New |    14.6776 ns |  0.0534 ns |  0.0473 ns |
| SparseLongWithFourCandidatesPerBucket_Case11_Old |    14.5545 ns |  0.0371 ns |  0.0329 ns |
| SparseLongWithFourCandidatesPerBucket_Case12_New |    14.5071 ns |  0.0813 ns |  0.0721 ns |
| SparseLongWithFourCandidatesPerBucket_Case12_Old |    14.7037 ns |  0.0499 ns |  0.0443 ns |
|      SparseWithFiveCandidatesPerBucket_Case1_New |     1.0590 ns |  0.0100 ns |  0.0083 ns |
|      SparseWithFiveCandidatesPerBucket_Case1_Old |     3.2311 ns |  0.0149 ns |  0.0132 ns |
|      SparseWithFiveCandidatesPerBucket_Case2_New |     1.0833 ns |  0.0431 ns |  0.0382 ns |
|      SparseWithFiveCandidatesPerBucket_Case2_Old |     3.0322 ns |  0.0150 ns |  0.0125 ns |
|      SparseWithFiveCandidatesPerBucket_Case3_New |     1.6373 ns |  0.0069 ns |  0.0065 ns |
|      SparseWithFiveCandidatesPerBucket_Case3_Old |     2.6822 ns |  0.0140 ns |  0.0117 ns |
|      SparseWithFiveCandidatesPerBucket_Case4_New |     2.0556 ns |  0.0089 ns |  0.0083 ns |
|      SparseWithFiveCandidatesPerBucket_Case4_Old |     2.9534 ns |  0.0116 ns |  0.0109 ns |
|      SparseWithFiveCandidatesPerBucket_Case5_New |     2.4704 ns |  0.0034 ns |  0.0030 ns |
|      SparseWithFiveCandidatesPerBucket_Case5_Old |     2.9153 ns |  0.0289 ns |  0.0270 ns |
|      SparseWithFiveCandidatesPerBucket_Case6_New |     0.8490 ns |  0.0033 ns |  0.0027 ns |
|      SparseWithFiveCandidatesPerBucket_Case6_Old |     3.4324 ns |  0.0152 ns |  0.0142 ns |
|      SparseWithFiveCandidatesPerBucket_Case7_New |     1.2171 ns |  0.0093 ns |  0.0078 ns |
|      SparseWithFiveCandidatesPerBucket_Case7_Old |     3.0010 ns |  0.0087 ns |  0.0077 ns |
|      SparseWithFiveCandidatesPerBucket_Case8_New |     1.6413 ns |  0.0096 ns |  0.0090 ns |
|      SparseWithFiveCandidatesPerBucket_Case8_Old |     3.0075 ns |  0.0116 ns |  0.0103 ns |
|      SparseWithFiveCandidatesPerBucket_Case9_New |     2.0662 ns |  0.0086 ns |  0.0076 ns |
|      SparseWithFiveCandidatesPerBucket_Case9_Old |     3.0003 ns |  0.0030 ns |  0.0025 ns |
|     SparseWithFiveCandidatesPerBucket_Case10_New |     2.4713 ns |  0.0069 ns |  0.0054 ns |
|     SparseWithFiveCandidatesPerBucket_Case10_Old |     2.9575 ns |  0.0102 ns |  0.0095 ns |
|     SparseWithFiveCandidatesPerBucket_Case11_New |     1.2585 ns |  0.0026 ns |  0.0020 ns |
|     SparseWithFiveCandidatesPerBucket_Case11_Old |     2.9554 ns |  0.0233 ns |  0.0207 ns |
|     SparseWithFiveCandidatesPerBucket_Case12_New |     1.2671 ns |  0.0023 ns |  0.0019 ns |
|     SparseWithFiveCandidatesPerBucket_Case12_Old |     3.4088 ns |  0.0111 ns |  0.0099 ns |
|     SparseWithFiveCandidatesPerBucket_Case13_New |     1.8325 ns |  0.0088 ns |  0.0073 ns |
|     SparseWithFiveCandidatesPerBucket_Case13_Old |     2.7409 ns |  0.0135 ns |  0.0113 ns |
|     SparseWithFiveCandidatesPerBucket_Case14_New |     2.2543 ns |  0.0117 ns |  0.0109 ns |
|     SparseWithFiveCandidatesPerBucket_Case14_Old |     2.8958 ns |  0.0156 ns |  0.0146 ns |
|     SparseWithFiveCandidatesPerBucket_Case15_New |     2.6738 ns |  0.0096 ns |  0.0085 ns |
|     SparseWithFiveCandidatesPerBucket_Case15_Old |     3.2204 ns |  0.0116 ns |  0.0097 ns |

|   SparseLongWithFiveCandidatesPerBucket_Case1_New |  17.13 ns | 0.113 ns |  0.106 ns |  17.11 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case1_Old |  16.94 ns | 0.161 ns |  0.151 ns |  16.94 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case1_Trie |  15.95 ns | 0.110 ns |  0.103 ns |  15.92 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case2_New |  16.88 ns | 0.081 ns |  0.071 ns |  16.89 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case2_Old |  15.23 ns | 0.136 ns |  0.128 ns |  15.22 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case2_Trie |  15.80 ns | 0.142 ns |  0.133 ns |  15.78 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case3_New |  16.15 ns | 0.075 ns |  0.067 ns |  16.15 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case3_Old |  16.22 ns | 0.187 ns |  0.175 ns |  16.17 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case3_Trie |  15.81 ns | 0.193 ns |  0.181 ns |  15.83 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case4_New |  15.47 ns | 0.062 ns |  0.058 ns |  15.48 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case4_Old |  15.33 ns | 0.084 ns |  0.078 ns |  15.31 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case4_Trie |  15.43 ns | 0.185 ns |  0.173 ns |  15.37 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case5_New |  15.52 ns | 0.066 ns |  0.055 ns |  15.53 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case5_Old |  15.19 ns | 0.083 ns |  0.078 ns |  15.21 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case5_Trie |  15.56 ns | 0.243 ns |  0.228 ns |  15.56 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case6_New |  15.37 ns | 0.120 ns |  0.107 ns |  15.39 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case6_Old |  15.25 ns | 0.188 ns |  0.175 ns |  15.22 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case6_Trie |  15.55 ns | 0.070 ns |  0.062 ns |  15.56 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case7_New |  15.53 ns | 0.160 ns |  0.150 ns |  15.52 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case7_Old |  15.27 ns | 0.138 ns |  0.129 ns |  15.28 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case7_Trie |  15.95 ns | 0.111 ns |  0.104 ns |  15.93 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case8_New |  15.57 ns | 0.080 ns |  0.071 ns |  15.56 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case8_Old |  15.38 ns | 0.085 ns |  0.080 ns |  15.40 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case8_Trie |  16.65 ns | 0.269 ns |  0.251 ns |  16.66 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case9_New |  15.33 ns | 0.084 ns |  0.079 ns |  15.31 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case9_Old |  14.88 ns | 0.211 ns |  0.197 ns |  14.93 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case9_Trie |  15.40 ns | 0.173 ns |  0.162 ns |  15.41 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case10_New |  15.14 ns | 0.076 ns |  0.064 ns |  15.12 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case10_Old |  15.51 ns | 0.287 ns |  0.254 ns |  15.45 ns |
| SparseLongWithFiveCandidatesPerBucket_Case10_Trie |  15.80 ns | 0.208 ns |  0.194 ns |  15.81 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case11_New |  15.08 ns | 0.051 ns |  0.045 ns |  15.08 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case11_Old |  14.92 ns | 0.119 ns |  0.112 ns |  14.93 ns |
| SparseLongWithFiveCandidatesPerBucket_Case11_Trie |  15.35 ns | 0.095 ns |  0.084 ns |  15.33 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case12_New |  15.12 ns | 0.066 ns |  0.058 ns |  15.14 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case12_Old |  14.73 ns | 0.097 ns |  0.091 ns |  14.71 ns |
| SparseLongWithFiveCandidatesPerBucket_Case12_Trie |  16.05 ns | 0.106 ns |  0.099 ns |  16.07 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case13_New |  15.12 ns | 0.092 ns |  0.081 ns |  15.12 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case13_Old |  14.84 ns | 0.105 ns |  0.098 ns |  14.81 ns |
| SparseLongWithFiveCandidatesPerBucket_Case13_Trie |  16.16 ns | 0.084 ns |  0.078 ns |  16.19 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case14_New |  15.34 ns | 0.089 ns |  0.083 ns |  15.34 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case14_Old |  15.04 ns | 0.088 ns |  0.083 ns |  15.05 ns |
| SparseLongWithFiveCandidatesPerBucket_Case14_Trie |  15.95 ns | 0.108 ns |  0.096 ns |  15.92 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case15_New |  15.16 ns | 0.042 ns |  0.039 ns |  15.15 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case15_Old |  14.91 ns | 0.053 ns |  0.047 ns |  14.90 ns |
| SparseLongWithFiveCandidatesPerBucket_Case15_Trie |  16.31 ns | 0.178 ns |  0.167 ns |  16.31 ns |
|     SparseLongWithFiveCandidatesPerBucket_Mix_New | 379.81 ns | 7.578 ns | 16.635 ns | 371.84 ns |
|     SparseLongWithFiveCandidatesPerBucket_Mix_Old | 355.55 ns | 2.950 ns |  2.615 ns | 355.07 ns |
|    SparseLongWithFiveCandidatesPerBucket_Mix_Trie | 377.79 ns | 2.903 ns |  2.715 ns | 378.43 ns |

|       SparseWithSixCandidatesPerBucket_Case1_New |     1.0537 ns |  0.0066 ns |  0.0058 ns |
|       SparseWithSixCandidatesPerBucket_Case1_Old |     2.5367 ns |  0.0066 ns |  0.0051 ns |
|       SparseWithSixCandidatesPerBucket_Case2_New |     1.0617 ns |  0.0035 ns |  0.0032 ns |
|       SparseWithSixCandidatesPerBucket_Case2_Old |     2.6587 ns |  0.0035 ns |  0.0029 ns |
|       SparseWithSixCandidatesPerBucket_Case3_New |     1.4321 ns |  0.0077 ns |  0.0069 ns |
|       SparseWithSixCandidatesPerBucket_Case3_Old |     2.4581 ns |  0.0089 ns |  0.0083 ns |
|       SparseWithSixCandidatesPerBucket_Case4_New |     1.8506 ns |  0.0078 ns |  0.0069 ns |
|       SparseWithSixCandidatesPerBucket_Case4_Old |     2.6474 ns |  0.0037 ns |  0.0029 ns |
|       SparseWithSixCandidatesPerBucket_Case5_New |     2.2773 ns |  0.0110 ns |  0.0098 ns |
|       SparseWithSixCandidatesPerBucket_Case5_Old |     2.4860 ns |  0.0085 ns |  0.0075 ns |
|       SparseWithSixCandidatesPerBucket_Case6_New |     2.6921 ns |  0.0051 ns |  0.0045 ns |
|       SparseWithSixCandidatesPerBucket_Case6_Old |     2.6570 ns |  0.0095 ns |  0.0084 ns |
|       SparseWithSixCandidatesPerBucket_Case7_New |     0.8439 ns |  0.0022 ns |  0.0017 ns |
|       SparseWithSixCandidatesPerBucket_Case7_Old |     2.8635 ns |  0.0064 ns |  0.0054 ns |
|       SparseWithSixCandidatesPerBucket_Case8_New |     1.0426 ns |  0.0305 ns |  0.0286 ns |
|       SparseWithSixCandidatesPerBucket_Case8_Old |     2.7406 ns |  0.0101 ns |  0.0090 ns |
|       SparseWithSixCandidatesPerBucket_Case9_New |     1.4519 ns |  0.0112 ns |  0.0100 ns |
|       SparseWithSixCandidatesPerBucket_Case9_Old |     2.4627 ns |  0.0127 ns |  0.0119 ns |
|      SparseWithSixCandidatesPerBucket_Case10_New |     1.8680 ns |  0.0111 ns |  0.0104 ns |
|      SparseWithSixCandidatesPerBucket_Case10_Old |     2.5152 ns |  0.0324 ns |  0.0287 ns |
|      SparseWithSixCandidatesPerBucket_Case11_New |     2.2978 ns |  0.0064 ns |  0.0054 ns |
|      SparseWithSixCandidatesPerBucket_Case11_Old |     2.6586 ns |  0.0112 ns |  0.0099 ns |
|      SparseWithSixCandidatesPerBucket_Case12_New |     2.5312 ns |  0.0090 ns |  0.0080 ns |
|      SparseWithSixCandidatesPerBucket_Case12_Old |     2.5343 ns |  0.0089 ns |  0.0074 ns |

|     SparseWithSevenCandidatesPerBucket_Case1_New |     2.6807 ns |  0.0061 ns |  0.0051 ns |
|     SparseWithSevenCandidatesPerBucket_Case1_Old |     2.6940 ns |  0.0316 ns |  0.0280 ns |
|     SparseWithSevenCandidatesPerBucket_Case2_New |     2.7390 ns |  0.0065 ns |  0.0054 ns |
|     SparseWithSevenCandidatesPerBucket_Case2_Old |     2.7365 ns |  0.0144 ns |  0.0128 ns |
|     SparseWithSevenCandidatesPerBucket_Case3_New |     2.5388 ns |  0.0102 ns |  0.0086 ns |
|     SparseWithSevenCandidatesPerBucket_Case3_Old |     2.4892 ns |  0.0107 ns |  0.0095 ns |
|     SparseWithSevenCandidatesPerBucket_Case4_New |     2.6819 ns |  0.0061 ns |  0.0051 ns |
|     SparseWithSevenCandidatesPerBucket_Case4_Old |     2.6634 ns |  0.0049 ns |  0.0038 ns |
|     SparseWithSevenCandidatesPerBucket_Case5_New |     2.7435 ns |  0.0047 ns |  0.0039 ns |
|     SparseWithSevenCandidatesPerBucket_Case5_Old |     2.5191 ns |  0.0097 ns |  0.0086 ns |
|     SparseWithSevenCandidatesPerBucket_Case6_New |     2.9504 ns |  0.0072 ns |  0.0064 ns |
|     SparseWithSevenCandidatesPerBucket_Case6_Old |     2.8850 ns |  0.0180 ns |  0.0168 ns |
|     SparseWithSevenCandidatesPerBucket_Case7_New |     2.7428 ns |  0.0045 ns |  0.0040 ns |
|     SparseWithSevenCandidatesPerBucket_Case7_Old |     2.9639 ns |  0.0127 ns |  0.0106 ns |
|     SparseWithSevenCandidatesPerBucket_Case8_New |     2.8884 ns |  0.0101 ns |  0.0095 ns |
|     SparseWithSevenCandidatesPerBucket_Case8_Old |     2.9472 ns |  0.0036 ns |  0.0028 ns |
|     SparseWithSevenCandidatesPerBucket_Case9_New |     2.6875 ns |  0.0149 ns |  0.0139 ns |
|     SparseWithSevenCandidatesPerBucket_Case9_Old |     2.7519 ns |  0.0196 ns |  0.0174 ns |
|    SparseWithSevenCandidatesPerBucket_Case10_New |     2.4807 ns |  0.0027 ns |  0.0021 ns |
|    SparseWithSevenCandidatesPerBucket_Case10_Old |     2.5361 ns |  0.0102 ns |  0.0090 ns |
|    SparseWithSevenCandidatesPerBucket_Case11_New |     2.6784 ns |  0.0053 ns |  0.0042 ns |
|    SparseWithSevenCandidatesPerBucket_Case11_Old |     2.5262 ns |  0.0122 ns |  0.0108 ns |
|    SparseWithSevenCandidatesPerBucket_Case12_New |     2.5394 ns |  0.0063 ns |  0.0053 ns |
|    SparseWithSevenCandidatesPerBucket_Case12_Old |     2.6889 ns |  0.0104 ns |  0.0087 ns |
|    SparseWithSevenCandidatesPerBucket_Case13_New |     2.8806 ns |  0.0063 ns |  0.0049 ns |
|    SparseWithSevenCandidatesPerBucket_Case13_Old |     2.7196 ns |  0.0135 ns |  0.0120 ns |
|    SparseWithSevenCandidatesPerBucket_Case14_New |     2.4718 ns |  0.0108 ns |  0.0095 ns |
|    SparseWithSevenCandidatesPerBucket_Case14_Old |     2.6667 ns |  0.0203 ns |  0.0180 ns |
*//*
|                                           Method |          Mean |      Error |     StdDev |
|------------------------------------------------- |--------------:|-----------:|-----------:|
|                                       Switch1New |    28.3154 ns |  0.1655 ns |  0.1468 ns |
|                                       Switch1Old |    44.7493 ns |  0.2814 ns |  0.2197 ns |
|                               NotALengthMatchNew |     0.4405 ns |  0.0071 ns |  0.0063 ns |
|                               NotALengthMatchOld |     5.5831 ns |  0.0311 ns |  0.0291 ns |
|                                         DenseNew | 1,066.1028 ns | 17.1358 ns | 16.0288 ns |
|                                         DenseOld |   992.7607 ns | 16.9565 ns | 15.8612 ns |
|         DenseFew_Match_New | 23.116 ns | 0.2747 ns | 0.2435 ns | 23.106 ns |
|         DenseFew_Match_Old | 17.964 ns | 0.0874 ns | 0.0818 ns | 17.972 ns |
|  DenseFew_DoesNotMatch_New |  7.458 ns | 0.1232 ns | 0.1152 ns |  7.420 ns |
|  DenseFew_DoesNotMatch_Old |  9.431 ns | 0.0636 ns | 0.0564 ns |  9.440 ns |
|        SparseFew_Match_New | 18.362 ns | 0.1258 ns | 0.1051 ns | 18.372 ns |
|        SparseFew_Match_Old | 17.940 ns | 0.1317 ns | 0.1168 ns | 17.942 ns |
| SparseFew_DoesNotMatch_New |  7.578 ns | 0.1733 ns | 0.3462 ns |  7.381 ns |
| SparseFew_DoesNotMatch_Old |  9.392 ns | 0.0872 ns | 0.0815 ns |  9.386 ns |
|                                        SparseNew | 1,307.5357 ns |  9.7918 ns |  9.1593 ns |
|                                        SparseOld | 1,510.2573 ns | 24.8400 ns | 22.0200 ns |
|                                   ContentTypeNew |    13.5558 ns |  0.1417 ns |  0.1325 ns |
|                                   ContentTypeOld |    25.6514 ns |  0.0246 ns |  0.0192 ns |
|                         ContentTypeAsListPattern |    17.5518 ns |  0.1027 ns |  0.0910 ns |
|                                      CyrusSwitch |    18.2087 ns |  0.0818 ns |  0.0725 ns |
|                                        CyrusTrie |   920.9832 ns |  1.6754 ns |  1.4852 ns |
|                    CyrusTrieWithoutOptimizations |   920.7312 ns |  0.8594 ns |  0.7618 ns |
|                        ShortSwitch_FirstCase_New |     1.4812 ns |  0.0031 ns |  0.0028 ns |
|                        ShortSwitch_FirstCase_Old |     0.8437 ns |  0.0022 ns |  0.0019 ns |
|                       ShortSwitch_SecondCase_New |     1.0612 ns |  0.0023 ns |  0.0022 ns |
|                       ShortSwitch_SecondCase_Old |     0.6382 ns |  0.0028 ns |  0.0024 ns |
|                        ShortSwitch_ThirdCase_New |     1.3888 ns |  0.0112 ns |  0.0105 ns |
|                        ShortSwitch_ThirdCase_Old |     1.2956 ns |  0.0467 ns |  0.0437 ns |
|                       ShortSwitch_FourthCase_New |     1.2695 ns |  0.0018 ns |  0.0015 ns |
|                       ShortSwitch_FourthCase_Old |     1.4690 ns |  0.0020 ns |  0.0015 ns |
|               ShortSwitchLongWords_FirstCase_New |     1.4268 ns |  0.0063 ns |  0.0059 ns |
|               ShortSwitchLongWords_FirstCase_Old |     0.8542 ns |  0.0024 ns |  0.0021 ns |
|              ShortSwitchLongWords_SecondCase_New |     1.6522 ns |  0.0052 ns |  0.0049 ns |
|              ShortSwitchLongWords_SecondCase_Old |     1.0594 ns |  0.0036 ns |  0.0032 ns |
|               ShortSwitchLongWords_ThirdCase_New |     1.6694 ns |  0.0086 ns |  0.0072 ns |
|               ShortSwitchLongWords_ThirdCase_Old |     1.3043 ns |  0.0072 ns |  0.0068 ns |
|              ShortSwitchLongWords_FourthCase_New |     1.4223 ns |  0.0058 ns |  0.0051 ns |
|              ShortSwitchLongWords_FourthCase_Old |     1.4770 ns |  0.0053 ns |  0.0047 ns |
|                             GetDriveType_Mix_New |   225.2959 ns |  0.7816 ns |  0.6527 ns |
|                             GetDriveType_Mix_Old |   294.2904 ns |  1.3327 ns |  1.2466 ns |
|        DenseWithTwoCandidatesPerBucket_Case1_New |     1.1420 ns |  0.0030 ns |  0.0025 ns |
|        DenseWithTwoCandidatesPerBucket_Case1_Old |     2.4881 ns |  0.0026 ns |  0.0022 ns |
|        DenseWithTwoCandidatesPerBucket_Case2_New |     1.2348 ns |  0.0072 ns |  0.0067 ns |
|        DenseWithTwoCandidatesPerBucket_Case2_Old |     2.4395 ns |  0.0099 ns |  0.0092 ns |
|        DenseWithTwoCandidatesPerBucket_Case3_New |     1.2654 ns |  0.0054 ns |  0.0048 ns |
|        DenseWithTwoCandidatesPerBucket_Case3_Old |     2.6448 ns |  0.0114 ns |  0.0095 ns |
|        DenseWithTwoCandidatesPerBucket_Case4_New |     1.2772 ns |  0.0101 ns |  0.0094 ns |
|        DenseWithTwoCandidatesPerBucket_Case4_Old |     2.4768 ns |  0.0069 ns |  0.0058 ns |
|        DenseWithTwoCandidatesPerBucket_Case5_New |     1.0620 ns |  0.0085 ns |  0.0079 ns |
|        DenseWithTwoCandidatesPerBucket_Case5_Old |     2.7278 ns |  0.0102 ns |  0.0090 ns |
|        DenseWithTwoCandidatesPerBucket_Case6_New |     1.2758 ns |  0.0041 ns |  0.0034 ns |
|        DenseWithTwoCandidatesPerBucket_Case6_Old |     2.8711 ns |  0.0179 ns |  0.0167 ns |
|        DenseWithTwoCandidatesPerBucket_Case7_New |     1.2620 ns |  0.0041 ns |  0.0032 ns |
|        DenseWithTwoCandidatesPerBucket_Case7_Old |     2.6574 ns |  0.0112 ns |  0.0093 ns |
|        DenseWithTwoCandidatesPerBucket_Case8_New |     1.2736 ns |  0.0034 ns |  0.0027 ns |
|        DenseWithTwoCandidatesPerBucket_Case8_Old |     2.7367 ns |  0.0046 ns |  0.0036 ns |
|        DenseWithTwoCandidatesPerBucket_Case9_New |     1.2628 ns |  0.0028 ns |  0.0024 ns |
|        DenseWithTwoCandidatesPerBucket_Case9_Old |     2.6626 ns |  0.0216 ns |  0.0202 ns |
|       DenseWithTwoCandidatesPerBucket_Case10_New |     1.2316 ns |  0.0159 ns |  0.0141 ns |
|       DenseWithTwoCandidatesPerBucket_Case10_Old |     2.5328 ns |  0.0042 ns |  0.0035 ns |
|       DenseWithTwoCandidatesPerBucket_Case11_New |     1.0602 ns |  0.0049 ns |  0.0043 ns |
|       DenseWithTwoCandidatesPerBucket_Case11_Old |     2.4595 ns |  0.0122 ns |  0.0108 ns |
|       DenseWithTwoCandidatesPerBucket_Case12_New |     1.0175 ns |  0.0057 ns |  0.0051 ns |
|       DenseWithTwoCandidatesPerBucket_Case12_Old |     2.2764 ns |  0.0066 ns |  0.0061 ns |
|      DenseWithThreeCandidatesPerBucket_Case1_New |     1.1713 ns |  0.0075 ns |  0.0066 ns |
|      DenseWithThreeCandidatesPerBucket_Case1_Old |     2.9393 ns |  0.0138 ns |  0.0116 ns |
|      DenseWithThreeCandidatesPerBucket_Case2_New |     1.2291 ns |  0.0149 ns |  0.0139 ns |
|      DenseWithThreeCandidatesPerBucket_Case2_Old |     2.5567 ns |  0.0086 ns |  0.0076 ns |
|      DenseWithThreeCandidatesPerBucket_Case3_New |     1.6402 ns |  0.0046 ns |  0.0043 ns |
|      DenseWithThreeCandidatesPerBucket_Case3_Old |     2.7642 ns |  0.0115 ns |  0.0096 ns |
|      DenseWithThreeCandidatesPerBucket_Case4_New |     1.0601 ns |  0.0069 ns |  0.0061 ns |
|      DenseWithThreeCandidatesPerBucket_Case4_Old |     2.5524 ns |  0.0511 ns |  0.0478 ns |
|      DenseWithThreeCandidatesPerBucket_Case5_New |     1.2282 ns |  0.0090 ns |  0.0085 ns |
|      DenseWithThreeCandidatesPerBucket_Case5_Old |     2.6004 ns |  0.0176 ns |  0.0164 ns |
|      DenseWithThreeCandidatesPerBucket_Case6_New |     1.6493 ns |  0.0158 ns |  0.0148 ns |
|      DenseWithThreeCandidatesPerBucket_Case6_Old |     3.0091 ns |  0.0228 ns |  0.0178 ns |
|      DenseWithThreeCandidatesPerBucket_Case7_New |     0.8738 ns |  0.0143 ns |  0.0133 ns |
|      DenseWithThreeCandidatesPerBucket_Case7_Old |     2.9503 ns |  0.0251 ns |  0.0196 ns |
|      DenseWithThreeCandidatesPerBucket_Case8_New |     1.2224 ns |  0.0132 ns |  0.0123 ns |
|      DenseWithThreeCandidatesPerBucket_Case8_Old |     2.7388 ns |  0.0173 ns |  0.0153 ns |
|      DenseWithThreeCandidatesPerBucket_Case9_New |     1.4321 ns |  0.0061 ns |  0.0051 ns |
|      DenseWithThreeCandidatesPerBucket_Case9_Old |     2.7540 ns |  0.0156 ns |  0.0138 ns |

| SparseLongWithThreeCandidatesPerBucket_Case1_New |    14.5882 ns |  0.0748 ns |  0.0734 ns |
| SparseLongWithThreeCandidatesPerBucket_Case1_Old |    14.5781 ns |  0.0194 ns |  0.0182 ns |
| SparseLongWithThreeCandidatesPerBucket_Case2_New |    15.5492 ns |  0.0276 ns |  0.0215 ns |
| SparseLongWithThreeCandidatesPerBucket_Case2_Old |    15.3750 ns |  0.0432 ns |  0.0383 ns |
| SparseLongWithThreeCandidatesPerBucket_Case3_New |    14.4727 ns |  0.0341 ns |  0.0302 ns |
| SparseLongWithThreeCandidatesPerBucket_Case3_Old |    14.2530 ns |  0.0206 ns |  0.0183 ns |
| SparseLongWithThreeCandidatesPerBucket_Case4_New |    14.5517 ns |  0.0343 ns |  0.0286 ns |
| SparseLongWithThreeCandidatesPerBucket_Case4_Old |    14.3480 ns |  0.0267 ns |  0.0236 ns |
| SparseLongWithThreeCandidatesPerBucket_Case5_New |    14.4211 ns |  0.0234 ns |  0.0196 ns |
| SparseLongWithThreeCandidatesPerBucket_Case5_Old |    14.3083 ns |  0.0672 ns |  0.0596 ns |
| SparseLongWithThreeCandidatesPerBucket_Case6_New |    15.6058 ns |  0.0333 ns |  0.0312 ns |
| SparseLongWithThreeCandidatesPerBucket_Case6_Old |    15.3582 ns |  0.0884 ns |  0.0827 ns |
| SparseLongWithThreeCandidatesPerBucket_Case7_New |    14.1825 ns |  0.0566 ns |  0.0501 ns |
| SparseLongWithThreeCandidatesPerBucket_Case7_Old |    14.1895 ns |  0.0464 ns |  0.0411 ns |
| SparseLongWithThreeCandidatesPerBucket_Case8_New |    14.4031 ns |  0.0172 ns |  0.0134 ns |
| SparseLongWithThreeCandidatesPerBucket_Case8_Old |    14.3670 ns |  0.0732 ns |  0.0685 ns |
| SparseLongWithThreeCandidatesPerBucket_Case9_New |    14.5255 ns |  0.1751 ns |  0.1638 ns |
| SparseLongWithThreeCandidatesPerBucket_Case9_Old |    14.4348 ns |  0.0569 ns |  0.0505 ns |
|   SparseLongWithThreeCandidatesPerBucket_Mix_New |   150.7844 ns |  0.5945 ns |  0.5561 ns |
|   SparseLongWithThreeCandidatesPerBucket_Mix_Old |   149.6289 ns |  0.7926 ns |  0.7414 ns |
|       DenseWithFourCandidatesPerBucket_Case1_New |     2.0698 ns |  0.0084 ns |  0.0079 ns |
|       DenseWithFourCandidatesPerBucket_Case1_Old |     2.1139 ns |  0.0080 ns |  0.0075 ns |
|       DenseWithFourCandidatesPerBucket_Case2_New |     1.2398 ns |  0.0073 ns |  0.0065 ns |
|       DenseWithFourCandidatesPerBucket_Case2_Old |     2.6767 ns |  0.0130 ns |  0.0115 ns |
|       DenseWithFourCandidatesPerBucket_Case3_New |     1.6482 ns |  0.0098 ns |  0.0087 ns |
|       DenseWithFourCandidatesPerBucket_Case3_Old |     2.8893 ns |  0.0556 ns |  0.0520 ns |
|       DenseWithFourCandidatesPerBucket_Case4_New |     2.1275 ns |  0.0287 ns |  0.0268 ns |
|       DenseWithFourCandidatesPerBucket_Case4_Old |     2.7723 ns |  0.0697 ns |  0.0618 ns |
|       DenseWithFourCandidatesPerBucket_Case5_New |     1.0690 ns |  0.0093 ns |  0.0078 ns |
|       DenseWithFourCandidatesPerBucket_Case5_Old |     3.0071 ns |  0.0039 ns |  0.0031 ns |
|       DenseWithFourCandidatesPerBucket_Case6_New |     1.2341 ns |  0.0125 ns |  0.0110 ns |
|       DenseWithFourCandidatesPerBucket_Case6_Old |     2.8861 ns |  0.0764 ns |  0.0849 ns |
|       DenseWithFourCandidatesPerBucket_Case7_New |     1.8521 ns |  0.0081 ns |  0.0068 ns |
|       DenseWithFourCandidatesPerBucket_Case7_Old |     2.9065 ns |  0.0577 ns |  0.0511 ns |
|       DenseWithFourCandidatesPerBucket_Case8_New |     2.2778 ns |  0.0121 ns |  0.0113 ns |
|       DenseWithFourCandidatesPerBucket_Case8_Old |     2.5948 ns |  0.0254 ns |  0.0238 ns |
|       DenseWithFourCandidatesPerBucket_Case9_New |     0.8578 ns |  0.0073 ns |  0.0068 ns |
|       DenseWithFourCandidatesPerBucket_Case9_Old |     2.8550 ns |  0.0162 ns |  0.0144 ns |
|      DenseWithFourCandidatesPerBucket_Case10_New |     1.2199 ns |  0.0028 ns |  0.0025 ns |
|      DenseWithFourCandidatesPerBucket_Case10_Old |     2.5491 ns |  0.0069 ns |  0.0061 ns |
|      DenseWithFourCandidatesPerBucket_Case11_New |     1.6427 ns |  0.0059 ns |  0.0052 ns |
|      DenseWithFourCandidatesPerBucket_Case11_Old |     2.9011 ns |  0.0216 ns |  0.0202 ns |
|      DenseWithFourCandidatesPerBucket_Case12_New |     2.0654 ns |  0.0073 ns |  0.0068 ns |
|      DenseWithFourCandidatesPerBucket_Case12_Old |     2.9133 ns |  0.0269 ns |  0.0251 ns |
|      SparseWithFourCandidatesPerBucket_Case1_New |     1.0511 ns |  0.0032 ns |  0.0027 ns |
|      SparseWithFourCandidatesPerBucket_Case1_Old |     2.7924 ns |  0.0713 ns |  0.0667 ns |
|      SparseWithFourCandidatesPerBucket_Case2_New |     1.2225 ns |  0.0071 ns |  0.0066 ns |
|      SparseWithFourCandidatesPerBucket_Case2_Old |     2.7958 ns |  0.0485 ns |  0.0430 ns |
|      SparseWithFourCandidatesPerBucket_Case3_New |     1.4508 ns |  0.0124 ns |  0.0116 ns |
|      SparseWithFourCandidatesPerBucket_Case3_Old |     2.9103 ns |  0.0295 ns |  0.0261 ns |
|      SparseWithFourCandidatesPerBucket_Case4_New |     1.9560 ns |  0.0598 ns |  0.0560 ns |
|      SparseWithFourCandidatesPerBucket_Case4_Old |     2.9244 ns |  0.0209 ns |  0.0196 ns |
|      SparseWithFourCandidatesPerBucket_Case5_New |     1.0390 ns |  0.0100 ns |  0.0089 ns |
|      SparseWithFourCandidatesPerBucket_Case5_Old |     2.8518 ns |  0.0115 ns |  0.0102 ns |
|      SparseWithFourCandidatesPerBucket_Case6_New |     1.2224 ns |  0.0087 ns |  0.0081 ns |
|      SparseWithFourCandidatesPerBucket_Case6_Old |     2.7478 ns |  0.0173 ns |  0.0162 ns |
|      SparseWithFourCandidatesPerBucket_Case7_New |     1.6353 ns |  0.0045 ns |  0.0035 ns |
|      SparseWithFourCandidatesPerBucket_Case7_Old |     2.9018 ns |  0.0254 ns |  0.0237 ns |
|      SparseWithFourCandidatesPerBucket_Case8_New |     2.0566 ns |  0.0043 ns |  0.0040 ns |
|      SparseWithFourCandidatesPerBucket_Case8_Old |     2.9059 ns |  0.0256 ns |  0.0227 ns |
|      SparseWithFourCandidatesPerBucket_Case9_New |     1.2595 ns |  0.0028 ns |  0.0025 ns |
|      SparseWithFourCandidatesPerBucket_Case9_Old |     2.9654 ns |  0.0126 ns |  0.0118 ns |
|     SparseWithFourCandidatesPerBucket_Case10_New |     1.0982 ns |  0.0074 ns |  0.0070 ns |
|     SparseWithFourCandidatesPerBucket_Case10_Old |     2.9560 ns |  0.0157 ns |  0.0139 ns |
|     SparseWithFourCandidatesPerBucket_Case11_New |     1.4890 ns |  0.0032 ns |  0.0025 ns |
|     SparseWithFourCandidatesPerBucket_Case11_Old |     2.6780 ns |  0.0179 ns |  0.0149 ns |
|     SparseWithFourCandidatesPerBucket_Case12_New |     1.8782 ns |  0.0131 ns |  0.0116 ns |
|     SparseWithFourCandidatesPerBucket_Case12_Old |     2.7053 ns |  0.0246 ns |  0.0230 ns |
|  SparseLongWithFourCandidatesPerBucket_Case1_New |    14.7843 ns |  0.0807 ns |  0.0674 ns |
|  SparseLongWithFourCandidatesPerBucket_Case1_Old |    14.6838 ns |  0.0222 ns |  0.0186 ns |
|  SparseLongWithFourCandidatesPerBucket_Case2_New |    14.4833 ns |  0.0617 ns |  0.0515 ns |
|  SparseLongWithFourCandidatesPerBucket_Case2_Old |    14.7110 ns |  0.0988 ns |  0.0876 ns |
|  SparseLongWithFourCandidatesPerBucket_Case3_New |    14.5274 ns |  0.0610 ns |  0.0571 ns |
|  SparseLongWithFourCandidatesPerBucket_Case3_Old |    14.4219 ns |  0.0358 ns |  0.0317 ns |
|  SparseLongWithFourCandidatesPerBucket_Case4_New |    15.7076 ns |  0.0412 ns |  0.0365 ns |
|  SparseLongWithFourCandidatesPerBucket_Case4_Old |    15.5833 ns |  0.0490 ns |  0.0458 ns |
|  SparseLongWithFourCandidatesPerBucket_Case5_New |    14.6921 ns |  0.0532 ns |  0.0472 ns |
|  SparseLongWithFourCandidatesPerBucket_Case5_Old |    14.7157 ns |  0.0378 ns |  0.0335 ns |
|  SparseLongWithFourCandidatesPerBucket_Case6_New |    14.6484 ns |  0.0612 ns |  0.0572 ns |
|  SparseLongWithFourCandidatesPerBucket_Case6_Old |    14.6850 ns |  0.0490 ns |  0.0409 ns |
|  SparseLongWithFourCandidatesPerBucket_Case7_New |    14.4594 ns |  0.1219 ns |  0.1140 ns |
|  SparseLongWithFourCandidatesPerBucket_Case7_Old |    14.4818 ns |  0.0417 ns |  0.0390 ns |
|  SparseLongWithFourCandidatesPerBucket_Case8_New |    15.5012 ns |  0.0931 ns |  0.0727 ns |
|  SparseLongWithFourCandidatesPerBucket_Case8_Old |    15.6793 ns |  0.0509 ns |  0.0451 ns |
|  SparseLongWithFourCandidatesPerBucket_Case9_New |    14.6379 ns |  0.0373 ns |  0.0349 ns |
|  SparseLongWithFourCandidatesPerBucket_Case9_Old |    14.5471 ns |  0.0248 ns |  0.0194 ns |
| SparseLongWithFourCandidatesPerBucket_Case10_New |    14.4847 ns |  0.0404 ns |  0.0338 ns |
| SparseLongWithFourCandidatesPerBucket_Case10_Old |    14.4785 ns |  0.0568 ns |  0.0531 ns |
| SparseLongWithFourCandidatesPerBucket_Case11_New |    14.6776 ns |  0.0534 ns |  0.0473 ns |
| SparseLongWithFourCandidatesPerBucket_Case11_Old |    14.5545 ns |  0.0371 ns |  0.0329 ns |
| SparseLongWithFourCandidatesPerBucket_Case12_New |    14.5071 ns |  0.0813 ns |  0.0721 ns |
| SparseLongWithFourCandidatesPerBucket_Case12_Old |    14.7037 ns |  0.0499 ns |  0.0443 ns |
|      SparseWithFiveCandidatesPerBucket_Case1_New |     1.0590 ns |  0.0100 ns |  0.0083 ns |
|      SparseWithFiveCandidatesPerBucket_Case1_Old |     3.2311 ns |  0.0149 ns |  0.0132 ns |
|      SparseWithFiveCandidatesPerBucket_Case2_New |     1.0833 ns |  0.0431 ns |  0.0382 ns |
|      SparseWithFiveCandidatesPerBucket_Case2_Old |     3.0322 ns |  0.0150 ns |  0.0125 ns |
|      SparseWithFiveCandidatesPerBucket_Case3_New |     1.6373 ns |  0.0069 ns |  0.0065 ns |
|      SparseWithFiveCandidatesPerBucket_Case3_Old |     2.6822 ns |  0.0140 ns |  0.0117 ns |
|      SparseWithFiveCandidatesPerBucket_Case4_New |     2.0556 ns |  0.0089 ns |  0.0083 ns |
|      SparseWithFiveCandidatesPerBucket_Case4_Old |     2.9534 ns |  0.0116 ns |  0.0109 ns |
|      SparseWithFiveCandidatesPerBucket_Case5_New |     2.4704 ns |  0.0034 ns |  0.0030 ns |
|      SparseWithFiveCandidatesPerBucket_Case5_Old |     2.9153 ns |  0.0289 ns |  0.0270 ns |
|      SparseWithFiveCandidatesPerBucket_Case6_New |     0.8490 ns |  0.0033 ns |  0.0027 ns |
|      SparseWithFiveCandidatesPerBucket_Case6_Old |     3.4324 ns |  0.0152 ns |  0.0142 ns |
|      SparseWithFiveCandidatesPerBucket_Case7_New |     1.2171 ns |  0.0093 ns |  0.0078 ns |
|      SparseWithFiveCandidatesPerBucket_Case7_Old |     3.0010 ns |  0.0087 ns |  0.0077 ns |
|      SparseWithFiveCandidatesPerBucket_Case8_New |     1.6413 ns |  0.0096 ns |  0.0090 ns |
|      SparseWithFiveCandidatesPerBucket_Case8_Old |     3.0075 ns |  0.0116 ns |  0.0103 ns |
|      SparseWithFiveCandidatesPerBucket_Case9_New |     2.0662 ns |  0.0086 ns |  0.0076 ns |
|      SparseWithFiveCandidatesPerBucket_Case9_Old |     3.0003 ns |  0.0030 ns |  0.0025 ns |
|     SparseWithFiveCandidatesPerBucket_Case10_New |     2.4713 ns |  0.0069 ns |  0.0054 ns |
|     SparseWithFiveCandidatesPerBucket_Case10_Old |     2.9575 ns |  0.0102 ns |  0.0095 ns |
|     SparseWithFiveCandidatesPerBucket_Case11_New |     1.2585 ns |  0.0026 ns |  0.0020 ns |
|     SparseWithFiveCandidatesPerBucket_Case11_Old |     2.9554 ns |  0.0233 ns |  0.0207 ns |
|     SparseWithFiveCandidatesPerBucket_Case12_New |     1.2671 ns |  0.0023 ns |  0.0019 ns |
|     SparseWithFiveCandidatesPerBucket_Case12_Old |     3.4088 ns |  0.0111 ns |  0.0099 ns |
|     SparseWithFiveCandidatesPerBucket_Case13_New |     1.8325 ns |  0.0088 ns |  0.0073 ns |
|     SparseWithFiveCandidatesPerBucket_Case13_Old |     2.7409 ns |  0.0135 ns |  0.0113 ns |
|     SparseWithFiveCandidatesPerBucket_Case14_New |     2.2543 ns |  0.0117 ns |  0.0109 ns |
|     SparseWithFiveCandidatesPerBucket_Case14_Old |     2.8958 ns |  0.0156 ns |  0.0146 ns |
|     SparseWithFiveCandidatesPerBucket_Case15_New |     2.6738 ns |  0.0096 ns |  0.0085 ns |
|     SparseWithFiveCandidatesPerBucket_Case15_Old |     3.2204 ns |  0.0116 ns |  0.0097 ns |

|   SparseLongWithFiveCandidatesPerBucket_Case1_New |  17.13 ns | 0.113 ns |  0.106 ns |  17.11 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case1_Old |  16.94 ns | 0.161 ns |  0.151 ns |  16.94 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case1_Trie |  15.95 ns | 0.110 ns |  0.103 ns |  15.92 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case2_New |  16.88 ns | 0.081 ns |  0.071 ns |  16.89 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case2_Old |  15.23 ns | 0.136 ns |  0.128 ns |  15.22 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case2_Trie |  15.80 ns | 0.142 ns |  0.133 ns |  15.78 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case3_New |  16.15 ns | 0.075 ns |  0.067 ns |  16.15 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case3_Old |  16.22 ns | 0.187 ns |  0.175 ns |  16.17 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case3_Trie |  15.81 ns | 0.193 ns |  0.181 ns |  15.83 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case4_New |  15.47 ns | 0.062 ns |  0.058 ns |  15.48 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case4_Old |  15.33 ns | 0.084 ns |  0.078 ns |  15.31 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case4_Trie |  15.43 ns | 0.185 ns |  0.173 ns |  15.37 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case5_New |  15.52 ns | 0.066 ns |  0.055 ns |  15.53 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case5_Old |  15.19 ns | 0.083 ns |  0.078 ns |  15.21 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case5_Trie |  15.56 ns | 0.243 ns |  0.228 ns |  15.56 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case6_New |  15.37 ns | 0.120 ns |  0.107 ns |  15.39 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case6_Old |  15.25 ns | 0.188 ns |  0.175 ns |  15.22 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case6_Trie |  15.55 ns | 0.070 ns |  0.062 ns |  15.56 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case7_New |  15.53 ns | 0.160 ns |  0.150 ns |  15.52 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case7_Old |  15.27 ns | 0.138 ns |  0.129 ns |  15.28 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case7_Trie |  15.95 ns | 0.111 ns |  0.104 ns |  15.93 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case8_New |  15.57 ns | 0.080 ns |  0.071 ns |  15.56 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case8_Old |  15.38 ns | 0.085 ns |  0.080 ns |  15.40 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case8_Trie |  16.65 ns | 0.269 ns |  0.251 ns |  16.66 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case9_New |  15.33 ns | 0.084 ns |  0.079 ns |  15.31 ns |
|   SparseLongWithFiveCandidatesPerBucket_Case9_Old |  14.88 ns | 0.211 ns |  0.197 ns |  14.93 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case9_Trie |  15.40 ns | 0.173 ns |  0.162 ns |  15.41 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case10_New |  15.14 ns | 0.076 ns |  0.064 ns |  15.12 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case10_Old |  15.51 ns | 0.287 ns |  0.254 ns |  15.45 ns |
| SparseLongWithFiveCandidatesPerBucket_Case10_Trie |  15.80 ns | 0.208 ns |  0.194 ns |  15.81 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case11_New |  15.08 ns | 0.051 ns |  0.045 ns |  15.08 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case11_Old |  14.92 ns | 0.119 ns |  0.112 ns |  14.93 ns |
| SparseLongWithFiveCandidatesPerBucket_Case11_Trie |  15.35 ns | 0.095 ns |  0.084 ns |  15.33 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case12_New |  15.12 ns | 0.066 ns |  0.058 ns |  15.14 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case12_Old |  14.73 ns | 0.097 ns |  0.091 ns |  14.71 ns |
| SparseLongWithFiveCandidatesPerBucket_Case12_Trie |  16.05 ns | 0.106 ns |  0.099 ns |  16.07 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case13_New |  15.12 ns | 0.092 ns |  0.081 ns |  15.12 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case13_Old |  14.84 ns | 0.105 ns |  0.098 ns |  14.81 ns |
| SparseLongWithFiveCandidatesPerBucket_Case13_Trie |  16.16 ns | 0.084 ns |  0.078 ns |  16.19 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case14_New |  15.34 ns | 0.089 ns |  0.083 ns |  15.34 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case14_Old |  15.04 ns | 0.088 ns |  0.083 ns |  15.05 ns |
| SparseLongWithFiveCandidatesPerBucket_Case14_Trie |  15.95 ns | 0.108 ns |  0.096 ns |  15.92 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case15_New |  15.16 ns | 0.042 ns |  0.039 ns |  15.15 ns |
|  SparseLongWithFiveCandidatesPerBucket_Case15_Old |  14.91 ns | 0.053 ns |  0.047 ns |  14.90 ns |
| SparseLongWithFiveCandidatesPerBucket_Case15_Trie |  16.31 ns | 0.178 ns |  0.167 ns |  16.31 ns |
|     SparseLongWithFiveCandidatesPerBucket_Mix_New | 379.81 ns | 7.578 ns | 16.635 ns | 371.84 ns |
|     SparseLongWithFiveCandidatesPerBucket_Mix_Old | 355.55 ns | 2.950 ns |  2.615 ns | 355.07 ns |
|    SparseLongWithFiveCandidatesPerBucket_Mix_Trie | 377.79 ns | 2.903 ns |  2.715 ns | 378.43 ns |

|       SparseWithSixCandidatesPerBucket_Case1_New |     1.0537 ns |  0.0066 ns |  0.0058 ns |
|       SparseWithSixCandidatesPerBucket_Case1_Old |     2.5367 ns |  0.0066 ns |  0.0051 ns |
|       SparseWithSixCandidatesPerBucket_Case2_New |     1.0617 ns |  0.0035 ns |  0.0032 ns |
|       SparseWithSixCandidatesPerBucket_Case2_Old |     2.6587 ns |  0.0035 ns |  0.0029 ns |
|       SparseWithSixCandidatesPerBucket_Case3_New |     1.4321 ns |  0.0077 ns |  0.0069 ns |
|       SparseWithSixCandidatesPerBucket_Case3_Old |     2.4581 ns |  0.0089 ns |  0.0083 ns |
|       SparseWithSixCandidatesPerBucket_Case4_New |     1.8506 ns |  0.0078 ns |  0.0069 ns |
|       SparseWithSixCandidatesPerBucket_Case4_Old |     2.6474 ns |  0.0037 ns |  0.0029 ns |
|       SparseWithSixCandidatesPerBucket_Case5_New |     2.2773 ns |  0.0110 ns |  0.0098 ns |
|       SparseWithSixCandidatesPerBucket_Case5_Old |     2.4860 ns |  0.0085 ns |  0.0075 ns |
|       SparseWithSixCandidatesPerBucket_Case6_New |     2.6921 ns |  0.0051 ns |  0.0045 ns |
|       SparseWithSixCandidatesPerBucket_Case6_Old |     2.6570 ns |  0.0095 ns |  0.0084 ns |
|       SparseWithSixCandidatesPerBucket_Case7_New |     0.8439 ns |  0.0022 ns |  0.0017 ns |
|       SparseWithSixCandidatesPerBucket_Case7_Old |     2.8635 ns |  0.0064 ns |  0.0054 ns |
|       SparseWithSixCandidatesPerBucket_Case8_New |     1.0426 ns |  0.0305 ns |  0.0286 ns |
|       SparseWithSixCandidatesPerBucket_Case8_Old |     2.7406 ns |  0.0101 ns |  0.0090 ns |
|       SparseWithSixCandidatesPerBucket_Case9_New |     1.4519 ns |  0.0112 ns |  0.0100 ns |
|       SparseWithSixCandidatesPerBucket_Case9_Old |     2.4627 ns |  0.0127 ns |  0.0119 ns |
|      SparseWithSixCandidatesPerBucket_Case10_New |     1.8680 ns |  0.0111 ns |  0.0104 ns |
|      SparseWithSixCandidatesPerBucket_Case10_Old |     2.5152 ns |  0.0324 ns |  0.0287 ns |
|      SparseWithSixCandidatesPerBucket_Case11_New |     2.2978 ns |  0.0064 ns |  0.0054 ns |
|      SparseWithSixCandidatesPerBucket_Case11_Old |     2.6586 ns |  0.0112 ns |  0.0099 ns |
|      SparseWithSixCandidatesPerBucket_Case12_New |     2.5312 ns |  0.0090 ns |  0.0080 ns |
|      SparseWithSixCandidatesPerBucket_Case12_Old |     2.5343 ns |  0.0089 ns |  0.0074 ns |

|     SparseWithSevenCandidatesPerBucket_Case1_New |     2.6807 ns |  0.0061 ns |  0.0051 ns |
|     SparseWithSevenCandidatesPerBucket_Case1_Old |     2.6940 ns |  0.0316 ns |  0.0280 ns |
|     SparseWithSevenCandidatesPerBucket_Case2_New |     2.7390 ns |  0.0065 ns |  0.0054 ns |
|     SparseWithSevenCandidatesPerBucket_Case2_Old |     2.7365 ns |  0.0144 ns |  0.0128 ns |
|     SparseWithSevenCandidatesPerBucket_Case3_New |     2.5388 ns |  0.0102 ns |  0.0086 ns |
|     SparseWithSevenCandidatesPerBucket_Case3_Old |     2.4892 ns |  0.0107 ns |  0.0095 ns |
|     SparseWithSevenCandidatesPerBucket_Case4_New |     2.6819 ns |  0.0061 ns |  0.0051 ns |
|     SparseWithSevenCandidatesPerBucket_Case4_Old |     2.6634 ns |  0.0049 ns |  0.0038 ns |
|     SparseWithSevenCandidatesPerBucket_Case5_New |     2.7435 ns |  0.0047 ns |  0.0039 ns |
|     SparseWithSevenCandidatesPerBucket_Case5_Old |     2.5191 ns |  0.0097 ns |  0.0086 ns |
|     SparseWithSevenCandidatesPerBucket_Case6_New |     2.9504 ns |  0.0072 ns |  0.0064 ns |
|     SparseWithSevenCandidatesPerBucket_Case6_Old |     2.8850 ns |  0.0180 ns |  0.0168 ns |
|     SparseWithSevenCandidatesPerBucket_Case7_New |     2.7428 ns |  0.0045 ns |  0.0040 ns |
|     SparseWithSevenCandidatesPerBucket_Case7_Old |     2.9639 ns |  0.0127 ns |  0.0106 ns |
|     SparseWithSevenCandidatesPerBucket_Case8_New |     2.8884 ns |  0.0101 ns |  0.0095 ns |
|     SparseWithSevenCandidatesPerBucket_Case8_Old |     2.9472 ns |  0.0036 ns |  0.0028 ns |
|     SparseWithSevenCandidatesPerBucket_Case9_New |     2.6875 ns |  0.0149 ns |  0.0139 ns |
|     SparseWithSevenCandidatesPerBucket_Case9_Old |     2.7519 ns |  0.0196 ns |  0.0174 ns |
|    SparseWithSevenCandidatesPerBucket_Case10_New |     2.4807 ns |  0.0027 ns |  0.0021 ns |
|    SparseWithSevenCandidatesPerBucket_Case10_Old |     2.5361 ns |  0.0102 ns |  0.0090 ns |
|    SparseWithSevenCandidatesPerBucket_Case11_New |     2.6784 ns |  0.0053 ns |  0.0042 ns |
|    SparseWithSevenCandidatesPerBucket_Case11_Old |     2.5262 ns |  0.0122 ns |  0.0108 ns |
|    SparseWithSevenCandidatesPerBucket_Case12_New |     2.5394 ns |  0.0063 ns |  0.0053 ns |
|    SparseWithSevenCandidatesPerBucket_Case12_Old |     2.6889 ns |  0.0104 ns |  0.0087 ns |
|    SparseWithSevenCandidatesPerBucket_Case13_New |     2.8806 ns |  0.0063 ns |  0.0049 ns |
|    SparseWithSevenCandidatesPerBucket_Case13_Old |     2.7196 ns |  0.0135 ns |  0.0120 ns |
|    SparseWithSevenCandidatesPerBucket_Case14_New |     2.4718 ns |  0.0108 ns |  0.0095 ns |
|    SparseWithSevenCandidatesPerBucket_Case14_Old |     2.6667 ns |  0.0203 ns |  0.0180 ns |
*/
public partial class LengthVsHashCode
{
    //[Benchmark]
    //public int Switch1New() => NewRoslyn.Switch1();
    //[Benchmark]
    //public int Switch1Old() => OldRoslyn.Switch1();

    //[Benchmark]
    //public int NotALengthMatchNew() => NewRoslyn.NotALengthMatch();
    //[Benchmark]
    //public int NotALengthMatchOld() => OldRoslyn.NotALengthMatch();

    //[Benchmark]
    //public int DenseNew() => NewRoslyn.Dense();
    //[Benchmark]
    //public int DenseOld() => OldRoslyn.Dense();

    //[Benchmark]
    //public int DenseFew_Match_New() => NewRoslyn.DenseFew_Match();
    //[Benchmark]
    //public int DenseFew_Match_Old() => OldRoslyn.DenseFew_Match();

    //[Benchmark]
    //public int DenseFew_DoesNotMatch_New() => NewRoslyn.DenseFew_DoesNotMatch();
    //[Benchmark]
    //public int DenseFew_DoesNotMatch_Old() => OldRoslyn.DenseFew_DoesNotMatch();

    //[Benchmark]
    //public int SparseFew_Match_New() => NewRoslyn.SparseFew_Match();
    //[Benchmark]
    //public int SparseFew_Match_Old() => OldRoslyn.SparseFew_Match();

    //[Benchmark]
    //public int SparseFew_DoesNotMatch_New() => NewRoslyn.SparseFew_DoesNotMatch();
    //[Benchmark]
    //public int SparseFew_DoesNotMatch_Old() => OldRoslyn.SparseFew_DoesNotMatch();

    //[Benchmark]
    //public int ContentTypeNew() => NewRoslyn.ContentType();
    //[Benchmark]
    //public int ContentTypeOld() => OldRoslyn.ContentType();
    //[Benchmark]
    //public int ContentTypeAsListPattern() => OldRoslyn.ContentTypeAsListPattern();

    //[Benchmark]
    //public int CyrusSwitch() => OldRoslyn.CyrusSwitch();
    //[Benchmark]
    //public int CyrusTrie() => OldRoslyn.CyrusTrie();
    //[Benchmark]
    //public int CyrusTrieWithoutOptimizations() => OldRoslyn.CyrusTrieWithoutOptimizations();
}
public class LengthVsHashCode_ShortSwitch
{
    [Params("GET", "POST", "PUT", "DELETE")]
    public string Value { get; set; }

    [Benchmark]
    public int ShortSwitch_FirstCase_New() => NewRoslyn.ShortSwitchCore(Value);
    [Benchmark]
    public int ShortSwitch_FirstCase_Old() => OldRoslyn.ShortSwitchCore(Value);
}
public partial class LengthVsHashCode
{
    [Benchmark]
    public DriveType GetDriveType_Mix_New() => NewRoslyn.GetDriveType_Mix();
    [Benchmark]
    public DriveType GetDriveType_Mix_Old() => OldRoslyn.GetDriveType_Mix();
}
public partial class LengthVsHashCode_DenseWithTwoCandidatesPerBucket
{
    [Params("aba", "abb", "baa", "bab", "cdc", "cdd", "dcc", "dcd", "efe", "eff", "fee", "fef")]
    public string Value { get; set; }

    [Benchmark]
    public int DenseWithTwoCandidatesPerBucket_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket(Value);
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
    public int SparseLongWithThreeCandidatesPerBucket_Old() => OldRoslyn.SparseLongWithThreeCandidatesPerBucket(Value);
}
public partial class LengthVsHashCode
{
    [Benchmark]
    public int SparseLongWithThreeCandidatesPerBucket_Mix_New() => NewRoslyn.SparseLongWithThreeCandidatesPerBucket_Mix();
    [Benchmark]
    public int SparseLongWithThreeCandidatesPerBucket_Mix_Old() => OldRoslyn.SparseLongWithThreeCandidatesPerBucket_Mix();
}
public class LengthVsHashCode_DenseWithFourCandidatesPerBucket
{
    [Params("aad", "aba", "acb", "adc", "bad", "bba", "bcb", "bdc", "cad", "cba", "ccb", "cdc", "dad", "dba", "dcb", "ddc")]
    public string Value { get; set; }

    [Benchmark]
    public int DenseWithFourCandidatesPerBucket_New() => NewRoslyn.DenseWithFourCandidatesPerBucket(Value);
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
    public int SparseLongWithFourCandidatesPerBucket_Old() => OldRoslyn.SparseLongWithFourCandidatesPerBucket(Value);
}
public partial class LengthVsHashCode_SparseWithFiveCandidatesPerBucket
{
    [Params("aaA", "aia", "aqi", "ayq", "aAy", "iaA", "iia", "iqi", "iyq", "iAy", "qaA", "qia", "qqi", "qyq", "qAy", "yaA", "yia", "yqi", "yyq", "yAy")]
    public string Value { get; set; }

    [Benchmark]
    public int SparseWithFiveCandidatesPerBucket_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket(Value);
    [Benchmark]
    public int SparseWithFiveCandidatesPerBucket_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket(Value);
    [Benchmark]
    public int SparseWithFiveCandidatesPerBucket_Trie() => OldRoslyn.SparseWithFiveCandidatesPerBucketTrie(Value);
}
public partial class LengthVsHashCode
{
    //[Benchmark]
    //public int SparseWithSixCandidatesPerBucket_New() => NewRoslyn.SparseWithSixCandidatesPerBucket_Case1();
    //[Benchmark]
    //public int SparseWithSixCandidatesPerBucket_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket_Case1();
}
public partial class LengthVsHashCode
{

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case1();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case1();
}
public partial class LengthVsHashCode
{

    //[Benchmark]
    //public int GetHashCodeBenchmark()
    //{
    //    int last = 0;
    //    for (int i = 0; i < 1000; i++)
    //    {
    //        last = "hello world".GetHashCode();
    //    }
    //    return last;
    //}

    //string field = "hello world";
    //[Benchmark]
    //public int StringEquality()
    //{
    //    string value = field;
    //    string other = "hello worl";
    //    other += "d";
    //    int last = 0;
    //    for (int i = 0; i < 1000; i++)
    //    {
    //        last = other == value ? 0 : 1;
    //    }
    //    return last;
    //}
}
