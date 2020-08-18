using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Flex00
{
    class DBHelper
    {
        // Const выражении
        public const string ERROR_ISFORMAT = "Нельзя вводить одинарные кавычки, точку с запятой, -- и слэш";
        public const string ERROR_ISSURNAME = "Фамилия должна состоять из букв";
        public const string ERROR_ISNAME = "Имя должна состоять из букв";
        public const string ERROR_ISDIGIT = " состоять только из цифр";
        public const string CAPTION_ISFORMAT = "Неправильные символы";

        // Строка подключения
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory.Remove(Environment.CurrentDirectory.Length - 10) + @"\Database.mdf;Integrated Security=True";
        
        public static async Task ExecuteCommand(params string[] sql)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    for (int i = 0; i < sql.Length; i++)
                    {
                        SqlCommand command = new SqlCommand(sql[i], connection);
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // Добавление данных
        public static async Task InsertClientAndSoldSub(Client client, SoldSub soldSub)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string sql = "";

                    sql = string.Format("INSERT INTO Clients (" +
                            "Surname, " + // N'{0}'
                            "Name, " + // N'{1}'
                            "Patronymic, " + // N'{2}'
                            "[Date Add], " + // N'{3}'
                            "[Date Update]) " +  // N'{4}'
                            "VALUES (" +
                            "N'{0}', N'{1}', N'{2}', '{3}', '{4}')",
                            client.Surname,
                            client.Name,
                            client.Patronymic,
                            client.DateAdd,
                            client.DateUpdate);
                    SqlCommand command = new SqlCommand(sql, connection);
                    await command.ExecuteNonQueryAsync();

                    command.CommandText = "SELECT CONVERT(int, SCOPE_IDENTITY()) FROM Clients";
                    int lastId = 0;
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        lastId = (int) reader[0];
                    }
                    reader.Close();

                    sql = string.Format("INSERT INTO [Sold Subscriptions] (" +
                        "Surname, " + // N'{0}'
                        "Name, " + // N'{1}'
                        "[Id of Client], " + // N'{2}'
                        "[Subscription number], " + // N'{3}'
                        "[Subscription type], " + // N'{4}'
                        "[Start date], " + // N'{5}'
                        "[End date], " + // N'{6}'
                        "Visit, " + // N'{7}'
                        "[Payment date], " + // N'{8}'
                        "[With Trainer], " + //  '{9}'
                        "[With Discount], " + // N'{10}'
                        "[Type Payment], " + //  '{11}'
                        "Amount, " + //  '{12}'
                        "Additional) " + // N'{13}'
                        "VALUES (" +
                        "N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', '{9}', N'{10}', '{11}', '{12}', N'{13}')",
                        client.Surname,
                        client.Name,
                        lastId,
                        soldSub.SubscriptionNumber,
                        soldSub.SubscriptionType,
                        soldSub.StartDate,
                        soldSub.EndDate,
                        soldSub.Visit,
                        soldSub.PaymentDate,
                        soldSub.WithTrainer,
                        soldSub.Discount,
                        soldSub.TypePayment,
                        soldSub.Amount,
                        soldSub.Additional);

                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static async Task InsertSoldSub(SoldSub soldSub, string idOfClient, string surname, string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string sql = "";

                    sql = string.Format("INSERT INTO [Sold Subscriptions] (" +
                        "Surname, " + // N'{0}'
                        "Name, " + // N'{1}'
                        "[Id of Client], " + // N'{2}'
                        "[Subscription number], " + // N'{3}'
                        "[Subscription type], " + // N'{4}'
                        "[Start date], " + // N'{5}'
                        "[End date], " + // N'{6}'
                        "Visit, " + // N'{7}'
                        "[Payment date], " + // N'{8}'
                        "[With Trainer], " + //  '{9}'
                        "[With Discount], " + // N'{10}'
                        "[Type Payment], " + //  '{11}'
                        "Amount, " + //  '{12}'
                        "Additional) " + // N'{13}'
                        "VALUES (" +
                        "N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', '{9}', N'{10}', '{11}', '{12}', N'{13}')",
                        surname,
                        name,
                        idOfClient,
                        soldSub.SubscriptionNumber,
                        soldSub.SubscriptionType,
                        soldSub.StartDate,
                        soldSub.EndDate,
                        soldSub.Visit,
                        soldSub.PaymentDate,
                        soldSub.WithTrainer,
                        soldSub.Discount,
                        soldSub.TypePayment,
                        soldSub.Amount,
                        soldSub.Additional);
                    SqlCommand command = new SqlCommand(sql, connection);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static Task InsertProduct(Product product)
        {
            string sql = "";
            sql = string.Format("INSERT INTO Products (" +
                "Name, " + // N'{0}'
                "Price, " + //  '{1}'
                "Count) " + //  '{2}'
                "VALUES (" +
                "N'{0}', '{1}', '{2}')",
                product.Name,
                product.Price,
                product.Count);
            return ExecuteCommand(sql);
        }
        public static Task InsertSell(Sell sell)
        {
            string sql = "";
            sql = string.Format("INSERT INTO Sells (" +
                "Name, "  + // N'{0}'
                "Count, " + //  '{1}'
                "Price,"  + //   {2}
                "Date, "  + //  '{3}'
                "Amount," + //   {4}
                "TypePayment) " + // N'{5}'
                "VALUES (" +
                "N'{0}', {1}, {2}, '{3}', {4}, N'{5}')",
                sell.Name,
                sell.Count,
                sell.Price,
                sell.Date,
                sell.Amount,
                sell.TypePayment);
            return ExecuteCommand(sql);
        }
        public static Task InsertEvent(string text, string type, string time, string who)
        {
            string sql = string.Format(
            "INSERT INTO Events (Event, Type, Time, Who) VALUES (N'{0}', '{1}', '{2}', '{3}')",
            text, type, time, who);
            return ExecuteCommand(sql);
        }
        public static Task InsertServices(Service service)
        {
            string sql = "";
            sql = string.Format("INSERT INTO Services VALUES (N'{0}', {1}, N'{2}', {3})",
                service.Name,
                service.Price,
                service.Limit,
                service.Month);
            return ExecuteCommand(sql);
        }

        // Изменение данных
        public static Task UpdateSoldSub(SoldSub soldSub, string id)
        {
            string sql = string.Format("UPDATE [Sold Subscriptions] SET " +
                "[Subscription number] = N'{0}', " +
                "[Subscription type] = N'{1}', " +
                "[Start date] = N'{2}', " +
                "[End date] = N'{3}', " +
                "Visit = N'{4}', " +
                "[Payment date] = N'{5}', " +
                "[With Trainer] = N'{6}', " +
                "[With Discount] = '{7}', " +
                "[Type Payment] = '{8}', " +
                "Amount = '{9}', " +
                "Additional = N'{10}' " +
                "WHERE id = {11} ",
                soldSub.SubscriptionNumber,
                soldSub.SubscriptionType,
                soldSub.StartDate,
                soldSub.EndDate,
                soldSub.Visit,
                soldSub.PaymentDate,
                soldSub.WithTrainer,
                soldSub.Discount,
                soldSub.TypePayment,
                soldSub.Amount,
                soldSub.Additional,
                id);
            return ExecuteCommand(sql);
        }
        public static Task UpdateProduct(Product product, string id)
        {
            string sql = "";
            sql = string.Format("UPDATE Products SET " +
                "Name = N'{0}', " +
                "Price = {1}, " +
                "Count = {2}" +
                "WHERE Id = {3}",
                product.Name,
                product.Price,
                product.Count,
                id);
            return ExecuteCommand(sql);
        }
        public static Task UpdateService(Service service, Service oldService, string oldPrice, string oldMonth)
        {
            string sql = "";
            sql = string.Format("UPDATE Services SET " +
                "Name = N'{0}', " +
                "Price = {1}, " +
                "Limit = N'{2}', " +
                "Month = {3} " +
                "WHERE (Name = N'{4}') AND (Price = {5}) AND (Limit = N'{6}') AND (Month = {7})",
                service.Name,
                service.Price,
                service.Limit,
                service.Month,
                oldService.Name,
                oldPrice,
                oldService.Limit,
                oldMonth);
            return ExecuteCommand(sql);
        }
        public static Task DecrementProduct(int count, string id)
        {
            string sql = "";
            sql = string.Format("UPDATE Products SET Count = {0} WHERE Id = {1}", count, id);
            return ExecuteCommand(sql);
        }
        public static Task DecrementVisit(byte newLimit, string id)
        {
            string sql = "";
            sql = string.Format("UPDATE [Sold Subscriptions] SET Visit = '{0}' WHERE id = {1}", newLimit, id);
            return ExecuteCommand(sql);
        }

        // Дизайн
        public static void SetRoundedShape(Control control, int radius, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.Clear(control.Parent.BackColor);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddLine(radius, 0, control.Width - radius, 0);
                path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                path.AddLine(control.Width, radius, control.Width, control.Height - radius);
                path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                path.AddLine(control.Width - radius, control.Height, radius, control.Height);
                path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                path.AddLine(0, control.Height - radius, 0, radius);
                path.AddArc(0, 0, radius, radius, 180, 90);
                using (SolidBrush brush = new SolidBrush(control.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        // Функции проверок, которые применяются во всех формах
        public static bool isFormat(string s)
        {
            if (s.IndexOf("'") == -1 &&
                s.IndexOf("\\") == -1 &&
                s.IndexOf(";") == -1 &&
                s.IndexOf("--") == -1)
                return true;
            else
                return false;
        }
        public static bool isString(string s)
        {
            string newString = s;
            if (s.Contains('-')) newString = s.Replace("-", "");
            return newString.ToCharArray().All(char.IsLetter) ? true : false;
        }
        public static bool isDigit(string s) => int.TryParse(s, out int a) ? true : false;

        // АРХИВЫ
        public static async Task DeleteSoldSub(string id)
        {
            SoldSub soldSub = new SoldSub();
            string surname = "";
            string name = "";
            string idOfClient = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string sql = "SELECT * FROM [Sold Subscriptions] WHERE Id = " + id;
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        idOfClient = reader[1].ToString();
                        surname = reader[2].ToString();
                        name = reader[3].ToString();
                        string subNumberString = reader[4].ToString().Trim();
                        soldSub.SubscriptionNumber = int.Parse(subNumberString);
                        soldSub.SubscriptionType = reader[5].ToString();
                        soldSub.StartDate = ((DateTime)reader[6]).ToString("yyyy-MM-dd");
                        soldSub.EndDate = ((DateTime)reader[7]).ToString("yyyy-MM-dd");
                        soldSub.Visit = reader[8].ToString();
                        soldSub.PaymentDate = ((DateTime)reader[9]).ToString("yyyy-MM-dd");
                        soldSub.WithTrainer = (bool)reader[10];
                        soldSub.Discount = reader[11].ToString();
                        soldSub.TypePayment = (bool)reader[12];
                        soldSub.Amount = reader[13].ToString();
                        soldSub.Additional = reader[14].ToString();
                    }
                    reader.Close();

                    sql = string.Format("INSERT INTO [AR Sold Subs] (" +
                        "[Old_id]," + // '{0}'
                        "Surname, " + // N'{1}'
                        "Name, " + // N'{2}'
                        "[Id of Client], " + // N'{3}'
                        "[Subscription number], " + // N'{4}'
                        "[Subscription type], " + // N'{5}'
                        "[Start date], " + // N'{6}'
                        "[End date], " + // N'{7}'
                        "Visit, " + // N'{8}'
                        "[Payment date], " + // N'{9}'
                        "[With Trainer], " + //  '{10}'
                        "[With Discount], " + // N'{11}'
                        "[Type Payment], " + //  '{12}'
                        "Amount, " + //  '{13}'
                        "Additional) " + // N'{14}'
                        "VALUES (" +
                        "'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', '{10}', N'{11}', '{12}', '{13}', N'{14}')",
                        id,
                        surname,
                        name,
                        idOfClient,
                        soldSub.SubscriptionNumber,
                        soldSub.SubscriptionType,
                        soldSub.StartDate,
                        soldSub.EndDate,
                        soldSub.Visit,
                        soldSub.PaymentDate,
                        soldSub.WithTrainer,
                        soldSub.Discount,
                        soldSub.TypePayment,
                        soldSub.Amount,
                        soldSub.Additional);
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();

                    sql = "DELETE FROM [Sold Subscriptions] WHERE Id = " + id;
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static async Task DeleteClient(string id)
        {
            Client client = new Client();
            string phone = "";
            string add = "";
            string image = "";
            string idOfClient = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string sql = "SELECT * FROM Clients WHERE Id = " + id;
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        idOfClient = reader[0].ToString();
                        client.Surname = reader[1].ToString();
                        client.Name = reader[2].ToString();
                        client.Patronymic = reader[3].ToString();
                        phone = reader[4].ToString();
                        add = reader[5].ToString();
                        client.DateAdd = ((DateTime)reader[6]).ToString("yyyy-MM-dd");
                        client.DateUpdate = ((DateTime)reader[7]).ToString("yyyy-MM-dd");
                        image = reader[8].ToString();
                    }
                    reader.Close();

                    sql = string.Format("INSERT INTO [AR Clients] (" +
                            "Old_id," + // '{0}'
                            "Surname, " + // N'{1}'
                            "Name, " + // N'{2}'
                            "Patronymic, " + // N'{3}'
                            "Phone, " + // N'{4}'
                            "Additional, " + // N'{5}'
                            "[Date Add], " + // '{6}'
                            "[Date Update], " +  // '{7}'
                            "Image)" + // N'{8}'
                            "VALUES (" +
                            "'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', '{6}', '{7}', N'{8}')",
                            idOfClient,
                            client.Surname,
                            client.Name,
                            client.Patronymic,
                            phone,
                            add,
                            client.DateAdd,
                            client.DateUpdate,
                            image);
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();

                    sql = string.Format("UPDATE [Sold Subscriptions] SET [Id of Client] = N'удален[{0}]' WHERE [Id of Client] = N'{0}'", id);
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();

                    sql = string.Format("UPDATE [AR Sold Subs] SET [Id of Client] = N'удален[{0}]' WHERE [Id of Client] = N'{0}'", id);
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();

                    sql = "DELETE FROM [Clients] WHERE Id = " + id;
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static async Task DeleteProduct(string id)
        {
            Product product = new Product();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string sql = "SELECT * FROM Products WHERE Id = " + id;
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        product.Name = reader[1].ToString();
                        product.Count = int.Parse(reader[2].ToString());
                        product.Price = int.Parse(reader[3].ToString());
                    }
                    reader.Close();

                    sql = string.Format("INSERT INTO [AR Products] (" +
                        "[Old_id]," + // '{0}'
                        "Name, " + // N'{1}'
                        "Count, " + // '{2}'
                        "Price) " + // '{3}'
                        "VALUES (" +
                        "'{0}', N'{1}', '{2}', '{3}')",
                        id,
                        product.Name,
                        product.Count,
                        product.Price);
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();

                    sql = "DELETE FROM [Products] WHERE Id = " + id;
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static async Task DeleteSell(string id)
        {
            Sell sell = new Sell();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string sql = "SELECT * FROM Sells WHERE Id = " + id;
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        sell.Name = reader[1].ToString();
                        sell.Count = int.Parse(reader[2].ToString());
                        sell.Price = int.Parse(reader[3].ToString());
                        sell.Date = ((DateTime)reader[4]).ToString("yyyy-MM-dd");
                        sell.Amount = int.Parse(reader[5].ToString());
                        sell.TypePayment = reader[6].ToString();
                    }
                    reader.Close();

                    sql = string.Format("INSERT INTO [AR Sells] (" +
                        "[Old_id]," + // '{0}'
                        "Name, " + // N'{1}'
                        "Count, " + // '{2}'
                        "Price, " + // '{3}'
                        "Date, " + // N'{4}'
                        "Amount, " + // '{5}'
                        "TypePayment) " + // N'{6}'
                        "VALUES (" +
                        "'{0}', N'{1}', '{2}', '{3}', N'{4}', '{5}', N'{6}')",
                        id,
                        sell.Name,
                        sell.Count,
                        sell.Price,
                        sell.Date,
                        sell.Amount,
                        sell.TypePayment);
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();

                    sql = "DELETE FROM [Sells] WHERE Id = " + id;
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // РАЗАРХИВ
        public static async Task UnZipSoldSub(string id)
        {
            SoldSub soldSub = new SoldSub();
            string surname = "";
            string name = "";
            string idOfClient = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string sql = "SELECT * FROM [AR Sold Subs] WHERE Id = " + id;
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        idOfClient = reader[2].ToString();
                        surname = reader[3].ToString();
                        name = reader[4].ToString();
                        string subNumberString = reader[5].ToString().Trim();
                        soldSub.SubscriptionNumber = int.Parse(subNumberString);
                        soldSub.SubscriptionType = reader[6].ToString();
                        soldSub.StartDate = ((DateTime)reader[7]).ToString("yyyy-MM-dd");
                        soldSub.EndDate = ((DateTime)reader[8]).ToString("yyyy-MM-dd");
                        soldSub.Visit = reader[9].ToString();
                        soldSub.PaymentDate = ((DateTime)reader[10]).ToString("yyyy-MM-dd");
                        soldSub.WithTrainer = (bool)reader[11];
                        soldSub.Discount = reader[12].ToString();
                        soldSub.TypePayment = (bool)reader[13];
                        soldSub.Amount = reader[14].ToString();
                        soldSub.Additional = reader[15].ToString();
                    }
                    reader.Close();

                    var task = InsertSoldSub(soldSub, idOfClient, surname, name);

                    sql = "DELETE FROM [AR Sold Subs] WHERE Id = " + id;
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static async Task UnZipClient(string id, string oldId)
        {
            Client client = new Client();
            string phone = "";
            string add = "";
            string image = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string sql = "SELECT * FROM [AR Clients] WHERE Id = " + id;
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        client.Surname = reader[2].ToString();
                        client.Name = reader[3].ToString();
                        client.Patronymic = reader[4].ToString();
                        phone = reader[5].ToString();
                        add = reader[6].ToString();
                        client.DateAdd = ((DateTime)reader[7]).ToString("yyyy-MM-dd");
                        client.DateUpdate = ((DateTime)reader[8]).ToString("yyyy-MM-dd");
                        image = reader[9].ToString();
                    }
                    reader.Close();

                    sql = string.Format("INSERT INTO Clients (" +
                            "Surname, " + // N'{0}'
                            "Name, " + // N'{1}'
                            "Patronymic, " + // N'{2}'
                            "Phone, " + // N'{3}'
                            "Additional, " + // N'{4}'
                            "[Date Add], " + // '{5}'
                            "[Date Update], " +  // '{6}'
                            "Image) " + // N'{7}'
                            "VALUES (" +
                            "N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', '{5}', '{6}', N'{7}')",
                            client.Surname,
                            client.Name,
                            client.Patronymic,
                            phone,
                            add,
                            client.DateAdd,
                            client.DateUpdate,
                            image);
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();

                    command.CommandText = "SELECT CONVERT(int, SCOPE_IDENTITY()) FROM Clients";
                    int lastId = 0;
                    reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        lastId = (int)reader[0];
                    }
                    reader.Close();

                    sql = string.Format("UPDATE [Sold Subscriptions] SET [Id of Client] = '{0}' WHERE [Id of Client] = N'удален[{1}]'", id, oldId);
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();

                    sql = string.Format("UPDATE [AR Sold Subs] SET [Id of Client] = '{0}' WHERE [Id of Client] = N'удален[{1}]'", id, oldId);
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();

                    sql = "DELETE FROM [AR Clients] WHERE Id = " + id;
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static async Task UnZipProduct(string id)
        {
            Product product = new Product();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string sql = "SELECT * FROM [AR Products] WHERE Id = " + id;
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        product.Name = reader[2].ToString();
                        product.Count = int.Parse(reader[3].ToString());
                        product.Price = int.Parse(reader[4].ToString());
                    }
                    reader.Close();

                    sql = string.Format("INSERT INTO Products (" +
                        "Name, " + // N'{0}'
                        "Count, " + // '{1}'
                        "Price) " + // '{2}'
                        "VALUES (" +
                        "N'{0}', '{1}', '{2}')",
                        product.Name,
                        product.Count,
                        product.Price);
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();

                    sql = "DELETE FROM [AR Products] WHERE Id = " + id;
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static async Task UnZipSell(string id)
        {
            Sell sell = new Sell();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string sql = "SELECT * FROM [AR Sells] WHERE Id = " + id;
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        sell.Name = reader[2].ToString();
                        sell.Count = int.Parse(reader[3].ToString());
                        sell.Price = int.Parse(reader[4].ToString());
                        sell.Date = ((DateTime)reader[5]).ToString("yyyy-MM-dd");
                        sell.Amount = int.Parse(reader[6].ToString());
                        sell.TypePayment = reader[7].ToString();
                    }
                    reader.Close();

                    sql = string.Format("INSERT INTO Sells (" +
                        "Name, " + // N'{0}'
                        "Count, " + // '{1}'
                        "Price, " + // '{2}'
                        "Date, " + // N'{3}'
                        "Amount, " + // '{4}'
                        "TypePayment) " + // N'{5}'
                        "VALUES (" +
                        "N'{0}', '{1}', '{2}', N'{3}', '{4}', N'{5}')",
                        sell.Name,
                        sell.Count,
                        sell.Price,
                        sell.Date,
                        sell.Amount,
                        sell.TypePayment);
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();

                    sql = "DELETE FROM [AR Sells] WHERE Id = " + id;
                    command.CommandText = sql;
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // Методы для заполнения статичных полей
        public static async void addDiscounts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Discounts";
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                List<string> data = new List<string>();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    string name = reader.GetValue(1).ToString();
                    string value = reader.GetValue(2).ToString();
                    data.Add("[" + name + "]{" + value + "}");
                }
                reader.Close();
                Data.Discounts = data;
            }
        }

        // Закрытие Excel
        public static void ReleaseExcel(object excel)
        {
            // Уничтожение объекта Excel.
            Marshal.ReleaseComObject(excel);
            // Вызываем сборщик мусора для немедленной очистки памяти
            GC.GetTotalMemory(true);
        }

        // Просто функции
        public static string getSurnameError() => ERROR_ISSURNAME;
        public static string getNameError() => ERROR_ISNAME;
        public static string getIsFormatError() => ERROR_ISFORMAT;
        public static string getIsDigitError(string s) => s + ERROR_ISDIGIT;
        public static string getOr() => "\nИли ";
        public static string getCaption() => "Предупреждение";
        public static string getCaptionIsFormat() => CAPTION_ISFORMAT;
    }
}
