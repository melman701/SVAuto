using System;

namespace SVAuto.BL.Handlers
{
    public static class HandlerResultFactory
    {
        public static HandlerResult<TResult> GetSuccessResult<TResult>(TResult result)
        {
            return new HandlerResult<TResult>(result);
        }

        public static HandlerResult<TResult> GetFailResult<TResult>(string message)
        {
            return new HandlerResult<TResult>(new Exception(message));
        }

        public static HandlerResult<TResult> GetFailResult<TResult>(Exception exception)
        {
            return new HandlerResult<TResult>(exception);
        }

        public static HandlerResult<TResult> GetFailResult<TResult>(TResult result, Exception exception)
        {
            return new HandlerResult<TResult>();
        }

        public static HandlerResult GetFailResult(string message)
        {
            return new HandlerResult(new Exception(message));
        }

        public static HandlerResult GetSuccessResult()
        {
            return new HandlerResult();
        }
    }
}
