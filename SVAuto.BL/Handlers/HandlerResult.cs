using System;
using System.Collections.Generic;
using System.Linq;

namespace SVAuto.BL.Handlers
{
    public class HandlerResult<TResult>
    {
        public TResult Data { get; set; }
        public List<Exception> Errors { get; } = new List<Exception>();

        public Exception FirstError => Errors.FirstOrDefault();
        public bool Success => FirstError == null;

        public HandlerResult()
        {

        }

        public HandlerResult(TResult result)
        {
            Data = result;
        }

        public HandlerResult(Exception exception)
        {
            Errors.Add(exception);
        }

        public HandlerResult(TResult result, Exception exception)
        {
            Data = result;
            Errors.Add(exception);
        }
    }


    public class HandlerResult
    {
        public List<Exception> Errors { get; } = new List<Exception>();

        public Exception FirstError => Errors.FirstOrDefault();
        public bool Success => FirstError == null;

        public HandlerResult()
        {

        }

        public HandlerResult(Exception exception)
        {
            Errors.Add(exception);
        }
    }
}
