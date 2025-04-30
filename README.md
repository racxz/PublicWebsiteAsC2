# 🧲 C# Web Scraper + PowerShell Executor + Self-Deleting EXE

This project demonstrates how to:

- 🌐 Scrape a webpage using C# + HtmlAgilityPack  
- 📤 Extract and decode a PowerShell command  
- 🖥️ Execute the command on Windows  
- 🧹 Self-delete the EXE after execution  

---

## ⚙️ Features

- Downloads HTML from a Pastebin link  
- Extracts PowerShell command using XPath  
- Decodes HTML entities and targets Desktop path  
- Executes silently using PowerShell  
- Deletes itself after execution  

---

## 🌐 Step 1: Install .NET 8.0 SDK on Kali

Kali Linux may not include the latest .NET SDK. Use Microsoft’s official script to install it:

```bash
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --channel 8.0
```
Then export the following environment variables to make .NET available in your terminal:
```
export DOTNET_ROOT=$HOME/.dotnet
export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools
```
💡 To make the environment variables persistent across terminal sessions, add the export lines to your ~/.bashrc or ~/.zshrc.

🧠 Step 2: Create a New Console App

Run the following commands to create a new console app and navigate into the project folder:
```
dotnet new console -n App
cd App
```
Next, replace the contents of Program.cs with the code provided in this repository.
You will also need to install the required NuGet package:
```
dotnet add package HtmlAgilityPack
```
🛠 Step 3: Build to a Windows .exe

To build the project as a self-contained Windows .exe file, use the following command:
```
dotnet publish -c Release -r win-x64 --self-contained true \
  -o winbuild \
  /p:PublishSingleFile=true \
  /p:IncludeNativeLibrariesForSelfExtract=true \
  /p:StripSymbols=true
```

