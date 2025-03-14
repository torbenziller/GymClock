using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GymClock.Controller
{
    public class CalcTax
    {
        public static double BruttoToNetto(string land, double bamount, bool spezial)
        {
            double tax = 0.0;
            switch (land)
            {
                case "DE":
                    tax = spezial ? 0.07 : 0.19;
                    break;
                case "AT":
                    tax = spezial ? 0.07 : 0.20;
                    break;
            }

            double namount = bamount * (1 + tax);
            return namount;
        }
    }
}
