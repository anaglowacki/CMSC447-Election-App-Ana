/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
MERGE INTO [dbo].[representatives] AS target
USING (VALUES 
    (N'Andy Harris', N'Republican Party', NULL, N'https://harris.house.gov/ https://en.wikipedia.org/wiki/Andy_Harris_%28politician%29', N'', N'U.S. Representative', N'http://bioguide.congress.gov/bioguide/photo/H/H001052.jpg', N'ocd-division/country:us/state:md/cd:1'),
    (N'Anthony G. Brown', N'Democratic Party', NULL, N'https://www.cardin.senate.gov/ https://en.wikipedia.org/wiki/Ben_Cardin', N'', N'MD State Attorney General', NULL, N'ocd-division/country:us/state:md'),
    (N'Aruna Miller', N'Democratic Party', NULL, N'https://www.cardin.senate.gov/ https://en.wikipedia.org/wiki/Ben_Cardin', N'', N'Lieutenant Governor of Maryland', NULL, N'ocd-division/country:us/state:md'),
    (N'Ben Cardin', N'Democratic Party', NULL, N'https://www.cardin.senate.gov/ https://en.wikipedia.org/wiki/Ben_Cardin', N'', N'U.S. Senator', N'http://bioguide.congress.gov/bioguide/photo/C/C000141.jpg', N'ocd-division/country:us/state:md'),
    (N'Brooke E. Lierman', N'Democratic Party', NULL, N'https://www.cardin.senate.gov/ https://en.wikipedia.org/wiki/Ben_Cardin', N'', N'MD State Comptroller', NULL, N'ocd-division/country:us/state:md'),
    (N'C. A. Dutch Ruppersberger', N'Democratic Party', NULL, N'https://ruppersberger.house.gov/ https://en.wikipedia.org/wiki/Dutch_Ruppersberger', N'', N'U.S. Representative', N'http://bioguide.congress.gov/bioguide/photo/R/R000576.jpg', N'ocd-division/country:us/state:md/cd:2'),
    (N'Chris Van Hollen', N'Democratic Party', NULL, N'https://www.vanhollen.senate.gov/ https://en.wikipedia.org/wiki/Chris_Van_Hollen', N'correspondence@vanhollen.senate.gov info@vanhollen.org', N'U.S. Senator', N'http://bioguide.congress.gov/bioguide/photo/V/V000128.jpg', N'ocd-division/country:us/state:md'),
    (N'David Trone', N'Democratic Party', NULL, N'https://trone.house.gov/ https://en.wikipedia.org/wiki/David_Trone', N'', N'U.S. Representative', NULL, N'ocd-division/country:us/state:md/cd:6'),
    (N'Glenn F. Ivey', N'Democratic Party', NULL, N'https://ivey.house.gov/ https://en.wikipedia.org/wiki/Glenn_Ivey', N'', N'U.S. Representative', NULL, N'ocd-division/country:us/state:md/cd:4'),
    (N'Jamie Raskin', N'Democratic Party', NULL, N'https://raskin.house.gov/ https://en.wikipedia.org/wiki/Jamie_Raskin', N'', N'U.S. Representative', NULL, N'ocd-division/country:us/state:md/cd:8'),
    (N'John Sarbanes', N'Democratic Party', NULL, N'https://sarbanes.house.gov/ https://en.wikipedia.org/wiki/John_Sarbanes', N'', N'U.S. Representative', N'http://bioguide.congress.gov/bioguide/photo/S/S001168.jpg', N'ocd-division/country:us/state:md/cd:3'),
    (N'Joseph R. Biden', N'Democratic Party', NULL, N'https://www.whitehouse.gov/ https://en.wikipedia.org/wiki/Joe_Biden', N'', N'President of the United States', NULL, N'ocd-division/country:us'),
    (N'Kamala D. Harris', N'Democratic Party', NULL, N'https://www.whitehouse.gov/ https://en.wikipedia.org/wiki/Kamala_Harris', N'', N'Vice President of the United States', NULL, N'ocd-division/country:us'),
    (N'Kweisi Mfume', N'Democratic Party', NULL, N'https://mfume.house.gov/ https://en.wikipedia.org/wiki/Kweisi_Mfume', N'', N'U.S. Representative', NULL, N'ocd-division/country:us/state:md/cd:7'),
    (N'Steny Hoyer', N'Democratic Party', NULL, N'https://hoyer.house.gov/ https://en.wikipedia.org/wiki/Steny_Hoyer', N'', N'U.S. Representative', N'http://bioguide.congress.gov/bioguide/photo/H/H000874.jpg', N'ocd-division/country:us/state:md/cd:5'),
    (N'Wes Moore', N'Democratic Party', NULL, N'https://www.cardin.senate.gov/ https://en.wikipedia.org/wiki/Ben_Cardin', N'', N'Governor of Maryland', NULL, N'ocd-division/country:us/state:md')
) AS source ([name], [party], [phones], [urls], [emails], [office], [photoUrl], [divisionId])
ON target.name = source.name
WHEN NOT MATCHED THEN
    INSERT ([name], [party], [phones], [urls], [emails], [office], [photoUrl], [divisionId])
    VALUES (source.[name], source.[party], source.[phones], source.[urls], source.[emails], source.[office], source.[photoUrl], source.[divisionId]);
