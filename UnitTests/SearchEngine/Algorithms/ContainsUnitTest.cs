using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Algorithms;

[TestFixture]
public class ContainsUnitTest
{
    ContainsAlgorithm algorithm;

    [SetUp]
    public void Setup()
    {
        algorithm = new ContainsAlgorithm();
    }

    [Test]
    public void Convert_()
    {
        var input = "What is .NET";
        var expected = ".NET";
        var actual = algorithm.Convert(input);
        Is.EqualTo(expected);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
