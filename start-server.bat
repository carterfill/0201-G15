@echo off
chcp 65001 >nul
setlocal
set ROOT=%~dp0
set IISEXE=C:\Program Files\IIS Express\iisexpress.exe
set SQLLDB=C:\Program Files\Microsoft SQL Server\170\Tools\Binn\SqlLocalDB.exe
set MSBUILD=C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe

echo ============================================
echo   SweetBakery - Khoi dong full server
echo ============================================

echo [1/3] Khoi dong LocalDB (MSSQLLocalDB)...
"%SQLLDB%" start MSSQLLocalDB >nul 2>&1
"%SQLLDB%" info MSSQLLocalDB | findstr /C:"State" 

echo [2/3] Build backend (MSBuild)...
"%MSBUILD%" "%ROOT%SweetBakery.sln" -p:Configuration=Debug -v:q -nologo
if errorlevel 1 (
    echo    ^! Build loi - van chay server voi DLL cu trong bin\
)

echo [3/3] Khoi dong IIS Express...
start "SweetBakery Backend :8080" "%IISEXE%" /path:"%ROOT%SweetBakery" /port:8080

timeout /t 3 /nobreak >nul
start "" http://localhost:8080/

echo.
echo   Backend MVC   : http://localhost:8080
echo   Admin         : admin@sweetbakery.vn / admin123
echo   Khach hang    : huongmai@gmail.com / 123456
echo.
echo   (Cua so IIS Express se hien thi log - khong dong no)
pause
