﻿using System.Data.Common;

namespace SipaksiNew.Common.Application.Data
{
    public interface IDbConnectionFactory
    {
        ValueTask<DbConnection> OpenConnectionAsync();
    }

}