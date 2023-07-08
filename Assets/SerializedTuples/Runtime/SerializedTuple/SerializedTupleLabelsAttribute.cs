using System;

namespace SerializedTuples
{

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class SerializedTupleLabelsAttribute : Attribute
    {
        #region PUBLIC_VARS
        public readonly string[] labels;
        #endregion

        #region CONSTRUCTORS
        public SerializedTupleLabelsAttribute(string v1)
        {
            labels = new string[1] { v1 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2)
        {
            labels = new string[2] { v1, v2 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2, string v3)
        {
            labels = new string[3] { v1, v2, v3 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2, string v3, string v4)
        {
            labels = new string[4] { v1, v2, v3, v4 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2, string v3, string v4, string v5)
        {
            labels = new string[5] { v1, v2, v3, v4, v5 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2, string v3, string v4, string v5,
                                              string v6)
        {
            labels = new string[6] { v1, v2, v3, v4, v5, v6 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2, string v3, string v4, string v5,
                                              string v6, string v7)
        {
            labels = new string[7] { v1, v2, v3, v4, v5, v6, v7 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2, string v3, string v4, string v5,
                                              string v6, string v7, string v8)
        {
            labels = new string[8] { v1, v2, v3, v4, v5, v6, v7, v8 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2, string v3, string v4, string v5,
                                              string v6, string v7, string v8, string v9)
        {
            labels = new string[9] { v1, v2, v3, v4, v5, v6, v7, v8, v9 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2, string v3, string v4, string v5,
                                              string v6, string v7, string v8, string v9, string v10)
        {
            labels = new string[10] { v1, v2, v3, v4, v5, v6, v7, v8, v9, v10 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2, string v3, string v4, string v5,
                                              string v6, string v7, string v8, string v9, string v10,
                                              string v11)
        {
            labels = new string[11] { v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2, string v3, string v4, string v5,
                                              string v6, string v7, string v8, string v9, string v10,
                                              string v11, string v12)
        {
            labels = new string[12] { v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2, string v3, string v4, string v5,
                                              string v6, string v7, string v8, string v9, string v10,
                                              string v11, string v12, string v13)
        {
            labels = new string[13] { v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2, string v3, string v4, string v5,
                                              string v6, string v7, string v8, string v9, string v10,
                                              string v11, string v12, string v13, string v14)
        {
            labels = new string[14] { v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14 };
        }

        public SerializedTupleLabelsAttribute(string v1, string v2, string v3, string v4, string v5,
                                              string v6, string v7, string v8, string v9, string v10,
                                              string v11, string v12, string v13, string v14, string v15)
        {
            labels = new string[15] { v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15 };
        }
        #endregion
    }






}
