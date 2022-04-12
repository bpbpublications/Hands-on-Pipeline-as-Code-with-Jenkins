REM @ECHO OFF



SET DllContainingTests=PM> SET DllContainingTests=AngularJSFormTests1\bin\Debug\AngularJSFormTests1.dll


REM *** IMPORTANT - Change DllContainingTests variable (above) to point to the DLL 

REM *** MSTest Test Runner (VS2013, will need to change 12.0 to 14.0 for VS2015)
SET TestRunnerExe=C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\MSTest.exe

REM Get OpenCover Executable (done this way so we dont have to change 
REM the code when the version number changes)
for /R "%~dp0packages" %%a in (*) do if /I "%%~nxa"=="OpenCover.Console.exe" SET OpenCoverExe=%%~dpnxa

REM Get Report Generator (done this way so we dont have to change the code 
REM when the version number changes)
for /R "%~dp0packages" %%a in (*) do if /I "%%~nxa"=="ReportGenerator.exe" 
     SET ReportGeneratorExe=%%~dpnxa

REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"

REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics

REM Generate the report output based on the test results
if %errorlevel% equ 0 ( 
 call :RunReportGeneratorOutput 
)

REM Launch the report
if %errorlevel% equ 0 ( 
 call :RunLaunchReport 
)
exit /b %errorlevel%

:RunOpenCoverUnitTestMetrics 
REM *** Change the filter to include/exclude parts of the solution you want to 
REM *** check for test coverage
"%OpenCoverExe%" ^
 -target:"%TestRunnerExe%" ^
 -targetargs:"/noisolation /testcontainer:\"%DllContainingTests%\"" ^
 -filter:"+[*]* -[*.Tests*]* -[*]*.Global -[*]*.RouteConfig -[*]*.WebApiConfig" ^
 -mergebyhash ^
 -skipautoprops ^
 -register:user ^
 -output:"%~dp0GeneratedReports\CoverageReport.xml"
exit /b %errorlevel%

:RunReportGeneratorOutput
"%ReportGeneratorExe%" ^
 -reports:"%~dp0\GeneratedReports\CoverageReport.xml" ^
 -targetdir:"%~dp0\GeneratedReports\ReportGenerator Output"
exit /b %errorlevel%

:RunLaunchReport
start "report" "%~dp0\GeneratedReports\ReportGenerator Output\index.htm"
exit /b %errorlevel%