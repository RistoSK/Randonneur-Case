/* *************************************************************************
 * LoginRole.cs  Original version: Kari Silpiö 20.3.2014 v1.0
 *               Modified by     : Risto Sardis Karhunen
 * -----------------------------------------------------------------------
 *  Application: Model Case
 *  Class:       Business object class holding username and login role
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by: Risto Sardis Karhunen"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************* */
using System;


public class LoginRole
{
    private String username;
    private String role;
    
    public LoginRole()
    {
        username = "";
        role = null;
    } 
   
    public String Username
    {
        get { return username; }
        set { username = value; }
    }

    public String Role
    {
        get { return role; }
        set { role = value; }
    }
}
// End