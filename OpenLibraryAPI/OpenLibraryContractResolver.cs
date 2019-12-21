using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OpenLibraryAPI
{
    public class OpenLibraryContractResolver : DefaultContractResolver
    {
        public bool UseJsonPropertyName { get; }

        public OpenLibraryContractResolver(bool useJsonPropertyName)
        {
            UseJsonPropertyName = useJsonPropertyName;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (!UseJsonPropertyName)
                property.PropertyName = property.UnderlyingName;

            return property;
        }
    }
}
