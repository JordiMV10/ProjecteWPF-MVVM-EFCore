using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Lib.Infrastructure
{
    public class ValidationResult
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public IQueryable<string> ErrorsQueryAll()   //Meu para probar lista errores en StudentsView. Puede borrarse
        {
            // return ProjectDbContext.Set<T>().AsQueryable();
            return Errors.AsQueryable();
        }

        public string AllErrors
        {
            get
            {
                var output = string.Empty;

                foreach (var error in Errors)
                    output += error + "\n\r";

                return output;
            }
        }
    }

    public class ValidationResult<T> : ValidationResult
    {
        public T ValidatedResult { get; set; }
    }
}
