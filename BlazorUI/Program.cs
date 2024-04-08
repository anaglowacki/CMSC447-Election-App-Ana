using ElectionAppLibrary.DataAccess;
using ElectionAppLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<LoginService>();
            builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
			builder.Services.AddHttpClient("RepAddress", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://www.googleapis.com/civicinfo/v2/representatives?key=AIzaSyDRPOb2Wy4TIGZ2HcSuXLxxuIoNytPGIzE&address=");
            });
			builder.Services.AddHttpClient("RepDivision", httpClient =>
			{
				httpClient.BaseAddress = new Uri("https://civicinfo.googleapis.com/civicinfo/v2/representatives/ocd-division%2Fcountry%3Aus%2Fstate%3Amd?key=AIzaSyDRPOb2Wy4TIGZ2HcSuXLxxuIoNytPGIzE");
			});
			builder.Services.AddHttpClient("Elections", httpClient =>
			{
				httpClient.BaseAddress = new Uri("https://www.googleapis.com/civicinfo/v2/elections?key=AIzaSyDRPOb2Wy4TIGZ2HcSuXLxxuIoNytPGIzE");
			});
			builder.Services.AddHttpClient("VoterInfo", httpClient =>
			{
				httpClient.BaseAddress = new Uri("https://www.googleapis.com/civicinfo/v2/voterinfo?key=AIzaSyDRPOb2Wy4TIGZ2HcSuXLxxuIoNytPGIzE&address=");
			});


			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
