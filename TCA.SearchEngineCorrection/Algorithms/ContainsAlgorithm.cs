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
                input = input.ReplaceInvariant(type.ToString().ReplacePascalCase(), "").Substring(1);
            }
        }
        return new CorrectionResult() { Text = input };
    }
}