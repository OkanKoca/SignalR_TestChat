# Her iki projeyi HTTPS profilleri ile baþlatýr.
# Bir kez aþaðýdaki komutla geliþtirme sertifikasýný güvenilir yapýn:
# dotnet dev-certs https --trust

$solutionRoot = Split-Path $MyInvocation.MyCommand.Path -Parent
$serverProj = Join-Path $solutionRoot 'SignalR_TestProje/SignalR_TestProje.csproj'
$clientProj = Join-Path $solutionRoot 'SignalR_Client/SignalR_Client.csproj'

Write-Host 'Sunucu (SignalR_TestProje) baþlatýlýyor...'
Start-Process powershell -ArgumentList "-NoExit","-Command","dotnet run --project `"$serverProj`" --launch-profile https" | Out-Null

Start-Sleep -Seconds 3

Write-Host 'Ýstemci (SignalR_Client) baþlatýlýyor...'
Start-Process powershell -ArgumentList "-NoExit","-Command","dotnet run --project `"$clientProj`" --launch-profile https" | Out-Null

Write-Host 'Çalýþýyor: Sunucu https://localhost:7040 | Ýstemci https://localhost:7155'