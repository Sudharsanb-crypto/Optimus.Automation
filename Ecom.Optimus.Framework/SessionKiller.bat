REM Kill chrome if needed

REM Kill chromedriver if needed
tasklist /FI "IMAGENAME eq chromedriver.exe" /NH | find /I /N "chromedriver.exe" >NUL
if "%ERRORLEVEL%"=="0" TASKKILL /IM chromedriver.exe /F


REM Kill IEDriverServer if needed
tasklist /FI "IMAGENAME eq IEDriverServer.exe" /NH | find /I /N "geckodriver.exe" >NUL
if "%ERRORLEVEL%"=="0" TASKKILL /IM geckodriver.exe /F