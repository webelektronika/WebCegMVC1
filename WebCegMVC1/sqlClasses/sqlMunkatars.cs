using Microsoft.Data.SqlClient;
using WebCegMVC1.Models;

// 10.194.101.123

namespace WebCegMVC1.sqlClasses
{
    public class sqlMunkatars
    {
        private string connectString = null;

        public sqlMunkatars(string connect)
        {
            connectString = connect;
        }

        public List<modellMunkatars> getLista()
        {
            string sqlCommand = null;
            List<modellMunkatars> lista = new List<modellMunkatars>();

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                sqlCommand = "Select * from munkatars";

                connection.Open();

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        modellMunkatars mm = new modellMunkatars();
                        mm.id = Convert.ToInt32(dataReader["ID"]);
                        mm.nev = Convert.ToString(dataReader["Nev"]);
                        mm.varos = Convert.ToString(dataReader["Varos"]);
                        mm.beosztas = Convert.ToString(dataReader["Beosztas"]);
                        mm.nyelvtudas = Convert.ToString(dataReader["Nyelvtudas"]);

                        lista.Add(mm);
                    }
                }
            }
            return lista;
        }

        public modellMunkatars getSzemely(int _id)
        {
            string sqlCommand = null;
            modellMunkatars mm = new modellMunkatars();

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                sqlCommand = "Select * from munkatars Where Id = '" +_id + "' ";

                connection.Open();

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        mm.id = Convert.ToInt32(dataReader["ID"]);
                        mm.nev = Convert.ToString(dataReader["Nev"]);
                        mm.varos = Convert.ToString(dataReader["Varos"]);
                        mm.beosztas = Convert.ToString(dataReader["Beosztas"]);
                        mm.nyelvtudas = Convert.ToString(dataReader["Nyelvtudas"]);

                    }
                }
            }
            return mm;
        }

        public bool setRekordParam(modellMunkatars mm)
        {
            string sqlCommand = "INSERT INTO munkatars (Id, Nev, Varos, Beosztas, Nyelvtudas) " +
                "values (@pId, @pNev, @pVaros, @pBeosztas, @pNyelvtudas)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    SqlCommand command = new SqlCommand(sqlCommand, connection);

                    command.Parameters.AddWithValue("@pId", mm.id);
                    command.Parameters.AddWithValue("@pNev", mm.nev);
                    command.Parameters.AddWithValue("@pVaros", mm.varos);
                    command.Parameters.AddWithValue("@pBeosztas", mm.beosztas);
                    command.Parameters.AddWithValue("@pNyelvtudas", mm.nyelvtudas);


                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
