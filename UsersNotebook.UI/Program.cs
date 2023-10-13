using UsersNotebook.UI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAntiforgery(opts =>
{
    opts.HeaderName = "XSRF-TOKEN";
});
builder.Services.AddHttpClient("UsersAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7261/users/");
    client.DefaultRequestHeaders.Add("X-API-Key", builder.Configuration["AppSettings:ApiKey"]);
});
builder.Services.AddSingleton <List<UserView>>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapFallbackToPage("/Users");
});


app.Run();
