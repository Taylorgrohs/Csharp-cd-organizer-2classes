using System.Collections.Generic;
using ArtistList;

namespace CdTitle{
  public class Cd
  {
    private string _title;
    private int _id;
    private static List<Cd> _instances = new List<Cd> {};

    public Cd(string title)
    {
      _title = title;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetTitle()
    {
      return _title;
    }
    public void SetTitle(string newTitle)
    {
      _title = newTitle;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Cd> GetAll()
    {
      return _instances;
    }
    public static Cd Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
