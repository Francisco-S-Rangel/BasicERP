using Microsoft.EntityFrameworkCore;
using BasicERP.Persistence.Context;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DbConnection");

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(project =>
    {
        project.SwaggerDoc("v1", new OpenApiInfo 
        { 
            Title = "BasicERP", 
            Version = "v1",
            Description = "Basic ERP API for study purposes"
        });
    }
);

builder.Services.AddDbContext<BasicERPContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
                    
            }
        );
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "BasicERP v1");
        options.RoutePrefix = "swagger";
    });
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
