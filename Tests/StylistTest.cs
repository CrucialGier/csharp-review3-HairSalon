using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Stylist.Objects
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=todolist_;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
