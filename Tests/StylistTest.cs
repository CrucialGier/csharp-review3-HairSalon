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
    public void Test_Find_FindsCategoryInDatabase()
    {
      Stylist testStylist = new Stylist("Rebecca");
      testStylist.Save();

      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      Assert.Equal(testStylist, foundStylist);
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
    public void Test_Delete_DeletesStylistFromDatabase()
    {
      string name1 = "Rebecca";
      Stylist testStylist1 = new Stylist(name1);
      testStylist1.Save();

      string name2 = "Tony";
      Stylist testStylist2 = new Stylist(name2);
      testStylist2.Save();

      Client testClient1 = new Client("Sam", testStylist1.GetId());
      testClient1.Save();
      Client testClient2 = new Client("Beth", testStylist2.GetId());
      testClient2.Save();
      Console.WriteLine(Client.Find(testClient1.GetId()).GetName());
      Console.WriteLine(Client.Find(testClient2.GetId()).GetName());

      testStylist1.Delete();

      List<Stylist> resultStylists = Stylist.GetAll();
      List<Stylist> testStylistList = new List<Stylist> {testStylist2};

      List<Client> resultClients = Client.GetAll();
      List<Client> testClientList = new List<Client> {testClient2};

      Assert.Equal(testStylistList, resultStylists);
      Assert.Equal(testClientList, resultClients);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
