using System;
using Elite.DataCollecting.API.Data;

namespace Elite.DataCollecting.API.Lib
{
    public class ImporterResolver
    {
        public dynamic Resolve(string importerClassName, object[] constructorParams)
        {
            return GetImporterInstance(importerClassName, constructorParams);
        }

        private Importer GetImporterInstance(string importerClassName, object[] constructorParams)
        {
            Type type = GetDbImporterTypeByName(importerClassName);
            return (Importer)Activator.CreateInstance(type, constructorParams);
        }

        private Type GetDbImporterTypeByName(string importerClassName)
        {
            return Type.GetType("Elite.DataCollecting.API.Lib.Importers." + importerClassName);
        }
    }
}
