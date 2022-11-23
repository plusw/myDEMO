@echo off
@echo installmsi.bat ... 
if %PROCESSOR_ARCHITECTURE%==x86 (
if "%INSTALL-TYPE%"=="machine" (
set msitransform=usb-serial-32-transform-per-machine.mst
)
) else (
if "%INSTALL-TYPE%"=="machine" (
set msitransform=usb-serial-64-transform-per-machine.mst
)
)
@echo ....msitransform[%msitransform%] ...
@msiexec /qn /i "%msifile%" TRANSFORMS=%msitransform%

