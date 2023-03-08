# TCA
TCA - Text Correction Algorithm

# Getting Started
## Search Engine Correction
### First way (via Package Manager Console):
1. Open Package Manager Console in Visual Studio
2. Enter: `NuGet\Install-Package TCA.SearchEngineCorrection`

### Secound way (via command line):
1. Open cmd/bash/PowerShell
2. Enter `dotnet add package TCA.SearchEngineCorrection`

### Third way (via UI):
1. Open tab for installing NuGet Packages.
2. Search for `TCA.SearchEngineCorrection`

# Examples
## Search Engine Correction
### Clear parasitic (for search engine) words:

```csharp
using TCA.SearchEngineCorrection;
var algorithm = new ContainsAlgorithm();
var result = algorithm.Convert("<your-prompt>");
```
That will be give this result: 
<br /> What is .NET -> .NET
<br /> Which is latest version of C# -> C# latest version
