using System;
using System.Collections.Generic;
using System.Text;


namespace Leboncoin.DAL
{
    interface IDbConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
