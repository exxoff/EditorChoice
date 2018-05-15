using System;
using System.Collections.Generic;

namespace EditorChoice.Model
{
    public interface IDataService
    {

        
        void GetData(Action<List<Editor>, Exception> callback);
    }
}
