public class TestScenariosCore
{
    public static int Switch1()
    {
        var x = "abc";
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
}