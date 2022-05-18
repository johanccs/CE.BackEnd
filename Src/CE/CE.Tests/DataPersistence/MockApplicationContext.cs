using System;
using System.Collections.Generic;

namespace CE.Tests.DataPersistence
{
    public class MockApplicationContext
    {
        internal List<OrderEntity> GetAll()
        {
            return new List<OrderEntity>();
        }
    }
}