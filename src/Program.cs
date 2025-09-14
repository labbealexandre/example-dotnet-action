using System.Text.RegularExpressions;

class Program
{
    static (bool, string) checkTitle(string[] args)
    {
        if (args.Length == 0)
        {
            return (false, "The path of the README.md file has not been provided.");
        }
        var filePath = args[0];

        Console.WriteLine(filePath);
        if (!File.Exists(filePath))
        {
            return (false, "The file path provided does not exists.");
        }
        var lines = File.ReadLines(filePath);

        if (lines.Count() == 0)
        {
            return (false, "The file provided is empty.");
        }
        var firstLine = lines.First();

        var pattern = @"\G#\s+.+";
        var m = Regex.Match(firstLine, pattern);
        if (m.Success)
        {
            return (true, "");
        }

        if (lines.Count() > 1)
        {
            var secondLine = lines.Skip(1).First();
            pattern = @"\G===";
            m = Regex.Match(secondLine, pattern);
            if (m.Success)
            {
                return (true, "");
            }
        }

        return (false, "The README.md file does not start with a title.");
        
    }
    static int Main(string[] args)
    {
        var (valid, error) = checkTitle(args);
        if (!valid)
        {
            Console.WriteLine(error);
            return 1;
        }
        
        return 0;
    }
}
