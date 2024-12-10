# Let's get created a web API with ASP.net and C#

First let's add dependancies,

Ensure you've already had dotnet-ef installed on your computer, otherwise, install it globally

```dotnet tool install --global dotnet-ef```

Then install, the project dependancies

```
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
``` 

### Compiler et executer le programme avec
```dotnet run```

Le port de lecture est http://localhost:5139/

### Le programme principal doit implémenter cette structure : 
```
using Data;

Seed.Init();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
```
