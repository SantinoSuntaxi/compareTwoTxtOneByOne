using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace aaascript
{
    class UsersCompare
    {
        private static string pathOne = Directory.GetCurrentDirectory();
        private static string pathTwo = "/DB_AAA.txt";
        private static string pathThree = "/Usuario_AAA.txt";
        private static string pathFour = "/Result_Dominio_AAA.txt";
        private static string allPath = pathOne + pathTwo;
        private static string allPathUsers = pathOne + pathThree;
        private static string allPathResult = pathOne + pathFour;
        private static ArrayList arrayData = new ArrayList();
        private static ArrayList arrayDataCompare = new ArrayList();
        private static ArrayList arrayResult = new ArrayList();
        private static ArrayList arraySearchResult = new ArrayList();




        private void printPathInConsole(string textPath)
        {
            System.Console.WriteLine(textPath);
        }

        

        public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.Write("   {0}", obj);
            Console.WriteLine();
        }

        private ArrayList compareArray(ArrayList compareArray)
        {
            

            foreach (string item in compareArray)
            {
                if (arrayDataCompare.Contains(item))
                {
                   ArrayList arrayData = compareArray;

                }
                else
                {
                    arrayData = compareArray;
                }
               
            }

            return  compareArray;

        }

        public ArrayList printCliTxtArray(string txtPatch)
        {
            ArrayList myAL = new ArrayList();
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(txtPatch);
            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of Users.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                myAL.Add(line);
                //Console.WriteLine("\t" + line);
            }
            return myAL;
        }
        static void Main()
        {

            UsersCompare userdata = new UsersCompare();
            userdata.printPathInConsole(UsersCompare.allPath);
            ArrayList arrayData = userdata.printCliTxtArray(UsersCompare.allPath);

            UsersCompare userClients = new UsersCompare();
            userClients.printPathInConsole(UsersCompare.allPathUsers);
            ArrayList arrayUsers = userClients.printCliTxtArray(UsersCompare.allPathUsers);
           
            String[] myArrUsers = (String[])arrayUsers.ToArray(typeof(string));
            String[] myArrData = (String[])arrayData.ToArray(typeof(string));

            foreach (var itemResult in myArrUsers)
            {
                var result = Array.Find(myArrData, element => element.StartsWith(itemResult));
               
                if (result == null)
                {
                    //Console.WriteLine(itemResult);
                    arraySearchResult.Add((itemResult + "@noexiste").ToString());
                    
                }
                else 
                {
                    //Console.WriteLine(result);
                    arraySearchResult.Add(result.ToString());
                }
                
            }

            String[] myArrSeachResult = (String[])arraySearchResult.ToArray(typeof(string));

         var path = UsersCompare.allPathResult;

            //string[] lines = { "old falcon", "deep forest", "golden ring" };
            File.WriteAllLines(path, myArrSeachResult);

            Console.WriteLine("lines written to file");
            

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

}
