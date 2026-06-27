using BlazorDeck;
using BlazorDeck.Components;
using BlazorDeck.Components.Config;
using BlazorDeck.Components.Config.ButtonTypes;
using BlazorDeck.Components.ExtentionMethods;
using BlazorDeck.Services;
using Microsoft.Extensions.Options;
using MudBlazor.Services;
using StreamerbotClient;
using ButtonType = BlazorDeck.Components.Config.ButtonType;
using Color = System.Drawing.Color;

var b1 = new DeckButtonConfig();
b1.Config = new SliderConfig() { Vertical = true };
b1.ButtonType = ButtonType.Slider;
b1.Height = 4;
b1.StreamerBotActionId = new Guid("f7a567db-bf60-40bc-9ca5-a29e5a9ebb73");


var b2 = new DeckButtonConfig();
b2.Config = new PressButtonConfig();
b2.X = 2;
b2.Y = 2;
b2.StreamerBotActionId = new Guid("2b8750c1-38ba-4564-8daa-1d6afa79d86c");

var b3 = new DeckButtonConfig();
b3.ButtonType = ButtonType.Button;
b3.Config = new PressButtonConfig() { ActivateTime = 1000 };
b3.InteractColor = Color.Yellow.ToHex();
b3.X = 3;
b3.Y = 4;
b3.StreamerBotActionId = new Guid("38eb0d7a-17e3-4651-93fc-a7aa5eee9d8f");


BlazorDeckConfig container = new();
var page = new PageConfig { Buttons = [b1, b2, b3], GridSizeX = 8, GridSizeY = 4, Name = "FUCKING WORK" };
container.BlazorDeckPages = new();
container.BlazorDeckPages.Add(page);
container.Save();


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ButtonStateService>();

var streamerBot = new Streamerbot();
streamerBot.Connect(builder.Configuration["StreamerBotURI"], "*");
builder.Services.AddSingleton(streamerBot);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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