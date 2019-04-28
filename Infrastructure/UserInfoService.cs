using System;
using System.Threading.Tasks;
using Dapper;
using ModulSchool.Models;
using ModulSchool.Services;
using Npgsql;

namespace ModulSchool.Infrasctructure
{
    public class UserInfoService : IUserInfoService
    {
        private const string ConnectionString =
            "host=localhost;port=5432;database=modul;username=marsel-dev;password=inversion";

        public async Task<User> GetById(Guid id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<User>(
                    "SELECT * FROM public.users WHERE Id = @id", new {id});
            }
        }

        public async Task<User> AppendUser(User user)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = "INSERT INTO public.users (Id, Email, Nickname, Phone) VALUES (@id, @email, @nickname, @phone) RETURNING *;";

                return await connection.QuerySingleAsync<User>(query, user);
            }
        }
    }
}

