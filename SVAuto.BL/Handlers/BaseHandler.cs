using Microsoft.Extensions.Logging;

namespace SVAuto.BL.Handlers
{
    public class BaseHandler
    {
        protected readonly ILogger logger;

        public BaseHandler(ILogger logger)
        {
            this.logger = logger;
        }
    }
}
