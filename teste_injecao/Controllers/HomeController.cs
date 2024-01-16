using Microsoft.AspNetCore.Mvc;
using teste_injecao.Core.Services;

namespace teste_injecao.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		//private readonly IExampleInterface _transientService;
		//private readonly IExampleInterface _scopedService;
		//private readonly IExampleInterface _singletonService;

		public HomeController(
			ILogger<HomeController> logger
			// Jeito normal
			//IExampleInterface transientService,
			//IExampleInterface scopedService,
			//IExampleInterface singletonService
			)
		{
			_logger = logger;
			// Jeito normal
			//_transientService = transientService;
			//_scopedService = scopedService;
			//_singletonService = singletonService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy(
			// Jeito para ser chamado no método
			[FromServices] ServiceTransient transientService,
			[FromServices] ServiceScoped scopedService,
			[FromServices] ServiceSingleton singletonService)
		{
			// Jeito normal
			//_transientService.ViewMessage();
			//_scopedService.ViewMessage();
			//_singletonService.ViewMessage();
			//_logger.LogInformation($"Transient: {_transientService.GetInstanceCount()}, Scoped: {_scopedService.GetInstanceCount()}, Singleton: {_singletonService.GetInstanceCount()}");

			// Jeito para ser chamado no método
			transientService.ViewMessage();
			scopedService.ViewMessage();
			singletonService.ViewMessage();
			_logger.LogInformation($"Privacy foi acessado. Transient: {transientService.GetInstanceCount()}, Scoped: {scopedService.GetInstanceCount()}, Singleton: {singletonService.GetInstanceCount()}");

			return View();
		}
	}
}
