using System;

/// <summary>
/// Department - Business object class
/// <remarks>Original version: Kari Silpiö 2014
///          Modified by: </remarks>
/// </summary>
public class Rider
{
    private int riderID;
    private String surname;
    private String givenName;
    private int phone;
    private String password;
    private String email;
    private String repassword;
    private String gender;
    private String username;
    private Club club;
    private String role;
    

    public Rider()
    {
        riderID = 0;
        surname = "";
        givenName = "";
        phone = 0;
        password = "";
        email = "";
        repassword = "";
        gender = "";
        username = "";
    }

    public int RiderId
    {
        get { return riderID; }
        set { riderID = value; }
    }

    public String Surname
    {
        get { return surname; }
        set { surname = value; }
    }

    public int Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    public String GivenName
    {
        get { return givenName; }
        set { givenName = value; }
    }

    public String Password
    {
        get { return password; }
        set { password = value; }
    }

    public String RePassword
    {
        get { return repassword; }
        set { repassword = value; }
    }

    public Club Club
    {
        get { return club; }
        set { club = value; }
    }

    public String Username
    {
        get { return username; }
        set { username = value; }
    }
 
    public String Email
    {
        get { return email; }
        set { email = value; }
    }

    public String Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    public String Role
    {
        get { return role; }
        set { role = value; }
    }
}