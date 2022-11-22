@echo off
SETLOCAL EnableDelayedExpansion
set NUL="%TEMP%\nul"
set subString=empty
if exist %SystemRoot%\System32\reg.exe (
set REG="%SystemRoot%\System32\reg.exe"
) else (
echo ...reg.exe does not exist... bail ...
goto DONE
)
set INSTALLPRODSIZE=0
set uninstallproduct=
@rem ...figure out the install product
set INSTALLPROD="%USERPROFILE%\installprod.txt"
if exist %INSTALLPROD% (
@del /F /Q %INSTALLPROD% > %NUL% 2>&1
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
if "%OEMtype%"=="hp" (
set subString="HP USB Serial"
)
if "%OEMtype%"=="empty" (
@echo OEM ...
@type %OEM%
goto DONE
)
set MSIINSTALLQUERY="%cd%\tool\%SYSTEMTYPEFD%\MSIInstallQuery.exe"
%MSIINSTALLQUERY% !subString! > %INSTALLPROD%
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
echo no installed MSI driver found ....
goto DONE
)
@rem ...found an installed MSI driver
set /p uninstallproduct=<%INSTALLPROD%
set key=HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\
set val1=UninstallString
set val2=WindowsInstaller
set newVal=MsiExec.exe /X%uninstallproduct% /qb^^!
if %TARGETOS%=="Windows POSReady 2009" (
echo ...TARGETOS[%TARGETOS%], Skipping hidecancelbutton
goto DONE 
)
if %TARGETOS%=="Windows XP" (
echo ...TARGETOS[%TARGETOS%], Skipping hidecancelbutton
goto DONE 
)
if %TARGETOS%=="Windows XP 64" (
echo ...TARGETOS[%TARGETOS%], Skipping hidecancelbutton
goto DONE
)
if %TARGETOS%=="Windows 2000" (
echo ...TARGETOS[%TARGETOS%], Skipping hidecancelbutton
goto DONE
)
if %TARGETOS%=="Windows Vista" (
echo ...TARGETOS[%TARGETOS%], Skipping hidecancelbutton
goto DONE
)

%REG% add %key%%uninstallproduct% /v %val1% /t REG_EXPAND_SZ /d "!newVal!" /f > %NUL% 2>&1
%REG% add %key%%uninstallproduct% /v %val2% /t REG_DWORD /d 0 /f > %NUL% 2>&1

:DONE
echo hidecancelbutton completes ....
