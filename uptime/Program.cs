using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace uptime
{
    class Program
    {
        [DllImport("kernel32")]
        extern static UInt64 GetTickCount64();

        public static TimeSpan GetUpTime()
        {
            return TimeSpan.FromMilliseconds(GetTickCount64());
        }

        static void Main(string[] args)
        {
            Boolean startGui = false;
            Boolean showStartTimeStamp = false;
 
            foreach(String arg in args)
            {
                if (arg.ToUpper().Equals("--VERSION") || 
                    arg.ToUpper().Equals("-V")
                    )
                {
                    ClsAbout about = new ClsAbout();

                    Console.WriteLine(about.getProductName() +  " - v" + about.getVersion());
                    Console.WriteLine("Author(s): " + about.getCompany());
                    Console.WriteLine("License: " + about.getCopyright());
                    Console.WriteLine("");

                    return;
                }
                if (arg.ToUpper().Equals("--VERSIONGUI") ||
                    arg.ToUpper().Equals("-VG")
                    )
                {
                    ClsAbout about = new ClsAbout();

                    String msg = String.Empty;
                    msg += about.getProductName() + " - v" + about.getVersion();
                    msg += Environment.NewLine;
                    msg += "Author(s): " + about.getCompany();
                    msg += Environment.NewLine;
                    msg += "License: " + about.getCopyright();
                    MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                if (arg.ToUpper().Equals("--HELP") ||
                    arg.ToUpper().Equals("-H"))
                {
                    String msg = getHelpTxt();
                    Console.WriteLine(msg);
                    return;
                }

                if (arg.ToUpper().Equals("--HELPGUI") ||
                    arg.ToUpper().Equals("-HG"))
                {
                    String msg = getHelpTxt();
                    MessageBox.Show(msg, "HELP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (arg.ToUpper().Equals("--GUI"))
                {
                    startGui = true;
                }
                if (arg.ToUpper().Equals("--SHOW-STARTUP-TIMESTAMP"))
                {
                    showStartTimeStamp = true;
                }
            }

            TimeSpan ts = GetUpTime();
            DateTime startupDate = DateTime.Now.Subtract(ts);

            String output = String.Empty;
            output += "At ";
            output += DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            output += " up ";
            output += ts.Days;
            output += " days, ";
            output += ts.ToString("hh\\:mm");
            if (showStartTimeStamp)
            {
                output += Environment.NewLine;
                output += "Start Timestamp: ";
                output += startupDate.ToString("dd.MM.yyyy HH:mm:ss");
            }
            if (startGui)
            {
                MessageBox.Show(output, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Console.WriteLine(output);
            }
        }

        private static string getHelpTxt()
        {
            String txt = String.Empty;
            txt += Environment.NewLine + "uptime [--gui][--show-startup-timestamp][-h/--help] ";
            txt += Environment.NewLine;
            txt += Environment.NewLine + "-h\t\tShows this help-page";
            txt += Environment.NewLine + "--help";
            txt += Environment.NewLine; 
            txt += Environment.NewLine + "-hg\t\tShows this help-page";
            txt += Environment.NewLine + "--helpgui\ton an messagebox-window";
            txt += Environment.NewLine;
            txt += Environment.NewLine + "--gui\t\tShows the uptime in an messagebox-";
            txt += Environment.NewLine + "\t\twindow instead on CLI";
            txt += Environment.NewLine;
            txt += Environment.NewLine + "--show-startup-timestamp";
            txt += Environment.NewLine + "\t\tShows the timestamp from Startup.";
            txt += Environment.NewLine + "\t\tCan be used on CLI or with --gui";
            txt += Environment.NewLine;
            txt += Environment.NewLine + "-v\t\tShows the version, author and ";
            txt += Environment.NewLine + "--version\t\tthe license information";
            txt += Environment.NewLine;
            txt += Environment.NewLine + "-vg\t\tLike -v but put the information";
            txt += Environment.NewLine + "--versiongui\ton an messagebox-window";
            txt += Environment.NewLine + "\t\tinstead on CLI";
            txt += Environment.NewLine; 
            return txt;
        }
    }
}
