using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importer.Models
{
    public class Module
    {
        public Module()
        {
            Questions = new List<Question>();
            Settings = new List<Settings>();
            MultiplicationStdScores = new List<MultiplicationStdScores>();
            ModuleLookups = new List<ModuleLookup>();
            ModuleErrorLookups = new List<ModuleErrorLookup>();
            AdditionStdScores = new List<AdditionStdScore>();
        }

        public int Id { get; set; }
        public int ModuleNumber { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual List<Settings> Settings { get; set; }

        public virtual List<MultiplicationStdScores> MultiplicationStdScores { get; set; }
        public virtual List<ModuleLookup> ModuleLookups { get; set; }
        public virtual List<ModuleErrorLookup> ModuleErrorLookups { get; set; }
        public virtual List<AdditionStdScore> AdditionStdScores { get; set; }
        public virtual string Code { get; set; }
    }
}
