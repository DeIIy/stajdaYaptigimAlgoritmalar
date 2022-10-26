using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace staj1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private static List<Location> _Location = new List<Location>();

        [HttpPost]

        public string Add(Location _location)
        {
            _location.ID = new Random().Next();
            _Location.Add(_location);
            return "<-Location_Added->";
        }

        [HttpGet]

        public List<Location> GetAll()
        {
            return _Location;
        }

        [HttpGet("{id}")]

        public Location Get(int id)
          {
            var _getLocation = _Location.Find(x => x.ID == id);
            return _getLocation;
          }

        [HttpDelete]

        public string DeleteLocation(int ID)
        {
            var _deleteLocation = _Location.FirstOrDefault(x => x.ID == ID);
            if (_deleteLocation != null)
            {
                _Location.Remove(_deleteLocation);
            }

            return "<-Location_Deleted->";
        }

        [HttpPut]

        public string Put(Location _location)
        {
            var _updateLocation = _Location.FirstOrDefault(x => x.ID == _location.ID);
            if (_updateLocation != null)
            {
                _updateLocation.Name = _location.Name;
            }
            _updateLocation.X = _location.X;
            _updateLocation.Y = _location.Y;
            return "<-Location_Updated->";
        }
    }
}
