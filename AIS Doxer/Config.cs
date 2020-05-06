using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MRK {
    public class Config {
        const string EXT = ".ammar";
        
        string m_ConfigPath;

        public string Username => GetValueOf("user");
        public string Password => GetValueOf("pass");
        public string OutputPath => GetValueOf("output_path");
        public double MaximumHypotheticalRam => double.Parse(GetValueOf("max_ram"));
        public int Threshold => int.Parse(GetValueOf("threshold"));

        public Config(out bool wasMissing) {
            wasMissing = false;

            string rawPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string[] files = Directory.EnumerateFiles(rawPath.Substring(0, rawPath.LastIndexOf('\\')), $"*{EXT}").ToArray();
            if (files.Length == 0) {
                wasMissing = true;
                //create config file
                m_ConfigPath = $"config{EXT}";
                File.WriteAllLines(m_ConfigPath, new string[] {
                    "#Username",
                    "user=USERNAME",

                    "\n#Password",
                    "pass=PASSWORD",

                    "\n#Output path of info",
                    "output_path=ammardox.txt",

                    "\n#Maximum ram usage (HYPOTHETICAL) PLEASE LEAVE ALONE!",
                    "max_ram=1500",

                    "\n#Maximum number of workers",
                    "threshold=500"
                });
            }
            else
                m_ConfigPath = files[0];
        }

        string GetValueOf(string key) {
            foreach (string line in File.ReadAllLines(m_ConfigPath)) {
                string realStr = line.Trim(' ');
                if (realStr.StartsWith("#"))
                    continue;

                int eqidx = realStr.IndexOf('=');
                if (eqidx == -1)
                    continue;

                if (realStr.Substring(0, eqidx) == key)
                    return realStr.Substring(eqidx + 1);
            }

            return "";
        }
    }
}
