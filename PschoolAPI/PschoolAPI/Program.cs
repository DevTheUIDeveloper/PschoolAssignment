using Microsoft.EntityFrameworkCore;
using Pschool.Business;
using Pschool.Business.Mapping;
using Pschool.DAL;
using Pschool.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<PschoolDbContext>(options =>
        options.UseInMemoryDatabase("PschoolDb"));

builder.Services.AddScoped<IRepositoryBase<Parent>, RepositoryBase<Parent>>();
builder.Services.AddScoped<IRepositoryBase<Student>, RepositoryBase<Student>>();

builder.Services.AddScoped<IParentService, ParentService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


SeedData(app.Services);

app.Run();


void SeedData(IServiceProvider serviceProvider)
{
    using (var scope = serviceProvider.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<PschoolDbContext>();
        if (!dbContext.Students.Any())
        {
            var parents = new List<Parent>
                    {
                        new Parent { Id = 1, FirstName = "First", LastName = "Parent", Email = "parent1@example.com" },
                        new Parent { Id = 2, FirstName = "Second", LastName = "Parent", Email = "parent2@example.com" }
                    };

            dbContext.Parents.AddRange(parents);
            dbContext.SaveChanges();

            var students = new List<Student>
                    {
                        new Student { Id = 1, FirstName = "John", LastName= "Doe", Age = 18, ParentId = 1 },
                        new Student { Id = 2, FirstName = "Jane", LastName="Smith", Age = 20, ParentId = 1 }
                    };

            dbContext.Students.AddRange(students);
            dbContext.SaveChanges();
        }
    }
}