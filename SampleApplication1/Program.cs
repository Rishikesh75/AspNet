var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hi This is sample Project...");

app.Run(async (HttpContext context) =>
{
    var queryParams = context.Request.Query.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString());

    if (queryParams.ContainsKey("FirstNumber") && queryParams.ContainsKey("SecondNumber") && queryParams.ContainsKey("Operation"))
    {
        int number1 = int.Parse(queryParams["FirstNumber"]);
        int number2 = int.Parse(queryParams["SecondNumber"]);
        string op = queryParams["Operation"];
        if (op == "add")
        {
            context.Response.StatusCode = 200;
            context.Response.WriteAsync((number1 + number2).ToString()).Wait();
        }
        else if (op == "sub")
        {
            context.Response.StatusCode = 200;
            context.Response.WriteAsync((number1 - number2).ToString()).Wait();
        }
        else if (op == "mul")
        {
            context.Response.StatusCode = 200;
            context.Response.WriteAsync((number1 * number2).ToString()).Wait();
        }
        else
        {
            context.Response.StatusCode = 200;
            context.Response.WriteAsync((number1 / number2).ToString()).Wait();
        }
    }
    else
    {
        context.Response.StatusCode = 400;
        context.Response.ContentType = "Invalid Details";
    }

});
app.Run();
