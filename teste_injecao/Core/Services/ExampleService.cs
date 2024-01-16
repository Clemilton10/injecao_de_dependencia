using teste_injecao.Core.Interfaces;

namespace teste_injecao.Core.Services
{
	public class ServiceTransient : IExampleInterface
	{
		private readonly ILogger<ServiceTransient> _logger;
		private static int instanceCount = 0;
		public ServiceTransient(ILogger<ServiceTransient> logger)
		{
			instanceCount++;
			_logger = logger;
		}
		public int GetInstanceCount()
		{
			return instanceCount;
		}
		public void ViewMessage()
		{
			_logger.LogInformation("Serviço Transient");
		}
	}

	public class ServiceScoped : IExampleInterface
	{
		private readonly ILogger<ServiceScoped> _logger;
		private static int instanceCount = 0;
		public ServiceScoped(ILogger<ServiceScoped> logger)
		{
			instanceCount++;
			_logger = logger;
		}
		public int GetInstanceCount()
		{
			return instanceCount;
		}
		public void ViewMessage()
		{
			_logger.LogInformation("Serviço Scoped");
		}
	}

	public class ServiceSingleton : IExampleInterface
	{
		private readonly ILogger<ServiceSingleton> _logger;
		private static int instanceCount = 0;
		public ServiceSingleton(ILogger<ServiceSingleton> logger)
		{
			instanceCount++;
			_logger = logger;
		}
		public int GetInstanceCount()
		{
			return instanceCount;
		}
		public void ViewMessage()
		{
			_logger.LogInformation("Serviço Singleton");
		}
	}

}
