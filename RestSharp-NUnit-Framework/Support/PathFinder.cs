using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharp_NUnit_Framework.Support
{
    internal class PathFinder
    {
        public static string GetPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = currentDirectory;
            while (true)
            {
                if (Directory.Exists(path + "\\RestSharp-NUnit-Framework"))
                {
                    return path;
                }
                else
                {
                    path = Directory.GetParent(path).ToString();
                }
            }
        }
    }
}