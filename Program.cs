namespace correct_dict;

internal class Program
{
    static string path = "";
    static void Main(string[] args)
    {
        var watch = new Stopwatch();

        Console.Write("Path to wordlist: ");
        path = Console.ReadLine();
        if (File.Exists(path))
        {
            watch.Start();
            Detect(path);
        }
        watch.Stop();
        Console.WriteLine($"Done in {watch.Elapsed.ToString(@"hh\:mm\:ss\:fff")} ms, press any key to exit");
        Console.Read();
    }

    static void Detect(string path)
    {
        string ext = Path.GetExtension(path);
        string[] lines = File.ReadAllLines(path);
        var distinctArray = lines.Distinct().ToArray();
        lines = lines.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).ToArray();
        Console.WriteLine($" Detected dupliacate: {lines.Length}");
        File.WriteAllLines(path.Replace($"{ext}", $".clean{ext}"), distinctArray);
        File.WriteAllLines(path.Replace($"{ext}", $".removedData{ext}"), lines);
    }

}