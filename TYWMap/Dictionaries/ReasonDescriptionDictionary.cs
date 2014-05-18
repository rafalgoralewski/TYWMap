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

namespace TYWMap.Dictionaries
{
    public class ReasonDescriptionDictionary
    {
        public static string GetReason(int number)
        {
            switch (number)
            {
                case 1: return "Walczy przeciwko dominacji chrześcijan";
                default: return "";
            }
        }
    }
}
