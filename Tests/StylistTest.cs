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
    public void Test_Equals_ObjectEqualsOverride()
    {
      Stylist firstStylist = new Stylist("Rebecca");
      Stylist secondStylist = new Stylist("Rebecca");

      Assert.Equal(firstStylist, secondStylist);
    }

    [Fact]
    public void Test_GetAll_RetrievesAllStylistsFromDatabase()
    {
      Stylist firstStylist = new Stylist("Rebecca");
      Stylist secondStylist = new Stylist("Tony");
      firstStylist.Save();
      secondStylist.Save();

      List<Stylist> testList = new List<Stylist>{firstStylist, secondStylist};
      List<Stylist> result = Stylist.GetAll();

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_SavesStylistToDatabase()
    {
      Stylist testStylist = new Stylist("Rebecca");
      testStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Update_UpdatesStylistInDatabase()
    {
      string name = "Rebecca";
      Stylist testStylist = new Stylist(name);
      testStylist.Save();
      string newName = "Becky";

      testStylist.Update(newName);
      
      string result = testStylist.GetName();

      Assert.Equal(newName, result);
    }

    [Fact]
     public void Test_Find_FindsCategoryInDatabase()
     {
       Stylist testStylist = new Stylist("Rebecca");
       testStylist.Save();

       Stylist foundStylist = Stylist.Find(testStylist.GetId());

       Assert.Equal(testStylist, foundStylist);
     }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
