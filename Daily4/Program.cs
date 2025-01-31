using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
    
        var filePaths = new List<string>
        {
            "file1.txt",
            "file2.txt",
            "file3.txt"
        };

        var tasks = new List<Task>();

        foreach (var filePath in filePaths)
        {
            tasks.Add(ReadFileAsync(filePath));
        }

        await Task.WhenAll(tasks);

        Console.WriteLine("All files read successfully.");
    }

    static async Task ReadFileAsync(string filePath)
    {
        if (File.Exists(filePath))
        {
        
            var content = await File.ReadAllTextAsync(filePath);
            Console.WriteLine($"Content of {filePath}:");
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine($"File {filePath} does not exist.");
        }
    }
}