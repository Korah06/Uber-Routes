using App.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand AdministrativeViewCommand { get; set; }
        public RelayCommand RoutesViewCommand { get; set; }
        public RelayCommand RouteMapViewCommand { get; set; }
        public RelayCommand UserViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public AdministrativeViewModel AdministrativeVM { get; set; }
        public UserViewModel UserVM { get; set; }
        public RoutesViewModel RoutesVM { get; set; }
        public RouteMapViewModel RouteMapVM { get; set; }

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

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            RoutesVM = new RoutesViewModel();
            RouteMapVM = new RouteMapViewModel();
            UserVM = new UserViewModel();
            AdministrativeVM = new AdministrativeViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            RoutesViewCommand = new RelayCommand(o =>
            {
                CurrentView = RoutesVM;
            });

            RouteMapViewCommand = new RelayCommand(o =>
            {
                CurrentView = RouteMapVM;
            });
            
            UserViewCommand = new RelayCommand(o =>
            {
                CurrentView = UserVM;
            });
            AdministrativeViewCommand = new RelayCommand(o =>
            {
                CurrentView = AdministrativeVM;
            });
        }
    }
}
