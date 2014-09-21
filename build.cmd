@echo off

powershell -NoProfile -ExecutionPolicy Bypass -Command "& '%~dp0\src\Employee\packages\psake.4.3.2\tools\psake.ps1' %* -parameters @{"packageVersion"="'%2'"}; if ($psake.build_success -eq $false) { write-host "Build Failed!" -fore RED; exit 1 } else { exit 0 }" <nul
