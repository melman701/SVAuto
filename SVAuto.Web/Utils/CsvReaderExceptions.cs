using System;

namespace SVAuto.Web.Utils
{
    public class NoRequiredHeadersException : Exception
    {
        public NoRequiredHeadersException(string msg)
            : base(msg)
        {

        }

        public NoRequiredHeadersException()
        {

        }
    }

    public class CsvFileNotFoundException : Exception
    {
        public CsvFileNotFoundException(string msg)
            : base(msg)
        {

        }

        public CsvFileNotFoundException()
        {

        }
    }
}
