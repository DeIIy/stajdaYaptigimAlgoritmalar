using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace stajWithDataUpdate3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        NpgsqlConnection con = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=222527; Database=databaseyusuf");

        static int number;

        [HttpPost]

        public string Add(Location _location)
        {
            con.Open();

            NpgsqlCommand c1 = new NpgsqlCommand(" INSERT INTO locationtableyusuf ( id , name , x , y) VALUES ( @i1 , @n1 , @x1 , @y1 )", con);

            if (_location.name != "")
            {
                if (_location.x != 0 && _location.y != 0)
                {
                    number = number + 1;
                    c1.Parameters.AddWithValue("i1", number);
                    c1.Parameters.AddWithValue("n1", _location.name);
                    c1.Parameters.AddWithValue("x1", _location.x);
                    c1.Parameters.AddWithValue("y1", _location.y);
                    c1.ExecuteNonQuery();

                    con.Close();
                    return "<-Location_Added->";
                }
                else
                {
                    return "<-Location_Information_Cannot_Be_Zero->";
                }
            }
            else
            {
                return "<-Location_Information_Cannot_Be_Empty->";
            }
        }

        [HttpGet]

        public List<Location> GetAll()
        {
            con.Open();

            NpgsqlCommand c2 = new NpgsqlCommand(" SELECT * FROM locationtableyusuf ", con);

            List<Location> list = new List<Location>();

            NpgsqlDataReader r1 = c2.ExecuteReader();

            while (r1.Read())
            {
                Location _newLocation = new Location();
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

            NpgsqlCommand c3 = new NpgsqlCommand(" SELECT * FROM locationtableyusuf WHERE id = @i2 ", con);

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

            NpgsqlCommand c4 = new NpgsqlCommand(" DELETE FROM locationtableyusuf WHERE id = @i3 ", con);

            c4.Parameters.AddWithValue("i3", id);
            c4.ExecuteNonQuery();

            con.Close();
            return "<-Location_Deleted->";
        }

        [HttpPut]

        public string Update(Location _location)
        {
            con.Open();

            if (_location.name != "string")
            {
                if (_location.x != 0)
                {
                    if (_location.y != 0)
                    {
                        NpgsqlCommand c5 = new NpgsqlCommand(" UPDATE locationtableyusuf SET name = @n4 , x = @x4 , y = @y4 WHERE id = @i4 ", con);
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
                    else
                    {
                        NpgsqlCommand c6 = new NpgsqlCommand(" UPDATE locationtableyusuf SET name = @n4 , x = @x4 WHERE id = @i4 ", con);
                        c6.Parameters.AddWithValue("i4", _location.id);

                        if (_location.name != null)
                        {
                            c6.Parameters.AddWithValue("n4", _location.name);
                        }
                        c6.Parameters.AddWithValue("x4", _location.x);
                        c6.ExecuteNonQuery();

                        return "<-Location_Name_X_Updated->";
                    }
                }
                else
                {
                    if (_location.y != 0)
                    {
                        NpgsqlCommand c7 = new NpgsqlCommand(" UPDATE locationtableyusuf SET name = @n4 , y = @y4 WHERE id = @i4 ", con);
                        c7.Parameters.AddWithValue("i4", _location.id);

                        if (_location.name != null)
                        {
                            c7.Parameters.AddWithValue("n4", _location.name);
                        }
                        c7.Parameters.AddWithValue("y4", _location.y);
                        c7.ExecuteNonQuery();

                        return "<-Location_Name_Y_Updated->";
                    }
                    else
                    {
                        NpgsqlCommand c8 = new NpgsqlCommand(" UPDATE locationtableyusuf SET name = @n4 WHERE id = @i4 ", con);
                        c8.Parameters.AddWithValue("i4", _location.id);

                        if (_location.name != null)
                        {
                            c8.Parameters.AddWithValue("n4", _location.name);
                        }
                        c8.ExecuteNonQuery();

                        return "<-Location_Name_Updated->";
                    }
                }
            }
            else
            {
                if (_location.x != 0)
                {
                    if (_location.y != 0)
                    {
                        NpgsqlCommand c9 = new NpgsqlCommand(" UPDATE locationtableyusuf SET x = @x4 , y = @y4 WHERE id = @i4 ", con);
                        c9.Parameters.AddWithValue("i4", _location.id);

                        c9.Parameters.AddWithValue("x4", _location.x);
                        c9.Parameters.AddWithValue("y4", _location.y);
                        c9.ExecuteNonQuery();

                        return "<-Location_X_Y_Updated->";
                    }
                    else
                    {
                        NpgsqlCommand c10 = new NpgsqlCommand(" UPDATE locationtableyusuf SET x = @x4 WHERE id = @i4 ", con);
                        c10.Parameters.AddWithValue("i4", _location.id);
                        c10.Parameters.AddWithValue("x4", _location.x);
                        c10.ExecuteNonQuery();

                        return "<-Location_X_Updated->";
                    }
                }
                else
                {
                    if (_location.y != 0)
                    {
                        NpgsqlCommand c11 = new NpgsqlCommand(" UPDATE locationtableyusuf SET y = @y4 WHERE id = @i4 ", con);
                        c11.Parameters.AddWithValue("i4", _location.id);
                        c11.Parameters.AddWithValue("y4", _location.y);
                        c11.ExecuteNonQuery();

                        return "<-Location_Y_Updated->";
                    }
                    else
                    {
                        return "<-Location_Not_Updated->";
                    }
                }
            }
            con.Close();
        }
    }
}
