using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importer.Models
{
    public class ImporterResponse<T>
    {
        public int Code { get; set; }

        public string Msg { get; set; }

        public T Data { get; set; }

        public static ImporterResponse<T> GetResult(int code, string msg, T data = default(T))
        {
            return new ImporterResponse<T>
            {
                Code = code,
                Msg = msg,
                Data = data
            };
        }
    }
}
