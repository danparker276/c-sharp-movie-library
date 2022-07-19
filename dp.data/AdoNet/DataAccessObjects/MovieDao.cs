using dp.business.Enums;
using dp.business.Models;
using dp.data.AdoNet.SqlExecution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dp.data.AdoNet.DataAccessObjects
{
    public class MovieDao : BaseDao
    {
        public MovieDao(string dpDbConnectionString) : base(dpDbConnectionString)
        {
        }
        /// <summary>
        /// This is just basic now, but it can get complex with filters and paging
        /// </summary>
        /// <param name="searchStr"></param>
        /// <returns></returns>
        public async Task<List<Movie>> GetMovies(string searchStr)
        {
            string searchWhere = "";
            if (searchStr != null)
            {
                searchWhere = " where title like @searchStr ";
            }

            SqlQuery textsql = new SqlQuery(@" 
                select * from movies m " + searchWhere
                , 30, System.Data.CommandType.Text);
            textsql.AddInputParam("@searchStr", SqlDbType.NVarChar, "%" + searchStr + "%", false);
            

            return await _queryExecutor.ExecuteAsync(textsql, dataReader =>
            {
                List<Movie> movies = new List<Movie>();
                while (dataReader.Read())
                {
                    movies.Add(new Movie()
                    {
                        Id = SqlQueryResultParser.GetValue<Int32>(dataReader, "Id"),
                        Description = SqlQueryResultParser.GetValue<String>(dataReader, "Description"),
                        ImageUrl = SqlQueryResultParser.GetValue<String>(dataReader, "ImageUrl"),
                        Title = SqlQueryResultParser.GetValue<String>(dataReader, "Title")
                    });

                }
                return movies;
            });

        }
        /// <summary>
        /// Adds a movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>int</returns>
        public async Task<int?> AddMovie(MovieRequest movie)
        {

            SqlQuery textsql = new SqlQuery(@" Insert into movies (Title, Description, ImageUrl, Created) 
                        values (@title, @description, @imageUrl, GETUTCDATE()); select SCOPE_IDENTITY();
                ", 30, System.Data.CommandType.Text);
            textsql.AddInputParam("title", SqlDbType.NVarChar, movie.Title);
            textsql.AddInputParam("description", SqlDbType.NVarChar, movie.Description);
            textsql.AddInputParam("imageUrl", SqlDbType.NVarChar, movie.ImageUrl);
            return await _queryExecutor.ExecuteAsync(textsql, sqlReader => GetReturnValue<int?>(sqlReader));

        }



    }
}