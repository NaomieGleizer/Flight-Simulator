using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulator.ViewModels;
using FlightSimulator.Model;
using System.ComponentModel;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for AutoPilot.xaml
    /// </summary>
    public partial class AutoPilot : UserControl
    {
        private AutoPilotViewModel vm;
    
        public AutoPilot()
        {
            InitializeComponent();
        }
        public CommandsModel Model {
            set {
                vm = new AutoPilotViewModel(value);
                DataContext = vm;


                vm.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e) { Dispatcher.InvokeAsync(() => { userText.Background = Brushes.White; }); };

                }
        }

        


        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            userText.Background = Brushes.Pink;
            List<string> commands;
            string str = userText.Text;
            //commands = str.Split().ToList();
            commands=str.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
            vm.SendCommands(commands);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            userText.Text = String.Empty;
        }
    }
}
