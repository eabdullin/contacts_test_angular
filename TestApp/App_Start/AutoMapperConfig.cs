using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace TestApp
{
    public static class AutoMapperConfig
    {
        private static readonly object LockObject = new object();
        private static bool _isRegistered;

        public static void RegisterMappings()
        {
            if (_isRegistered == false)
            {
                lock (LockObject)
                {
                    IEnumerable<Type> profiles = typeof(AutoMapperConfig).Assembly
                        .GetTypes()
                        .Where(x => typeof(Profile).IsAssignableFrom(x));
                    _isRegistered = true;
                    Mapper.Initialize(cfg =>
                    {
                        foreach (Type profile in profiles)
                        {
                            cfg.AddProfile((Profile)Activator.CreateInstance(profile));
                        }
                    });
                }
            }
        }
    }
}