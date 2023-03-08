using System.Runtime.CompilerServices;

namespace TCA.Shared;

public class CorrectionResult
{
    public string Text { get; set; } = "";
    public int Elapsed { get; set; } = 0;
    public List<Keyword> Keywords { get; set; } = new();
}

public class Keyword
{
    public Keyword()
    {

    }

    public Keyword(string text)
    {
        Name = text;
    }

    public Keyword(string text, string basic)
    {
        Name = text;
        Basic = new(basic);
    }
    public Keyword(string text, Keyword basic)
    {
        Name = text;
        Basic = basic;
    }

    public Keyword(string text, string basic, IEnumerable<string> compatibleWith)
    {
        Name = text;
        Basic = new(basic);
        CompatibleWith = compatibleWith.Select(c => new Keyword(c)).ToList();
    }
    public Keyword(string text, string basic, IEnumerable<Keyword> compatibleWith)
    {
        Name = text;
        Basic = new(basic);
        CompatibleWith = compatibleWith.ToList();
    }

    public Keyword(string text, Keyword basic, IEnumerable<string> compatibleWith)
    {
        Name = text;
        Basic = basic;
        CompatibleWith = compatibleWith.Select(c => new Keyword(c)).ToList();
    }
    public Keyword(string text, Keyword basic, IEnumerable<Keyword> compatibleWith)
    {
        Name = text;
        Basic = basic;
        CompatibleWith = compatibleWith.ToList();
    }

    /// <summary>
    /// Name (value) of keyword.
    /// </summary>
    /// <example>C#</example>
    public string Name { get; set; } = "";

    /// <summary>
    /// (Optional) null if basic.
    /// </summary>
    public Keyword? Basic { get; set; }

    /// <summary>
    /// List of keywords, that compatible with current.
    /// </summary>
    /// <example>C# -> .NET, Programming</example>
    public List<Keyword> CompatibleWith { get; set; } = new List<Keyword>();
}