using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Person.Person;

namespace Person.DAL
{
    public class PersonDbDal : IPersonDbDal
    {

        private readonly ILogger<PersonDbDal> _logger;
        private readonly string _cs;

        public PersonDbDal(ILogger<PersonDbDal> logger, IConfiguration configuration)
        {
            _logger = logger;
            _cs = configuration["ConnectionStrings:Connstr"];
        }

        public void AddPerson(PersonModel person)
        {
            using (SqlConnection con = new SqlConnection(_cs))
            {
                con.Open();

                //string sql = "INSERT INTO Persons(name,address) VALUES(@param1,@param2)";
                string sql = @"declare @addressid INT 
                    insert into Addresses([streetname],[zip]) values(@streetname,@zip);
                    SELECT @addressid = Scope_identity();
                    insert into Persons([firstname], [lastname], [address])  values(@firstname, @lastname, @addressid);";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = person.Firstname;
                    cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = person.Lastname;
                    cmd.Parameters.Add("@streetname", SqlDbType.VarChar).Value = person.Streetname;
                    cmd.Parameters.Add("@zip", SqlDbType.VarChar).Value = person.Zip;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<PersonModel> ListPersons()
        {
            var queryString = @"SELECT
                    firstname,
                    lastname,
                    streetname,
                    zip
                FROM
                    Persons p
                INNER JOIN addresses a 
                ON a.id = p.address";

            return ListPersons(queryString);
        }



        public List<PersonModel> ListPersonsByLastName(string lastname)
        {
            
            var queryString = @"SELECT
                    firstname,
                    lastname,
                    streetname,
                    zip
                FROM
                    Persons p
                INNER JOIN addresses a 
                ON a.id = p.address
                Where p.lastname like '"+lastname+"';";
            //Skitten hastverkshack

            return ListPersons(queryString);
        }

        public List<PersonModel> ListPersonsByZip(string zip)
        {
            var queryString = @"SELECT
                    firstname,
                    lastname,
                    streetname,
                    zip
                FROM
                    Persons p
                INNER JOIN addresses a 
                ON a.id = p.address
                Where a.zip like '" + zip + "';";
            //Skitten hastverkshack

            return ListPersons(queryString);
        }

        private List<PersonModel> ListPersons(string queryString)
        {
            using (SqlConnection con = new SqlConnection(_cs))
            {
                List<PersonModel> personList = new List<PersonModel>();
                SqlCommand cmd = new SqlCommand(queryString, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                _logger.LogInformation("read complete");

                while (rdr.Read())
                {
                    _logger.LogInformation("record found");
                    var person = new PersonModel();


                    person.Firstname = rdr["firstname"].ToString();
                    person.Lastname = rdr["lastname"].ToString();
                    person.Streetname = rdr["streetname"].ToString();
                    person.Zip = rdr["zip"].ToString();

                    personList.Add(person);
                }

                return personList;
            }
        }
    }
}