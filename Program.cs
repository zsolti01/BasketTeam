﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace BasketTeam
{
    internal class Program
    {

        public static Connect conn = new Connect();

        public static void GetAllData()
        {
            conn.Connection.Open();

            string sql = "SELECT * FROM `player`";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            do
            {
                var player = new
                {
                    Id = dr.GetInt32(4),
                    Name = dr.GetString(0),
                    Height = dr.GetInt32(1),
                    Weight = dr.GetInt32(2),
                    CreatedTime = dr.GetDateTime(3)
                };

                Console.WriteLine($"Játékos adatok: {player.Name},{player.Height}");

            } while (dr.Read());
            
            dr.Close();

            conn.Connection.Close();
        }

        static void Main(string[] args)
        {
            GetAllData();
        }
    }
}
