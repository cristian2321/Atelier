string version = "v1";
string title = "Atelier";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=> c.SwaggerDoc(version, 
    new() {Title = title, Version = version }));

var app = builder.Build();

app.Run();
