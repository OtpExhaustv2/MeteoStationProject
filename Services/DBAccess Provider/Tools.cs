using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoSationProject.Services.DBAccess_Provider
{
    class Tools
    {

        internal static OleDbDataAdapter Adapter = new OleDbDataAdapter();

        internal static OleDbConnection connexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;"
                                                                            +
                                                                        @"Data Source=..\..\DB_UserAccess.accdb;Cache Authentication=True");
        internal static void Config()
        {
            string Insert_CommandText = "INSERT into UserTable(UserName,UserPassword,Access_Id) values(?,?,?);";
            string Delete_CommandText = "DELETE FROM UserTable WHERE UserKey_Id = ?;";
            string Select_CommandText = "SELECT * from UserTable ORDER BY UserKey_Id;";
            string Update_CommandText = "UPDATE UserTable SET UserPassword = ?, Access_Id = ? WHERE UserKey_Id = ?;";

            OleDbCommand Insert_Command = new OleDbCommand(Insert_CommandText, connexion);
            OleDbCommand Delete_Command = new OleDbCommand(Delete_CommandText, connexion);
            OleDbCommand Select_Command = new OleDbCommand(Select_CommandText, connexion);
            OleDbCommand Update_Command = new OleDbCommand(Update_CommandText, connexion);

            Adapter.SelectCommand = Select_Command;
            Adapter.InsertCommand = Insert_Command;
            Adapter.DeleteCommand = Delete_Command;
            Adapter.UpdateCommand = Update_Command;

            Adapter.TableMappings.Add("UserTable", "Local_UserTable");
            Adapter.TableMappings.Add("AccessTable", "Local_AccessTable");

            Adapter.InsertCommand.Parameters.Add("@UserName", OleDbType.VarChar, 40, "UserName");
            Adapter.InsertCommand.Parameters.Add("@UserPassword", OleDbType.VarChar, 40, "UserPassword");
            Adapter.InsertCommand.Parameters.Add("@Access_Id", OleDbType.Numeric, 100, "Access_Id");
            Adapter.DeleteCommand.Parameters.Add("@UserKey_ID", OleDbType.Numeric, 40, "UserKey_ID");
            Adapter.UpdateCommand.Parameters.Add("@UserPassword", OleDbType.VarChar, 40, "UserPassword");
            Adapter.UpdateCommand.Parameters.Add("@Access_Id", OleDbType.Numeric, 100, "Access_Id");
            Adapter.UpdateCommand.Parameters.Add("@UserKey_ID", OleDbType.Numeric, 40, "UserKey_ID");
        }
    }
}
