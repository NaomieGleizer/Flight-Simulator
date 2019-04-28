using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private InfoModel model;
        public FlightBoardViewModel(InfoModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                ChangeLatLon();
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public double Lon
        {
            set;
            get;
        }

        public double Lat
        {
            set;
            get;
        }

        public void ChangeLatLon()
        {
            Lon = model.Longitude;
            Lat = model.Latitude;
        }
    }

}
