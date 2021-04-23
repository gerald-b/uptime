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
                    arg.ToUpper().Equals("-H")
                {

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
    }
}
