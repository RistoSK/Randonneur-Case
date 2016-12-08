/* *************************************************************************
 * DepartmentDAO.cs   Original version: Kari Silpiö 20.3.2014 v1.0
 *                    Modified by     : Risto Sardis Karhunen
 * ------------------------------------------------------------------------
 *  Application: Model Case
 *  Layer:       Data Access Layer
 *  Class:       SQL Server specific DAO class for Department entity objects
 * -------------------------------------------------------------------------
 * NOTICE: This is an over-simplified example for an introductory course. 
 * - Error processing is not robust (some error are not handled)
 * - No multi-user considerations, no transaction programming 
 * - No protection for attacks of type 'SQL injection'
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by: Risto Sardis Karhunen"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************* */
using System;
using System.Collections.Generic;

using System.Data;
using Karis.DatabaseLibrary;

/// <summary>
/// DepartmentDAO - Data Access Layer interface class. Accesses the data storage.
/// <remarks>Original version: Kari Silpiö 2014
///          Modified by: Risto Sardis Karhunen </remarks>
/// </summary>
public class ClubDAO
{
    private Database myDatabase;
    private String myConnectionString;

    public ClubDAO()
    {
        myConnectionString = ModelCaseConnectionString.Text;
        myDatabase = new Database();
    }


    public int DeleteClub(int ClubID)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (ClubNameExistsForClub(ClubID) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
              @"DELETE FROM Club
                 WHERE clubId = {0}", ClubID);

            myDatabase.ExecuteUpdate(sqlText);

            return 0;   // OK
        }
        catch (Exception)
        {
            return -1; // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }


    public List<Club> GetAllClubsOrderedByName()
    {
        List<Club> ClubList = new List<Club>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = 
              @"SELECT clubId, ClubName, city, email
                  FROM Club
              ORDER BY clubId";

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Club club = new Club();
                club.ClubId = (int)resultSet["ClubId"];
                club.ClubName = (String)resultSet["ClubName"];
                club.City = (String)resultSet["City"];    
                club.Email = (String)resultSet["Email"];
                ClubList.Add(club);
            }

            resultSet.Close();

            return ClubList;
        }
        catch (Exception)
        {
            return null; // An error occured
        }
        finally
        {
            myDatabase.Close();
        }
    }

 
    public Club GetClubByClubId(int clubID)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"SELECT clubId, clubName, city, email
                  FROM Club
                 WHERE clubId = {0}", clubID);

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                Club club = new Club();

                club.ClubId = (int)resultSet["ClubId"];
                club.ClubName = (String)resultSet["ClubName"];
                club.City = (String)resultSet["City"];
                club.Email = (String)resultSet["Email"];
                resultSet.Close();

                return club;
            }
            else
            {
                return null; // Not found
            }
        }
        catch (Exception)
        {
            return null;  // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }

    public int InsertClub(Club club)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (ClubIDExists(club.ClubId) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
              @"INSERT INTO club (clubId, ClubName, city, email)
                VALUES ({0}, '{1}', '{2}', '{3}')",
                club.ClubId,
                club.ClubName, 
                club.City,
                club.Email);

            myDatabase.ExecuteUpdate(sqlText);

            return 0;  // OK
        }
        catch (Exception)
        {
            return -1; // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }

    /// <summary>
    /// Updates an existing Department row in the database.
    /// </summary>
    /// <returns>0 = OK, -1 = error</returns>
    public int UpdateClub(Club club)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"UPDATE Club
                SET clubName  = '{0}', 
                    city = '{1}',    
                    email     = '{2}'
                WHERE clubId  =  {3}",
                club.ClubName,
                club.City,
                club.Email,
                club.ClubId);

            myDatabase.ExecuteUpdate(sqlText);

            return 0;  // OK
        }
        catch (Exception)
        {
            return -1; // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }


    private bool ClubIDExists(int ClubID)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT clubId 
              FROM Club 
             WHERE clubId = {0}", ClubID);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }


    private bool ClubNameExistsForClub(int clubID)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT clubName
              FROM Club
             WHERE clubId = {0}", clubID);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }
}
// End
