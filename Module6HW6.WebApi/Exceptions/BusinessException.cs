using System;

namespace Module6HW5.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
