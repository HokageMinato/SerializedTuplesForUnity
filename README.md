# SerializedTuplesForUnity
Serialized Tuples allow you to create data objects with any type combinations you desire.

Declarations range from **SerializedTuple<T1>** to **SeralizedTuple<T1,T2,T3,T4,T5,T6,T7,T8>** allowing various combinations of data.

Use **[SerializedTupleLabels("Your Custom Field Name")]** to decorate each tuple values with appropriate names for inspector accessibility.

There are many usecases where one can use it to cross data accross assemblies, (Provided there is a common reference to this one ofc).
or use it to pass data to nonMono systems where there is a need to link data(parameters) in inspector with systems/classes which are POCC but non serialized.

Values can be access either by tuple.v1/v2/v.n or by invoking  _T GetValue(string propertyName)_.

