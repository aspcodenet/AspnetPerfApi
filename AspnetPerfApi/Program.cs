using AspnetPerfApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/players/{id}", (String id) =>
{
    var resp = Data.Deserialize();
    System.Threading.Thread.Sleep(10);
    resp.Hits.Hits[0]._Id = id;
    return resp.Hits.Hits[0];


});


app.MapGet("/players", () =>
{
    var resp = Data.Deserialize();
    System.Threading.Thread.Sleep(10);
    FibonacciIterative(20);
    return resp;


});

static int FibonacciIterative(int n)
{
    if (n <= 1)
    {
        return n;
    }

    int n2 = 0;
    int n1 = 1;

    for (int i = 2; i <= n; i++)
    {
        (n2, n1) = (n1, n1 + n2); // Using tuple deconstruction for the swap
    }

    return n1;
}



app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");


app.Run();


internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
