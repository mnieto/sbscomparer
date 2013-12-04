; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!
#ifndef DeployType
#define DeployType "Debug"
#endif
#define CurrentVersion GetFileVersion("..\SideBySide\bin\" + DeployType + "\SBSComparer.exe")

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{2E7479AB-D983-4980-BCA4-88F0C1EBE313}
AppName=SideBySideComparer
AppVerName=SideBySideComparer {#CurrentVersion}
VersionInfoVersion={#CurrentVersion}
AppPublisher=Kevull
DefaultDirName={userappdata}\Kevull\SBSComparer
DisableDirPage=false
DefaultGroupName=Kevull\SideBySideComparer
DisableProgramGroupPage=true
OutputDir=.
OutputBaseFilename=SBSComparer_{#CurrentVersion}_{#DeployType}_Setup
SetupIconFile=..\SideBySide\Resources\SBSComparer.ico
Compression=lzma
SolidCompression=true
PrivilegesRequired=none

[Languages]
Name: english; MessagesFile: compiler:Default.isl
Name: spanish; MessagesFile: compiler:Languages\Spanish.isl

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked

[Files]
Source: ..\SideBySide\bin\{#DeployType}\*; DestDir: {app}; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: {group}\SBSComparer; Filename: {app}\SBSComparer.exe; WorkingDir: {app}; IconFilename: {app}\SBSComparer.exe; Comment: Side by side comparer
Name: {userdesktop}\SBSComparer; Filename: {app}\SBSComparer.exe; Tasks: desktopicon; WorkingDir: {app}; Comment: Side by side comparer
Name: {group}\{cm:UninstallProgram, SideBySideComparer}; Filename: {uninstallexe}

[Run]
Filename: {app}\SBSComparer.exe; Description: {cm:LaunchProgram,SBSComparer}; Flags: nowait postinstall skipifsilent; WorkingDir: {app}