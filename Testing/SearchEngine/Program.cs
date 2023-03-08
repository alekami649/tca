// See https://aka.ms/new-console-template for more information
using TCA.SearchEngineCorrection;

var algorithm = new ContainsAlgorithm();
while (true)
{
    Console.Write("Enter your prompt: ");
    var prompt = Console.ReadLine();
    var result = algorithm.Convert(prompt);
    Console.WriteLine("Text: " + result.Text);
    Console.WriteLine("Elapsed (in millisecounds): " + result.Elapsed);
    Console.WriteLine("Keywords: " + string.Join(", ", result.Keywords));
}