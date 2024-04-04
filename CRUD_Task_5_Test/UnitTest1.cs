using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System;

[TestClass]
public class CRUD_Task_5_Tests
{
    private readonly string connectionString = CRUD_Task_5.connectionString;

    [TestMethod]
    public void TestStoreDataAfterDelete()
    {
        CRUD_Task_5.Main(null);

        object[,] actualData = RetrieveStoreDataFromDatabase();

        object[,] expectedData = new object[,]
        {
            { 1, "Bananas", "Fruits", 0.99f, 150 },
            { 2, "Apples", "Fruits", 1.49f, 100 },
            { 5, "Milk", "Dairy", 2.49f, 200 },
            { 6, "Eggs", "Dairy", 1.99f, 120 },
            { 7, "Bread", "Bakery", 1.99f, 200 },
            { 8, "Chicken", "Meat", 4.99f, 200 },
            { 9, "Rice", "Grains", 3.99f, 120 },
            { 10, "Pasta", "Grains", 1.49f, 150 }
        };

        Assert.AreEqual(expectedData.Length, actualData.Length, "Number of items in store does not match.");

        for (int i = 0; i < expectedData.GetLength(0); i++)
        {
            for (int j = 0; j < expectedData.GetLength(1); j++)
            {
                Assert.AreEqual(expectedData[i, j], actualData[i, j], $"Mismatch at row {i + 1}, column {j + 1}.");
            }
        }
    }

    private object[,] RetrieveStoreDataFromDatabase()
    {
        object[,] storeData = new object[8, 5];

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string cmdText = "SELECT id, name, category, price, stock_quantity FROM store ORDER BY id";
            MySqlCommand cmd = new MySqlCommand(cmdText, connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                int row = 0;
                while (reader.Read() && row < 8)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        storeData[row, col] = reader.GetValue(col);
                    }
                    row++;
                }
            }
        }

        return storeData;
    }
}