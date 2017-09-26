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
using System.ComponentModel;

using PSharp.Events;

namespace PSharp.IO
{
    public class CFGProperties
    {
        private Int32 m_lanmode;
        private Int32 m_maxplayers;
        private Int32 m_announce;
        private Int32 m_query;
        private Int32 m_port;
        private Int32 m_rcon;
        private Int32 m_maxnpc;
        private Int32 m_onfootRate;
        private Int32 m_incarRate;
        private Int32 m_weaponRate;
        private Int32 m_streamRate;
        private Int32 m_timestamp;
        private Int32 m_logqueries;
        private Int32 m_chatlogging;
        private Int32 m_playerTimeout;
        private Int32 m_minimumConnectionTime;
        private Int32 m_acksLimit;
        private Int32 m_connCookies;
        private Int32 m_cookieLogging;
        private Int32 m_dbLogging;
        private Int32 m_dbLogQueries;
        private Int32 m_lagcompMode;

        private String m_streamDistance;
        private String m_echo;
        private String m_hostname;
        private String m_gamemode;
        private String m_weburl;
        private String m_rconPassword;
        private String m_filterScripts;
        private String m_plugins;
        private String m_password;
        private String m_mapname;
        private String m_language;

        public event GamemodeChangeEventHandler GamemodeChanged;
        public event FiltercriptChangeEventHandler FilterscriptChanged;
        public event PluginsChangeEventHandler PluginChanged;

        /// <summary>
        ///     Gets or sets lanmode
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("Deprecated variable, has no effect.")]
        [DisplayName("lanmode")]
        public Int32 Lanmode
        {
            get
            {
                return m_lanmode;
            }
            set
            {
                if (m_lanmode == value)
                {
                    return;
                }
                m_lanmode = value;
            }
        }

        /// <summary>
        ///     Gets or sets maxplayers
        /// </summary>
        [Browsable(true)]
        [Category("Settings")]
        [Description("This is the maximum amount of players your server can hold, by changing this number you can alter how many players can enter the server. The maximum is 1000 and the minimum is 1.")]
        [DisplayName("maxplayers")]
        public Int32 MaxPlayers
        {
            get
            {
                return m_maxplayers;
            }
            set
            {
                if (m_maxplayers == value)
                {
                    return;
                }
                m_maxplayers = value;
            }
        }
        /// <summary>
        ///     Gets or sets announce
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("Toggle server to be announced to SA-MP masterlist. Set to 1 to enable announcing or 0 to disable.")]
        [DisplayName("announce")]
        public Int32 Announce
        {
            get
            {
                return m_announce;
            }
            set
            {
                if (m_announce == value)
                {
                    return;
                }
                m_announce = value;
            }
        }

        /// <summary>
        ///     Gets or sets query
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("Toggle querying of server. If this is disabled, the server information will not be displayed in the server browser. Set to 1 to enable querying or 0 to disable. ")]
        [DisplayName("query")]
        public Int32 Query
        {
            get
            {
                return m_query;
            }
            set
            {
                if (m_query == value)
                {
                    return;
                }
                m_query = value;
            }
        }

        /// <summary>
        ///     Gets or sets port
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("The port in which the server will use to communicate can be specified here, you will need to port forward in order to run the server")]
        [DisplayName("port")]
        public Int32 Port
        {
            get
            {
                return m_port;
            }
            set
            {
                if (m_port == value)
                {
                    return;
                }
                m_port = value;

            }
        }

        /// <summary>
        ///     Gets or sets Rcon
        /// </summary>
        [Browsable(true)]
        [Category("Server")]
        [Description("If 0 is specified the remote console feature is disabled")]
        [DisplayName("rcon")]
        public Int32 Rcon
        {
            get
            {
                return m_rcon;
            }
            set
            {
                if (m_rcon == value)
                {
                    return;
                }
                m_rcon = value;
            }
        }

        /// <summary>
        ///     Get or sets maximum npc
        /// </summary>
        [Browsable(true)]
        [Category("Server")]
        [Description("The maximum number of NPCs that can join your server.")]
        [DisplayName("maxnpc")]
        public Int32 MaxNPC
        {
            get
            {
                return m_maxnpc;
            }
            set
            {
                if (m_maxnpc == value)
                {
                    return;
                }
                m_maxnpc = value;
            }
        }

        /// <summary>
        ///     Gets or sets on foot rate
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("The minimum time in milliseconds a client updates the server with new data while running/walking.")]
        [DisplayName("onfoot_rate")]
        public Int32 OnFootRate
        {
            get
            {
                return m_onfootRate;
            }
            set
            {
                if (m_onfootRate == value)
                {
                    return;
                }
                m_onfootRate = value;
            }
        }

        /// <summary>
        ///     Gets or sets incar rate
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("The minimum time in milliseconds a client updates the server with new data while in a vehicle.")]
        [DisplayName("incar_rate")]
        public Int32 InCarRate
        {
            get
            {
                return m_incarRate;
            }
            set
            {
                if (m_incarRate == value)
                {
                    return;
                }
                m_incarRate = value;
            }
        }

        /// <summary>
        ///     Gets or sets weapon rate
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("The minimum time in milliseconds a client updates the server with new data while firing a weapon.")]
        [DisplayName("weapon_rate")]
        public Int32 WeaponRate
        {
            get
            {
                return m_weaponRate;
            }
            set
            {
                if (m_weaponRate == value)
                {
                    return;
                }
                m_weaponRate = value;
            }
        }

        /// <summary>
        ///     Gets or sets stream rate
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("The number of milliseconds that must elapse before server entities stream distance is retested for each player. The maximum is 5000 and the minimum is 500.")]
        [DisplayName("stream_rate")]
        public Int32 StreamRate
        {
            get
            {
                return m_streamRate;
            }
            set
            {
                if (m_streamRate == value)
                {
                    return;
                }
                m_streamRate = value;
            }
        }

        /// <summary>
        ///     Gets or sets timestamp
        /// </summary>
        [Browsable(true)]
        [Category("Settings")]
        [Description("Enable / Disable timestamp")]
        [DisplayName("timestamp")]
        public Int32 Timestamp
        {
            get
            {
                return m_timestamp;
            }
            set
            {
                if (m_timestamp == value)
                {
                    return;
                }
                m_timestamp = value;
            }
        }

        /// <summary>
        ///     Gets or sets log queries
        /// </summary>
        [Browsable(true)]
        [Category("Settings")]
        [Description("0 to disable, 1 to enable. This logs all queries sent to the server by players, it's considerably useful during a DDoS attack.")]
        [DisplayName("logqueries")]
        public Int32 LogQueries
        {
            get
            {
                return m_logqueries;
            }
            set
            {
                if (m_logqueries == value)
                {
                    return;
                }
                m_logqueries = value;
            }
        }

        /// <summary>
        ///     Gets or sets chat logging
        /// </summary>
        [Browsable(true)]
        [Category("Settings")]
        [Description("Enable/disable player chat to the server log. Useful to disable to stop the log becoming bloated, or if you have another scripted chat logging solution.")]
        [DisplayName("chatlogging")]
        public Int32 ChatLogging
        {
            get
            {
                return m_chatlogging;
            }
            set
            {
                if (m_chatlogging == value)
                {
                    return;
                }
                m_chatlogging = value;
            }
        }

        /// <summary>
        ///     Gets or sets lag comp mode
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("0: Setting this to 0 will fully disable lag compensation. Setting it to 1 will enable lag compensation. Setting it to 2 will enable position - only lag compensation.This means player rotation won't be lag comp'd.")]
        [DisplayName("lagcompmode")]
        public Int32 LagCompMode
        {
            get
            {
                return m_lagcompMode;
            }
            set
            {
                if (m_lagcompMode == value)
                {
                    return;
                }
                m_lagcompMode = value;
            }
        }

        /// <summary>
        ///     Gets or sets ackslimit
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("The default 'ackslimit' is raised from 1000 to 3000. Some servers had problems with players being erroneously kicked with an 'ackslimit' of 1000.")]
        [DisplayName("ackslimit")]
        public Int32 AcksLimit
        {
            get
            {
                return m_acksLimit;
            }
            set
            {
                if (m_acksLimit == value)
                {
                    return;
                }
                m_acksLimit = value;
            }
        }

        /// <summary>
        ///     Gets or sets player timeout
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("Time in miliseconds after which player will timeout when not sending any data to the server.")]
        [DisplayName("playertimeout")]
        public Int32 PlayerTimeout
        {
            get
            {
                return m_playerTimeout;
            }
            set
            {
                if (m_playerTimeout == value)
                {
                    return;
                }
                m_playerTimeout = value;
            }
        }

        /// <summary>
        ///     Gets or sets minimum connection time
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("Time in milliseconds that server will wait before accepting another incoming connection.")]
        [DisplayName("minconnectiontime")]
        public Int32 MinimumConnectionTime
        {
            get
            {
                return m_minimumConnectionTime;
            }
            set
            {
                if (m_minimumConnectionTime == value)
                {
                    return;
                }
                m_minimumConnectionTime = value;
            }
        }

        /// <summary>
        ///     Gets or sets connection cookies
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("If 0 is specified it will disable the 0.3.7 connection cookie system.")]
        [DisplayName("conncookies")]
        public Int32 ConnCookies
        {
            get
            {
                return m_connCookies;
            }
            set
            {
                if (m_connCookies == value)
                {
                    return;
                }
                m_connCookies = value;
            }
        }

        /// <summary>
        ///     Gets or set cookie logging
        /// </summary>
        [Browsable(true)]
        [Category("Network")]
        [Description("If 0 is specified it will disable logging of connection cookies requested by newly connecting players.")]
        [DisplayName("cookielogging")]
        public Int32 CookieLogging
        {
            get
            {
                return m_cookieLogging;
            }
            set
            {
                if (m_cookieLogging == value)
                {
                    return;
                }
                m_cookieLogging = value;
            }
        }

        /// <summary>
        ///     Gets or sets database logging
        /// </summary>
        [Browsable(true)]
        [Category("Settings")]
        [Description("Logs sqlite db_* function errors to the main server_log.")]
        [DisplayName("db_logging")]
        public Int32 DbLogging
        {
            get
            {
                return m_dbLogging;
            }
            set
            {
                if (m_dbLogging == value)
                {
                    return;
                }
                m_dbLogging = value;
            }
        }

        /// <summary>
        ///     Gets or sets database log queries
        /// </summary>
        [Browsable(true)]
        [Category("Settings")]
        [Description("Logs all sqlite db_query() calls including the query string.")]
        [DisplayName("db_log_queries")]
        public Int32 DbLogQueries
        {
            get
            {
                return m_dbLogQueries;
            }
            set
            {
                if (m_dbLogQueries == value)
                {
                    return;
                }
                m_dbLogQueries = value;
            }
        }

        /// <summary>
        ///     Gets or sets echo
        /// </summary>
        [Browsable(true)]
        [Category("Settings")]
        [Description("This is what the sampserver.exe echos when executing server.cfg, there is no need to change this at all as you'll be the only one who sees the the console. By default this says Executing Server Config...")]
        [DisplayName("echo")]
        public String Echo
        {
            get
            {
                return m_echo;
            }
            set
            {
                if (m_echo == value)
                {
                    return;
                }
                m_echo = value;
            }
        }

        /// <summary>
        ///     Gets or sets server name
        /// </summary>
        [Browsable(true)]
        [Category("Server")]
        [Description("This is the name that will display in the server browser for other users to see.")]
        [DisplayName("hostname")]
        public String Hostname
        {
            get
            {
                return m_hostname;
            }
            set
            {
                if (m_hostname == value)
                {
                    return;
                }
                m_hostname = value;
            }
        }

        /// <summary>
        ///     Gets or sets gamemode
        /// </summary>
        [Browsable(true)]
        [Category("Server")]
        [Description("It's possible to set the gamemode that plays, how many times it plays and when it plays by editing the values here")]
        [DisplayName("gamemode")]
        public String Gamemode
        {
            get
            {
                return m_gamemode;
            }
            set
            {
                if (m_gamemode == value)
                {
                    return;
                }
                OnGameModeChange(value, m_gamemode);
                m_gamemode = value;
            }
        }

        /// <summary>
        ///     Gets or sets website url
        /// </summary>
        [Browsable(true)]
        [Category("Server")]
        [Description("This is the website people can visit to gain more information about the server, a web url is not needed.")]
        [DisplayName("weburl")]
        public String WebURL
        {
            get
            {
                return m_weburl;
            }
            set
            {
                if (m_weburl == value)
                {
                    return;
                }
                m_weburl = value;
            }
        }

        /// <summary>
        ///     Gets or sets rcon password
        /// </summary>
        [Browsable(true)]
        [Category("Settings")]
        [Description("This is the password used to administrate the server and use the rcon, you must make sure you change this to something hard to crack so that others cannot take control of your server")]
        [DisplayName("rcon_password")]
        public String RconPassword
        {
            get
            {
                return m_rconPassword;
            }
            set
            {
                if (m_rconPassword == value)
                {
                    return;
                }
                m_rconPassword = value;
            }
        }

        /// <summary>
        ///     Gets or sets filterscripts
        /// </summary>
        [Browsable(true)]
        [Category("Server")]
        [Description("Filterscripts are scripts that run in the background of your gamemode, they are there to add extras to the server without editing the gamemode.")]
        [DisplayName("filterscripts")]
        public String Filterscripts
        {
            get
            {
                return m_filterScripts;
            }
            set
            {
                if (m_filterScripts == value)
                {
                    return;
                }
                OnFilterscriptChange(value, m_filterScripts);
                m_filterScripts = value;
            }
        }

        /// <summary>
        ///     Gets or sets plugins
        /// </summary>
        [Browsable(true)]
        [Category("Server")]
        [Description("The plugins directive allows you to specify plugins which are designed to enhance gamemodes and filterscripts.")]
        [DisplayName("plugins")]
        public String Plugins
        {
            get
            {
                return m_plugins;
            }
            set
            {
                if (m_plugins == value)
                {
                    return;
                }
                OnPluginChange(value, m_plugins);
                m_plugins = value;
            }
        }

        /// <summary>
        ///     Gets or sets server password
        /// </summary>
        [Browsable(true)]
        [Category("Server")]
        [Description("Locking your server is another option that is available for the root server administrator. You can use this to lock unwanted visitors from the server.")]
        [DisplayName("password")]
        public String Password
        {
            get
            {
                return m_password;
            }
            set
            {
                if (m_password == value)
                {
                    return;
                }
                m_password = value;
            }
        }

        /// <summary>
        ///     Gets or sets server mapname
        /// </summary>
        [Browsable(true)]
        [Category("Server")]
        [Description("The mapname appears in the server browser.")]
        [DisplayName("mapname")]
        public String Mapname
        {
            get
            {
                return m_mapname;
            }
            set
            {
                if (m_mapname == value)
                {
                    return;
                }
                m_mapname = value;
            }
        }

        /// <summary>
        ///     Gets or sets server language
        /// </summary>
        [Browsable(true)]
        [Category("Setting")]
        [Description("Specifies the language that is used on the server so players can filter servers by language in the server browser.")]
        [DisplayName("language")]
        public String Language
        {
            get
            {
                return m_language;
            }
            set
            {
                if (m_language == value)
                {
                    return;
                }
                m_language = value;
            }
        }

        [Browsable(true)]
        [Category("Setting")]
        [Description("The distance on the X,Y plane which server entities will stream in for connected players.")]
        [DisplayName("stream_distance")]
        public String StreamDistance
        {
            get
            {
                return m_streamDistance;
            }
            set
            {
                if (m_streamDistance == value)
                {
                    return;
                }
                m_streamDistance = value;
            }
        }

        protected void OnGameModeChange(String newGamemode, String oldGamemode)
        {
            if (GamemodeChanged != null)
            {
                GamemodeChanged(this, new GameModeChangeEventArgs(oldGamemode, newGamemode));
            }
        }

        protected void OnFilterscriptChange(String newScript, String oldScript)
        {
            if (FilterscriptChanged != null)
            {
                FilterscriptChanged(this, new FilterscriptChangeEventArgs(oldScript, newScript));
            }
        }

        protected void OnPluginChange(String newPlugin, String oldPlugin)
        {
            if (PluginChanged != null)
            {
                PluginChanged(this, new PlugInChangeEventArgs(oldPlugin, newPlugin));
            }
        }
    }
}
