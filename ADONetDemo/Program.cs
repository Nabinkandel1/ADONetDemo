
using System.Data;
using Microsoft.Data.SqlClient;

namespace ADONetDemo
{
    class Program
    {
        //For Window Authentication
        static string connection = "Server=192.168.84.83;Database=AdoNetDemo; Encrypt=true; TrustServerCertificate=true; Integrated Security=true";

        //For SQL Server Authentication
        //static string connection = "Server=192.168.1.3;Database=AdoNetDemo; User Id=sa; Password=Docker123;TrustServerCertificate=true;";

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Create Table");
                Console.WriteLine("2. Insert Data");
                Console.WriteLine("3. Read Data");
                Console.WriteLine("4. Update Data");
                Console.WriteLine("5. Delete Data");
                Console.WriteLine("6. Exit");

                Console.WriteLine("Enter Your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateTable();
                        break;
                    case "2":
                        InsertData();
                        break;
                    case "3":
                        ReadData();
                        break;
                    case "4":
                        UpdateData();
                        break;
                    case "5":
                        DeleteData();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        private static void DeleteData()
        {
            throw new NotImplementedException();
        }

        private static void UpdateData()
        {
            throw new NotImplementedException();
        }

        private static void ReadData()
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "SELECT * FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Employees");

                Console.WriteLine("\n--- Employees (Using SqlDataAdapter) ---");
                foreach (DataRow row in ds.Tables["Employees"].Rows)
                {
                    Console.WriteLine($"Name: {row["Name"]}, Position: {row["Position"]}, Salary: {row["Salary"]}");
                }
            }
        }

        private static void InsertData()
        {
            Console.WriteLine("Enter Your name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your position");
            string position = Console.ReadLine();

            Console.WriteLine("Enter salary ammount");
            string salary = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "Insert into employees(Name, Position, salary) values (@name, @position, @salary)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@salary", salary);
                conn.Open();

                int rowAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowAffected} rows inserted");
            }
        }

        private static void CreateTable()
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string createTableQuery = @"
                    CREATE TABLE Employees (
                        Id INT PRIMARY KEY IDENTITY(1,1), 
                        Name NVARCHAR(100) NOT NULL,
                        Position NVARCHAR(100) NOT NULL,
                        Salary DECIMAL(18, 2) NOT NULL
                    )";
                using (SqlCommand cmd = new SqlCommand(createTableQuery, conn))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Table created successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error creating table: {ex.Message}");
                    }
                }
            }
        }
    }
}