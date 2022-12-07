using System.Text;

class C
{
    static int indent = 0;
    static StringBuilder sb = new();

    static void Main(string[] args)
    {
        var words = GetWords();
        WriteLine("class C");
        WriteLine("{");
        indent++;

        WriteLine("static int M1(string input)");
        WriteLine("{");
        indent++;
        Generate1(words);
        indent--;
        WriteLine("}");


        WriteLine("static int M2(string input)");
        WriteLine("{");
        indent++;
        Generate2(words);
        indent--;
        WriteLine("}");

        indent--;
        WriteLine("}");

        System.Console.WriteLine(sb.ToString());
    }

    private static void Write(string value)
    {
        sb.Append(new string(' ', indent * 4));
        sb.Append(value);
    }

    private static void WriteLine(string value)
    {
        sb.Append(new string(' ', indent * 4));
        sb.AppendLine(value);
    }

    private static void Generate1(IEnumerable<string> words)
    {
        var groups = words.GroupBy(w => w.Length);
        var orderedGroups = groups.OrderBy(g => g.Key).ToList();

        WriteLine("return input switch");
        WriteLine("{");
        indent++;

        var result = 0;
        foreach (var group in orderedGroups)
        {
            foreach (var value in group)
            {
                WriteLine($"\"{value}\" => {result++},");
            }
        }

        WriteLine($"_ => -1,");
        indent--;
        WriteLine("};");
    }

    private static void Generate2(IEnumerable<string> words)
    {
        var groups = words.GroupBy(w => w.Length);
        var orderedGroups = groups.OrderBy(g => g.Key).ToList();

        WriteLine("return input.Length switch");
        WriteLine("{");
        indent++;

        var result = 0;
        foreach (var group in orderedGroups)
        {
            Write($"{group.Key} => ");
            Recurse(group.Key, group, currentIndex: 0, ref result);
        }

        WriteLine($"_ => -1,");
        indent--;
        WriteLine("};");
    }

    private static void Recurse(int groupWordLength, IEnumerable<string> groupWords, int currentIndex, ref int result)
    {
        var groupWordsList = groupWords.ToList();
        if (groupWordsList.Count == 1)
        {
            var singleWord = groupWordsList[0];

            if (currentIndex == 0)
            {
                sb.AppendLine($"input == \"{singleWord}\" ? /* match '{singleWord}' */ {result++} : -1,");
            }
            else if (currentIndex == groupWordLength - 1)
            {
                sb.AppendLine($"input[{currentIndex}] == '{Escape(singleWord[currentIndex])}' ? /* match '{singleWord}' */ {result++} : -1,");
            }
            else
            {
                //sb.AppendLine($"input.AsSpan({currentIndex}).SequenceEqual(\"{singleWord.Substring(currentIndex)}\") ? /* match '{singleWord}' */ {result++} : -1,");
                sb.AppendLine($"input == \"{singleWord}\") ? /* match '{singleWord}' */ {result++} : -1,");
            }
        }
        else
        {
            var groupByCharacter = groupWords.GroupBy(s => s[currentIndex]).OrderBy(g => g.Key).ToList();

            //if (groupByCharacter.Count == 1)
            //{
            //    var childGroup = groupByCharacter[0];

            //    ProcessTrivialGroup(groupWordLength, childGroup, currentIndex, ref result);
            //}
            //else
            {
                sb.AppendLine($"input[{currentIndex}] switch");
                WriteLine("{");
                indent++;
                foreach (var childGroup in groupByCharacter)
                {
                    if (currentIndex + 1 == groupWordLength)
                    {
                        var word = childGroup.Single();
                        WriteLine($"'{Escape(childGroup.Key)}' => /* match '{word}' */ {result++},");
                    }
                    else
                    {
                        Write($"'{Escape(childGroup.Key)}' => ");
                        Recurse(groupWordLength, childGroup, currentIndex + 1, ref result);
                    }
                }

                WriteLine($"_ => -1,");
                indent--;
                WriteLine("},");
            }
        }
    }

    private static void ProcessTrivialGroup(int groupWordLength, IGrouping<char, string> childGroup, int currentIndex, ref int result)
    {
        // Write($"if (");

        var startingIndex = currentIndex;

        while (true)
        {
            // sb.Append($"input[{currentIndex}] == '{Escape(childGroup.Key)}'");

            currentIndex++;
            if (currentIndex == groupWordLength)
            {
                break;
            }
            else
            {
                var childGroups = childGroup.GroupBy(s => s[currentIndex]).OrderBy(g => g.Key).ToList();
                if (childGroups.Count == 1)
                {
                    // sb.Append(" && ");
                    childGroup = childGroups.Single();
                    continue;
                }
                else
                {
                    break;
                }
            }
        }

        if (currentIndex == startingIndex + 1)
        {
            sb.Append($"input[{startingIndex}] != '{Escape(childGroup.Key)}'");
        }
        else
        {
            var length = currentIndex - startingIndex;
            sb.Append($"!input.AsSpan({startingIndex}, {length}).SequenceEqual(\"{childGroup.First().Substring(startingIndex, length)}\")");
        }


        //  sb.AppendLine(")");

        // WriteLine($"if (input[{currentIndex}] == '{Escape(childGroup.Key)}')");
        if (currentIndex == groupWordLength)
        {
            var word = childGroup.Single();
            sb.AppendLine($" ? -1 : /* match '{word}' */ {result++},");
        }
        else
        {
            sb.Append(" ? -1 : ");
            indent++;
            Recurse(groupWordLength, childGroup, currentIndex, ref result);
            indent--;
        }
    }

    private static string Escape(char key)
    {
        return key switch
        {
            '\'' => "\\'",
            _ => key.ToString(),
        };
    }

    //private static void CheckRemainder(int currentIndex, IGrouping<char, string> grouping)
    //{
    //    WriteLine($"if (input[{currentIndex}] != '{grouping.Key}')");
    //    WriteLine($"    return;");
    //}

    private static List<string> GetWords()
    {
        return new List<string> {
            "xxxxx-xxxxx-xxxxx-xxxxx-aaA",
            "xxxxx-xxxxx-xxxxx-xxxxx-aia",
            "xxxxx-xxxxx-xxxxx-xxxxx-aqi",
            "xxxxx-xxxxx-xxxxx-xxxxx-ayq",
            "xxxxx-xxxxx-xxxxx-xxxxx-aAy",
            "xxxxx-xxxxx-xxxxx-xxxxx-iaA",
            "xxxxx-xxxxx-xxxxx-xxxxx-iia",
            "xxxxx-xxxxx-xxxxx-xxxxx-iqi",
            "xxxxx-xxxxx-xxxxx-xxxxx-iyq",
            "xxxxx-xxxxx-xxxxx-xxxxx-iAy",
            "xxxxx-xxxxx-xxxxx-xxxxx-qaA",
            "xxxxx-xxxxx-xxxxx-xxxxx-qia",
            "xxxxx-xxxxx-xxxxx-xxxxx-qqi",
            "xxxxx-xxxxx-xxxxx-xxxxx-qyq",
            "xxxxx-xxxxx-xxxxx-xxxxx-qAy",
            "xxxxx-xxxxx-xxxxx-xxxxx-yaA",
            "xxxxx-xxxxx-xxxxx-xxxxx-yia",
            "xxxxx-xxxxx-xxxxx-xxxxx-yqi",
            "xxxxx-xxxxx-xxxxx-xxxxx-yyq",
            "xxxxx-xxxxx-xxxxx-xxxxx-yAy"
        };
    }
}
