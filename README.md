# 🧲 C# Web Scraper + PowerShell Executor + Self-Deleting EXE

This project demonstrates how to:

- 🌐 Scrape a webpage using C# + HtmlAgilityPack
- 📤 Extract and decode a PowerShell command
- 🖥️ Execute the command on Windows
- 🧹 Self-delete the EXE after execution

---

## ⚙️ Features

- Downloads HTML from a Pastebin link  
- Filters out the PowerShell command using XPath  
- Automatically replaces paths to target Desktop  
- Executes silently using PowerShell  
- Deletes itself after execution

---

## 🌐 Install .NET 8.0 SDK on Kali

> Kali Linux doesn’t always come with the latest .NET SDK. Use Microsoft’s official script:
Step 1: install dotnet

>> wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
>> chmod +x dotnet-install.sh
>> ./dotnet-install.sh --channel 8.0

Then export the required environment paths:

>> export DOTNET_ROOT=$HOME/.dotnet
>> export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools

##💡 Add the export lines to your ~/.bashrc or ~/.zshrc to make them permanent.

Step 2: Create a New Console App

>> dotnet new console -n App
>> cd App

Replace the contents of Program.cs with the C# code from this repo.

Install the required dependency:

dotnet add package HtmlAgilityPack

Step 3: Build to Windows .exe

To build a Windows-compatible .exe from Kali, run:

>> dotnet publish -c Release -r win-x64 --self-contained true \
  -o winbuild \
  /p:PublishSingleFile=true \
  /p:IncludeNativeLibrariesForSelfExtract=true \
  /p:StripSymbols=true

  
