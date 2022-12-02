
public class TestScenariosCore
{
    // TODO2 dimensions:
    // - high vs. low match rate
    // - long vs. short cases
    // - long vs. short inputs
    // - dense vs. sparse cases for a given length
    public static int Switch1()
    {
        int y = 0;
        foreach (var x in new[] { "a", "ab", "ab_", "abc", "abcd", "abcde", "abcdef", "abcdefg", "abcdefgh", "abcdefghi" })
        {
            y += x switch
            {
                "a" => 1,
                "ab" => 2,
                "ab_" => 3,
                "abcd" => 4,
                "abcde" => 5,
                "abcdef" => 6,
                "abcdefg" => 7,
                "abcdefgh" => 8,
                _ => 9,
            };
        }
        return y;
    }

    // This is the best case, since we reach a conclusion with just a Length check.
    public static int NotALengthMatch()
    {
        var x = "abcdefghijklm";
        return x switch
        {
            "a" => 1,
            "ab" => 2,
            "ab_" => 3,
            "abcd" => 4,
            "abcde" => 5,
            "abcdef" => 6,
            "abcdefg" => 7,
            "abcdefgh" => 8,
            _ => 9,
        };
    }

    // This is the worst case, since after doing Length and char checks we still compute the hash code.
    // This motivates giving up on optimization when buckets resulting from char checks are too large.
    // Alternatively, we could check a bundle of 2 or 4 chars at once.
    public static int Dense()
    {
        int y = 42;
        foreach (var x in Enumerable.Range(0, 60))
        {
            y += x.ToString("D2") switch
            {
                "00" => 0,
                "01" => 0,
                #region cases
                "02" => 0,
                "03" => 0,
                "04" => 0,
                "05" => 0,
                "06" => 0,
                "07" => 0,
                "08" => 0,
                "09" => 0,
                "10" => 0,
                "11" => 0,
                "12" => 0,
                "13" => 0,
                "14" => 0,
                "15" => 0,
                "16" => 0,
                "17" => 0,
                "18" => 0,
                "19" => 0,
                "20" => 0,
                "21" => 0,
                "22" => 0,
                "23" => 0,
                "24" => 0,
                "25" => 0,
                "26" => 0,
                "27" => 0,
                "28" => 0,
                "29" => 0,
                "30" => 0,
                "31" => 0,
                "32" => 0,
                "33" => 0,
                "34" => 0,
                "35" => 0,
                "36" => 0,
                "37" => 0,
                "38" => 0,
                "39" => 0,
                "40" => 0,
                "41" => 0,
                "42" => 0,
                "43" => 0,
                "44" => 0,
                "45" => 0,
                "46" => 0,
                "47" => 0,
                "48" => 0,
                #endregion
                "49" => 0,
                _ => 0,
            };
        }
        return y;
    }

    public static int DenseFew()
    {
        int y = 42;
        foreach (var x in Enumerable.Range(0, 10))
        {
            y += x.ToString("D2") switch
            {
                "00" => 0,
                "01" => 0,
                "02" => 0,
                "03" => 0,
                "04" => 0,
                "05" => 0,
                _ => 0,
            };
        }
        return y;
    }

    public static int Sparse()
    {
        int y = 42;
        foreach (var x in Enumerable.Range(0, 99))
        {
            y += x.ToString("D2") switch
            {
                "00" => 0,
                "05" => 0,
                "50" => 0,
                "59" => 0,
                "95" => 0,
                "99" => 0,
                _ => 0,
            };
        }
        return y;
    }

    public static int ContentType()
    {
        int y = 42;
        foreach (var x in new[] { "text/xml", "text/plain", "application/pdf", "other" })
        {
            switch (x)
            {
                case "text/xml":
                case "text/css":
                case "text/csv":
                case "image/gif":
                case "image/png":
                case "text/html":
                case "text/plain":
                case "image/jpeg":
                case "application/pdf":
                case "application/xml":
                case "application/zip":
                case "application/grpc":
                case "application/json":
                case "multipart/form-data":
                case "application/javascript":
                case "application/octet-stream":
                case "text/html; charset=utf-8":
                case "text/plain; charset=utf-8":
                case "application/json; charset=utf-8":
                case "application/x-www-form-urlencoded":
                    y++;
                    break;
            }
        }
        return y;
    }

    public static int ContentTypeAsListPattern()
    {
        int y = 42;
        foreach (var x in new[] { "text/xml", "text/plain", "application/pdf", "other" })
        {
            switch (x)
            {
                case ['t', 'e', 'x', 't', '/', 'x', 'm', 'l']:
                case ['t', 'e', 'x', 't', '/', 'c', 's', 's']:
                case ['t', 'e', 'x', 't', '/', 'c', 's', 'v']:
                case ['i', 'm', 'a', 'g', 'e', '/', 'g', 'i', 'f']:
                case ['i', 'm', 'a', 'g', 'e', '/', 'p', 'n', 'g']:
                case ['t', 'e', 'x', 't', '/', 'h', 't', 'm', 'l']:
                case ['t', 'e', 'x', 't', '/', 'p', 'l', 'a', 'i', 'n']:
                case ['i', 'm', 'a', 'g', 'e', '/', 'j', 'p', 'e', 'g']:
                case ['a', 'p', 'p', 'l', 'i', 'c', 'a', 't', 'i', 'o', 'n', '/', 'p', 'd', 'f']:
                case ['a', 'p', 'p', 'l', 'i', 'c', 'a', 't', 'i', 'o', 'n', '/', 'x', 'm', 'l']:
                case ['a', 'p', 'p', 'l', 'i', 'c', 'a', 't', 'i', 'o', 'n', '/', 'z', 'i', 'p']:
                case ['a', 'p', 'p', 'l', 'i', 'c', 'a', 't', 'i', 'o', 'n', '/', 'g', 'r', 'p', 'c']:
                case ['a', 'p', 'p', 'l', 'i', 'c', 'a', 't', 'i', 'o', 'n', '/', 'j', 's', 'o', 'n']:
                case ['m', 'u', 'l', 't', 'i', 'p', 'a', 'r', 't', '/', 'f', 'o', 'r', 'm', '-', 'd', 'a', 't', 'a']:
                case ['a', 'p', 'p', 'l', 'i', 'c', 'a', 't', 'i', 'o', 'n', '/', 'j', 'a', 'v', 'a', 's', 'c', 'r', 'i', 'p', 't']:
                case ['a', 'p', 'p', 'l', 'i', 'c', 'a', 't', 'i', 'o', 'n', '/', 'o', 'c', 't', 'e', 't', '-', 's', 't', 'r', 'e', 'a', 'm']:
                case ['t', 'e', 'x', 't', '/', 'h', 't', 'm', 'l', ';', ' ', 'c', 'h', 'a', 'r', 's', 'e', 't', '=', 'u', 't', 'f', '-', '8']:
                case ['t', 'e', 'x', 't', '/', 'p', 'l', 'a', 'i', 'n', ';', ' ', 'c', 'h', 'a', 'r', 's', 'e', 't', '=', 'u', 't', 'f', '-', '8']:
                case ['a', 'p', 'p', 'l', 'i', 'c', 'a', 't', 'i', 'o', 'n', '/', 'j', 's', 'o', 'n', ';', ' ', 'c', 'h', 'a', 'r', 's', 'e', 't', '=', 'u', 't', 'f', '-', '8']:
                case ['a', 'p', 'p', 'l', 'i', 'c', 'a', 't', 'i', 'o', 'n', '/', 'x', '-', 'w', 'w', 'w', '-', 'f', 'o', 'r', 'm', '-', 'u', 'r', 'l', 'e', 'n', 'c', 'o', 'd', 'e', 'd']:
                    y++;
                    break;
            }
        }
        return y;
    }

    public static int CyrusSwitch()
    {
        foreach (var x in new[] { "hello", "world" })
        {
            CyrusSwitchCore(x);
        }
        return 0;

        static int CyrusSwitchCore(string input)
        {
            return input switch
            {
                "a" => 0,
                "I" => 1,
                "of" => 2,
                "to" => 3,
                "in" => 4,
                "is" => 5,
                "it" => 6,
                "he" => 7,
                "on" => 8,
                "as" => 9,
                "be" => 10,
                "at" => 11,
                "or" => 12,
                "by" => 13,
                "we" => 14,
                "up" => 15,
                "an" => 16,
                "do" => 17,
                "if" => 18,
                "so" => 19,
                "go" => 20,
                "no" => 21,
                "my" => 22,
                "me" => 23,
                "us" => 24,
                "oh" => 25,
                "am" => 26,
                "the" => 27,
                "and" => 28,
                "you" => 29,
                "was" => 30,
                "for" => 31,
                "are" => 32,
                "his" => 33,
                "one" => 34,
                "had" => 35,
                "not" => 36,
                "but" => 37,
                "can" => 38,
                "out" => 39,
                "all" => 40,
                "use" => 41,
                "how" => 42,
                "she" => 43,
                "way" => 44,
                "her" => 45,
                "see" => 46,
                "him" => 47,
                "two" => 48,
                "has" => 49,
                "day" => 50,
                "did" => 51,
                "who" => 52,
                "may" => 53,
                "now" => 54,
                "any" => 55,
                "new" => 56,
                "get" => 57,
                "man" => 58,
                "our" => 59,
                "say" => 60,
                "low" => 61,
                "boy" => 62,
                "old" => 63,
                "too" => 64,
                "set" => 65,
                "air" => 66,
                "end" => 67,
                "put" => 68,
                "add" => 69,
                "big" => 70,
                "act" => 71,
                "why" => 72,
                "ask" => 73,
                "men" => 74,
                "off" => 75,
                "try" => 76,
                "own" => 77,
                "sun" => 78,
                "eye" => 79,
                "let" => 80,
                "saw" => 81,
                "far" => 82,
                "sea" => 83,
                "run" => 84,
                "few" => 85,
                "got" => 86,
                "car" => 87,
                "eat" => 88,
                "cut" => 89,
                "red" => 90,
                "dog" => 91,
                "top" => 92,
                "six" => 93,
                "ten" => 94,
                "war" => 95,
                "lay" => 96,
                "map" => 97,
                "fly" => 98,
                "cry" => 99,
                "box" => 100,
                "dry" => 101,
                "ago" => 102,
                "ran" => 103,
                "hot" => 104,
                "yes" => 105,
                "yet" => 106,
                "arm" => 107,
                "ice" => 108,
                "art" => 109,
                "bed" => 110,
                "egg" => 111,
                "sit" => 112,
                "leg" => 113,
                "sky" => 114,
                "joy" => 115,
                "sat" => 116,
                "cow" => 117,
                "job" => 118,
                "fun" => 119,
                "gas" => 120,
                "buy" => 121,
                "cat" => 122,
                "law" => 123,
                "bit" => 124,
                "lie" => 125,
                "ear" => 126,
                "son" => 127,
                "pay" => 128,
                "age" => 129,
                "lot" => 130,
                "key" => 131,
                "row" => 132,
                "die" => 133,
                "bad" => 134,
                "oil" => 135,
                "mix" => 136,
                "fit" => 137,
                "hit" => 138,
                "bat" => 139,
                "rub" => 140,
                "tie" => 141,
                "gun" => 142,
                "hat" => 143,
                "fig" => 144,
                "led" => 145,
                "win" => 146,
                "nor" => 147,
                "fat" => 148,
                "dad" => 149,
                "bar" => 150,
                "log" => 151,
                "that" => 152,
                "with" => 153,
                "they" => 154,
                "have" => 155,
                "this" => 156,
                "from" => 157,
                "word" => 158,
                "what" => 159,
                "some" => 160,
                "were" => 161,
                "when" => 162,
                "your" => 163,
                "said" => 164,
                "each" => 165,
                "time" => 166,
                "will" => 167,
                "many" => 168,
                "then" => 169,
                "them" => 170,
                "like" => 171,
                "long" => 172,
                "make" => 173,
                "look" => 174,
                "more" => 175,
                "come" => 176,
                "most" => 177,
                "over" => 178,
                "know" => 179,
                "than" => 180,
                "call" => 181,
                "down" => 182,
                "side" => 183,
                "been" => 184,
                "find" => 185,
                "work" => 186,
                "part" => 187,
                "take" => 188,
                "made" => 189,
                "live" => 190,
                "back" => 191,
                "only" => 192,
                "year" => 193,
                "came" => 194,
                "show" => 195,
                "good" => 196,
                "give" => 197,
                "name" => 198,
                "very" => 199,
                "just" => 200,
                "form" => 201,
                "help" => 202,
                "line" => 203,
                "turn" => 204,
                "much" => 205,
                "mean" => 206,
                "move" => 207,
                "same" => 208,
                "tell" => 209,
                "does" => 210,
                "want" => 211,
                "well" => 212,
                "also" => 213,
                "play" => 214,
                "home" => 215,
                "read" => 216,
                "hand" => 217,
                "port" => 218,
                "even" => 219,
                "land" => 220,
                "here" => 221,
                "must" => 222,
                "high" => 223,
                "such" => 224,
                "went" => 225,
                "kind" => 226,
                "need" => 227,
                "near" => 228,
                "self" => 229,
                "head" => 230,
                "page" => 231,
                "grow" => 232,
                "food" => 233,
                "four" => 234,
                "keep" => 235,
                "last" => 236,
                "city" => 237,
                "tree" => 238,
                "farm" => 239,
                "hard" => 240,
                "draw" => 241,
                "left" => 242,
                "late" => 243,
                "real" => 244,
                "life" => 245,
                "open" => 246,
                "seem" => 247,
                "next" => 248,
                "walk" => 249,
                "ease" => 250,
                "both" => 251,
                "mark" => 252,
                "mile" => 253,
                "feet" => 254,
                "care" => 255,
                "book" => 256,
                "took" => 257,
                "room" => 258,
                "idea" => 259,
                "fish" => 260,
                "stop" => 261,
                "once" => 262,
                "base" => 263,
                "hear" => 264,
                "sure" => 265,
                "face" => 266,
                "wood" => 267,
                "main" => 268,
                "girl" => 269,
                "ever" => 270,
                "list" => 271,
                "feel" => 272,
                "talk" => 273,
                "bird" => 274,
                "soon" => 275,
                "body" => 276,
                "pose" => 277,
                "song" => 278,
                "door" => 279,
                "wind" => 280,
                "ship" => 281,
                "area" => 282,
                "half" => 283,
                "rock" => 284,
                "fire" => 285,
                "told" => 286,
                "knew" => 287,
                "pass" => 288,
                "king" => 289,
                "best" => 290,
                "hour" => 291,
                "true" => 292,
                "five" => 293,
                "step" => 294,
                "hold" => 295,
                "west" => 296,
                "fast" => 297,
                "verb" => 298,
                "sing" => 299,
                "less" => 300,
                "slow" => 301,
                "love" => 302,
                "road" => 303,
                "rain" => 304,
                "rule" => 305,
                "pull" => 306,
                "cold" => 307,
                "unit" => 308,
                "town" => 309,
                "fine" => 310,
                "fall" => 311,
                "lead" => 312,
                "dark" => 313,
                "note" => 314,
                "wait" => 315,
                "plan" => 316,
                "star" => 317,
                "noun" => 318,
                "rest" => 319,
                "able" => 320,
                "done" => 321,
                "week" => 322,
                "gave" => 323,
                "warm" => 324,
                "free" => 325,
                "mind" => 326,
                "tail" => 327,
                "fact" => 328,
                "inch" => 329,
                "stay" => 330,
                "full" => 331,
                "blue" => 332,
                "deep" => 333,
                "moon" => 334,
                "foot" => 335,
                "busy" => 336,
                "test" => 337,
                "boat" => 338,
                "gold" => 339,
                "game" => 340,
                "miss" => 341,
                "heat" => 342,
                "snow" => 343,
                "tire" => 344,
                "fill" => 345,
                "east" => 346,
                "ball" => 347,
                "wave" => 348,
                "drop" => 349,
                "wide" => 350,
                "sail" => 351,
                "size" => 352,
                "vary" => 353,
                "pair" => 354,
                "felt" => 355,
                "pick" => 356,
                "hunt" => 357,
                "ride" => 358,
                "cell" => 359,
                "race" => 360,
                "lone" => 361,
                "wall" => 362,
                "wish" => 363,
                "wild" => 364,
                "kept" => 365,
                "edge" => 366,
                "sign" => 367,
                "past" => 368,
                "soft" => 369,
                "bear" => 370,
                "hope" => 371,
                "gone" => 372,
                "jump" => 373,
                "baby" => 374,
                "meet" => 375,
                "root" => 376,
                "push" => 377,
                "held" => 378,
                "hair" => 379,
                "cook" => 380,
                "burn" => 381,
                "hill" => 382,
                "safe" => 383,
                "type" => 384,
                "copy" => 385,
                "tall" => 386,
                "sand" => 387,
                "soil" => 388,
                "roll" => 389,
                "beat" => 390,
                "view" => 391,
                "else" => 392,
                "case" => 393,
                "kill" => 394,
                "lake" => 395,
                "loud" => 396,
                "milk" => 397,
                "tiny" => 398,
                "cool" => 399,
                "poor" => 400,
                "iron" => 401,
                "flat" => 402,
                "skin" => 403,
                "hole" => 404,
                "trip" => 405,
                "seed" => 406,
                "tone" => 407,
                "join" => 408,
                "lady" => 409,
                "yard" => 410,
                "rise" => 411,
                "blow" => 412,
                "grew" => 413,
                "cent" => 414,
                "team" => 415,
                "wire" => 416,
                "cost" => 417,
                "lost" => 418,
                "wear" => 419,
                "sent" => 420,
                "fell" => 421,
                "flow" => 422,
                "fair" => 423,
                "bank" => 424,
                "save" => 425,
                "noon" => 426,
                "ring" => 427,
                "atom" => 428,
                "crop" => 429,
                "bone" => 430,
                "rail" => 431,
                "thus" => 432,
                "rich" => 433,
                "wing" => 434,
                "wash" => 435,
                "corn" => 436,
                "poem" => 437,
                "bell" => 438,
                "meat" => 439,
                "tube" => 440,
                "fear" => 441,
                "thin" => 442,
                "mine" => 443,
                "send" => 444,
                "dead" => 445,
                "spot" => 446,
                "suit" => 447,
                "lift" => 448,
                "rose" => 449,
                "sell" => 450,
                "deal" => 451,
                "swim" => 452,
                "term" => 453,
                "wife" => 454,
                "shoe" => 455,
                "camp" => 456,
                "born" => 457,
                "nine" => 458,
                "shop" => 459,
                "gray" => 460,
                "salt" => 461,
                "nose" => 462,
                "huge" => 463,
                "coat" => 464,
                "mass" => 465,
                "card" => 466,
                "band" => 467,
                "rope" => 468,
                "slip" => 469,
                "feed" => 470,
                "tool" => 471,
                "seat" => 472,
                "post" => 473,
                "glad" => 474,
                "duck" => 475,
                "dear" => 476,
                "path" => 477,
                "neck" => 478,
                "other" => 479,
                "there" => 480,
                "which" => 481,
                "their" => 482,
                "about" => 483,
                "write" => 484,
                "would" => 485,
                "these" => 486,
                "thing" => 487,
                "could" => 488,
                "sound" => 489,
                "water" => 490,
                "first" => 491,
                "place" => 492,
                "where" => 493,
                "after" => 494,
                "round" => 495,
                "every" => 496,
                "under" => 497,
                "great" => 498,
                "think" => 499,
                "cause" => 500,
                "right" => 501,
                "three" => 502,
                "small" => 503,
                "large" => 504,
                "spell" => 505,
                "light" => 506,
                "house" => 507,
                "again" => 508,
                "point" => 509,
                "world" => 510,
                "build" => 511,
                "earth" => 512,
                "stand" => 513,
                "found" => 514,
                "study" => 515,
                "still" => 516,
                "learn" => 517,
                "plant" => 518,
                "cover" => 519,
                "state" => 520,
                "never" => 521,
                "cross" => 522,
                "start" => 523,
                "might" => 524,
                "story" => 525,
                "don't" => 526,
                "while" => 527,
                "press" => 528,
                "close" => 529,
                "night" => 530,
                "north" => 531,
                "white" => 532,
                "begin" => 533,
                "paper" => 534,
                "group" => 535,
                "music" => 536,
                "those" => 537,
                "often" => 538,
                "until" => 539,
                "river" => 540,
                "carry" => 541,
                "began" => 542,
                "horse" => 543,
                "watch" => 544,
                "color" => 545,
                "plain" => 546,
                "usual" => 547,
                "young" => 548,
                "ready" => 549,
                "above" => 550,
                "leave" => 551,
                "black" => 552,
                "short" => 553,
                "class" => 554,
                "order" => 555,
                "south" => 556,
                "piece" => 557,
                "since" => 558,
                "whole" => 559,
                "space" => 560,
                "heard" => 561,
                "early" => 562,
                "reach" => 563,
                "table" => 564,
                "vowel" => 565,
                "money" => 566,
                "serve" => 567,
                "voice" => 568,
                "power" => 569,
                "field" => 570,
                "pound" => 571,
                "drive" => 572,
                "stood" => 573,
                "front" => 574,
                "teach" => 575,
                "final" => 576,
                "green" => 577,
                "quick" => 578,
                "ocean" => 579,
                "clear" => 580,
                "wheel" => 581,
                "force" => 582,
                "plane" => 583,
                "stead" => 584,
                "laugh" => 585,
                "check" => 586,
                "shape" => 587,
                "bring" => 588,
                "paint" => 589,
                "among" => 590,
                "grand" => 591,
                "heart" => 592,
                "heavy" => 593,
                "dance" => 594,
                "speak" => 595,
                "count" => 596,
                "store" => 597,
                "train" => 598,
                "sleep" => 599,
                "prove" => 600,
                "catch" => 601,
                "mount" => 602,
                "board" => 603,
                "glass" => 604,
                "grass" => 605,
                "visit" => 606,
                "month" => 607,
                "happy" => 608,
                "eight" => 609,
                "raise" => 610,
                "solve" => 611,
                "metal" => 612,
                "seven" => 613,
                "third" => 614,
                "shall" => 615,
                "floor" => 616,
                "coast" => 617,
                "value" => 618,
                "fight" => 619,
                "sense" => 620,
                "quite" => 621,
                "broke" => 622,
                "scale" => 623,
                "child" => 624,
                "speed" => 625,
                "organ" => 626,
                "dress" => 627,
                "cloud" => 628,
                "quiet" => 629,
                "stone" => 630,
                "climb" => 631,
                "stick" => 632,
                "smile" => 633,
                "trade" => 634,
                "mouth" => 635,
                "exact" => 636,
                "least" => 637,
                "shout" => 638,
                "wrote" => 639,
                "clean" => 640,
                "break" => 641,
                "blood" => 642,
                "touch" => 643,
                "brown" => 644,
                "equal" => 645,
                "woman" => 646,
                "whose" => 647,
                "radio" => 648,
                "spoke" => 649,
                "human" => 650,
                "party" => 651,
                "agree" => 652,
                "won't" => 653,
                "chair" => 654,
                "fruit" => 655,
                "thick" => 656,
                "guess" => 657,
                "sharp" => 658,
                "crowd" => 659,
                "sight" => 660,
                "hurry" => 661,
                "chief" => 662,
                "clock" => 663,
                "enter" => 664,
                "major" => 665,
                "fresh" => 666,
                "allow" => 667,
                "print" => 668,
                "block" => 669,
                "chart" => 670,
                "event" => 671,
                "quart" => 672,
                "truck" => 673,
                "noise" => 674,
                "level" => 675,
                "throw" => 676,
                "shine" => 677,
                "wrong" => 678,
                "broad" => 679,
                "anger" => 680,
                "claim" => 681,
                "sugar" => 682,
                "death" => 683,
                "skill" => 684,
                "women" => 685,
                "thank" => 686,
                "match" => 687,
                "steel" => 688,
                "guide" => 689,
                "score" => 690,
                "apple" => 691,
                "pitch" => 692,
                "dream" => 693,
                "total" => 694,
                "basic" => 695,
                "smell" => 696,
                "track" => 697,
                "shore" => 698,
                "sheet" => 699,
                "favor" => 700,
                "spend" => 701,
                "chord" => 702,
                "share" => 703,
                "bread" => 704,
                "offer" => 705,
                "slave" => 706,
                "chick" => 707,
                "enemy" => 708,
                "reply" => 709,
                "drink" => 710,
                "occur" => 711,
                "range" => 712,
                "steam" => 713,
                "meant" => 714,
                "teeth" => 715,
                "shell" => 716,
                "number" => 717,
                "people" => 718,
                "little" => 719,
                "differ" => 720,
                "before" => 721,
                "follow" => 722,
                "change" => 723,
                "animal" => 724,
                "mother" => 725,
                "father" => 726,
                "should" => 727,
                "answer" => 728,
                "school" => 729,
                "always" => 730,
                "letter" => 731,
                "second" => 732,
                "friend" => 733,
                "enough" => 734,
                "though" => 735,
                "family" => 736,
                "direct" => 737,
                "happen" => 738,
                "better" => 739,
                "during" => 740,
                "ground" => 741,
                "listen" => 742,
                "travel" => 743,
                "simple" => 744,
                "toward" => 745,
                "center" => 746,
                "person" => 747,
                "appear" => 748,
                "govern" => 749,
                "notice" => 750,
                "figure" => 751,
                "beauty" => 752,
                "minute" => 753,
                "strong" => 754,
                "behind" => 755,
                "street" => 756,
                "course" => 757,
                "object" => 758,
                "decide" => 759,
                "island" => 760,
                "system" => 761,
                "record" => 762,
                "common" => 763,
                "wonder" => 764,
                "equate" => 765,
                "engine" => 766,
                "settle" => 767,
                "weight" => 768,
                "matter" => 769,
                "circle" => 770,
                "divide" => 771,
                "sudden" => 772,
                "square" => 773,
                "reason" => 774,
                "length" => 775,
                "region" => 776,
                "energy" => 777,
                "forest" => 778,
                "window" => 779,
                "summer" => 780,
                "winter" => 781,
                "bright" => 782,
                "finish" => 783,
                "flower" => 784,
                "clothe" => 785,
                "either" => 786,
                "result" => 787,
                "phrase" => 788,
                "silent" => 789,
                "finger" => 790,
                "excite" => 791,
                "middle" => 792,
                "moment" => 793,
                "spring" => 794,
                "nation" => 795,
                "method" => 796,
                "design" => 797,
                "bottom" => 798,
                "single" => 799,
                "twenty" => 800,
                "crease" => 801,
                "melody" => 802,
                "office" => 803,
                "symbol" => 804,
                "except" => 805,
                "garden" => 806,
                "choose" => 807,
                "gentle" => 808,
                "doctor" => 809,
                "please" => 810,
                "locate" => 811,
                "insect" => 812,
                "caught" => 813,
                "period" => 814,
                "effect" => 815,
                "expect" => 816,
                "modern" => 817,
                "corner" => 818,
                "supply" => 819,
                "danger" => 820,
                "create" => 821,
                "rather" => 822,
                "string" => 823,
                "depend" => 824,
                "famous" => 825,
                "dollar" => 826,
                "stream" => 827,
                "planet" => 828,
                "colony" => 829,
                "search" => 830,
                "yellow" => 831,
                "desert" => 832,
                "spread" => 833,
                "invent" => 834,
                "cotton" => 835,
                "chance" => 836,
                "gather" => 837,
                "column" => 838,
                "select" => 839,
                "repeat" => 840,
                "plural" => 841,
                "oxygen" => 842,
                "pretty" => 843,
                "season" => 844,
                "magnet" => 845,
                "silver" => 846,
                "branch" => 847,
                "suffix" => 848,
                "afraid" => 849,
                "sister" => 850,
                "bought" => 851,
                "valley" => 852,
                "double" => 853,
                "arrive" => 854,
                "master" => 855,
                "parent" => 856,
                "charge" => 857,
                "proper" => 858,
                "market" => 859,
                "degree" => 860,
                "speech" => 861,
                "nature" => 862,
                "motion" => 863,
                "liquid" => 864,
                "through" => 865,
                "picture" => 866,
                "country" => 867,
                "between" => 868,
                "thought" => 869,
                "example" => 870,
                "science" => 871,
                "measure" => 872,
                "product" => 873,
                "numeral" => 874,
                "problem" => 875,
                "hundred" => 876,
                "morning" => 877,
                "several" => 878,
                "against" => 879,
                "pattern" => 880,
                "certain" => 881,
                "machine" => 882,
                "correct" => 883,
                "contain" => 884,
                "develop" => 885,
                "special" => 886,
                "produce" => 887,
                "nothing" => 888,
                "surface" => 889,
                "brought" => 890,
                "distant" => 891,
                "present" => 892,
                "general" => 893,
                "include" => 894,
                "perhaps" => 895,
                "subject" => 896,
                "brother" => 897,
                "believe" => 898,
                "written" => 899,
                "weather" => 900,
                "million" => 901,
                "strange" => 902,
                "village" => 903,
                "whether" => 904,
                "century" => 905,
                "natural" => 906,
                "observe" => 907,
                "section" => 908,
                "receive" => 909,
                "trouble" => 910,
                "suggest" => 911,
                "collect" => 912,
                "control" => 913,
                "decimal" => 914,
                "captain" => 915,
                "protect" => 916,
                "history" => 917,
                "element" => 918,
                "student" => 919,
                "imagine" => 920,
                "provide" => 921,
                "capital" => 922,
                "soldier" => 923,
                "process" => 924,
                "operate" => 925,
                "compare" => 926,
                "current" => 927,
                "success" => 928,
                "company" => 929,
                "arrange" => 930,
                "stretch" => 931,
                "require" => 932,
                "prepare" => 933,
                "discuss" => 934,
                "forward" => 935,
                "similar" => 936,
                "evening" => 937,
                "connect" => 938,
                "station" => 939,
                "segment" => 940,
                "instant" => 941,
                "support" => 942,
                "sentence" => 943,
                "together" => 944,
                "children" => 945,
                "mountain" => 946,
                "question" => 947,
                "complete" => 948,
                "remember" => 949,
                "interest" => 950,
                "multiply" => 951,
                "possible" => 952,
                "thousand" => 953,
                "language" => 954,
                "position" => 955,
                "material" => 956,
                "syllable" => 957,
                "probable" => 958,
                "fraction" => 959,
                "exercise" => 960,
                "describe" => 961,
                "consider" => 962,
                "industry" => 963,
                "straight" => 964,
                "surprise" => 965,
                "practice" => 966,
                "separate" => 967,
                "indicate" => 968,
                "electric" => 969,
                "neighbor" => 970,
                "triangle" => 971,
                "continue" => 972,
                "subtract" => 973,
                "opposite" => 974,
                "shoulder" => 975,
                "property" => 976,
                "molecule" => 977,
                "solution" => 978,
                "division" => 979,
                "original" => 980,
                "populate" => 981,
                "quotient" => 982,
                "represent" => 983,
                "paragraph" => 984,
                "consonant" => 985,
                "difficult" => 986,
                "character" => 987,
                "necessary" => 988,
                "determine" => 989,
                "continent" => 990,
                "condition" => 991,
                "substance" => 992,
                "instrument" => 993,
                "dictionary" => 994,
                "experiment" => 995,
                "particular" => 996,
                "especially" => 997,
                "experience" => 998,
                "temperature" => 999,
                _ => -1,
            };
        }
    }

    public static int CyrusTrie()
    {
        foreach (var x in new[] { "hello", "world" })
        {
            CyrusTrieCore(x);
        }
        return 0;

        static int CyrusTrieCore(string input)
        {
            return input.Length switch
            {
                1 => input[0] switch
                {
                    'I' => /* match 'I' */ 0,
                    'a' => /* match 'a' */ 1,
                    _ => -1,
                },
                2 => input[0] switch
                {
                    'a' => input[1] switch
                    {
                        'm' => /* match 'am' */ 2,
                        'n' => /* match 'an' */ 3,
                        's' => /* match 'as' */ 4,
                        't' => /* match 'at' */ 5,
                        _ => -1,
                    },
                    'b' => input[1] switch
                    {
                        'e' => /* match 'be' */ 6,
                        'y' => /* match 'by' */ 7,
                        _ => -1,
                    },
                    'd' => input[1] == 'o' ? /* match 'do' */ 8 : -1,
                    'g' => input[1] == 'o' ? /* match 'go' */ 9 : -1,
                    'h' => input[1] == 'e' ? /* match 'he' */ 10 : -1,
                    'i' => input[1] switch
                    {
                        'f' => /* match 'if' */ 11,
                        'n' => /* match 'in' */ 12,
                        's' => /* match 'is' */ 13,
                        't' => /* match 'it' */ 14,
                        _ => -1,
                    },
                    'm' => input[1] switch
                    {
                        'e' => /* match 'me' */ 15,
                        'y' => /* match 'my' */ 16,
                        _ => -1,
                    },
                    'n' => input[1] == 'o' ? /* match 'no' */ 17 : -1,
                    'o' => input[1] switch
                    {
                        'f' => /* match 'of' */ 18,
                        'h' => /* match 'oh' */ 19,
                        'n' => /* match 'on' */ 20,
                        'r' => /* match 'or' */ 21,
                        _ => -1,
                    },
                    's' => input[1] == 'o' ? /* match 'so' */ 22 : -1,
                    't' => input[1] == 'o' ? /* match 'to' */ 23 : -1,
                    'u' => input[1] switch
                    {
                        'p' => /* match 'up' */ 24,
                        's' => /* match 'us' */ 25,
                        _ => -1,
                    },
                    'w' => input[1] == 'e' ? /* match 'we' */ 26 : -1,
                    _ => -1,
                },
                3 => input[0] switch
                {
                    'a' => input[1] switch
                    {
                        'c' => input[2] == 't' ? /* match 'act' */ 27 : -1,
                        'd' => input[2] == 'd' ? /* match 'add' */ 28 : -1,
                        'g' => input[2] switch
                        {
                            'e' => /* match 'age' */ 29,
                            'o' => /* match 'ago' */ 30,
                            _ => -1,
                        },
                        'i' => input[2] == 'r' ? /* match 'air' */ 31 : -1,
                        'l' => input[2] == 'l' ? /* match 'all' */ 32 : -1,
                        'n' => input[2] switch
                        {
                            'd' => /* match 'and' */ 33,
                            'y' => /* match 'any' */ 34,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'e' => /* match 'are' */ 35,
                            'm' => /* match 'arm' */ 36,
                            't' => /* match 'art' */ 37,
                            _ => -1,
                        },
                        's' => input[2] == 'k' ? /* match 'ask' */ 38 : -1,
                        _ => -1,
                    },
                    'b' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'd' => /* match 'bad' */ 39,
                            'r' => /* match 'bar' */ 40,
                            't' => /* match 'bat' */ 41,
                            _ => -1,
                        },
                        'e' => input[2] == 'd' ? /* match 'bed' */ 42 : -1,
                        'i' => input[2] switch
                        {
                            'g' => /* match 'big' */ 43,
                            't' => /* match 'bit' */ 44,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'x' => /* match 'box' */ 45,
                            'y' => /* match 'boy' */ 46,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            't' => /* match 'but' */ 47,
                            'y' => /* match 'buy' */ 48,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'c' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'n' => /* match 'can' */ 49,
                            'r' => /* match 'car' */ 50,
                            't' => /* match 'cat' */ 51,
                            _ => -1,
                        },
                        'o' => input[2] == 'w' ? /* match 'cow' */ 52 : -1,
                        'r' => input[2] == 'y' ? /* match 'cry' */ 53 : -1,
                        'u' => input[2] == 't' ? /* match 'cut' */ 54 : -1,
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'd' => /* match 'dad' */ 55,
                            'y' => /* match 'day' */ 56,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'd' => /* match 'did' */ 57,
                            'e' => /* match 'die' */ 58,
                            _ => -1,
                        },
                        'o' => input[2] == 'g' ? /* match 'dog' */ 59 : -1,
                        'r' => input[2] == 'y' ? /* match 'dry' */ 60 : -1,
                        _ => -1,
                    },
                    'e' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'r' => /* match 'ear' */ 61,
                            't' => /* match 'eat' */ 62,
                            _ => -1,
                        },
                        'g' => input[2] == 'g' ? /* match 'egg' */ 63 : -1,
                        'n' => input[2] == 'd' ? /* match 'end' */ 64 : -1,
                        'y' => input[2] == 'e' ? /* match 'eye' */ 65 : -1,
                        _ => -1,
                    },
                    'f' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'r' => /* match 'far' */ 66,
                            't' => /* match 'fat' */ 67,
                            _ => -1,
                        },
                        'e' => input[2] == 'w' ? /* match 'few' */ 68 : -1,
                        'i' => input[2] switch
                        {
                            'g' => /* match 'fig' */ 69,
                            't' => /* match 'fit' */ 70,
                            _ => -1,
                        },
                        'l' => input[2] == 'y' ? /* match 'fly' */ 71 : -1,
                        'o' => input[2] == 'r' ? /* match 'for' */ 72 : -1,
                        'u' => input[2] == 'n' ? /* match 'fun' */ 73 : -1,
                        _ => -1,
                    },
                    'g' => input[1] switch
                    {
                        'a' => input[2] == 's' ? /* match 'gas' */ 74 : -1,
                        'e' => input[2] == 't' ? /* match 'get' */ 75 : -1,
                        'o' => input[2] == 't' ? /* match 'got' */ 76 : -1,
                        'u' => input[2] == 'n' ? /* match 'gun' */ 77 : -1,
                        _ => -1,
                    },
                    'h' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'd' => /* match 'had' */ 78,
                            's' => /* match 'has' */ 79,
                            't' => /* match 'hat' */ 80,
                            _ => -1,
                        },
                        'e' => input[2] == 'r' ? /* match 'her' */ 81 : -1,
                        'i' => input[2] switch
                        {
                            'm' => /* match 'him' */ 82,
                            's' => /* match 'his' */ 83,
                            't' => /* match 'hit' */ 84,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            't' => /* match 'hot' */ 85,
                            'w' => /* match 'how' */ 86,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'i' => input.AsSpan(1).SequenceEqual("ce") ? /* match 'ice' */ 87 : -1,
                    'j' => input[1] != 'o' ? -1 : input[2] switch
                    {
                        'b' => /* match 'job' */ 88,
                        'y' => /* match 'joy' */ 89,
                        _ => -1,
                    },
                    'k' => input.AsSpan(1).SequenceEqual("ey") ? /* match 'key' */ 90 : -1,
                    'l' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'w' => /* match 'law' */ 91,
                            'y' => /* match 'lay' */ 92,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'd' => /* match 'led' */ 93,
                            'g' => /* match 'leg' */ 94,
                            't' => /* match 'let' */ 95,
                            _ => -1,
                        },
                        'i' => input[2] == 'e' ? /* match 'lie' */ 96 : -1,
                        'o' => input[2] switch
                        {
                            'g' => /* match 'log' */ 97,
                            't' => /* match 'lot' */ 98,
                            'w' => /* match 'low' */ 99,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'm' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'n' => /* match 'man' */ 100,
                            'p' => /* match 'map' */ 101,
                            'y' => /* match 'may' */ 102,
                            _ => -1,
                        },
                        'e' => input[2] == 'n' ? /* match 'men' */ 103 : -1,
                        'i' => input[2] == 'x' ? /* match 'mix' */ 104 : -1,
                        _ => -1,
                    },
                    'n' => input[1] switch
                    {
                        'e' => input[2] == 'w' ? /* match 'new' */ 105 : -1,
                        'o' => input[2] switch
                        {
                            'r' => /* match 'nor' */ 106,
                            't' => /* match 'not' */ 107,
                            'w' => /* match 'now' */ 108,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'o' => input[1] switch
                    {
                        'f' => input[2] == 'f' ? /* match 'off' */ 109 : -1,
                        'i' => input[2] == 'l' ? /* match 'oil' */ 110 : -1,
                        'l' => input[2] == 'd' ? /* match 'old' */ 111 : -1,
                        'n' => input[2] == 'e' ? /* match 'one' */ 112 : -1,
                        'u' => input[2] switch
                        {
                            'r' => /* match 'our' */ 113,
                            't' => /* match 'out' */ 114,
                            _ => -1,
                        },
                        'w' => input[2] == 'n' ? /* match 'own' */ 115 : -1,
                        _ => -1,
                    },
                    'p' => input[1] switch
                    {
                        'a' => input[2] == 'y' ? /* match 'pay' */ 116 : -1,
                        'u' => input[2] == 't' ? /* match 'put' */ 117 : -1,
                        _ => -1,
                    },
                    'r' => input[1] switch
                    {
                        'a' => input[2] == 'n' ? /* match 'ran' */ 118 : -1,
                        'e' => input[2] == 'd' ? /* match 'red' */ 119 : -1,
                        'o' => input[2] == 'w' ? /* match 'row' */ 120 : -1,
                        'u' => input[2] switch
                        {
                            'b' => /* match 'rub' */ 121,
                            'n' => /* match 'run' */ 122,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    's' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            't' => /* match 'sat' */ 123,
                            'w' => /* match 'saw' */ 124,
                            'y' => /* match 'say' */ 125,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => /* match 'sea' */ 126,
                            'e' => /* match 'see' */ 127,
                            't' => /* match 'set' */ 128,
                            _ => -1,
                        },
                        'h' => input[2] == 'e' ? /* match 'she' */ 129 : -1,
                        'i' => input[2] switch
                        {
                            't' => /* match 'sit' */ 130,
                            'x' => /* match 'six' */ 131,
                            _ => -1,
                        },
                        'k' => input[2] == 'y' ? /* match 'sky' */ 132 : -1,
                        'o' => input[2] == 'n' ? /* match 'son' */ 133 : -1,
                        'u' => input[2] == 'n' ? /* match 'sun' */ 134 : -1,
                        _ => -1,
                    },
                    't' => input[1] switch
                    {
                        'e' => input[2] == 'n' ? /* match 'ten' */ 135 : -1,
                        'h' => input[2] == 'e' ? /* match 'the' */ 136 : -1,
                        'i' => input[2] == 'e' ? /* match 'tie' */ 137 : -1,
                        'o' => input[2] switch
                        {
                            'o' => /* match 'too' */ 138,
                            'p' => /* match 'top' */ 139,
                            _ => -1,
                        },
                        'r' => input[2] == 'y' ? /* match 'try' */ 140 : -1,
                        'w' => input[2] == 'o' ? /* match 'two' */ 141 : -1,
                        _ => -1,
                    },
                    'u' => input.AsSpan(1).SequenceEqual("se") ? /* match 'use' */ 142 : -1,
                    'w' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'r' => /* match 'war' */ 143,
                            's' => /* match 'was' */ 144,
                            'y' => /* match 'way' */ 145,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'o' => /* match 'who' */ 146,
                            'y' => /* match 'why' */ 147,
                            _ => -1,
                        },
                        'i' => input[2] == 'n' ? /* match 'win' */ 148 : -1,
                        _ => -1,
                    },
                    'y' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            's' => /* match 'yes' */ 149,
                            't' => /* match 'yet' */ 150,
                            _ => -1,
                        },
                        'o' => input[2] == 'u' ? /* match 'you' */ 151 : -1,
                        _ => -1,
                    },
                    _ => -1,
                },
                4 => input[0] switch
                {
                    'a' => input[1] switch
                    {
                        'b' => input.AsSpan(2).SequenceEqual("le") ? /* match 'able' */ 152 : -1,
                        'l' => input.AsSpan(2).SequenceEqual("so") ? /* match 'also' */ 153 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("ea") ? /* match 'area' */ 154 : -1,
                        't' => input.AsSpan(2).SequenceEqual("om") ? /* match 'atom' */ 155 : -1,
                        _ => -1,
                    },
                    'b' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'b' => input[3] == 'y' ? /* match 'baby' */ 156 : -1,
                            'c' => input[3] == 'k' ? /* match 'back' */ 157 : -1,
                            'l' => input[3] == 'l' ? /* match 'ball' */ 158 : -1,
                            'n' => input[3] switch
                            {
                                'd' => /* match 'band' */ 159,
                                'k' => /* match 'bank' */ 160,
                                _ => -1,
                            },
                            's' => input[3] == 'e' ? /* match 'base' */ 161 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'r' => /* match 'bear' */ 162,
                                't' => /* match 'beat' */ 163,
                                _ => -1,
                            },
                            'e' => input[3] == 'n' ? /* match 'been' */ 164 : -1,
                            'l' => input[3] == 'l' ? /* match 'bell' */ 165 : -1,
                            's' => input[3] == 't' ? /* match 'best' */ 166 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("rd") ? /* match 'bird' */ 167 : -1,
                        'l' => input[2] switch
                        {
                            'o' => input[3] == 'w' ? /* match 'blow' */ 168 : -1,
                            'u' => input[3] == 'e' ? /* match 'blue' */ 169 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'a' => input[3] == 't' ? /* match 'boat' */ 170 : -1,
                            'd' => input[3] == 'y' ? /* match 'body' */ 171 : -1,
                            'n' => input[3] == 'e' ? /* match 'bone' */ 172 : -1,
                            'o' => input[3] == 'k' ? /* match 'book' */ 173 : -1,
                            'r' => input[3] == 'n' ? /* match 'born' */ 174 : -1,
                            't' => input[3] == 'h' ? /* match 'both' */ 175 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'r' => input[3] == 'n' ? /* match 'burn' */ 176 : -1,
                            's' => input[3] == 'y' ? /* match 'busy' */ 177 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'c' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'l' => input[3] == 'l' ? /* match 'call' */ 178 : -1,
                            'm' => input[3] switch
                            {
                                'e' => /* match 'came' */ 179,
                                'p' => /* match 'camp' */ 180,
                                _ => -1,
                            },
                            'r' => input[3] switch
                            {
                                'd' => /* match 'card' */ 181,
                                'e' => /* match 'care' */ 182,
                                _ => -1,
                            },
                            's' => input[3] == 'e' ? /* match 'case' */ 183 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'l' => input[3] == 'l' ? /* match 'cell' */ 184 : -1,
                            'n' => input[3] == 't' ? /* match 'cent' */ 185 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ty") ? /* match 'city' */ 186 : -1,
                        'o' => input[2] switch
                        {
                            'a' => input[3] == 't' ? /* match 'coat' */ 187 : -1,
                            'l' => input[3] == 'd' ? /* match 'cold' */ 188 : -1,
                            'm' => input[3] == 'e' ? /* match 'come' */ 189 : -1,
                            'o' => input[3] switch
                            {
                                'k' => /* match 'cook' */ 190,
                                'l' => /* match 'cool' */ 191,
                                _ => -1,
                            },
                            'p' => input[3] == 'y' ? /* match 'copy' */ 192 : -1,
                            'r' => input[3] == 'n' ? /* match 'corn' */ 193 : -1,
                            's' => input[3] == 't' ? /* match 'cost' */ 194 : -1,
                            _ => -1,
                        },
                        'r' => input.AsSpan(2).SequenceEqual("op") ? /* match 'crop' */ 195 : -1,
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("rk") ? /* match 'dark' */ 196 : -1,
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'd' => /* match 'dead' */ 197,
                                'l' => /* match 'deal' */ 198,
                                'r' => /* match 'dear' */ 199,
                                _ => -1,
                            },
                            'e' => input[3] == 'p' ? /* match 'deep' */ 200 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'e' => input[3] == 's' ? /* match 'does' */ 201 : -1,
                            'n' => input[3] == 'e' ? /* match 'done' */ 202 : -1,
                            'o' => input[3] == 'r' ? /* match 'door' */ 203 : -1,
                            'w' => input[3] == 'n' ? /* match 'down' */ 204 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'a' => input[3] == 'w' ? /* match 'draw' */ 205 : -1,
                            'o' => input[3] == 'p' ? /* match 'drop' */ 206 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("ck") ? /* match 'duck' */ 207 : -1,
                        _ => -1,
                    },
                    'e' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'c' => input[3] == 'h' ? /* match 'each' */ 208 : -1,
                            's' => input[3] switch
                            {
                                'e' => /* match 'ease' */ 209,
                                't' => /* match 'east' */ 210,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'd' => input.AsSpan(2).SequenceEqual("ge") ? /* match 'edge' */ 211 : -1,
                        'l' => input.AsSpan(2).SequenceEqual("se") ? /* match 'else' */ 212 : -1,
                        'v' => input[2] != 'e' ? -1 : input[3] switch
                        {
                            'n' => /* match 'even' */ 213,
                            'r' => /* match 'ever' */ 214,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'f' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'c' => input[3] switch
                            {
                                'e' => /* match 'face' */ 215,
                                't' => /* match 'fact' */ 216,
                                _ => -1,
                            },
                            'i' => input[3] == 'r' ? /* match 'fair' */ 217 : -1,
                            'l' => input[3] == 'l' ? /* match 'fall' */ 218 : -1,
                            'r' => input[3] == 'm' ? /* match 'farm' */ 219 : -1,
                            's' => input[3] == 't' ? /* match 'fast' */ 220 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] == 'r' ? /* match 'fear' */ 221 : -1,
                            'e' => input[3] switch
                            {
                                'd' => /* match 'feed' */ 222,
                                'l' => /* match 'feel' */ 223,
                                't' => /* match 'feet' */ 224,
                                _ => -1,
                            },
                            'l' => input[3] switch
                            {
                                'l' => /* match 'fell' */ 225,
                                't' => /* match 'felt' */ 226,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'l' => input[3] == 'l' ? /* match 'fill' */ 227 : -1,
                            'n' => input[3] switch
                            {
                                'd' => /* match 'find' */ 228,
                                'e' => /* match 'fine' */ 229,
                                _ => -1,
                            },
                            'r' => input[3] == 'e' ? /* match 'fire' */ 230 : -1,
                            's' => input[3] == 'h' ? /* match 'fish' */ 231 : -1,
                            'v' => input[3] == 'e' ? /* match 'five' */ 232 : -1,
                            _ => -1,
                        },
                        'l' => input[2] switch
                        {
                            'a' => input[3] == 't' ? /* match 'flat' */ 233 : -1,
                            'o' => input[3] == 'w' ? /* match 'flow' */ 234 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'o' => input[3] switch
                            {
                                'd' => /* match 'food' */ 235,
                                't' => /* match 'foot' */ 236,
                                _ => -1,
                            },
                            'r' => input[3] == 'm' ? /* match 'form' */ 237 : -1,
                            'u' => input[3] == 'r' ? /* match 'four' */ 238 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'e' => input[3] == 'e' ? /* match 'free' */ 239 : -1,
                            'o' => input[3] == 'm' ? /* match 'from' */ 240 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("ll") ? /* match 'full' */ 241 : -1,
                        _ => -1,
                    },
                    'g' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'm' => input[3] == 'e' ? /* match 'game' */ 242 : -1,
                            'v' => input[3] == 'e' ? /* match 'gave' */ 243 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'r' => input[3] == 'l' ? /* match 'girl' */ 244 : -1,
                            'v' => input[3] == 'e' ? /* match 'give' */ 245 : -1,
                            _ => -1,
                        },
                        'l' => input.AsSpan(2).SequenceEqual("ad") ? /* match 'glad' */ 246 : -1,
                        'o' => input[2] switch
                        {
                            'l' => input[3] == 'd' ? /* match 'gold' */ 247 : -1,
                            'n' => input[3] == 'e' ? /* match 'gone' */ 248 : -1,
                            'o' => input[3] == 'd' ? /* match 'good' */ 249 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'a' => input[3] == 'y' ? /* match 'gray' */ 250 : -1,
                            'e' => input[3] == 'w' ? /* match 'grew' */ 251 : -1,
                            'o' => input[3] == 'w' ? /* match 'grow' */ 252 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'h' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'i' => input[3] == 'r' ? /* match 'hair' */ 253 : -1,
                            'l' => input[3] == 'f' ? /* match 'half' */ 254 : -1,
                            'n' => input[3] == 'd' ? /* match 'hand' */ 255 : -1,
                            'r' => input[3] == 'd' ? /* match 'hard' */ 256 : -1,
                            'v' => input[3] == 'e' ? /* match 'have' */ 257 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'd' => /* match 'head' */ 258,
                                'r' => /* match 'hear' */ 259,
                                't' => /* match 'heat' */ 260,
                                _ => -1,
                            },
                            'l' => input[3] switch
                            {
                                'd' => /* match 'held' */ 261,
                                'p' => /* match 'help' */ 262,
                                _ => -1,
                            },
                            'r' => input[3] == 'e' ? /* match 'here' */ 263 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'g' => input[3] == 'h' ? /* match 'high' */ 264 : -1,
                            'l' => input[3] == 'l' ? /* match 'hill' */ 265 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'l' => input[3] switch
                            {
                                'd' => /* match 'hold' */ 266,
                                'e' => /* match 'hole' */ 267,
                                _ => -1,
                            },
                            'm' => input[3] == 'e' ? /* match 'home' */ 268 : -1,
                            'p' => input[3] == 'e' ? /* match 'hope' */ 269 : -1,
                            'u' => input[3] == 'r' ? /* match 'hour' */ 270 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'g' => input[3] == 'e' ? /* match 'huge' */ 271 : -1,
                            'n' => input[3] == 't' ? /* match 'hunt' */ 272 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'i' => input[1] switch
                    {
                        'd' => input.AsSpan(2).SequenceEqual("ea") ? /* match 'idea' */ 273 : -1,
                        'n' => input.AsSpan(2).SequenceEqual("ch") ? /* match 'inch' */ 274 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("on") ? /* match 'iron' */ 275 : -1,
                        _ => -1,
                    },
                    'j' => input[1] switch
                    {
                        'o' => input.AsSpan(2).SequenceEqual("in") ? /* match 'join' */ 276 : -1,
                        'u' => input[2] switch
                        {
                            'm' => input[3] == 'p' ? /* match 'jump' */ 277 : -1,
                            's' => input[3] == 't' ? /* match 'just' */ 278 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'k' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            'e' => input[3] == 'p' ? /* match 'keep' */ 279 : -1,
                            'p' => input[3] == 't' ? /* match 'kept' */ 280 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'l' => input[3] == 'l' ? /* match 'kill' */ 281 : -1,
                            'n' => input[3] switch
                            {
                                'd' => /* match 'kind' */ 282,
                                'g' => /* match 'king' */ 283,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'n' => input[2] switch
                        {
                            'e' => input[3] == 'w' ? /* match 'knew' */ 284 : -1,
                            'o' => input[3] == 'w' ? /* match 'know' */ 285 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'l' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'd' => input[3] == 'y' ? /* match 'lady' */ 286 : -1,
                            'k' => input[3] == 'e' ? /* match 'lake' */ 287 : -1,
                            'n' => input[3] == 'd' ? /* match 'land' */ 288 : -1,
                            's' => input[3] == 't' ? /* match 'last' */ 289 : -1,
                            't' => input[3] == 'e' ? /* match 'late' */ 290 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] == 'd' ? /* match 'lead' */ 291 : -1,
                            'f' => input[3] == 't' ? /* match 'left' */ 292 : -1,
                            's' => input[3] == 's' ? /* match 'less' */ 293 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'f' => input[3] switch
                            {
                                'e' => /* match 'life' */ 294,
                                't' => /* match 'lift' */ 295,
                                _ => -1,
                            },
                            'k' => input[3] == 'e' ? /* match 'like' */ 296 : -1,
                            'n' => input[3] == 'e' ? /* match 'line' */ 297 : -1,
                            's' => input[3] == 't' ? /* match 'list' */ 298 : -1,
                            'v' => input[3] == 'e' ? /* match 'live' */ 299 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'n' => input[3] switch
                            {
                                'e' => /* match 'lone' */ 300,
                                'g' => /* match 'long' */ 301,
                                _ => -1,
                            },
                            'o' => input[3] == 'k' ? /* match 'look' */ 302 : -1,
                            's' => input[3] == 't' ? /* match 'lost' */ 303 : -1,
                            'u' => input[3] == 'd' ? /* match 'loud' */ 304 : -1,
                            'v' => input[3] == 'e' ? /* match 'love' */ 305 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'm' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'd' => input[3] == 'e' ? /* match 'made' */ 306 : -1,
                            'i' => input[3] == 'n' ? /* match 'main' */ 307 : -1,
                            'k' => input[3] == 'e' ? /* match 'make' */ 308 : -1,
                            'n' => input[3] == 'y' ? /* match 'many' */ 309 : -1,
                            'r' => input[3] == 'k' ? /* match 'mark' */ 310 : -1,
                            's' => input[3] == 's' ? /* match 'mass' */ 311 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'n' => /* match 'mean' */ 312,
                                't' => /* match 'meat' */ 313,
                                _ => -1,
                            },
                            'e' => input[3] == 't' ? /* match 'meet' */ 314 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'l' => input[3] switch
                            {
                                'e' => /* match 'mile' */ 315,
                                'k' => /* match 'milk' */ 316,
                                _ => -1,
                            },
                            'n' => input[3] switch
                            {
                                'd' => /* match 'mind' */ 317,
                                'e' => /* match 'mine' */ 318,
                                _ => -1,
                            },
                            's' => input[3] == 's' ? /* match 'miss' */ 319 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'o' => input[3] == 'n' ? /* match 'moon' */ 320 : -1,
                            'r' => input[3] == 'e' ? /* match 'more' */ 321 : -1,
                            's' => input[3] == 't' ? /* match 'most' */ 322 : -1,
                            'v' => input[3] == 'e' ? /* match 'move' */ 323 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'c' => input[3] == 'h' ? /* match 'much' */ 324 : -1,
                            's' => input[3] == 't' ? /* match 'must' */ 325 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'n' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("me") ? /* match 'name' */ 326 : -1,
                        'e' => input[2] switch
                        {
                            'a' => input[3] == 'r' ? /* match 'near' */ 327 : -1,
                            'c' => input[3] == 'k' ? /* match 'neck' */ 328 : -1,
                            'e' => input[3] == 'd' ? /* match 'need' */ 329 : -1,
                            'x' => input[3] == 't' ? /* match 'next' */ 330 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ne") ? /* match 'nine' */ 331 : -1,
                        'o' => input[2] switch
                        {
                            'o' => input[3] == 'n' ? /* match 'noon' */ 332 : -1,
                            's' => input[3] == 'e' ? /* match 'nose' */ 333 : -1,
                            't' => input[3] == 'e' ? /* match 'note' */ 334 : -1,
                            'u' => input[3] == 'n' ? /* match 'noun' */ 335 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'o' => input[1] switch
                    {
                        'n' => input[2] switch
                        {
                            'c' => input[3] == 'e' ? /* match 'once' */ 336 : -1,
                            'l' => input[3] == 'y' ? /* match 'only' */ 337 : -1,
                            _ => -1,
                        },
                        'p' => input.AsSpan(2).SequenceEqual("en") ? /* match 'open' */ 338 : -1,
                        'v' => input.AsSpan(2).SequenceEqual("er") ? /* match 'over' */ 339 : -1,
                        _ => -1,
                    },
                    'p' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'g' => input[3] == 'e' ? /* match 'page' */ 340 : -1,
                            'i' => input[3] == 'r' ? /* match 'pair' */ 341 : -1,
                            'r' => input[3] == 't' ? /* match 'part' */ 342 : -1,
                            's' => input[3] switch
                            {
                                's' => /* match 'pass' */ 343,
                                't' => /* match 'past' */ 344,
                                _ => -1,
                            },
                            't' => input[3] == 'h' ? /* match 'path' */ 345 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ck") ? /* match 'pick' */ 346 : -1,
                        'l' => input[2] != 'a' ? -1 : input[3] switch
                        {
                            'n' => /* match 'plan' */ 347,
                            'y' => /* match 'play' */ 348,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'e' => input[3] == 'm' ? /* match 'poem' */ 349 : -1,
                            'o' => input[3] == 'r' ? /* match 'poor' */ 350 : -1,
                            'r' => input[3] == 't' ? /* match 'port' */ 351 : -1,
                            's' => input[3] switch
                            {
                                'e' => /* match 'pose' */ 352,
                                't' => /* match 'post' */ 353,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'l' => input[3] == 'l' ? /* match 'pull' */ 354 : -1,
                            's' => input[3] == 'h' ? /* match 'push' */ 355 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'r' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'c' => input[3] == 'e' ? /* match 'race' */ 356 : -1,
                            'i' => input[3] switch
                            {
                                'l' => /* match 'rail' */ 357,
                                'n' => /* match 'rain' */ 358,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'd' => /* match 'read' */ 359,
                                'l' => /* match 'real' */ 360,
                                _ => -1,
                            },
                            's' => input[3] == 't' ? /* match 'rest' */ 361 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'c' => input[3] == 'h' ? /* match 'rich' */ 362 : -1,
                            'd' => input[3] == 'e' ? /* match 'ride' */ 363 : -1,
                            'n' => input[3] == 'g' ? /* match 'ring' */ 364 : -1,
                            's' => input[3] == 'e' ? /* match 'rise' */ 365 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'a' => input[3] == 'd' ? /* match 'road' */ 366 : -1,
                            'c' => input[3] == 'k' ? /* match 'rock' */ 367 : -1,
                            'l' => input[3] == 'l' ? /* match 'roll' */ 368 : -1,
                            'o' => input[3] switch
                            {
                                'm' => /* match 'room' */ 369,
                                't' => /* match 'root' */ 370,
                                _ => -1,
                            },
                            'p' => input[3] == 'e' ? /* match 'rope' */ 371 : -1,
                            's' => input[3] == 'e' ? /* match 'rose' */ 372 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("le") ? /* match 'rule' */ 373 : -1,
                        _ => -1,
                    },
                    's' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'f' => input[3] == 'e' ? /* match 'safe' */ 374 : -1,
                            'i' => input[3] switch
                            {
                                'd' => /* match 'said' */ 375,
                                'l' => /* match 'sail' */ 376,
                                _ => -1,
                            },
                            'l' => input[3] == 't' ? /* match 'salt' */ 377 : -1,
                            'm' => input[3] == 'e' ? /* match 'same' */ 378 : -1,
                            'n' => input[3] == 'd' ? /* match 'sand' */ 379 : -1,
                            'v' => input[3] == 'e' ? /* match 'save' */ 380 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] == 't' ? /* match 'seat' */ 381 : -1,
                            'e' => input[3] switch
                            {
                                'd' => /* match 'seed' */ 382,
                                'm' => /* match 'seem' */ 383,
                                _ => -1,
                            },
                            'l' => input[3] switch
                            {
                                'f' => /* match 'self' */ 384,
                                'l' => /* match 'sell' */ 385,
                                _ => -1,
                            },
                            'n' => input[3] switch
                            {
                                'd' => /* match 'send' */ 386,
                                't' => /* match 'sent' */ 387,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'i' => input[3] == 'p' ? /* match 'ship' */ 388 : -1,
                            'o' => input[3] switch
                            {
                                'e' => /* match 'shoe' */ 389,
                                'p' => /* match 'shop' */ 390,
                                'w' => /* match 'show' */ 391,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'd' => input[3] == 'e' ? /* match 'side' */ 392 : -1,
                            'g' => input[3] == 'n' ? /* match 'sign' */ 393 : -1,
                            'n' => input[3] == 'g' ? /* match 'sing' */ 394 : -1,
                            'z' => input[3] == 'e' ? /* match 'size' */ 395 : -1,
                            _ => -1,
                        },
                        'k' => input.AsSpan(2).SequenceEqual("in") ? /* match 'skin' */ 396 : -1,
                        'l' => input[2] switch
                        {
                            'i' => input[3] == 'p' ? /* match 'slip' */ 397 : -1,
                            'o' => input[3] == 'w' ? /* match 'slow' */ 398 : -1,
                            _ => -1,
                        },
                        'n' => input.AsSpan(2).SequenceEqual("ow") ? /* match 'snow' */ 399 : -1,
                        'o' => input[2] switch
                        {
                            'f' => input[3] == 't' ? /* match 'soft' */ 400 : -1,
                            'i' => input[3] == 'l' ? /* match 'soil' */ 401 : -1,
                            'm' => input[3] == 'e' ? /* match 'some' */ 402 : -1,
                            'n' => input[3] == 'g' ? /* match 'song' */ 403 : -1,
                            'o' => input[3] == 'n' ? /* match 'soon' */ 404 : -1,
                            _ => -1,
                        },
                        'p' => input.AsSpan(2).SequenceEqual("ot") ? /* match 'spot' */ 405 : -1,
                        't' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'r' => /* match 'star' */ 406,
                                'y' => /* match 'stay' */ 407,
                                _ => -1,
                            },
                            'e' => input[3] == 'p' ? /* match 'step' */ 408 : -1,
                            'o' => input[3] == 'p' ? /* match 'stop' */ 409 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'c' => input[3] == 'h' ? /* match 'such' */ 410 : -1,
                            'i' => input[3] == 't' ? /* match 'suit' */ 411 : -1,
                            'r' => input[3] == 'e' ? /* match 'sure' */ 412 : -1,
                            _ => -1,
                        },
                        'w' => input.AsSpan(2).SequenceEqual("im") ? /* match 'swim' */ 413 : -1,
                        _ => -1,
                    },
                    't' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'i' => input[3] == 'l' ? /* match 'tail' */ 414 : -1,
                            'k' => input[3] == 'e' ? /* match 'take' */ 415 : -1,
                            'l' => input[3] switch
                            {
                                'k' => /* match 'talk' */ 416,
                                'l' => /* match 'tall' */ 417,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] == 'm' ? /* match 'team' */ 418 : -1,
                            'l' => input[3] == 'l' ? /* match 'tell' */ 419 : -1,
                            'r' => input[3] == 'm' ? /* match 'term' */ 420 : -1,
                            's' => input[3] == 't' ? /* match 'test' */ 421 : -1,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'n' => /* match 'than' */ 422,
                                't' => /* match 'that' */ 423,
                                _ => -1,
                            },
                            'e' => input[3] switch
                            {
                                'm' => /* match 'them' */ 424,
                                'n' => /* match 'then' */ 425,
                                'y' => /* match 'they' */ 426,
                                _ => -1,
                            },
                            'i' => input[3] switch
                            {
                                'n' => /* match 'thin' */ 427,
                                's' => /* match 'this' */ 428,
                                _ => -1,
                            },
                            'u' => input[3] == 's' ? /* match 'thus' */ 429 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'm' => input[3] == 'e' ? /* match 'time' */ 430 : -1,
                            'n' => input[3] == 'y' ? /* match 'tiny' */ 431 : -1,
                            'r' => input[3] == 'e' ? /* match 'tire' */ 432 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'l' => input[3] == 'd' ? /* match 'told' */ 433 : -1,
                            'n' => input[3] == 'e' ? /* match 'tone' */ 434 : -1,
                            'o' => input[3] switch
                            {
                                'k' => /* match 'took' */ 435,
                                'l' => /* match 'tool' */ 436,
                                _ => -1,
                            },
                            'w' => input[3] == 'n' ? /* match 'town' */ 437 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'e' => input[3] == 'e' ? /* match 'tree' */ 438 : -1,
                            'i' => input[3] == 'p' ? /* match 'trip' */ 439 : -1,
                            'u' => input[3] == 'e' ? /* match 'true' */ 440 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'b' => input[3] == 'e' ? /* match 'tube' */ 441 : -1,
                            'r' => input[3] == 'n' ? /* match 'turn' */ 442 : -1,
                            _ => -1,
                        },
                        'y' => input.AsSpan(2).SequenceEqual("pe") ? /* match 'type' */ 443 : -1,
                        _ => -1,
                    },
                    'u' => input.AsSpan(1).SequenceEqual("nit") ? /* match 'unit' */ 444 : -1,
                    'v' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("ry") ? /* match 'vary' */ 445 : -1,
                        'e' => input[2] != 'r' ? -1 : input[3] switch
                        {
                            'b' => /* match 'verb' */ 446,
                            'y' => /* match 'very' */ 447,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ew") ? /* match 'view' */ 448 : -1,
                        _ => -1,
                    },
                    'w' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'i' => input[3] == 't' ? /* match 'wait' */ 449 : -1,
                            'l' => input[3] switch
                            {
                                'k' => /* match 'walk' */ 450,
                                'l' => /* match 'wall' */ 451,
                                _ => -1,
                            },
                            'n' => input[3] == 't' ? /* match 'want' */ 452 : -1,
                            'r' => input[3] == 'm' ? /* match 'warm' */ 453 : -1,
                            's' => input[3] == 'h' ? /* match 'wash' */ 454 : -1,
                            'v' => input[3] == 'e' ? /* match 'wave' */ 455 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] == 'r' ? /* match 'wear' */ 456 : -1,
                            'e' => input[3] == 'k' ? /* match 'week' */ 457 : -1,
                            'l' => input[3] == 'l' ? /* match 'well' */ 458 : -1,
                            'n' => input[3] == 't' ? /* match 'went' */ 459 : -1,
                            'r' => input[3] == 'e' ? /* match 'were' */ 460 : -1,
                            's' => input[3] == 't' ? /* match 'west' */ 461 : -1,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'a' => input[3] == 't' ? /* match 'what' */ 462 : -1,
                            'e' => input[3] == 'n' ? /* match 'when' */ 463 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'd' => input[3] == 'e' ? /* match 'wide' */ 464 : -1,
                            'f' => input[3] == 'e' ? /* match 'wife' */ 465 : -1,
                            'l' => input[3] switch
                            {
                                'd' => /* match 'wild' */ 466,
                                'l' => /* match 'will' */ 467,
                                _ => -1,
                            },
                            'n' => input[3] switch
                            {
                                'd' => /* match 'wind' */ 468,
                                'g' => /* match 'wing' */ 469,
                                _ => -1,
                            },
                            'r' => input[3] == 'e' ? /* match 'wire' */ 470 : -1,
                            's' => input[3] == 'h' ? /* match 'wish' */ 471 : -1,
                            't' => input[3] == 'h' ? /* match 'with' */ 472 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'o' => input[3] == 'd' ? /* match 'wood' */ 473 : -1,
                            'r' => input[3] switch
                            {
                                'd' => /* match 'word' */ 474,
                                'k' => /* match 'work' */ 475,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'y' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("rd") ? /* match 'yard' */ 476 : -1,
                        'e' => input.AsSpan(2).SequenceEqual("ar") ? /* match 'year' */ 477 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("ur") ? /* match 'your' */ 478 : -1,
                        _ => -1,
                    },
                    _ => -1,
                },
                5 => input[0] switch
                {
                    'a' => input[1] switch
                    {
                        'b' => input[2] != 'o' ? -1 : input[3] switch
                        {
                            'u' => input[4] == 't' ? /* match 'about' */ 479 : -1,
                            'v' => input[4] == 'e' ? /* match 'above' */ 480 : -1,
                            _ => -1,
                        },
                        'f' => input.AsSpan(2).SequenceEqual("ter") ? /* match 'after' */ 481 : -1,
                        'g' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("in") ? /* match 'again' */ 482 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ee") ? /* match 'agree' */ 483 : -1,
                            _ => -1,
                        },
                        'l' => input.AsSpan(2).SequenceEqual("low") ? /* match 'allow' */ 484 : -1,
                        'm' => input.AsSpan(2).SequenceEqual("ong") ? /* match 'among' */ 485 : -1,
                        'n' => input.AsSpan(2).SequenceEqual("ger") ? /* match 'anger' */ 486 : -1,
                        'p' => input.AsSpan(2).SequenceEqual("ple") ? /* match 'apple' */ 487 : -1,
                        _ => -1,
                    },
                    'b' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("sic") ? /* match 'basic' */ 488 : -1,
                        'e' => input[2] != 'g' ? -1 : input[3] switch
                        {
                            'a' => input[4] == 'n' ? /* match 'began' */ 489 : -1,
                            'i' => input[4] == 'n' ? /* match 'begin' */ 490 : -1,
                            _ => -1,
                        },
                        'l' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("ck") ? /* match 'black' */ 491 : -1,
                            'o' => input[3] switch
                            {
                                'c' => input[4] == 'k' ? /* match 'block' */ 492 : -1,
                                'o' => input[4] == 'd' ? /* match 'blood' */ 493 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'o' => input.AsSpan(2).SequenceEqual("ard") ? /* match 'board' */ 494 : -1,
                        'r' => input[2] switch
                        {
                            'e' => input[3] != 'a' ? -1 : input[4] switch
                            {
                                'd' => /* match 'bread' */ 495,
                                'k' => /* match 'break' */ 496,
                                _ => -1,
                            },
                            'i' => input.AsSpan(3).SequenceEqual("ng") ? /* match 'bring' */ 497 : -1,
                            'o' => input[3] switch
                            {
                                'a' => input[4] == 'd' ? /* match 'broad' */ 498 : -1,
                                'k' => input[4] == 'e' ? /* match 'broke' */ 499 : -1,
                                'w' => input[4] == 'n' ? /* match 'brown' */ 500 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("ild") ? /* match 'build' */ 501 : -1,
                        _ => -1,
                    },
                    'c' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'r' => input.AsSpan(3).SequenceEqual("ry") ? /* match 'carry' */ 502 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ch") ? /* match 'catch' */ 503 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("se") ? /* match 'cause' */ 504 : -1,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'i' => input[4] == 'r' ? /* match 'chair' */ 505 : -1,
                                'r' => input[4] == 't' ? /* match 'chart' */ 506 : -1,
                                _ => -1,
                            },
                            'e' => input.AsSpan(3).SequenceEqual("ck") ? /* match 'check' */ 507 : -1,
                            'i' => input[3] switch
                            {
                                'c' => input[4] == 'k' ? /* match 'chick' */ 508 : -1,
                                'e' => input[4] == 'f' ? /* match 'chief' */ 509 : -1,
                                'l' => input[4] == 'd' ? /* match 'child' */ 510 : -1,
                                _ => -1,
                            },
                            'o' => input.AsSpan(3).SequenceEqual("rd") ? /* match 'chord' */ 511 : -1,
                            _ => -1,
                        },
                        'l' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'i' => input[4] == 'm' ? /* match 'claim' */ 512 : -1,
                                's' => input[4] == 's' ? /* match 'class' */ 513 : -1,
                                _ => -1,
                            },
                            'e' => input[3] != 'a' ? -1 : input[4] switch
                            {
                                'n' => /* match 'clean' */ 514,
                                'r' => /* match 'clear' */ 515,
                                _ => -1,
                            },
                            'i' => input.AsSpan(3).SequenceEqual("mb") ? /* match 'climb' */ 516 : -1,
                            'o' => input[3] switch
                            {
                                'c' => input[4] == 'k' ? /* match 'clock' */ 517 : -1,
                                's' => input[4] == 'e' ? /* match 'close' */ 518 : -1,
                                'u' => input[4] == 'd' ? /* match 'cloud' */ 519 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("st") ? /* match 'coast' */ 520 : -1,
                            'l' => input.AsSpan(3).SequenceEqual("or") ? /* match 'color' */ 521 : -1,
                            'u' => input[3] switch
                            {
                                'l' => input[4] == 'd' ? /* match 'could' */ 522 : -1,
                                'n' => input[4] == 't' ? /* match 'count' */ 523 : -1,
                                _ => -1,
                            },
                            'v' => input.AsSpan(3).SequenceEqual("er") ? /* match 'cover' */ 524 : -1,
                            _ => -1,
                        },
                        'r' => input[2] != 'o' ? -1 : input[3] switch
                        {
                            's' => input[4] == 's' ? /* match 'cross' */ 525 : -1,
                            'w' => input[4] == 'd' ? /* match 'crowd' */ 526 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("nce") ? /* match 'dance' */ 527 : -1,
                        'e' => input.AsSpan(2).SequenceEqual("ath") ? /* match 'death' */ 528 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("n't") ? /* match 'don't' */ 529 : -1,
                        'r' => input[2] switch
                        {
                            'e' => input[3] switch
                            {
                                'a' => input[4] == 'm' ? /* match 'dream' */ 530 : -1,
                                's' => input[4] == 's' ? /* match 'dress' */ 531 : -1,
                                _ => -1,
                            },
                            'i' => input[3] switch
                            {
                                'n' => input[4] == 'k' ? /* match 'drink' */ 532 : -1,
                                'v' => input[4] == 'e' ? /* match 'drive' */ 533 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'e' => input[1] switch
                    {
                        'a' => input[2] != 'r' ? -1 : input[3] switch
                        {
                            'l' => input[4] == 'y' ? /* match 'early' */ 534 : -1,
                            't' => input[4] == 'h' ? /* match 'earth' */ 535 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ght") ? /* match 'eight' */ 536 : -1,
                        'n' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("my") ? /* match 'enemy' */ 537 : -1,
                            't' => input.AsSpan(3).SequenceEqual("er") ? /* match 'enter' */ 538 : -1,
                            _ => -1,
                        },
                        'q' => input.AsSpan(2).SequenceEqual("ual") ? /* match 'equal' */ 539 : -1,
                        'v' => input[2] != 'e' ? -1 : input[3] switch
                        {
                            'n' => input[4] == 't' ? /* match 'event' */ 540 : -1,
                            'r' => input[4] == 'y' ? /* match 'every' */ 541 : -1,
                            _ => -1,
                        },
                        'x' => input.AsSpan(2).SequenceEqual("act") ? /* match 'exact' */ 542 : -1,
                        _ => -1,
                    },
                    'f' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("vor") ? /* match 'favor' */ 543 : -1,
                        'i' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("ld") ? /* match 'field' */ 544 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("ht") ? /* match 'fight' */ 545 : -1,
                            'n' => input.AsSpan(3).SequenceEqual("al") ? /* match 'final' */ 546 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("st") ? /* match 'first' */ 547 : -1,
                            _ => -1,
                        },
                        'l' => input.AsSpan(2).SequenceEqual("oor") ? /* match 'floor' */ 548 : -1,
                        'o' => input[2] switch
                        {
                            'r' => input.AsSpan(3).SequenceEqual("ce") ? /* match 'force' */ 549 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("nd") ? /* match 'found' */ 550 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("sh") ? /* match 'fresh' */ 551 : -1,
                            'o' => input.AsSpan(3).SequenceEqual("nt") ? /* match 'front' */ 552 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("it") ? /* match 'fruit' */ 553 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'g' => input[1] switch
                    {
                        'l' => input.AsSpan(2).SequenceEqual("ass") ? /* match 'glass' */ 554 : -1,
                        'r' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'n' => input[4] == 'd' ? /* match 'grand' */ 555 : -1,
                                's' => input[4] == 's' ? /* match 'grass' */ 556 : -1,
                                _ => -1,
                            },
                            'e' => input[3] switch
                            {
                                'a' => input[4] == 't' ? /* match 'great' */ 557 : -1,
                                'e' => input[4] == 'n' ? /* match 'green' */ 558 : -1,
                                _ => -1,
                            },
                            'o' => input.AsSpan(3).SequenceEqual("up") ? /* match 'group' */ 559 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("ss") ? /* match 'guess' */ 560 : -1,
                            'i' => input.AsSpan(3).SequenceEqual("de") ? /* match 'guide' */ 561 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'h' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("ppy") ? /* match 'happy' */ 562 : -1,
                        'e' => input[2] != 'a' ? -1 : input[3] switch
                        {
                            'r' => input[4] switch
                            {
                                'd' => /* match 'heard' */ 563,
                                't' => /* match 'heart' */ 564,
                                _ => -1,
                            },
                            'v' => input[4] == 'y' ? /* match 'heavy' */ 565 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'r' => input.AsSpan(3).SequenceEqual("se") ? /* match 'horse' */ 566 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("se") ? /* match 'house' */ 567 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'm' => input.AsSpan(3).SequenceEqual("an") ? /* match 'human' */ 568 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ry") ? /* match 'hurry' */ 569 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'l' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'r' => input.AsSpan(3).SequenceEqual("ge") ? /* match 'large' */ 570 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("gh") ? /* match 'laugh' */ 571 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'r' => input[4] == 'n' ? /* match 'learn' */ 572 : -1,
                                's' => input[4] == 't' ? /* match 'least' */ 573 : -1,
                                'v' => input[4] == 'e' ? /* match 'leave' */ 574 : -1,
                                _ => -1,
                            },
                            'v' => input.AsSpan(3).SequenceEqual("el") ? /* match 'level' */ 575 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ght") ? /* match 'light' */ 576 : -1,
                        _ => -1,
                    },
                    'm' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'j' => input.AsSpan(3).SequenceEqual("or") ? /* match 'major' */ 577 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ch") ? /* match 'match' */ 578 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("nt") ? /* match 'meant' */ 579 : -1,
                            't' => input.AsSpan(3).SequenceEqual("al") ? /* match 'metal' */ 580 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ght") ? /* match 'might' */ 581 : -1,
                        'o' => input[2] switch
                        {
                            'n' => input[3] switch
                            {
                                'e' => input[4] == 'y' ? /* match 'money' */ 582 : -1,
                                't' => input[4] == 'h' ? /* match 'month' */ 583 : -1,
                                _ => -1,
                            },
                            'u' => input[3] switch
                            {
                                'n' => input[4] == 't' ? /* match 'mount' */ 584 : -1,
                                't' => input[4] == 'h' ? /* match 'mouth' */ 585 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("sic") ? /* match 'music' */ 586 : -1,
                        _ => -1,
                    },
                    'n' => input[1] switch
                    {
                        'e' => input.AsSpan(2).SequenceEqual("ver") ? /* match 'never' */ 587 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("ght") ? /* match 'night' */ 588 : -1,
                        'o' => input[2] switch
                        {
                            'i' => input.AsSpan(3).SequenceEqual("se") ? /* match 'noise' */ 589 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("th") ? /* match 'north' */ 590 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'o' => input[1] switch
                    {
                        'c' => input[2] switch
                        {
                            'c' => input.AsSpan(3).SequenceEqual("ur") ? /* match 'occur' */ 591 : -1,
                            'e' => input.AsSpan(3).SequenceEqual("an") ? /* match 'ocean' */ 592 : -1,
                            _ => -1,
                        },
                        'f' => input[2] switch
                        {
                            'f' => input.AsSpan(3).SequenceEqual("er") ? /* match 'offer' */ 593 : -1,
                            't' => input.AsSpan(3).SequenceEqual("en") ? /* match 'often' */ 594 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'd' => input.AsSpan(3).SequenceEqual("er") ? /* match 'order' */ 595 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("an") ? /* match 'organ' */ 596 : -1,
                            _ => -1,
                        },
                        't' => input.AsSpan(2).SequenceEqual("her") ? /* match 'other' */ 597 : -1,
                        _ => -1,
                    },
                    'p' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'i' => input.AsSpan(3).SequenceEqual("nt") ? /* match 'paint' */ 598 : -1,
                            'p' => input.AsSpan(3).SequenceEqual("er") ? /* match 'paper' */ 599 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ty") ? /* match 'party' */ 600 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("ce") ? /* match 'piece' */ 601 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ch") ? /* match 'pitch' */ 602 : -1,
                            _ => -1,
                        },
                        'l' => input[2] != 'a' ? -1 : input[3] switch
                        {
                            'c' => input[4] == 'e' ? /* match 'place' */ 603 : -1,
                            'i' => input[4] == 'n' ? /* match 'plain' */ 604 : -1,
                            'n' => input[4] switch
                            {
                                'e' => /* match 'plane' */ 605,
                                't' => /* match 'plant' */ 606,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'i' => input.AsSpan(3).SequenceEqual("nt") ? /* match 'point' */ 607 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("nd") ? /* match 'pound' */ 608 : -1,
                            'w' => input.AsSpan(3).SequenceEqual("er") ? /* match 'power' */ 609 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("ss") ? /* match 'press' */ 610 : -1,
                            'i' => input.AsSpan(3).SequenceEqual("nt") ? /* match 'print' */ 611 : -1,
                            'o' => input.AsSpan(3).SequenceEqual("ve") ? /* match 'prove' */ 612 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'q' => input[1] != 'u' ? -1 : input[2] switch
                    {
                        'a' => input.AsSpan(3).SequenceEqual("rt") ? /* match 'quart' */ 613 : -1,
                        'i' => input[3] switch
                        {
                            'c' => input[4] == 'k' ? /* match 'quick' */ 614 : -1,
                            'e' => input[4] == 't' ? /* match 'quiet' */ 615 : -1,
                            't' => input[4] == 'e' ? /* match 'quite' */ 616 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'r' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'd' => input.AsSpan(3).SequenceEqual("io") ? /* match 'radio' */ 617 : -1,
                            'i' => input.AsSpan(3).SequenceEqual("se") ? /* match 'raise' */ 618 : -1,
                            'n' => input.AsSpan(3).SequenceEqual("ge") ? /* match 'range' */ 619 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'c' => input[4] == 'h' ? /* match 'reach' */ 620 : -1,
                                'd' => input[4] == 'y' ? /* match 'ready' */ 621 : -1,
                                _ => -1,
                            },
                            'p' => input.AsSpan(3).SequenceEqual("ly") ? /* match 'reply' */ 622 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'g' => input.AsSpan(3).SequenceEqual("ht") ? /* match 'right' */ 623 : -1,
                            'v' => input.AsSpan(3).SequenceEqual("er") ? /* match 'river' */ 624 : -1,
                            _ => -1,
                        },
                        'o' => input.AsSpan(2).SequenceEqual("und") ? /* match 'round' */ 625 : -1,
                        _ => -1,
                    },
                    's' => input[1] switch
                    {
                        'c' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("le") ? /* match 'scale' */ 626 : -1,
                            'o' => input.AsSpan(3).SequenceEqual("re") ? /* match 'score' */ 627 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'n' => input.AsSpan(3).SequenceEqual("se") ? /* match 'sense' */ 628 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ve") ? /* match 'serve' */ 629 : -1,
                            'v' => input.AsSpan(3).SequenceEqual("en") ? /* match 'seven' */ 630 : -1,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'l' => input[4] == 'l' ? /* match 'shall' */ 631 : -1,
                                'p' => input[4] == 'e' ? /* match 'shape' */ 632 : -1,
                                'r' => input[4] switch
                                {
                                    'e' => /* match 'share' */ 633,
                                    'p' => /* match 'sharp' */ 634,
                                    _ => -1,
                                },
                                _ => -1,
                            },
                            'e' => input[3] switch
                            {
                                'e' => input[4] == 't' ? /* match 'sheet' */ 635 : -1,
                                'l' => input[4] == 'l' ? /* match 'shell' */ 636 : -1,
                                _ => -1,
                            },
                            'i' => input.AsSpan(3).SequenceEqual("ne") ? /* match 'shine' */ 637 : -1,
                            'o' => input[3] switch
                            {
                                'r' => input[4] switch
                                {
                                    'e' => /* match 'shore' */ 638,
                                    't' => /* match 'short' */ 639,
                                    _ => -1,
                                },
                                'u' => input[4] == 't' ? /* match 'shout' */ 640 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'g' => input.AsSpan(3).SequenceEqual("ht") ? /* match 'sight' */ 641 : -1,
                            'n' => input.AsSpan(3).SequenceEqual("ce") ? /* match 'since' */ 642 : -1,
                            _ => -1,
                        },
                        'k' => input.AsSpan(2).SequenceEqual("ill") ? /* match 'skill' */ 643 : -1,
                        'l' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("ve") ? /* match 'slave' */ 644 : -1,
                            'e' => input.AsSpan(3).SequenceEqual("ep") ? /* match 'sleep' */ 645 : -1,
                            _ => -1,
                        },
                        'm' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("ll") ? /* match 'small' */ 646 : -1,
                            'e' => input.AsSpan(3).SequenceEqual("ll") ? /* match 'smell' */ 647 : -1,
                            'i' => input.AsSpan(3).SequenceEqual("le") ? /* match 'smile' */ 648 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'l' => input.AsSpan(3).SequenceEqual("ve") ? /* match 'solve' */ 649 : -1,
                            'u' => input[3] switch
                            {
                                'n' => input[4] == 'd' ? /* match 'sound' */ 650 : -1,
                                't' => input[4] == 'h' ? /* match 'south' */ 651 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'p' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("ce") ? /* match 'space' */ 652 : -1,
                            'e' => input[3] switch
                            {
                                'a' => input[4] == 'k' ? /* match 'speak' */ 653 : -1,
                                'e' => input[4] == 'd' ? /* match 'speed' */ 654 : -1,
                                'l' => input[4] == 'l' ? /* match 'spell' */ 655 : -1,
                                'n' => input[4] == 'd' ? /* match 'spend' */ 656 : -1,
                                _ => -1,
                            },
                            'o' => input.AsSpan(3).SequenceEqual("ke") ? /* match 'spoke' */ 657 : -1,
                            _ => -1,
                        },
                        't' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'n' => input[4] == 'd' ? /* match 'stand' */ 658 : -1,
                                'r' => input[4] == 't' ? /* match 'start' */ 659 : -1,
                                't' => input[4] == 'e' ? /* match 'state' */ 660 : -1,
                                _ => -1,
                            },
                            'e' => input[3] switch
                            {
                                'a' => input[4] switch
                                {
                                    'd' => /* match 'stead' */ 661,
                                    'm' => /* match 'steam' */ 662,
                                    _ => -1,
                                },
                                'e' => input[4] == 'l' ? /* match 'steel' */ 663 : -1,
                                _ => -1,
                            },
                            'i' => input[3] switch
                            {
                                'c' => input[4] == 'k' ? /* match 'stick' */ 664 : -1,
                                'l' => input[4] == 'l' ? /* match 'still' */ 665 : -1,
                                _ => -1,
                            },
                            'o' => input[3] switch
                            {
                                'n' => input[4] == 'e' ? /* match 'stone' */ 666 : -1,
                                'o' => input[4] == 'd' ? /* match 'stood' */ 667 : -1,
                                'r' => input[4] switch
                                {
                                    'e' => /* match 'store' */ 668,
                                    'y' => /* match 'story' */ 669,
                                    _ => -1,
                                },
                                _ => -1,
                            },
                            'u' => input.AsSpan(3).SequenceEqual("dy") ? /* match 'study' */ 670 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("gar") ? /* match 'sugar' */ 671 : -1,
                        _ => -1,
                    },
                    't' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("ble") ? /* match 'table' */ 672 : -1,
                        'e' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("ch") ? /* match 'teach' */ 673 : -1,
                            'e' => input.AsSpan(3).SequenceEqual("th") ? /* match 'teeth' */ 674 : -1,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("nk") ? /* match 'thank' */ 675 : -1,
                            'e' => input[3] switch
                            {
                                'i' => input[4] == 'r' ? /* match 'their' */ 676 : -1,
                                'r' => input[4] == 'e' ? /* match 'there' */ 677 : -1,
                                's' => input[4] == 'e' ? /* match 'these' */ 678 : -1,
                                _ => -1,
                            },
                            'i' => input[3] switch
                            {
                                'c' => input[4] == 'k' ? /* match 'thick' */ 679 : -1,
                                'n' => input[4] switch
                                {
                                    'g' => /* match 'thing' */ 680,
                                    'k' => /* match 'think' */ 681,
                                    _ => -1,
                                },
                                'r' => input[4] == 'd' ? /* match 'third' */ 682 : -1,
                                _ => -1,
                            },
                            'o' => input.AsSpan(3).SequenceEqual("se") ? /* match 'those' */ 683 : -1,
                            'r' => input[3] switch
                            {
                                'e' => input[4] == 'e' ? /* match 'three' */ 684 : -1,
                                'o' => input[4] == 'w' ? /* match 'throw' */ 685 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            't' => input.AsSpan(3).SequenceEqual("al") ? /* match 'total' */ 686 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ch") ? /* match 'touch' */ 687 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'c' => input[4] == 'k' ? /* match 'track' */ 688 : -1,
                                'd' => input[4] == 'e' ? /* match 'trade' */ 689 : -1,
                                'i' => input[4] == 'n' ? /* match 'train' */ 690 : -1,
                                _ => -1,
                            },
                            'u' => input.AsSpan(3).SequenceEqual("ck") ? /* match 'truck' */ 691 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'u' => input[1] switch
                    {
                        'n' => input[2] switch
                        {
                            'd' => input.AsSpan(3).SequenceEqual("er") ? /* match 'under' */ 692 : -1,
                            't' => input.AsSpan(3).SequenceEqual("il") ? /* match 'until' */ 693 : -1,
                            _ => -1,
                        },
                        's' => input.AsSpan(2).SequenceEqual("ual") ? /* match 'usual' */ 694 : -1,
                        _ => -1,
                    },
                    'v' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("lue") ? /* match 'value' */ 695 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("sit") ? /* match 'visit' */ 696 : -1,
                        'o' => input[2] switch
                        {
                            'i' => input.AsSpan(3).SequenceEqual("ce") ? /* match 'voice' */ 697 : -1,
                            'w' => input.AsSpan(3).SequenceEqual("el") ? /* match 'vowel' */ 698 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'w' => input[1] switch
                    {
                        'a' => input[2] != 't' ? -1 : input[3] switch
                        {
                            'c' => input[4] == 'h' ? /* match 'watch' */ 699 : -1,
                            'e' => input[4] == 'r' ? /* match 'water' */ 700 : -1,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'e' => input[3] switch
                            {
                                'e' => input[4] == 'l' ? /* match 'wheel' */ 701 : -1,
                                'r' => input[4] == 'e' ? /* match 'where' */ 702 : -1,
                                _ => -1,
                            },
                            'i' => input[3] switch
                            {
                                'c' => input[4] == 'h' ? /* match 'which' */ 703 : -1,
                                'l' => input[4] == 'e' ? /* match 'while' */ 704 : -1,
                                't' => input[4] == 'e' ? /* match 'white' */ 705 : -1,
                                _ => -1,
                            },
                            'o' => input[3] switch
                            {
                                'l' => input[4] == 'e' ? /* match 'whole' */ 706 : -1,
                                's' => input[4] == 'e' ? /* match 'whose' */ 707 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'm' => input[3] switch
                            {
                                'a' => input[4] == 'n' ? /* match 'woman' */ 708 : -1,
                                'e' => input[4] == 'n' ? /* match 'women' */ 709 : -1,
                                _ => -1,
                            },
                            'n' => input.AsSpan(3).SequenceEqual("'t") ? /* match 'won't' */ 710 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ld") ? /* match 'world' */ 711 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ld") ? /* match 'would' */ 712 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'i' => input.AsSpan(3).SequenceEqual("te") ? /* match 'write' */ 713 : -1,
                            'o' => input[3] switch
                            {
                                'n' => input[4] == 'g' ? /* match 'wrong' */ 714 : -1,
                                't' => input[4] == 'e' ? /* match 'wrote' */ 715 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'y' => input.AsSpan(1).SequenceEqual("oung") ? /* match 'young' */ 716 : -1,
                    _ => -1,
                },
                6 => input[0] switch
                {
                    'a' => input[1] switch
                    {
                        'f' => input.AsSpan(2).SequenceEqual("raid") ? /* match 'afraid' */ 717 : -1,
                        'l' => input.AsSpan(2).SequenceEqual("ways") ? /* match 'always' */ 718 : -1,
                        'n' => input[2] switch
                        {
                            'i' => input.AsSpan(3).SequenceEqual("mal") ? /* match 'animal' */ 719 : -1,
                            's' => input.AsSpan(3).SequenceEqual("wer") ? /* match 'answer' */ 720 : -1,
                            _ => -1,
                        },
                        'p' => input.AsSpan(2).SequenceEqual("pear") ? /* match 'appear' */ 721 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("rive") ? /* match 'arrive' */ 722 : -1,
                        _ => -1,
                    },
                    'b' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("uty") ? /* match 'beauty' */ 723 : -1,
                            'f' => input.AsSpan(3).SequenceEqual("ore") ? /* match 'before' */ 724 : -1,
                            'h' => input.AsSpan(3).SequenceEqual("ind") ? /* match 'behind' */ 725 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ter") ? /* match 'better' */ 726 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            't' => input.AsSpan(3).SequenceEqual("tom") ? /* match 'bottom' */ 727 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ght") ? /* match 'bought' */ 728 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("nch") ? /* match 'branch' */ 729 : -1,
                            'i' => input.AsSpan(3).SequenceEqual("ght") ? /* match 'bright' */ 730 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'c' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("ught") ? /* match 'caught' */ 731 : -1,
                        'e' => input.AsSpan(2).SequenceEqual("nter") ? /* match 'center' */ 732 : -1,
                        'h' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'n' => input[4] switch
                                {
                                    'c' => input[5] == 'e' ? /* match 'chance' */ 733 : -1,
                                    'g' => input[5] == 'e' ? /* match 'change' */ 734 : -1,
                                    _ => -1,
                                },
                                'r' => input.AsSpan(4).SequenceEqual("ge") ? /* match 'charge' */ 735 : -1,
                                _ => -1,
                            },
                            'o' => input.AsSpan(3).SequenceEqual("ose") ? /* match 'choose' */ 736 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("rcle") ? /* match 'circle' */ 737 : -1,
                        'l' => input.AsSpan(2).SequenceEqual("othe") ? /* match 'clothe' */ 738 : -1,
                        'o' => input[2] switch
                        {
                            'l' => input[3] switch
                            {
                                'o' => input.AsSpan(4).SequenceEqual("ny") ? /* match 'colony' */ 739 : -1,
                                'u' => input.AsSpan(4).SequenceEqual("mn") ? /* match 'column' */ 740 : -1,
                                _ => -1,
                            },
                            'm' => input.AsSpan(3).SequenceEqual("mon") ? /* match 'common' */ 741 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ner") ? /* match 'corner' */ 742 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ton") ? /* match 'cotton' */ 743 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("rse") ? /* match 'course' */ 744 : -1,
                            _ => -1,
                        },
                        'r' => !input.AsSpan(2, 2).SequenceEqual("ea") ? -1 : input[4] switch
                        {
                            's' => input[5] == 'e' ? /* match 'crease' */ 745 : -1,
                            't' => input[5] == 'e' ? /* match 'create' */ 746 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("nger") ? /* match 'danger' */ 747 : -1,
                        'e' => input[2] switch
                        {
                            'c' => input.AsSpan(3).SequenceEqual("ide") ? /* match 'decide' */ 748 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("ree") ? /* match 'degree' */ 749 : -1,
                            'p' => input.AsSpan(3).SequenceEqual("end") ? /* match 'depend' */ 750 : -1,
                            's' => input[3] switch
                            {
                                'e' => input.AsSpan(4).SequenceEqual("rt") ? /* match 'desert' */ 751 : -1,
                                'i' => input.AsSpan(4).SequenceEqual("gn") ? /* match 'design' */ 752 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'f' => input.AsSpan(3).SequenceEqual("fer") ? /* match 'differ' */ 753 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ect") ? /* match 'direct' */ 754 : -1,
                            'v' => input.AsSpan(3).SequenceEqual("ide") ? /* match 'divide' */ 755 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'c' => input.AsSpan(3).SequenceEqual("tor") ? /* match 'doctor' */ 756 : -1,
                            'l' => input.AsSpan(3).SequenceEqual("lar") ? /* match 'dollar' */ 757 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ble") ? /* match 'double' */ 758 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("ring") ? /* match 'during' */ 759 : -1,
                        _ => -1,
                    },
                    'e' => input[1] switch
                    {
                        'f' => input.AsSpan(2).SequenceEqual("fect") ? /* match 'effect' */ 760 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("ther") ? /* match 'either' */ 761 : -1,
                        'n' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("rgy") ? /* match 'energy' */ 762 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("ine") ? /* match 'engine' */ 763 : -1,
                            'o' => input.AsSpan(3).SequenceEqual("ugh") ? /* match 'enough' */ 764 : -1,
                            _ => -1,
                        },
                        'q' => input.AsSpan(2).SequenceEqual("uate") ? /* match 'equate' */ 765 : -1,
                        'x' => input[2] switch
                        {
                            'c' => input[3] switch
                            {
                                'e' => input.AsSpan(4).SequenceEqual("pt") ? /* match 'except' */ 766 : -1,
                                'i' => input.AsSpan(4).SequenceEqual("te") ? /* match 'excite' */ 767 : -1,
                                _ => -1,
                            },
                            'p' => input.AsSpan(3).SequenceEqual("ect") ? /* match 'expect' */ 768 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'f' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'm' => input[3] switch
                            {
                                'i' => input.AsSpan(4).SequenceEqual("ly") ? /* match 'family' */ 769 : -1,
                                'o' => input.AsSpan(4).SequenceEqual("us") ? /* match 'famous' */ 770 : -1,
                                _ => -1,
                            },
                            't' => input.AsSpan(3).SequenceEqual("her") ? /* match 'father' */ 771 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'g' => input.AsSpan(3).SequenceEqual("ure") ? /* match 'figure' */ 772 : -1,
                            'n' => input[3] switch
                            {
                                'g' => input.AsSpan(4).SequenceEqual("er") ? /* match 'finger' */ 773 : -1,
                                'i' => input.AsSpan(4).SequenceEqual("sh") ? /* match 'finish' */ 774 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'l' => input.AsSpan(2).SequenceEqual("ower") ? /* match 'flower' */ 775 : -1,
                        'o' => input[2] switch
                        {
                            'l' => input.AsSpan(3).SequenceEqual("low") ? /* match 'follow' */ 776 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("est") ? /* match 'forest' */ 777 : -1,
                            _ => -1,
                        },
                        'r' => input.AsSpan(2).SequenceEqual("iend") ? /* match 'friend' */ 778 : -1,
                        _ => -1,
                    },
                    'g' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'r' => input.AsSpan(3).SequenceEqual("den") ? /* match 'garden' */ 779 : -1,
                            't' => input.AsSpan(3).SequenceEqual("her") ? /* match 'gather' */ 780 : -1,
                            _ => -1,
                        },
                        'e' => input.AsSpan(2).SequenceEqual("ntle") ? /* match 'gentle' */ 781 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("vern") ? /* match 'govern' */ 782 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("ound") ? /* match 'ground' */ 783 : -1,
                        _ => -1,
                    },
                    'h' => input.AsSpan(1).SequenceEqual("appen") ? /* match 'happen' */ 784 : -1,
                    'i' => input[1] switch
                    {
                        'n' => input[2] switch
                        {
                            's' => input.AsSpan(3).SequenceEqual("ect") ? /* match 'insect' */ 785 : -1,
                            'v' => input.AsSpan(3).SequenceEqual("ent") ? /* match 'invent' */ 786 : -1,
                            _ => -1,
                        },
                        's' => input.AsSpan(2).SequenceEqual("land") ? /* match 'island' */ 787 : -1,
                        _ => -1,
                    },
                    'l' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            'n' => input.AsSpan(3).SequenceEqual("gth") ? /* match 'length' */ 788 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ter") ? /* match 'letter' */ 789 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'q' => input.AsSpan(3).SequenceEqual("uid") ? /* match 'liquid' */ 790 : -1,
                            's' => input.AsSpan(3).SequenceEqual("ten") ? /* match 'listen' */ 791 : -1,
                            't' => input.AsSpan(3).SequenceEqual("tle") ? /* match 'little' */ 792 : -1,
                            _ => -1,
                        },
                        'o' => input.AsSpan(2).SequenceEqual("cate") ? /* match 'locate' */ 793 : -1,
                        _ => -1,
                    },
                    'm' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'g' => input.AsSpan(3).SequenceEqual("net") ? /* match 'magnet' */ 794 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ket") ? /* match 'market' */ 795 : -1,
                            's' => input.AsSpan(3).SequenceEqual("ter") ? /* match 'master' */ 796 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ter") ? /* match 'matter' */ 797 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'l' => input.AsSpan(3).SequenceEqual("ody") ? /* match 'melody' */ 798 : -1,
                            't' => input.AsSpan(3).SequenceEqual("hod") ? /* match 'method' */ 799 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'd' => input.AsSpan(3).SequenceEqual("dle") ? /* match 'middle' */ 800 : -1,
                            'n' => input.AsSpan(3).SequenceEqual("ute") ? /* match 'minute' */ 801 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'd' => input.AsSpan(3).SequenceEqual("ern") ? /* match 'modern' */ 802 : -1,
                            'm' => input.AsSpan(3).SequenceEqual("ent") ? /* match 'moment' */ 803 : -1,
                            't' => input[3] switch
                            {
                                'h' => input.AsSpan(4).SequenceEqual("er") ? /* match 'mother' */ 804 : -1,
                                'i' => input.AsSpan(4).SequenceEqual("on") ? /* match 'motion' */ 805 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'n' => input[1] switch
                    {
                        'a' => input[2] != 't' ? -1 : input[3] switch
                        {
                            'i' => input.AsSpan(4).SequenceEqual("on") ? /* match 'nation' */ 806 : -1,
                            'u' => input.AsSpan(4).SequenceEqual("re") ? /* match 'nature' */ 807 : -1,
                            _ => -1,
                        },
                        'o' => input.AsSpan(2).SequenceEqual("tice") ? /* match 'notice' */ 808 : -1,
                        'u' => input.AsSpan(2).SequenceEqual("mber") ? /* match 'number' */ 809 : -1,
                        _ => -1,
                    },
                    'o' => input[1] switch
                    {
                        'b' => input.AsSpan(2).SequenceEqual("ject") ? /* match 'object' */ 810 : -1,
                        'f' => input.AsSpan(2).SequenceEqual("fice") ? /* match 'office' */ 811 : -1,
                        'x' => input.AsSpan(2).SequenceEqual("ygen") ? /* match 'oxygen' */ 812 : -1,
                        _ => -1,
                    },
                    'p' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("rent") ? /* match 'parent' */ 813 : -1,
                        'e' => input[2] switch
                        {
                            'o' => input.AsSpan(3).SequenceEqual("ple") ? /* match 'people' */ 814 : -1,
                            'r' => input[3] switch
                            {
                                'i' => input.AsSpan(4).SequenceEqual("od") ? /* match 'period' */ 815 : -1,
                                's' => input.AsSpan(4).SequenceEqual("on") ? /* match 'person' */ 816 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'h' => input.AsSpan(2).SequenceEqual("rase") ? /* match 'phrase' */ 817 : -1,
                        'l' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("net") ? /* match 'planet' */ 818 : -1,
                            'e' => input.AsSpan(3).SequenceEqual("ase") ? /* match 'please' */ 819 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ral") ? /* match 'plural' */ 820 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("tty") ? /* match 'pretty' */ 821 : -1,
                            'o' => input.AsSpan(3).SequenceEqual("per") ? /* match 'proper' */ 822 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'r' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("ther") ? /* match 'rather' */ 823 : -1,
                        'e' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("son") ? /* match 'reason' */ 824 : -1,
                            'c' => input.AsSpan(3).SequenceEqual("ord") ? /* match 'record' */ 825 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("ion") ? /* match 'region' */ 826 : -1,
                            'p' => input.AsSpan(3).SequenceEqual("eat") ? /* match 'repeat' */ 827 : -1,
                            's' => input.AsSpan(3).SequenceEqual("ult") ? /* match 'result' */ 828 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    's' => input[1] switch
                    {
                        'c' => input.AsSpan(2).SequenceEqual("hool") ? /* match 'school' */ 829 : -1,
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'r' => input.AsSpan(4).SequenceEqual("ch") ? /* match 'search' */ 830 : -1,
                                's' => input.AsSpan(4).SequenceEqual("on") ? /* match 'season' */ 831 : -1,
                                _ => -1,
                            },
                            'c' => input.AsSpan(3).SequenceEqual("ond") ? /* match 'second' */ 832 : -1,
                            'l' => input.AsSpan(3).SequenceEqual("ect") ? /* match 'select' */ 833 : -1,
                            't' => input.AsSpan(3).SequenceEqual("tle") ? /* match 'settle' */ 834 : -1,
                            _ => -1,
                        },
                        'h' => input.AsSpan(2).SequenceEqual("ould") ? /* match 'should' */ 835 : -1,
                        'i' => input[2] switch
                        {
                            'l' => input[3] switch
                            {
                                'e' => input.AsSpan(4).SequenceEqual("nt") ? /* match 'silent' */ 836 : -1,
                                'v' => input.AsSpan(4).SequenceEqual("er") ? /* match 'silver' */ 837 : -1,
                                _ => -1,
                            },
                            'm' => input.AsSpan(3).SequenceEqual("ple") ? /* match 'simple' */ 838 : -1,
                            'n' => input.AsSpan(3).SequenceEqual("gle") ? /* match 'single' */ 839 : -1,
                            's' => input.AsSpan(3).SequenceEqual("ter") ? /* match 'sister' */ 840 : -1,
                            _ => -1,
                        },
                        'p' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("ech") ? /* match 'speech' */ 841 : -1,
                            'r' => input[3] switch
                            {
                                'e' => input.AsSpan(4).SequenceEqual("ad") ? /* match 'spread' */ 842 : -1,
                                'i' => input.AsSpan(4).SequenceEqual("ng") ? /* match 'spring' */ 843 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'q' => input.AsSpan(2).SequenceEqual("uare") ? /* match 'square' */ 844 : -1,
                        't' => input[2] != 'r' ? -1 : input[3] switch
                        {
                            'e' => input[4] switch
                            {
                                'a' => input[5] == 'm' ? /* match 'stream' */ 845 : -1,
                                'e' => input[5] == 't' ? /* match 'street' */ 846 : -1,
                                _ => -1,
                            },
                            'i' => input.AsSpan(4).SequenceEqual("ng") ? /* match 'string' */ 847 : -1,
                            'o' => input.AsSpan(4).SequenceEqual("ng") ? /* match 'strong' */ 848 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'd' => input.AsSpan(3).SequenceEqual("den") ? /* match 'sudden' */ 849 : -1,
                            'f' => input.AsSpan(3).SequenceEqual("fix") ? /* match 'suffix' */ 850 : -1,
                            'm' => input.AsSpan(3).SequenceEqual("mer") ? /* match 'summer' */ 851 : -1,
                            'p' => input.AsSpan(3).SequenceEqual("ply") ? /* match 'supply' */ 852 : -1,
                            _ => -1,
                        },
                        'y' => input[2] switch
                        {
                            'm' => input.AsSpan(3).SequenceEqual("bol") ? /* match 'symbol' */ 853 : -1,
                            's' => input.AsSpan(3).SequenceEqual("tem") ? /* match 'system' */ 854 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    't' => input[1] switch
                    {
                        'h' => input.AsSpan(2).SequenceEqual("ough") ? /* match 'though' */ 855 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("ward") ? /* match 'toward' */ 856 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("avel") ? /* match 'travel' */ 857 : -1,
                        'w' => input.AsSpan(2).SequenceEqual("enty") ? /* match 'twenty' */ 858 : -1,
                        _ => -1,
                    },
                    'v' => input.AsSpan(1).SequenceEqual("alley") ? /* match 'valley' */ 859 : -1,
                    'w' => input[1] switch
                    {
                        'e' => input.AsSpan(2).SequenceEqual("ight") ? /* match 'weight' */ 860 : -1,
                        'i' => input[2] != 'n' ? -1 : input[3] switch
                        {
                            'd' => input.AsSpan(4).SequenceEqual("ow") ? /* match 'window' */ 861 : -1,
                            't' => input.AsSpan(4).SequenceEqual("er") ? /* match 'winter' */ 862 : -1,
                            _ => -1,
                        },
                        'o' => input.AsSpan(2).SequenceEqual("nder") ? /* match 'wonder' */ 863 : -1,
                        _ => -1,
                    },
                    'y' => input.AsSpan(1).SequenceEqual("ellow") ? /* match 'yellow' */ 864 : -1,
                    _ => -1,
                },
                7 => input[0] switch
                {
                    'a' => input[1] switch
                    {
                        'g' => input.AsSpan(2).SequenceEqual("ainst") ? /* match 'against' */ 865 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("range") ? /* match 'arrange' */ 866 : -1,
                        _ => -1,
                    },
                    'b' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            'l' => input.AsSpan(3).SequenceEqual("ieve") ? /* match 'believe' */ 867 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ween") ? /* match 'between' */ 868 : -1,
                            _ => -1,
                        },
                        'r' => input[2] != 'o' ? -1 : input[3] switch
                        {
                            't' => input.AsSpan(4).SequenceEqual("her") ? /* match 'brother' */ 869 : -1,
                            'u' => input.AsSpan(4).SequenceEqual("ght") ? /* match 'brought' */ 870 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'c' => input[1] switch
                    {
                        'a' => input[2] != 'p' ? -1 : input[3] switch
                        {
                            'i' => input.AsSpan(4).SequenceEqual("tal") ? /* match 'capital' */ 871 : -1,
                            't' => input.AsSpan(4).SequenceEqual("ain") ? /* match 'captain' */ 872 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'n' => input.AsSpan(3).SequenceEqual("tury") ? /* match 'century' */ 873 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("tain") ? /* match 'certain' */ 874 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'l' => input.AsSpan(3).SequenceEqual("lect") ? /* match 'collect' */ 875 : -1,
                            'm' => !input.AsSpan(3, 2).SequenceEqual("pa") ? -1 : input[5] switch
                            {
                                'n' => input[6] == 'y' ? /* match 'company' */ 876 : -1,
                                'r' => input[6] == 'e' ? /* match 'compare' */ 877 : -1,
                                _ => -1,
                            },
                            'n' => input[3] switch
                            {
                                'n' => input.AsSpan(4).SequenceEqual("ect") ? /* match 'connect' */ 878 : -1,
                                't' => input[4] switch
                                {
                                    'a' => input.AsSpan(5).SequenceEqual("in") ? /* match 'contain' */ 879 : -1,
                                    'r' => input.AsSpan(5).SequenceEqual("ol") ? /* match 'control' */ 880 : -1,
                                    _ => -1,
                                },
                                _ => -1,
                            },
                            'r' => input.AsSpan(3).SequenceEqual("rect") ? /* match 'correct' */ 881 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ntry") ? /* match 'country' */ 882 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("rrent") ? /* match 'current' */ 883 : -1,
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            'c' => input.AsSpan(3).SequenceEqual("imal") ? /* match 'decimal' */ 884 : -1,
                            'v' => input.AsSpan(3).SequenceEqual("elop") ? /* match 'develop' */ 885 : -1,
                            _ => -1,
                        },
                        'i' => input[2] != 's' ? -1 : input[3] switch
                        {
                            'c' => input.AsSpan(4).SequenceEqual("uss") ? /* match 'discuss' */ 886 : -1,
                            't' => input.AsSpan(4).SequenceEqual("ant") ? /* match 'distant' */ 887 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'e' => input[1] switch
                    {
                        'l' => input.AsSpan(2).SequenceEqual("ement") ? /* match 'element' */ 888 : -1,
                        'v' => input.AsSpan(2).SequenceEqual("ening") ? /* match 'evening' */ 889 : -1,
                        'x' => input.AsSpan(2).SequenceEqual("ample") ? /* match 'example' */ 890 : -1,
                        _ => -1,
                    },
                    'f' => input.AsSpan(1).SequenceEqual("orward") ? /* match 'forward' */ 891 : -1,
                    'g' => input.AsSpan(1).SequenceEqual("eneral") ? /* match 'general' */ 892 : -1,
                    'h' => input[1] switch
                    {
                        'i' => input.AsSpan(2).SequenceEqual("story") ? /* match 'history' */ 893 : -1,
                        'u' => input.AsSpan(2).SequenceEqual("ndred") ? /* match 'hundred' */ 894 : -1,
                        _ => -1,
                    },
                    'i' => input[1] switch
                    {
                        'm' => input.AsSpan(2).SequenceEqual("agine") ? /* match 'imagine' */ 895 : -1,
                        'n' => input[2] switch
                        {
                            'c' => input.AsSpan(3).SequenceEqual("lude") ? /* match 'include' */ 896 : -1,
                            's' => input.AsSpan(3).SequenceEqual("tant") ? /* match 'instant' */ 897 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'm' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("chine") ? /* match 'machine' */ 898 : -1,
                        'e' => input.AsSpan(2).SequenceEqual("asure") ? /* match 'measure' */ 899 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("llion") ? /* match 'million' */ 900 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("rning") ? /* match 'morning' */ 901 : -1,
                        _ => -1,
                    },
                    'n' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("tural") ? /* match 'natural' */ 902 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("thing") ? /* match 'nothing' */ 903 : -1,
                        'u' => input.AsSpan(2).SequenceEqual("meral") ? /* match 'numeral' */ 904 : -1,
                        _ => -1,
                    },
                    'o' => input[1] switch
                    {
                        'b' => input.AsSpan(2).SequenceEqual("serve") ? /* match 'observe' */ 905 : -1,
                        'p' => input.AsSpan(2).SequenceEqual("erate") ? /* match 'operate' */ 906 : -1,
                        _ => -1,
                    },
                    'p' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("ttern") ? /* match 'pattern' */ 907 : -1,
                        'e' => input.AsSpan(2).SequenceEqual("rhaps") ? /* match 'perhaps' */ 908 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("cture") ? /* match 'picture' */ 909 : -1,
                        'r' => input[2] switch
                        {
                            'e' => input[3] switch
                            {
                                'p' => input.AsSpan(4).SequenceEqual("are") ? /* match 'prepare' */ 910 : -1,
                                's' => input.AsSpan(4).SequenceEqual("ent") ? /* match 'present' */ 911 : -1,
                                _ => -1,
                            },
                            'o' => input[3] switch
                            {
                                'b' => input.AsSpan(4).SequenceEqual("lem") ? /* match 'problem' */ 912 : -1,
                                'c' => input.AsSpan(4).SequenceEqual("ess") ? /* match 'process' */ 913 : -1,
                                'd' => !input.AsSpan(4, 2).SequenceEqual("uc") ? -1 : input[6] switch
                                {
                                    'e' => /* match 'produce' */ 914,
                                    't' => /* match 'product' */ 915,
                                    _ => -1,
                                },
                                't' => input.AsSpan(4).SequenceEqual("ect") ? /* match 'protect' */ 916 : -1,
                                'v' => input.AsSpan(4).SequenceEqual("ide") ? /* match 'provide' */ 917 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'r' => input[1] != 'e' ? -1 : input[2] switch
                    {
                        'c' => input.AsSpan(3).SequenceEqual("eive") ? /* match 'receive' */ 918 : -1,
                        'q' => input.AsSpan(3).SequenceEqual("uire") ? /* match 'require' */ 919 : -1,
                        _ => -1,
                    },
                    's' => input[1] switch
                    {
                        'c' => input.AsSpan(2).SequenceEqual("ience") ? /* match 'science' */ 920 : -1,
                        'e' => input[2] switch
                        {
                            'c' => input.AsSpan(3).SequenceEqual("tion") ? /* match 'section' */ 921 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("ment") ? /* match 'segment' */ 922 : -1,
                            'v' => input.AsSpan(3).SequenceEqual("eral") ? /* match 'several' */ 923 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("milar") ? /* match 'similar' */ 924 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("ldier") ? /* match 'soldier' */ 925 : -1,
                        'p' => input.AsSpan(2).SequenceEqual("ecial") ? /* match 'special' */ 926 : -1,
                        't' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("tion") ? /* match 'station' */ 927 : -1,
                            'r' => input[3] switch
                            {
                                'a' => input.AsSpan(4).SequenceEqual("nge") ? /* match 'strange' */ 928 : -1,
                                'e' => input.AsSpan(4).SequenceEqual("tch") ? /* match 'stretch' */ 929 : -1,
                                _ => -1,
                            },
                            'u' => input.AsSpan(3).SequenceEqual("dent") ? /* match 'student' */ 930 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'b' => input.AsSpan(3).SequenceEqual("ject") ? /* match 'subject' */ 931 : -1,
                            'c' => input.AsSpan(3).SequenceEqual("cess") ? /* match 'success' */ 932 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("gest") ? /* match 'suggest' */ 933 : -1,
                            'p' => input.AsSpan(3).SequenceEqual("port") ? /* match 'support' */ 934 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("face") ? /* match 'surface' */ 935 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    't' => input[1] switch
                    {
                        'h' => input[2] switch
                        {
                            'o' => input.AsSpan(3).SequenceEqual("ught") ? /* match 'thought' */ 936 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ough") ? /* match 'through' */ 937 : -1,
                            _ => -1,
                        },
                        'r' => input.AsSpan(2).SequenceEqual("ouble") ? /* match 'trouble' */ 938 : -1,
                        _ => -1,
                    },
                    'v' => input.AsSpan(1).SequenceEqual("illage") ? /* match 'village' */ 939 : -1,
                    'w' => input[1] switch
                    {
                        'e' => input.AsSpan(2).SequenceEqual("ather") ? /* match 'weather' */ 940 : -1,
                        'h' => input.AsSpan(2).SequenceEqual("ether") ? /* match 'whether' */ 941 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("itten") ? /* match 'written' */ 942 : -1,
                        _ => -1,
                    },
                    _ => -1,
                },
                8 => input[0] switch
                {
                    'c' => input[1] switch
                    {
                        'h' => input.AsSpan(2).SequenceEqual("ildren") ? /* match 'children' */ 943 : -1,
                        'o' => input[2] switch
                        {
                            'm' => input.AsSpan(3).SequenceEqual("plete") ? /* match 'complete' */ 944 : -1,
                            'n' => input[3] switch
                            {
                                's' => input.AsSpan(4).SequenceEqual("ider") ? /* match 'consider' */ 945 : -1,
                                't' => input.AsSpan(4).SequenceEqual("inue") ? /* match 'continue' */ 946 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'e' => input.AsSpan(2).SequenceEqual("scribe") ? /* match 'describe' */ 947 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("vision") ? /* match 'division' */ 948 : -1,
                        _ => -1,
                    },
                    'e' => input[1] switch
                    {
                        'l' => input.AsSpan(2).SequenceEqual("ectric") ? /* match 'electric' */ 949 : -1,
                        'x' => input.AsSpan(2).SequenceEqual("ercise") ? /* match 'exercise' */ 950 : -1,
                        _ => -1,
                    },
                    'f' => input.AsSpan(1).SequenceEqual("raction") ? /* match 'fraction' */ 951 : -1,
                    'i' => input[1] != 'n' ? -1 : input[2] switch
                    {
                        'd' => input[3] switch
                        {
                            'i' => input.AsSpan(4).SequenceEqual("cate") ? /* match 'indicate' */ 952 : -1,
                            'u' => input.AsSpan(4).SequenceEqual("stry") ? /* match 'industry' */ 953 : -1,
                            _ => -1,
                        },
                        't' => input.AsSpan(3).SequenceEqual("erest") ? /* match 'interest' */ 954 : -1,
                        _ => -1,
                    },
                    'l' => input.AsSpan(1).SequenceEqual("anguage") ? /* match 'language' */ 955 : -1,
                    'm' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("terial") ? /* match 'material' */ 956 : -1,
                        'o' => input[2] switch
                        {
                            'l' => input.AsSpan(3).SequenceEqual("ecule") ? /* match 'molecule' */ 957 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ntain") ? /* match 'mountain' */ 958 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("ltiply") ? /* match 'multiply' */ 959 : -1,
                        _ => -1,
                    },
                    'n' => input.AsSpan(1).SequenceEqual("eighbor") ? /* match 'neighbor' */ 960 : -1,
                    'o' => input[1] switch
                    {
                        'p' => input.AsSpan(2).SequenceEqual("posite") ? /* match 'opposite' */ 961 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("iginal") ? /* match 'original' */ 962 : -1,
                        _ => -1,
                    },
                    'p' => input[1] switch
                    {
                        'o' => input[2] switch
                        {
                            'p' => input.AsSpan(3).SequenceEqual("ulate") ? /* match 'populate' */ 963 : -1,
                            's' => input[3] switch
                            {
                                'i' => input.AsSpan(4).SequenceEqual("tion") ? /* match 'position' */ 964 : -1,
                                's' => input.AsSpan(4).SequenceEqual("ible") ? /* match 'possible' */ 965 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("ctice") ? /* match 'practice' */ 966 : -1,
                            'o' => input[3] switch
                            {
                                'b' => input.AsSpan(4).SequenceEqual("able") ? /* match 'probable' */ 967 : -1,
                                'p' => input.AsSpan(4).SequenceEqual("erty") ? /* match 'property' */ 968 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'q' => input[1] != 'u' ? -1 : input[2] switch
                    {
                        'e' => input.AsSpan(3).SequenceEqual("stion") ? /* match 'question' */ 969 : -1,
                        'o' => input.AsSpan(3).SequenceEqual("tient") ? /* match 'quotient' */ 970 : -1,
                        _ => -1,
                    },
                    'r' => input.AsSpan(1).SequenceEqual("emember") ? /* match 'remember' */ 971 : -1,
                    's' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            'n' => input.AsSpan(3).SequenceEqual("tence") ? /* match 'sentence' */ 972 : -1,
                            'p' => input.AsSpan(3).SequenceEqual("arate") ? /* match 'separate' */ 973 : -1,
                            _ => -1,
                        },
                        'h' => input.AsSpan(2).SequenceEqual("oulder") ? /* match 'shoulder' */ 974 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("lution") ? /* match 'solution' */ 975 : -1,
                        't' => input.AsSpan(2).SequenceEqual("raight") ? /* match 'straight' */ 976 : -1,
                        'u' => input[2] switch
                        {
                            'b' => input.AsSpan(3).SequenceEqual("tract") ? /* match 'subtract' */ 977 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("prise") ? /* match 'surprise' */ 978 : -1,
                            _ => -1,
                        },
                        'y' => input.AsSpan(2).SequenceEqual("llable") ? /* match 'syllable' */ 979 : -1,
                        _ => -1,
                    },
                    't' => input[1] switch
                    {
                        'h' => input.AsSpan(2).SequenceEqual("ousand") ? /* match 'thousand' */ 980 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("gether") ? /* match 'together' */ 981 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("iangle") ? /* match 'triangle' */ 982 : -1,
                        _ => -1,
                    },
                    _ => -1,
                },
                9 => input[0] switch
                {
                    'c' => input[1] switch
                    {
                        'h' => input.AsSpan(2).SequenceEqual("aracter") ? /* match 'character' */ 983 : -1,
                        'o' => input[2] != 'n' ? -1 : input[3] switch
                        {
                            'd' => input.AsSpan(4).SequenceEqual("ition") ? /* match 'condition' */ 984 : -1,
                            's' => input.AsSpan(4).SequenceEqual("onant") ? /* match 'consonant' */ 985 : -1,
                            't' => input.AsSpan(4).SequenceEqual("inent") ? /* match 'continent' */ 986 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'e' => input.AsSpan(2).SequenceEqual("termine") ? /* match 'determine' */ 987 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("fficult") ? /* match 'difficult' */ 988 : -1,
                        _ => -1,
                    },
                    'n' => input.AsSpan(1).SequenceEqual("ecessary") ? /* match 'necessary' */ 989 : -1,
                    'p' => input.AsSpan(1).SequenceEqual("aragraph") ? /* match 'paragraph' */ 990 : -1,
                    'r' => input.AsSpan(1).SequenceEqual("epresent") ? /* match 'represent' */ 991 : -1,
                    's' => input.AsSpan(1).SequenceEqual("ubstance") ? /* match 'substance' */ 992 : -1,
                    _ => -1,
                },
                10 => input[0] switch
                {
                    'd' => input.AsSpan(1).SequenceEqual("ictionary") ? /* match 'dictionary' */ 993 : -1,
                    'e' => input[1] switch
                    {
                        's' => input.AsSpan(2).SequenceEqual("pecially") ? /* match 'especially' */ 994 : -1,
                        'x' => !input.AsSpan(2, 4).SequenceEqual("peri") ? -1 : input[6] switch
                        {
                            'e' => input.AsSpan(7).SequenceEqual("nce") ? /* match 'experience' */ 995 : -1,
                            'm' => input.AsSpan(7).SequenceEqual("ent") ? /* match 'experiment' */ 996 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'i' => input.AsSpan(1).SequenceEqual("nstrument") ? /* match 'instrument' */ 997 : -1,
                    'p' => input.AsSpan(1).SequenceEqual("articular") ? /* match 'particular' */ 998 : -1,
                    _ => -1,
                },
                11 => input == "temperature" ? /* match 'temperature' */ 999 : -1,
                _ => -1,
            };
        }
    }

    public static int CyrusTrieWithoutOptimizations()
    {
        foreach (var x in new[] { "hello", "world" })
        {
            M2(x);
        }
        return 0;

        static int M2(string input)
        {
            return input.Length switch
            {
                1 => input[0] switch
                {
                    'I' => /* match 'I' */ 0,
                    'a' => /* match 'a' */ 1,
                    _ => -1,
                },
                2 => input[0] switch
                {
                    'a' => input[1] switch
                    {
                        'm' => /* match 'am' */ 2,
                        'n' => /* match 'an' */ 3,
                        's' => /* match 'as' */ 4,
                        't' => /* match 'at' */ 5,
                        _ => -1,
                    },
                    'b' => input[1] switch
                    {
                        'e' => /* match 'be' */ 6,
                        'y' => /* match 'by' */ 7,
                        _ => -1,
                    },
                    'd' => input[1] == 'o' ? /* match 'do' */ 8 : -1,
                    'g' => input[1] == 'o' ? /* match 'go' */ 9 : -1,
                    'h' => input[1] == 'e' ? /* match 'he' */ 10 : -1,
                    'i' => input[1] switch
                    {
                        'f' => /* match 'if' */ 11,
                        'n' => /* match 'in' */ 12,
                        's' => /* match 'is' */ 13,
                        't' => /* match 'it' */ 14,
                        _ => -1,
                    },
                    'm' => input[1] switch
                    {
                        'e' => /* match 'me' */ 15,
                        'y' => /* match 'my' */ 16,
                        _ => -1,
                    },
                    'n' => input[1] == 'o' ? /* match 'no' */ 17 : -1,
                    'o' => input[1] switch
                    {
                        'f' => /* match 'of' */ 18,
                        'h' => /* match 'oh' */ 19,
                        'n' => /* match 'on' */ 20,
                        'r' => /* match 'or' */ 21,
                        _ => -1,
                    },
                    's' => input[1] == 'o' ? /* match 'so' */ 22 : -1,
                    't' => input[1] == 'o' ? /* match 'to' */ 23 : -1,
                    'u' => input[1] switch
                    {
                        'p' => /* match 'up' */ 24,
                        's' => /* match 'us' */ 25,
                        _ => -1,
                    },
                    'w' => input[1] == 'e' ? /* match 'we' */ 26 : -1,
                    _ => -1,
                },
                3 => input[0] switch
                {
                    'a' => input[1] switch
                    {
                        'c' => input[2] == 't' ? /* match 'act' */ 27 : -1,
                        'd' => input[2] == 'd' ? /* match 'add' */ 28 : -1,
                        'g' => input[2] switch
                        {
                            'e' => /* match 'age' */ 29,
                            'o' => /* match 'ago' */ 30,
                            _ => -1,
                        },
                        'i' => input[2] == 'r' ? /* match 'air' */ 31 : -1,
                        'l' => input[2] == 'l' ? /* match 'all' */ 32 : -1,
                        'n' => input[2] switch
                        {
                            'd' => /* match 'and' */ 33,
                            'y' => /* match 'any' */ 34,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'e' => /* match 'are' */ 35,
                            'm' => /* match 'arm' */ 36,
                            't' => /* match 'art' */ 37,
                            _ => -1,
                        },
                        's' => input[2] == 'k' ? /* match 'ask' */ 38 : -1,
                        _ => -1,
                    },
                    'b' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'd' => /* match 'bad' */ 39,
                            'r' => /* match 'bar' */ 40,
                            't' => /* match 'bat' */ 41,
                            _ => -1,
                        },
                        'e' => input[2] == 'd' ? /* match 'bed' */ 42 : -1,
                        'i' => input[2] switch
                        {
                            'g' => /* match 'big' */ 43,
                            't' => /* match 'bit' */ 44,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'x' => /* match 'box' */ 45,
                            'y' => /* match 'boy' */ 46,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            't' => /* match 'but' */ 47,
                            'y' => /* match 'buy' */ 48,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'c' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'n' => /* match 'can' */ 49,
                            'r' => /* match 'car' */ 50,
                            't' => /* match 'cat' */ 51,
                            _ => -1,
                        },
                        'o' => input[2] == 'w' ? /* match 'cow' */ 52 : -1,
                        'r' => input[2] == 'y' ? /* match 'cry' */ 53 : -1,
                        'u' => input[2] == 't' ? /* match 'cut' */ 54 : -1,
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'd' => /* match 'dad' */ 55,
                            'y' => /* match 'day' */ 56,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'd' => /* match 'did' */ 57,
                            'e' => /* match 'die' */ 58,
                            _ => -1,
                        },
                        'o' => input[2] == 'g' ? /* match 'dog' */ 59 : -1,
                        'r' => input[2] == 'y' ? /* match 'dry' */ 60 : -1,
                        _ => -1,
                    },
                    'e' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'r' => /* match 'ear' */ 61,
                            't' => /* match 'eat' */ 62,
                            _ => -1,
                        },
                        'g' => input[2] == 'g' ? /* match 'egg' */ 63 : -1,
                        'n' => input[2] == 'd' ? /* match 'end' */ 64 : -1,
                        'y' => input[2] == 'e' ? /* match 'eye' */ 65 : -1,
                        _ => -1,
                    },
                    'f' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'r' => /* match 'far' */ 66,
                            't' => /* match 'fat' */ 67,
                            _ => -1,
                        },
                        'e' => input[2] == 'w' ? /* match 'few' */ 68 : -1,
                        'i' => input[2] switch
                        {
                            'g' => /* match 'fig' */ 69,
                            't' => /* match 'fit' */ 70,
                            _ => -1,
                        },
                        'l' => input[2] == 'y' ? /* match 'fly' */ 71 : -1,
                        'o' => input[2] == 'r' ? /* match 'for' */ 72 : -1,
                        'u' => input[2] == 'n' ? /* match 'fun' */ 73 : -1,
                        _ => -1,
                    },
                    'g' => input[1] switch
                    {
                        'a' => input[2] == 's' ? /* match 'gas' */ 74 : -1,
                        'e' => input[2] == 't' ? /* match 'get' */ 75 : -1,
                        'o' => input[2] == 't' ? /* match 'got' */ 76 : -1,
                        'u' => input[2] == 'n' ? /* match 'gun' */ 77 : -1,
                        _ => -1,
                    },
                    'h' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'd' => /* match 'had' */ 78,
                            's' => /* match 'has' */ 79,
                            't' => /* match 'hat' */ 80,
                            _ => -1,
                        },
                        'e' => input[2] == 'r' ? /* match 'her' */ 81 : -1,
                        'i' => input[2] switch
                        {
                            'm' => /* match 'him' */ 82,
                            's' => /* match 'his' */ 83,
                            't' => /* match 'hit' */ 84,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            't' => /* match 'hot' */ 85,
                            'w' => /* match 'how' */ 86,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'i' => input.AsSpan(1).SequenceEqual("ce") ? /* match 'ice' */ 87 : -1,
                    'j' => input[1] != 'o' ? -1 : input[2] switch
                    {
                        'b' => /* match 'job' */ 88,
                        'y' => /* match 'joy' */ 89,
                        _ => -1,
                    },
                    'k' => input.AsSpan(1).SequenceEqual("ey") ? /* match 'key' */ 90 : -1,
                    'l' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'w' => /* match 'law' */ 91,
                            'y' => /* match 'lay' */ 92,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'd' => /* match 'led' */ 93,
                            'g' => /* match 'leg' */ 94,
                            't' => /* match 'let' */ 95,
                            _ => -1,
                        },
                        'i' => input[2] == 'e' ? /* match 'lie' */ 96 : -1,
                        'o' => input[2] switch
                        {
                            'g' => /* match 'log' */ 97,
                            't' => /* match 'lot' */ 98,
                            'w' => /* match 'low' */ 99,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'm' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'n' => /* match 'man' */ 100,
                            'p' => /* match 'map' */ 101,
                            'y' => /* match 'may' */ 102,
                            _ => -1,
                        },
                        'e' => input[2] == 'n' ? /* match 'men' */ 103 : -1,
                        'i' => input[2] == 'x' ? /* match 'mix' */ 104 : -1,
                        _ => -1,
                    },
                    'n' => input[1] switch
                    {
                        'e' => input[2] == 'w' ? /* match 'new' */ 105 : -1,
                        'o' => input[2] switch
                        {
                            'r' => /* match 'nor' */ 106,
                            't' => /* match 'not' */ 107,
                            'w' => /* match 'now' */ 108,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'o' => input[1] switch
                    {
                        'f' => input[2] == 'f' ? /* match 'off' */ 109 : -1,
                        'i' => input[2] == 'l' ? /* match 'oil' */ 110 : -1,
                        'l' => input[2] == 'd' ? /* match 'old' */ 111 : -1,
                        'n' => input[2] == 'e' ? /* match 'one' */ 112 : -1,
                        'u' => input[2] switch
                        {
                            'r' => /* match 'our' */ 113,
                            't' => /* match 'out' */ 114,
                            _ => -1,
                        },
                        'w' => input[2] == 'n' ? /* match 'own' */ 115 : -1,
                        _ => -1,
                    },
                    'p' => input[1] switch
                    {
                        'a' => input[2] == 'y' ? /* match 'pay' */ 116 : -1,
                        'u' => input[2] == 't' ? /* match 'put' */ 117 : -1,
                        _ => -1,
                    },
                    'r' => input[1] switch
                    {
                        'a' => input[2] == 'n' ? /* match 'ran' */ 118 : -1,
                        'e' => input[2] == 'd' ? /* match 'red' */ 119 : -1,
                        'o' => input[2] == 'w' ? /* match 'row' */ 120 : -1,
                        'u' => input[2] switch
                        {
                            'b' => /* match 'rub' */ 121,
                            'n' => /* match 'run' */ 122,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    's' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            't' => /* match 'sat' */ 123,
                            'w' => /* match 'saw' */ 124,
                            'y' => /* match 'say' */ 125,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => /* match 'sea' */ 126,
                            'e' => /* match 'see' */ 127,
                            't' => /* match 'set' */ 128,
                            _ => -1,
                        },
                        'h' => input[2] == 'e' ? /* match 'she' */ 129 : -1,
                        'i' => input[2] switch
                        {
                            't' => /* match 'sit' */ 130,
                            'x' => /* match 'six' */ 131,
                            _ => -1,
                        },
                        'k' => input[2] == 'y' ? /* match 'sky' */ 132 : -1,
                        'o' => input[2] == 'n' ? /* match 'son' */ 133 : -1,
                        'u' => input[2] == 'n' ? /* match 'sun' */ 134 : -1,
                        _ => -1,
                    },
                    't' => input[1] switch
                    {
                        'e' => input[2] == 'n' ? /* match 'ten' */ 135 : -1,
                        'h' => input[2] == 'e' ? /* match 'the' */ 136 : -1,
                        'i' => input[2] == 'e' ? /* match 'tie' */ 137 : -1,
                        'o' => input[2] switch
                        {
                            'o' => /* match 'too' */ 138,
                            'p' => /* match 'top' */ 139,
                            _ => -1,
                        },
                        'r' => input[2] == 'y' ? /* match 'try' */ 140 : -1,
                        'w' => input[2] == 'o' ? /* match 'two' */ 141 : -1,
                        _ => -1,
                    },
                    'u' => input.AsSpan(1).SequenceEqual("se") ? /* match 'use' */ 142 : -1,
                    'w' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'r' => /* match 'war' */ 143,
                            's' => /* match 'was' */ 144,
                            'y' => /* match 'way' */ 145,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'o' => /* match 'who' */ 146,
                            'y' => /* match 'why' */ 147,
                            _ => -1,
                        },
                        'i' => input[2] == 'n' ? /* match 'win' */ 148 : -1,
                        _ => -1,
                    },
                    'y' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            's' => /* match 'yes' */ 149,
                            't' => /* match 'yet' */ 150,
                            _ => -1,
                        },
                        'o' => input[2] == 'u' ? /* match 'you' */ 151 : -1,
                        _ => -1,
                    },
                    _ => -1,
                },
                4 => input[0] switch
                {
                    'a' => input[1] switch
                    {
                        'b' => input.AsSpan(2).SequenceEqual("le") ? /* match 'able' */ 152 : -1,
                        'l' => input.AsSpan(2).SequenceEqual("so") ? /* match 'also' */ 153 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("ea") ? /* match 'area' */ 154 : -1,
                        't' => input.AsSpan(2).SequenceEqual("om") ? /* match 'atom' */ 155 : -1,
                        _ => -1,
                    },
                    'b' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'b' => input[3] == 'y' ? /* match 'baby' */ 156 : -1,
                            'c' => input[3] == 'k' ? /* match 'back' */ 157 : -1,
                            'l' => input[3] == 'l' ? /* match 'ball' */ 158 : -1,
                            'n' => input[3] switch
                            {
                                'd' => /* match 'band' */ 159,
                                'k' => /* match 'bank' */ 160,
                                _ => -1,
                            },
                            's' => input[3] == 'e' ? /* match 'base' */ 161 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'r' => /* match 'bear' */ 162,
                                't' => /* match 'beat' */ 163,
                                _ => -1,
                            },
                            'e' => input[3] == 'n' ? /* match 'been' */ 164 : -1,
                            'l' => input[3] == 'l' ? /* match 'bell' */ 165 : -1,
                            's' => input[3] == 't' ? /* match 'best' */ 166 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("rd") ? /* match 'bird' */ 167 : -1,
                        'l' => input[2] switch
                        {
                            'o' => input[3] == 'w' ? /* match 'blow' */ 168 : -1,
                            'u' => input[3] == 'e' ? /* match 'blue' */ 169 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'a' => input[3] == 't' ? /* match 'boat' */ 170 : -1,
                            'd' => input[3] == 'y' ? /* match 'body' */ 171 : -1,
                            'n' => input[3] == 'e' ? /* match 'bone' */ 172 : -1,
                            'o' => input[3] == 'k' ? /* match 'book' */ 173 : -1,
                            'r' => input[3] == 'n' ? /* match 'born' */ 174 : -1,
                            't' => input[3] == 'h' ? /* match 'both' */ 175 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'r' => input[3] == 'n' ? /* match 'burn' */ 176 : -1,
                            's' => input[3] == 'y' ? /* match 'busy' */ 177 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'c' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'l' => input[3] == 'l' ? /* match 'call' */ 178 : -1,
                            'm' => input[3] switch
                            {
                                'e' => /* match 'came' */ 179,
                                'p' => /* match 'camp' */ 180,
                                _ => -1,
                            },
                            'r' => input[3] switch
                            {
                                'd' => /* match 'card' */ 181,
                                'e' => /* match 'care' */ 182,
                                _ => -1,
                            },
                            's' => input[3] == 'e' ? /* match 'case' */ 183 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'l' => input[3] == 'l' ? /* match 'cell' */ 184 : -1,
                            'n' => input[3] == 't' ? /* match 'cent' */ 185 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ty") ? /* match 'city' */ 186 : -1,
                        'o' => input[2] switch
                        {
                            'a' => input[3] == 't' ? /* match 'coat' */ 187 : -1,
                            'l' => input[3] == 'd' ? /* match 'cold' */ 188 : -1,
                            'm' => input[3] == 'e' ? /* match 'come' */ 189 : -1,
                            'o' => input[3] switch
                            {
                                'k' => /* match 'cook' */ 190,
                                'l' => /* match 'cool' */ 191,
                                _ => -1,
                            },
                            'p' => input[3] == 'y' ? /* match 'copy' */ 192 : -1,
                            'r' => input[3] == 'n' ? /* match 'corn' */ 193 : -1,
                            's' => input[3] == 't' ? /* match 'cost' */ 194 : -1,
                            _ => -1,
                        },
                        'r' => input.AsSpan(2).SequenceEqual("op") ? /* match 'crop' */ 195 : -1,
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("rk") ? /* match 'dark' */ 196 : -1,
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'd' => /* match 'dead' */ 197,
                                'l' => /* match 'deal' */ 198,
                                'r' => /* match 'dear' */ 199,
                                _ => -1,
                            },
                            'e' => input[3] == 'p' ? /* match 'deep' */ 200 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'e' => input[3] == 's' ? /* match 'does' */ 201 : -1,
                            'n' => input[3] == 'e' ? /* match 'done' */ 202 : -1,
                            'o' => input[3] == 'r' ? /* match 'door' */ 203 : -1,
                            'w' => input[3] == 'n' ? /* match 'down' */ 204 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'a' => input[3] == 'w' ? /* match 'draw' */ 205 : -1,
                            'o' => input[3] == 'p' ? /* match 'drop' */ 206 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("ck") ? /* match 'duck' */ 207 : -1,
                        _ => -1,
                    },
                    'e' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'c' => input[3] == 'h' ? /* match 'each' */ 208 : -1,
                            's' => input[3] switch
                            {
                                'e' => /* match 'ease' */ 209,
                                't' => /* match 'east' */ 210,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'd' => input.AsSpan(2).SequenceEqual("ge") ? /* match 'edge' */ 211 : -1,
                        'l' => input.AsSpan(2).SequenceEqual("se") ? /* match 'else' */ 212 : -1,
                        'v' => input[2] != 'e' ? -1 : input[3] switch
                        {
                            'n' => /* match 'even' */ 213,
                            'r' => /* match 'ever' */ 214,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'f' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'c' => input[3] switch
                            {
                                'e' => /* match 'face' */ 215,
                                't' => /* match 'fact' */ 216,
                                _ => -1,
                            },
                            'i' => input[3] == 'r' ? /* match 'fair' */ 217 : -1,
                            'l' => input[3] == 'l' ? /* match 'fall' */ 218 : -1,
                            'r' => input[3] == 'm' ? /* match 'farm' */ 219 : -1,
                            's' => input[3] == 't' ? /* match 'fast' */ 220 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] == 'r' ? /* match 'fear' */ 221 : -1,
                            'e' => input[3] switch
                            {
                                'd' => /* match 'feed' */ 222,
                                'l' => /* match 'feel' */ 223,
                                't' => /* match 'feet' */ 224,
                                _ => -1,
                            },
                            'l' => input[3] switch
                            {
                                'l' => /* match 'fell' */ 225,
                                't' => /* match 'felt' */ 226,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'l' => input[3] == 'l' ? /* match 'fill' */ 227 : -1,
                            'n' => input[3] switch
                            {
                                'd' => /* match 'find' */ 228,
                                'e' => /* match 'fine' */ 229,
                                _ => -1,
                            },
                            'r' => input[3] == 'e' ? /* match 'fire' */ 230 : -1,
                            's' => input[3] == 'h' ? /* match 'fish' */ 231 : -1,
                            'v' => input[3] == 'e' ? /* match 'five' */ 232 : -1,
                            _ => -1,
                        },
                        'l' => input[2] switch
                        {
                            'a' => input[3] == 't' ? /* match 'flat' */ 233 : -1,
                            'o' => input[3] == 'w' ? /* match 'flow' */ 234 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'o' => input[3] switch
                            {
                                'd' => /* match 'food' */ 235,
                                't' => /* match 'foot' */ 236,
                                _ => -1,
                            },
                            'r' => input[3] == 'm' ? /* match 'form' */ 237 : -1,
                            'u' => input[3] == 'r' ? /* match 'four' */ 238 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'e' => input[3] == 'e' ? /* match 'free' */ 239 : -1,
                            'o' => input[3] == 'm' ? /* match 'from' */ 240 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("ll") ? /* match 'full' */ 241 : -1,
                        _ => -1,
                    },
                    'g' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'm' => input[3] == 'e' ? /* match 'game' */ 242 : -1,
                            'v' => input[3] == 'e' ? /* match 'gave' */ 243 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'r' => input[3] == 'l' ? /* match 'girl' */ 244 : -1,
                            'v' => input[3] == 'e' ? /* match 'give' */ 245 : -1,
                            _ => -1,
                        },
                        'l' => input.AsSpan(2).SequenceEqual("ad") ? /* match 'glad' */ 246 : -1,
                        'o' => input[2] switch
                        {
                            'l' => input[3] == 'd' ? /* match 'gold' */ 247 : -1,
                            'n' => input[3] == 'e' ? /* match 'gone' */ 248 : -1,
                            'o' => input[3] == 'd' ? /* match 'good' */ 249 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'a' => input[3] == 'y' ? /* match 'gray' */ 250 : -1,
                            'e' => input[3] == 'w' ? /* match 'grew' */ 251 : -1,
                            'o' => input[3] == 'w' ? /* match 'grow' */ 252 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'h' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'i' => input[3] == 'r' ? /* match 'hair' */ 253 : -1,
                            'l' => input[3] == 'f' ? /* match 'half' */ 254 : -1,
                            'n' => input[3] == 'd' ? /* match 'hand' */ 255 : -1,
                            'r' => input[3] == 'd' ? /* match 'hard' */ 256 : -1,
                            'v' => input[3] == 'e' ? /* match 'have' */ 257 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'd' => /* match 'head' */ 258,
                                'r' => /* match 'hear' */ 259,
                                't' => /* match 'heat' */ 260,
                                _ => -1,
                            },
                            'l' => input[3] switch
                            {
                                'd' => /* match 'held' */ 261,
                                'p' => /* match 'help' */ 262,
                                _ => -1,
                            },
                            'r' => input[3] == 'e' ? /* match 'here' */ 263 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'g' => input[3] == 'h' ? /* match 'high' */ 264 : -1,
                            'l' => input[3] == 'l' ? /* match 'hill' */ 265 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'l' => input[3] switch
                            {
                                'd' => /* match 'hold' */ 266,
                                'e' => /* match 'hole' */ 267,
                                _ => -1,
                            },
                            'm' => input[3] == 'e' ? /* match 'home' */ 268 : -1,
                            'p' => input[3] == 'e' ? /* match 'hope' */ 269 : -1,
                            'u' => input[3] == 'r' ? /* match 'hour' */ 270 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'g' => input[3] == 'e' ? /* match 'huge' */ 271 : -1,
                            'n' => input[3] == 't' ? /* match 'hunt' */ 272 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'i' => input[1] switch
                    {
                        'd' => input.AsSpan(2).SequenceEqual("ea") ? /* match 'idea' */ 273 : -1,
                        'n' => input.AsSpan(2).SequenceEqual("ch") ? /* match 'inch' */ 274 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("on") ? /* match 'iron' */ 275 : -1,
                        _ => -1,
                    },
                    'j' => input[1] switch
                    {
                        'o' => input.AsSpan(2).SequenceEqual("in") ? /* match 'join' */ 276 : -1,
                        'u' => input[2] switch
                        {
                            'm' => input[3] == 'p' ? /* match 'jump' */ 277 : -1,
                            's' => input[3] == 't' ? /* match 'just' */ 278 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'k' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            'e' => input[3] == 'p' ? /* match 'keep' */ 279 : -1,
                            'p' => input[3] == 't' ? /* match 'kept' */ 280 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'l' => input[3] == 'l' ? /* match 'kill' */ 281 : -1,
                            'n' => input[3] switch
                            {
                                'd' => /* match 'kind' */ 282,
                                'g' => /* match 'king' */ 283,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'n' => input[2] switch
                        {
                            'e' => input[3] == 'w' ? /* match 'knew' */ 284 : -1,
                            'o' => input[3] == 'w' ? /* match 'know' */ 285 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'l' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'd' => input[3] == 'y' ? /* match 'lady' */ 286 : -1,
                            'k' => input[3] == 'e' ? /* match 'lake' */ 287 : -1,
                            'n' => input[3] == 'd' ? /* match 'land' */ 288 : -1,
                            's' => input[3] == 't' ? /* match 'last' */ 289 : -1,
                            't' => input[3] == 'e' ? /* match 'late' */ 290 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] == 'd' ? /* match 'lead' */ 291 : -1,
                            'f' => input[3] == 't' ? /* match 'left' */ 292 : -1,
                            's' => input[3] == 's' ? /* match 'less' */ 293 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'f' => input[3] switch
                            {
                                'e' => /* match 'life' */ 294,
                                't' => /* match 'lift' */ 295,
                                _ => -1,
                            },
                            'k' => input[3] == 'e' ? /* match 'like' */ 296 : -1,
                            'n' => input[3] == 'e' ? /* match 'line' */ 297 : -1,
                            's' => input[3] == 't' ? /* match 'list' */ 298 : -1,
                            'v' => input[3] == 'e' ? /* match 'live' */ 299 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'n' => input[3] switch
                            {
                                'e' => /* match 'lone' */ 300,
                                'g' => /* match 'long' */ 301,
                                _ => -1,
                            },
                            'o' => input[3] == 'k' ? /* match 'look' */ 302 : -1,
                            's' => input[3] == 't' ? /* match 'lost' */ 303 : -1,
                            'u' => input[3] == 'd' ? /* match 'loud' */ 304 : -1,
                            'v' => input[3] == 'e' ? /* match 'love' */ 305 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'm' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'd' => input[3] == 'e' ? /* match 'made' */ 306 : -1,
                            'i' => input[3] == 'n' ? /* match 'main' */ 307 : -1,
                            'k' => input[3] == 'e' ? /* match 'make' */ 308 : -1,
                            'n' => input[3] == 'y' ? /* match 'many' */ 309 : -1,
                            'r' => input[3] == 'k' ? /* match 'mark' */ 310 : -1,
                            's' => input[3] == 's' ? /* match 'mass' */ 311 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'n' => /* match 'mean' */ 312,
                                't' => /* match 'meat' */ 313,
                                _ => -1,
                            },
                            'e' => input[3] == 't' ? /* match 'meet' */ 314 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'l' => input[3] switch
                            {
                                'e' => /* match 'mile' */ 315,
                                'k' => /* match 'milk' */ 316,
                                _ => -1,
                            },
                            'n' => input[3] switch
                            {
                                'd' => /* match 'mind' */ 317,
                                'e' => /* match 'mine' */ 318,
                                _ => -1,
                            },
                            's' => input[3] == 's' ? /* match 'miss' */ 319 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'o' => input[3] == 'n' ? /* match 'moon' */ 320 : -1,
                            'r' => input[3] == 'e' ? /* match 'more' */ 321 : -1,
                            's' => input[3] == 't' ? /* match 'most' */ 322 : -1,
                            'v' => input[3] == 'e' ? /* match 'move' */ 323 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'c' => input[3] == 'h' ? /* match 'much' */ 324 : -1,
                            's' => input[3] == 't' ? /* match 'must' */ 325 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'n' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("me") ? /* match 'name' */ 326 : -1,
                        'e' => input[2] switch
                        {
                            'a' => input[3] == 'r' ? /* match 'near' */ 327 : -1,
                            'c' => input[3] == 'k' ? /* match 'neck' */ 328 : -1,
                            'e' => input[3] == 'd' ? /* match 'need' */ 329 : -1,
                            'x' => input[3] == 't' ? /* match 'next' */ 330 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ne") ? /* match 'nine' */ 331 : -1,
                        'o' => input[2] switch
                        {
                            'o' => input[3] == 'n' ? /* match 'noon' */ 332 : -1,
                            's' => input[3] == 'e' ? /* match 'nose' */ 333 : -1,
                            't' => input[3] == 'e' ? /* match 'note' */ 334 : -1,
                            'u' => input[3] == 'n' ? /* match 'noun' */ 335 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'o' => input[1] switch
                    {
                        'n' => input[2] switch
                        {
                            'c' => input[3] == 'e' ? /* match 'once' */ 336 : -1,
                            'l' => input[3] == 'y' ? /* match 'only' */ 337 : -1,
                            _ => -1,
                        },
                        'p' => input.AsSpan(2).SequenceEqual("en") ? /* match 'open' */ 338 : -1,
                        'v' => input.AsSpan(2).SequenceEqual("er") ? /* match 'over' */ 339 : -1,
                        _ => -1,
                    },
                    'p' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'g' => input[3] == 'e' ? /* match 'page' */ 340 : -1,
                            'i' => input[3] == 'r' ? /* match 'pair' */ 341 : -1,
                            'r' => input[3] == 't' ? /* match 'part' */ 342 : -1,
                            's' => input[3] switch
                            {
                                's' => /* match 'pass' */ 343,
                                't' => /* match 'past' */ 344,
                                _ => -1,
                            },
                            't' => input[3] == 'h' ? /* match 'path' */ 345 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ck") ? /* match 'pick' */ 346 : -1,
                        'l' => input[2] != 'a' ? -1 : input[3] switch
                        {
                            'n' => /* match 'plan' */ 347,
                            'y' => /* match 'play' */ 348,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'e' => input[3] == 'm' ? /* match 'poem' */ 349 : -1,
                            'o' => input[3] == 'r' ? /* match 'poor' */ 350 : -1,
                            'r' => input[3] == 't' ? /* match 'port' */ 351 : -1,
                            's' => input[3] switch
                            {
                                'e' => /* match 'pose' */ 352,
                                't' => /* match 'post' */ 353,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'l' => input[3] == 'l' ? /* match 'pull' */ 354 : -1,
                            's' => input[3] == 'h' ? /* match 'push' */ 355 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'r' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'c' => input[3] == 'e' ? /* match 'race' */ 356 : -1,
                            'i' => input[3] switch
                            {
                                'l' => /* match 'rail' */ 357,
                                'n' => /* match 'rain' */ 358,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'd' => /* match 'read' */ 359,
                                'l' => /* match 'real' */ 360,
                                _ => -1,
                            },
                            's' => input[3] == 't' ? /* match 'rest' */ 361 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'c' => input[3] == 'h' ? /* match 'rich' */ 362 : -1,
                            'd' => input[3] == 'e' ? /* match 'ride' */ 363 : -1,
                            'n' => input[3] == 'g' ? /* match 'ring' */ 364 : -1,
                            's' => input[3] == 'e' ? /* match 'rise' */ 365 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'a' => input[3] == 'd' ? /* match 'road' */ 366 : -1,
                            'c' => input[3] == 'k' ? /* match 'rock' */ 367 : -1,
                            'l' => input[3] == 'l' ? /* match 'roll' */ 368 : -1,
                            'o' => input[3] switch
                            {
                                'm' => /* match 'room' */ 369,
                                't' => /* match 'root' */ 370,
                                _ => -1,
                            },
                            'p' => input[3] == 'e' ? /* match 'rope' */ 371 : -1,
                            's' => input[3] == 'e' ? /* match 'rose' */ 372 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("le") ? /* match 'rule' */ 373 : -1,
                        _ => -1,
                    },
                    's' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'f' => input[3] == 'e' ? /* match 'safe' */ 374 : -1,
                            'i' => input[3] switch
                            {
                                'd' => /* match 'said' */ 375,
                                'l' => /* match 'sail' */ 376,
                                _ => -1,
                            },
                            'l' => input[3] == 't' ? /* match 'salt' */ 377 : -1,
                            'm' => input[3] == 'e' ? /* match 'same' */ 378 : -1,
                            'n' => input[3] == 'd' ? /* match 'sand' */ 379 : -1,
                            'v' => input[3] == 'e' ? /* match 'save' */ 380 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] == 't' ? /* match 'seat' */ 381 : -1,
                            'e' => input[3] switch
                            {
                                'd' => /* match 'seed' */ 382,
                                'm' => /* match 'seem' */ 383,
                                _ => -1,
                            },
                            'l' => input[3] switch
                            {
                                'f' => /* match 'self' */ 384,
                                'l' => /* match 'sell' */ 385,
                                _ => -1,
                            },
                            'n' => input[3] switch
                            {
                                'd' => /* match 'send' */ 386,
                                't' => /* match 'sent' */ 387,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'i' => input[3] == 'p' ? /* match 'ship' */ 388 : -1,
                            'o' => input[3] switch
                            {
                                'e' => /* match 'shoe' */ 389,
                                'p' => /* match 'shop' */ 390,
                                'w' => /* match 'show' */ 391,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'd' => input[3] == 'e' ? /* match 'side' */ 392 : -1,
                            'g' => input[3] == 'n' ? /* match 'sign' */ 393 : -1,
                            'n' => input[3] == 'g' ? /* match 'sing' */ 394 : -1,
                            'z' => input[3] == 'e' ? /* match 'size' */ 395 : -1,
                            _ => -1,
                        },
                        'k' => input.AsSpan(2).SequenceEqual("in") ? /* match 'skin' */ 396 : -1,
                        'l' => input[2] switch
                        {
                            'i' => input[3] == 'p' ? /* match 'slip' */ 397 : -1,
                            'o' => input[3] == 'w' ? /* match 'slow' */ 398 : -1,
                            _ => -1,
                        },
                        'n' => input.AsSpan(2).SequenceEqual("ow") ? /* match 'snow' */ 399 : -1,
                        'o' => input[2] switch
                        {
                            'f' => input[3] == 't' ? /* match 'soft' */ 400 : -1,
                            'i' => input[3] == 'l' ? /* match 'soil' */ 401 : -1,
                            'm' => input[3] == 'e' ? /* match 'some' */ 402 : -1,
                            'n' => input[3] == 'g' ? /* match 'song' */ 403 : -1,
                            'o' => input[3] == 'n' ? /* match 'soon' */ 404 : -1,
                            _ => -1,
                        },
                        'p' => input.AsSpan(2).SequenceEqual("ot") ? /* match 'spot' */ 405 : -1,
                        't' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'r' => /* match 'star' */ 406,
                                'y' => /* match 'stay' */ 407,
                                _ => -1,
                            },
                            'e' => input[3] == 'p' ? /* match 'step' */ 408 : -1,
                            'o' => input[3] == 'p' ? /* match 'stop' */ 409 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'c' => input[3] == 'h' ? /* match 'such' */ 410 : -1,
                            'i' => input[3] == 't' ? /* match 'suit' */ 411 : -1,
                            'r' => input[3] == 'e' ? /* match 'sure' */ 412 : -1,
                            _ => -1,
                        },
                        'w' => input.AsSpan(2).SequenceEqual("im") ? /* match 'swim' */ 413 : -1,
                        _ => -1,
                    },
                    't' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'i' => input[3] == 'l' ? /* match 'tail' */ 414 : -1,
                            'k' => input[3] == 'e' ? /* match 'take' */ 415 : -1,
                            'l' => input[3] switch
                            {
                                'k' => /* match 'talk' */ 416,
                                'l' => /* match 'tall' */ 417,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] == 'm' ? /* match 'team' */ 418 : -1,
                            'l' => input[3] == 'l' ? /* match 'tell' */ 419 : -1,
                            'r' => input[3] == 'm' ? /* match 'term' */ 420 : -1,
                            's' => input[3] == 't' ? /* match 'test' */ 421 : -1,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'n' => /* match 'than' */ 422,
                                't' => /* match 'that' */ 423,
                                _ => -1,
                            },
                            'e' => input[3] switch
                            {
                                'm' => /* match 'them' */ 424,
                                'n' => /* match 'then' */ 425,
                                'y' => /* match 'they' */ 426,
                                _ => -1,
                            },
                            'i' => input[3] switch
                            {
                                'n' => /* match 'thin' */ 427,
                                's' => /* match 'this' */ 428,
                                _ => -1,
                            },
                            'u' => input[3] == 's' ? /* match 'thus' */ 429 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'm' => input[3] == 'e' ? /* match 'time' */ 430 : -1,
                            'n' => input[3] == 'y' ? /* match 'tiny' */ 431 : -1,
                            'r' => input[3] == 'e' ? /* match 'tire' */ 432 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'l' => input[3] == 'd' ? /* match 'told' */ 433 : -1,
                            'n' => input[3] == 'e' ? /* match 'tone' */ 434 : -1,
                            'o' => input[3] switch
                            {
                                'k' => /* match 'took' */ 435,
                                'l' => /* match 'tool' */ 436,
                                _ => -1,
                            },
                            'w' => input[3] == 'n' ? /* match 'town' */ 437 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'e' => input[3] == 'e' ? /* match 'tree' */ 438 : -1,
                            'i' => input[3] == 'p' ? /* match 'trip' */ 439 : -1,
                            'u' => input[3] == 'e' ? /* match 'true' */ 440 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'b' => input[3] == 'e' ? /* match 'tube' */ 441 : -1,
                            'r' => input[3] == 'n' ? /* match 'turn' */ 442 : -1,
                            _ => -1,
                        },
                        'y' => input.AsSpan(2).SequenceEqual("pe") ? /* match 'type' */ 443 : -1,
                        _ => -1,
                    },
                    'u' => input.AsSpan(1).SequenceEqual("nit") ? /* match 'unit' */ 444 : -1,
                    'v' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("ry") ? /* match 'vary' */ 445 : -1,
                        'e' => input[2] != 'r' ? -1 : input[3] switch
                        {
                            'b' => /* match 'verb' */ 446,
                            'y' => /* match 'very' */ 447,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ew") ? /* match 'view' */ 448 : -1,
                        _ => -1,
                    },
                    'w' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'i' => input[3] == 't' ? /* match 'wait' */ 449 : -1,
                            'l' => input[3] switch
                            {
                                'k' => /* match 'walk' */ 450,
                                'l' => /* match 'wall' */ 451,
                                _ => -1,
                            },
                            'n' => input[3] == 't' ? /* match 'want' */ 452 : -1,
                            'r' => input[3] == 'm' ? /* match 'warm' */ 453 : -1,
                            's' => input[3] == 'h' ? /* match 'wash' */ 454 : -1,
                            'v' => input[3] == 'e' ? /* match 'wave' */ 455 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] == 'r' ? /* match 'wear' */ 456 : -1,
                            'e' => input[3] == 'k' ? /* match 'week' */ 457 : -1,
                            'l' => input[3] == 'l' ? /* match 'well' */ 458 : -1,
                            'n' => input[3] == 't' ? /* match 'went' */ 459 : -1,
                            'r' => input[3] == 'e' ? /* match 'were' */ 460 : -1,
                            's' => input[3] == 't' ? /* match 'west' */ 461 : -1,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'a' => input[3] == 't' ? /* match 'what' */ 462 : -1,
                            'e' => input[3] == 'n' ? /* match 'when' */ 463 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'd' => input[3] == 'e' ? /* match 'wide' */ 464 : -1,
                            'f' => input[3] == 'e' ? /* match 'wife' */ 465 : -1,
                            'l' => input[3] switch
                            {
                                'd' => /* match 'wild' */ 466,
                                'l' => /* match 'will' */ 467,
                                _ => -1,
                            },
                            'n' => input[3] switch
                            {
                                'd' => /* match 'wind' */ 468,
                                'g' => /* match 'wing' */ 469,
                                _ => -1,
                            },
                            'r' => input[3] == 'e' ? /* match 'wire' */ 470 : -1,
                            's' => input[3] == 'h' ? /* match 'wish' */ 471 : -1,
                            't' => input[3] == 'h' ? /* match 'with' */ 472 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'o' => input[3] == 'd' ? /* match 'wood' */ 473 : -1,
                            'r' => input[3] switch
                            {
                                'd' => /* match 'word' */ 474,
                                'k' => /* match 'work' */ 475,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'y' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("rd") ? /* match 'yard' */ 476 : -1,
                        'e' => input.AsSpan(2).SequenceEqual("ar") ? /* match 'year' */ 477 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("ur") ? /* match 'your' */ 478 : -1,
                        _ => -1,
                    },
                    _ => -1,
                },
                5 => input[0] switch
                {
                    'a' => input[1] switch
                    {
                        'b' => input[2] != 'o' ? -1 : input[3] switch
                        {
                            'u' => input[4] == 't' ? /* match 'about' */ 479 : -1,
                            'v' => input[4] == 'e' ? /* match 'above' */ 480 : -1,
                            _ => -1,
                        },
                        'f' => input.AsSpan(2).SequenceEqual("ter") ? /* match 'after' */ 481 : -1,
                        'g' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("in") ? /* match 'again' */ 482 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ee") ? /* match 'agree' */ 483 : -1,
                            _ => -1,
                        },
                        'l' => input.AsSpan(2).SequenceEqual("low") ? /* match 'allow' */ 484 : -1,
                        'm' => input.AsSpan(2).SequenceEqual("ong") ? /* match 'among' */ 485 : -1,
                        'n' => input.AsSpan(2).SequenceEqual("ger") ? /* match 'anger' */ 486 : -1,
                        'p' => input.AsSpan(2).SequenceEqual("ple") ? /* match 'apple' */ 487 : -1,
                        _ => -1,
                    },
                    'b' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("sic") ? /* match 'basic' */ 488 : -1,
                        'e' => input[2] != 'g' ? -1 : input[3] switch
                        {
                            'a' => input[4] == 'n' ? /* match 'began' */ 489 : -1,
                            'i' => input[4] == 'n' ? /* match 'begin' */ 490 : -1,
                            _ => -1,
                        },
                        'l' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("ck") ? /* match 'black' */ 491 : -1,
                            'o' => input[3] switch
                            {
                                'c' => input[4] == 'k' ? /* match 'block' */ 492 : -1,
                                'o' => input[4] == 'd' ? /* match 'blood' */ 493 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'o' => input.AsSpan(2).SequenceEqual("ard") ? /* match 'board' */ 494 : -1,
                        'r' => input[2] switch
                        {
                            'e' => input[3] != 'a' ? -1 : input[4] switch
                            {
                                'd' => /* match 'bread' */ 495,
                                'k' => /* match 'break' */ 496,
                                _ => -1,
                            },
                            'i' => input.AsSpan(3).SequenceEqual("ng") ? /* match 'bring' */ 497 : -1,
                            'o' => input[3] switch
                            {
                                'a' => input[4] == 'd' ? /* match 'broad' */ 498 : -1,
                                'k' => input[4] == 'e' ? /* match 'broke' */ 499 : -1,
                                'w' => input[4] == 'n' ? /* match 'brown' */ 500 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("ild") ? /* match 'build' */ 501 : -1,
                        _ => -1,
                    },
                    'c' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'r' => input.AsSpan(3).SequenceEqual("ry") ? /* match 'carry' */ 502 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ch") ? /* match 'catch' */ 503 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("se") ? /* match 'cause' */ 504 : -1,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'i' => input[4] == 'r' ? /* match 'chair' */ 505 : -1,
                                'r' => input[4] == 't' ? /* match 'chart' */ 506 : -1,
                                _ => -1,
                            },
                            'e' => input.AsSpan(3).SequenceEqual("ck") ? /* match 'check' */ 507 : -1,
                            'i' => input[3] switch
                            {
                                'c' => input[4] == 'k' ? /* match 'chick' */ 508 : -1,
                                'e' => input[4] == 'f' ? /* match 'chief' */ 509 : -1,
                                'l' => input[4] == 'd' ? /* match 'child' */ 510 : -1,
                                _ => -1,
                            },
                            'o' => input.AsSpan(3).SequenceEqual("rd") ? /* match 'chord' */ 511 : -1,
                            _ => -1,
                        },
                        'l' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'i' => input[4] == 'm' ? /* match 'claim' */ 512 : -1,
                                's' => input[4] == 's' ? /* match 'class' */ 513 : -1,
                                _ => -1,
                            },
                            'e' => input[3] != 'a' ? -1 : input[4] switch
                            {
                                'n' => /* match 'clean' */ 514,
                                'r' => /* match 'clear' */ 515,
                                _ => -1,
                            },
                            'i' => input.AsSpan(3).SequenceEqual("mb") ? /* match 'climb' */ 516 : -1,
                            'o' => input[3] switch
                            {
                                'c' => input[4] == 'k' ? /* match 'clock' */ 517 : -1,
                                's' => input[4] == 'e' ? /* match 'close' */ 518 : -1,
                                'u' => input[4] == 'd' ? /* match 'cloud' */ 519 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("st") ? /* match 'coast' */ 520 : -1,
                            'l' => input.AsSpan(3).SequenceEqual("or") ? /* match 'color' */ 521 : -1,
                            'u' => input[3] switch
                            {
                                'l' => input[4] == 'd' ? /* match 'could' */ 522 : -1,
                                'n' => input[4] == 't' ? /* match 'count' */ 523 : -1,
                                _ => -1,
                            },
                            'v' => input.AsSpan(3).SequenceEqual("er") ? /* match 'cover' */ 524 : -1,
                            _ => -1,
                        },
                        'r' => input[2] != 'o' ? -1 : input[3] switch
                        {
                            's' => input[4] == 's' ? /* match 'cross' */ 525 : -1,
                            'w' => input[4] == 'd' ? /* match 'crowd' */ 526 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("nce") ? /* match 'dance' */ 527 : -1,
                        'e' => input.AsSpan(2).SequenceEqual("ath") ? /* match 'death' */ 528 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("n't") ? /* match 'don't' */ 529 : -1,
                        'r' => input[2] switch
                        {
                            'e' => input[3] switch
                            {
                                'a' => input[4] == 'm' ? /* match 'dream' */ 530 : -1,
                                's' => input[4] == 's' ? /* match 'dress' */ 531 : -1,
                                _ => -1,
                            },
                            'i' => input[3] switch
                            {
                                'n' => input[4] == 'k' ? /* match 'drink' */ 532 : -1,
                                'v' => input[4] == 'e' ? /* match 'drive' */ 533 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'e' => input[1] switch
                    {
                        'a' => input[2] != 'r' ? -1 : input[3] switch
                        {
                            'l' => input[4] == 'y' ? /* match 'early' */ 534 : -1,
                            't' => input[4] == 'h' ? /* match 'earth' */ 535 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ght") ? /* match 'eight' */ 536 : -1,
                        'n' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("my") ? /* match 'enemy' */ 537 : -1,
                            't' => input.AsSpan(3).SequenceEqual("er") ? /* match 'enter' */ 538 : -1,
                            _ => -1,
                        },
                        'q' => input.AsSpan(2).SequenceEqual("ual") ? /* match 'equal' */ 539 : -1,
                        'v' => input[2] != 'e' ? -1 : input[3] switch
                        {
                            'n' => input[4] == 't' ? /* match 'event' */ 540 : -1,
                            'r' => input[4] == 'y' ? /* match 'every' */ 541 : -1,
                            _ => -1,
                        },
                        'x' => input.AsSpan(2).SequenceEqual("act") ? /* match 'exact' */ 542 : -1,
                        _ => -1,
                    },
                    'f' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("vor") ? /* match 'favor' */ 543 : -1,
                        'i' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("ld") ? /* match 'field' */ 544 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("ht") ? /* match 'fight' */ 545 : -1,
                            'n' => input.AsSpan(3).SequenceEqual("al") ? /* match 'final' */ 546 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("st") ? /* match 'first' */ 547 : -1,
                            _ => -1,
                        },
                        'l' => input.AsSpan(2).SequenceEqual("oor") ? /* match 'floor' */ 548 : -1,
                        'o' => input[2] switch
                        {
                            'r' => input.AsSpan(3).SequenceEqual("ce") ? /* match 'force' */ 549 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("nd") ? /* match 'found' */ 550 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("sh") ? /* match 'fresh' */ 551 : -1,
                            'o' => input.AsSpan(3).SequenceEqual("nt") ? /* match 'front' */ 552 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("it") ? /* match 'fruit' */ 553 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'g' => input[1] switch
                    {
                        'l' => input.AsSpan(2).SequenceEqual("ass") ? /* match 'glass' */ 554 : -1,
                        'r' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'n' => input[4] == 'd' ? /* match 'grand' */ 555 : -1,
                                's' => input[4] == 's' ? /* match 'grass' */ 556 : -1,
                                _ => -1,
                            },
                            'e' => input[3] switch
                            {
                                'a' => input[4] == 't' ? /* match 'great' */ 557 : -1,
                                'e' => input[4] == 'n' ? /* match 'green' */ 558 : -1,
                                _ => -1,
                            },
                            'o' => input.AsSpan(3).SequenceEqual("up") ? /* match 'group' */ 559 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("ss") ? /* match 'guess' */ 560 : -1,
                            'i' => input.AsSpan(3).SequenceEqual("de") ? /* match 'guide' */ 561 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'h' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("ppy") ? /* match 'happy' */ 562 : -1,
                        'e' => input[2] != 'a' ? -1 : input[3] switch
                        {
                            'r' => input[4] switch
                            {
                                'd' => /* match 'heard' */ 563,
                                't' => /* match 'heart' */ 564,
                                _ => -1,
                            },
                            'v' => input[4] == 'y' ? /* match 'heavy' */ 565 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'r' => input.AsSpan(3).SequenceEqual("se") ? /* match 'horse' */ 566 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("se") ? /* match 'house' */ 567 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'm' => input.AsSpan(3).SequenceEqual("an") ? /* match 'human' */ 568 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ry") ? /* match 'hurry' */ 569 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'l' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'r' => input.AsSpan(3).SequenceEqual("ge") ? /* match 'large' */ 570 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("gh") ? /* match 'laugh' */ 571 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'r' => input[4] == 'n' ? /* match 'learn' */ 572 : -1,
                                's' => input[4] == 't' ? /* match 'least' */ 573 : -1,
                                'v' => input[4] == 'e' ? /* match 'leave' */ 574 : -1,
                                _ => -1,
                            },
                            'v' => input.AsSpan(3).SequenceEqual("el") ? /* match 'level' */ 575 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ght") ? /* match 'light' */ 576 : -1,
                        _ => -1,
                    },
                    'm' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'j' => input.AsSpan(3).SequenceEqual("or") ? /* match 'major' */ 577 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ch") ? /* match 'match' */ 578 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("nt") ? /* match 'meant' */ 579 : -1,
                            't' => input.AsSpan(3).SequenceEqual("al") ? /* match 'metal' */ 580 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("ght") ? /* match 'might' */ 581 : -1,
                        'o' => input[2] switch
                        {
                            'n' => input[3] switch
                            {
                                'e' => input[4] == 'y' ? /* match 'money' */ 582 : -1,
                                't' => input[4] == 'h' ? /* match 'month' */ 583 : -1,
                                _ => -1,
                            },
                            'u' => input[3] switch
                            {
                                'n' => input[4] == 't' ? /* match 'mount' */ 584 : -1,
                                't' => input[4] == 'h' ? /* match 'mouth' */ 585 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("sic") ? /* match 'music' */ 586 : -1,
                        _ => -1,
                    },
                    'n' => input[1] switch
                    {
                        'e' => input.AsSpan(2).SequenceEqual("ver") ? /* match 'never' */ 587 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("ght") ? /* match 'night' */ 588 : -1,
                        'o' => input[2] switch
                        {
                            'i' => input.AsSpan(3).SequenceEqual("se") ? /* match 'noise' */ 589 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("th") ? /* match 'north' */ 590 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'o' => input[1] switch
                    {
                        'c' => input[2] switch
                        {
                            'c' => input.AsSpan(3).SequenceEqual("ur") ? /* match 'occur' */ 591 : -1,
                            'e' => input.AsSpan(3).SequenceEqual("an") ? /* match 'ocean' */ 592 : -1,
                            _ => -1,
                        },
                        'f' => input[2] switch
                        {
                            'f' => input.AsSpan(3).SequenceEqual("er") ? /* match 'offer' */ 593 : -1,
                            't' => input.AsSpan(3).SequenceEqual("en") ? /* match 'often' */ 594 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'd' => input.AsSpan(3).SequenceEqual("er") ? /* match 'order' */ 595 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("an") ? /* match 'organ' */ 596 : -1,
                            _ => -1,
                        },
                        't' => input.AsSpan(2).SequenceEqual("her") ? /* match 'other' */ 597 : -1,
                        _ => -1,
                    },
                    'p' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'i' => input.AsSpan(3).SequenceEqual("nt") ? /* match 'paint' */ 598 : -1,
                            'p' => input.AsSpan(3).SequenceEqual("er") ? /* match 'paper' */ 599 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ty") ? /* match 'party' */ 600 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("ce") ? /* match 'piece' */ 601 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ch") ? /* match 'pitch' */ 602 : -1,
                            _ => -1,
                        },
                        'l' => input[2] != 'a' ? -1 : input[3] switch
                        {
                            'c' => input[4] == 'e' ? /* match 'place' */ 603 : -1,
                            'i' => input[4] == 'n' ? /* match 'plain' */ 604 : -1,
                            'n' => input[4] switch
                            {
                                'e' => /* match 'plane' */ 605,
                                't' => /* match 'plant' */ 606,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'i' => input.AsSpan(3).SequenceEqual("nt") ? /* match 'point' */ 607 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("nd") ? /* match 'pound' */ 608 : -1,
                            'w' => input.AsSpan(3).SequenceEqual("er") ? /* match 'power' */ 609 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("ss") ? /* match 'press' */ 610 : -1,
                            'i' => input.AsSpan(3).SequenceEqual("nt") ? /* match 'print' */ 611 : -1,
                            'o' => input.AsSpan(3).SequenceEqual("ve") ? /* match 'prove' */ 612 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'q' => input[1] != 'u' ? -1 : input[2] switch
                    {
                        'a' => input.AsSpan(3).SequenceEqual("rt") ? /* match 'quart' */ 613 : -1,
                        'i' => input[3] switch
                        {
                            'c' => input[4] == 'k' ? /* match 'quick' */ 614 : -1,
                            'e' => input[4] == 't' ? /* match 'quiet' */ 615 : -1,
                            't' => input[4] == 'e' ? /* match 'quite' */ 616 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'r' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'd' => input.AsSpan(3).SequenceEqual("io") ? /* match 'radio' */ 617 : -1,
                            'i' => input.AsSpan(3).SequenceEqual("se") ? /* match 'raise' */ 618 : -1,
                            'n' => input.AsSpan(3).SequenceEqual("ge") ? /* match 'range' */ 619 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'c' => input[4] == 'h' ? /* match 'reach' */ 620 : -1,
                                'd' => input[4] == 'y' ? /* match 'ready' */ 621 : -1,
                                _ => -1,
                            },
                            'p' => input.AsSpan(3).SequenceEqual("ly") ? /* match 'reply' */ 622 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'g' => input.AsSpan(3).SequenceEqual("ht") ? /* match 'right' */ 623 : -1,
                            'v' => input.AsSpan(3).SequenceEqual("er") ? /* match 'river' */ 624 : -1,
                            _ => -1,
                        },
                        'o' => input.AsSpan(2).SequenceEqual("und") ? /* match 'round' */ 625 : -1,
                        _ => -1,
                    },
                    's' => input[1] switch
                    {
                        'c' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("le") ? /* match 'scale' */ 626 : -1,
                            'o' => input.AsSpan(3).SequenceEqual("re") ? /* match 'score' */ 627 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'n' => input.AsSpan(3).SequenceEqual("se") ? /* match 'sense' */ 628 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ve") ? /* match 'serve' */ 629 : -1,
                            'v' => input.AsSpan(3).SequenceEqual("en") ? /* match 'seven' */ 630 : -1,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'l' => input[4] == 'l' ? /* match 'shall' */ 631 : -1,
                                'p' => input[4] == 'e' ? /* match 'shape' */ 632 : -1,
                                'r' => input[4] switch
                                {
                                    'e' => /* match 'share' */ 633,
                                    'p' => /* match 'sharp' */ 634,
                                    _ => -1,
                                },
                                _ => -1,
                            },
                            'e' => input[3] switch
                            {
                                'e' => input[4] == 't' ? /* match 'sheet' */ 635 : -1,
                                'l' => input[4] == 'l' ? /* match 'shell' */ 636 : -1,
                                _ => -1,
                            },
                            'i' => input.AsSpan(3).SequenceEqual("ne") ? /* match 'shine' */ 637 : -1,
                            'o' => input[3] switch
                            {
                                'r' => input[4] switch
                                {
                                    'e' => /* match 'shore' */ 638,
                                    't' => /* match 'short' */ 639,
                                    _ => -1,
                                },
                                'u' => input[4] == 't' ? /* match 'shout' */ 640 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'g' => input.AsSpan(3).SequenceEqual("ht") ? /* match 'sight' */ 641 : -1,
                            'n' => input.AsSpan(3).SequenceEqual("ce") ? /* match 'since' */ 642 : -1,
                            _ => -1,
                        },
                        'k' => input.AsSpan(2).SequenceEqual("ill") ? /* match 'skill' */ 643 : -1,
                        'l' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("ve") ? /* match 'slave' */ 644 : -1,
                            'e' => input.AsSpan(3).SequenceEqual("ep") ? /* match 'sleep' */ 645 : -1,
                            _ => -1,
                        },
                        'm' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("ll") ? /* match 'small' */ 646 : -1,
                            'e' => input.AsSpan(3).SequenceEqual("ll") ? /* match 'smell' */ 647 : -1,
                            'i' => input.AsSpan(3).SequenceEqual("le") ? /* match 'smile' */ 648 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'l' => input.AsSpan(3).SequenceEqual("ve") ? /* match 'solve' */ 649 : -1,
                            'u' => input[3] switch
                            {
                                'n' => input[4] == 'd' ? /* match 'sound' */ 650 : -1,
                                't' => input[4] == 'h' ? /* match 'south' */ 651 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'p' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("ce") ? /* match 'space' */ 652 : -1,
                            'e' => input[3] switch
                            {
                                'a' => input[4] == 'k' ? /* match 'speak' */ 653 : -1,
                                'e' => input[4] == 'd' ? /* match 'speed' */ 654 : -1,
                                'l' => input[4] == 'l' ? /* match 'spell' */ 655 : -1,
                                'n' => input[4] == 'd' ? /* match 'spend' */ 656 : -1,
                                _ => -1,
                            },
                            'o' => input.AsSpan(3).SequenceEqual("ke") ? /* match 'spoke' */ 657 : -1,
                            _ => -1,
                        },
                        't' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'n' => input[4] == 'd' ? /* match 'stand' */ 658 : -1,
                                'r' => input[4] == 't' ? /* match 'start' */ 659 : -1,
                                't' => input[4] == 'e' ? /* match 'state' */ 660 : -1,
                                _ => -1,
                            },
                            'e' => input[3] switch
                            {
                                'a' => input[4] switch
                                {
                                    'd' => /* match 'stead' */ 661,
                                    'm' => /* match 'steam' */ 662,
                                    _ => -1,
                                },
                                'e' => input[4] == 'l' ? /* match 'steel' */ 663 : -1,
                                _ => -1,
                            },
                            'i' => input[3] switch
                            {
                                'c' => input[4] == 'k' ? /* match 'stick' */ 664 : -1,
                                'l' => input[4] == 'l' ? /* match 'still' */ 665 : -1,
                                _ => -1,
                            },
                            'o' => input[3] switch
                            {
                                'n' => input[4] == 'e' ? /* match 'stone' */ 666 : -1,
                                'o' => input[4] == 'd' ? /* match 'stood' */ 667 : -1,
                                'r' => input[4] switch
                                {
                                    'e' => /* match 'store' */ 668,
                                    'y' => /* match 'story' */ 669,
                                    _ => -1,
                                },
                                _ => -1,
                            },
                            'u' => input.AsSpan(3).SequenceEqual("dy") ? /* match 'study' */ 670 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("gar") ? /* match 'sugar' */ 671 : -1,
                        _ => -1,
                    },
                    't' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("ble") ? /* match 'table' */ 672 : -1,
                        'e' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("ch") ? /* match 'teach' */ 673 : -1,
                            'e' => input.AsSpan(3).SequenceEqual("th") ? /* match 'teeth' */ 674 : -1,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("nk") ? /* match 'thank' */ 675 : -1,
                            'e' => input[3] switch
                            {
                                'i' => input[4] == 'r' ? /* match 'their' */ 676 : -1,
                                'r' => input[4] == 'e' ? /* match 'there' */ 677 : -1,
                                's' => input[4] == 'e' ? /* match 'these' */ 678 : -1,
                                _ => -1,
                            },
                            'i' => input[3] switch
                            {
                                'c' => input[4] == 'k' ? /* match 'thick' */ 679 : -1,
                                'n' => input[4] switch
                                {
                                    'g' => /* match 'thing' */ 680,
                                    'k' => /* match 'think' */ 681,
                                    _ => -1,
                                },
                                'r' => input[4] == 'd' ? /* match 'third' */ 682 : -1,
                                _ => -1,
                            },
                            'o' => input.AsSpan(3).SequenceEqual("se") ? /* match 'those' */ 683 : -1,
                            'r' => input[3] switch
                            {
                                'e' => input[4] == 'e' ? /* match 'three' */ 684 : -1,
                                'o' => input[4] == 'w' ? /* match 'throw' */ 685 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            't' => input.AsSpan(3).SequenceEqual("al") ? /* match 'total' */ 686 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ch") ? /* match 'touch' */ 687 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'c' => input[4] == 'k' ? /* match 'track' */ 688 : -1,
                                'd' => input[4] == 'e' ? /* match 'trade' */ 689 : -1,
                                'i' => input[4] == 'n' ? /* match 'train' */ 690 : -1,
                                _ => -1,
                            },
                            'u' => input.AsSpan(3).SequenceEqual("ck") ? /* match 'truck' */ 691 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'u' => input[1] switch
                    {
                        'n' => input[2] switch
                        {
                            'd' => input.AsSpan(3).SequenceEqual("er") ? /* match 'under' */ 692 : -1,
                            't' => input.AsSpan(3).SequenceEqual("il") ? /* match 'until' */ 693 : -1,
                            _ => -1,
                        },
                        's' => input.AsSpan(2).SequenceEqual("ual") ? /* match 'usual' */ 694 : -1,
                        _ => -1,
                    },
                    'v' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("lue") ? /* match 'value' */ 695 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("sit") ? /* match 'visit' */ 696 : -1,
                        'o' => input[2] switch
                        {
                            'i' => input.AsSpan(3).SequenceEqual("ce") ? /* match 'voice' */ 697 : -1,
                            'w' => input.AsSpan(3).SequenceEqual("el") ? /* match 'vowel' */ 698 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'w' => input[1] switch
                    {
                        'a' => input[2] != 't' ? -1 : input[3] switch
                        {
                            'c' => input[4] == 'h' ? /* match 'watch' */ 699 : -1,
                            'e' => input[4] == 'r' ? /* match 'water' */ 700 : -1,
                            _ => -1,
                        },
                        'h' => input[2] switch
                        {
                            'e' => input[3] switch
                            {
                                'e' => input[4] == 'l' ? /* match 'wheel' */ 701 : -1,
                                'r' => input[4] == 'e' ? /* match 'where' */ 702 : -1,
                                _ => -1,
                            },
                            'i' => input[3] switch
                            {
                                'c' => input[4] == 'h' ? /* match 'which' */ 703 : -1,
                                'l' => input[4] == 'e' ? /* match 'while' */ 704 : -1,
                                't' => input[4] == 'e' ? /* match 'white' */ 705 : -1,
                                _ => -1,
                            },
                            'o' => input[3] switch
                            {
                                'l' => input[4] == 'e' ? /* match 'whole' */ 706 : -1,
                                's' => input[4] == 'e' ? /* match 'whose' */ 707 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'm' => input[3] switch
                            {
                                'a' => input[4] == 'n' ? /* match 'woman' */ 708 : -1,
                                'e' => input[4] == 'n' ? /* match 'women' */ 709 : -1,
                                _ => -1,
                            },
                            'n' => input.AsSpan(3).SequenceEqual("'t") ? /* match 'won't' */ 710 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ld") ? /* match 'world' */ 711 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ld") ? /* match 'would' */ 712 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'i' => input.AsSpan(3).SequenceEqual("te") ? /* match 'write' */ 713 : -1,
                            'o' => input[3] switch
                            {
                                'n' => input[4] == 'g' ? /* match 'wrong' */ 714 : -1,
                                't' => input[4] == 'e' ? /* match 'wrote' */ 715 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'y' => input.AsSpan(1).SequenceEqual("oung") ? /* match 'young' */ 716 : -1,
                    _ => -1,
                },
                6 => input[0] switch
                {
                    'a' => input[1] switch
                    {
                        'f' => input.AsSpan(2).SequenceEqual("raid") ? /* match 'afraid' */ 717 : -1,
                        'l' => input.AsSpan(2).SequenceEqual("ways") ? /* match 'always' */ 718 : -1,
                        'n' => input[2] switch
                        {
                            'i' => input.AsSpan(3).SequenceEqual("mal") ? /* match 'animal' */ 719 : -1,
                            's' => input.AsSpan(3).SequenceEqual("wer") ? /* match 'answer' */ 720 : -1,
                            _ => -1,
                        },
                        'p' => input.AsSpan(2).SequenceEqual("pear") ? /* match 'appear' */ 721 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("rive") ? /* match 'arrive' */ 722 : -1,
                        _ => -1,
                    },
                    'b' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("uty") ? /* match 'beauty' */ 723 : -1,
                            'f' => input.AsSpan(3).SequenceEqual("ore") ? /* match 'before' */ 724 : -1,
                            'h' => input.AsSpan(3).SequenceEqual("ind") ? /* match 'behind' */ 725 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ter") ? /* match 'better' */ 726 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            't' => input.AsSpan(3).SequenceEqual("tom") ? /* match 'bottom' */ 727 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ght") ? /* match 'bought' */ 728 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("nch") ? /* match 'branch' */ 729 : -1,
                            'i' => input.AsSpan(3).SequenceEqual("ght") ? /* match 'bright' */ 730 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'c' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("ught") ? /* match 'caught' */ 731 : -1,
                        'e' => input.AsSpan(2).SequenceEqual("nter") ? /* match 'center' */ 732 : -1,
                        'h' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'n' => input[4] switch
                                {
                                    'c' => input[5] == 'e' ? /* match 'chance' */ 733 : -1,
                                    'g' => input[5] == 'e' ? /* match 'change' */ 734 : -1,
                                    _ => -1,
                                },
                                'r' => input.AsSpan(4).SequenceEqual("ge") ? /* match 'charge' */ 735 : -1,
                                _ => -1,
                            },
                            'o' => input.AsSpan(3).SequenceEqual("ose") ? /* match 'choose' */ 736 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("rcle") ? /* match 'circle' */ 737 : -1,
                        'l' => input.AsSpan(2).SequenceEqual("othe") ? /* match 'clothe' */ 738 : -1,
                        'o' => input[2] switch
                        {
                            'l' => input[3] switch
                            {
                                'o' => input.AsSpan(4).SequenceEqual("ny") ? /* match 'colony' */ 739 : -1,
                                'u' => input.AsSpan(4).SequenceEqual("mn") ? /* match 'column' */ 740 : -1,
                                _ => -1,
                            },
                            'm' => input.AsSpan(3).SequenceEqual("mon") ? /* match 'common' */ 741 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ner") ? /* match 'corner' */ 742 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ton") ? /* match 'cotton' */ 743 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("rse") ? /* match 'course' */ 744 : -1,
                            _ => -1,
                        },
                        'r' => !input.AsSpan(2, 2).SequenceEqual("ea") ? -1 : input[4] switch
                        {
                            's' => input[5] == 'e' ? /* match 'crease' */ 745 : -1,
                            't' => input[5] == 'e' ? /* match 'create' */ 746 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("nger") ? /* match 'danger' */ 747 : -1,
                        'e' => input[2] switch
                        {
                            'c' => input.AsSpan(3).SequenceEqual("ide") ? /* match 'decide' */ 748 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("ree") ? /* match 'degree' */ 749 : -1,
                            'p' => input.AsSpan(3).SequenceEqual("end") ? /* match 'depend' */ 750 : -1,
                            's' => input[3] switch
                            {
                                'e' => input.AsSpan(4).SequenceEqual("rt") ? /* match 'desert' */ 751 : -1,
                                'i' => input.AsSpan(4).SequenceEqual("gn") ? /* match 'design' */ 752 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'f' => input.AsSpan(3).SequenceEqual("fer") ? /* match 'differ' */ 753 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ect") ? /* match 'direct' */ 754 : -1,
                            'v' => input.AsSpan(3).SequenceEqual("ide") ? /* match 'divide' */ 755 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'c' => input.AsSpan(3).SequenceEqual("tor") ? /* match 'doctor' */ 756 : -1,
                            'l' => input.AsSpan(3).SequenceEqual("lar") ? /* match 'dollar' */ 757 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ble") ? /* match 'double' */ 758 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("ring") ? /* match 'during' */ 759 : -1,
                        _ => -1,
                    },
                    'e' => input[1] switch
                    {
                        'f' => input.AsSpan(2).SequenceEqual("fect") ? /* match 'effect' */ 760 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("ther") ? /* match 'either' */ 761 : -1,
                        'n' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("rgy") ? /* match 'energy' */ 762 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("ine") ? /* match 'engine' */ 763 : -1,
                            'o' => input.AsSpan(3).SequenceEqual("ugh") ? /* match 'enough' */ 764 : -1,
                            _ => -1,
                        },
                        'q' => input.AsSpan(2).SequenceEqual("uate") ? /* match 'equate' */ 765 : -1,
                        'x' => input[2] switch
                        {
                            'c' => input[3] switch
                            {
                                'e' => input.AsSpan(4).SequenceEqual("pt") ? /* match 'except' */ 766 : -1,
                                'i' => input.AsSpan(4).SequenceEqual("te") ? /* match 'excite' */ 767 : -1,
                                _ => -1,
                            },
                            'p' => input.AsSpan(3).SequenceEqual("ect") ? /* match 'expect' */ 768 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'f' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'm' => input[3] switch
                            {
                                'i' => input.AsSpan(4).SequenceEqual("ly") ? /* match 'family' */ 769 : -1,
                                'o' => input.AsSpan(4).SequenceEqual("us") ? /* match 'famous' */ 770 : -1,
                                _ => -1,
                            },
                            't' => input.AsSpan(3).SequenceEqual("her") ? /* match 'father' */ 771 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'g' => input.AsSpan(3).SequenceEqual("ure") ? /* match 'figure' */ 772 : -1,
                            'n' => input[3] switch
                            {
                                'g' => input.AsSpan(4).SequenceEqual("er") ? /* match 'finger' */ 773 : -1,
                                'i' => input.AsSpan(4).SequenceEqual("sh") ? /* match 'finish' */ 774 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'l' => input.AsSpan(2).SequenceEqual("ower") ? /* match 'flower' */ 775 : -1,
                        'o' => input[2] switch
                        {
                            'l' => input.AsSpan(3).SequenceEqual("low") ? /* match 'follow' */ 776 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("est") ? /* match 'forest' */ 777 : -1,
                            _ => -1,
                        },
                        'r' => input.AsSpan(2).SequenceEqual("iend") ? /* match 'friend' */ 778 : -1,
                        _ => -1,
                    },
                    'g' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'r' => input.AsSpan(3).SequenceEqual("den") ? /* match 'garden' */ 779 : -1,
                            't' => input.AsSpan(3).SequenceEqual("her") ? /* match 'gather' */ 780 : -1,
                            _ => -1,
                        },
                        'e' => input.AsSpan(2).SequenceEqual("ntle") ? /* match 'gentle' */ 781 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("vern") ? /* match 'govern' */ 782 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("ound") ? /* match 'ground' */ 783 : -1,
                        _ => -1,
                    },
                    'h' => input.AsSpan(1).SequenceEqual("appen") ? /* match 'happen' */ 784 : -1,
                    'i' => input[1] switch
                    {
                        'n' => input[2] switch
                        {
                            's' => input.AsSpan(3).SequenceEqual("ect") ? /* match 'insect' */ 785 : -1,
                            'v' => input.AsSpan(3).SequenceEqual("ent") ? /* match 'invent' */ 786 : -1,
                            _ => -1,
                        },
                        's' => input.AsSpan(2).SequenceEqual("land") ? /* match 'island' */ 787 : -1,
                        _ => -1,
                    },
                    'l' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            'n' => input.AsSpan(3).SequenceEqual("gth") ? /* match 'length' */ 788 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ter") ? /* match 'letter' */ 789 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'q' => input.AsSpan(3).SequenceEqual("uid") ? /* match 'liquid' */ 790 : -1,
                            's' => input.AsSpan(3).SequenceEqual("ten") ? /* match 'listen' */ 791 : -1,
                            't' => input.AsSpan(3).SequenceEqual("tle") ? /* match 'little' */ 792 : -1,
                            _ => -1,
                        },
                        'o' => input.AsSpan(2).SequenceEqual("cate") ? /* match 'locate' */ 793 : -1,
                        _ => -1,
                    },
                    'm' => input[1] switch
                    {
                        'a' => input[2] switch
                        {
                            'g' => input.AsSpan(3).SequenceEqual("net") ? /* match 'magnet' */ 794 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ket") ? /* match 'market' */ 795 : -1,
                            's' => input.AsSpan(3).SequenceEqual("ter") ? /* match 'master' */ 796 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ter") ? /* match 'matter' */ 797 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'l' => input.AsSpan(3).SequenceEqual("ody") ? /* match 'melody' */ 798 : -1,
                            't' => input.AsSpan(3).SequenceEqual("hod") ? /* match 'method' */ 799 : -1,
                            _ => -1,
                        },
                        'i' => input[2] switch
                        {
                            'd' => input.AsSpan(3).SequenceEqual("dle") ? /* match 'middle' */ 800 : -1,
                            'n' => input.AsSpan(3).SequenceEqual("ute") ? /* match 'minute' */ 801 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'd' => input.AsSpan(3).SequenceEqual("ern") ? /* match 'modern' */ 802 : -1,
                            'm' => input.AsSpan(3).SequenceEqual("ent") ? /* match 'moment' */ 803 : -1,
                            't' => input[3] switch
                            {
                                'h' => input.AsSpan(4).SequenceEqual("er") ? /* match 'mother' */ 804 : -1,
                                'i' => input.AsSpan(4).SequenceEqual("on") ? /* match 'motion' */ 805 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'n' => input[1] switch
                    {
                        'a' => input[2] != 't' ? -1 : input[3] switch
                        {
                            'i' => input.AsSpan(4).SequenceEqual("on") ? /* match 'nation' */ 806 : -1,
                            'u' => input.AsSpan(4).SequenceEqual("re") ? /* match 'nature' */ 807 : -1,
                            _ => -1,
                        },
                        'o' => input.AsSpan(2).SequenceEqual("tice") ? /* match 'notice' */ 808 : -1,
                        'u' => input.AsSpan(2).SequenceEqual("mber") ? /* match 'number' */ 809 : -1,
                        _ => -1,
                    },
                    'o' => input[1] switch
                    {
                        'b' => input.AsSpan(2).SequenceEqual("ject") ? /* match 'object' */ 810 : -1,
                        'f' => input.AsSpan(2).SequenceEqual("fice") ? /* match 'office' */ 811 : -1,
                        'x' => input.AsSpan(2).SequenceEqual("ygen") ? /* match 'oxygen' */ 812 : -1,
                        _ => -1,
                    },
                    'p' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("rent") ? /* match 'parent' */ 813 : -1,
                        'e' => input[2] switch
                        {
                            'o' => input.AsSpan(3).SequenceEqual("ple") ? /* match 'people' */ 814 : -1,
                            'r' => input[3] switch
                            {
                                'i' => input.AsSpan(4).SequenceEqual("od") ? /* match 'period' */ 815 : -1,
                                's' => input.AsSpan(4).SequenceEqual("on") ? /* match 'person' */ 816 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'h' => input.AsSpan(2).SequenceEqual("rase") ? /* match 'phrase' */ 817 : -1,
                        'l' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("net") ? /* match 'planet' */ 818 : -1,
                            'e' => input.AsSpan(3).SequenceEqual("ase") ? /* match 'please' */ 819 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ral") ? /* match 'plural' */ 820 : -1,
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("tty") ? /* match 'pretty' */ 821 : -1,
                            'o' => input.AsSpan(3).SequenceEqual("per") ? /* match 'proper' */ 822 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'r' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("ther") ? /* match 'rather' */ 823 : -1,
                        'e' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("son") ? /* match 'reason' */ 824 : -1,
                            'c' => input.AsSpan(3).SequenceEqual("ord") ? /* match 'record' */ 825 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("ion") ? /* match 'region' */ 826 : -1,
                            'p' => input.AsSpan(3).SequenceEqual("eat") ? /* match 'repeat' */ 827 : -1,
                            's' => input.AsSpan(3).SequenceEqual("ult") ? /* match 'result' */ 828 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    's' => input[1] switch
                    {
                        'c' => input.AsSpan(2).SequenceEqual("hool") ? /* match 'school' */ 829 : -1,
                        'e' => input[2] switch
                        {
                            'a' => input[3] switch
                            {
                                'r' => input.AsSpan(4).SequenceEqual("ch") ? /* match 'search' */ 830 : -1,
                                's' => input.AsSpan(4).SequenceEqual("on") ? /* match 'season' */ 831 : -1,
                                _ => -1,
                            },
                            'c' => input.AsSpan(3).SequenceEqual("ond") ? /* match 'second' */ 832 : -1,
                            'l' => input.AsSpan(3).SequenceEqual("ect") ? /* match 'select' */ 833 : -1,
                            't' => input.AsSpan(3).SequenceEqual("tle") ? /* match 'settle' */ 834 : -1,
                            _ => -1,
                        },
                        'h' => input.AsSpan(2).SequenceEqual("ould") ? /* match 'should' */ 835 : -1,
                        'i' => input[2] switch
                        {
                            'l' => input[3] switch
                            {
                                'e' => input.AsSpan(4).SequenceEqual("nt") ? /* match 'silent' */ 836 : -1,
                                'v' => input.AsSpan(4).SequenceEqual("er") ? /* match 'silver' */ 837 : -1,
                                _ => -1,
                            },
                            'm' => input.AsSpan(3).SequenceEqual("ple") ? /* match 'simple' */ 838 : -1,
                            'n' => input.AsSpan(3).SequenceEqual("gle") ? /* match 'single' */ 839 : -1,
                            's' => input.AsSpan(3).SequenceEqual("ter") ? /* match 'sister' */ 840 : -1,
                            _ => -1,
                        },
                        'p' => input[2] switch
                        {
                            'e' => input.AsSpan(3).SequenceEqual("ech") ? /* match 'speech' */ 841 : -1,
                            'r' => input[3] switch
                            {
                                'e' => input.AsSpan(4).SequenceEqual("ad") ? /* match 'spread' */ 842 : -1,
                                'i' => input.AsSpan(4).SequenceEqual("ng") ? /* match 'spring' */ 843 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'q' => input.AsSpan(2).SequenceEqual("uare") ? /* match 'square' */ 844 : -1,
                        't' => input[2] != 'r' ? -1 : input[3] switch
                        {
                            'e' => input[4] switch
                            {
                                'a' => input[5] == 'm' ? /* match 'stream' */ 845 : -1,
                                'e' => input[5] == 't' ? /* match 'street' */ 846 : -1,
                                _ => -1,
                            },
                            'i' => input.AsSpan(4).SequenceEqual("ng") ? /* match 'string' */ 847 : -1,
                            'o' => input.AsSpan(4).SequenceEqual("ng") ? /* match 'strong' */ 848 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'd' => input.AsSpan(3).SequenceEqual("den") ? /* match 'sudden' */ 849 : -1,
                            'f' => input.AsSpan(3).SequenceEqual("fix") ? /* match 'suffix' */ 850 : -1,
                            'm' => input.AsSpan(3).SequenceEqual("mer") ? /* match 'summer' */ 851 : -1,
                            'p' => input.AsSpan(3).SequenceEqual("ply") ? /* match 'supply' */ 852 : -1,
                            _ => -1,
                        },
                        'y' => input[2] switch
                        {
                            'm' => input.AsSpan(3).SequenceEqual("bol") ? /* match 'symbol' */ 853 : -1,
                            's' => input.AsSpan(3).SequenceEqual("tem") ? /* match 'system' */ 854 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    't' => input[1] switch
                    {
                        'h' => input.AsSpan(2).SequenceEqual("ough") ? /* match 'though' */ 855 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("ward") ? /* match 'toward' */ 856 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("avel") ? /* match 'travel' */ 857 : -1,
                        'w' => input.AsSpan(2).SequenceEqual("enty") ? /* match 'twenty' */ 858 : -1,
                        _ => -1,
                    },
                    'v' => input.AsSpan(1).SequenceEqual("alley") ? /* match 'valley' */ 859 : -1,
                    'w' => input[1] switch
                    {
                        'e' => input.AsSpan(2).SequenceEqual("ight") ? /* match 'weight' */ 860 : -1,
                        'i' => input[2] != 'n' ? -1 : input[3] switch
                        {
                            'd' => input.AsSpan(4).SequenceEqual("ow") ? /* match 'window' */ 861 : -1,
                            't' => input.AsSpan(4).SequenceEqual("er") ? /* match 'winter' */ 862 : -1,
                            _ => -1,
                        },
                        'o' => input.AsSpan(2).SequenceEqual("nder") ? /* match 'wonder' */ 863 : -1,
                        _ => -1,
                    },
                    'y' => input.AsSpan(1).SequenceEqual("ellow") ? /* match 'yellow' */ 864 : -1,
                    _ => -1,
                },
                7 => input[0] switch
                {
                    'a' => input[1] switch
                    {
                        'g' => input.AsSpan(2).SequenceEqual("ainst") ? /* match 'against' */ 865 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("range") ? /* match 'arrange' */ 866 : -1,
                        _ => -1,
                    },
                    'b' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            'l' => input.AsSpan(3).SequenceEqual("ieve") ? /* match 'believe' */ 867 : -1,
                            't' => input.AsSpan(3).SequenceEqual("ween") ? /* match 'between' */ 868 : -1,
                            _ => -1,
                        },
                        'r' => input[2] != 'o' ? -1 : input[3] switch
                        {
                            't' => input.AsSpan(4).SequenceEqual("her") ? /* match 'brother' */ 869 : -1,
                            'u' => input.AsSpan(4).SequenceEqual("ght") ? /* match 'brought' */ 870 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'c' => input[1] switch
                    {
                        'a' => input[2] != 'p' ? -1 : input[3] switch
                        {
                            'i' => input.AsSpan(4).SequenceEqual("tal") ? /* match 'capital' */ 871 : -1,
                            't' => input.AsSpan(4).SequenceEqual("ain") ? /* match 'captain' */ 872 : -1,
                            _ => -1,
                        },
                        'e' => input[2] switch
                        {
                            'n' => input.AsSpan(3).SequenceEqual("tury") ? /* match 'century' */ 873 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("tain") ? /* match 'certain' */ 874 : -1,
                            _ => -1,
                        },
                        'o' => input[2] switch
                        {
                            'l' => input.AsSpan(3).SequenceEqual("lect") ? /* match 'collect' */ 875 : -1,
                            'm' => !input.AsSpan(3, 2).SequenceEqual("pa") ? -1 : input[5] switch
                            {
                                'n' => input[6] == 'y' ? /* match 'company' */ 876 : -1,
                                'r' => input[6] == 'e' ? /* match 'compare' */ 877 : -1,
                                _ => -1,
                            },
                            'n' => input[3] switch
                            {
                                'n' => input.AsSpan(4).SequenceEqual("ect") ? /* match 'connect' */ 878 : -1,
                                't' => input[4] switch
                                {
                                    'a' => input.AsSpan(5).SequenceEqual("in") ? /* match 'contain' */ 879 : -1,
                                    'r' => input.AsSpan(5).SequenceEqual("ol") ? /* match 'control' */ 880 : -1,
                                    _ => -1,
                                },
                                _ => -1,
                            },
                            'r' => input.AsSpan(3).SequenceEqual("rect") ? /* match 'correct' */ 881 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ntry") ? /* match 'country' */ 882 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("rrent") ? /* match 'current' */ 883 : -1,
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            'c' => input.AsSpan(3).SequenceEqual("imal") ? /* match 'decimal' */ 884 : -1,
                            'v' => input.AsSpan(3).SequenceEqual("elop") ? /* match 'develop' */ 885 : -1,
                            _ => -1,
                        },
                        'i' => input[2] != 's' ? -1 : input[3] switch
                        {
                            'c' => input.AsSpan(4).SequenceEqual("uss") ? /* match 'discuss' */ 886 : -1,
                            't' => input.AsSpan(4).SequenceEqual("ant") ? /* match 'distant' */ 887 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'e' => input[1] switch
                    {
                        'l' => input.AsSpan(2).SequenceEqual("ement") ? /* match 'element' */ 888 : -1,
                        'v' => input.AsSpan(2).SequenceEqual("ening") ? /* match 'evening' */ 889 : -1,
                        'x' => input.AsSpan(2).SequenceEqual("ample") ? /* match 'example' */ 890 : -1,
                        _ => -1,
                    },
                    'f' => input.AsSpan(1).SequenceEqual("orward") ? /* match 'forward' */ 891 : -1,
                    'g' => input.AsSpan(1).SequenceEqual("eneral") ? /* match 'general' */ 892 : -1,
                    'h' => input[1] switch
                    {
                        'i' => input.AsSpan(2).SequenceEqual("story") ? /* match 'history' */ 893 : -1,
                        'u' => input.AsSpan(2).SequenceEqual("ndred") ? /* match 'hundred' */ 894 : -1,
                        _ => -1,
                    },
                    'i' => input[1] switch
                    {
                        'm' => input.AsSpan(2).SequenceEqual("agine") ? /* match 'imagine' */ 895 : -1,
                        'n' => input[2] switch
                        {
                            'c' => input.AsSpan(3).SequenceEqual("lude") ? /* match 'include' */ 896 : -1,
                            's' => input.AsSpan(3).SequenceEqual("tant") ? /* match 'instant' */ 897 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'm' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("chine") ? /* match 'machine' */ 898 : -1,
                        'e' => input.AsSpan(2).SequenceEqual("asure") ? /* match 'measure' */ 899 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("llion") ? /* match 'million' */ 900 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("rning") ? /* match 'morning' */ 901 : -1,
                        _ => -1,
                    },
                    'n' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("tural") ? /* match 'natural' */ 902 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("thing") ? /* match 'nothing' */ 903 : -1,
                        'u' => input.AsSpan(2).SequenceEqual("meral") ? /* match 'numeral' */ 904 : -1,
                        _ => -1,
                    },
                    'o' => input[1] switch
                    {
                        'b' => input.AsSpan(2).SequenceEqual("serve") ? /* match 'observe' */ 905 : -1,
                        'p' => input.AsSpan(2).SequenceEqual("erate") ? /* match 'operate' */ 906 : -1,
                        _ => -1,
                    },
                    'p' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("ttern") ? /* match 'pattern' */ 907 : -1,
                        'e' => input.AsSpan(2).SequenceEqual("rhaps") ? /* match 'perhaps' */ 908 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("cture") ? /* match 'picture' */ 909 : -1,
                        'r' => input[2] switch
                        {
                            'e' => input[3] switch
                            {
                                'p' => input.AsSpan(4).SequenceEqual("are") ? /* match 'prepare' */ 910 : -1,
                                's' => input.AsSpan(4).SequenceEqual("ent") ? /* match 'present' */ 911 : -1,
                                _ => -1,
                            },
                            'o' => input[3] switch
                            {
                                'b' => input.AsSpan(4).SequenceEqual("lem") ? /* match 'problem' */ 912 : -1,
                                'c' => input.AsSpan(4).SequenceEqual("ess") ? /* match 'process' */ 913 : -1,
                                'd' => !input.AsSpan(4, 2).SequenceEqual("uc") ? -1 : input[6] switch
                                {
                                    'e' => /* match 'produce' */ 914,
                                    't' => /* match 'product' */ 915,
                                    _ => -1,
                                },
                                't' => input.AsSpan(4).SequenceEqual("ect") ? /* match 'protect' */ 916 : -1,
                                'v' => input.AsSpan(4).SequenceEqual("ide") ? /* match 'provide' */ 917 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'r' => input[1] != 'e' ? -1 : input[2] switch
                    {
                        'c' => input.AsSpan(3).SequenceEqual("eive") ? /* match 'receive' */ 918 : -1,
                        'q' => input.AsSpan(3).SequenceEqual("uire") ? /* match 'require' */ 919 : -1,
                        _ => -1,
                    },
                    's' => input[1] switch
                    {
                        'c' => input.AsSpan(2).SequenceEqual("ience") ? /* match 'science' */ 920 : -1,
                        'e' => input[2] switch
                        {
                            'c' => input.AsSpan(3).SequenceEqual("tion") ? /* match 'section' */ 921 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("ment") ? /* match 'segment' */ 922 : -1,
                            'v' => input.AsSpan(3).SequenceEqual("eral") ? /* match 'several' */ 923 : -1,
                            _ => -1,
                        },
                        'i' => input.AsSpan(2).SequenceEqual("milar") ? /* match 'similar' */ 924 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("ldier") ? /* match 'soldier' */ 925 : -1,
                        'p' => input.AsSpan(2).SequenceEqual("ecial") ? /* match 'special' */ 926 : -1,
                        't' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("tion") ? /* match 'station' */ 927 : -1,
                            'r' => input[3] switch
                            {
                                'a' => input.AsSpan(4).SequenceEqual("nge") ? /* match 'strange' */ 928 : -1,
                                'e' => input.AsSpan(4).SequenceEqual("tch") ? /* match 'stretch' */ 929 : -1,
                                _ => -1,
                            },
                            'u' => input.AsSpan(3).SequenceEqual("dent") ? /* match 'student' */ 930 : -1,
                            _ => -1,
                        },
                        'u' => input[2] switch
                        {
                            'b' => input.AsSpan(3).SequenceEqual("ject") ? /* match 'subject' */ 931 : -1,
                            'c' => input.AsSpan(3).SequenceEqual("cess") ? /* match 'success' */ 932 : -1,
                            'g' => input.AsSpan(3).SequenceEqual("gest") ? /* match 'suggest' */ 933 : -1,
                            'p' => input.AsSpan(3).SequenceEqual("port") ? /* match 'support' */ 934 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("face") ? /* match 'surface' */ 935 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    't' => input[1] switch
                    {
                        'h' => input[2] switch
                        {
                            'o' => input.AsSpan(3).SequenceEqual("ught") ? /* match 'thought' */ 936 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("ough") ? /* match 'through' */ 937 : -1,
                            _ => -1,
                        },
                        'r' => input.AsSpan(2).SequenceEqual("ouble") ? /* match 'trouble' */ 938 : -1,
                        _ => -1,
                    },
                    'v' => input.AsSpan(1).SequenceEqual("illage") ? /* match 'village' */ 939 : -1,
                    'w' => input[1] switch
                    {
                        'e' => input.AsSpan(2).SequenceEqual("ather") ? /* match 'weather' */ 940 : -1,
                        'h' => input.AsSpan(2).SequenceEqual("ether") ? /* match 'whether' */ 941 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("itten") ? /* match 'written' */ 942 : -1,
                        _ => -1,
                    },
                    _ => -1,
                },
                8 => input[0] switch
                {
                    'c' => input[1] switch
                    {
                        'h' => input.AsSpan(2).SequenceEqual("ildren") ? /* match 'children' */ 943 : -1,
                        'o' => input[2] switch
                        {
                            'm' => input.AsSpan(3).SequenceEqual("plete") ? /* match 'complete' */ 944 : -1,
                            'n' => input[3] switch
                            {
                                's' => input.AsSpan(4).SequenceEqual("ider") ? /* match 'consider' */ 945 : -1,
                                't' => input.AsSpan(4).SequenceEqual("inue") ? /* match 'continue' */ 946 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'e' => input.AsSpan(2).SequenceEqual("scribe") ? /* match 'describe' */ 947 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("vision") ? /* match 'division' */ 948 : -1,
                        _ => -1,
                    },
                    'e' => input[1] switch
                    {
                        'l' => input.AsSpan(2).SequenceEqual("ectric") ? /* match 'electric' */ 949 : -1,
                        'x' => input.AsSpan(2).SequenceEqual("ercise") ? /* match 'exercise' */ 950 : -1,
                        _ => -1,
                    },
                    'f' => input.AsSpan(1).SequenceEqual("raction") ? /* match 'fraction' */ 951 : -1,
                    'i' => input[1] != 'n' ? -1 : input[2] switch
                    {
                        'd' => input[3] switch
                        {
                            'i' => input.AsSpan(4).SequenceEqual("cate") ? /* match 'indicate' */ 952 : -1,
                            'u' => input.AsSpan(4).SequenceEqual("stry") ? /* match 'industry' */ 953 : -1,
                            _ => -1,
                        },
                        't' => input.AsSpan(3).SequenceEqual("erest") ? /* match 'interest' */ 954 : -1,
                        _ => -1,
                    },
                    'l' => input.AsSpan(1).SequenceEqual("anguage") ? /* match 'language' */ 955 : -1,
                    'm' => input[1] switch
                    {
                        'a' => input.AsSpan(2).SequenceEqual("terial") ? /* match 'material' */ 956 : -1,
                        'o' => input[2] switch
                        {
                            'l' => input.AsSpan(3).SequenceEqual("ecule") ? /* match 'molecule' */ 957 : -1,
                            'u' => input.AsSpan(3).SequenceEqual("ntain") ? /* match 'mountain' */ 958 : -1,
                            _ => -1,
                        },
                        'u' => input.AsSpan(2).SequenceEqual("ltiply") ? /* match 'multiply' */ 959 : -1,
                        _ => -1,
                    },
                    'n' => input.AsSpan(1).SequenceEqual("eighbor") ? /* match 'neighbor' */ 960 : -1,
                    'o' => input[1] switch
                    {
                        'p' => input.AsSpan(2).SequenceEqual("posite") ? /* match 'opposite' */ 961 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("iginal") ? /* match 'original' */ 962 : -1,
                        _ => -1,
                    },
                    'p' => input[1] switch
                    {
                        'o' => input[2] switch
                        {
                            'p' => input.AsSpan(3).SequenceEqual("ulate") ? /* match 'populate' */ 963 : -1,
                            's' => input[3] switch
                            {
                                'i' => input.AsSpan(4).SequenceEqual("tion") ? /* match 'position' */ 964 : -1,
                                's' => input.AsSpan(4).SequenceEqual("ible") ? /* match 'possible' */ 965 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        'r' => input[2] switch
                        {
                            'a' => input.AsSpan(3).SequenceEqual("ctice") ? /* match 'practice' */ 966 : -1,
                            'o' => input[3] switch
                            {
                                'b' => input.AsSpan(4).SequenceEqual("able") ? /* match 'probable' */ 967 : -1,
                                'p' => input.AsSpan(4).SequenceEqual("erty") ? /* match 'property' */ 968 : -1,
                                _ => -1,
                            },
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'q' => input[1] != 'u' ? -1 : input[2] switch
                    {
                        'e' => input.AsSpan(3).SequenceEqual("stion") ? /* match 'question' */ 969 : -1,
                        'o' => input.AsSpan(3).SequenceEqual("tient") ? /* match 'quotient' */ 970 : -1,
                        _ => -1,
                    },
                    'r' => input.AsSpan(1).SequenceEqual("emember") ? /* match 'remember' */ 971 : -1,
                    's' => input[1] switch
                    {
                        'e' => input[2] switch
                        {
                            'n' => input.AsSpan(3).SequenceEqual("tence") ? /* match 'sentence' */ 972 : -1,
                            'p' => input.AsSpan(3).SequenceEqual("arate") ? /* match 'separate' */ 973 : -1,
                            _ => -1,
                        },
                        'h' => input.AsSpan(2).SequenceEqual("oulder") ? /* match 'shoulder' */ 974 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("lution") ? /* match 'solution' */ 975 : -1,
                        't' => input.AsSpan(2).SequenceEqual("raight") ? /* match 'straight' */ 976 : -1,
                        'u' => input[2] switch
                        {
                            'b' => input.AsSpan(3).SequenceEqual("tract") ? /* match 'subtract' */ 977 : -1,
                            'r' => input.AsSpan(3).SequenceEqual("prise") ? /* match 'surprise' */ 978 : -1,
                            _ => -1,
                        },
                        'y' => input.AsSpan(2).SequenceEqual("llable") ? /* match 'syllable' */ 979 : -1,
                        _ => -1,
                    },
                    't' => input[1] switch
                    {
                        'h' => input.AsSpan(2).SequenceEqual("ousand") ? /* match 'thousand' */ 980 : -1,
                        'o' => input.AsSpan(2).SequenceEqual("gether") ? /* match 'together' */ 981 : -1,
                        'r' => input.AsSpan(2).SequenceEqual("iangle") ? /* match 'triangle' */ 982 : -1,
                        _ => -1,
                    },
                    _ => -1,
                },
                9 => input[0] switch
                {
                    'c' => input[1] switch
                    {
                        'h' => input.AsSpan(2).SequenceEqual("aracter") ? /* match 'character' */ 983 : -1,
                        'o' => input[2] != 'n' ? -1 : input[3] switch
                        {
                            'd' => input.AsSpan(4).SequenceEqual("ition") ? /* match 'condition' */ 984 : -1,
                            's' => input.AsSpan(4).SequenceEqual("onant") ? /* match 'consonant' */ 985 : -1,
                            't' => input.AsSpan(4).SequenceEqual("inent") ? /* match 'continent' */ 986 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'd' => input[1] switch
                    {
                        'e' => input.AsSpan(2).SequenceEqual("termine") ? /* match 'determine' */ 987 : -1,
                        'i' => input.AsSpan(2).SequenceEqual("fficult") ? /* match 'difficult' */ 988 : -1,
                        _ => -1,
                    },
                    'n' => input.AsSpan(1).SequenceEqual("ecessary") ? /* match 'necessary' */ 989 : -1,
                    'p' => input.AsSpan(1).SequenceEqual("aragraph") ? /* match 'paragraph' */ 990 : -1,
                    'r' => input.AsSpan(1).SequenceEqual("epresent") ? /* match 'represent' */ 991 : -1,
                    's' => input.AsSpan(1).SequenceEqual("ubstance") ? /* match 'substance' */ 992 : -1,
                    _ => -1,
                },
                10 => input[0] switch
                {
                    'd' => input.AsSpan(1).SequenceEqual("ictionary") ? /* match 'dictionary' */ 993 : -1,
                    'e' => input[1] switch
                    {
                        's' => input.AsSpan(2).SequenceEqual("pecially") ? /* match 'especially' */ 994 : -1,
                        'x' => !input.AsSpan(2, 4).SequenceEqual("peri") ? -1 : input[6] switch
                        {
                            'e' => input.AsSpan(7).SequenceEqual("nce") ? /* match 'experience' */ 995 : -1,
                            'm' => input.AsSpan(7).SequenceEqual("ent") ? /* match 'experiment' */ 996 : -1,
                            _ => -1,
                        },
                        _ => -1,
                    },
                    'i' => input.AsSpan(1).SequenceEqual("nstrument") ? /* match 'instrument' */ 997 : -1,
                    'p' => input.AsSpan(1).SequenceEqual("articular") ? /* match 'particular' */ 998 : -1,
                    _ => -1,
                },
                11 => input == "temperature" ? /* match 'temperature' */ 999 : -1,
                _ => -1,
            };
        }
    }

    public static int ShortSwitch_FirstCase()
        => ShortSwitchCore("GET");

    public static int ShortSwitch_SecondCase()
        => ShortSwitchCore("POST");

    public static int ShortSwitch_ThirdCase()
        => ShortSwitchCore("PUT");

    public static int ShortSwitch_FourthCase()
        => ShortSwitchCore("DELETE");

    private static int ShortSwitchCore(string s)
    {
        return s switch
        {
            "GET" => 0,
            "POST" => 1,
            "PUT" => 2,
            "DELETE" => 3,
            _ => 0
        };
    }

    public static int ShortSwitchLongWords_FirstCase()
        => ShortSwitchLongWordsCore("application/javascript");

    public static int ShortSwitchLongWords_SecondCase()
        => ShortSwitchLongWordsCore("application/octet-stream");

    public static int ShortSwitchLongWords_ThirdCase()
        => ShortSwitchLongWordsCore("text/html; charset=utf-8");

    public static int ShortSwitchLongWords_FourthCase()
        => ShortSwitchLongWordsCore("text/plain; charset=utf-8");

    private static int ShortSwitchLongWordsCore(string s)
    {
        return s switch
        {
            "application/javascript" => 0,
            "application/octet-stream" => 0,
            "text/html; charset=utf-8" => 0,
            "text/plain; charset=utf-8" => 0,
            "application/json; charset=utf-8" => 0,
            "application/x-www-form-urlencoded" => 0,
            _ => 0
        };
    }
}