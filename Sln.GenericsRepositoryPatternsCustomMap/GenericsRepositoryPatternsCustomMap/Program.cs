using GenericsRepositoryPatternsCustomMap.Implementations;
using GenericsRepositoryPatternsCustomMap.Molel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericsRepositoryPatternsCustomMap
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonalInfo _PersonalInfo = new PersonalInfo
            {
                FirstName = "Ramidur",
                LastName = "Rahman",
                DateOfBirth = DateTime.Now.AddYears(-28),
                City = "Dahak",
                Country = "Banglades",
                Email = "ramidur@gmail.comn",
                MobileNo = "01723289333",
                NID = "798465132798465132",
                Status = 1
            };

            var result = InsertIntoMSSQLDB(_PersonalInfo);
            Console.WriteLine(result.Result.ToString().Trim());

            Console.ReadKey();

        }


        public async static Task<string> InsertIntoMSSQLDB(PersonalInfo entity)
        {
            try
            {
                //Test: Get all data
                IEnumerable<PersonalInfo> list = await GetAllPersonalInfo();

                var result = new RepositoryPersonalInfo().Insert(entity);
                return result.Result.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static Task<IEnumerable<PersonalInfo>> GetAllPersonalInfo()
        {
            try
            {
                var result = new RepositoryPersonalInfo().GetAll();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
