using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCA.Shared;

namespace TCA.SearchEngineCorrection;

public interface IAlgorithm
{
    public CorrectionResult Convert(string input);
}
