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


app.MapGet("/players/{id}", async (String id) =>
{
    var resp = Data.Deserialize();
    //Thread.Sleep(10); // Simulate a delay - anropa en databas
    await Task.Delay(10); // Simulate a delay - anropa en databas
    resp.Hits.Hits[0]._Id = id;
    return resp.Hits.Hits[0];


});


app.MapGet("/players",async  () =>
{
    var resp = Data.Deserialize();
    //Thread.Sleep(10); // Simulate a delay - anropa en databas
    await Task.Delay(10); // Simulate a delay - anropa en databas
    FibonacciIterative(50);
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





app.Run();


