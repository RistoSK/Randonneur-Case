using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class BrevetRider
{
    private Rider rider;
    private Brevet brevet;
    private String isCompleted;
    private String finishingTime;
	public BrevetRider()
	{
	 rider = new Rider();
     brevet = new Brevet();
	}

public Rider Rider
    {
        get { return rider; }
        set { rider = value; }
    }
public Brevet Brevet
    {
        get { return brevet; }
        set { brevet = value; }
    }
public String IsCompleted
    {
        get { return isCompleted; }
        set { isCompleted = value; }
    }
public String FinishingTime
    {
        get { return finishingTime; }
        set { finishingTime = value; }
    }
}