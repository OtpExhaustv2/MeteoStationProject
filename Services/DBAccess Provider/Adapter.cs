using MeteoSationProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeteoSationProject.Services.DBAccess_Provider
{
    class Adapter
    {

        internal static bool Insert(string name, string password, int access)
        {
            Tools.Adapter.InsertCommand.Parameters[0].Value = name;
            Tools.Adapter.InsertCommand.Parameters[1].Value = password;
            Tools.Adapter.InsertCommand.Parameters[2].Value = access;

            try
            {
                Tools.connexion.Open();

                int buffer = Tools.Adapter.InsertCommand.ExecuteNonQuery();

                if (buffer != 0) MessageBox.Show("User successfully inserted");
                else MessageBox.Show("User not inserted");

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("An user with this username already exists!");
            }
            finally
            {
                Tools.connexion.Close();
            }

            return false;
        }
        internal static bool Delete(int id)
        {
            Tools.Adapter.DeleteCommand.Parameters[0].Value = id;

            try
            {
                Tools.connexion.Open();

                int buffer = Tools.Adapter.DeleteCommand.ExecuteNonQuery();

                if (buffer != 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Tools.connexion.Close();
            }

            return false;
        }

        internal static Dictionary<int, string> GetAllAccess()
        {
            Dictionary<int, string> accesses = new Dictionary<int, string>();
            OleDbCommand SelectCommand = new OleDbCommand("SELECT AccessKey_Id, AccessName FROM AccessTable ORDER BY AccessKey_Id", Tools.connexion);
            try
            {
                Tools.connexion.Open();
                OleDbDataReader DBReader = SelectCommand.ExecuteReader();
                if (DBReader.HasRows)
                {
                    while (DBReader.Read())
                    {
                        accesses.Add((int)DBReader[0], DBReader[1].ToString());
                    }
                }
                DBReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Tools.connexion.Close();
            }
            return accesses;
        }

        internal static User Connection(string username, string password)
        {
            OleDbCommand SelectCommand = new OleDbCommand("SELECT * FROM UserTable u, AccessTable a WHERE Username = ? AND UserPassword = ? AND a.AccessKey_Id = u.Access_Id;", Tools.connexion);
            SelectCommand.Parameters.Add("@UserName", OleDbType.VarChar, 40, "UserName");
            SelectCommand.Parameters.Add("@UserPassword", OleDbType.VarChar, 40, "UserPassword");
            SelectCommand.Parameters[0].Value = username;
            SelectCommand.Parameters[1].Value = password;
            try
            {
                Tools.connexion.Open();
                OleDbDataReader DBReader = SelectCommand.ExecuteReader();
                if (DBReader.HasRows)
                {
                    while (DBReader.Read())
                    {

                        Access access = new Access(DBReader[5].ToString(), (bool)DBReader[6], (bool)DBReader[7], (bool)DBReader[8], (bool)DBReader[9]);
                        User user = new User((int)DBReader[0], DBReader[1].ToString(), DBReader[2].ToString(), (int)DBReader[3], access);
                        UserProvider.UserProvider.User = user;
                        return user;
                    }
                }
                DBReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Tools.connexion.Close();
            }

            return null;
        }

        /* internal static void Fill(DataSet dataset, string TableName, string DB_Table, DataGridView Grid)
         {
             dataset.Tables[TableName].Clear();

             Tools.Adapter.SelectCommand = new OleDbCommand("SELECT * FROM " + DB_Table + ";", Tools.connexion);

             try
             {
                 Tools.connexion.Open();

                 Tools.Adapter.Fill(dataset.Tables[TableName]);

                 Grid.DataSource = dataset.Tables[TableName];
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 Tools.connexion.Close();
             }
         }
         internal static void Update(DataTable Table)
         {
             try
             {
                 Tools.connexion.Open();

                 Tools.Adapter.Update(Table);
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 Tools.connexion.Close();
             }
         }*/


    }

}
