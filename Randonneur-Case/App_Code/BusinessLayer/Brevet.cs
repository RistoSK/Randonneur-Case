using System;

/// <summary>
/// Department - Business object class
/// <remarks>Original version: Kari Silpiö 2014
///          Modified by: </remarks>
/// </summary>
public class Brevet

{
    private int brevetID;
    private int distance;
    private DateTime  date;
    private String location;
    private int climbing;

  public Brevet()
    {
        brevetID = 0;
        distance = 0;
        climbing = 0;
        date = new DateTime(1900, 1, 1);
        location = "";
    }

    public int BrevetId
    {
        get { return brevetID; }
        set { brevetID = value; }
    }

    public int Distance
    {
        get { return distance; }
        set { distance = value; }
    }

    public int Climbing
    {
        get { return climbing; }
        set { climbing = value; }
    }

    public String Location
    {
        get { return location; }
        set { location = value; }
    }

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }
}