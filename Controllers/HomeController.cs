using Microsoft.AspNetCore.Mvc;
using Geolocation;
using System.Threading.Tasks;
using trendyolGO.Services;
using Geocoding;
using trendyolGO.Models;

namespace trendyolGO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new HomeViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HomeViewModel model)
        {
            double radius = Convert.ToDouble(model.SelectedRadius);
            var originCoordinate = new Coordinate { Latitude = 41.001234, Longitude = 29.395314 };
            model.Results = GetResults(originCoordinate, radius, model.SelectedDistanceUnit);
            return View(model);
        }
        private IEnumerable<ResultModel> GetResults(Coordinate originCoordinate, double radius, DistanceUnit distanceUnit)
        {
            var boundaries = new CoordinateBoundaries(originCoordinate.Latitude, originCoordinate.Longitude, radius, distanceUnit);
            //secili tum konumlar
            return Locations
                .Where(x => x.Latitude >= boundaries.MinLatitude && x.Latitude <= boundaries.MaxLatitude)
                .Where(x => x.Longitude >= boundaries.MinLongitude && x.Longitude <= boundaries.MaxLongitude)
                .Select(result => new ResultModel
                {
                    Name = result.Name,
                    Distance = GeoCalculator.GetDistance(originCoordinate.Latitude, originCoordinate.Longitude, result.Latitude, result.Longitude, distanceUnit: distanceUnit),
                    Direction = GeoCalculator.GetDirection(originCoordinate.Latitude, originCoordinate.Longitude, result.Latitude, result.Longitude)
                })
                .Where(x => x.Distance <= radius)
                .OrderBy(x => x.Distance);
        }
        private IEnumerable<LocationModel> Locations
        {
            get
            {
                return new List<LocationModel>
                {
                    new LocationModel { Name = "Istanbul", Latitude = 41.017058, Longitude = 28.985568},
                    new LocationModel { Name = "Konya", Latitude = 42.017058, Longitude = 28.985568},
                    new LocationModel { Name = "Izmir", Latitude = 41.507058, Longitude = 28.985568},
                    new LocationModel { Name = "Ankara", Latitude = 41.717058, Longitude = 28.985568},
                    new LocationModel { Name = "Agri", Latitude = 42.517058, Longitude = 28.985568}
                };
            }
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page";
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}