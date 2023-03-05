using TCA.Shared;
using TCA.Utilities;

namespace TCA.SearchEngineCorrection;

public class ContainsAlgorithm : IAlgorithm
{
    public CorrectionResult Convert(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(nameof(input));
        }
        foreach (var type in (PromptType[])Enum.GetValues(typeof(PromptType)))
        {
            if (input.ContainsInvariant(type.ToString().ReplacePascalCase()))
            {
                input = input.ReplaceInvariant(type.ToString().ReplacePascalCase(), "")[1..];
                input = SwapParasitic(input);
            }
        }
        return new CorrectionResult() { Text = input };
    }
    public static string SwapParasitic(string str)
    {
        var result = str;
        if (string.IsNullOrWhiteSpace(str))
        {
            throw new ArgumentNullException(nameof(str));
        }
        if (str.ContainsInvariant(ParasiticWords.The.ToString()))
        {
            result = result.ReplaceInvariant(ParasiticWords.The.ToString(), "")[1..];
        }
        if (str.ContainsInvariant(ParasiticWords.Of.ToString()))
        {
            var index = result.IndexOfInvariant(ParasiticWords.Of.ToString());
            var firstPart = result[..(index - 1)];
            var secoundPart = result.Substring(index + ParasiticWords.Of.ToString().Length, result.Length - (index + ParasiticWords.Of.ToString().Length));
            secoundPart = secoundPart[1..];
            result = secoundPart + " " + firstPart;
        }
        return result;
    }
}