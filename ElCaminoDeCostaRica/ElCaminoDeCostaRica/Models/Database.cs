using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;


namespace ElCaminoDeCostaRica.Models
{
    public class Database
    {
        private SqlConnection connection;
        private string connetionPath;

        public Database()
        {
            connetionPath = ConfigurationManager.ConnectionStrings["CaminoCRConnection"].ToString();
            connection = new SqlConnection(connetionPath);
        }

        public void openConnection()
        {
            connection.Open();
        }

        public void closeConnection()
        {
            connection.Close();
        }


        public bool addWalker(User user)
        {
            SqlCommand command = new SqlCommand("ADD_WALKER", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.Int).Value = user.id;
            command.Parameters.Add("@firstName", SqlDbType.VarChar, 50).Value = user.firstName;
            command.Parameters.Add("@lastName", SqlDbType.VarChar, 100).Value = user.lastName;
            command.Parameters.Add("@email", SqlDbType.VarChar, 70).Value = user.email;
            command.Parameters.Add("@phone", SqlDbType.Int).Value = user.phone;
            command.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = user.password;

            SqlParameter output = new SqlParameter("@output", SqlDbType.VarChar, 10);
            output.Direction = ParameterDirection.Output;
            command.Parameters.Add(output);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            bool success = Convert.ToBoolean(output.Value);

            return success;
        }

        public bool checkID(int id)
        {
            SqlCommand command = new SqlCommand("CHECK_ID", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlParameter output = new SqlParameter("@output", SqlDbType.VarChar, 10);
            output.Direction = ParameterDirection.Output;
            command.Parameters.Add(output);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            bool success = Convert.ToBoolean(output.Value);

            return success;
        }


        public bool checkEmail(string email)
        {
            SqlCommand command = new SqlCommand("CHECK_EMAIL", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@email", SqlDbType.VarChar, 70).Value = email;
            SqlParameter output = new SqlParameter("@output", SqlDbType.VarChar, 10);
            output.Direction = ParameterDirection.Output;
            command.Parameters.Add(output);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            bool success = Convert.ToBoolean(output.Value);

            return success;
        }


        public List<User> userList()
        {
            List<User> Users = new List<User>();
            SqlCommand command = new SqlCommand("GET_USERSLIST", connection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
<<<<<<< HEAD
=======
                        string dis = "NO";
                        if (!reader.IsDBNull(6))
                        {
                            dis = reader.GetString(6);
                        }
>>>>>>> Cesar
                        Users.Add(
                            new User
                            {
                                id = reader.GetInt32(0),
                                firstName = reader.GetString(1),
                                lastName = reader.GetString(2),
                                email = reader.GetString(3),
                                phone = reader.GetInt32(4),
                                userType = reader.GetInt32(5),
<<<<<<< HEAD
                                password = ""
                            });
=======
                                password = "",
                                disability = dis                                
                            }); ;
>>>>>>> Cesar
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return Users;
        }

<<<<<<< HEAD
=======
        public List<Disease> getUserDisease(int id)
        {
            List<Disease> diseases = new List<Disease>();
            SqlCommand command = new SqlCommand("GET_USERDISEASE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@idUser", SqlDbType.Int).Value = id;
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        diseases.Add(
                            new Disease
                            {
                                name = Convert.ToString(reader.GetValue(0)),
                                treatment = Convert.ToString(reader.GetValue(1)),
                                idUser = Convert.ToInt32(reader.GetValue(2))
                            }); ;
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return diseases;
        }

>>>>>>> Cesar
        public bool userEdit(User user)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("UPDATE_USER", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.Int).Value = user.id;
            command.Parameters.Add("@firstName", SqlDbType.VarChar, 50).Value = user.firstName;
            command.Parameters.Add("@lastName", SqlDbType.VarChar, 100).Value = user.lastName;
            command.Parameters.Add("@email", SqlDbType.VarChar, 70).Value = user.email;
            command.Parameters.Add("@phone", SqlDbType.Int).Value = user.phone;
            command.Parameters.Add("@userType", SqlDbType.Int).Value = user.userType;
<<<<<<< HEAD
=======
            command.Parameters.Add("@disability", SqlDbType.VarChar, 500).Value = user.disability;
>>>>>>> Cesar

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return success;
        }

        public void userDelete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE_USER", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool checkPassword(string username, string password)
        {
            SqlCommand command = new SqlCommand("CHECK_PASSWORD", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@username", SqlDbType.VarChar, 70).Value = username;
            command.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = password;
            SqlParameter output = new SqlParameter("@output", SqlDbType.VarChar, 10);
            output.Direction = ParameterDirection.Output;
            command.Parameters.Add(output);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            bool success = Convert.ToBoolean(output.Value);

            return success;
        }

        public int getUserType(string email)
        {
            int type = -1;

            SqlCommand command = new SqlCommand("GET_USERTYPE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@email", SqlDbType.VarChar, 70).Value = email;
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
<<<<<<< HEAD
                        //System.Diagnostics.Debug.WriteLine(reader.GetString(0));
=======
>>>>>>> Cesar
                        type = reader.GetInt32(0);
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return type;
        }

<<<<<<< HEAD
        public int getSurveyID (DateTime day)
=======
        public int getSurveyID (Survey survey)
>>>>>>> Cesar
        {
            int id = -1;

            SqlCommand command = new SqlCommand("GET_SURVEYID", connection);
            command.CommandType = CommandType.StoredProcedure;
<<<<<<< HEAD
            command.Parameters.Add("@day", SqlDbType.Date).Value = day;
=======
            command.Parameters.Add("@version", SqlDbType.Int).Value = survey.version;
            command.Parameters.Add("@idCategory", SqlDbType.Int).Value = survey.idCategory;
            command.Parameters.Add("@idService", SqlDbType.Int).Value = survey.idService;
>>>>>>> Cesar

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                reader.Close();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return id;
        }

        public bool addSurvey(Survey survey)
        {
            SqlCommand command = new SqlCommand("ADD_SURVEY", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@version", SqlDbType.VarChar, 250).Value = survey.version;
            command.Parameters.Add("@idCategory", SqlDbType.Int).Value = survey.idCategory;
            command.Parameters.Add("@idService", SqlDbType.Int).Value = survey.idService;
<<<<<<< HEAD
            command.Parameters.Add("@day", SqlDbType.Date).Value = survey.day;
=======
>>>>>>> Cesar


            SqlParameter output = new SqlParameter("@output", SqlDbType.VarChar, 10);
            output.Direction = ParameterDirection.Output;
            command.Parameters.Add(output);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            bool success = Convert.ToBoolean(output.Value);

            return success;
        }

        public List<Survey> surveyList()
        {
            List<Survey> surveys = new List<Survey>();
            SqlCommand command = new SqlCommand("GET_SURVEYS", connection);
            command.CommandType = CommandType.StoredProcedure;
            
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        surveys.Add(
                            new Survey
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                version = Convert.ToInt32(reader.GetValue(1)),
                                idCategory = Convert.ToInt32(reader.GetValue(2)),
<<<<<<< HEAD
                                idService = Convert.ToInt32(reader.GetValue(3)),
                                day = (reader.GetDateTime(4)),//cambiar
=======
                                idService = Convert.ToInt32(reader.GetValue(3))
>>>>>>> Cesar
                            });
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return surveys;
        }

        public void surveyDelete(int id)
        {

            SqlCommand command = new SqlCommand("DELETE_SURVEY", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool surveyEdit(Survey survey)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("UPDATE_SURVEY", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.Int).Value = survey.id;
            command.Parameters.Add("@version", SqlDbType.Int).Value = survey.version;
            command.Parameters.Add("@idCategory", SqlDbType.Int).Value = survey.idCategory;
            command.Parameters.Add("@idService", SqlDbType.Int).Value = survey.idService;
<<<<<<< HEAD
            command.Parameters.Add("@day", SqlDbType.Date).Value = survey.day;
=======
>>>>>>> Cesar

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return success;
        }

        public bool addService(Service service)
        {
            SqlCommand command = new SqlCommand("ADD_SERVICE", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@name", SqlDbType.VarChar, 250).Value = service.name;
            command.Parameters.Add("@description", SqlDbType.VarChar, 500).Value = service.description;
            command.Parameters.Add("@idCategory", SqlDbType.Int).Value = service.idCategory;
            command.Parameters.Add("@idSupplier", SqlDbType.Int).Value = service.idSupplier;
            command.Parameters.Add("@idStage", SqlDbType.Int).Value = service.idStage;

            SqlParameter output = new SqlParameter("@output", SqlDbType.VarChar, 10);
            output.Direction = ParameterDirection.Output;
            command.Parameters.Add(output);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
            bool success = Convert.ToBoolean(output.Value);

            return success;
        }

        public List<Service> serviceList()
        {
            List<Service> services = new List<Service>();
            SqlCommand command = new SqlCommand("GET_SERVICESLITS", connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        services.Add(
                            new Service
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1),
                                description = reader.GetString(2),
                                idCategory = reader.GetInt32(3),
                                idSupplier = reader.GetInt32(4),
                                idStage = reader.GetInt32(5),
                            });
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return services;
        }

        public void serviceDelete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE_SERVICE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool serviceEdit(Service service)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("UPDATE_SERVICE", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.Int).Value = service.id;
            command.Parameters.Add("@name", SqlDbType.VarChar, 250).Value = service.name;
            command.Parameters.Add("@description", SqlDbType.VarChar, 500).Value = service.description;
            command.Parameters.Add("@idCategory", SqlDbType.Int).Value = service.idCategory;
            command.Parameters.Add("@idSupplier", SqlDbType.Int).Value = service.idSupplier;
            command.Parameters.Add("@idStage", SqlDbType.Int).Value = service.idStage;

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            
            return success;
        }

        public bool addCategory(Category category)
        {
            SqlCommand command = new SqlCommand("ADD_CATEGORY", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@name", SqlDbType.VarChar, 250).Value = category.name;

            SqlParameter output = new SqlParameter("@output", SqlDbType.VarChar, 10);
            output.Direction = ParameterDirection.Output;
            command.Parameters.Add(output);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            bool success = Convert.ToBoolean(output.Value);

            return success;
        }

        public List<Category> categoryList()
        {
            List<Category> categories = new List<Category>();
            SqlCommand command = new SqlCommand("GET_CATEGORYLIST", connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        categories.Add(
                            new Category
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1),
                            });
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return categories;
        }

        public bool categoryEdit(Category category)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("UPDATE_CATEGORY", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.Int).Value = category.id;
            command.Parameters.Add("@name", SqlDbType.VarChar, 250).Value = category.name;

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public void categoryDelete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE_CATEGORY", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool addSupplier(Supplier supplier)
        {
            SqlCommand command = new SqlCommand("ADD_SUPPLIER", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@name", SqlDbType.VarChar, 250).Value = supplier.name;
            command.Parameters.Add("@longitude", SqlDbType.Float).Value = supplier.longitude;
            command.Parameters.Add("@latitude", SqlDbType.Float).Value = supplier.latitude;
            command.Parameters.Add("@email", SqlDbType.VarChar, 150).Value = supplier.email;
            command.Parameters.Add("@phone", SqlDbType.Int).Value = supplier.phone;


            SqlParameter output = new SqlParameter("@output", SqlDbType.VarChar, 10);
            output.Direction = ParameterDirection.Output;
            command.Parameters.Add(output);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            bool success = Convert.ToBoolean(output.Value);

            return success;
        }

        public List<Supplier> supplierList()
        {
            List<Supplier> suppliers = new List<Supplier>();
            SqlCommand command = new SqlCommand("GET_SUPPLIERS", connection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        suppliers.Add(
                            new Supplier
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
                                name = Convert.ToString(reader.GetValue(1)),
                                email = Convert.ToString(reader.GetValue(2)),
                                phone = Convert.ToInt32(reader.GetValue(3)),
                                longitude = float.Parse(Convert.ToString(reader.GetValue(4))),
                                latitude = float.Parse(Convert.ToString(reader.GetValue(5))),

                            });
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return suppliers;
        }

        public void supplierDelete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE_SUPPLIER", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool supplierEdit(Supplier supplier)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("UPDATE_SUPPLIER", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.Int).Value = supplier.id;
            command.Parameters.Add("@name", SqlDbType.VarChar, 250).Value = supplier.name;
            command.Parameters.Add("@longitude", SqlDbType.Float).Value = supplier.longitude;
            command.Parameters.Add("@latitude", SqlDbType.Float).Value = supplier.latitude;
            command.Parameters.Add("@email", SqlDbType.VarChar, 150).Value = supplier.email;
            command.Parameters.Add("@phone", SqlDbType.Int).Value = supplier.phone;

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public bool addFeedback(Feedback feedback)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("ADD_FEEDBACK", connection);
            command.CommandType = CommandType.StoredProcedure;

<<<<<<< HEAD
            command.Parameters.Add("@idSurvey", SqlDbType.Int).Value = feedback.idSurvey;
            command.Parameters.Add("@idService", SqlDbType.Int).Value = feedback.idService;
            command.Parameters.Add("@rating", SqlDbType.Float).Value = feedback.rating;
            command.Parameters.Add("@comments", SqlDbType.VarChar, 1000).Value = feedback.comments;
=======
            command.Parameters.Add("@idQuestion", SqlDbType.Int).Value = feedback.idQuestion;
            command.Parameters.Add("@idSurvey", SqlDbType.Int).Value = feedback.idSurvey;
            command.Parameters.Add("@idService", SqlDbType.Int).Value = feedback.idService;
            command.Parameters.Add("@rating", SqlDbType.Int).Value = feedback.rating;
            command.Parameters.Add("@comments", SqlDbType.VarChar, 1000).Value = feedback.comments;
            command.Parameters.Add("@day", SqlDbType.Date).Value = feedback.day;
>>>>>>> Cesar

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public List<Feedback> feedbackList()
        {
            List<Feedback> feedbacks = new List<Feedback>();
            SqlCommand command = new SqlCommand("GET_FEEDBACKLIST", connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        feedbacks.Add(
                            new Feedback
                            {
<<<<<<< HEAD
                                idSurvey = reader.GetInt32(0),
                                idService = reader.GetInt32(1),
                                rating = reader.GetFloat(2),
                                comments = reader.GetString(3),

=======
                                idQuestion = reader.GetInt32(0),
                                idSurvey = reader.GetInt32(1),
                                idService = reader.GetInt32(2),
                                rating = reader.GetInt32(3),
                                comments = reader.GetString(4),
                                day = reader.GetDateTime(5)
>>>>>>> Cesar
                            });
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return feedbacks;
        }

        public void feedbackDelete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE_FEEDBACK", connection);
            command.CommandType = CommandType.StoredProcedure;
<<<<<<< HEAD
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
=======
            command.Parameters.Add("@idSurvey", SqlDbType.Int).Value = id;
            // Falta agregar los otro parametros de ID question y ID service
            // Editar el controlador
>>>>>>> Cesar

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool feedbackEdit(Feedback feedback)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("UPDATE_FEEDBACK", connection);
            command.CommandType = CommandType.StoredProcedure;

<<<<<<< HEAD
=======
            command.Parameters.Add("@idQuestion", SqlDbType.Int).Value = feedback.idQuestion;
>>>>>>> Cesar
            command.Parameters.Add("@idSurvey", SqlDbType.Int).Value = feedback.idSurvey;
            command.Parameters.Add("@idService", SqlDbType.Int).Value = feedback.idService;
            command.Parameters.Add("@rating", SqlDbType.Float).Value = feedback.rating;
            command.Parameters.Add("@comments", SqlDbType.VarChar, 1000).Value = feedback.comments;
<<<<<<< HEAD
=======
            command.Parameters.Add("@day", SqlDbType.Date).Value = feedback.day;
>>>>>>> Cesar

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public bool inscription(Inscription inscription)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("ADD_INSCRIPTION", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@idUser", SqlDbType.Int).Value = inscription.idUser;
            command.Parameters.Add("@idStage", SqlDbType.Int).Value = inscription.idStage;
<<<<<<< HEAD
            command.Parameters.Add("@date", SqlDbType.Date).Value = inscription.date;
            command.Parameters.Add("@code", SqlDbType.VarChar, 10).Value = inscription.code;
=======
            command.Parameters.Add("@idDates", SqlDbType.Int).Value = inscription.idDates;
>>>>>>> Cesar

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public List<Inscription> inscriptionList()
        {
            List<Inscription> inscriptions = new List<Inscription>();
            SqlCommand command = new SqlCommand("GET_INSCRIPTIONLIST", connection);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        inscriptions.Add(
                            new Inscription
                            {
                                idUser = reader.GetInt32(0),
                                idStage = reader.GetInt32(1),
<<<<<<< HEAD
                                date = reader.GetDateTime(2),
                                code = reader.GetString(3),

=======
                                idDates = reader.GetInt32(2)
>>>>>>> Cesar
                            }); ;
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return inscriptions;
        }

<<<<<<< HEAD
        public void desinscription(int id)
=======
        public void desinscription(Inscription inscription)
>>>>>>> Cesar
        {
            SqlCommand command = new SqlCommand("DELETE_INSCRIPTION", connection);
            command.CommandType = CommandType.StoredProcedure;

<<<<<<< HEAD
=======
            command.Parameters.Add("@idUser", SqlDbType.Int).Value = inscription.idUser;
            command.Parameters.Add("@idDates", SqlDbType.Int).Value = inscription.idDates;

>>>>>>> Cesar
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool inscriptionEdit(Inscription inscription)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("UPDATE_INSCRIPTION", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@idUser", SqlDbType.Int).Value = inscription.idUser;
            command.Parameters.Add("@idStage", SqlDbType.Int).Value = inscription.idStage;
<<<<<<< HEAD
            command.Parameters.Add("@date", SqlDbType.Date).Value = inscription.date;
            command.Parameters.Add("@code", SqlDbType.VarChar, 10).Value = inscription.code;
=======
            command.Parameters.Add("@idDates", SqlDbType.Int).Value = inscription.idDates;
>>>>>>> Cesar

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public bool addPicture(Picture picture)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("ADD_PICTURE", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@picture", SqlDbType.VarChar).Value = picture.picture;
            command.Parameters.Add("@caption", SqlDbType.VarChar, 250).Value = picture.caption;
            command.Parameters.Add("@idSite", SqlDbType.Int).Value = picture.idSite;
            command.Parameters.Add("@idStage", SqlDbType.Int).Value = picture.idStage;

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public List<Picture> pictureList()
        {
            List<Picture> pictures = new List<Picture>();
            SqlCommand command = new SqlCommand("GET_PICTURELIST", connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pictures.Add(
                            new Picture
                            {
                                picture = reader.GetString(0),
                                caption = reader.GetString(1),
                                idSite = reader.GetInt32(2),
                                idStage = reader.GetInt32(3),

                            });
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return pictures;
        }

        public void pictureDelete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE_PICTURE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool pictureEdit(Picture picture)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("UPDATE_PICTURE", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@picture", SqlDbType.VarChar).Value = picture.picture;
            command.Parameters.Add("@caption", SqlDbType.VarChar, 250).Value = picture.caption;
            command.Parameters.Add("@idSite", SqlDbType.Int).Value = picture.idSite;
            command.Parameters.Add("@idStage", SqlDbType.Int).Value = picture.idStage;

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public bool addQuestion(Question question)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("ADD_QUESTION", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@idSurvey", SqlDbType.Int).Value = question.idSurvey;
            command.Parameters.Add("@idService", SqlDbType.Int).Value = question.idService;
            command.Parameters.Add("@question", SqlDbType.VarChar, 1000).Value = question.question;

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public List<Question> questionList()
        {
            List<Question> questions = new List<Question>();
            SqlCommand command = new SqlCommand("GET_QUESTIONLIST", connection);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        questions.Add(
                            new Question
                            {
<<<<<<< HEAD
                                idSurvey = reader.GetInt32(0),
                                idService = reader.GetInt32(1),
                                question = reader.GetString(2),
=======
                                id = Convert.ToInt32(reader.GetValue(0)),
                                question = Convert.ToString(reader.GetValue(1)),
                                idSurvey = Convert.ToInt32(reader.GetValue(2)),
                                idService = Convert.ToInt32(reader.GetValue(3)),
                                
>>>>>>> Cesar

                            });
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return questions;
        }

        public void questionDelete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE_QUESTION", connection);
            command.CommandType = CommandType.StoredProcedure;
<<<<<<< HEAD
            command.Parameters.Add("@idSurvey", SqlDbType.Int).Value = id;
=======
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
>>>>>>> Cesar

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool questionEdit(Question question)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("UPDATE_QUESTION", connection);
            command.CommandType = CommandType.StoredProcedure;

<<<<<<< HEAD
=======
            command.Parameters.Add("@id", SqlDbType.Int).Value = question.id;
>>>>>>> Cesar
            command.Parameters.Add("@idSurvey", SqlDbType.Int).Value = question.idSurvey;
            command.Parameters.Add("@idService", SqlDbType.Int).Value = question.idService;
            command.Parameters.Add("@question", SqlDbType.VarChar, 1000).Value = question.question;

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public bool addRoute(Route route)
        {
            SqlCommand command = new SqlCommand("ADD_ROUTE", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@start", SqlDbType.VarChar, 250).Value = route.start;
            command.Parameters.Add("@finish", SqlDbType.VarChar, 500).Value = route.finish;
            command.Parameters.Add("@distance", SqlDbType.Float).Value = route.distance;

            SqlParameter output = new SqlParameter("@output", SqlDbType.VarChar, 10);
            output.Direction = ParameterDirection.Output;
            command.Parameters.Add(output);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            bool success = Convert.ToBoolean(output.Value);

            return success;
        }

        public List<Route> routeList()
        {
            List<Route> routes = new List<Route>();
            SqlCommand command = new SqlCommand("GET_ROUTELIST", connection);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        routes.Add(
                            new Route
                            {
<<<<<<< HEAD

                                id = Convert.ToInt32(reader.GetValue(0)),
                                start = Convert.ToString(reader.GetValue(1)),
                                finish = Convert.ToString(reader.GetValue(2)),
                                distance = float.Parse(Convert.ToString(reader.GetValue(3)))
=======
                                id = Convert.ToInt32(reader.GetValue(0)),
                                name = Convert.ToString(reader.GetValue(1)),
                                start = Convert.ToString(reader.GetValue(2)),
                                finish = Convert.ToString(reader.GetValue(3)),
                                distance = float.Parse(Convert.ToString(reader.GetValue(4)))
>>>>>>> Cesar
                            });
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return routes;
        }

        public void routeDelete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE_ROUTE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool routeEdit(Route route)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("UPDATE_ROUTE", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.Int).Value = route.id;
            command.Parameters.Add("@start", SqlDbType.VarChar, 250).Value = route.start;
            command.Parameters.Add("@finish", SqlDbType.VarChar, 250).Value = route.finish;
            command.Parameters.Add("@distance", SqlDbType.Float).Value = route.distance;

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public List<Coordinate> getPathInfo()
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            SqlCommand command = new SqlCommand("GET_PATHINFO", connection);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataAdapter tableAdapter = new SqlDataAdapter(command);
                DataTable queryTable = new DataTable();
                tableAdapter.Fill(queryTable);
                foreach (DataRow column in queryTable.Rows)
                {
                    coordinates.Add(
                    new Coordinate
                    {
                        latitude = Convert.ToDouble(column["latitude"]),
                        longitude = Convert.ToDouble(column["longitude"]),
                        sequence = Convert.ToInt32(column["sequence"]),
<<<<<<< HEAD
                        id_route = Convert.ToInt32(column["id_route"])
=======
                        id_route = Convert.ToInt32(column["id_route"]),
                        id_stage = Convert.ToInt32(column["id_stage"])
>>>>>>> Cesar
                    });
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return coordinates;
        }

        public List<Coordinate> getPlaceInfo()
        {
            List<Coordinate> places = new List<Coordinate>();
            SqlCommand command = new SqlCommand("GET_PLACEINFO", connection);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataAdapter tableAdapter = new SqlDataAdapter(command);
                DataTable queryTable = new DataTable();
                tableAdapter.Fill(queryTable);
                foreach (DataRow column in queryTable.Rows)
                {
                    places.Add(
                    new Coordinate
                    {
                        latitude = Convert.ToDouble(column["latitude"]),
                        longitude = Convert.ToDouble(column["longitude"]),
                        name = Convert.ToString(column["name"]),
                        description = Convert.ToString(column["description"]),
<<<<<<< HEAD
=======
                        id_stage = Convert.ToInt32(column["id_stage"]),
>>>>>>> Cesar
                        id_route = Convert.ToInt32(column["id_route"])
                    });
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return places;
        }

<<<<<<< HEAD
=======
        public bool addSection(Section section)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("ADD_SECTION", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = section.name;
            command.Parameters.Add("@idRoute", SqlDbType.Int).Value = section.idRoute;

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public List<Section> sectionList()
        {
            List<Section> sections = new List<Section>();
            SqlCommand command = new SqlCommand("GET_SECTIONLIST", connection);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sections.Add(
                            new Section
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1),
                                idRoute = reader.GetInt32(2)
                            });
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return sections;
        }

        public void deleteSection (int id)
        {
            SqlCommand command = new SqlCommand("DELETE_SECTION", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool sectionEdit (Section section)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("UPDATE_SECTION", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.Int).Value = section.id;
            command.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = section.name;
            command.Parameters.Add("@idRoute", SqlDbType.Int).Value = section.idRoute;

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

>>>>>>> Cesar
        public bool addStage(Stage stage)
        {
            SqlCommand command = new SqlCommand("ADD_STAGE", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@start", SqlDbType.VarChar, 250).Value = stage.start;
            command.Parameters.Add("@finish", SqlDbType.VarChar, 250).Value = stage.finish;
            command.Parameters.Add("@distance", SqlDbType.Float).Value = stage.distance;
            command.Parameters.Add("@minAltimetry", SqlDbType.Float).Value = stage.minAltimetry;
            command.Parameters.Add("@maxAltimetry", SqlDbType.Float).Value = stage.maxAltimetry;
            command.Parameters.Add("@idRoute", SqlDbType.Int).Value = stage.idRoute;
<<<<<<< HEAD
=======
            command.Parameters.Add("@idSection", SqlDbType.Int).Value = stage.idSection;
>>>>>>> Cesar

            SqlParameter output = new SqlParameter("@output", SqlDbType.VarChar, 10);
            output.Direction = ParameterDirection.Output;
            command.Parameters.Add(output);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            bool success = Convert.ToBoolean(output.Value);

            return success;
        }

        public List<Stage> stageList()
        {
            List<Stage> stages = new List<Stage>();
            SqlCommand command = new SqlCommand("GET_STAGELIST", connection);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        stages.Add(
                            new Stage
                            {
                                id = Convert.ToInt32(reader.GetValue(0)),
<<<<<<< HEAD
                                start = Convert.ToString(reader.GetValue(1)),
                                finish = Convert.ToString(reader.GetValue(2)),
                                distance = float.Parse(Convert.ToString(reader.GetValue(3))),
                                minAltimetry = float.Parse(Convert.ToString(reader.GetValue(4))),
                                maxAltimetry = float.Parse(Convert.ToString(reader.GetValue(5))),
                                idRoute = Convert.ToInt32(reader.GetValue(6))
=======
                                name = Convert.ToString(reader.GetValue(1)),
                                start = Convert.ToString(reader.GetValue(2)),
                                finish = Convert.ToString(reader.GetValue(3)),
                                distance = float.Parse(Convert.ToString(reader.GetValue(4))),
                                minAltimetry = float.Parse(Convert.ToString(reader.GetValue(5))),
                                maxAltimetry = float.Parse(Convert.ToString(reader.GetValue(6))),
                                idRoute = Convert.ToInt32(reader.GetValue(7)),
                                idSection = Convert.ToInt32(reader.GetValue(8))
>>>>>>> Cesar
                            });
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return stages;
        }

        public void stageDelete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE_STAGE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool stageEdit(Stage stage)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("UPDATE_STAGE", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.Int).Value = stage.id;
            command.Parameters.Add("@start", SqlDbType.VarChar, 250).Value = stage.start;
            command.Parameters.Add("@finish", SqlDbType.VarChar, 250).Value = stage.finish;
            command.Parameters.Add("@distance", SqlDbType.Float).Value = stage.distance;
            command.Parameters.Add("@minAltimetry", SqlDbType.Float).Value = stage.minAltimetry;
            command.Parameters.Add("@maxAltimetry", SqlDbType.Float).Value = stage.maxAltimetry;
            command.Parameters.Add("@idRoute", SqlDbType.Int).Value = stage.idRoute;
<<<<<<< HEAD
=======
            command.Parameters.Add("@idSection", SqlDbType.Int).Value = stage.idSection;
>>>>>>> Cesar

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public bool addSite(Site site)
        {
            SqlCommand command = new SqlCommand("ADD_SITE", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@name", SqlDbType.VarChar, 250).Value = site.name;
            command.Parameters.Add("@description", SqlDbType.VarChar, 500).Value = site.description;
            command.Parameters.Add("@longitude", SqlDbType.Float).Value = site.longitude;
            command.Parameters.Add("@latitude", SqlDbType.Float).Value = site.latitude;
            command.Parameters.Add("@idUser", SqlDbType.Int).Value = site.idUser;
            command.Parameters.Add("@idStage", SqlDbType.Int).Value = site.idStage;

            SqlParameter output = new SqlParameter("@output", SqlDbType.VarChar, 10);
            output.Direction = ParameterDirection.Output;
            command.Parameters.Add(output);

            bool success = false;
            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public List<Site> siteList()
        {
            List<Site> sites = new List<Site>();
            SqlCommand command = new SqlCommand("GET_SITELIST", connection);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sites.Add(
                            new Site
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1),
                                description = reader.GetString(2),
                                longitude = reader.GetFloat(3),
                                latitude = reader.GetFloat(4),
                                idUser = reader.GetInt32(5),
                                idStage = reader.GetInt32(6),
                            });
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return sites;
        }

        public void siteDelete(int id)
        {
            SqlCommand command = new SqlCommand("DELETE_SITE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool siteEdit(Site site)
        {
            bool success = false;

            SqlCommand command = new SqlCommand("UPDATE_SITE", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.Int).Value = site.id;
            command.Parameters.Add("@name", SqlDbType.VarChar, 250).Value = site.name;
            command.Parameters.Add("@description", SqlDbType.VarChar, 500).Value = site.description;
            command.Parameters.Add("@longitude", SqlDbType.Float).Value = site.longitude;
            command.Parameters.Add("@latitude", SqlDbType.Float).Value = site.latitude;
            command.Parameters.Add("@idUser", SqlDbType.Int).Value = site.idUser;
            command.Parameters.Add("@idStage", SqlDbType.Int).Value = site.idStage;

            SqlParameter output = new SqlParameter("@output", SqlDbType.VarChar, 10);
            output.Direction = ParameterDirection.Output;
            command.Parameters.Add(output);

            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }
<<<<<<< HEAD
=======

        public bool addDates(StageDates dates)
        {
            SqlCommand command = new SqlCommand("ADD_DATES", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@date", SqlDbType.Date).Value = dates.date;
            command.Parameters.Add("@capacity", SqlDbType.Int).Value = dates.capacity;
            command.Parameters.Add("@code", SqlDbType.VarChar, 6).Value = dates.code;
            command.Parameters.Add("@idStage", SqlDbType.Int).Value = dates.idStage;

            bool success = false;
            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public List<StageDates> getDatesList()
        {
            List<StageDates> dates = new List<StageDates>();
            SqlCommand command = new SqlCommand("GET_DATESLIST", connection);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dates.Add(
                            new StageDates
                            {
                                id = reader.GetInt32(0),
                                date = reader.GetDateTime(1),
                                capacity = reader.GetInt32(2),
                                code = reader.GetString(3),
                                idStage = reader.GetInt32(4)
                            });
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return dates;
        }

        public void deleteDates (int id)
        {
            SqlCommand command = new SqlCommand("DELETE_DATE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool datesEdit (StageDates dates)
        {
            SqlCommand command = new SqlCommand("UPDATE_DATES", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.Int).Value = dates.id;
            command.Parameters.Add("@date", SqlDbType.Date).Value = dates.date;
            command.Parameters.Add("@capacity", SqlDbType.Int).Value = dates.capacity;
            command.Parameters.Add("@code", SqlDbType.VarChar, 6).Value = dates.code;
            command.Parameters.Add("@idStage", SqlDbType.Int).Value = dates.idStage;

            bool success = false;
            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public bool addDisease(Disease disease)
        {
            SqlCommand command = new SqlCommand("ADD_DISEASE", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@name", SqlDbType.VarChar, 150).Value = disease.name;
            command.Parameters.Add("@treatment", SqlDbType.VarChar, 500).Value = disease.treatment;
            command.Parameters.Add("@idUser", SqlDbType.Int).Value = disease.idUser;

            bool success = false;
            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }

        public List<Disease> diseasesList ()
        {
            List<Disease> diseases = new List<Disease>();
            SqlCommand command = new SqlCommand("GET_DISEASELIST", connection);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        diseases.Add(
                            new Disease
                            {
                                name = reader.GetString(0),
                                treatment = reader.GetString(1),
                                idUser = reader.GetInt32(3)
                            });
                    }
                }
                reader.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }

            return diseases;
        }

        public void deleteDisease(Disease disease)
        {
            SqlCommand command = new SqlCommand("DELETE_DISEASE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@name", SqlDbType.VarChar, 150).Value = disease.name;
            command.Parameters.Add("@idUser", SqlDbType.Int).Value = disease.idUser;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public bool diseaseEdit(Disease disease)
        {
            SqlCommand command = new SqlCommand("UPDATE_DISEASE", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@name", SqlDbType.VarChar, 150).Value = disease.name;
            command.Parameters.Add("@treatment", SqlDbType.VarChar, 500).Value = disease.treatment;
            command.Parameters.Add("@idUser", SqlDbType.Int).Value = disease.idUser;

            bool success = false;
            try
            {
                success = command.ExecuteNonQuery() >= 1;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return success;
        }


>>>>>>> Cesar
    }
}