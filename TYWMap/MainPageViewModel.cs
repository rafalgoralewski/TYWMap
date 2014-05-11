using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TYWMap
{
    public class MainPageViewModel
    {
        private string selectedProvince;

        public string SelectedProvince
        {
            get { return selectedProvince; }
            set { selectedProvince = value; }
        }
    }
}
