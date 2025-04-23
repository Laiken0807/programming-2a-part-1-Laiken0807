using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cybersecurity
{
    internal class Program
    {
        static void Main()
        {


            // play audio greeting
            PlayGreetingAudio("cyber_bot.wav");

            Console.Title = "Cybersecurity Awareness Assistant Chatbox";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@" 


_________        ___.               __________        __   
\_   ___ \___.__.\_ |__   __________\______   \ _____/  |_ 
/    \  \<   |  | | __ \_/ __ \_  __ \    |  _//  _ \   __\
\     \___\___  | | \_\ \  ___/|  | \/    |   (  <_> )  |  
 \______  / ____| |___  /\___  >__|  |______  /\____/|__|  
        \/\/          \/     \/             \/             

");

            Console.Write("What is your name?");
            Console.ForegroundColor = ConsoleColor.White;

            string userName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine($"Hello,{userName}! I'm your Cybersecurity Assistant.");
            Console.WriteLine("You can ask me about password safety, phishing, malware, safe browsing or you can type 'exit' to quit.\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write($"{userName}: ");

                string userInput = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Chatbox: Please can you enter a valid question.");
                    Console.WriteLine();

                    continue;
                }
                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Chatbox: Thank you for using CyberBot! Stay safe online, bye!");
                    Console.WriteLine();

                    break;
                }

                HandleUserQuery(userInput, userName);
            }
        }
        static void PlayGreetingAudio(string filePath)
        {
            try
            {
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                if (File.Exists(fullPath))
                {
                    SoundPlayer player = new SoundPlayer(fullPath);
                    player.PlaySync(); // Play audio synchronously
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {filePath} was not found at the specified location");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error playing audio: {ex.Message}");
            }
        }

        static void HandleUserQuery(string input, string userName)
        {
            Dictionary<string, string> responses = new Dictionary<string, string>
            {
                 {"how are you?", "I'm good but I am just a program here to help you with cybersecurity!" },

                 {"what's your purpose?", "My purpose is to provide you with information and tips on cybersecurity." },

                 {"what can i ask you about?", "You can ask about password safety, phishing, malware and safe browsing." },

                 {"password safety", "You can create a strong password by using a mix of letters both capital and lowercase, numbers, symbols " +
                 "and avoid using personal information such as your birthda etc. and make it at least 12 characters long."},

                 {"phishing", "Phishing attacks is a scam where an unauthorised user tries to trick you into giving personal information like passwords or bank details, " +
                  "by pretending to be a trusted source." +
                  "So i would advise you to never click suspicious links or share your credentials."},

                 {"malware", "Malware is malicious software made to damage, steal, or disrupt your computer and data by using viruses, spyware, ransomware etc." +
                 " You can protect yourself by:" +
                 "\n- Keeping your systems up to date\n- Use an antivirus\n- Avoid downloading anything suspicious"},

                 {"safe browsing","Practice safe browsing by: \nUse secure websites and look for “https” in the url" +
                "\n- Avoiding clicking on suspicious links \nKeep your browser updated \nDon't dowload anything from suspicious websites"}
            };
            if (responses.ContainsKey(input))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Chatbox: {responses[input]}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Chatbox: I'm not sure about that{userName}. Would you like me to tell you some essential cybersecurity tips? (yes/no)");

                string reply = Console.ReadLine()?.ToLower().Trim();

                if (reply == "yes")
                {
                    CyberSecurityTips();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Chatbox: No worries! Let me know if there is anything else i can help with");
                }
            }
        }


        static void CyberSecurityTips()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Chatbox: Here are some cybersecurity tips that are essential: ");
            Console.WriteLine();
            Console.WriteLine("1. Use strong and unique passwords for all of your accounts");
            Console.WriteLine("2. Enable two-factor authentication for extra safety! ");
            Console.WriteLine("3. Keep all your software and devices updated all the time ");
            Console.WriteLine("4. Be careful of suspicious emails or links as they might be phishing attempts");
            Console.WriteLine("5. Use a VPN on public networks or avoid using it at all when accessing sensitive information");
            Console.WriteLine("6. Regularly backup data that is important to you incase you're attacked");
            Console.WriteLine("7. Use antivirus and firewalls to block out threats for extra protection! ");


        }
    }
}



