
namespace ADONetDemo
{
    class Program
    {
        //For SQL Server Authentication
        //static string connection = "Server=192.168.84.83;Database=AdoNetDemo; Encrypt=true; TrustServerCertificate=true;";

        //For Window Authentication
        static string connection = "Server=192.168.84.83;Database=AdoNetDemo; User Id=sa; Password=Docker123;TrustServerCertificate=true;";

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
            throw new NotImplementedException();
        }

        private static void InsertData()
        {
            throw new NotImplementedException();
        }

        private static void CreateTable()
        {
            throw new NotImplementedException();
        }
    }
}