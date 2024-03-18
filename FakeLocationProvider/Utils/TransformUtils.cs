using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeLocationProvider.Utils
{
    internal class TransformUtils
    {
        public static (double deltaLat, double deltaLng) GetDelta(int direction, double step)
        {
            double deltaLat = 0, deltaLng = 0;
            switch (direction)
            {
                case 0:
                    deltaLat = 0;
                    deltaLng = step;
                    break;
                case 1:
                    deltaLat = step;
                    deltaLng = 0;
                    break;
                case 2:
                    deltaLat = 0;
                    deltaLng = -step;
                    break;
                case 3:
                    deltaLat = -step;
                    deltaLng = 0;
                    break;
                default:
                    break;
            }

            return (deltaLat, deltaLng);
        }
    }
}
