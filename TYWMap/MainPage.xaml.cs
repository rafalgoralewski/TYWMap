using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using TYWMap.Dictionaries;

namespace TYWMap
{
    public partial class MainPage : UserControl
    {
        private List<Path> provincesPaths;
        private MainPageViewModel vm;

        public MainPage()
        {
            InitializeComponent();
            vm = new MainPageViewModel();
            this.DataContext = vm;
            provincesPaths = InitializeProvincesList();
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            SelectProvince("PthAustria");
        }

        private void Province_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Path)
            {
                string name = (sender as Path).Name;
                SetProvincesColors();
                SelectProvince(name);
            }
        }

        private void SelectProvince(string name)
        {
            ClearProvincesSelection();
            provincesPaths.Single(x => x.Name == name).StrokeThickness = 3;
            provincesPaths.Single(x => x.Name == name).Stroke = new SolidColorBrush(Colors.Black);
            vm.SelectedProvince = name;
        }

        private void SetProvincesColors()
        {
            if (vm.CurrentMapMode == null)
            {
                return;
            }

            foreach (var province in provincesPaths)
            {
                if (vm.CurrentMapMode.Equals(MainPageViewModel.MAPMODE_REASON))
                {
                    province.Fill = vm.GetProvinceColorForReason(province.Name);
                }
                else if (vm.CurrentMapMode.Equals(MainPageViewModel.MAPMODE_RELIGION))
                {
                    province.Fill = vm.GetProvinceColorForReligion(province.Name);
                }
                else if (vm.CurrentMapMode.Equals(MainPageViewModel.MAPMODE_HRE))
                {
                    province.Fill = vm.GetProvinceColorForHRE(province.Name);
                }
                else if (vm.CurrentMapMode.Equals(MainPageViewModel.MAPMODE_HABSBURG))
                {
                    province.Fill = vm.GetProvinceColorForHabsburg(province.Name);
                }
            }
        }

        #region provincesListManagement

        private List<Path> InitializeProvincesList()
        {
            return new List<Path>() {
            PthAustria, PthSaxony, PthPalatinate, PthBohemia, PthBavaria, PthSwiss, PthSavoy, PthBurgundy, 
            PthLorraine, PthWurttemberg, PthBrandemburg, PthPomerania, PthFranken, PthHessen, PthHolstein, 
            PthMecklenburg, PthHamburg, PthLuxemburg, PthLiege, PthCologne, PthFlanders, PthDutch, PthMunster, 
            PthBrunswick, PthItalies, PthHungary, PthPoland, PthDennmark, PthSweden, PthEngland, PthFrance };
        }

        private void ClearProvincesSelection()
        {
            foreach (Path province in provincesPaths)
            {
                province.StrokeThickness = 0;
            }
        }

        #endregion

        private void SlrCurrentYear_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(sender is Slider)
            {
                vm.CurrentYearSliderValue = (sender as Slider).Value;
                SetProvincesColors();
                SelectProvince(vm.SelectedProvince);
            }
        }

        private void cbxMapMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vm.CurrentMapMode = (sender as ComboBox).SelectedItem.ToString();

            spMapModeHabsburg.Visibility = Visibility.Collapsed;
            spMapModeHRE.Visibility = Visibility.Collapsed;
            spMapModeReason.Visibility = Visibility.Collapsed;
            spMapModeReligion.Visibility = Visibility.Collapsed;

            if (vm.CurrentMapMode.Equals(MainPageViewModel.MAPMODE_REASON))
            {
                spMapModeReason.Visibility = Visibility.Visible;
            }
            else if (vm.CurrentMapMode.Equals(MainPageViewModel.MAPMODE_RELIGION))
            {
                spMapModeReligion.Visibility = Visibility.Visible;
            }
            else if (vm.CurrentMapMode.Equals(MainPageViewModel.MAPMODE_HRE))
            {
                spMapModeHRE.Visibility = Visibility.Visible;
            }
            else if (vm.CurrentMapMode.Equals(MainPageViewModel.MAPMODE_HABSBURG))
            {
                spMapModeHabsburg.Visibility = Visibility.Visible;
            }

            SetProvincesColors();
        }
    }
}
