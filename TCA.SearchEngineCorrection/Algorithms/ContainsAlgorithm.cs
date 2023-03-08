using System.Diagnostics;
using TCA.Shared;
using TCA.Utilities;

namespace TCA.SearchEngineCorrection;

public class ContainsAlgorithm : IAlgorithm
{
    readonly List<Keyword> keywords = new();
    public CorrectionResult Convert(string input)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        if (string.IsNullOrWhiteSpace(input))
        {
            stopWatch.Stop();
            throw new ArgumentNullException(nameof(input));
        }
        foreach (var type in (PromptType[])Enum.GetValues(typeof(PromptType)))
        {
            if (input.ContainsInvariant(type.ToString().ReplacePascalCase()))
            {
                input = input.ReplaceInvariant(type.ToString().ReplacePascalCase(), "");
                input = SwapParasitic(input);
            }
        }
        stopWatch.Stop();
        return new CorrectionResult() { Text = input, Elapsed = (int)stopWatch.ElapsedMilliseconds, Keywords = keywords };
    }
    public string SwapParasitic(string str)
    {
        var result = str;
        if (string.IsNullOrWhiteSpace(str))
        {
            throw new ArgumentNullException(nameof(str));
        }
        if (str.ContainsInvariant(" " + ParasiticWords.The.ToString() + " "))
        {
            result = result.ReplaceInvariant(" " + ParasiticWords.The.ToString() + " ", "")[1..];
        }
        if (str.ContainsInvariant(" " + ParasiticWords.Of.ToString() + " "))
        {
            var index = result.IndexOfInvariant(" " + ParasiticWords.Of.ToString() + " ");
            var firstPart = result[..index][1..];
            var secoundPart = result[(index + (" " + ParasiticWords.Of.ToString() + " ").Length)..];
            result = secoundPart + " " + firstPart;
            result = result.ReplaceSymbols();
            keywords.Add(new(secoundPart)); // which are versions of python -> python
        }
        return result;
    }
}