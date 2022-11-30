
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
}