using MySql.Data.MySqlClient;

public class CRUD_Task_5
{
    // Write the connection string here
    public static string connectionString = "host=localhost;port=7777;user=root;password=Th!sIsMyPassword;database=school";

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