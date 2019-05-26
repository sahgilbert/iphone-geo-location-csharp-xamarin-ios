using System;
using CoreLocation;

namespace SimonGilbert.Blog.GeoLocation
{
    public class LocationUpdatedEventArgs : EventArgs
    {
        private readonly CLLocation _location;

        public LocationUpdatedEventArgs(CLLocation location)
        {
            this._location = location;
        }

        public CLLocation Location { get { return _location; } }
    }
}
