using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Ōhara.Doppler.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class MasterController : Controller
    {

    }
}