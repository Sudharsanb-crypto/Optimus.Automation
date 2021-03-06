﻿using Ecom.Optimus.Framework.Basic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Ecom.Optimus.Framework.Config;
using System.Threading.Tasks;

namespace Ecom.Optimus.Framework.Common
{
    public class Report
    {
        public static string filelocation;

        /// <summary>
        /// To configure test report directory
        /// </summary>
        /// <returns></returns>
        public static string ConfigureReport()
        {
            string location = null;
            string foldername = "TestReport";
            string rootfolderlocation = Configuration.GetInfo().TestReportFilePath + foldername;
            string datefolderlocation = rootfolderlocation + @"\" + DateTime.Now.ToString("dd-MM-yyyy");
            string currenttime = DateTime.Now.ToLocalTime().ToString();
            currenttime = currenttime.Replace(":", "-");
            string newfolderlocation = datefolderlocation + @"\" + currenttime;

            if (!Directory.Exists(rootfolderlocation))
            {
                Printer.ConsoleWriter("Log folder  created");
                Directory.CreateDirectory(rootfolderlocation);

                Directory.CreateDirectory(datefolderlocation);

                Directory.CreateDirectory(newfolderlocation);
                location = newfolderlocation + @"\HtmlReport.html";

            }

            else
            {
                Printer.ConsoleWriter("Test Report folder  exists");
                if (Directory.Exists(datefolderlocation))
                {
                    Printer.ConsoleWriter("Date folder exists");


                }
                else if (!Directory.Exists(datefolderlocation))
                {
                    Printer.ConsoleWriter("Date folder doesn't exists");
                    Directory.CreateDirectory(datefolderlocation);

                }

                Directory.CreateDirectory(newfolderlocation);
                location = newfolderlocation + @"\HtmlReport.html";
            }

            return location;


        }
    }
}
