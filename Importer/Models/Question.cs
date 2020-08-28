using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importer.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string Type { get; set; }
        public string Type2 { get; set; }
        public string Section { get; set; }
        public string Qnum { get; set; }
        public string Content { get; set; }
        public int Response01 { get; set; }
        public int Response02 { get; set; }
        public int Response03 { get; set; }
        public int Response04 { get; set; }
        public int CorrectAnswer { get; set; }
        public string Code { get; internal set; }
    }
}
