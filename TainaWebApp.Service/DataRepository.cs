using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TainaWebApp.Service.Models;
using TainaWebApp.Service.Services;

namespace TainaWebApp.Service
{
    public class DataRepository : IDataRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<DataService> _logger;

        public DataRepository(string connectionString, ILogger<DataService> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public bool TryAddPerson(PersonDto dto)
        {
            var result = false;

            try
            {
                using (var database = new SqlConnection(_connectionString))
                {
                    database.Execute("dbo.InsertPerson", new
                    {
                        FirstName = dto.Firstname,
                        Surname = dto.Surname,
                        EmailAddress = dto.EmailAddress,
                        Gender = dto.Gender,
                        PhoneNumber = dto.PhoneNumber
                    }, commandType: System.Data.CommandType.StoredProcedure);
                }

                result = true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Error occured while adding person. Exception : {0}", ex.Message);
            }

            return result;
            
        }

        public IEnumerable<PersonDto> GetPeople()
        {
            IEnumerable<PersonDto> result = null;

            try
            {
                using (var database = new SqlConnection(_connectionString))
                {
                    result = database.Query<PersonDto>("dbo.GetPeople", commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Error occured while getting the person list. Exception : {0}", ex.Message); ;
            }

            return result;
        }

        public bool TryUpdatePerson(PersonDto dto)
        {
            var result = false;

            try
            {
                using (var database = new SqlConnection(_connectionString))
                {
                    database.Execute("dbo.UpdatePerson", new
                    {
                        PersonId = dto.PersonId,
                        Firstname = dto.Firstname,
                        Surname = dto.Surname,
                        EmailAddress = dto.EmailAddress,
                        Gender = dto.Gender,
                        PhoneNumber = dto.PhoneNumber
                    }, commandType: System.Data.CommandType.StoredProcedure);
                }

                result = true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Error occured while updating person with Id {0}. Exception : {1}", dto.PersonId.Value, ex.Message);
            }

            return result;
        }
    }
}
