using teste_injecao.Core.Services;

namespace teste_injecao
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Jeito normal de declarar a injeção de dependência
			//builder.Services.AddTransient<IExampleInterface, ServiceTransient>();
			//builder.Services.AddScoped<IExampleInterface, ServiceScoped>();
			//builder.Services.AddSingleton<IExampleInterface, ServiceSingleton>();

			// Jeito para ser chamado no método
			builder.Services.AddTransient<ServiceTransient>();
			builder.Services.AddScoped<ServiceScoped>();
			builder.Services.AddSingleton<ServiceSingleton>();

			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}