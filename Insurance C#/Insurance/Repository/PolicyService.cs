
using Insurance.Exceptions;
using Insurance.Model;
using Insurance.Utility;
using Microsoft.Data.SqlClient;

namespace Insurance.Repository
{
    internal class PolicyService : IPolicyService
    {
        string sqlConnection = null;
        SqlCommand cmd = null;

        public PolicyService()
        {
            //sqlConnection = "Server=PRASHI;Database=Insurance;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true";
            sqlConnection = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();

        }

        //Create Policy
        public bool CreatePolicy(object policyName)
        {
            int policyId = 0;
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                cmd.CommandText = "SELECT Top 1 * FROM Policy ORDER BY policyId DESC";
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        policyId = (int)reader["policyId"];
                        //return true;
                    }
                    else
                    {
                        throw new Exception("Can't Add Values to the Table Policy.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //return false;
                }
                finally
                {
                    connection.Close();
                    policyId++;
                }
            }
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                cmd.CommandText = "INSERT INTO Policy (PolicyId, PolicyName) VALUES (@id,@name)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", policyId);
                cmd.Parameters.AddWithValue("@name", policyName);

                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    int reader = cmd.ExecuteNonQuery();
                    if (reader > 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("Can't Add Values to the Table Employee.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        //Get Policy
        public Policy GetPolicy(int policyId)
        {
            Policy policy = null;
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                cmd.CommandText = "SELECT policyName FROM Policy Where policyId = @policyId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@policyId", policyId);
                try
                {
                    connection.Open();
                    cmd.Connection = connection;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        policy = new Policy();
                        policy.policyName = (string)reader["policyName"];
                        return policy;
                    }
                    else
                    {
                        throw new PolicyNotFoundException("Policy Not Fount");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return policy;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //Get All Policy
        public List<Policy> GetAllPolicy()
        {
            List<Policy> policies = new List<Policy>();
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                cmd.CommandText = "SELECT * FROM Policy";
                try
                {

                    connection.Open();
                    cmd.Connection = connection;
                    bool flag = false;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Policy policy = new Policy();
                        policy.policyName = (string)reader["policyName"];
                        policy.policyId = (int)reader["policyId"];
                        policies.Add(policy);
                        flag = true;
                    }
                    if (!flag)
                    {
                        throw new Exception("Records Not Found");
                    }
                    return policies;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return policies;
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        //Delete Policy
        public bool DeletePolicy(int policyID)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                cmd.CommandText = "DELETE FROM Policy WHERE policyID = @policyId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@policyId", policyID);
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    int reader = cmd.ExecuteNonQuery();
                    if (reader > 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new PolicyNotFoundException($"Policy ID :: {policyID} NOT FOUND");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // Update Policy
        public bool UpdatePolicy(string policyName,int policyId)
        {
            using(SqlConnection connection = new SqlConnection(sqlConnection))
            {
                cmd.CommandText = $"UPDATE policy SET policyName = @new WHERE policyId = @policyId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@policyId", policyId);
                cmd.Parameters.AddWithValue("@new", policyName);
                try
                {
                    connection.Open();
                    cmd.Connection = connection;

                    int reader = cmd.ExecuteNonQuery();
                    if (reader > 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new PolicyNotFoundException("policy Not Fount");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
