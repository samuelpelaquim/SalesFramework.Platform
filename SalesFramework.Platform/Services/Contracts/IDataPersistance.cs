﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SalesFramework.Platform.Services.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataAccess<T>
    {
        T SelectSingle(System.Int64 ID);

        List<T> SelectAllBySearchTerm(System.String searchTerm);

        List<T> SelectAll();

        System.Boolean Create(T item);

        System.Boolean Update(T item);

        System.Boolean Delete(System.Int64 ID);
    }
}
