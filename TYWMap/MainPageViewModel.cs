using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using TYWMap.Dictionaries;

namespace TYWMap
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region prop
        private const string FILENAME = "HistoryData";
        public const string MAPMODE_REASON = "Strony konfliktu";
        public const string MAPMODE_RELIGION = "Wyznanie";
        public const string MAPMODE_HABSBURG = "Wpływy Habsburgów";
        public const string MAPMODE_HRE = "Terytorium Cesarstwa";

        XDocument historyData;
        private string selectedProvince;
        private string currentYear;
        private string countryName;
        private bool isHRE;
        private bool isHabsburg;
        private string rulerName;
        private string religion;
        private double currentYearSliderValue;
        private string description;
        private string reason;
        private List<string> mapModes;

        public string CurrentMapMode { get; set; }

        public string SelectedProvince
        {
            get { return selectedProvince; }
            set 
            {
                selectedProvince = value;
                SelectProvince();
                NotifyOnPropertyChanged("SelectedProvince");
            }
        }

        public string CurrentYear
        {
            get { return currentYear; }
            set 
            {
                currentYear = value;
                NotifyOnPropertyChanged("CurrentYear");
            }
        }

        public string CountryName
        {
            get { return countryName; }
            set 
            {
                countryName = value;
                NotifyOnPropertyChanged("CountryName");
            }
        }

        public bool IsHRE
        {
            get { return isHRE; }
            set 
            {
                isHRE = value;
                NotifyOnPropertyChanged("IsHRE");
            }
        }

        public bool IsHabsburg
        {
            get { return isHabsburg; }
            set 
            {
                isHabsburg = value;
                NotifyOnPropertyChanged("IsHabsburg");
            }
        }

        public string RulerName
        {
            get { return rulerName; }
            set 
            {
                rulerName = value;
                NotifyOnPropertyChanged("RulerName");
            }
        }

        public string Religion
        {
            get { return religion; }
            set 
            {
                religion = value;
                NotifyOnPropertyChanged("Religion");
            }
        }

        public double CurrentYearSliderValue
        {
            get { return currentYearSliderValue; }
            set 
            { 
                currentYearSliderValue = value;
                SelectProvince();
                NotifyOnPropertyChanged("CurrentYearSliderValue");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyOnPropertyChanged("Description");
            }
        }

        public string Reason
        {
            get { return reason; }
            set
            {
                reason = value;
                NotifyOnPropertyChanged("Reason");
            }
        }

        public List<string> MapModes
        {
            get { return mapModes; }
            set
            {
                mapModes = value;
                NotifyOnPropertyChanged("MapModes");
            }
        }      

        #endregion

        public MainPageViewModel()
        {
            historyData = XDocument.Load("HistoryData.xml");
            SelectProvince();
        }

        public void SelectProvince()
        {
            try
            {
                double slider = Math.Floor(this.currentYearSliderValue);
                var history = historyData.Root.Descendants("Year");
                var year = history.Single(x =>
                    double.Parse(x.Attribute("CurrentSliderValue").Value) == slider);
                var province = year.Descendants("Country").Single(x =>
                    x.Attribute("SelectedProvince").Value.Equals(this.selectedProvince));

                this.CurrentYear = year.Attribute("CurrentYear").Value;
                this.CountryName = province.Descendants("CountryName").Single().Value;
                this.IsHRE = bool.Parse(province.Descendants("IsHRE").Single().Value);
                this.IsHabsburg = bool.Parse(province.Descendants("IsHabsburg").Single().Value);
                this.RulerName = province.Descendants("RulerName").Single().Value;
                this.Religion = province.Descendants("Religion").Single().Value;
                this.Description = province.Descendants("Description").Single().Value;

                int xmlReason;
                int.TryParse(province.Descendants("Reason").Single().Value, out xmlReason);
                this.Reason = ReasonDescriptionDictionary.GetReason(xmlReason);
                
                this.mapModes = new List<string>() 
                {
                    MAPMODE_REASON,
                    MAPMODE_RELIGION,
                    MAPMODE_HABSBURG,
                    MAPMODE_HRE
                };
            }
            catch
            {
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOnPropertyChanged(String PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        #region province colors

        public Brush GetProvinceColorForReason(string provinceName)
        {
            int xmlReason = 0;
            try
            {
                double slider = Math.Floor(this.currentYearSliderValue);
                var history = historyData.Root.Descendants("Year");
                var year = history.Single(x =>
                    double.Parse(x.Attribute("CurrentSliderValue").Value) == slider);
                var province = year.Descendants("Country").Single(x =>
                    x.Attribute("SelectedProvince").Value.Equals(provinceName));
                int.TryParse(province.Descendants("Reason").Single().Value, out xmlReason);
            }
            catch
            {
            }
            return ColorDictionary.GetReasonColor(xmlReason);
        }

        public Brush GetProvinceColorForReligion(string provinceName)
        {
            string xmlReligion = String.Empty;
            try
            {
                double slider = Math.Floor(this.currentYearSliderValue);
                var history = historyData.Root.Descendants("Year");
                var year = history.Single(x =>
                    double.Parse(x.Attribute("CurrentSliderValue").Value) == slider);
                var province = year.Descendants("Country").Single(x =>
                    x.Attribute("SelectedProvince").Value.Equals(provinceName));
                xmlReligion = province.Descendants("Religion").Single().Value;
            }
            catch
            {
            }
            return ColorDictionary.GetReligionColor(xmlReligion);
        }

        public Brush GetProvinceColorForHabsburg(string provinceName)
        {
            bool xmlHabsburg = false;
            try
            {
                double slider = Math.Floor(this.currentYearSliderValue);
                var history = historyData.Root.Descendants("Year");
                var year = history.Single(x =>
                    double.Parse(x.Attribute("CurrentSliderValue").Value) == slider);
                var province = year.Descendants("Country").Single(x =>
                    x.Attribute("SelectedProvince").Value.Equals(provinceName));
                bool.TryParse(province.Descendants("IsHabsburg").Single().Value, out xmlHabsburg);
            }
            catch
            {
            }
            return ColorDictionary.GetHabsburgColor(xmlHabsburg);
        }

        public Brush GetProvinceColorForHRE(string provinceName)
        {
            bool xmlHRE = false;
            try
            {
                double slider = Math.Floor(this.currentYearSliderValue);
                var history = historyData.Root.Descendants("Year");
                var year = history.Single(x =>
                    double.Parse(x.Attribute("CurrentSliderValue").Value) == slider);
                var province = year.Descendants("Country").Single(x =>
                    x.Attribute("SelectedProvince").Value.Equals(provinceName));
                bool.TryParse(province.Descendants("IsHRE").Single().Value, out xmlHRE);
            }
            catch
            {
            }
            return ColorDictionary.GetHREColor(xmlHRE);
        }

        #endregion
    }
}
