using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class JoystickViewModel : BaseNotify
    {
        private ICommandModel model;
        private ICommand _commandRudder;
        private ICommand _commandThrottle;
        private string throttlePath = "/controls/engines/current-engine/throttle";
        private string rudderPath = "/controls/flight/rudder";
        private string aileronPath = "/controls/flight/aileron";
        private string elevatorPath = "/controls/flight/elevator";
        public JoystickViewModel(ICommandModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        //public double Rudder
        //{
        //    get;
        //    set;
        //}

        //public double Throttle
        //{
        //    set;
        //    get;
        //}

        //public ICommand RudderCommand
        //{
        //    get
        //    {
        //        return _commandRudder ?? (_commandRudder = new CommandHandler(() => UpdateRudder(Rudder.ToString())));

        //    }
        //}

        //public ICommand ThrottleCommand
        //{
        //    get
        //    {
        //        return _commandThrottle ?? (_commandThrottle = new CommandHandler(() => UpdateThrottle(Throttle.ToString())));

        //    }
        //}

        public void UpdateRudder(string command)
        {
          
            List<string> list = new List<string>();
            list.Add("set "+rudderPath+" "+command);
            model.SetValues(list, false);
        }

        public void UpdateThrottle(string command)
        {
           
            List<string> list = new List<string>();
            list.Add("set "+throttlePath+ " "+ command);
            model.SetValues(list, false);
        }

        public void updateAileronAndElevator(string commandAileron, string commandElevator)
        {
            List<string> list = new List<string>();
            list.Add("set " + aileronPath + " " + commandAileron);
            list.Add("set " + elevatorPath + " " + commandElevator);
            model.SetValues(list, false);
        }

        
    }
}
