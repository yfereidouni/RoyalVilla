using RoyalVilla.Core.Contracts.Villas;
using RoyalVilla.Core.Entities.Villas;
using RoyalVilla.Endpoints.VillaAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IVillaRepository, VillaRepository>();

// AutoMapper Configuration -----------------------------------------------------------------------
builder.Services.AddAutoMapper(typeof(MappingConfig));
//-------------------------------------------------------------------------------------------------


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

app.Run();
