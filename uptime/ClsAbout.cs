using System;
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

        public string getCopyright()
        {
            object[] attribs = myAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true);
            if (attribs.Count() > 0)
            {
                return ((AssemblyCopyrightAttribute)attribs[0]).Copyright;
            }
            return "Not Found";
        }

        public string getCompany()
        {
            object[] attribs = myAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), true);
            if (attribs.Count() > 0)
            {
                return ((AssemblyCompanyAttribute)attribs[0]).Company;
            }
            return "Not Found";
        }

        public string getProductName()
        {
            object[] attribs = myAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), true);
            if (attribs.Count() > 0)
            {
                return ((AssemblyProductAttribute)attribs[0]).Product;
            }
            return "Not Found";
        }
    }
}
