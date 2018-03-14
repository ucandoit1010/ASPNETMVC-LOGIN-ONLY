using System;
using System.Configuration;

namespace BusinessLayer.Common
{
    public static class SQLConnection
    {
        public static string GetConnection()
        {

            return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
        

    }
}
