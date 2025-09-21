using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Models.Exceptions
{
    public class BusinessException: Exception
    {
        public string LogCategory;

        public BusinessException(string message, string logCategory, Exception innerException = null): base(message, innerException)
        {
            LogCategory = logCategory;
        }
    }
}
