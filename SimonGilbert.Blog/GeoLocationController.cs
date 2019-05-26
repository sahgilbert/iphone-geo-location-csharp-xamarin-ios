using SimonGilbert.Blog.GeoLocation;
using SimonGilbert.Blog.UI.Helpers;
using UIKit;

namespace SimonGilbert.Blog
{
    public class GeoLocationController : UIViewController
    {
        public static LocationManager LocationManager { get; set; }
        private UIView geoLocationDataView;
        private UILabel geoLocationData;

        public GeoLocationController()
        {
            LocationManager = new LocationManager();

            LocationManager.StartLocationUpdates();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;
            Title = "Geo Location";

            CreateGeoLocationLabelView();

            SubscribeToLocationUpdates();

            UnsubscribeFromUpdatesWhenAppEntersBackgroundState();
        }

        private void SubscribeToLocationUpdates()
        {
            LocationManager.LocationUpdated += HandleLocationChanged;

            UIApplication.Notifications.ObserveDidBecomeActive((sender, args) =>
            {
                LocationManager.LocationUpdated += HandleLocationChanged;
            });
        }

        private void UnsubscribeFromUpdatesWhenAppEntersBackgroundState()
        {
            UIApplication.Notifications.ObserveDidEnterBackground((sender, args) =>
            {
                LocationManager.LocationUpdated -= HandleLocationChanged;
            });
        }

        public void HandleLocationChanged(object sender, LocationUpdatedEventArgs e)
        {
            var currentGeoLocation = $"{e.Location.Coordinate.Latitude.ToString()} {e.Location.Coordinate.Longitude.ToString()}";

            geoLocationData.Text = currentGeoLocation;
        }

        private void CreateGeoLocationLabelView()
        {
            const float titleXAxisPosition = 5;
            const int titleYAxisPosition = 50;
            const float titleHeight = 20;

            var geoLocationTitle = UIHelper.CreateViewWithLabel(
                titleXAxisPosition,
                titleYAxisPosition,
                titleHeight,
                "Your Geo Location");

            this.View.AddSubview(geoLocationTitle);

            const float yAxisMargin = 15;
            const float dataXAxisPosition = 5;
            var dataYAxisPosition = titleYAxisPosition + yAxisMargin;
            var dataHeight = 20;

            geoLocationDataView = UIHelper.CreateView(
                dataXAxisPosition,
                dataYAxisPosition,
                dataHeight);

            geoLocationData = UIHelper.CreateLabel(
                dataXAxisPosition,
                dataYAxisPosition,
                dataHeight);

            geoLocationDataView.AddSubview(geoLocationData);

            this.View.AddSubview(geoLocationDataView);
        }

    }
}