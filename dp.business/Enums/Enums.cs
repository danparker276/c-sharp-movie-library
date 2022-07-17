using System;
using System.Collections.Generic;
using System.Text;

namespace dp.business.Enums
{

    public enum DataProvider
    {
        Npgsql,
        AdoNet
    }

    public enum Role
    {
        Anon =0,
        User = 1,
        Admin = 2,
    }
    public enum UserStatus
    {
        New = 0,
        Acitve = 1,
        Inactive = 2
    }
    /// <summary>
    /// Rental Status of Movies a User has taken out. Lost status can be stolen, lost, or another reason not returned
    /// </summary>
    /// 
    public enum RentalStatus
    {
        Reserved = 0,
        Rented = 1,
        Returned = 2,
        Lost = 3
    }
    /// <summary>
    /// The users' membership level for those that are not admin
    /// </summary>
    public enum Membership
    {
        None = 0,
        Member = 1,
        Expired = 2
    }


}
