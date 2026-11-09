@echo off
chcp 65001 >nul
echo Dang tat IIS Express...
taskkill /IM iisexpress.exe /F >nul 2>&1

echo Dang stop LocalDB...
"C:\Program Files\Microsoft SQL Server\170\Tools\Binn\SqlLocalDB.exe" stop MSSQLLocalDB >nul 2>&1

echo Da tat toan bo server.
pause
