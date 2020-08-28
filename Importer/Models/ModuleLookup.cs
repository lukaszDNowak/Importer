using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importer.Models
{
    public class ModuleLookup
    {
        public int Id { get; set; }

        public int StandardScore { get; set; }
        public int Band { get; set; }
        public  string Summary { get; set; }
        public  string SkillLevel { get; set; }
        public string Code { get; internal set; }
    }
}
