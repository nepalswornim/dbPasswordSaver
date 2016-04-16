using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace BusinessLayer
{
    public class BllUser
    {
        public int SavePassword(string platform, string email, string username, string password, string confidentiality) {


            SqlConnection con = new SqlConnection("Data Source=SWORNIMPC; Integrated Security=True; Initial Catalog=PasswordSaveDB");
            string sql ="insert into tbl_Password values(@platform,@email,@username,@password,@confidentiality)";

            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("@platform", platform);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@confidentiality", confidentiality);
            try
            {
                con.Open();
              return  cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally {

                con.Close();

            }
         
           

            

        
        
        }

        public DataTable FetchUsersfromTable() {

            
           
            SqlConnection con = new SqlConnection("Data Source=SWORNIMPC; Integrated Security=True; Initial Catalog=PasswordSaveDB");
            string sql = "select* from tbl_Password";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        
        }

        public DataTable FetchCount()
        {



            SqlConnection con = new SqlConnection("Data Source=SWORNIMPC; Integrated Security=True; Initial Catalog=PasswordSaveDB");
            string sql = "select count(AccountId) from tbl_Password";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;


        }

        public DataTable SearchUsersFromDataTable(string platform) {
            SqlConnection con = new SqlConnection("Data Source=SWORNIMPC; Integrated Security=True; Initial Catalog=PasswordSaveDB");
            string sql = "select* from tbl_Password where PlatformName=@platform";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@platform", platform);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        
        
        }
        public DataTable SearchUsersFromDataTablewithEmail(string email)
        {
            SqlConnection con = new SqlConnection("Data Source=SWORNIMPC; Integrated Security=True; Initial Catalog=PasswordSaveDB");
            string sql = "select* from tbl_Password where Email=@email";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;



        }
      
        

        public DataTable SearchUserSuggestions(string character) {
            SqlConnection con = new SqlConnection("Data Source=SWORNIMPC; Integrated Security=True; Initial Catalog=PasswordSaveDB");
            string sql = "select* from tbl_Password where PlatformName like @platform";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@platform", character + "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;



        
        
        }
        public int UpdatePassword(string platform, string email, string username, string password, string confidentiality, int accountid)
        {
            SqlConnection con = new SqlConnection("Data Source=SWORNIMPC; Integrated Security=True; Initial Catalog=PasswordSaveDB");
            string sql = "update tbl_Password set PlatformName=@platform,Email=@email,Username=@username,Password=@password,Confidentiality=@confidentiality where AccountId=@accountid";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@platform", platform);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@confidentiality", confidentiality);
            cmd.Parameters.AddWithValue("@accountid", accountid);
            con.Open();
            return cmd.ExecuteNonQuery();
            con.Close();



        
        }

        public DataTable UserCount()
        {



            SqlConnection con = new SqlConnection("Data Source=SWORNIMPC; Integrated Security=True; Initial Catalog=PasswordSaveDB");
            string sql = "select* from tbl_Password";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;


        }

        public int DeleteUser(int userid) {
            SqlConnection con = new SqlConnection("Data Source=SWORNIMPC; Integrated Security=True;Initial Catalog=PasswordSaveDB");
            string sql = "delete from tbl_Password where AccountId=@userid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@userid", userid);
            con.Open();
            return cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
