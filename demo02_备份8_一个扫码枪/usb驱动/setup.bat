@echo off
cd /d %~d0%~p0
setlocal enableextensions enabledelayedexpansion
set RETURNCODE=0
@rem checking for admin right here. If not, print out a warning for the user
@rem and exit out.
net session >nul 2>&1
if %errorlevel% NEQ 0 (
echo ...Administrator Privilege is required to install the driver
echo ...Please consult the README.txt for install/uninstall instruction
set RETURNCODE=%errorlevel%
goto DISP
)
@call preinstchk.bat
if "%supportOS%"=="no" ( goto UNSUPPORTOS)
if %continueSetup%==no (goto WARN)
if "%1" EQU "" (goto CONT)
if "%1" EQU "/silent" ( 
goto SILENT 
) else (
goto USAGE
)
:CONT
@call preinstproc.bat
@pushd .
@cd /d %SYSTEMTYPE%
@msiexec /i "%msifile%" TRANSFORMS=%msitransform%
set RETURNCODE=%errorlevel%
@popd
@call hidecancelbutton.bat
goto END
:UNSUPPORTOS
echo ------ UNSUPPORTED OS
set RETURNCODE=2
goto DISP
:WARN
echo ======== WARNING WARNING: Cannot install this driver =========================================
echo There is a different version of MSI driver package, ver=%foundVer% is currently installed
echo Please first remove the current MSI installed driver in 'Control Panel\Add and Remove program'
echo Then try to install this driver again.
echo ==============================================================================================
@rem make sure that user can see the above warning message.
@rem ONLY want to pause if normal install is invoked
:DISP
if "%1" EQU "" (
@pause
)
goto END
:SILENT
@rem processing for silent install
if "%2" EQU "/install" (
set INSTALL-OPT=install
if "%3"=="" (
set INSTALL-TYPE=user
goto CONT1
)
if "%3"=="/machine" (
set INSTALL-TYPE=machine
goto CONT1
)
if "%3"=="/user" (
set INSTALL-TYPE=user
goto CONT1
)
@rem, 3rd parm is bad, error out
goto USAGE
) else (
if "%2" EQU "/uninstall" (
set INSTALL-OPT=uninstall
) else (
goto USAGE
)
)
:CONT1
@call preinstproc.bat
@call silentsetup.bat
goto END1
@rem,
:USAGE
set RETURNCODE=2
@rem display usage
@echo USAGE
@echo "setup.bat" -- For Wizard Guide Install/Uninstall
@echo setup.bat /silent [/install ^| /uninstall] [/machine ^| /user]  -- For Silent Install/Uninstall
:END
exit /B !RETURNCODE!
:END1
