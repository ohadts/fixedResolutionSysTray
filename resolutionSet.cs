using System;
namespace fixedResolutionSysTray
{
    public class resolutionSet
    {
        public int width {get;set;}
        public int height { get; set; }
        public int refreshRate { get; set; }
        public int deviceId { get; set; }
        public String deviceName { get; set; }
        public String deviceRealName { get; set; }
        public Boolean primary { get; set; }
        public Boolean active { get; set; }
        public String devicePrettyName { get; set; }


        public resolutionSet(int deviceId, String deviceName, String deviceRealName ,Boolean primary)
        {
            this.deviceId = deviceId;
            this.deviceName = deviceName;
            this.primary = primary;
            this.deviceRealName = deviceRealName;
            this.devicePrettyName = primary ? deviceRealName + ": " + deviceName + " - Primary" : deviceRealName + ": " + deviceName;
        }

        internal void setConfig(int width, int height, int refreshRate, Boolean active)
        {
            this.width = width;
            this.height = height;
            this.refreshRate = refreshRate;
            this.active = active;
        }
    }
}
