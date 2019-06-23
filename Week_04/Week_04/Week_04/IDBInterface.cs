using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Week_04
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
