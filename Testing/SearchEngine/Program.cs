// See https://aka.ms/new-console-template for more information
using TCA.SearchEngineCorrection;
using TCA.Utilities;

var algorithm = new ContainsAlgorithm();
while (true)
{
    Console.Write("Enter your prompt: ");
    var prompt = Console.ReadLine();
    Console.WriteLine("After converting: " + algorithm.Convert(prompt).Text);
}