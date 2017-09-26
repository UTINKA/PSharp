/*
 * Copyright (C) 2017-2018 Alimşah YILDIRIM <alimsahy@gmail.com>
 *
 * PSharp is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * PSharp is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using PSharp.Interface;
using PSharp.Events;

namespace PSharp.Network
{
    class MySQL : INetworkConnection, IDisposable
    {
        private String m_currentDatabase;
        private String m_currentTable;
        private String m_server;
        private String m_user;
        private String m_password;

        private Int32 m_databaseCount;
        private Int32 m_tableCount;
        private Int32 m_queryNumRow;

        private const Int32 MYSQL_ERROR_SERVER = 0;
        private const Int32 MYSQL_ERROR_CREDENTIALS = 1045;

        private MySqlConnection m_connection;
        private MySqlConnectionStringBuilder m_connectionBuilder;
        private MySqlDataAdapter m_adapter;
        private MySqlCommand m_query;

        public String Server { get; set; }
        public String User { get; set; }
        public String Password { get; set; }

        public event DatabaseCreateEventHandler DatabaseAdded;
        public event DatabaseDropEventHandler DatabaseRemoved;
        public event TableCreateEventHandler TableAdded;
        public event TableDropEventHandler TableRemoved;

        public MySQL()
        {
            Initialize();
        }

        public MySQL(String server, String user, String password)
        {
            Server = server;
            User = user;
            Password = password;
            Initialize();
        }

        private void Initialize()
        {
            m_connectionBuilder = new MySqlConnectionStringBuilder();
            m_connectionBuilder.Server = Server;
            m_connectionBuilder.UserID = User;
            m_connectionBuilder.Password = Password;
        }

        public void Connect()
        {
            m_connection = new MySqlConnection(m_connectionBuilder.ToString());
            
        }

        public void Connect(String server, String user, String password)
        {
           
        }

        public void Close()
        {

        }

        public void Dispose()
        {

        }

        public String[] GetTableNames(String database)
        {
            return null;
        }

        public String[] GetDatabaseNames()
        {
            List<String> databaseNames = new List<String>();
            try
            {
                MySqlDataReader reader = RunCommand("SHOW DATABASES").ExecuteReader();
                while (reader.Read())
                {
                    for (Int32 i = 0; i < reader.FieldCount; i++)
                    {
                        databaseNames.Add(reader.GetValue(i).ToString());
                    }
                }
                return databaseNames.ToArray();
            }
            catch (MySqlException ex)
            {

            }
            return null;
        }

        public MySqlCommand RunCommand(String queryString)
        {
            return new MySqlCommand(queryString, m_connection);
        }

        private void OnMySQLMessageInfo(object sender, MySqlInfoMessageEventArgs args)
        {

        }
    }
}
