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
    }
  }
}
