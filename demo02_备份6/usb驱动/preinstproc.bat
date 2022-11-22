@echo off
@rem.
@rem =====================================================================
@rem Name: preinstproc.bat 
@rem version: 1.9
@rem Description: This utility is called by setup.bat, after preinstchk.bat was called.
@rem              It will do the followings:
@rem               1/ Install VC++ 2010 Redistributable if it is not already there on target machine
@rem               2/ Custom process for each OEMtype. For example, for Intermec target, it will remove
@rem                  VCP Installer automatically
@rem                  
@rem 
@rem Usage:
@rem checkmsi
@rem Revision History:
@rem  Version       Author      Description
@rem   1.0          KL          Initial Release
@rem =================================================================================================================
@rem.
@rem.
set VCPATH="%cd%\tool\%SYSTEMTYPEFD%\vcredist.exe"
if "%vcredist%"=="no" ( 
@echo Installing vcredist ...
%VCPATH% /passive /promptrestart
@echo ...Finished installing VC++ 2010 Redistributable
set vcredist=yes
)

SETLOCAL ENABLEDELAYEDEXPANSION
set INLEGACYDRIVERSIZE=0
@set INLEGACYDRIVER=
@set MSIINSTALLQUERY=
@set vcpinstaller=empty

@rem Custom process for Intermec
if "%OEMtype%"=="intermec" (
@rem we need to check here to see if VCP Installer is installed on target machine
@rem if it is, we will remove it
@rem need to make sure that vcredist is present first
if "%vcredist%"=="yes" (
@echo ...vcredist is INSTALLED and we are INTERMEC ...

@set INLEGACYDRIVER="%USERPROFILE%\inlegacydriver.txt"
@set MSIINSTALLQUERY="%cd%\tool\%SYSTEMTYPEFD%\MSIInstallQuery.exe"
!MSIINSTALLQUERY! "VCP Installer" > !INLEGACYDRIVER!
@pushd .
@cd /d "%USERPROFILE%"
@rem Now, that we are here. We need to find out if each of the above files
@rem is non-zero, and only perform devcon on non-zero file
@rem figure out the size for the files ...
for /f "usebackq" %%A in ('"inlegacydriver.txt"') do @set INLEGACYDRIVERSIZE=%%~zA
@echo INLEGACYDRIVERSIZE[!INLEGACYDRIVERSIZE!]...
if !INLEGACYDRIVERSIZE! NEQ 0 (
set /p vcpinstaller=<!INLEGACYDRIVER!
echo FOUND VCP Installer Product[!vcpinstaller!]...
)
@popd
@rem if there is VCP Installer exist, silently uninstall it
if "!vcpinstaller!" NEQ "empty" (
echo SILENTLY uninstalling Intermec VCP Installer ...
@msiexec /x !vcpinstaller! /qb!
)
)
)
ENDLOCAL
