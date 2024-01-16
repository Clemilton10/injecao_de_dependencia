using Api.Repositories;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);


// Abrindo o arquivo appsettings.json
builder.Configuration
	.AddJsonFile(
		"appsettings.json",
		optional: false,
		reloadOnChange: true
	);

// Pegando a string de conexao do appsettings.json
string connectionString = builder.Configuration
	.GetConnectionString("sqlServerDb");

// Configure o banco de dados
builder.Services
	.AddDbContext<AppDbContext>(
		options =>
		//options.UseSqlite(connectionString)
		options.UseSqlServer(connectionString)
	);

// Registre o repositorio no container de injecao de dependencia
builder.Services.AddScoped<ILivroRepository, LivroRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication? app = builder.Build();

// Cria o banco de dados e aplica as migracoes na inicializacao
using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider
	.GetRequiredService<AppDbContext>();
	dbContext.Database.EnsureCreated();
	// dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
