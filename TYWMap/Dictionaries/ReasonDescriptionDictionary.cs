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
                case 1: return "Nie akceptuje Ferdynanda II";
                case 2: return "Wspiera Ferdynanda II";

                case 3: return "Broni Cesarstwa przed najeźdźcą";
                case 4: return "Wspiera protestantów, umacnia swoją pozycję na morzu Bałtyckim";
                case 5: return "Przeprowadza inwazję, wspiera protestantów";
                case 6: return "Osłabia pozycję Habsburgów, wspiera protestantów";

                // Francja, okres szwedzki
                case 7: return "Wspiera najeźdźcę";


                default: return "";
            }
        }
    }
}
