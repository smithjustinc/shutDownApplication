using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Shut_Down_App
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Title = "Shut Down Program";
            this.AppWindow.MoveAndResize(new Windows.Graphics.RectInt32(100, 100, 340, 175));
        }

        private void submitButtonClick(object sender, RoutedEventArgs e)
        {
            //get seconds
            int seconds = convertToSeconds(int.Parse(hoursTextBox.Text), int.Parse(minutesTextBox.Text));

            accessOS(seconds);
            submitButton.Content = "Shut Down Confirmed";

        }

        //Button Supporting Functions
        public int convertToSeconds(int hours, int minutes)
        {
            return ((hours * 3600) + (minutes * 60));
        }
        public void accessOS(int seconds)
        {
            string command = $"/c shutdown /s /t {seconds}";
            //Opens command prompt and runs shutdown command
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = command;
            process.StartInfo.CreateNoWindow = false; // Show the command prompt window
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }
    }
}
