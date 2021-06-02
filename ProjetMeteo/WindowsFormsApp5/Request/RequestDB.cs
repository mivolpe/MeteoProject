using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApp5.Request
{
    public class RequestDB
    {
        DataTable UserTable = new DataTable();
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;"
                +
                @"Data Source=..\..\DB\DB_UserAccess1.accdb;Cache Authentication=True";
        OleDbConnection connection = new OleDbConnection();
        OleDbCommand command = new OleDbCommand();

        public void createUser(String username, String password, int Access)
        {
            if (Form1.accessLvl == 1)
            {
                connection.ConnectionString = connectionString;
                try
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "insert into UserTable (UserName,UserPassword,Access_Id) values ('" + username + "','" + password + "','" + Access + "')";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            else
            {
                MessageBox.Show("Vous ne disposez pas des droits nécessaire pour effectuer cette opération");
            }
        }

        public void readData(DataGridView gridUser)
        {
            if (Form1.accessLvl == 1)
            {
                UserTable.Rows.Clear();
                if (!UserTable.Columns.Contains("ID"))
                {
                    UserTable.Columns.Add("ID", typeof(Int32));
                    UserTable.Columns.Add("UserName", typeof(string));
                    UserTable.Columns.Add("UserPassword", typeof(string));
                    UserTable.Columns.Add("AccessID", typeof(Int32));
                }

                connection.ConnectionString = connectionString;
                try
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select * from UserTable";
                    OleDbDataReader dbDataReader = command.ExecuteReader();
                    if (dbDataReader.HasRows)
                    {
                        while (dbDataReader.Read())
                        {
                            UserTable.Rows.Add(new object[] { dbDataReader[0], dbDataReader[1], dbDataReader[2], dbDataReader[3] });
                        }
                    }
                    dbDataReader.Close();
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                gridUser.DataSource = UserTable;
            }
            else
            {
                MessageBox.Show("Vous ne disposez pas des droits nécessaire pour effectuer cette opération");
            }

        }

        public void deleteUser(DataGridView gridUser)
        {
            if (Form1.accessLvl == 1)
            {
                int rowToDelete = gridUser.CurrentCell.RowIndex;
                int id = (int)gridUser.Rows[rowToDelete].Cells[0].Value;
                UserTable.Rows.RemoveAt(rowToDelete);

                try
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "delete from UserTable where UserKey_ID = " + id;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            else
            {
                MessageBox.Show("Vous ne disposez pas des droits nécessaire pour effectuer cette opération");
            }

        }

        public void loginUser (String username, String password)
        {
            connection.ConnectionString = connectionString;
            try 
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select Access_Id from UserTable where UserName = '" + username + "' and UserPassword = '" + password+"' ";
                OleDbDataReader dbDataReader = command.ExecuteReader();
                if (dbDataReader.Read())
                {
                    Form1.username = username;
                    Form1.accessLvl =(int) dbDataReader[0];
                    MessageBox.Show("Connexion réussite");
                    
                }
                else
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect");
                }
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }



    }
}
