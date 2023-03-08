using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCA.Shared;

namespace TCA.SearchEngineCorrection;

public class MLAlgorithm : IAlgorithm
{
    MLContext mlContext;
    bool isSetupped;

    public void Setup()
    {
        var trainingData = mlContext.Data.LoadFromTextFile<MLInputData>("training-data.txt", separatorChar: '\t', hasHeader: true);


    }


    public CorrectionResult Convert(string input)
    {
        if (!isSetupped)
        {
            Setup();
        }

        // Load the model
        var modelPath = "path/to/exported/model.zip";
        var model = mlContext.Model.Load(modelPath, out var modelSchema);

        // Use the model to predict the class of a new prompt
        var prompt = new PromptData() { Prompt = "What is the capital of France?" };
        var predictor = mlContext.Model.CreatePredictionEngine<PromptData, PromptPrediction>(model);
        var prediction = predictor.Predict(prompt);

        throw new NotImplementedException();
    }
}
class MLInputData
{
    [LoadColumn(0)] public string Text { get; set; }
}

// Define data structure for output keywords
class MLOutputData
{
    public string[] Keywords { get; set; }
}