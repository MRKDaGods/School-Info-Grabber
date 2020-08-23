/*
 * Copyright (c) 2020, Mohamed Ammar <mamar452@gmail.com>
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice, this
 *    list of conditions and the following disclaimer.
 *
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

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
