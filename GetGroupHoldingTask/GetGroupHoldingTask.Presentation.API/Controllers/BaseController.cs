using Microsoft.AspNetCore.Mvc;
using SharedKernal.Common;
using SharedKernal.Middlewares.Basees;

namespace GetGroupHoldingTask.Presentation.API.Controllers
{
   
    [ApiController]
    [Route(APIRoute.VersioningTemplate)]
    public abstract class BaseController : ControllerBase
    {
        #region Properties
        public Presenter Presenter { get; set; }
        #endregion

      
    }
}
