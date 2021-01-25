using Microsoft.Win32;
using NReco.VideoConverter;
using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace cffmpeg
{
    class Program
    {
     
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string mp4 = args[0];
                if (IsFormatsVideo(mp4))
                {
                    string mp3 = mp4.Replace(System.IO.Path.GetExtension(mp4),".mp3");
                    new FFMpegConverter().ConvertMedia(mp4, mp3, "mp3");
                }

                
            }
            else if (args.Length == 0)
            {
                
                Console.WriteLine($"\n reg - добавление в контекстное меню комманду.\n, help - вывод информации.\n");
                Console.WriteLine("https://i.imgur.com/d4hSvP4.png");

                while (true)
                {
                    switch (Console.ReadLine().ToLower().Replace(" ", ""))
                    {
                        case "reg":
                            string path = System.IO.Path.GetFullPath(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                            Console.WriteLine(path);

                            if (isAdm())
                            {
                                RegshellCffmpeg(path);
                            }
                            else
                            {
                                Console.WriteLine("Требуется запуск от имени администратора!");                              
                            }
                            
                            break;
                        case "help":
                            Console.WriteLine("1. Создать файл \"run.bat\" с \"cffmpeg.exe Media.mp4\"");
                            Console.WriteLine("2. Запустить \"run.bat\"\n\n");
                            Console.WriteLine("Принимает только путь к .mp4 фалу.");
                            Console.WriteLine("\n\nДобавить в контекстное меню \"mp4 to mp3\"");
                            Console.WriteLine($"HKEY_CLASSES_ROOT{"\\*\\"}shell\\");
                            break;
                        default:
                            break;
                    }
                }


                
            }

        }

        public static void RegshellCffmpeg(string pith_cffmpeg_exe)
        {
            string Convert = @"HKEY_CLASSES_ROOT\*\shell\Convert";
            string Command = @"HKEY_CLASSES_ROOT\*\shell\Convert\shell\video to mp3\command";
            string cmd = $"\"{pith_cffmpeg_exe}\" \"%1\"";


            Microsoft.Win32.Registry.SetValue(Convert, "SubCommands", "");
            Microsoft.Win32.Registry.SetValue(Convert, "MUIVerb", "Convert");
            Microsoft.Win32.Registry.SetValue(Command, "", cmd);
        }
        public static bool IsFormatsVideo(string mp4)
        {
            string[] format = { ".mp4", ".mkv" };
            bool b = false;

            foreach (string f in format)
            {
                if (f == System.IO.Path.GetExtension(mp4))
                {
                    b = true;
                    break;
                }
                else
                {
                    b = false;
                }
            }
            return b;
        }
        public static bool isAdm()
        {
            bool isElevated;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            return isElevated;
        }

    }
}
