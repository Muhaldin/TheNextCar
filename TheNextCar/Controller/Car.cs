
using System;
using System.Collections.Generic;
using System.Text;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class Car
    {
        AccubatteryController accubaterryController;
        DoorController doorController;
        OnCarEngineStatusChanged callbackCarEngineStatusChanged;
        private MainWindow mainWindow;

        public Car(AccubaterryController accubaterryController, DoorController doorController, OnCarEngineStatusChanged callbackCarEngineStatusChanged)
        {
            this.accubaterryController = accubaterryController;
            this.doorController = doorController;
            this.callbackCarEngineStatusChanged = callbackCarEngineStatusChanged;
        }

        public Car(DoorController doorController, AccubaterryController accubaterryController, MainWindow mainWindow)
        {
            this.doorController = doorController;
            this.accubaterryController = accubaterryController;
            this.mainWindow = mainWindow;
        }

        public void turnOnPower()
        {
            this.accubaterryController.turnOn();
        }
        public void turnOffPower()
        {
            this.accubaterryController.turnOff();
        }
        public bool powerIsReady()
        {
            return this.accubaterryController.accubatteryIsOn();
        }
        public void closeTheDoor()
        {
            this.doorController.close();
        }
        public void openTheDoor()
        {
            this.doorController.open();
        }
        public void lockTheDoor()
        {
            this.doorController.activateLock();
        }
        public void unlockTheDoor()
        {
            this.doorController.unlock();
        }
        private bool doorIsClose()
        {
            return this.doorController.Isclose();
        }
        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }
        public void toggleStartEngineButton()
        {
            if (!doorIsClose())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "door is open");
                return;
            }
            if (!doorIsLocked())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "door is unlocked");
                return;
            }
            if (!powerIsReady())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "no power available");
                return;
            }
            this.callbackCarEngineStatusChanged.carEngineStatusChanged("STARTED", "Engine Started");
        }
        public void toggleTheLockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.lockTheDoor();
            }
            else
            {
                this.unlockTheDoor();
            }
        }
        public void toggleTheDoorButton()
        {
            if (!doorIsClose())
            {
                this.closeTheDoor();
            }
            else
            {
                this.openTheDoor();
            }
        }
        public void toggleThePowerButton()
        {
            if (!powerIsReady())
            {
                this.turnOnPower();
            }
            else
            {
                this.turnOffPower();
            }
        }
    }

    public class AccubaterryController
    {
        public AccubaterryController(MainWindow mainWindow)
        {
        }
    }

    interface OnCarEngineStatusChanged
    {
        void carEngineStatusChanged(string value, string messsage);
    }
}
