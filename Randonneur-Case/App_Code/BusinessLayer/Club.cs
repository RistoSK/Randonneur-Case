/* *************************************************************************
 * Department.cs    Original version: Kari Silpiö 20.3.2014 v1.0
 *                  Modified by     : Risto Sardis Karhunen
 * -----------------------------------------------------------------------
 *  Application: Model Case
 *  Layer:       Business Logic Layer
 *  Class:       Business object class describing a single Department
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by: Risto Sardis Karhunen"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************* */
using System;


public class Club
{
    private int clubID;
    private String clubName; 
    private String city;
    private String email;

    public Club()
    {
        clubID = -1;
        clubName = "";
        city = "";   
        email = "";
    }

    public int ClubId
    {
        get { return clubID; }
        set { clubID = value; }
    }

    public String ClubName
    {
        get { return clubName; }
        set { clubName = value; }
    }

    public String City
    {
        get { return city; }
        set { city = value; }
    }
    
    public String Email
    {
        get { return email; }
        set { email = value; }
    }
}
// End