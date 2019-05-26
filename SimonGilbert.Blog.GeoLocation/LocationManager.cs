using System;
using CoreLocation;
using UIKit;

namespace SimonGilbert.Blog.GeoLocation
{
    public class LocationManager
    {
        protected CLLocationManager locationManager;

        public event EventHandler<LocationUpdatedEventArgs> LocationUpdated = delegate { };

        public LocationManager()
        {
            this.locationManager = new CLLocationManager
            {
                PausesLocationUpdatesAutomatically = false
            };

            ConfigureiOS8Permissions();

            ConfigureiOS9BackgroundUpdates();
        }

        public CLLocationManager GeoLocationManager
        {
            get { return this.locationManager; }
        }

        private void ConfigureiOS8Permissions()
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                locationManager.RequestAlwaysAuthorization();
            }
        }

        private void ConfigureiOS9BackgroundUpdates()
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
            {
                locationManager.AllowsBackgroundLocationUpdates = true;
            }
        }

        public void StartLocationUpdates()
        {
            if (CLLocationManager.LocationServicesEnabled)
            {
                SetDesiredAccuracyInMetres();

                GeoLocationManager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) => 
                {
                    LocationUpdated(this, new LocationUpdatedEventArgs(e.Locations[e.Locations.Length - 1]));
                };

                GeoLocationManager.StartUpdatingLocation();
            }
        }

        private void SetDesiredAccuracyInMetres()
        {
            GeoLocationManager.DesiredAccuracy = 1;
        }
    }
}
