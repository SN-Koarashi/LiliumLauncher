[![Releases Download Counter](https://img.shields.io/github/downloads/SN-Koarashi/LiliumLauncher/total.png?style=for-the-badge&color=0969da&label=Downloads)](https://github.com/SN-Koarashi/LiliumLauncher/releases/latest)
[![Releases version](https://img.shields.io/github/v/release/SN-Koarashi/LiliumLauncher.png?style=for-the-badge&color=0969da&label=releases)](https://github.com/SN-Koarashi/LiliumLauncher/releases/latest)

# Lilium Launcher - 輕量化的解決方案 | Lightweight solution
Simple third-party Minecraft launcher that can install mods and download resources quickly.

簡單的可安裝模組及高速下載資源的第三方 Minecraft 啟動器。

- With self-renewal function
  - 具有自我更新功能
- Minecraft launcher function (Forge, Fabric, OptiFine, LiteLoader can be installed), the maximum support is the latest snapshot version, and the minimum support is version 1.0
  - Minecraft 啟動器功能(可安裝 Forge、Fabric、OptiFine、LiteLoader)，最高支援到最新快照版本，最低支援到1.0版本
- Multiple language (Now supporting English, Traditional Chinese and Simplified Chinese)
  - 多國語言功能

[更新過程預覽](https://youtu.be/Qi6jolpD43w) | [Updater Preview](https://youtu.be/Qi6jolpD43w)

## 安裝 | Installation
- Download `LiliumLauncher-SFXInstaller.exe` and double-click to install, this is the NSIS installer
  - 下載 `LiliumLauncher-SFXInstaller.exe` 後雙擊即可安裝，此為 NSIS 安裝程式
- If the update file is installed by the application itself, it will be installed in silent mode after downloading, and the installation path will be selected according to the execution location of the self-updater (`LiliumLauncher-Updater`)
  - 若由應用程式本身安裝更新檔案，將會在下載後使用安靜模式安裝，並且依照自我更新程式(`LiliumLauncher-Updater`)之執行位置來選擇安裝路徑

## 編譯 | Compile
- Because the project itself uses the Costura.Fody NuGet package, there may be `A numeric comparison was attempted on "$(MsBuildMajorVersion)" that evaluates to "" instead of a number, in condition "($(MsBuildMajorVersion) < 16)".` errors during compilation/debugging, as long as you uninstall and reinstall Costura.Fody in the NuGet package management, it can be resolved
  - 因為專案本身有使用 Costura.Fody NuGet套件包，因此可能會在編譯/偵錯過程出現 `MSB4086: 嘗試對條件 "($(MsBuildMajorVersion) < 16)" 中評估為 "" (而非數字) 的 "$(MsBuildMajorVersion)" 進行數字比較。` 的錯誤，只要在 NuGet 套件管理中解除並重新安裝 Costura.Fody 即可解決

## 附註 | Note
- LiliumLauncher focuses on the lightweight of the original launcher. If you want to use a beautiful, multi-functional, and convenient launcher, you can refer to [MultiMC](https://multimc.org/) or [Prism Launcher](https://prismlauncher.org/).
  - LiliumLauncher 主要以原版啟動器的輕量化為主，如果想使用兼具美觀、多功能、方便性的啟動器，可以參考 [MultiMC](https://multimc.org/) 或 [Prism Launcher](https://prismlauncher.org/)。

## 參考 | Reference
- [[UPDATE] Google Auth Flows and WebView2](https://github.com/MicrosoftEdge/WebView2Feedback/issues/1647)
- [OAuth for Apps: Samples for Windows](https://github.com/Beej126/oauth-apps-for-windows)
- [Fix: “A numeric comparison was attempted” at VS build (Costura.Fody)](https://zoomicon.wordpress.com/2019/10/18/fix-a-numeric-comparison-was-attempted-at-vs-build-costura-fody/)
