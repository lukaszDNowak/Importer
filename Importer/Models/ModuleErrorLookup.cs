using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importer.Models
{
    public class ModuleErrorLookup
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string Section { get; set; }
        public string Qnum { get; set; }
        public string Target { get; set; }
        public string Actual { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
        public string Code { get; internal set; }
    }
}
