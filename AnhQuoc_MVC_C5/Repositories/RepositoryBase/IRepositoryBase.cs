﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnhQuoc_MVC_C5
{
    public interface IRepositoryBase<T>: IEnumerable where T : class
    {
        int Count { get; }
        ObservableCollection<T> Gets();

        void LoadList();

        void Add(T item);
        void AddRange(IEnumerable<T> collection);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> collection);

        void WriteAdd(T item);
        void WriteAddRange(ObservableCollection<T> items);
        
        void WriteDelete(T item);
        void WriteUpdate(T item, string key);
    }
}
