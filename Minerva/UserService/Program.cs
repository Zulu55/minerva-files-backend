using SharedLibrary.Data;
using UserService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configure database

//builder.Services.AddScoped<IDataConext, DataContext>();

var configuration = builder.Configuration;

builder.Services.AddTransient<IDbContextConfigurator>(provider =>
{
    var providerName = configuration["DatabaseProvider"] ?? "";
    var connectionString = configuration.GetConnectionString(providerName == "MySQL" ? "MySqlConnection" : "SqlServerConnection") ?? "";
    return DbContextConfiguratorFactory.CreateConfigurator(providerName, connectionString);
});

builder.Services.AddDbContext<DataContext>((serviceProvider, options) =>
{
    var configurator = serviceProvider.GetRequiredService<IDbContextConfigurator>();
    configurator.Configure(options);
});

#endregion Configure database

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
           .AllowAnyMethod()
           .AllowAnyHeader()
           .SetIsOriginAllowed(origin => true)
           .AllowCredentials());

app.Run();