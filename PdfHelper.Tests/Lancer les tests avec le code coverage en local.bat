::La premi�re fois, d�commenter la ligne suivante puis la laisser comment�e
::dotnet tool install -g dotnet-reportgenerator-globaltool
 if not exist .\TestResults mkdir TestResults
 if not exist .\coveragereport mkdir coveragereport
 del /Q .\TestResults
 del /Q /S .\coveragereport
 ::dotnet build 
 dotnet test PdfHelper.Tests.csproj  --collect:"XPlat Code Coverage" /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=".\TestResults\coverage.cobertura.xml"
 ::reportgenerator "-reports:BMS.RELEVISEUR.OCR.TEST.Tesseract\TestResults\a3ed8ab2-1cf5-4bb9-a6c6-7f8c84eced68\coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html
 ::start "" ".\coveragereport\index.html"