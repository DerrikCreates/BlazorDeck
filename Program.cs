using BlazorDeck;
using BlazorDeck.Components;
using BlazorDeck.Components.Config;
using BlazorDeck.Components.Config.ButtonTypes;
using BlazorDeck.Components.ExtentionMethods;
using BlazorDeck.Config;
using BlazorDeck.Services;
using Microsoft.Extensions.Options;
using MudBlazor.Services;
using StreamerbotClient;
using ButtonType = BlazorDeck.Components.Config.ButtonType;
using Color = System.Drawing.Color;

BlazorDeckConfig container = new();
var page1 = new PageBuilder()
    .PageSize(8, 4)
    .BuildDemo1();

var page2 = new PageBuilder()
    .PageSize(8, 4)
    .BuildDemo2();

container.BlazorDeckPages.Add(page1);
container.BlazorDeckPages.Add(page2);
container.Save();


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ButtonStateService>();

var streamerBot = new StreamerBotClient();
streamerBot.Connect(builder.Configuration["StreamerBotURI"], "*");
builder.Services.AddSingleton(streamerBot);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<DOMHelper>();
builder.Services.AddScoped<ClientInputInterop>();

builder.Services.AddSingleton<ConfigWatcher>();


builder.Services.AddMudServices();

builder.Services.AddSignalR();

var app = builder.Build();

var c = app.Services.GetService<IOptionsMonitor<BlazorDeckConfig>>();

c.OnChange((config => { Console.WriteLine("CHANGED"); }));
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();