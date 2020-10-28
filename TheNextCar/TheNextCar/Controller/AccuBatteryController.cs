using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class AccuBatteryController
    {
        private Accubattery accubattery;
        private OnPowerChanged callBackOnPowerChanged;

        public AccuBatteryController(OnPowerChanged callBackOnPowerChanged)
        {
            this.accubattery = new Accubattery(12);
            this.callBackOnPowerChanged = callBackOnPowerChanged;
        }

        public bool accubatteryIsOn()
        {
            return this.accubattery.isOn();
        }

        public void turnOn()
        {
            this.accubattery.turnOn();
            this.callBackOnPowerChanged.onPowerChangedStatus("ON", "power is on");
        }

        public void turnOff()
        {
            this.accubattery.turnOff();
            this.callBackOnPowerChanged.onPowerChangedStatus("OFF", "power is off");
        }
    }
    interface OnPowerChanged
    {
        void onPowerChangedStatus(string value, string message); 
    }
}
