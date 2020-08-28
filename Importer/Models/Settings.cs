using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importer.Models
{
    public class Settings
    {
        public int id { get; set; }
        public int ModuleNumber { get; set; }
        public string Language { get; set; }

        public string Type { get; set; }

        public int Timer { get; set; }


        public string CountdownTimer { get; set; }

        public string FinishAfterCorrectInRow { get; set; }
        public string FinishAfterIncorrectInRow { get; set; }

        public string FinishAfterCorrectTotal { get; set; }

        public string FinishAfterIncorrectTotal { get; set; }

        public string MarkAsProbablyGuessAfterXIncorrectAnswersInRow { get; set; }

        public string MarkAsProbablyGuessAfterXIncorrectAnswersAditional { get; set; }
        public string MarkAsProbablyGuessAfterXIncorrectAnswersMultiplication { get; set; }

        public string Calculator { get; set; }

        public string ReportSummary { get; set; }
        public string ReportSections { get; set; }
        public string ReportFull { get; set; }
        public string Code { get; internal set; }
    }
}
