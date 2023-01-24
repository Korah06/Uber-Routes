using App.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MVVM.ViewModel
{
    internal class AdministrativeViewModel : ObservableObject
    {

        public RelayCommand AdmRouteViewCommand { get; set; }
        public RelayCommand AdmUserViewCommand { get; set; }


        public AdmUserViewModel AdmUserVM { get; set; }
        public AdmRouteViewModel AdmRouteVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public AdministrativeViewModel()
        {
            AdmUserVM = new AdmUserViewModel();
            AdmRouteVM = new AdmRouteViewModel();
            CurrentView = AdmUserVM;

            AdmUserViewCommand = new RelayCommand(o =>
            {
                CurrentView = AdmUserVM;
            });

            AdmRouteViewCommand = new RelayCommand(o =>
            {
                CurrentView = AdmRouteVM;
            });
        }
    }
}
