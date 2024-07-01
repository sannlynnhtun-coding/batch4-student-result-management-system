using Batch4.Api.StudentResultManagement.BusinessLogic.Services;
using Batch4.Api.StudentResultManagement.BusinessLogic.Services.Course;
using Batch4.Api.StudentResultManagement.BusinessLogic.Services.Result;
using Batch4.Api.StudentResultManagement.BusinessLogic.Services.Student;
using Batch4.Api.StudentResultManagement.DataAccess.Db;
using Batch4.Api.StudentResultManagement.DataAccess.Services.Course;
using Batch4.Api.StudentResultManagement.DataAccess.Services.Result;
using Batch4.Api.StudentResultManagement.DataAccess.Services.Student;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

//Course
builder.Services.AddScoped<DA_Course>();
builder.Services.AddScoped<BL_Course>();

//Student
builder.Services.AddScoped<DA_Student>();
builder.Services.AddScoped<BL_Student>();

//Result
builder.Services.AddScoped<DA_Result>();
builder.Services.AddScoped<BL_Result>();

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
