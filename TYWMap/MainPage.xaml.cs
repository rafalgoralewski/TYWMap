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
        }

        private void Province_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Path)
            {
                string name = (sender as Path).Name;
                ClearProvincesSelection();
                provincesPaths.Single(x => x.Name == name).StrokeThickness = 3;
                provincesPaths.Single(x => x.Name == name).Stroke = new SolidColorBrush(Colors.Black);
                vm.SelectedProvince = name;
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
    }
}
