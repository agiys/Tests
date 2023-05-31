using System;
using System.Data.OleDb;

namespace AccessDatabaseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Users\\Chupapimunyanya\\source\\repos\\Game\\Test\\Library\\Library\\Database.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Создание таблицы Книги
                OleDbCommand createBooksTableCommand = new OleDbCommand("CREATE TABLE Книги (id AUTOINCREMENT PRIMARY KEY, Название TEXT, ГодИздания INT, КолвоСтраниц INT, Автор TEXT)", connection);
                createBooksTableCommand.ExecuteNonQuery();

                // Создание таблицы Читатели
                OleDbCommand createReadersTableCommand = new OleDbCommand("CREATE TABLE Читатели (ID AUTOINCREMENT PRIMARY KEY, Имя TEXT, Фамилия TEXT, Адрес TEXT, Телефон TEXT)", connection);
                createReadersTableCommand.ExecuteNonQuery();

                // Создание таблицы Выдача
                OleDbCommand createIssueTableCommand = new OleDbCommand("CREATE TABLE Выдача (ID AUTOINCREMENT PRIMARY KEY, ДатаВыдачи DATETIME, idКниги INT, idЧитателя INT, ДатаВозврата DATETIME, FOREIGN KEY (idКниги) REFERENCES Книги(id), FOREIGN KEY (idЧитателя) REFERENCES Читатели(ID))", connection);
                createIssueTableCommand.ExecuteNonQuery();

                Console.WriteLine("Таблицы успешно созданы.");

                connection.Close();
            }
        }
    }
}
