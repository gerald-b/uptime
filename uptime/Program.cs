﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

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
            TimeSpan ts = GetUpTime();
            String output = String.Empty;
            output += "At ";
            output += DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            output += " up ";
            output += ts.Days;
            output += " days, ";
            output += ts.ToString("hh\\:mm");
            Console.WriteLine(output);
        }
    }
}