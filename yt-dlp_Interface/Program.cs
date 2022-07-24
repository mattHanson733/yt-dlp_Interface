namespace yt_dlp_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] outputTemplates = {
                "%(playlist)s/%(playlist_index)s - %(title)s.%(ext)s",
                "%(playlist)s/%(playlist_index)s - %(title)s/%(id)s - %(title)s.%(ext)s",
                "%(id)s - %(title)s.%(ext)s",
                "%(title)s/%(id)s - %(title)s.%(ext)s"
            };
            string[] formatCodes = {
                "b,ba[ext=m4a]",
                "bv+ba"
            };

            string cookiesSelector = "--cookies-from-browser chrome";
            string OTcode ="";
            string Fcode = "";

            //Gets directory containing yt-dlp.exe and ffmpeg.exe + its related files
            Console.Write("Specificy working directory: ");
            string workingDir = Console.ReadLine();

            //Gets output folder from the user
            Console.Write("Specificy otput directory: ");
            string outputDir = Console.ReadLine();
            outputDir = outputDir;

            Console.Write("Input OT code(code 1 - 2 for playlist, 3 - 4 for video): ");
            string temp = Console.ReadLine();
            int OToption = int.Parse(temp);

            Console.Write("Input format code(1 or 2): ");
            temp = Console.ReadLine();
            int Foption = int.Parse(temp);

            Console.Write("Are you using a .bat file: ");
            string useBAT = Console.ReadLine();

            Console.Write(".bat file path OR video/playlist url: ");
            string inputPath = Console.ReadLine();


            if (OToption == 1)
            {
                OTcode = outputTemplates[1];
            }
            else if (OToption == 2)
            {
                OTcode = outputTemplates[2];
            }
            else if (OToption == 3)
            {
                OTcode = outputTemplates[3];
            }
            else if (OToption == 4) 
            {
                OTcode = outputTemplates[4];
            }


            if (Foption == 1)
            {
                Fcode = formatCodes[1];
            }
            else if (Foption == 2)
            {
                Fcode = formatCodes[2];
            }


            if (useBAT.ToLower() == "y") 
            {
                inputPath = $"-a {inputPath}";
            }

            string strCmdText;
            strCmdText = $@"/C cd {workingDir} & yt-dlp {cookiesSelector} -P {outputDir} -o ""{OTcode}"" -f ""{Fcode}"" {inputPath}";
            Console.WriteLine(strCmdText);
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }
    }
}