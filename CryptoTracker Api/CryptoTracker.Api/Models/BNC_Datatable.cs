using System.Collections.Generic;

namespace CryptoTracker.Api.Models
{
    public class BNC_Datatable
    {
        public Datatable Datatable { get; }
    }

    public class Datatable
    {
        public object Data { get; set; }
        public List<Column> Columns { get; }
    }

    public class Column
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
