@echo off
@rem.
@rem =====================================================================
@rem Name: silentsetup.bat 
@rem version: 1.0
@rem Description: This utility invokes before silent installation take place. 
@rem              It is called by setup.bat.
@rem              The goal is to do all the pre checking activities:
@rem              1/ check to see if the user run as admin.
@rem              2/ Make sure that Microsoft visual c++ 2010 redistributable is installed on target machine.
@rem              2/ check to see if there is any installed MSI driver.
@rem                 If there is an installed MSI driver AND its version is NOT the same as the new MSI version
@rem                   then we need to exit
@rem                 Else 
@rem 
@rem Usage:
@rem Revision History:
@rem  Version       Author      Description
@rem   1.0          Kiet Ly	    Initial version
@rem   1.1          Kiet Ly     Remove all the port assignment retrieval code since they have already been moved to
@rem                            Install_xxx.bat and Uninstall_xxx.bat. 
@rem   1.2          Kiet Ly	    Add return code:
@rem                             0 ==> success
@rem                             1 ==> no operation
@rem                             2 ==> fail
@rem   1.3          Kiet Ly     Add product substring
@rem =====================================================================
@rem.
@rem.
@rem
setlocal enableextensions enabledelayedexpansion
set RETURNCODE=0
set subString=empty
if exist %SystemRoot%\System32\reg.exe (
set REG="%SystemRoot%\System32\reg.exe"
) else (
echo ...reg.exe does not exist... bail ...
goto DONE
)
@rem figure out the correct product name substring to search for
if "%OEMtype%"=="honeywell" (
set subString="Honeywell HSM USB Serial"
)
if "%OEMtype%"=="youjie" (
set subString="Youjie USB Serial"
)
if "%OEMtype%"=="keyence" (
set subString="Keyence USB Serial"
)
if "%OEMtype%"=="intermec" (
set subString="Intermec USB Serial"
)
if "%OEMtype%"=="empty" (
@echo OEM ...
@type %OEM%
goto DONE
)
set INSTALLPROD="%USERPROFILE%\installprod.txt"
if exist %INSTALLPROD% (
@del /F /Q %INSTALLPROD% > nul 2>&1
)
@rem Initalize all local variable
@rem set VCREDIST=
set MSIINSTALLQUERY=
set MSIINSTALLED=

@set MSIINSTALLQUERY="%cd%\tool\%SYSTEMTYPEFD%\MSIInstallQuery.exe"

@rem %VCREDIST% /q /norestart
@rem query to find out if there is already a MSI-based driver installed
%MSIINSTALLQUERY% !subString! > %INSTALLPROD%
if NOT %ERRORLEVEL%==0 (
echo ------ Microsoft Visual C++ 2010 Redistributable Package is required to be installed on target computer
echo ------ Please consult the README.txt for installation instruction, then try again.
set RETURNCODE=2
goto DONE
)

@rem for now, just go to the USERPROFILE directory and figure out the size
@rem
@pushd .
@cd /d "%USERPROFILE%"
@rem Now, that we are here. We need to find out if each of the above files
@rem is non-zero, and only perform devcon on non-zero file
@rem figure out the size for the files ...
for /f "usebackq" %%A in ('"installprod.txt"') do @set INSTALLPRODSIZE=%%~zA
@popd
@rem
if %INSTALLPRODSIZE% equ 0 (
@set MSIINSTALLED=no
) else (
@set MSIINSTALLED=yes
)
@rem, Now we have 2 different environment variables: INSTALL-OPT, and MSIINSTALLED
@rem, 

if "%INSTALL-OPT%"=="install" (
@pushd .
@cd /d "%cd%\%SYSTEMTYPE%"
if "%MSIINSTALLED%"=="yes" (
@rem, try to install a MSI version of the driver while there was already a MSI version of the driver installed
@echo a MSI version of the driver has already installed, do nothing ...
set RETURNCODE=1
) else (
if "%MSIINSTALLED%"=="no" (
@rem, proceed to install the driver
@echo ...about to install the driver...
@call ..\installmsi.bat
@rem return errorcode from msiexec
set RETURNCODE=%errorlevel%
) else (
@rem, error, bail
set RETURNCODE=2
)
)
@popd
@rem call hidecancelbutton.bat here if we did install successfully
if !RETURNCODE!==0 (
@call hidecancelbutton.bat
)
goto DONE
)
@rem,
@rem, if we are here, we are doing uninstall
@echo ....uninstall.....
if "%INSTALL-OPT%"=="uninstall" (
if "%MSIINSTALLED%"=="no" (
@rem, try to uninstall a MSI version of the driver while there was NOT already a MSI version of the driver installed
@echo there is not a MSI version of the driver already installed, do nothing ...
set RETURNCODE=1
) else (
if "%MSIINSTALLED%"=="yes" (
@set /p uninstallproduct=<%INSTALLPROD%
@echo ...about to uninstall driver.... 
@call uninstallmsi.bat
@rem return errorcode from msiexec
set RETURNCODE=%errorlevel%
) else (
@rem, error, bail
set RETURNCODE=2
)
)
)
:DONE
exit /B !RETURNCODE!
echo silentsetup completes ....

