using middleware.MyMiddlewares;

var builder = WebApplication.CreateBuilder(args);

//registering middleware
builder.Services.AddTransient<IMiddleware,CustomeMiddleware>();
var app = builder.Build();


//middleware 1
app.Use( async (HttpContext context,RequestDelegate next) => {
    await context.Response.WriteAsync("Hello\n");
    await next(context);
});

//using middleware
app.UseMiddleware<CustomeMiddleware>();


//middleware 3
app.Use(async (HttpContext context,RequestDelegate next) =>{
    await context.Response.WriteAsync("Hello again");
    await next(context);
});

//end middleware
app.Run();