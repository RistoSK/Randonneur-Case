using System;
using System.Collections.Generic;
using System.Data;
using Karis.DatabaseLibrary;




public class BrevetDAO
{
    private Database myDatabase;
    private String myConnectionString;

    public BrevetDAO()
    {
        myConnectionString = ModelCaseConnectionString.Text;
        myDatabase = new Database();
    }
    public int DeleteBrevet(int BrevetID)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (IDExistsForBrevet(BrevetID) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
              @"DELETE FROM Brevet
                 WHERE brevetId = {0}", BrevetID);

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
    public List<Brevet> GetAllBrevetsOrderedByName()
    {
        List<Brevet> BrevetList = new List<Brevet>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText =
              @"SELECT brevetId, distance, brevetDate, location ,climbing
                  FROM Brevet
              ORDER BY brevetId";
            
            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Brevet brevet = new Brevet();
                brevet.BrevetId = (int)resultSet["brevetId"];
                brevet.Distance = (int)resultSet["distance"];
                brevet.Date = (DateTime)resultSet["brevetDate"];
                brevet.Location = (String)resultSet["location"];
                brevet.Climbing = (int)resultSet["climbing"];
                BrevetList.Add(brevet);
            }

            resultSet.Close();

            return BrevetList;
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
    public Brevet GetBrevetByBrevetId(int BrevetID)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"SELECT brevetId, distance, brevetDate, location ,climbing
                  FROM Brevet           
                 WHERE brevetId = {0}", BrevetID);

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                Brevet brevet = new Brevet();

                brevet.BrevetId = (int)resultSet["Brevetid"];
                brevet.Distance = (int)resultSet["Distance"];
                brevet.Date = (DateTime)resultSet["Date"];
                brevet.Location = (String)resultSet["Location"];
                brevet.Climbing = (int)resultSet["Climbing"];

                return brevet;
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
    public int InsertBrevet(Brevet brevet)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (BrevetIDExists(brevet.BrevetId) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
              @"INSERT INTO brevetId, distance, brevetDate, location ,climbing)
                VALUES ({0}, '{1}', '{2}', '{3}' , '{4}', '{5}')",
                brevet.BrevetId,
                brevet.Distance,
                brevet.Date,
                brevet.Location,
                brevet.Climbing);

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
    public int UpdateBrevet(Brevet brevet)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"UPDATE Brevet
                SET  distance    = '{0}', 
                    brevetDate = '{1}',    
                    location    = '{2}',
                          climbing = '{3}',   
                WHERE brevetid  =  {4}",
                brevet.Distance,
                brevet.Date,
                brevet.Location,
                brevet.Climbing,
                brevet.BrevetId);

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
    private bool BrevetIDExists(int BrevetID)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT brevetId 
              FROM Brevet 
             WHERE brevetId = {0}", BrevetID);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }

    /// <summary>
    /// Checks if the Department row is being referenced by another row. 
    /// </summary>
    /// <returns>true = a child row exists, otherwise false</returns>
    private bool IDExistsForBrevet(int brevetID)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT brevetId
              FROM Brevet
             WHERE brevetId = {0}", brevetID);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }
}