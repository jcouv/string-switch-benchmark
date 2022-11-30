
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
}