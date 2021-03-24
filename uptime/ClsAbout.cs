﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace uptime
{
    class ClsAbout
    {
        private Assembly myAssembly;

        public ClsAbout()
        {
            myAssembly = Assembly.GetCallingAssembly();
        }

        public String getVersion()
        {
            return myAssembly.GetName().Version.ToString();
        }
    }
}