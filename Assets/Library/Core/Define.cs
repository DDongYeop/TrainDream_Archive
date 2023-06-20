using UnityEngine;

namespace Core
{
    public enum StateType
    {
        Normal = 0,
    }
    
    public enum ResourceType
    {
        Experience = 0, 
    }
    
    public class Define
    {
        private static Camera _mainCam = null;
        public static Camera MainCam
        {
            get
            {
                if(_mainCam == null)
                {
                    _mainCam = Camera.main;
                }

                return _mainCam;
            }
        }
    }
}
