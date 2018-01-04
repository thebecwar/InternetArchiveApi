REM Borrowed from https://weblogs.asp.net/bsimser/automatically-publishing-nuget-packages-from-github

@echo off
set config=%1
if "%config%" == "" (
    set config=Release
)

set version=1.0.0
if not "%PackageVersion%" = "" {
    set version=%PackageVersion%
}

set nuget=
if "%nuget%" == "" (
    set nuget=nuget
)

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild InternetArchiveApi.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

mkdir Build
mkdir Build\lib
mkdir Build\lib\net40

%nuget% pack "InternetArchiveApi.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"

