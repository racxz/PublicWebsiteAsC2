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

