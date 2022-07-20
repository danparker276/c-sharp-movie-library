using dp.business.Enums;
using dp.business.Models;
using dp.data.AdoNet.SqlExecution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dp.data.AdoNet.DataAccessObjects
{
    public class RentalDao : BaseDao
    {
        public RentalDao(string dpDbConnectionString) : base(dpDbConnectionString)
        {
        }

        /// <summary>
        /// Gets rentals for userId with status = rented
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<RentalMovies>> GetCurrentRentals(int userId)
        {

            SqlQuery textsql = new SqlQuery(@" 
                select r.*, m.Description, m.Title, m.ImageUrl from rentals r inner join movies m on r.movieId=m.id
                where r.userId=@userId 
                and r.status = @status;
                ", 30, System.Data.CommandType.Text);
            textsql.AddInputParam("userId", SqlDbType.Int, userId);
            textsql.AddInputParam("status", SqlDbType.Int, RentalStatus.Rented);

            return await _queryExecutor.ExecuteAsync(textsql, dataReader =>
            {
                List<RentalMovies> movies = new List<RentalMovies>();
                while (dataReader.Read())
                {
                    movies.Add( new RentalMovies()
                    {
                        UserId = SqlQueryResultParser.GetValue<Int32>(dataReader, "userId"),
                        Status = SqlQueryResultParser.GetValue<RentalStatus>(dataReader, "status"),
                        MovieId = SqlQueryResultParser.GetValue<Int32>(dataReader, "movieId"),
                        Description = SqlQueryResultParser.GetValue<String>(dataReader, "Description"),
                        ImageUrl = SqlQueryResultParser.GetValue<String>(dataReader, "ImageUrl"),
                        Title = SqlQueryResultParser.GetValue<String>(dataReader, "Title"),
                        Rented = SqlQueryResultParser.GetValue<DateTime>(dataReader, "Rented"),
                        Returned = SqlQueryResultParser.GetValue<DateTime>(dataReader, "Returned",false),


                    });
                 
                }
                return movies;
            });

        }

        /// <summary>
        /// We won't do any business logic here, valdiations and number or rentals per user done in service
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public async Task<int?> AddRental(int userId, int movieId)
        {

            SqlQuery textsql = new SqlQuery(@" Insert into rentals (UserId, MovieId, Status, Rented) values (@userId, @movieId, @status, GETUTCDATE());
                select SCOPE_IDENTITY();", 30, System.Data.CommandType.Text);
            textsql.AddInputParam("userId", SqlDbType.Int, userId);
            textsql.AddInputParam("movieId", SqlDbType.Int, movieId);
            textsql.AddInputParam("status", SqlDbType.Int, RentalStatus.Rented);
            return await _queryExecutor.ExecuteAsync(textsql, sqlReader => GetReturnValue<int?>(sqlReader));

        }
        /// <summary>
        /// Updates RentalStatus
        /// </summary>
        /// <param name="rentalId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task UpdateRental(int rentalId, RentalStatus status)
        {

            SqlQuery textsql = new SqlQuery(@" update rentals set status=@status where Id=@rentalId;"
                , 30, System.Data.CommandType.Text);
            textsql.AddInputParam("rentalId", SqlDbType.Int, rentalId);
            textsql.AddInputParam("status", SqlDbType.Int, (int)status);
            await _queryExecutor.ExecuteAsync(textsql);

        }


    }
}