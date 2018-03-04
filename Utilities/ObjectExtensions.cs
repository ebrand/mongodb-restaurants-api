using System;
using MongoDB.Bson;
using MongoDB.Bson.IO;

namespace Utilities
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj, bool indented = false)
        {
            return obj.ToJson(new JsonWriterSettings { Indent = indented });
        }
    }
}