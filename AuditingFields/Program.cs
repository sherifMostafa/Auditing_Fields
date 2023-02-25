using AuditingFields.Persistence;
using AuditingFields.Repository;
using AuditingFields.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<UpdateAuditableEntitiesInterceptor>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 
builder.Services.AddScoped<IMemberRepository, MemeberRepository>();
builder.Services.AddDbContext<ApplicationDbContext>( (sp , optionBuilder) =>
{
       var auditableInterceptor = sp.GetService<UpdateAuditableEntitiesInterceptor>()!;
       optionBuilder.UseSqlServer("name=ConnectionStrings:AuditingDatabase" ,o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
       .AddInterceptors(auditableInterceptor);
});

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
