using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Terragard
{
    class IOscript : Types
    {
        public static string[] worldLevel;

        /*paths:
        DebugWorld: "D:\\Other\\Terragard\\DebugWorld.txt"
        */

        [STAThread]
        public static void ReadFile(string path)
        { 
            String line;

            try
            {
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();
                
                int count = 1; 
                while (line != null)
                {
                    count++; 
                    line = sr.ReadLine();
                } 
                sr.Close();

                sr = new StreamReader(path); 
                int i = 0;

                worldLevel = new string[count];
                line = sr.ReadLine();
                 
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window 
                    worldLevel[i] = line;
                    i++;

                    //Read the next line
                    line = sr.ReadLine();
                } 
                sr.Close(); 
            }
            catch (Exception e)
            {
                Console.WriteLine("IOscript reading file exception: " + e.Message);
            } 
            finally
            {
                Console.WriteLine("IOscript reading file: " + path + " END");
            }
        }

        public static void WriteFile(string path)
        {
            try
            {  
                StreamWriter sw = new StreamWriter(path);

                foreach( TextureID tex in World.blocks)
                {
                    sw.WriteLine(tex);
                }
                 
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("IOscript writing file exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("IOscript writing file: " + path + " END");
            }
        }
    }
}
