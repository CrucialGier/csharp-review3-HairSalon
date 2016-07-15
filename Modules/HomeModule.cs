using System.Collections.Generic;
using System;
using Nancy;
using HairSalon.Objects;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] =_=> {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/stylist-form"] =_=> {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylist_form.cshtml", allStylists];
      };
      Post["/added-stylist"] =_=> {
        Stylist newStylist = new Stylist(Request.Form["newName"]);
        newStylist.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/appointments/{id}"] = parameters => {
        Stylist currentStylist = Stylist.Find(parameters.id);
        return View["stylist.cshtml", currentStylist];
      };
      Post["/new-appointment/{id}"] = parameters => {
        Client newClient = new Client(Request.Form["newClient"], parameters.id);
        newClient.Save();
        Stylist currentStylist = Stylist.Find(parameters.id);
        return View["stylist.cshtml", currentStylist];
      };
      Get["/stylist/edit/{id}"] = parameters => {
        Stylist currentStylist = Stylist.Find(parameters.id);
        return View["stylist_edit.cshtml", currentStylist];
      };
      Patch["/stylist/edit/{id}"] = parameters => {
        Stylist currentStylist = Stylist.Find(parameters.id);
        currentStylist.Update(Request.Form["newName"]);
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/stylist/delete/{id}"] = parameters => {
        Stylist currentStylist = Stylist.Find(parameters.id);
        return View["stylist_delete.cshtml", currentStylist];
      };
      Delete["/stylist/delete/{id}"] = parameters => {
        Stylist currentStylist = Stylist.Find(parameters.id);
        currentStylist.Delete();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/appointment/edit/{id}"] = parameters => {
        Client currentClient = Client.Find(parameters.id);
        return View["client_edit.cshtml", currentClient];
      };
      Patch["/appointment/edit/{id}"] = parameters => {
        Client currentClient = Client.Find(parameters.id);
        Stylist currentStylist = Stylist.Find(currentClient.GetStylistId());
        currentClient.Update(Request.Form["newName"], currentStylist.GetId());
        return View["stylist.cshtml", currentStylist];
      };
      Get["/appointment/delete/{id}"] = parameters => {
        Client currentClient = Client.Find(parameters.id);
        return View["client_delete.cshtml", currentClient];
      };
      Delete["/appointment/delete/{id}"] = parameters => {
        Client currentClient = Client.Find(parameters.id);
        currentClient.Delete();
        Stylist currentStylist = Stylist.Find(currentClient.GetStylistId());
        return View["stylist.cshtml", currentStylist];
      };
    }
  }
}
