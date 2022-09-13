# XCoreNET - 輕量化的解決方案 | Lightweight solution (Display language is Traditional Chinese ONLY)
透過 Microsoft Edge WebView2 框架載入多個社交媒體網站及網路即時聊天室

Load multiple social media sites and web chat rooms through the Microsoft Edge WebView2 framework

- 具有自我更新功能
- With self-renewal function
- 網路聊天室採用 WebSocket
- Website chat room using WebSocket
- 由於是遠端載入，因此聊天室的功能更新並不需要更新應用程式本身
- Due to remote loading, the function update of the chat room does not require updating the application itself
- Minecraft 啟動器功能(可安裝 Forge、Fabric、OptiFine、LiteLoader)，最高支援到最新快照版本，最低支援到1.0版本
- Minecraft launcher function (Forge, Fabric, OptiFine, LiteLoader can be installed), the maximum support is the latest snapshot version, and the minimum support is version 1.0

[更新過程預覽](https://youtu.be/Qi6jolpD43w) | [Updater Preview](https://youtu.be/Qi6jolpD43w)

## 安裝 | Installation
- 下載 `XCoreNET-SFXInstaller.exe` 後雙擊即可安裝，此為 NSIS 安裝程式
- Download `XCoreNET-SFXInstaller.exe` and double-click to install, this is the NSIS installer
- 若由應用程式本身安裝更新檔案，將會在下載後使用安靜模式安裝，並且依照自我更新程式(`XCoreNET-Updater`)之執行位置來選擇安裝路徑
- If the update file is installed by the application itself, it will be installed in silent mode after downloading, and the installation path will be selected according to the execution location of the self-updater (`XCoreNET-Updater`)

## 編譯 | Compile
- 因為專案本身有使用 Costura.Fody NuGet套件包，因此可能會在編譯/偵錯過程出現 `MSB4086: 嘗試對條件 "($(MsBuildMajorVersion) < 16)" 中評估為 "" (而非數字) 的 "$(MsBuildMajorVersion)" 進行數字比較。` 的錯誤，只要在 NuGet 套件管理中解除並重新安裝 Costura.Fody 即可解決

## 參考 | Reference
- [[UPDATE] Google Auth Flows and WebView2](https://github.com/MicrosoftEdge/WebView2Feedback/issues/1647)
- [OAuth for Apps: Samples for Windows](https://github.com/Beej126/oauth-apps-for-windows)
- [Fix: “A numeric comparison was attempted” at VS build (Costura.Fody)](https://zoomicon.wordpress.com/2019/10/18/fix-a-numeric-comparison-was-attempted-at-vs-build-costura-fody/)
