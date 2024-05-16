using ElectionAppLibrary.DataAccess;
using ElectionAppLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlazorUI
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddServerSideBlazor();
			builder.Services.AddSingleton<LoginService>();
			builder.Services.AddSingleton<SearchService>();
			builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
			builder.Services.AddTransient<IUserData, UserData>();
			builder.Services.AddTransient<IRepAPIRequests, RepAPIRequests>();
			builder.Services.AddTransient<IRepData, RepData>();
			builder.Services.AddTransient<IVoterInfoAPI, VoterInfoAPI>();
			builder.Services.AddTransient<ICandidateData, CandidateData>();
			builder.Services.AddHttpClient("RepByDiv", httpClient =>
			{
				httpClient.BaseAddress = new Uri("https://civicinfo.googleapis.com/civicinfo/v2/representatives/");
			});
			builder.Services.AddHttpClient("VoterInfo", httpClient =>
			{
				httpClient.BaseAddress = new Uri("https://civicinfo.googleapis.com/civicinfo/v2/voterinfo");
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

			await ImportCandidatesFromTextFile(app.Services);

			app.Run();
		}

        private static async Task ImportCandidatesFromTextFile(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var candidateData = scope.ServiceProvider.GetRequiredService<ICandidateData>();

                string projectFolder = AppContext.BaseDirectory;
                string relativePath = "../../../../gen_cand_lists_2024_1_ALL.txt";
                string textFilePath = Path.Combine(projectFolder, relativePath);

                using (var reader = new StreamReader(textFilePath))
                {
                    string headerLine = await reader.ReadLineAsync();
                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        var values = line.Split('\t');

                        var candidate = new CandidateModelDB
                        {
                            OfficeName = values[0],
                            DistrictNameAndNumber = values[1],
                            CandidateLastName = values[2],
                            CandidateFirstName = values[3],
                            PoliticalParty = values[4],
                            CandidateStatus = values[5],
                            PublicPhone = values.Length > 6 ? values[6] : null,
                            Email = values.Length > 7 ? values[7] : null,
                            Website = values.Length > 8 ? values[8] : null,
                            Facebook = values.Length > 9 ? values[9] : null,
                            Twitter = values.Length > 10 ? values[10] : null,
                            Other = values.Length > 11 ? values[11] : null
                        };

                        bool candidateExists = await candidateData.IsCandidateInDB(candidate);
                        if (!candidateExists)
                        {
                            await candidateData.InsertCandidate(candidate);
                        }
                    }
                }

                Console.WriteLine("Import completed successfully.");
            }
        }

    }
}