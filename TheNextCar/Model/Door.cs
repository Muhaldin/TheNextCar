using System;
using System.Collections.Generic;
using System.Text;

namespace TheNextCar.Model
{
    class doorController
    {
        private bool locked;
        private bool closed;
        puclic void Close()
        {
            this.closed = true;
        }
        public void open()
        {
            this.closed = false;
        }
        public void activatelock()
        {
            this.locked = true;
        }
        public void unlock()
        {
            this.locked = false;
        }
        public bool islocked()
        {
            return this.locked;
        }
        public bool Isclosed()
        {
            return this.closed;
        }
    }
}
