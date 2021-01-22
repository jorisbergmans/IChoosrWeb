using IChoosrWebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IChoosrWebApp.Models
{
    public class CameraViewModel
    {
        public CameraViewModel()
        {

        }

        public List<CameraModel> ConvertCameraNameToNumbers(List<CameraModel> cameras)
        {
            cameras.ForEach(c => c.Number = Convert.ToInt32(c.Camera.Substring(7, 3)));
            return cameras;
        }
    }
}
