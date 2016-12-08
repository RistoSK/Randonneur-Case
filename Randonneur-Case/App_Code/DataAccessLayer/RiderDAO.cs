using System;
using System.Collections.Generic;
using System.Data;
using Karis.DatabaseLibrary;   

/// <summary>
/// Summary description for RiderDAO
/// </summary>
public class RiderDAO
 {
    private Database myDatabase;
    private String myConnectionString;

    public RiderDAO()
    {
        myConnectionString = ModelCaseConnectionString.Text;
        myDatabase = new Database();
    }
    public int DeleteRider(int RiderID)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (IDExistsForRider(RiderID) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
              @"DELETE FROM Rider
                 WHERE riderId = {0}", RiderID);

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

    /// <summary>
    /// Retrieves all Department rows in alphabetical order by Department name from the database.
    /// </summary>
    /// <returns>A List of Departments</returns>
    public List<Rider> GetAllRidersOrderedByName()
    {
        List<Rider> RiderList = new List<Rider>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText =
              @"SELECT riderId, familyName, givenName, gender , phone , email , clubId , username , password , role
                  FROM Rider
              ORDER BY ridertId";

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Rider rider = new Rider();

                rider.RiderId = (int)resultSet["riderId"];
                rider.Surname = (String)resultSet["familyName"];
                rider.GivenName = (String)resultSet["givenName"];
                rider.Phone = (int)resultSet["phone"];
                rider.Email = (String)resultSet["email"];
                rider.Gender = (String)resultSet["gender"];
                rider.Club.ClubName = (string)resultSet["clunId"];
                rider.Username = (string)resultSet["username"];
                rider.Password = (string)resultSet["password"];

                RiderList.Add(rider);
            }

            resultSet.Close();

            return RiderList;
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

    /// <summary>
    /// Retrieves a single Department row by DepartmentId from the database.
    /// </summary>
    /// <returns>A single Department object</returns>
    public Rider GetRiderByRiderId(int RiderID)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
               @"SELECT riderId, familyName, givenName, gender , phone , email , clubId , username , password , role
                  FROM Rider          
                 WHERE riderId = {0}", RiderID);

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                Rider rider = new Rider();

                rider.RiderId = (int)resultSet["Riderid"];
                rider.Surname = (String)resultSet["familyName"];
                rider.GivenName = (String)resultSet["givenName"];
                rider.Phone = (int)resultSet["phone"];
                rider.Email = (String)resultSet["email"];
                rider.Club.ClubName = (string)resultSet["clunName"];
                rider.Username = (string)resultSet["username"];
                rider.Password = (string)resultSet["password"];

                return rider;
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

    /// <summary>
    /// Inserts a single Department row into the database.
    /// </summary>
    /// <returns>0 = OK, 1 = insert not allowed, -1 = error</returns>
    public int InsertRider(Rider rider)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (RiderIDExists(rider.RiderId) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
              @"INSERT INTO riderId, familyName, givenName, gender , phone , email , clubId , username , password , role)
                VALUES ({0}, '{1}', '{2}', '{3}' , '{4}', '{5}', '{6}'), '{7}'), '{8}'))",
                rider.RiderId,
                rider.Surname,
                rider.GivenName,
                rider.Phone,
                rider.Email,
                rider.Club.ClubName,
                rider.Username,
                rider.Password);
           

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
    public int UpdateRider(Rider rider)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"UPDATE Rider
                SET  Password    = '{0}', 
                    Surname = '{1}',    
                    GivenName    = '{2}',
                          Phone = '{3}',
                         Email = '{4}',    
                    ClubName    = '{5}',
                          Username = '{6}',        
                WHERE RiderId  =  {7}",
               rider.Password,
                rider.Surname,
                rider.GivenName,
                rider.Phone,
                rider.Email,
                rider.Club.ClubName,
                rider.Username,
                rider.RiderId);

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
    /// Checks if a Department row with the given Department id exists in the database.
    /// </summary>
    /// <returns>true = row exists, otherwise false</returns>
    private bool RiderIDExists(int RiderID)
{
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT riderId 
              FROM Rider
             WHERE riderId = {0}", RiderID);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }

    /// <summary>
    /// Checks if the Department row is being referenced by another row. 
    /// </summary>
    /// <returns>true = a child row exists, otherwise false</returns>
    private bool IDExistsForRider(int brevetID)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT riderId
              FROM Rider
             WHERE riderId = {0}", brevetID);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }
}