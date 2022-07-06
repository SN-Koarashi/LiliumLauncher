# WebChat - 網路聊天室
透過 Microsoft Edge WebView2 框架載入多個社交媒體網站及網路即時聊天室
- 具有自我更新功能
- 網路聊天室採用 WebSocket
- 由於是遠端載入，因此聊天室的功能更新並不需要更新應用程式本身

[更新過程預覽](https://youtu.be/Qi6jolpD43w)

## 安裝
- 下載 `webchat-autoInstaller.exe` 後雙擊即可安裝，此為 WinRAR 自我解壓縮檔案(WinRAR SFX)
- 若由應用程式本身安裝更新檔案，將會在下載後使用安靜模式安裝，並且依照自我更新程式(`webchat-updater`)之執行位置來選擇解壓縮路徑

## 參考
- [[UPDATE] Google Auth Flows and WebView2](https://github.com/MicrosoftEdge/WebView2Feedback/issues/1647)
- [OAuth for Apps: Samples for Windows](https://github.com/Beej126/oauth-apps-for-windows)
