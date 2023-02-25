using Microsoft.AspNetCore.Mvc;

namespace MelVincentAnonuevo_COMP306_Lab2.Controllers
{
    [ApiController]
    public abstract class BaseController<T> : Controller
    {
        protected readonly ILogger<T> _logger;

        public BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}