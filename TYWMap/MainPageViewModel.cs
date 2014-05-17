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
        private string currentYear;
        private string countryName;
        private bool isHolyRomanEmpire;
        private bool isHabsburg;
        private string rulerName;
        private string religion;

        public string SelectedProvince
        {
            get { return selectedProvince; }
            set { selectedProvince = value; }
        }

        public string CurrentYear
        {
            get { return currentYear; }
            set { currentYear = value; }
        }

        public string CountryName
        {
            get { return countryName; }
            set { countryName = value; }
        }

        public bool IsHolyRomanEmpire
        {
            get { return isHolyRomanEmpire; }
            set { isHolyRomanEmpire = value; }
        }

        public bool IsHabsburg
        {
            get { return isHabsburg; }
            set { isHabsburg = value; }
        }

        public string RulerName
        {
            get { return rulerName; }
            set { rulerName = value; }
        }

        public string Religion
        {
            get { return religion; }
            set { religion = value; }
        }

        
    }
}
