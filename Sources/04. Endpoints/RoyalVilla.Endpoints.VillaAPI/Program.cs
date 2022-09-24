using RoyalVilla.Core.Contracts.Villas;
using RoyalVilla.Infrastructures.DAL.EF.Villas;
using RoyalVilla.Endpoints.VillaAPI;
using RoyalVilla.Infrastructures.DAL.EF.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<IVillaRepository, VillaRepository>();


// AutoMapper Configuration -----------------------------------------------------------------------
builder.Services.AddAutoMapper(typeof(MappingConfig));
//-------------------------------------------------------------------------------------------------


// Headers configuration for accepting "Application/XML" content ----------------------------------
builder.Services.AddControllers(options =>
{
    //options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
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
