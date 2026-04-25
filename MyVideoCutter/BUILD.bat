@echo off
title My Video Cutter - Builder
color 0B
echo.
echo  ============================================
echo    My Video Cutter - Build Script
echo  ============================================
echo.

:: Check for dotnet SDK
where dotnet >nul 2>&1
if %errorlevel% neq 0 (
    echo  [ERROR] .NET SDK not found!
    echo.
    echo  Please install the .NET 8 SDK from:
    echo  https://dotnet.microsoft.com/download
    echo.
    pause
    exit /b 1
)

echo  [1/2] Restoring NuGet packages...
dotnet restore MyVideoCutter\MyVideoCutter.csproj
if %errorlevel% neq 0 goto :error

echo.
echo  [2/2] Publishing single-file portable EXE...
dotnet publish MyVideoCutter\MyVideoCutter.csproj -c Release -o .\publish\
if %errorlevel% neq 0 goto :error

echo.
echo  ============================================
echo   BUILD SUCCESSFUL!
echo  ============================================
echo.
echo  EXE location:  .\publish\MyVideoCutter.exe
echo.
echo  IMPORTANT: Copy ffmpeg.exe into the same
echo  folder as MyVideoCutter.exe before running.
echo  Download ffmpeg from: https://ffmpeg.org/download.html
echo.
explorer .\publish\
pause
exit /b 0

:error
echo.
echo  [ERROR] Build failed. See messages above.
pause
exit /b 1
