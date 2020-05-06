using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MRK {
    public delegate void DocLoaded(object sender, WebBrowserDocumentCompletedEventArgs e);

    public partial class Main : Form {
        class UserInfo {
            public string Name;
            public string Href;
            public string Email;
            public List<string> Subjects;
        }

        const string USERNAME = "ammarwhatever@gmail.com";
        const string PASSWORD = "mohamed12345678";
        const int THRESHOLD = 40;
        const double HYPOTHETICAL_MEMORY = 300d; //300mb per WB
        const double MAX_MEMORY = 1500d; //i will just alloc for 1500MB for the browsers!
        const string FLEX = "fgh8743hg8g44frn3c94jc3mxmfmeniubierbfinnSSMAMMARMRK";
        const string HAPPY = "chillthisisnottherealkeyofhappinesslol";

        static string[] ms_Roles = new string[] {
            GetRealString(@"~yql}^Oj"),
            GetRealString(@"F^g|}@Jsy[IFHLOl}CrCGHL"),
            GetRealString(@"F^g|}@Jsy[IFHLOl}CrCGHB\L~yql}^Oj"),
            GetRealString(@"FLHFXqsf")
        };
        static string[] ms_Subjects = new string[] {
            GetRealString(@"\L|mJj"),
            GetRealString(@"\LzFG]IlENz"),
            GetRealString(@"\LzCGI|GQOca"),
            GetRealString(@"y}RI|m^"),
            GetRealString(@"zE}QJ|GHf"),
            GetRealString(@"yEaGIFeD"),
            GetRealString(@"~AJ|XIO"),
            GetRealString(@"~cerC]IlENz"),
            GetRealString(@"xc}_r|LzFG]IlENz"),
            GetRealString(@"SzJcGQJ|eQ"),
            GetRealString(@"Clbn}j"),
            GetRealString(@"y|e]IF_J|eQ"),
            GetRealString(@"lGqsaCOc}Rqz"),
            GetRealString(@"z|eAI}^OlG^q\"),
            GetRealString(@"zf"),
            GetRealString(@"y~yrbnCOlL"),
            GetRealString(@"zbLzCGI|GQOca"),
            GetRealString(@"z}fLzCGI|GQOca"),
            GetRealString(@"zbL~lCHGAH\"),
            GetRealString(@"z}fL~lCHGAH\"),
            GetRealString(@"zbLzFG]IlENz"),
            GetRealString(@"z}fLzFG]IlENz"),
            GetRealString(@"zbL|mJj"),
            GetRealString(@"zsaCrFGAbn}@qsCAq|\"),
            GetRealString(@"z}fL|mJj"),
            GetRealString(@"x~e~"),
            GetRealString(@"}ca[r|\LysCCIz"),
            GetRealString(@"y|EIlGQJhiCHRiCbceGr^qhiXr|EO|mEqxj\d@Qbneayz"),
            GetRealString(@"~lCHGAHRj\dHR"),
            GetRealString(@"|mJhimqcCAq|\Lenifz"),
            GetRealString(@"zFG]IlENxj\dH\"),
            GetRealString(@"zCGI|GQOcabojeQn"),
            GetRealString(@"zFG]IlENxi~~FGCIhjS"),
            GetRealString(@"Ol}QOne]OsaQqz")
        };

        DocLoaded m_NextEvent;
        WebBrowser m_Browser;
        BrowserDebugger m_Debugger; //for debug
        List<UserInfo> m_Users;
        Dictionary<string, WebBrowser> m_MBrowsers;
        int m_CompleteUsers;
        bool m_Down;
        Point m_LastLocation;
        Dictionary<string, WebBrowser>[] m_Workers;
        int m_CurrentWorker;
        Config m_Config;
        int m_SZPerWorker;
        WebBrowser[] m_RealBrowsers;

        public Main() {
            InitializeComponent();

            bt.Click += OnClick;
            //m_Debugger = new BrowserDebugger();
            //m_Debugger.Show();
            m_Browser = new WebBrowser(); //m_Debugger.browser1;
            m_Browser.ScriptErrorsSuppressed = true;
            m_Browser.DocumentCompleted += OnDocLoaded;

            new Control[] {
                pT, lT
            }.All(x => {
                x.MouseDown += OnMouseDown;
                x.MouseMove += OnMouseMove;
                x.MouseUp += OnMouseUp;

                return true;
            });

            bool miss;
            m_Config = new Config(out miss);

            if (miss)
                MessageBox.Show("Config file just got created.\nEdit it then come back");
        }

        void OnMouseDown(object o, MouseEventArgs e) {
            m_Down = true;
            m_LastLocation = e.Location;
        }

        void OnMouseMove(object o, MouseEventArgs e) {
            if (m_Down) {
                Location = new Point((Location.X - m_LastLocation.X) + e.X, (Location.Y - m_LastLocation.Y) + e.Y);
                Update();
            }
        }

        void OnMouseUp(object o, MouseEventArgs e) {
            m_Down = false;
        }

        HtmlElement GetElementWithAttr(string attr, string val, WebBrowser browser = null) {
            if (browser == null)
                browser = m_Browser;

            foreach (HtmlElement element in browser.Document.All)
                if (element.GetAttribute(attr) == val)
                    return element;

            return null;
        }

        HtmlElement GetElementWithClass(string clazz, WebBrowser browser = null) {
            if (browser == null)
                browser = m_Browser;

            return GetElementWithAttr("className", clazz, browser);
        }

        HtmlElement GetElementWithId(string id, WebBrowser browser = null) {
            if (browser == null)
                browser = m_Browser;

            return GetElementWithAttr("id", id, browser);
        }

        void SetElementValue(HtmlElement buf, string value) {
            if (buf != null)
                buf.SetAttribute("value", value);
        }

        void OnDocLoaded(object o, WebBrowserDocumentCompletedEventArgs e) {
            m_NextEvent?.Invoke(o, e);
        }

        string LocalToProxyHref(string href) {
            int idxX = href.IndexOf(GetRealString(@"J|z")) + 3;
            int edxX = href.LastIndexOf(GetRealString(@"aFm_HoX"));
            return GetRealString(@"JcyHcfgRCIcf^J|H^r|eCql}_NxH}RgiRIq[Il~^HlC\{G@{z") 
                + href.Substring(idxX, edxX - idxX);
        }

        void OnMDocLoaded(object o, WebBrowserDocumentCompletedEventArgs e) {
            //no need for lock
            //SAFE
            WebBrowser caller = o as WebBrowser;
            string callingHref = e.Url.OriginalString; //"";

            /*foreach (KeyValuePair<string, WebBrowser> pair in m_MBrowsers) {
                if (pair.Value == caller) {
                    callingHref = pair.Key;
                    break;
                }
            }*/

            //should be 1 ONLY
            UserInfo user = (from u in m_Users
                             where LocalToProxyHref(u.Href) == callingHref
                             select u).Single();

            HtmlElement element = GetElementWithClass(GetRealString(@"OseGHEiRIq[Il~"), caller);
            string ih = element.InnerHtml;

            int x = ih.IndexOf(GetRealString(@"rxiDHF}F{xa_r|GXOl")) + 15;
            int y = ih.Substring(x).IndexOf(GetRealString(@"bA")) + 2 + x;
            int z = ih.Substring(y).IndexOf(GetRealString(@"{hC{L")) + y;

            user.Email = ih.Substring(y, z - y);

            //compare subjects against it rather than string calculations, saves time...
            string it = element.InnerText;
            user.Subjects = new List<string>();

            foreach (string subj in ms_Subjects) {
                if (it.Contains(subj)) {
                    user.Subjects.Add(subj);
                }
            }

            //clean
            m_MBrowsers[callingHref] = null;

            m_CompleteUsers++;
            if (m_CompleteUsers % m_SZPerWorker == 0) {
                //this means that our X worker has finished
                m_CurrentWorker++;
                StartWorker(m_CurrentWorker);
            }

            SetStatus($"Virtualizing {m_CurrentWorker}:{m_CompleteUsers} - {(int)((float)m_CompleteUsers / m_Users.Count * 100f)}%");

            if (m_CompleteUsers == m_Users.Count) {
                //complete!
                SetStatus("Writing");

                using (FileStream stream = new FileStream(m_Config.OutputPath, FileMode.Create))
                using (StreamWriter writer = new StreamWriter(stream)) {
                    foreach (UserInfo uinfo in m_Users) {
                        writer.WriteLine($"--------------------------------------------------------");
                        writer.WriteLine($"Name: {uinfo.Name}");
                        writer.WriteLine($"Email: {uinfo.Email}");
                        writer.WriteLine($"Subjects:");
                        foreach (string subject in uinfo.Subjects) {
                            writer.WriteLine($"\t{subject}");
                        }

                        writer.WriteLine($"--------------------------------------------------------");
                    }

                    writer.Close();
                }

                SetStatus("done");
            }
        }

        void SetStatus(string txt) {
            lst.Text = txt;
        }

        void StartWorker(int index) {
            //clean old worker if present
            if (index > 0) {
                m_Workers[index - 1].Clear();
                GC.Collect();
            }

            if (index >= m_Workers.Length)
                return;

            foreach (KeyValuePair<string, WebBrowser> pair in m_Workers[index]) {
                pair.Value.Navigate(pair.Key);
            }
        }

        static string GetRealString(string str) {
            string newStr = "";

            for (int i = 0; i < str.Length; i++) {
                char old = str[i];
                for (int j = HAPPY.Length - 1; j > -1; j--) {
                    old = (char)(old ^ HAPPY[j]);
                }

                newStr += old;
            }

            string _newStr = "";

            for (int i = 0; i < newStr.Length; i++) {
                char old = newStr[i];
                for (int j = FLEX.Length - 1; j > -1; j--) {
                    old = (char)(old ^ FLEX[j]);
                }

                _newStr += old;
            }

            byte[] utf = Convert.FromBase64String(_newStr);
            string realStr = Encoding.UTF8.GetString(utf);

            return realStr;
        }

        void OnClick(object sender, EventArgs e) {
            SetStatus("Initiating");
            m_Browser.Navigate(GetRealString(@"JcyHcfgRCIcf^J|H^r|eCql}_NxXIO[IB[IFyGNh\Jcj"));
            HtmlElement element = null;

            m_NextEvent = (x, x1) => {
                element = GetElementWithId(GetRealString(@"OseGHFCI|~"));
                SetElementValue(element, m_Config.Username);

                element = GetElementWithId(GetRealString(@"HlmQHO]HFz"));
                SetElementValue(element, m_Config.Password);

                element = GetElementWithId(GetRealString(@"IlEJ|BOl"));
                element.InvokeMember(GetRealString(@"rS[rX"));

                m_NextEvent = (x2, x3) => {
                    if (x3.Url.OriginalString != GetRealString(@"JcyHcfgRCIcf^J|H^r|eCql}_Nx_Nx"))
                        return;

                    m_Browser.Navigate(string.Format(GetRealString(
                        @"JcyHcfgRCIcf^J|H^r|eCql}_NxH}RgG^ql}gEiDHoAIqsCJ|zfzaFG@{naEiGHEiCq~NQiaEy[qFGRHz"),
                        m_Config.Threshold));

                    m_NextEvent = (x4, x5) => {
                        int index = 0;
                        m_Users = new List<UserInfo>();

                        while (true) {
                            element = GetElementWithId(GetRealString(@"OseGHB[IFyGNh\rsaJ|e[Hlm^Ocf_fqMHL") + index);

                            if (element == null)
                                break;

                            string clz;
                            if ((clz = element.GetAttribute("className")) != null && clz == GetRealString(@"q|\OcGRIH"))
                                break;

                            string ih = element.InnerHtml;
                            string it = element.InnerText;

                            int y = ih.IndexOf(GetRealString(@"JcaGqAB")) + 6;
                            int z = ih.IndexOf(GetRealString(@"aFm_Ho_AI}RH~frB{L")) + 14;

                            string href = ih.Substring(y, z - y);
                            int nIdx;
                            int locIdx = 0;
                            do
                                nIdx = it.IndexOf(ms_Roles[locIdx++]);
                            while (nIdx == -1 && locIdx < ms_Roles.Length);

                            string name = it.Substring(0, nIdx);

                            m_Users.Add(new UserInfo {
                                Href = href,
                                Name = name
                            });

                            index++;

                            SetStatus($"Fetching memeber {index}");
                        }

                        SetStatus($"Virtualizing {index} members");
                        m_CompleteUsers = 0;

                        //i dont want to put a lock in MDocLoaded so I should instantiate all browsers first then nav to hrefs
                        //as MDocLoaded might be fired from a seperate thread while I am still instantiating browsers...
                        //we MUST divide the tasks
                        //due to memory size used by WebBrowser

                        m_MBrowsers = new Dictionary<string, WebBrowser>();
                        double maxRam = m_Config.MaximumHypotheticalRam;
                        if (maxRam <= HYPOTHETICAL_MEMORY)
                            maxRam = MAX_MEMORY;

                        int workers = (int)Math.Ceiling(m_Users.Count * HYPOTHETICAL_MEMORY / maxRam);
                        m_Workers = new Dictionary<string, WebBrowser>[workers];
                        m_SZPerWorker = (int)Math.Floor(m_Users.Count / (double)workers);

                        m_RealBrowsers = new WebBrowser[m_SZPerWorker];

                        int idx = 0;
                        foreach (UserInfo info in m_Users) {
                            if (m_RealBrowsers[idx] == null) {
                                WebBrowser browser = new WebBrowser {
                                    ScriptErrorsSuppressed = true
                                };

                                browser.DocumentCompleted += OnMDocLoaded;
                                m_RealBrowsers[idx] = browser;
                            }

                            m_MBrowsers[info.Href] = m_RealBrowsers[idx];
                            idx++;

                            if (idx >= m_RealBrowsers.Length)
                                idx = 0;
                        }         
                        
                        string[] keyBuf = m_MBrowsers.Keys.ToArray();
                        WebBrowser[] wbBuf = m_MBrowsers.Values.ToArray();

                        for (int i = 0; i < workers; i++) {
                            m_Workers[i] = new Dictionary<string, WebBrowser>();

                            for (int j = 0; j < m_SZPerWorker; j++) {
                                int realVIndex = i * m_SZPerWorker + j;
                                if (realVIndex >= keyBuf.Length)
                                    break;

                                m_Workers[i].Add(keyBuf[realVIndex], wbBuf[realVIndex]);
                            }
                        }

                        //start first worker
                        if (workers > 0) {
                            m_CurrentWorker = 0;

                            StartWorker(0);
                        }
                    };
                };
            };
        }
    }
}
