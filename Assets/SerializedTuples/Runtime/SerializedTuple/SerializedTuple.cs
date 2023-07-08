using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SerializedTuples.Runtime
{
    [Serializable]
    public abstract class SerializedTuple 
    {
    }

    //Add proper setters to each.
    public class SerializedTuple<T> 
    {
        #region PUBLIC_VARS
        public T v1;
        public static string NameMapFieldName => nameof(nameMap);
        #endregion

        #region PRIVATE_VARS
        protected Dictionary<string, int> idxCache = new();
        [UnityEngine.HideInInspector][UnityEngine.SerializeField] private string[] nameMap;
        #endregion

        #region CONSTRUCTOR
        public SerializedTuple(T v1)
        {
            this.v1 = v1;
        }
        #endregion

        #region PRIVATE_METHODS
        private void ValidateCache(string propertyName)
        {
            if (!idxCache.ContainsKey(propertyName))
            {
                int idx = Array.IndexOf(nameMap, propertyName);
                idxCache.Add(propertyName, idx + 1);
            }
        }

        #endregion

        #region PUBLIC_METHODS
        public MT GetPropertyValueByIdx<MT>(int index)
        {
            switch (index)
            {
                case 1:
                    return (MT)(object)v1;
                default:
                    throw new Exception($"InvalidIndexRequestException, Since its trying to access a non existant variable at index {index}!");
            }
        }

        public MT GetValue<MT>(string propertyName)
        {
            ValidateCache(propertyName);
            return GetPropertyValueByIdx<MT>(idxCache[propertyName]);
        }
        #endregion


    }


    [Serializable]
    public class SerializedTuple<T1, T2> : SerializedTuple<T1>
    {
        #region PUBLIC_VARS
        public T2 v2;
        #endregion

        #region PRIVATE_VARS
        #endregion

        #region CONSTRUCTOR
        public SerializedTuple(T1 v1 ,T2 v2) : base(v1)
        {
            this.v2 = v2;
        }
        #endregion

        #region PRIVATE_METHODS
        public new T GetPropertyValueByIdx<T>(int index) 
        {
            switch (index)
            {
                case 1:
                    return (T)(object)v1;
                case 2:
                    return (T)(object)v2;
                default:
                    throw new Exception("Some error, since its trying to access a non existant variable !");
            }
        }
        #endregion

        
    }


    [Serializable]
    public class SerializedTuple<T1, T2, T3> : SerializedTuple<T1, T2> 
    {
        public T3 v3;

        public SerializedTuple(T1 v1, T2 v2, T3 v3) : base(v1, v2)
        {
            this.v3 = v3;
        }

        protected new T GetPropertyValueByIdx<T>(int index) 
        {
            switch (index)
            {
                case 3:
                    return (T)(object)v3;
                default:
                    return base.GetPropertyValueByIdx<T>(index);
            }
        }
  
    }


    [Serializable]
    public class SerializedTuple<T1, T2, T3, T4> : SerializedTuple<T1, T2, T3>
    {
        public T4 v4;

        public SerializedTuple(T1 v1, T2 v2, T3 v3, T4 v4) : base(v1, v2, v3)
        {
            this.v4 = v4;
        }

        protected new T GetPropertyValueByIdx<T>(int index)
        {
            switch (index)
            {
                case 4:
                    return (T)(object)v4;
                default:
                    return base.GetPropertyValueByIdx<T>(index);
            }
        }

  
    }

    [Serializable]
    public class SerializedTuple<T1, T2, T3, T4, T5> : SerializedTuple<T1, T2, T3, T4>
    {
        public T5 v5;

        public SerializedTuple(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5) : base(v1, v2, v3, v4)
        {
            this.v5 = v5;
        }

        protected new T GetPropertyValueByIdx<T>(int index)
        {
            switch (index)
            {
                case 5:
                    return (T)(object)v5;
                default:
                    return base.GetPropertyValueByIdx<T>(index);
            }
        }

    }

    [Serializable]
    public class SerializedTuple<T1, T2, T3, T4, T5, T6> : SerializedTuple<T1, T2, T3, T4, T5>
    {
        public T6 v6;

        public SerializedTuple(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6) : base(v1, v2, v3, v4, v5)
        {
            this.v6 = v6;
        }

        protected new T GetPropertyValueByIdx<T>(int index)
        {
            switch (index)
            {
                case 6:
                    return (T)(object)v6;
                default:
                    return base.GetPropertyValueByIdx<T>(index);
            }
        }

        
       
        
       
    }

    [Serializable]
    public class SerializedTuple<T1, T2, T3, T4, T5, T6, T7> : SerializedTuple<T1, T2, T3, T4, T5, T6>
    {
        public T7 v7;

        public SerializedTuple(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6, T7 v7) : base(v1, v2, v3, v4, v5, v6)
        {
            this.v7 = v7;
        }

        protected new T GetPropertyValueByIdx<T>(int index)
        {
            switch (index)
            {
                case 7:
                    return (T)(object)v7;
                default:
                    return base.GetPropertyValueByIdx<T>(index);
            }
        }

        
       
    }

    [Serializable]
    public class SerializedTuple<T1, T2, T3, T4, T5, T6, T7, T8> : SerializedTuple<T1, T2, T3, T4, T5, T6, T7>
    {
        public T8 v8;

        public SerializedTuple(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6, T7 v7, T8 v8) : base(v1, v2, v3, v4, v5, v6, v7)
        {
            this.v8 = v8;
        }

        protected new T GetPropertyValueByIdx<T>(int index)
        {
            switch (index)
            {
                case 8:
                    return (T)(object)v8;
                default:
                    return base.GetPropertyValueByIdx<T>(index);
            }
        }

        
    }

    [Serializable]
    public class SerializedTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9> : SerializedTuple<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        public T9 v9;

        public SerializedTuple(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6, T7 v7, T8 v8, T9 v9) : base(v1, v2, v3, v4, v5, v6, v7, v8)
        {
            this.v9 = v9;
        }

        protected new T GetPropertyValueByIdx<T>(int index)
        {
            switch (index)
            {
                case 9:
                    return (T)(object)v9;
                default:
                    return base.GetPropertyValueByIdx<T>(index);
            }
        }

           
       
    }


    [Serializable]
    public class SerializedTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : SerializedTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        public T10 v10;

        public SerializedTuple(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6, T7 v7, T8 v8, T9 v9, T10 v10) : base(v1, v2, v3, v4, v5, v6, v7, v8, v9)
        {
            this.v10 = v10;
        }

        protected new T GetPropertyValueByIdx<T>(int index)
        {
            switch (index)
            {
                case 10:
                    return (T)(object)v10;
                default:
                    return base.GetPropertyValueByIdx<T>(index);
            }
        }

         
        
    }



}
