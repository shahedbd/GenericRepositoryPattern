﻿using System;
using System.Configuration;
using System.Data.SqlClient;

namespace GenericsRepositoryPatternsCustomMap.Configarations
{
    public static class MSSQLConn
    {
        public static SqlConnection MSSQLConnection()
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sqlConn;
        }
    }
}
