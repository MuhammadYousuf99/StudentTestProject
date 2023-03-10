using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Web;

namespace BasicApp.Scheduler
{
    public class LogScheduler
    {
        private readonly List<string> _logs = new List<string>();
      

        string _logFilePath = AppDomain.CurrentDomain.BaseDirectory+"\\log.txt";

      
        public void Start()
        {
            var timer = new Timer(60 * 1000); // 60 seconds
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }

        public IEnumerable<string> GetLogs()
        {
            return _logs;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var log = $"{timestamp}: Scheduler run";
            _logs.Add(log);
            using (StreamWriter writer = File.AppendText(_logFilePath))
            {
                writer.WriteLine(log);
            }
        }

    }
}