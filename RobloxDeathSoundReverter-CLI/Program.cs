using CommandLine;

namespace RobloxDeathSoundReverter_CLI
{
    internal class Program
    {
        public class Options
        {
            [Option("mode", Required = true, HelpText = "The ROBLOX death sound type")]
            public string mode { get; set; } = string.Empty;
        }


        private static async Task<int> Main(string[] args)
        {
            ParserResult<Options> parserResult = Parser.Default.ParseArguments<Options>(args);
            if (parserResult.Tag != ParserResultType.Parsed) return 1;

            Options options = ((Parsed<Options>)parserResult).Value;

            if (options.mode != "new" && options.mode != "old")
            {
                Console.WriteLine("Invalid mode (new/old)");
                return 1;
            }

            string? robloxDir = RobloxUtils.GetRobloxDirectory();

            if (robloxDir == null)
            {
                Console.WriteLine("Failed to find roblox directory");
                return 1;
            }

            using (HttpClient httpClient = new HttpClient())
            {
                string baseDir = Path.Join(robloxDir, @"content\sounds\");
                string oofDir = Path.Join(baseDir, "ouch.ogg");

                string oofUrl = "https://github.com/jluims/RobloxDeathSoundReverter/raw/main/sounds/" + (options.mode == "new" ? "ouch" : "uuhhh") + ".ogg";
                byte[] oofBytes = await httpClient.GetByteArrayAsync(oofUrl);

                File.WriteAllBytes(oofDir, oofBytes);
            }

            Console.WriteLine("Death sound succesfully changed");

            return 0;
        }
    }
}