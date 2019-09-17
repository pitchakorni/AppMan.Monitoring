using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppMan.Monitoring.Models;
using System.IO;

namespace AppMan.Monitoring.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DriveInfo Drive = new DriveInfo("c");

            PerformanceCounter cpuCounter;
            PerformanceCounter ramCounter;

            cpuCounter = new PerformanceCounter();

            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            @ViewData["RAMcurrent"] = ramCounter.NextValue() + "MB";
            @ViewData["CPUcurrent"] = cpuCounter.NextValue() + "%";

            //ViewData["DriveCInfo"] = string.Format("{0} Total : {1}  Used : {2}  Free : {3}", Drive.Name, ConvertLongToStringZero(Drive.TotalSize), ConvertLongToStringZero(Drive.TotalSize - Drive.TotalFreeSpace), ConvertLongToStringZero(Drive.TotalFreeSpace));
            @ViewData["DriveC"] = new Drive()
            {
                Name = Drive.Name,
                TotalSize = Drive.TotalSize,
                TotalUsedSpace = Drive.TotalSize-Drive.TotalFreeSpace,
                TotalFreeSpace = Drive.TotalFreeSpace
            };

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult HealthCheck()
        {
            return View();
        }

        public string ConvertLongToStringZero(long num)
        {
            return num.ToString("N0") + " Bytes";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
