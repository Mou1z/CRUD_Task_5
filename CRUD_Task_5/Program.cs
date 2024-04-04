using MySql.Data.MySqlClient;

public class CRUD_Task_5
{
    // Write the connection string here
    public static string connectionString = "host=___;port=___;user=___;password=___;database=___";

    public static void Main(string[] args)
    {
        // Write code below this line
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            // code here ..
        }
        // Write code above this line
    }
}
