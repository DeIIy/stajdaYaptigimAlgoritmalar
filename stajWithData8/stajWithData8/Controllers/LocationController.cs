using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace stajWithData8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        NpgsqlConnection con = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=222527; Database=databasepo");

        static int number;

        [HttpPost]

        public string Add(Location _location)
        {
            con.Open();

            NpgsqlCommand c1 = new NpgsqlCommand(" INSERT INTO locationtablepo ( id , name , x , y) VALUES ( @i1 , @n1 , @x1 , @y1 )", con);


            number = number + 1;
            c1.Parameters.AddWithValue("i1", number);
            if(_location.name!=null)
            {
                c1.Parameters.AddWithValue("n1", _location.name);
            }
            c1.Parameters.AddWithValue("x1", _location.x);
            c1.Parameters.AddWithValue("y1", _location.y);
            c1.ExecuteNonQuery();

            con.Close();
            return "<-Location_Added->";
        }       

        [HttpGet]

        public List<Location> GetAll()
        {
            con.Open();

            NpgsqlCommand c2 = new NpgsqlCommand(" SELECT * FROM locationtablepo ", con);

            List<Location> list = new List<Location>();
            Location _newLocation = new Location();

            NpgsqlDataReader r1 = c2.ExecuteReader();

            while (r1.Read())
            {
                _newLocation.id = r1.GetInt32(0);
                _newLocation.name = r1.GetString(1);
                _newLocation.x = r1.GetDouble(2);
                _newLocation.y = r1.GetDouble(3);
                list.Add(_newLocation);
            }

            r1.Close();
            con.Close();
            return list;
        }

        [HttpGet("{id}")]

        public Location Get(int id)
        {
            con.Open();

            Location _newLocation = new Location();

            NpgsqlCommand c3 = new NpgsqlCommand(" SELECT * FROM locationtablepo WHERE id = @i2 ", con);

            c3.Parameters.AddWithValue("i2", id);

            NpgsqlDataReader r2 = c3.ExecuteReader();

            while (r2.Read())
            {
                _newLocation.id = r2.GetInt32(0);
                _newLocation.name = r2.GetString(1);
                _newLocation.x = r2.GetDouble(2);
                _newLocation.y = r2.GetDouble(3);
            }

            r2.Close();
            con.Close();
            return _newLocation;
        }

        [HttpDelete("{id}")]

        public string Delete(int id)
        {
            con.Open();

            NpgsqlCommand c4 = new NpgsqlCommand(" DELETE FROM locationtablepo WHERE id = @i3 ", con);

            c4.Parameters.AddWithValue("i3", id);
            c4.ExecuteNonQuery();

            con.Close();
            return "<-Location_Deleted->";
        }

        [HttpPut]

        public string Update(Location _location)
        {
            con.Open();


            NpgsqlCommand c5 = new NpgsqlCommand(" UPDATE locationtablepo SET name = @n4 , x = @x4 , y = @y4 WHERE id = @i4 ", con);
            c5.Parameters.AddWithValue("i4", _location.id);

            if (_location.name != null)
            {
                c5.Parameters.AddWithValue("n4", _location.name);
            }
            c5.Parameters.AddWithValue("x4", _location.x);
            c5.Parameters.AddWithValue("y4", _location.y);
            c5.ExecuteNonQuery();

            return "<-Location_Name_X_Y_Updated->";
        }
    }
}
