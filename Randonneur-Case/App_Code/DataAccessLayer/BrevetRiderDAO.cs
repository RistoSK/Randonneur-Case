using System;
using System.Collections.Generic;
using System.Data;
using Karis.DatabaseLibrary;

/// <summary>
/// Summary description for BrevetRiderDAO
/// </summary>
public class BrevetRiderDAO
{
    private Database myDatabase;
    private String myConnectionString;

	public BrevetRiderDAO()
	{
        myConnectionString = ModelCaseConnectionString.Text;
        myDatabase = new Database();
	}

    public List<BrevetRider> GetRidersByBrevet(int brevetID)
    {
        List<BrevetRider> brevetRiderList = new List<BrevetRider>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
           @"SELECT Rider.riderId, familyName, givenName
                  FROM Brevet_Rider  
                  JOIN Rider  ON (Brevet_Rider.riderId = Rider.riderId)
                         
                 WHERE brevetId = {0}", brevetID);


            resultSet = myDatabase.ExecuteQuery(sqlText);

            while (resultSet.Read() == true)
            {
                BrevetRider brevetRider = new BrevetRider();

                brevetRider.Rider.Surname = (String)resultSet["familyName"];
                brevetRider.Rider.GivenName = (String)resultSet["givenName"];
                brevetRider.Rider.RiderId = (int)resultSet["riderId"];
                brevetRider.Brevet.BrevetId = brevetID;
                brevetRiderList.Add(brevetRider);
            }

            resultSet.Close();

            return brevetRiderList;

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


    public List<Brevet> GetAllBrevetsOrderedByName(int BrevetID)
    {
        List<Brevet> brevetList = new List<Brevet>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText =
              @"SELECT brevetId, distance, brevetDate, location 
                  FROM Brevet_Rider
              JOIN Brevet AS (Brevet_Rider.brevetId = Brevet.brevetId
              ORDER BY brevetId";

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Brevet brevet = new Brevet();
                brevet.BrevetId = (int)resultSet["Brevetid"];
                brevet.Distance = (int)resultSet["distance"];
                brevet.Date = (DateTime)resultSet["date"];
                brevet.Location = (String)resultSet["location"];
                brevetList.Add(brevet);
            }

            resultSet.Close();

            return brevetList;
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
}