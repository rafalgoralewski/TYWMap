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
    public class ColorDictionary
    {
        public static Brush GetReasonColor(int number)
        {
            switch (number)
            {
                case 1: return new SolidColorBrush(Colors.Orange);
                case 2: return new SolidColorBrush(Colors.Gray);
                case 3: return new SolidColorBrush(Colors.Green);
                case 4: return new SolidColorBrush(Colors.Red);
                case 5: return new SolidColorBrush(Colors.Blue);
                case 6: return new SolidColorBrush(Colors.Cyan);
                case 7: return new SolidColorBrush(Colors.Cyan);
                default: return new SolidColorBrush(Colors.White);
            }
        }

        public static Brush GetReligionColor(string religion)
        {
            if (religion.Equals("Katolicyzm"))
            {
                return new SolidColorBrush(Colors.Green);
            }
            if (religion.Equals("Luteranizm"))
            {
                return new SolidColorBrush(Colors.Orange);
            }
            if (religion.Equals("Kalwinizm"))
            {
                return new SolidColorBrush(Colors.Red);
            }
            if (religion.Equals("Husytyzm"))
            {
                return new SolidColorBrush(Colors.Yellow);
            }
            if (religion.Equals("Zwilingianizm"))
            {
                return new SolidColorBrush(Colors.Brown);
            }
            if (religion.Equals("Anglikanizm"))
            {
                return new SolidColorBrush(Colors.Purple);
            }

            return new SolidColorBrush(Colors.White);
        }

        public static Brush GetHabsburgColor (bool isHabsburg)
        {
            return isHabsburg ? 
                new SolidColorBrush(Colors.Green) :
                new SolidColorBrush(Colors.White);
        }

        public static Brush GetHREColor(bool isHRE)
        {
            return isHRE ?
                new SolidColorBrush(Colors.Purple) :
                new SolidColorBrush(Colors.White);
        }
    }
}
