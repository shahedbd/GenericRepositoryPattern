using GenericsRepositoryPatternsCustomMap.Configarations;
using GenericsRepositoryPatternsCustomMap.DBCommunications;
using GenericsRepositoryPatternsCustomMap.Logs;
using GenericsRepositoryPatternsCustomMap.Molel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GenericsRepositoryPatternsCustomMap.Implementations
{
    public class RepositoryPersonalInfo : Repository<PersonalInfo>, IRepositoryPersonalInfo<PersonalInfo>
    {
        protected ILogger Logger { get; set; }
        public RepositoryPersonalInfo()
        {
            Logger = logger;
        }
        public RepositoryPersonalInfo(ILogger logger)
        {
            Logger = logger;
        }


        public async Task<IEnumerable<PersonalInfo>> GetAll()
        {
            try
            {
                var cmd = new SqlCommand("sp_PersonalInfo");
                cmd.Parameters.AddWithValue("@pOptions", 4);
                var result = await GetDataReaderProc(cmd);
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw ex;
            }
        }

        public async Task<PersonalInfo> GetByID(long PersonalInfoID)
        {
            try
            {
                var cmd = new SqlCommand("sp_PersonalInfo");
                cmd.Parameters.AddWithValue("@PersonalInfoID", PersonalInfoID);
                cmd.Parameters.AddWithValue("@pOptions", 5);
                var result = await GetByDataReaderProc(cmd);
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw ex;
            }
        }

        public async Task<string> Insert(PersonalInfo entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_PersonalInfo");
                cmd.Parameters.AddWithValue("@PersonalInfoID", entity.PersonalInfoID);
                cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
                cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", entity.DateOfBirth);
                cmd.Parameters.AddWithValue("@City", entity.City);
                cmd.Parameters.AddWithValue("@Country", entity.Country);
                cmd.Parameters.AddWithValue("@MobileNo", entity.MobileNo);
                cmd.Parameters.AddWithValue("@NID", entity.NID);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters.AddWithValue("@Status", entity.Status);

                cmd.Parameters.Add("@Msg", SqlDbType.NChar, 500);
                cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@pOptions", 1);

                var result = await ExecuteNonQueryProc(cmd);
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw ex;
            }
        }

        public async Task<string> Delete(long PersonalInfoID)
        {
            try
            {
                var cmd = new SqlCommand("sp_PersonalInfo");
                cmd.Parameters.AddWithValue("@PersonalInfoID", PersonalInfoID);
                cmd.Parameters.Add("@Msg", SqlDbType.NChar, 500);


                cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@pOptions", 3);


                var result = await ExecuteNonQueryProc(cmd);
                if (Convert.ToString(result).Trim().Contains("Data Deleted Successfully"))
                {
                    var message = PersonalInfoID.ToString() + " has been Deleted.";
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw ex;
            }
        }

        public async Task<string> Update(PersonalInfo entity)
        {
            try
            {
                var cmd = new SqlCommand("sp_PersonalInfo");
                cmd.Parameters.AddWithValue("@PersonalInfoID", entity.PersonalInfoID);
                cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
                cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", entity.DateOfBirth);
                cmd.Parameters.AddWithValue("@City", entity.City);
                cmd.Parameters.AddWithValue("@Country", entity.Country);
                cmd.Parameters.AddWithValue("@MobileNo", entity.MobileNo);
                cmd.Parameters.AddWithValue("@NID", entity.NID);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters.AddWithValue("@Status", entity.Status);

                cmd.Parameters.Add("@Msg", SqlDbType.NChar, 500);
                cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@pOptions", 2);

                var result = await ExecuteNonQueryProc(cmd);
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw ex;
            }
        }

        public PersonalInfo Mapping(SqlDataReader sqldatareader)
        {
            try
            {
                PersonalInfo oPersonalInfo = new PersonalInfo();
                oPersonalInfo.PersonalInfoID = Helper.ColumnExists(sqldatareader, "PersonalInfoID") ? ((sqldatareader["PersonalInfoID"] == DBNull.Value) ? 0 : Convert.ToInt64(sqldatareader["PersonalInfoID"])) : 0;
                oPersonalInfo.FirstName = Helper.ColumnExists(sqldatareader, "FirstName") ? sqldatareader["FirstName"].ToString() : "";
                oPersonalInfo.LastName = Helper.ColumnExists(sqldatareader, "LastName") ? sqldatareader["LastName"].ToString() : "";
                oPersonalInfo.DateOfBirth = Helper.ColumnExists(sqldatareader, "DateOfBirth") ? ((sqldatareader["DateOfBirth"] == DBNull.Value) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(sqldatareader["DateOfBirth"])) : Convert.ToDateTime("01/01/1900");
                oPersonalInfo.City = Helper.ColumnExists(sqldatareader, "City") ? sqldatareader["City"].ToString() : "";
                oPersonalInfo.Country = Helper.ColumnExists(sqldatareader, "Country") ? sqldatareader["Country"].ToString() : "";
                oPersonalInfo.MobileNo = Helper.ColumnExists(sqldatareader, "MobileNo") ? sqldatareader["MobileNo"].ToString() : "";
                oPersonalInfo.NID = Helper.ColumnExists(sqldatareader, "NID") ? sqldatareader["NID"].ToString() : "";
                oPersonalInfo.Email = Helper.ColumnExists(sqldatareader, "Email") ? sqldatareader["Email"].ToString() : "";
                oPersonalInfo.Status = Helper.ColumnExists(sqldatareader, "Status") ? ((sqldatareader["Status"] == DBNull.Value) ? 0 : Convert.ToInt16(sqldatareader["Status"])) : 0;
                return oPersonalInfo;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw ex;
            }
        }
    }
}
