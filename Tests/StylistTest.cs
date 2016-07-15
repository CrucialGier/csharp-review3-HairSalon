using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_Stylist_ObjectEqualsOverrideTrue()
    {
      Stylist firstStylist = new Stylist("Rebecca");
      Stylist secondStylist = new Stylist("Rebecca");

      Assert.Equal(firstStylist, secondStylist);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
