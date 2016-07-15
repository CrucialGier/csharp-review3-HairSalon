using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon.Objects;
{
  public class StylistTest
  {
    private int _id;
    private string _name;

    public Stylist(int Id = 0, string Name)
    {
      _id = Id;
      _name = Name;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
