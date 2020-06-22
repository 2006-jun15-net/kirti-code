using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serialization.DataModel;

namespace Serialization
{
    class Program
    {
        static async Task Main(string[] args)
        {

            // (for your program, the string directory is bin/Debug/netcoreapp3.1
            string filePath = "../../../data.json";

            List<PlayerStats> data;
            try
            {
                //serilize the objects into a string in JSON format
                string initialJson = await File.ReadAllTextAsync(filePath);
                data = JsonConvert.DeserializeObject<List<PlayerStats>>(initialJson);
            }
            catch (FileNotFoundException)
            {
               data = GetinitialData();
            }

            data[0].Name += "+";

            string json = ConvertToJason(data);

            await WriteStringToFile(filePath, json);

            // at this point the file is efinately written 

        }

        /// <summary>
        /// serilize the objects into a string in JSON format
        /// </summary>
        /// <param name="data">the data</param>
        /// <returns>serialized JSON</returns>
        private static string ConvertToJason(List<PlayerStats> data)
        {
            // in .NET core, use a program called NuGet
            // to resolve dependencies and download them from the registries (usually NuGet.org)

            return JsonConvert.SerializeObject(data, Formatting.Indented);

            //can customize with optional parameters to that method
            // or, with attributes on the PlayerStats class and properties themselves.
        }

        // when doing somethis async:
            // 1. call async version of whatever library method
            // 2. await that task
            // 3. mark the current method with async modifier
            // 4. if the method returns type T, change it to return type Task<T>
                // if it returns void, change to to return type task
            // 5. as a matter of convention, add the Async suffix to your methos.
            // continue again frm step 1 on the parts of your code that are now broken
        public async static Task WriteStringToFile(string filePath, string json)
        {
            await File.WriteAllTextAsync(filePath, json);

            /*--------------------------------------------------OR-------------------------------------------------------------*/
            // for more control over the file I/O, we would uaually a filestream object.

            // the CLR manages the memory for all the CLR objects with garbage collection.
            // otherwise, there will be memory leaks anytime I failed to manually clean up any object.

            // any time you have .NET code open or access some resources OUTSIDE the CLR
            // (like the hard drive), you so need to manually tell it when you are done to avoid problems.
            // the Disposable interface is implemented by any class which you need to do this for.

            /*FileStream fileStream = null;
            try
            {
                // if you are fine with the resource not being disposed until the variable goes out of scope.. you can use this form of using statement.
                fileStream = new FileStream(filePath, FileMode.Create);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing fileL {ex.Message}");
            }
            finally
            {
                // what if an exception is thrown at any point beforehand?
                //if (fileStream != null)
                //    fileStream.Dispose();
                fileStream?.Dispose();
                // C# has an operator "?." which calles a method for access a property/field/etc.
            }*/
            //C# has a "using statement" to replace boilerplate "resource = null, try, finally, resource.Dispose"

            //using (var fileStream = new FileStream(filePath, FileMode.Create))
            //{

            //} // right here, at the closing brace, is effectively "finally { resource?.Dispose() }"
        }

        private static List<PlayerStats> GetinitialData()
        {

            /* 
             * var thePlayerStatistics = new PlayerStats();
             * thePlayerStatistics.ArcLocation = null;
             * thePlayerStatistics.FreeThrowPercentage = 100;
             * thePlayerStatistics.PointsPerGame = 12;
             * 
             * The below property is same as this piece of code
            */
            //var thePlayerStatistics = new PlayerStats
            //{
            //    //    Name = "Lebron James",
            //    FreeThrowPercentage = 65,
            //    PointsPerGame = 25,
            //    ArcLocation = new Dictionary<int, double>
            //    {
            //        [-150] = 30,
            //        [-120] = 30,
            //        [-90] = 30
            //    }
            //};

            return new List<PlayerStats>
            {
                new PlayerStats
                {
                    Name = "Lebron James",
                    FreeThrowPercentage = 65,
                    PointsPerGame = 25,
                    ArcLocation = new Dictionary<int, double>
                    {
                        [-150] = 30,
                        [-120] = 30,
                        [-90] = 30
                    }
                },

                new PlayerStats
                {
                    Name = "Lebron James",
                    FreeThrowPercentage = 65,
                    PointsPerGame = 25,
                    ArcLocation = new Dictionary<int, double>
                    {
                        [-150] = 30,
                        [-120] = 30,
                        [-90] = 30
                    }
                },

                new PlayerStats
                {
                    Name = "Lebron James",
                    FreeThrowPercentage = 65,
                    PointsPerGame = 25,
                    ArcLocation = new Dictionary<int, double>
                    {
                        [-150] = 30,
                        [-120] = 30,
                        [-90] = 30
                    }
                }
            }; // this syntax can be used for anything
        }
    }
}
