Honeywell USB Serial Driver Installation


Uncompress the driver install media and save to TARGET COMPUTER as <driver install directory>.
The <driver install directory> is the directory folder where all the files in the driver install media get uncompressed and copied to.
The name of the <driver install directory> can be any valid string name of the user choice.

BEFORE PROCEED, PLEASE CONSULT THE "NOTES" SECTION AT THE BOTTOM OF THIS DOCUMENT FOR SPECIAL USE CASES.

NORMAL(INTERACTIVE) INSTALL/UNINSTALL (for normal user)
=======================================================

1) INSTALLATION: The driver can be installed to target computer by following one of the below methods:

a/ Method 1 -- Install from a command prompt

   i/ Open a Command Prompt with "elevated priviledge". Right click "Start->All Programs->Accessories->Command Prompt". 
      Select "Run as administrator".
  ii/ cd <driver install directory>
 iii/ Run setup.bat
  iv/ Follow installation instructions.
  

b/ Method 2 -- Install from Windows Explorer

(Note: This method recommended if the <driver install directory> is stored localy on target machine. Do not use
       this method if the <driver install directory> is stored in a network location)
       
   i/ Open the <driver install directory> with Windows Explorer.
  ii/ Right click the file "setup.bat" and select "Run as administrator"
 iii/ Follow installation instructions.


2) UNINSTALLATION: The installed driver can be uninstalled from target computer by following one of the below methods:

a/ Method 1 - Uninstall from <Control Panel>\<Uninstall a program>

   i/ Start->Control Panel->Uninstall a program
  ii/ Select "Honeywell USB Serial Driver xxx". Click "Uninstall"
 iii/ Follow uninstallation instructions.

b/ Method 2 -- Uninstall from a command prompt

   i/ Open a Command Prompt with "elevated priviledge". Right click "Start->All Programs->Accessories->Command Prompt". 
      Select "Run as administrator".
  ii/ cd <driver install directory>
 iii/ Run setup.bat
  iv/ Follow uninstallation instructions.

c/ Method 3 -- Uninstall from Windows Explorer

(Note: This method recommended if the <driver install directory> is stored localy on target machine. Do not use
       this method if the <driver install directory> is stored in a network location)      
        
   i/ Open the <driver install directory> with Windows Explorer.
  ii/ Right click the file "setup.bat" and select "Run as administrator"
 iii/ Follow uninstallation instructions.

SILENT(NON INTERACTIVE) INSTALL/UNINSTALL (for IT/System Administrator)
=======================================================================
This driver package can also be silently installed/uninstalled if required. 
This approach should NOT be used by a normal user but rather by an IT/Administrator personel.
 
a/ Silently install the driver package on target machine
  i/ Launch a command prompt with elevated priviledge
 ii/ cd <driver install directory>
iii/ setup.bat /silent /install [/machine | /user]
      If there was not already a version of the driver installed on target machine, this driver version will be installed automatically.
      Else, no action.
      Note: For silent installation, the user now can optionally provide a third parameter for specifying whether the install is per machine or per
            current user. If the third parameter is not provided, per user install will be done.
      

b/ Silently uninstall the installed driver package on target machine
  i/ Launch a command prompt with elevated priviledge
 ii/ cd <driver install directory>
iii/ setup.bat /silent /uninstall 
      If there is a version of the driver installed on target machine, this driver version will be uninstalled automatically.
      Else, no action
      
SILENT INSTALL RETURN CODE:
0      -- SUCCESS    - Requested action executes successfully
1      -- DO NOTHING - Requested action is not executed since there is nothing to do
2      -- FAILURE    - Requested action executes with a general failure
n > 2  -- FAILURE    - Requested action executes with a specific failure code n, such as MSI failure code


The Driver Documentations will be installed on target computer under the folder location supplied 
during the driver install wizard.

1/ "HSM USB Serial Driver Release Notes.pdf" -- List of device supported, supported OS, Known Issues.

2/ "HSM USB Serial Driver - WDReg Usage.pdf"  -- Driver installation utility. This is for customer that need to write their own
                                                installation for the driver, else normal customer will never need it.
                                               
3/ "HSM USB Serial Driver Force COM Port.pdf" -- Usage of the Driver "Force COM Port" feature.

4/ "HSM USB Serial Driver - Debug Logging.pdf" -- Instruction for enable/disable driver logging.

NOTES:
======
1/ The Microsoft Visual C++ 2010 Redistributable Package is required for driver install and shall be installed automatically if the target pc does not already have it.

2/ Network location Install/Uninstall.
If the <driver install directory> is stored in a network location, it is recommended that you install/uninstall
the driver using the "command prompt" method, and do not use the "Windows Explorer" method.
You will need to map the network location to a Windows drive as shown in the below steps:

   a. Launch a command prompt with elevated priviledge
   b. Map the network location to a Windows local drive, say k:
     net use k: \\<share-network-computer>\<shared-folder> * /user:test
   c. Supply the password when prompted
   d. Check to make sure that the newly created network drive is good to go.
      net use
      The status should show "OK"

3/ It is recommended to copy the driver package to target pc's hard drive and run the driver installer from there instead of from a USB flash drive due to the 
instability of a flash drive file system.
      
4/ Special character in the directory path of the <driver install directory>
If you have decided to copy the <driver install directory> to directory location on the target computer
that has special character. Install/Uninstall may not work well using the "Windows Explorer" method.
It is best to use the "command prompt" method.
For example: You have a user log account as "R&D", and copy the driver package to your desktop. So the 
<driver install directory> will be at: C:\User\R&D\Desktop\<driver install directory>

Because of the special character "&" in the directory path, running anything under there from Windows Explorer will
have an issue. In this situation, it is recommended that you use the "command prompt" method.

4/ On WEPOS 1.x, when the WHQL signed driver is installed and loaded. The "Digital Signer" field in device properties driver tab, under
Windows Device manager, will show "Not Digitally Signed" instead of "Microsoft Windows Hardware Compatibility Publisher".
This is an expected behavior on these OS due to a software limitation in the OS which Microsoft will not fix.

5/ Silent install can only be done via command prompt method only