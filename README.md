# Sweriks URP Template

![Release](https://github.com/TheSwerik/URPTemplate/workflows/Release/badge.svg)

This is an URP Template without any example Assets but with recommended Settings and preinstalled Packages. (recommended by me)

## How to install
* Download the [latest Release](https://github.com/TheSwerik/URPTemplate/releases)
* Put the file into `INSTALL_FOLDER_OF_UNITY_EDITOR\Editor\Data\Resources\PackageManager\ProjectTemplates`
* Restart Unity Hub if you are using it. If not restart Unity

## How to create your own Template
* Download and unzip the [latest Release](https://github.com/TheSwerik/URPTemplate/releases)
* Overwrite the `Assets`, `ProjectSettings` and `Packages` in `package\ProjectData~`
* Remove `ProjectSettings\ProjectVersion.txt`
* Adjust everything in `package\README.md`, `package\CHANGELOG.md` and `package\package.json`
* Zip the `package` to a `.tar` and then to a `.gz` and change the extension from `.tar.gz` to `.tgz`
    * This can be done in one step in Ubuntu with the `tar`-command: `tar -czvf FILENAME.tgz package`

This can also be automated with Github Actions. Feel free to copy **and adjust** my [Action](https://github.com/TheSwerik/URPTemplate/blob/main/.github/workflows/release.yml).