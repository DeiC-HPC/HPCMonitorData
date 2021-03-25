using DeiC_HPC_Usage_Data;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace DeiC_HPC_Usage_Data_Verify
{



    class Program
    {
        static int Main(string[] args)
        {
            var rootCommand = new RootCommand
            {
                new Option<FileInfo>(
                        "--center",
                        "File path to center daily"),
                new Option<FileInfo>(
                        "--person",
                        "File path to person"),
                new Option<bool>("--parseDatelLax", getDefaultValue: () => false, "Use this option if the you want to lax the parsing of the date")
            };

            rootCommand.Description = "Verify Danish HPC Usage data.";

            // Note that the parameters of the handler method are matched according to the names of the options
            rootCommand.Handler = CommandHandler.Create<FileInfo, FileInfo, bool>(HandleInput);
            // Parse the incoming args and invoke the handler
            return rootCommand.InvokeAsync(args).Result;
        }
        public static void HandleInput(FileInfo center, FileInfo person, bool laxDateTimeParse)
        {
            if (!center?.Exists ?? false)
            {
                Console.WriteLine($"Center file option or file not found");
                return;
            }

            if (!person?.Exists ?? false)
            {
                Console.WriteLine($"Person file option or file not found");
                return;
            }

            List<Person> persons = new();
            List<CenterDaily> centerDailies = new();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                Encoder = JavaScriptEncoder.Default,  

            };
            if (laxDateTimeParse)
            {
                options.Converters.Add(new DateTimeConverterUsingDateTimeParse());
            }
            try
            {
                var jsonPersonString = File.ReadAllText(person.FullName);
                persons = JsonSerializer.Deserialize<List<Person>>(jsonPersonString, options) ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error parsing the json for person");
                return;
            }

            try
            {
                var jsonCenterDailyString = File.ReadAllText(center.FullName);
                centerDailies = JsonSerializer.Deserialize<List<CenterDaily>>(jsonCenterDailyString, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error parsing the json for centerdaily");
                return;
            }



        }

    }
}
