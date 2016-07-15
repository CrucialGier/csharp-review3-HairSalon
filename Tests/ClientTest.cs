using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_Equals_ObjectEqualsOverride()
    {
      Client firstClient = new Client("Rebecca");
      Client secondClient = new Client("Rebecca");

      Assert.Equal(firstClient, secondClient);
    }

    [Fact]
    public void Test_GetAll_RetrievesAllClientsFromDatabase()
    {
      Client firstClient = new Client("Rebecca");
      Client secondClient = new Client("Tony");
      firstClient.Save();
      secondClient.Save();

      List<Client> testList = new List<Client>{firstClient, secondClient};
      List<Client> result = Client.GetAll();

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_SavesClientToDatabase()
    {
      Client testClient = new Client("Rebecca");
      testClient.Save();

      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindsCategoryInDatabase()
    {
      Client testClient = new Client("Rebecca");
      testClient.Save();

      Client foundClient = Client.Find(testClient.GetId());

      Assert.Equal(testClient, foundClient);
    }

    [Fact]
    public void Test_Update_UpdatesClientInDatabase()
    {
      string name = "Rebecca";
      Client testClient = new Client(name);
      testClient.Save();
      string newName = "Becky";

      testClient.Update(newName);

      string result = testClient.GetName();

      Assert.Equal(newName, result);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
