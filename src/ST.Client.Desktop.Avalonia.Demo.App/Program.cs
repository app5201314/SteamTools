﻿namespace System.Application.UI
{
    static partial class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            IsMainProcess = true;
            Startup.Init(CommandLineTools.DILevel.Main);
            BuildAvaloniaAppAndStartWithClassicDesktopLifetime(args);
        }
    }
}