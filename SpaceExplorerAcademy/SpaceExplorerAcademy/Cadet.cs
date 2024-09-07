using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorerAcademy
{
    //This class represents a cadet in the Space Explorer academy
    //It implements INotifyPropertyChanged to support the WPF binding
     class Cadet : INotifyPropertyChanged
    {
        private string name; //property for the cadet's name

        public string Name
        {
            get => name;
            set
            {
                name = value;

                //Notify the UI that the property has changed
                OnPropertyChanged();
                //Also notify that the DisplayName has changed, since it depends on Name
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        //collection of missions assigned to this cadet
        //using ObservableCollection so that the UI updates automatically when missions are added
        private ObservableCollection<SpaceMission> missions = new ObservableCollection<SpaceMission>();
        public ObservableCollection<SpaceMission> Missions
        { 
            get => missions;
            set 
            {
                missions = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayName));
            } 
        
        }
        //property that combines the cadet's name & missioin count for the display in the UI
        public string DisplayName => $"{Name} - Missions: {Missions.Count}";

        //event that the UI listens to for updates
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /*[CallerMemberName] 
         * This is an attribute that automatically obtains the name of the method / property
         * that calls this method. Meaning when OnPropertyChanged is called without arguments the
         * propertyName parameter automatically gets the name of the property that changed

         * string propertyName = null
         * Name of the property that is changed. Default value of null is 
         * usually overridden by the CallerMemberName
         */
    }
}

