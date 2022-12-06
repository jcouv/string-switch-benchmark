﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<LengthVsHashCode>();

/*
|                                       Method |          Mean |      Error |     StdDev |
|--------------------------------------------- |--------------:|-----------:|-----------:|
|                                   Switch1New |    27.8354 ns |  0.2403 ns |  0.2130 ns |
|                                   Switch1Old |    44.8823 ns |  0.2538 ns |  0.2120 ns |
|                           NotALengthMatchNew |     0.4240 ns |  0.0028 ns |  0.0025 ns |
|                           NotALengthMatchOld |     5.4919 ns |  0.0080 ns |  0.0071 ns |
|                                     DenseNew | 1,029.7080 ns | 20.0111 ns | 20.5499 ns |
|                                     DenseOld |   962.5248 ns | 10.2100 ns |  9.5504 ns |
|                                  DenseFewNew |   168.8721 ns |  2.9597 ns |  2.7685 ns |
|                                  DenseFewOld |   149.3897 ns |  0.8174 ns |  0.7246 ns |
|                                    SparseNew | 1,309.9482 ns | 11.2266 ns |  9.9521 ns |
|                                    SparseOld | 1,510.6280 ns |  6.8189 ns |  6.0447 ns |
|                               ContentTypeNew |    13.5610 ns |  0.1688 ns |  0.1579 ns |
|                               ContentTypeOld |    25.8446 ns |  0.1119 ns |  0.0934 ns |
|                     ContentTypeAsListPattern |    17.4950 ns |  0.0487 ns |  0.0407 ns |
|                                  CyrusSwitch |    17.8296 ns |  0.0392 ns |  0.0306 ns |
|                                    CyrusTrie |   919.9889 ns |  2.2507 ns |  2.1053 ns |
|                CyrusTrieWithoutOptimizations |   920.0803 ns |  1.4677 ns |  1.2256 ns |
|                    ShortSwitch_FirstCase_New |     1.4850 ns |  0.0104 ns |  0.0086 ns |
|                    ShortSwitch_FirstCase_Old |     0.8461 ns |  0.0055 ns |  0.0046 ns |
|                   ShortSwitch_SecondCase_New |     1.0577 ns |  0.0024 ns |  0.0021 ns |
|                   ShortSwitch_SecondCase_Old |     0.6351 ns |  0.0027 ns |  0.0022 ns |
|                    ShortSwitch_ThirdCase_New |     1.3865 ns |  0.0125 ns |  0.0117 ns |
|                    ShortSwitch_ThirdCase_Old |     1.0599 ns |  0.0016 ns |  0.0014 ns |
|                   ShortSwitch_FourthCase_New |     1.2693 ns |  0.0034 ns |  0.0030 ns |
|                   ShortSwitch_FourthCase_Old |     1.4690 ns |  0.0077 ns |  0.0068 ns |
|           ShortSwitchLongWords_FirstCase_New |     1.4191 ns |  0.0037 ns |  0.0035 ns |
|           ShortSwitchLongWords_FirstCase_Old |     0.8517 ns |  0.0034 ns |  0.0028 ns |
|          ShortSwitchLongWords_SecondCase_New |     1.6544 ns |  0.0054 ns |  0.0045 ns |
|          ShortSwitchLongWords_SecondCase_Old |     1.0577 ns |  0.0024 ns |  0.0021 ns |
|           ShortSwitchLongWords_ThirdCase_New |     1.6734 ns |  0.0118 ns |  0.0110 ns |
|           ShortSwitchLongWords_ThirdCase_Old |     1.3039 ns |  0.0141 ns |  0.0125 ns |
|          ShortSwitchLongWords_FourthCase_New |     1.4210 ns |  0.0025 ns |  0.0022 ns |
|          ShortSwitchLongWords_FourthCase_Old |     1.4776 ns |  0.0056 ns |  0.0044 ns |
|                         GetDriveType_Mix_New |   224.4547 ns |  1.2165 ns |  1.0784 ns |
|                         GetDriveType_Mix_Old |   295.9894 ns |  1.4958 ns |  1.3992 ns |
|    DenseWithTwoCandidatesPerBucket_Case1_New |     1.1393 ns |  0.0046 ns |  0.0043 ns |
|    DenseWithTwoCandidatesPerBucket_Case1_Old |     2.4849 ns |  0.0051 ns |  0.0045 ns |
|    DenseWithTwoCandidatesPerBucket_Case2_New |     1.2267 ns |  0.0075 ns |  0.0070 ns |
|    DenseWithTwoCandidatesPerBucket_Case2_Old |     2.4010 ns |  0.0084 ns |  0.0079 ns |
|    DenseWithTwoCandidatesPerBucket_Case3_New |     1.2661 ns |  0.0028 ns |  0.0022 ns |
|    DenseWithTwoCandidatesPerBucket_Case3_Old |     2.6636 ns |  0.0043 ns |  0.0038 ns |
|    DenseWithTwoCandidatesPerBucket_Case4_New |     1.2769 ns |  0.0048 ns |  0.0042 ns |
|    DenseWithTwoCandidatesPerBucket_Case4_Old |     2.4889 ns |  0.0062 ns |  0.0055 ns |
|    DenseWithTwoCandidatesPerBucket_Case5_New |     1.0607 ns |  0.0036 ns |  0.0032 ns |
|    DenseWithTwoCandidatesPerBucket_Case5_Old |     2.7435 ns |  0.0084 ns |  0.0070 ns |
|    DenseWithTwoCandidatesPerBucket_Case6_New |     1.2748 ns |  0.0033 ns |  0.0030 ns |
|    DenseWithTwoCandidatesPerBucket_Case6_Old |     2.8724 ns |  0.0075 ns |  0.0071 ns |
|    DenseWithTwoCandidatesPerBucket_Case7_New |     1.2664 ns |  0.0043 ns |  0.0038 ns |
|    DenseWithTwoCandidatesPerBucket_Case7_Old |     2.6768 ns |  0.0231 ns |  0.0205 ns |
|    DenseWithTwoCandidatesPerBucket_Case8_New |     1.2792 ns |  0.0039 ns |  0.0030 ns |
|    DenseWithTwoCandidatesPerBucket_Case8_Old |     2.7392 ns |  0.0031 ns |  0.0026 ns |
|    DenseWithTwoCandidatesPerBucket_Case9_New |     1.2666 ns |  0.0029 ns |  0.0024 ns |
|    DenseWithTwoCandidatesPerBucket_Case9_Old |     2.6631 ns |  0.0054 ns |  0.0045 ns |
|   DenseWithTwoCandidatesPerBucket_Case10_New |     1.2312 ns |  0.0082 ns |  0.0073 ns |
|   DenseWithTwoCandidatesPerBucket_Case10_Old |     2.5423 ns |  0.0084 ns |  0.0079 ns |
|   DenseWithTwoCandidatesPerBucket_Case11_New |     1.0590 ns |  0.0027 ns |  0.0024 ns |
|   DenseWithTwoCandidatesPerBucket_Case11_Old |     2.4567 ns |  0.0065 ns |  0.0054 ns |
|   DenseWithTwoCandidatesPerBucket_Case12_New |     1.0230 ns |  0.0080 ns |  0.0075 ns |
|   DenseWithTwoCandidatesPerBucket_Case12_Old |     2.3068 ns |  0.0304 ns |  0.0285 ns |
|  DenseWithThreeCandidatesPerBucket_Case1_New |     1.1810 ns |  0.0074 ns |  0.0065 ns |
|  DenseWithThreeCandidatesPerBucket_Case1_Old |     2.9523 ns |  0.0055 ns |  0.0051 ns |
|  DenseWithThreeCandidatesPerBucket_Case2_New |     1.2220 ns |  0.0036 ns |  0.0032 ns |
|  DenseWithThreeCandidatesPerBucket_Case2_Old |     2.5649 ns |  0.0081 ns |  0.0063 ns |
|  DenseWithThreeCandidatesPerBucket_Case3_New |     1.6411 ns |  0.0035 ns |  0.0031 ns |
|  DenseWithThreeCandidatesPerBucket_Case3_Old |     2.7724 ns |  0.0086 ns |  0.0076 ns |
|  DenseWithThreeCandidatesPerBucket_Case4_New |     1.0589 ns |  0.0017 ns |  0.0016 ns |
|  DenseWithThreeCandidatesPerBucket_Case4_Old |     2.5827 ns |  0.0084 ns |  0.0079 ns |
|  DenseWithThreeCandidatesPerBucket_Case5_New |     1.2233 ns |  0.0043 ns |  0.0036 ns |
|  DenseWithThreeCandidatesPerBucket_Case5_Old |     2.5763 ns |  0.0047 ns |  0.0042 ns |
|  DenseWithThreeCandidatesPerBucket_Case6_New |     1.6455 ns |  0.0052 ns |  0.0046 ns |
|  DenseWithThreeCandidatesPerBucket_Case6_Old |     3.0061 ns |  0.0022 ns |  0.0021 ns |
|  DenseWithThreeCandidatesPerBucket_Case7_New |     1.0607 ns |  0.0018 ns |  0.0014 ns |
|  DenseWithThreeCandidatesPerBucket_Case7_Old |     2.9808 ns |  0.0099 ns |  0.0083 ns |
|  DenseWithThreeCandidatesPerBucket_Case8_New |     1.2220 ns |  0.0024 ns |  0.0019 ns |
|  DenseWithThreeCandidatesPerBucket_Case8_Old |     2.7393 ns |  0.0095 ns |  0.0089 ns |
|  DenseWithThreeCandidatesPerBucket_Case9_New |     1.4370 ns |  0.0075 ns |  0.0067 ns |
|  DenseWithThreeCandidatesPerBucket_Case9_Old |     2.7608 ns |  0.0087 ns |  0.0077 ns |
|   DenseWithFourCandidatesPerBucket_Case1_New |     2.0595 ns |  0.0050 ns |  0.0047 ns |
|   DenseWithFourCandidatesPerBucket_Case1_Old |     2.1113 ns |  0.0031 ns |  0.0029 ns |
|   DenseWithFourCandidatesPerBucket_Case2_New |     1.2779 ns |  0.0039 ns |  0.0034 ns |
|   DenseWithFourCandidatesPerBucket_Case2_Old |     2.6883 ns |  0.0070 ns |  0.0059 ns |
|   DenseWithFourCandidatesPerBucket_Case3_New |     1.6450 ns |  0.0047 ns |  0.0042 ns |
|   DenseWithFourCandidatesPerBucket_Case3_Old |     2.9289 ns |  0.0214 ns |  0.0200 ns |
|   DenseWithFourCandidatesPerBucket_Case4_New |     2.0620 ns |  0.0062 ns |  0.0058 ns |
|   DenseWithFourCandidatesPerBucket_Case4_Old |     2.7596 ns |  0.0134 ns |  0.0125 ns |
|   DenseWithFourCandidatesPerBucket_Case5_New |     1.0596 ns |  0.0037 ns |  0.0029 ns |
|   DenseWithFourCandidatesPerBucket_Case5_Old |     3.0073 ns |  0.0051 ns |  0.0045 ns |
|   DenseWithFourCandidatesPerBucket_Case6_New |     1.2302 ns |  0.0086 ns |  0.0072 ns |
|   DenseWithFourCandidatesPerBucket_Case6_Old |     2.9186 ns |  0.0192 ns |  0.0179 ns |
|   DenseWithFourCandidatesPerBucket_Case7_New |     1.8496 ns |  0.0047 ns |  0.0039 ns |
|   DenseWithFourCandidatesPerBucket_Case7_Old |     2.9409 ns |  0.0245 ns |  0.0230 ns |
|   DenseWithFourCandidatesPerBucket_Case8_New |     2.2731 ns |  0.0075 ns |  0.0067 ns |
|   DenseWithFourCandidatesPerBucket_Case8_Old |     2.7210 ns |  0.0290 ns |  0.0271 ns |
|   DenseWithFourCandidatesPerBucket_Case9_New |     0.8531 ns |  0.0017 ns |  0.0015 ns |
|   DenseWithFourCandidatesPerBucket_Case9_Old |     2.9773 ns |  0.0158 ns |  0.0148 ns |
|  DenseWithFourCandidatesPerBucket_Case10_New |     1.2252 ns |  0.0072 ns |  0.0064 ns |
|  DenseWithFourCandidatesPerBucket_Case10_Old |     2.5572 ns |  0.0137 ns |  0.0128 ns |
|  DenseWithFourCandidatesPerBucket_Case11_New |     1.6425 ns |  0.0027 ns |  0.0024 ns |
|  DenseWithFourCandidatesPerBucket_Case11_Old |     2.9204 ns |  0.0237 ns |  0.0221 ns |
|  DenseWithFourCandidatesPerBucket_Case12_New |     2.0603 ns |  0.0088 ns |  0.0074 ns |
|  DenseWithFourCandidatesPerBucket_Case12_Old |     2.9268 ns |  0.0263 ns |  0.0246 ns |
|  SparseWithFourCandidatesPerBucket_Case1_New |     1.0532 ns |  0.0027 ns |  0.0024 ns |
|  SparseWithFourCandidatesPerBucket_Case1_Old |     2.7707 ns |  0.0118 ns |  0.0111 ns |
|  SparseWithFourCandidatesPerBucket_Case2_New |     1.2228 ns |  0.0112 ns |  0.0099 ns |
|  SparseWithFourCandidatesPerBucket_Case2_Old |     2.9231 ns |  0.0160 ns |  0.0142 ns |
|  SparseWithFourCandidatesPerBucket_Case3_New |     1.4353 ns |  0.0048 ns |  0.0043 ns |
|  SparseWithFourCandidatesPerBucket_Case3_Old |     2.9751 ns |  0.0734 ns |  0.0686 ns |
|  SparseWithFourCandidatesPerBucket_Case4_New |     1.8694 ns |  0.0253 ns |  0.0237 ns |
|  SparseWithFourCandidatesPerBucket_Case4_Old |     2.9214 ns |  0.0138 ns |  0.0115 ns |
|  SparseWithFourCandidatesPerBucket_Case5_New |     1.0316 ns |  0.0051 ns |  0.0043 ns |
|  SparseWithFourCandidatesPerBucket_Case5_Old |     2.9266 ns |  0.0182 ns |  0.0161 ns |
|  SparseWithFourCandidatesPerBucket_Case6_New |     1.3701 ns |  0.0102 ns |  0.0090 ns |
|  SparseWithFourCandidatesPerBucket_Case6_Old |     2.7735 ns |  0.0145 ns |  0.0129 ns |
|  SparseWithFourCandidatesPerBucket_Case7_New |     1.6327 ns |  0.0068 ns |  0.0060 ns |
|  SparseWithFourCandidatesPerBucket_Case7_Old |     2.9312 ns |  0.0284 ns |  0.0266 ns |
|  SparseWithFourCandidatesPerBucket_Case8_New |     2.0603 ns |  0.0060 ns |  0.0053 ns |
|  SparseWithFourCandidatesPerBucket_Case8_Old |     2.9228 ns |  0.0206 ns |  0.0183 ns |
|  SparseWithFourCandidatesPerBucket_Case9_New |     1.2606 ns |  0.0040 ns |  0.0033 ns |
|  SparseWithFourCandidatesPerBucket_Case9_Old |     2.9848 ns |  0.0158 ns |  0.0140 ns |
| SparseWithFourCandidatesPerBucket_Case10_New |     1.2707 ns |  0.0032 ns |  0.0028 ns |
| SparseWithFourCandidatesPerBucket_Case10_Old |     2.9734 ns |  0.0118 ns |  0.0110 ns |
| SparseWithFourCandidatesPerBucket_Case11_New |     1.4886 ns |  0.0036 ns |  0.0030 ns |
| SparseWithFourCandidatesPerBucket_Case11_Old |     2.6837 ns |  0.0078 ns |  0.0065 ns |
| SparseWithFourCandidatesPerBucket_Case12_New |     1.8816 ns |  0.0241 ns |  0.0226 ns |
| SparseWithFourCandidatesPerBucket_Case12_Old |     2.7158 ns |  0.0170 ns |  0.0159 ns |
|  SparseWithFiveCandidatesPerBucket_Case1_New | 1.0593 ns | 0.0062 ns | 0.0058 ns |
|  SparseWithFiveCandidatesPerBucket_Case1_Old | 3.2330 ns | 0.0072 ns | 0.0064 ns |
|  SparseWithFiveCandidatesPerBucket_Case2_New | 1.0660 ns | 0.0075 ns | 0.0066 ns |
|  SparseWithFiveCandidatesPerBucket_Case2_Old | 3.0183 ns | 0.0169 ns | 0.0142 ns |
|  SparseWithFiveCandidatesPerBucket_Case3_New | 1.6369 ns | 0.0046 ns | 0.0039 ns |
|  SparseWithFiveCandidatesPerBucket_Case3_Old | 3.0075 ns | 0.0112 ns | 0.0094 ns |
|  SparseWithFiveCandidatesPerBucket_Case4_New | 2.0580 ns | 0.0065 ns | 0.0058 ns |
|  SparseWithFiveCandidatesPerBucket_Case4_Old | 2.9555 ns | 0.0159 ns | 0.0141 ns |
|  SparseWithFiveCandidatesPerBucket_Case5_New | 2.4778 ns | 0.0062 ns | 0.0052 ns |
|  SparseWithFiveCandidatesPerBucket_Case5_Old | 2.9156 ns | 0.0261 ns | 0.0244 ns |
|  SparseWithFiveCandidatesPerBucket_Case6_New | 0.8581 ns | 0.0161 ns | 0.0134 ns |
|  SparseWithFiveCandidatesPerBucket_Case6_Old | 3.4328 ns | 0.0084 ns | 0.0075 ns |
|  SparseWithFiveCandidatesPerBucket_Case7_New | 1.2084 ns | 0.0027 ns | 0.0024 ns |
|  SparseWithFiveCandidatesPerBucket_Case7_Old | 3.0108 ns | 0.0076 ns | 0.0063 ns |
|  SparseWithFiveCandidatesPerBucket_Case8_New | 1.6378 ns | 0.0033 ns | 0.0029 ns |
|  SparseWithFiveCandidatesPerBucket_Case8_Old | 3.0169 ns | 0.0171 ns | 0.0160 ns |
|  SparseWithFiveCandidatesPerBucket_Case9_New | 2.0668 ns | 0.0073 ns | 0.0065 ns |
|  SparseWithFiveCandidatesPerBucket_Case9_Old | 3.0084 ns | 0.0042 ns | 0.0033 ns |
| SparseWithFiveCandidatesPerBucket_Case10_New | 2.4691 ns | 0.0038 ns | 0.0032 ns |
| SparseWithFiveCandidatesPerBucket_Case10_Old | 2.9501 ns | 0.0182 ns | 0.0162 ns |
| SparseWithFiveCandidatesPerBucket_Case11_New | 1.2690 ns | 0.0148 ns | 0.0139 ns |
| SparseWithFiveCandidatesPerBucket_Case11_Old | 2.9555 ns | 0.0176 ns | 0.0156 ns |
| SparseWithFiveCandidatesPerBucket_Case12_New | 1.2666 ns | 0.0022 ns | 0.0021 ns |
| SparseWithFiveCandidatesPerBucket_Case12_Old | 3.4269 ns | 0.0055 ns | 0.0046 ns |
| SparseWithFiveCandidatesPerBucket_Case13_New | 1.8394 ns | 0.0069 ns | 0.0057 ns |
| SparseWithFiveCandidatesPerBucket_Case13_Old | 2.7552 ns | 0.0235 ns | 0.0209 ns |
| SparseWithFiveCandidatesPerBucket_Case14_New | 2.2538 ns | 0.0029 ns | 0.0023 ns |
| SparseWithFiveCandidatesPerBucket_Case14_Old | 2.9106 ns | 0.0231 ns | 0.0216 ns |
| SparseWithFiveCandidatesPerBucket_Case15_New | 2.6762 ns | 0.0027 ns | 0.0025 ns |
| SparseWithFiveCandidatesPerBucket_Case15_Old | 3.2189 ns | 0.0029 ns | 0.0023 ns |

|  SparseWithSixCandidatesPerBucket_Case1_New | 1.0542 ns | 0.0079 ns | 0.0074 ns |
|  SparseWithSixCandidatesPerBucket_Case1_Old | 2.5371 ns | 0.0073 ns | 0.0065 ns |
|  SparseWithSixCandidatesPerBucket_Case2_New | 1.0616 ns | 0.0073 ns | 0.0065 ns |
|  SparseWithSixCandidatesPerBucket_Case2_Old | 2.6887 ns | 0.0191 ns | 0.0169 ns |
|  SparseWithSixCandidatesPerBucket_Case3_New | 1.4308 ns | 0.0110 ns | 0.0098 ns |
|  SparseWithSixCandidatesPerBucket_Case3_Old | 2.4506 ns | 0.0092 ns | 0.0086 ns |
|  SparseWithSixCandidatesPerBucket_Case4_New | 1.8461 ns | 0.0067 ns | 0.0060 ns |
|  SparseWithSixCandidatesPerBucket_Case4_Old | 2.6667 ns | 0.0194 ns | 0.0181 ns |
|  SparseWithSixCandidatesPerBucket_Case5_New | 2.2799 ns | 0.0116 ns | 0.0102 ns |
|  SparseWithSixCandidatesPerBucket_Case5_Old | 2.4991 ns | 0.0267 ns | 0.0237 ns |
|  SparseWithSixCandidatesPerBucket_Case6_New | 2.6939 ns | 0.0080 ns | 0.0071 ns |
|  SparseWithSixCandidatesPerBucket_Case6_Old | 2.6606 ns | 0.0084 ns | 0.0066 ns |
|  SparseWithSixCandidatesPerBucket_Case7_New | 0.8491 ns | 0.0067 ns | 0.0060 ns |
|  SparseWithSixCandidatesPerBucket_Case7_Old | 2.8678 ns | 0.0141 ns | 0.0132 ns |
|  SparseWithSixCandidatesPerBucket_Case8_New | 1.0377 ns | 0.0197 ns | 0.0174 ns |
|  SparseWithSixCandidatesPerBucket_Case8_Old | 2.7434 ns | 0.0161 ns | 0.0143 ns |
|  SparseWithSixCandidatesPerBucket_Case9_New | 1.4451 ns | 0.0132 ns | 0.0124 ns |
|  SparseWithSixCandidatesPerBucket_Case9_Old | 2.4565 ns | 0.0161 ns | 0.0151 ns |
| SparseWithSixCandidatesPerBucket_Case10_New | 1.8662 ns | 0.0175 ns | 0.0163 ns |
| SparseWithSixCandidatesPerBucket_Case10_Old | 2.4839 ns | 0.0144 ns | 0.0134 ns |
| SparseWithSixCandidatesPerBucket_Case11_New | 2.3161 ns | 0.0186 ns | 0.0174 ns |
| SparseWithSixCandidatesPerBucket_Case11_Old | 2.6608 ns | 0.0107 ns | 0.0095 ns |
| SparseWithSixCandidatesPerBucket_Case12_New | 2.5166 ns | 0.0063 ns | 0.0049 ns |
| SparseWithSixCandidatesPerBucket_Case12_Old | 2.5276 ns | 0.0112 ns | 0.0093 ns |

|  SparseWithSevenCandidatesPerBucket_Case1_New | 2.707 ns | 0.0085 ns | 0.0075 ns |
|  SparseWithSevenCandidatesPerBucket_Case1_Old | 2.700 ns | 0.0082 ns | 0.0073 ns |
|  SparseWithSevenCandidatesPerBucket_Case2_New | 3.050 ns | 0.0128 ns | 0.0120 ns |
|  SparseWithSevenCandidatesPerBucket_Case2_Old | 2.757 ns | 0.0301 ns | 0.0282 ns |
|  SparseWithSevenCandidatesPerBucket_Case3_New | 2.825 ns | 0.0137 ns | 0.0122 ns |
|  SparseWithSevenCandidatesPerBucket_Case3_Old | 2.485 ns | 0.0036 ns | 0.0028 ns |
|  SparseWithSevenCandidatesPerBucket_Case4_New | 2.685 ns | 0.0089 ns | 0.0074 ns |
|  SparseWithSevenCandidatesPerBucket_Case4_Old | 2.673 ns | 0.0068 ns | 0.0057 ns |
|  SparseWithSevenCandidatesPerBucket_Case5_New | 2.746 ns | 0.0066 ns | 0.0051 ns |
|  SparseWithSevenCandidatesPerBucket_Case5_Old | 2.516 ns | 0.0252 ns | 0.0236 ns |
|  SparseWithSevenCandidatesPerBucket_Case6_New | 2.972 ns | 0.0205 ns | 0.0160 ns |
|  SparseWithSevenCandidatesPerBucket_Case6_Old | 2.954 ns | 0.0203 ns | 0.0190 ns |
|  SparseWithSevenCandidatesPerBucket_Case7_New | 2.738 ns | 0.0126 ns | 0.0105 ns |
|  SparseWithSevenCandidatesPerBucket_Case7_Old | 2.936 ns | 0.0277 ns | 0.0246 ns |
|  SparseWithSevenCandidatesPerBucket_Case8_New | 2.916 ns | 0.0287 ns | 0.0254 ns |
|  SparseWithSevenCandidatesPerBucket_Case8_Old | 2.959 ns | 0.0143 ns | 0.0120 ns |
|  SparseWithSevenCandidatesPerBucket_Case9_New | 2.682 ns | 0.0091 ns | 0.0071 ns |
|  SparseWithSevenCandidatesPerBucket_Case9_Old | 2.742 ns | 0.0151 ns | 0.0141 ns |
| SparseWithSevenCandidatesPerBucket_Case10_New | 2.489 ns | 0.0096 ns | 0.0085 ns |
| SparseWithSevenCandidatesPerBucket_Case10_Old | 2.538 ns | 0.0162 ns | 0.0152 ns |
| SparseWithSevenCandidatesPerBucket_Case11_New | 2.684 ns | 0.0085 ns | 0.0075 ns |
| SparseWithSevenCandidatesPerBucket_Case11_Old | 2.522 ns | 0.0084 ns | 0.0079 ns |
| SparseWithSevenCandidatesPerBucket_Case12_New | 2.543 ns | 0.0092 ns | 0.0086 ns |
| SparseWithSevenCandidatesPerBucket_Case12_Old | 2.693 ns | 0.0099 ns | 0.0088 ns |
| SparseWithSevenCandidatesPerBucket_Case13_New | 2.888 ns | 0.0138 ns | 0.0122 ns |
| SparseWithSevenCandidatesPerBucket_Case13_Old | 2.717 ns | 0.0057 ns | 0.0047 ns |
| SparseWithSevenCandidatesPerBucket_Case14_New | 2.465 ns | 0.0039 ns | 0.0034 ns |
| SparseWithSevenCandidatesPerBucket_Case14_Old | 2.672 ns | 0.0137 ns | 0.0122 ns |
*/
public class LengthVsHashCode
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
    //public int DenseFewNew() => NewRoslyn.DenseFew();
    //[Benchmark]
    //public int DenseFewOld() => OldRoslyn.DenseFew();

    //[Benchmark]
    //public int SparseNew() => NewRoslyn.Sparse();
    //[Benchmark]
    //public int SparseOld() => OldRoslyn.Sparse();

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

    //[Benchmark]
    //public int ShortSwitch_FirstCase_New() => NewRoslyn.ShortSwitch_FirstCase();
    //[Benchmark]
    //public int ShortSwitch_FirstCase_Old() => OldRoslyn.ShortSwitch_FirstCase();

    //[Benchmark]
    //public int ShortSwitch_SecondCase_New() => NewRoslyn.ShortSwitch_SecondCase();
    //[Benchmark]
    //public int ShortSwitch_SecondCase_Old() => OldRoslyn.ShortSwitch_SecondCase();

    //[Benchmark]
    //public int ShortSwitch_ThirdCase_New() => NewRoslyn.ShortSwitch_ThirdCase();
    //[Benchmark]
    //public int ShortSwitch_ThirdCase_Old() => OldRoslyn.ShortSwitch_ThirdCase();

    //[Benchmark]
    //public int ShortSwitch_FourthCase_New() => NewRoslyn.ShortSwitch_FourthCase();
    //[Benchmark]
    //public int ShortSwitch_FourthCase_Old() => OldRoslyn.ShortSwitch_FourthCase();

    //[Benchmark]
    //public int ShortSwitchLongWords_FirstCase_New() => NewRoslyn.ShortSwitchLongWords_FirstCase();
    //[Benchmark]
    //public int ShortSwitchLongWords_FirstCase_Old() => OldRoslyn.ShortSwitchLongWords_FirstCase();

    //[Benchmark]
    //public int ShortSwitchLongWords_SecondCase_New() => NewRoslyn.ShortSwitchLongWords_SecondCase();
    //[Benchmark]
    //public int ShortSwitchLongWords_SecondCase_Old() => OldRoslyn.ShortSwitchLongWords_SecondCase();

    //[Benchmark]
    //public int ShortSwitchLongWords_ThirdCase_New() => NewRoslyn.ShortSwitchLongWords_ThirdCase();
    //[Benchmark]
    //public int ShortSwitchLongWords_ThirdCase_Old() => OldRoslyn.ShortSwitchLongWords_ThirdCase();

    //[Benchmark]
    //public int ShortSwitchLongWords_FourthCase_New() => NewRoslyn.ShortSwitchLongWords_FourthCase();
    //[Benchmark]
    //public int ShortSwitchLongWords_FourthCase_Old() => OldRoslyn.ShortSwitchLongWords_FourthCase();

    //[Benchmark]
    //public DriveType GetDriveType_Mix_New() => NewRoslyn.GetDriveType_Mix();
    //[Benchmark]
    //public DriveType GetDriveType_Mix_Old() => OldRoslyn.GetDriveType_Mix();

    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case1_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket_Case1();
    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case1_Old() => OldRoslyn.DenseWithTwoCandidatesPerBucket_Case1();

    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case2_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket_Case2();
    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case2_Old() => OldRoslyn.DenseWithTwoCandidatesPerBucket_Case2();

    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case3_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket_Case3();
    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case3_Old() => OldRoslyn.DenseWithTwoCandidatesPerBucket_Case3();

    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case4_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket_Case4();
    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case4_Old() => OldRoslyn.DenseWithTwoCandidatesPerBucket_Case4();

    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case5_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket_Case5();
    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case5_Old() => OldRoslyn.DenseWithTwoCandidatesPerBucket_Case5();

    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case6_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket_Case6();
    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case6_Old() => OldRoslyn.DenseWithTwoCandidatesPerBucket_Case6();

    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case7_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket_Case7();
    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case7_Old() => OldRoslyn.DenseWithTwoCandidatesPerBucket_Case7();

    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case8_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket_Case8();
    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case8_Old() => OldRoslyn.DenseWithTwoCandidatesPerBucket_Case8();

    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case9_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket_Case9();
    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case9_Old() => OldRoslyn.DenseWithTwoCandidatesPerBucket_Case9();

    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case10_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket_Case10();
    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case10_Old() => OldRoslyn.DenseWithTwoCandidatesPerBucket_Case10();

    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case11_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket_Case11();
    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case11_Old() => OldRoslyn.DenseWithTwoCandidatesPerBucket_Case11();

    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case12_New() => NewRoslyn.DenseWithTwoCandidatesPerBucket_Case12();
    //[Benchmark]
    //public int DenseWithTwoCandidatesPerBucket_Case12_Old() => OldRoslyn.DenseWithTwoCandidatesPerBucket_Case12();

    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case1_New() => NewRoslyn.DenseWithThreeCandidatesPerBucket_Case1();
    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case1_Old() => OldRoslyn.DenseWithThreeCandidatesPerBucket_Case1();

    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case2_New() => NewRoslyn.DenseWithThreeCandidatesPerBucket_Case2();
    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case2_Old() => OldRoslyn.DenseWithThreeCandidatesPerBucket_Case2();

    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case3_New() => NewRoslyn.DenseWithThreeCandidatesPerBucket_Case3();
    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case3_Old() => OldRoslyn.DenseWithThreeCandidatesPerBucket_Case3();

    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case4_New() => NewRoslyn.DenseWithThreeCandidatesPerBucket_Case4();
    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case4_Old() => OldRoslyn.DenseWithThreeCandidatesPerBucket_Case4();

    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case5_New() => NewRoslyn.DenseWithThreeCandidatesPerBucket_Case5();
    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case5_Old() => OldRoslyn.DenseWithThreeCandidatesPerBucket_Case5();

    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case6_New() => NewRoslyn.DenseWithThreeCandidatesPerBucket_Case6();
    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case6_Old() => OldRoslyn.DenseWithThreeCandidatesPerBucket_Case6();

    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case7_New() => NewRoslyn.DenseWithThreeCandidatesPerBucket_Case7();
    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case7_Old() => OldRoslyn.DenseWithThreeCandidatesPerBucket_Case7();

    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case8_New() => NewRoslyn.DenseWithThreeCandidatesPerBucket_Case8();
    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case8_Old() => OldRoslyn.DenseWithThreeCandidatesPerBucket_Case8();

    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case9_New() => NewRoslyn.DenseWithThreeCandidatesPerBucket_Case9();
    //[Benchmark]
    //public int DenseWithThreeCandidatesPerBucket_Case9_Old() => OldRoslyn.DenseWithThreeCandidatesPerBucket_Case9();


    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case1_New() => NewRoslyn.DenseWithFourCandidatesPerBucket_Case1();
    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case1_Old() => OldRoslyn.DenseWithFourCandidatesPerBucket_Case1();

    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case2_New() => NewRoslyn.DenseWithFourCandidatesPerBucket_Case2();
    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case2_Old() => OldRoslyn.DenseWithFourCandidatesPerBucket_Case2();

    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case3_New() => NewRoslyn.DenseWithFourCandidatesPerBucket_Case3();
    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case3_Old() => OldRoslyn.DenseWithFourCandidatesPerBucket_Case3();

    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case4_New() => NewRoslyn.DenseWithFourCandidatesPerBucket_Case4();
    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case4_Old() => OldRoslyn.DenseWithFourCandidatesPerBucket_Case4();

    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case5_New() => NewRoslyn.DenseWithFourCandidatesPerBucket_Case5();
    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case5_Old() => OldRoslyn.DenseWithFourCandidatesPerBucket_Case5();

    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case6_New() => NewRoslyn.DenseWithFourCandidatesPerBucket_Case6();
    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case6_Old() => OldRoslyn.DenseWithFourCandidatesPerBucket_Case6();

    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case7_New() => NewRoslyn.DenseWithFourCandidatesPerBucket_Case7();
    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case7_Old() => OldRoslyn.DenseWithFourCandidatesPerBucket_Case7();

    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case8_New() => NewRoslyn.DenseWithFourCandidatesPerBucket_Case8();
    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case8_Old() => OldRoslyn.DenseWithFourCandidatesPerBucket_Case8();

    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case9_New() => NewRoslyn.DenseWithFourCandidatesPerBucket_Case9();
    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case9_Old() => OldRoslyn.DenseWithFourCandidatesPerBucket_Case9();

    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case10_New() => NewRoslyn.DenseWithFourCandidatesPerBucket_Case10();
    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case10_Old() => OldRoslyn.DenseWithFourCandidatesPerBucket_Case10();

    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case11_New() => NewRoslyn.DenseWithFourCandidatesPerBucket_Case11();
    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case11_Old() => OldRoslyn.DenseWithFourCandidatesPerBucket_Case11();

    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case12_New() => NewRoslyn.DenseWithFourCandidatesPerBucket_Case12();
    //[Benchmark]
    //public int DenseWithFourCandidatesPerBucket_Case12_Old() => OldRoslyn.DenseWithFourCandidatesPerBucket_Case12();

    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case1_New() => NewRoslyn.SparseWithFourCandidatesPerBucket_Case1();
    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case1_Old() => OldRoslyn.SparseWithFourCandidatesPerBucket_Case1();

    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case2_New() => NewRoslyn.SparseWithFourCandidatesPerBucket_Case2();
    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case2_Old() => OldRoslyn.SparseWithFourCandidatesPerBucket_Case2();

    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case3_New() => NewRoslyn.SparseWithFourCandidatesPerBucket_Case3();
    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case3_Old() => OldRoslyn.SparseWithFourCandidatesPerBucket_Case3();

    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case4_New() => NewRoslyn.SparseWithFourCandidatesPerBucket_Case4();
    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case4_Old() => OldRoslyn.SparseWithFourCandidatesPerBucket_Case4();

    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case5_New() => NewRoslyn.SparseWithFourCandidatesPerBucket_Case5();
    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case5_Old() => OldRoslyn.SparseWithFourCandidatesPerBucket_Case5();

    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case6_New() => NewRoslyn.SparseWithFourCandidatesPerBucket_Case6();
    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case6_Old() => OldRoslyn.SparseWithFourCandidatesPerBucket_Case6();

    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case7_New() => NewRoslyn.SparseWithFourCandidatesPerBucket_Case7();
    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case7_Old() => OldRoslyn.SparseWithFourCandidatesPerBucket_Case7();

    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case8_New() => NewRoslyn.SparseWithFourCandidatesPerBucket_Case8();
    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case8_Old() => OldRoslyn.SparseWithFourCandidatesPerBucket_Case8();

    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case9_New() => NewRoslyn.SparseWithFourCandidatesPerBucket_Case9();
    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case9_Old() => OldRoslyn.SparseWithFourCandidatesPerBucket_Case9();

    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case10_New() => NewRoslyn.SparseWithFourCandidatesPerBucket_Case10();
    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case10_Old() => OldRoslyn.SparseWithFourCandidatesPerBucket_Case10();

    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case11_New() => NewRoslyn.SparseWithFourCandidatesPerBucket_Case11();
    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case11_Old() => OldRoslyn.SparseWithFourCandidatesPerBucket_Case11();

    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case12_New() => NewRoslyn.SparseWithFourCandidatesPerBucket_Case12();
    //[Benchmark]
    //public int SparseWithFourCandidatesPerBucket_Case12_Old() => OldRoslyn.SparseWithFourCandidatesPerBucket_Case12();


    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case1_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case1();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case1_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case1();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case2_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case2();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case2_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case2();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case3_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case3();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case3_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case3();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case4_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case4();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case4_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case4();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case5_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case5();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case5_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case5();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case6_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case6();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case6_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case6();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case7_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case7();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case7_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case7();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case8_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case8();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case8_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case8();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case9_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case9();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case9_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case9();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case10_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case10();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case10_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case10();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case11_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case11();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case11_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case11();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case12_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case12();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case12_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case12();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case13_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case13();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case13_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case13();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case14_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case14();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case14_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case14();

    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case15_New() => NewRoslyn.SparseWithFiveCandidatesPerBucket_Case15();
    //[Benchmark]
    //public int SparseWithFiveCandidatesPerBucket_Case15_Old() => OldRoslyn.SparseWithFiveCandidatesPerBucket_Case15();



    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case1_New() => NewRoslyn.SparseWithSixCandidatesPerBucket_Case1();
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case1_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket_Case1();

    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case2_New() => NewRoslyn.SparseWithSixCandidatesPerBucket_Case2();
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case2_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket_Case2();

    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case3_New() => NewRoslyn.SparseWithSixCandidatesPerBucket_Case3();
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case3_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket_Case3();

    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case4_New() => NewRoslyn.SparseWithSixCandidatesPerBucket_Case4();
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case4_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket_Case4();

    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case5_New() => NewRoslyn.SparseWithSixCandidatesPerBucket_Case5();
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case5_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket_Case5();

    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case6_New() => NewRoslyn.SparseWithSixCandidatesPerBucket_Case6();
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case6_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket_Case6();

    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case7_New() => NewRoslyn.SparseWithSixCandidatesPerBucket_Case7();
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case7_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket_Case7();

    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case8_New() => NewRoslyn.SparseWithSixCandidatesPerBucket_Case8();
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case8_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket_Case8();

    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case9_New() => NewRoslyn.SparseWithSixCandidatesPerBucket_Case9();
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case9_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket_Case9();

    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case10_New() => NewRoslyn.SparseWithSixCandidatesPerBucket_Case10();
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case10_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket_Case10();

    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case11_New() => NewRoslyn.SparseWithSixCandidatesPerBucket_Case11();
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case11_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket_Case11();

    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case12_New() => NewRoslyn.SparseWithSixCandidatesPerBucket_Case12();
    [Benchmark]
    public int SparseWithSixCandidatesPerBucket_Case12_Old() => OldRoslyn.SparseWithSixCandidatesPerBucket_Case12();


    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case1_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case1();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case1_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case1();

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case2_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case2();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case2_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case2();

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case3_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case3();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case3_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case3();

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case4_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case4();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case4_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case4();

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case5_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case5();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case5_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case5();

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case6_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case6();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case6_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case6();

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case7_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case7();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case7_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case7();

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case8_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case8();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case8_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case8();

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case9_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case9();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case9_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case9();

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case10_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case10();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case10_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case10();

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case11_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case11();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case11_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case11();

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case12_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case12();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case12_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case12();

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case13_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case13();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case13_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case13();

    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case14_New() => NewRoslyn.SparseWithSevenCandidatesPerBucket_Case14();
    //[Benchmark]
    //public int SparseWithSevenCandidatesPerBucket_Case14_Old() => OldRoslyn.SparseWithSevenCandidatesPerBucket_Case14();
}
