@echo off
@rem.
@rem =====================================================================
@rem Name: preinstchk.bat 
@rem version: 1.9
@rem Description: This utility invokes before any installation take place. 
@rem              It is called by setup.bat.
@rem              The goal is to do all the pre checking activities:
@rem              1/ check to see if the user run as admin.
@rem              2/ check to see if there is any installed MSI driver.
@rem                 If there is an installed MSI driver AND its version is NOT the same as the new MSI version
@rem                   then we need to exit
@rem                 Else 
@rem 
@rem Usage:
@rem checkmsi
@rem Revision History:
@rem  Version       Author      Description
@rem   1.0          KL          Initial Release
@rem   1.1          KL          Do not check for honeywell_enum.sys
@rem   1.2          KL	        reg.exe 3.0, the earlier version on POSReady 2009. 
@rem                            It outputs the utility header information hence messed up
@rem                            the output format. So, we need to deal with this.
@rem   1.3          KL          Windows XP is using the same reg.exe as that of POSReady 2009.
@rem                            So, we need to fix for XP
@rem   1.4          KL          Figure out if MS Visual C++ Redistributable package is installed
@rem                            We cheat, assuming that findUsbPkgVer.exe fails mean the vcredist is not installed.
@rem   1.5          KL          Fix %USERPROFILE%, make sure that this can handle special character.
@rem   1.6          KL          Figure out the correct msi file and use that instead of setup.exe
@rem   1.7          KL          Add check if Microsoft Visual C++ 2010 redistributable package is installed.
@rem                            Fix up the null file. Put this file in %TEMP%
@rem   1.8          KL			Add support for Windows 10
@rem   1.9			KL			Add back support for Windows 10 since the licensing is finalized with Jungo
@rem   2.0          KL          a/ Add SYSTEMTYPEFD b/ Fix a bug where installVer will be reported incorrectly when VC++ 2010 Redist
@rem                             is not present
@rem   2.1          KL          Add the following changes:
@rem                            a/ process oem.txt, so that we can get rid off specific version for each oem type
@rem                            b/ Save oem.txt into a new environment variable OEMtype
@rem =================================================================================================================
@rem.
@rem.
@rem cannot setlocal here since the variable declared here will not be visible in parent script such as setup.bat
set NUL="%TEMP%\nul"
set POSREADY2009=yes
set MSIINSTALLEXIST=no
set TARGETOS="Windows POSReady 2009"
set CHECKMSI_VER=2.1
set installVer=0
set foundVer=0
set msifile=
set continueSetup=yes
set supportOS=yes
set vcredist=yes
set msitransform=
set OEMtype=empty
set /p OEMtype=<oem.txt
if "%OEMtype%"=="empty" (
@echo Invalid OEM ...
goto END
)
set REGOUTPRE="%USERPROFILE%\regout-pre.txt"
set REGOUT="%USERPROFILE%\regout.txt"
set INSTALLMSIFILE="%USERPROFILE%\installmsifile.txt"
set vcredist-x86=HKLM\Software\Microsoft\Windows\CurrentVersion\Uninstall\{196BB40D-1578-3D01-B289-BEFC77A11A1E}
set vcredist-x86-sp1=HKLM\Software\Microsoft\Windows\CurrentVersion\Uninstall\{F0C3E5D1-1ADE-321E-8167-68EF0DE699A5}
set vcredist-x64=HKLM\Software\Microsoft\Windows\CurrentVersion\Uninstall\{DA5E371C-6333-3D8A-93A4-6FD5B20BCC6E}
set vcredist-x64-sp1=HKLM\Software\Microsoft\Windows\CurrentVersion\Uninstall\{1D8E6291-B0D5-35EC-8441-6616F567A0F7}
set vvcredist=
set vvcredist-sp1=
set SYSTEMTYPEFD=
echo CHECKMSI_VER=%CHECKMSI_VER%
@rem Get the new driver version ....
set /p installVer=<"%cd%\driver_package_reg_ver.txt"
if exist %REGOUTPRE% (
@del /F /Q %REGOUTPRE% > %NUL% 2>&1
)
if exist %REGOUT% (
@del /F /Q %REGOUT% > %NUL% 2>&1
)
if exist %INSTALLMSIFILE% (
@del /F /Q %INSTALLMSIFILE% > %NUL% 2>&1
)
@rem
if %PROCESSOR_ARCHITECTURE%==x86 (
dir x86-ForInternalUseOnly\*win78.msi /A:H /B > %INSTALLMSIFILE%
set SYSTEMTYPE=x86-ForInternalUseOnly
set SYSTEMTYPEFD=x86
set msitransform=usb-serial-32-transform.mst
set vvcredist=%vcredist-x86%
set vvcredist-sp1=%vcredist-x86-sp1%
) else (
dir x64-ForInternalUseOnly\*win78.msi /A:H /B > %INSTALLMSIFILE%
set SYSTEMTYPE=x64-ForInternalUseOnly
set SYSTEMTYPEFD=x64
set msitransform=usb-serial-64-transform.mst
set vvcredist=%vcredist-x64%
set vvcredist-sp1=%vcredist-x64-sp1%
)
@rem
set /p msifile=<%INSTALLMSIFILE%

@rem
if exist %SystemRoot%\System32\findstr.exe (
set FINDSTR="%SystemRoot%\System32\findstr.exe"
set POSREADY2009=no
) else (
echo POSREADY2009=%POSREADY2009%
set FINDSTR=
set FINDUSBVER="%cd%\findUsbPkgVer.exe"
)
if exist %SystemRoot%\System32\reg.exe (
set REG="%SystemRoot%\System32\reg.exe"
) else (
echo ...reg.exe does not exist... bail ...
goto END
)
@rem.
@rem ...first check to see if target machine has Visual 2010 Redistributable installed
%REG% query %vvcredist% /v DisplayName > %NUL% 2>&1
if %errorlevel% equ 0 (
goto VC-REDIST-INST
)
@rem ...Do not have 2010 vcredist installed
%REG% query %vvcredist-sp1% /v DisplayName > %NUL% 2>&1
if %errorlevel% neq 0 (
@rem echo ...Do not have 2010 vcredist nor 2010 vcredist sp1 installed. Done, get out
set vcredist=no
@rem ...remove the goto below since we want to figure out the correct TARGETOS, so, let the code below to run
@rem goto END
)
:VC-REDIST-INST
@rem echo ... Target machine have either 2010 vcredist or 2010 vcredist sp1 installed, continue
@rem move on ....
if "%POSREADY2009%"=="yes" (goto DONEOS)
@rem If not, find out the OS version ...
ver | %FINDSTR% /C:"5.0" > %NUL%
if %ERRORLEVEL%==0 goto WIN2K
ver | %FINDSTR% /C:"5.1" > %NUL%
if %ERRORLEVEL%==0 goto WINXP
ver | %FINDSTR% /C:"5.2" > %NUL%
if %ERRORLEVEL%==0 goto WINXP_64
ver | %FINDSTR% /C:"6.0" > %NUL%
if %ERRORLEVEL%==0 goto WINVISTA
ver | %FINDSTR% /C:"6.1" > %NUL%
if %ERRORLEVEL%==0 goto WIN7
ver | %FINDSTR% /C:"6.2" > %NUL%
if %ERRORLEVEL%==0 goto WIN8
ver | %FINDSTR% /C:"6.3" > %NUL% 2>&1
if %ERRORLEVEL%==0 goto WIN81
ver | %FINDSTR% /C:"10.0" > %NUL% 2>&1
if %ERRORLEVEL%==0 goto WIN10
goto DONEOS

:WIN2K
@set TARGETOS="Windows 2000"
echo Unsupported OS: %TARGETOS% ...
set supportOS=no
goto END

:WINXP
@set TARGETOS="Windows XP"
@set DRIVERSTOREPATH="%SystemRoot%\System32\DRVSTORE"
@set FINDUSBVER="%cd%\findUsbPkgVer.exe"
goto DONEOS

:WINXP_64
@set TARGETOS="Windows XP 64"
@set DRIVERSTOREPATH="%SystemRoot%\System32\DRVSTORE"
goto DONEOS

:WINVISTA
@set TARGETOS="Windows Vista"
@set DRIVERSTOREPATH="%SystemRoot%\System32\DriverStore\FileRepository"
goto DONEOS

:WIN7
@set TARGETOS="Windows 7"

@set DRIVERSTOREPATH="%SystemRoot%\System32\DriverStore\FileRepository"
goto DONEOS

:WIN8
@set TARGETOS="Windows 8"
@set DRIVERSTOREPATH="%SystemRoot%\System32\DriverStore\FileRepository"
goto DONEOS

:WIN81
@set TARGETOS="Windows 8.1"
@set DRIVERSTOREPATH="%SystemRoot%\System32\DriverStore\FileRepository"
goto DONEOS

:WIN10
@set TARGETOS="Windows 10"
@set DRIVERSTOREPATH="%SystemRoot%\System32\DriverStore\FileRepository"

if %PROCESSOR_ARCHITECTURE%==x86 (
dir x86-ForInternalUseOnly\*win10.msi /A:H /B > %INSTALLMSIFILE%
set SYSTEMTYPE=x86-ForInternalUseOnly
set SYSTEMTYPEFD=x86
set msitransform=usb-serial-32-transform.mst
set vvcredist=%vcredist-x86%
set vvcredist-sp1=%vcredist-x86-sp1%
) else (
dir x64-ForInternalUseOnly\*win10.msi /A:H /B > %INSTALLMSIFILE%
set SYSTEMTYPE=x64-ForInternalUseOnly
set SYSTEMTYPEFD=x64
set msitransform=usb-serial-64-transform.mst
set vvcredist=%vcredist-x64%
set vvcredist-sp1=%vcredist-x64-sp1%
)
set /p msifile=<%INSTALLMSIFILE%
goto DONEOS

:DONEOS


@rem ONLY do the below if vcredist set to yes, else jump to END
if "%vcredist%"=="no" (goto END)

@rem setting up service_enum
@set service_enum=
if "%OEMtype%"=="honeywell" (
@set service_enum=honeywell_enum
)
if "%OEMtype%"=="intermec" (
@set service_enum=intermec_enum
)
if "%OEMtype%"=="youjie" (
@set service_enum=youjie_enum
)
if "%OEMtype%"=="keyence" (
@set service_enum=keyence_enum
)
if "%OEMtype%"=="hp" (
@set service_enum=hp_enum
)

@rem query and surppress all output from reg.exe
%REG% query HKLM\SYSTEM\CurrentControlSet\Services\%service_enum%\Parameters /v UsbDriverVer > %NUL% 2>&1
if %ERRORLEVEL%==1 (goto GETINVER)
@rem we are here, this means that the registry "UsbDriverVer" exists. Get it.
@rem, depending on what OS, we need to use different method to get the UsbDriverVer from registry
@rem.
@pushd .
cd /d "%USERPROFILE%"
if "%POSREADY2009%"=="yes" (goto POSR)
if %TARGETOS%=="Windows XP" (goto POSR)
@rem this is for non POSReady 2009
%REG% query HKLM\SYSTEM\CurrentControlSet\Services\%service_enum%\Parameters /v UsbDriverVer > %REGOUT%
for /f "tokens=3 delims= " %%A in ('@type %REGOUT%') do @set foundVer=%%A
goto NPOSR
:POSR
@rem, first we need to save this into a file, so that we can later process with findString1.exe
%REG% query HKLM\SYSTEM\CurrentControlSet\Services\%service_enum%\Parameters /v UsbDriverVer > %REGOUTPRE%
%FINDUSBVER% REG_SZ %REGOUTPRE% > %REGOUT%
@rem, if there is an error, this would mean that there is no MS C++ 2010 redistributable installed.
@rem, get out and return
if not %ERRORLEVEL%==0 (
set vcredist=no
@popd
goto END
)
for /f "tokens=1 delims= " %%A in ('@type %REGOUT%') do @set foundVer=%%A
:NPOSR
@popd
@rem.
if %ERRORLEVEL%==0 ( goto GETINVER )
goto END
:GETINVER
@rem now, we need to check the installed version
if not %installVer%==%foundVer% ( goto CHECKMORE )
goto END
:CHECKMORE
@rem check to see if foundVer is non zero
if not %foundVer%==0 ( set continueSetup=no )
:END
if exist %NUL% del /F /Q %NUL%
echo ... foundVer=%foundVer%
echo ... installVer=%installVer%
echo ... continueSetup=%continueSetup%
echo ... supportOS=%supportOS%
echo preinstchk completes ....
