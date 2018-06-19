using DistributedDB.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedDB.Database
{
    public class DBService: IDisposable
    {
        private readonly SqlConnection travel1 = new SqlConnection(StaticConstants.DB1);
        private readonly SqlConnection travel2 = new SqlConnection(StaticConstants.BD2);
        private readonly SqlConnection travel3 = new SqlConnection(StaticConstants.BD3);

        public DBService()
        {
            travel1.Open();
            travel2.Open();
            travel3.Open();
        }

        public List<DataRow> GetClientes()
        {
            var table = new DataTable();
            using (SqlCommand com = new SqlCommand("Select * from Cliente1", travel1))
            {
                table.Load(com.ExecuteReader());
            }

            var table2 = new DataTable();
            using (SqlCommand com = new SqlCommand("Select * from Cliente2", travel2))
            {
                table2.Load(com.ExecuteReader());
            }

            table.Merge(table2);
            return table.AsEnumerable().ToList();
        }

		public List<DataRow> GetCiudades()
		{
			var table = new DataTable();
			using (SqlCommand com = new SqlCommand("Select * from Ciudades1", travel1))
			{
				table.Load(com.ExecuteReader());
			}

			var table2 = new DataTable();
			using (SqlCommand com = new SqlCommand("Select * from Ciudades1", travel2))
			{
				table2.Load(com.ExecuteReader());
			}

			var table3 = new DataTable();
			using (SqlCommand com = new SqlCommand("Select * from Ciudades2", travel3))
			{
				table3.Load(com.ExecuteReader());
			}

			table.Merge(table2);
			table.Merge(table3);
			return table.AsEnumerable().ToList();
		}

		public List<DataRow> GetPaises()
		{
			var table = new DataTable();
			using (SqlCommand com = new SqlCommand("Select * from Paises1", travel1))
			{
				table.Load(com.ExecuteReader());
			}

			var table2 = new DataTable();
			using (SqlCommand com = new SqlCommand("Select * from Paises1", travel2))
			{
				table2.Load(com.ExecuteReader());
			}

			var table3 = new DataTable();
			using (SqlCommand com = new SqlCommand("Select * from Paises2", travel3))
			{
				table3.Load(com.ExecuteReader());
			}

			table.Merge(table2);
			table.Merge(table3);
			return table.AsEnumerable().ToList();
		}

		public List<DataRow> GetDestino()
		{
			var table = new DataTable();
			using (SqlCommand com = new SqlCommand("Select * from Destinos1", travel1))
			{
				table.Load(com.ExecuteReader());
			}

			var table2 = new DataTable();
			using (SqlCommand com = new SqlCommand("Select * from Destinos2", travel3))
			{
				table2.Load(com.ExecuteReader());
			}

			table.Merge(table2);
			return table.AsEnumerable().ToList();
		}

        public List<DataRow> GetViajes()
        {
            var table = new DataTable();
            using (SqlCommand com = new SqlCommand("Select * from Viajes1", travel1))
            {
                table.Load(com.ExecuteReader());
            }

            var table2 = new DataTable();
            using (SqlCommand com = new SqlCommand("Select * from Viajes1", travel2))
            {
                table2.Load(com.ExecuteReader());
            }

            table.Merge(table2);
            return table.AsEnumerable().ToList();
        }

        public void Dispose()
        {
            travel1.Close();
            travel2.Close();
            travel3.Close();
        }
    }
}
