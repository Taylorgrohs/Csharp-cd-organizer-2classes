using Nancy;
using System.Collections.Generic;
using CdTitle;
using ArtistList;

namespace Organize
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/"] = _ => {
        var allArtists = Artist.GetAll();
        return View["index.cshtml", allArtists];
      };
      Get["/artists/new"] = _ => {
        return View["artist_form.cshtml"];
      };
      Post["/"] = _ => {
        var newArtist = new Artist(Request.Form["artist-name"]);
        var allArtists = Artist.GetAll();
        return View["index.cshtml", allArtists];
      };
      Get["/artist/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedArtist = Artist.Find(parameters.id);
        var artistCds = selectedArtist.GetCds();
        model.Add("artist", selectedArtist);
        model.Add("cds", artistCds);
        return View["artist.cshtml", model];
      };
      Get["/artist/{id}/cds/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist selectedArtist = Artist.Find(parameters.id);
        List<Cd> allCds = selectedArtist.GetCds();
        model.Add("artist", selectedArtist);
        model.Add("cds", allCds);
        return View["artist_cd_form.cshtml", model];
      };
      Post["/cds"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist selectedArtist = Artist.Find(Request.Form["artist-id"]);
        List<Cd> artistCds = selectedArtist.GetCds();
        string cdTitle = Request.Form["cd-title"];
        Cd newCd = new Cd(cdTitle);
        artistCds.Add(newCd);
        model.Add("cds", artistCds);
        model.Add("artist", selectedArtist);
        return View["artist.cshtml", model];
      };

      Get["/search_artist"] = _ => View["search_artists.cshtml"];
      Post["/view_result"] = _ => {
        string artist = Request.Form["artist"];
        List<Artist> results = Artist.SearchArtist(artist);
        return View["view_result.cshtml", results];
      };
    }
  }
}
