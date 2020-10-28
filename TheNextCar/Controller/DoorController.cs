using System;
using System.Collections.Generic;
using System.Text;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class DoorController
    {
        private doorController door;
        private OnDoorChanged callbackOnDoorChanged;

        public DoorController(OnDoorChanged callbackOnDoorChanged)
        {
            this.callbackOnDoorChanged = callbackOnDoorChanged;
            this.door = new doorController();
        }
        public void close()
        {
            this.door.Isclosed();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("CLOSED","door closed");
        }
        public void open()
        {
            this.door.open();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("OPEN", "door opened");
        }
        public void activatelock()
        {
            this.door.activatelock();
            this.callbackOnDoorChanged.onLockDoorStateChanged("LOCKED", "door locked");
        }
        public void unlock()
        {
            this.door.unlock();
            this.callbackOnDoorChanged.onLockDoorStateChanged("UNLOCKED", "door unlocked");
        }
        public bool Isclose()
        {
            return this.door.Isclosed();
        }
        public bool islocked()
        {
            return this.door.islocked();
        }

        internal void activateLock()
        {
            throw new NotImplementedException();
        }

        internal bool isLocked()
        {
            throw new NotImplementedException();
        }
    }

    interface   OnDoorChanged
    {
        void onLockDoorStateChanged(string value, string message);
        void onDoorOpenStateChanged(string value, string message);
    }
}
