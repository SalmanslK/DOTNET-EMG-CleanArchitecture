using CleanArchitecture.API.Attributes;
using CleanArchitecture.Business.Decorators;
using CleanArchitecture.Business.Interfaces;
using CleanArchitecture.Business.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidateModelStateAttribute)))
                .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();

builder.Services.Decorate<IEmployeeService, EmployeeServiceLoggingDecorator>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
