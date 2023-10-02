@echo off

rem Uruchom nginx
start nginx/nginx.exe

rem Uruchom dotnet run
start dotnet run --project src/HSTService.Api --urls=http://localhost:5001/
start dotnet run --project src/HSTService.Api --urls=http://localhost:5002/

rem Oczekiwanie na sygnał ctrl c
:loop
if "%1"=="-c" (
    goto exit
)
ping localhost -n 1 > nul
goto loop

:exit
rem Zamknij nginx
taskkill /f /im nginx.exe