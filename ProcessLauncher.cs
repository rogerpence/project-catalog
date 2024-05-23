﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

public class ProcessLauncher
{
    StringBuilder stdoutBuffer = new StringBuilder();

    public List<String> StatusMessage = new List<string>();

    public int ExitCode = 0;

    static public string GetLibrettoXCommandLineArgs(string templateFile, string schemaFile, string outputPath)
    {
        return $"librettox.py -t \"{templateFile}\" -s \"{schemaFile}\" -o \"{outputPath}\"";
    }

    public void LaunchProcess(string command, string arguments, bool wait = true)
    {
        Process process = new Process();
        ProcessStartInfo startInfo = new ProcessStartInfo();

        stdoutBuffer.Clear();

        Stopwatch sw = new Stopwatch();

        sw.Start();

        //Console.WriteLine("Running commands {0} {1}...", command, arguments);

        startInfo.FileName = command;
        startInfo.Arguments = arguments;

        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        if (command.ToLower().Contains(".exe"))
        {
            startInfo.WorkingDirectory = Path.GetDirectoryName(command);
        }

        process.EnableRaisingEvents = true;

        process.OutputDataReceived += (sender, args) => {
            if (! String.IsNullOrEmpty(args.Data))
            {
                string timeNow = DateTime.Now.ToString("HH:mm:ss : ");

                this.StatusMessage.Add(timeNow + args.Data);
            }
        };

        process.StartInfo = startInfo;

        string errorText;
        try
        {
            process.Start();
            process.BeginOutputReadLine();
            //errorText = process.StandardError.ReadToEnd();

            if (wait)
            {
                process.WaitForExit();
            }
            process.CancelOutputRead();

            this.ExitCode = process.ExitCode;
            if (ExitCode != 0) {
                errorText = process.StandardError.ReadToEnd();
                errorText = "AN ERROR OCCURRED--it's likely the best error info is at the bottom of this list.\n" + errorText;
                string[] lines = errorText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines) 
                {
                    this.StatusMessage.Add(line);
                }
            }
             
            sw.Stop();
        }
        catch (Exception ex)
        {
            this.StatusMessage.Add(ex.Message);
        }
        finally
        {
            process.Close();
            process.Dispose();
        }

        string minutes = sw.ElapsedMilliseconds < 60000 ? " < 1 min" : (sw.ElapsedMilliseconds / 60000).ToString("#,### mins");

        return;
    }
}

