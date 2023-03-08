using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace TCA.Shared;

public class CorrectionInput
{
    public CorrectionInput()
    {

    }

    public CorrectionInput(string text)
    {
        Text = text;
    }

    public string Text { get; set; } = "";
}
