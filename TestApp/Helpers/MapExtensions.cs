using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace TestApp.Helpers
{
    public static class MapExtensions
    {
        public static TDest MapTo<TDest>(this object source)
        {

            return (TDest)Mapper.Map(source, source.GetType(), typeof(TDest));
        }

        public static TDest MapTo<TDest, TSource>(this TSource source, TDest destination)
        {
            return Mapper.Map(source, destination);
        }

        public static IEnumerable<TDest> MapEachTo<TDest>(this IEnumerable<object> source)
        {
            return source.MapTo<IEnumerable<TDest>>();
        }

        public static void UpdateMap<TSource, TDest>(this TSource source, TDest dest)
        {
            Mapper.Map(source, dest);
        }


        public static T Map<T>(params object[] sources) where T : class
        {
            if (!sources.Any())
            {
                return default(T);
            }

            object initialSource = sources[0];

            T mappingResult = Map<T>(initialSource);

            // Now map the remaining source objects
            if (sources.Count() > 1)
            {
                Map(mappingResult, sources.Skip(1).ToArray());
            }

            return mappingResult;
        }

        private static void Map(object destination, params object[] sources)
        {
            if (!sources.Any())
            {
                return;
            }

            Type destinationType = destination.GetType();

            foreach (object source in sources)
            {
                Type sourceType = source.GetType();
                Mapper.Map(source, destination, sourceType, destinationType);
            }
        }

        private static T Map<T>(object source) where T : class
        {
            Type destinationType = typeof(T);
            Type sourceType = source.GetType();

            object mappingResult = Mapper.Map(source, sourceType, destinationType);

            return mappingResult as T;
        }
    }
}